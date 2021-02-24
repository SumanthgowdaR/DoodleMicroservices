using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Doodle.Infrastructure.DoodleClient
{
    public class DoodleClient : IDoodleClient
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoodleClient(HttpClient client,  IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _client = client;

        }


        public async Task<T> GetAsync<T>(string requestUri)
        {
            try
            {
                var response = await _client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    
                    throw new HttpRequestException(errorMessage);
                }
            }
            catch (Exception e)
            {
               
                throw;
            }
        }

        public async Task<T> PostAsync<T>(string requestUri, string json)
        {
            try
            {
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var response = await _client.PostAsync(requestUri, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(responseData);
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    
                    throw new HttpRequestException(errorMessage);
                }
            }
            catch (Exception e)
            {
               
                throw;
            }
        }

        public Task<T> PutAsync<T>(string api, string json)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync<T>(string api)
        {
            throw new NotImplementedException();
        }

        public Task<T> SendAsync<T>(string api, string Content, HttpMethod httpMethod)
        {
            throw new NotImplementedException();
        }
    }
}
