using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Doodle.Infrastructure.DoodleClient
{
    public interface IDoodleClient
    {
        public Task<T> GetAsync<T>(string requestUri);
        public Task<T> PostAsync<T>(string requestUri, string json);
        public Task<T> PutAsync<T>(string api, string json);
        public Task<T> DeleteAsync<T>(string api);
        public Task<T> SendAsync<T>(string api, string Content, HttpMethod httpMethod);
    }
}
