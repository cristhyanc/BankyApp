﻿using BankyApp.Shared.Exceptions;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankyApp.Services
{ 
    public class RestClient
{

    string Toke;
    JsonSerializerSettings _deserializationSettings;
    public RestClient(string toke)
    {
        this.Toke = toke;

        _deserializationSettings = new JsonSerializerSettings
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,

            //ContractResolver = new ReadOnlyJsonContractResolver(),
            //Converters = new List<JsonConverter>
            //    {
            //        new Iso8601TimeSpanConverter()
            //    }
        };
    }

    private async Task<HttpResponseMessage> Call(string url, HttpMethod method, CancellationToken cancellationToken, object data = null)
    {
        using (var httpClient = new HttpClient())
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (method == HttpMethod.Get)
            {
                if (data != null)
                {
                    var query = data.ToString();
                    url += "?" + query;
                }
            }

            using (var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = method })
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (!string.IsNullOrEmpty(Toke))
                {
                    List<string> values = new List<string>();
                    httpClient.DefaultRequestHeaders.Clear();
                    values.Add(Toke);
                    httpClient.DefaultRequestHeaders.Add("iSystainToken", values);
                    // httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", this.Toke);
                }
                cancellationToken.ThrowIfCancellationRequested();
                if (method != HttpMethod.Get)
                {
                    var jsonContent = JsonConvert.SerializeObject(data);
                    request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }



                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                   
                    var excep = new ConnectionException(ex.Message);
                    
                    throw excep;
                }

                return response;
            }

        }
    }

    public async Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null, CancellationToken cancellationToken = default(CancellationToken)) where TResult : class
    {
        try
        {
            HttpResponseMessage response = await Call(url, method, cancellationToken, data);
            cancellationToken.ThrowIfCancellationRequested();
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {


                try
                {
                    var result = JsonConvert.DeserializeObject<TResult>(responseContent, _deserializationSettings);
                    return result;
                }
                catch (JsonException ex)
                {
                    if (response != null)
                    {
                        response.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", ex);
                }


            }
            else
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var excep = new AuthorizeException();
                    
                    throw excep;
                }


                if (response.StatusCode == System.Net.HttpStatusCode.PreconditionFailed)
                {
                    var excep = new ValidationException(responseContent);
                    throw excep;
                }
                else
                {
                    throw new Exception(responseContent);
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> MakeApiCall(string url, HttpMethod method, object data = null, CancellationToken cancellationToken = default(CancellationToken))
    {
        try
        {
            HttpResponseMessage response = await Call(url, method, cancellationToken, data);
            cancellationToken.ThrowIfCancellationRequested();
            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            else
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var excep = new AuthorizeException();                    
                    throw excep;
                }

                var stringSerialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.PreconditionFailed)
                {
                    var excep = new ValidationException(stringSerialized);
                    throw excep;
                }
                else
                {
                    throw new Exception(stringSerialized);
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}
}