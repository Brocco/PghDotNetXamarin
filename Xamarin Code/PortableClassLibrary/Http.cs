using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PortableClassLibrary
{
    public static class Http
    {
        /// <summary>
        /// Get data via HTTP
        /// </summary>
        /// <param name="url">The URL to request data from</param>
        /// <returns>The response message</returns>
        public static async Task<HttpResponseMessage> Get(string url)
        {
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler, true);

            var responseMessage = await client.GetAsync(url);
            return responseMessage;
        }

        /// <summary>
        /// Post data via HTTP
        /// </summary>
        /// <param name="url">The URL to post data to</param>
        /// <param name="data">The data to be posted</param>
        /// <returns>The response message</returns>
        public static async Task<HttpResponseMessage> Post(string url, IEnumerable<KeyValuePair<string, string>> data)
        {
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler, true);

            var content = new FormUrlEncodedContent(data);
            
            var responseMessage = await client.PostAsync(url, content);
            return responseMessage;
        }

        /// <summary>
        /// Delete data via HTTP
        /// </summary>
        /// <param name="url">The URL to post data to</param>
        /// <returns>The response message</returns>
        public static async Task<HttpResponseMessage> Delete(string url)
        {
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler, true);

            var responseMessage = await client.DeleteAsync(url);
            return responseMessage;
        }

        /// <summary>
        /// Reads the content string from the response message
        /// </summary>
        /// <param name="responseMessage">The message to be parsed</param>
        /// <returns>The conent of the response message</returns>
        public static async Task<string> GetContentString(HttpResponseMessage responseMessage)
        {
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            return responseString;
        }

        /// <summary>
        /// Build a URL
        /// </summary>
        /// <param name="urlBase">The base URL to build upon</param>
        /// <param name="data">The values to be placed in the query string.</param>
        /// <returns>The new URL</returns>
        public static string BuildUrl(string urlBase, IEnumerable<KeyValuePair<string, string>> data)
        {
            var sb = new StringBuilder(urlBase);

            foreach (var keyValuePair in data)
            {
                sb.Append(string.Format("&{0}={1}", keyValuePair.Key, keyValuePair.Value));
            }

            return sb.ToString();
        }
    }
}
