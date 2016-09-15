using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public class HttpLoggingDelegatingHandler : DelegatingHandlerBase
    {
        public enum Level
        {
            NONE,
            BASIC,
            HEADERS,
            BODY
        };

        public Level LogLevel { get; set; }

        public HttpLoggingDelegatingHandler() : base() { }

        public HttpLoggingDelegatingHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (LogLevel == Level.NONE)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            Console.WriteLine("Request: {0} {1}", request.Method, request.RequestUri);
            if (LogLevel == Level.BODY || LogLevel == Level.HEADERS)
            {
                Console.WriteLine("  headers:");
                foreach (var header in request.Headers)
                {
                    Console.WriteLine("    {0} : {1}", header.Key, string.Join(" ", header.Value));
                }
            }

            if (LogLevel == Level.BODY)
            {
                if (request.Content != null)
                {
                    string content = await request.Content.ReadAsStringAsync();
                    Console.WriteLine("  body: " + content);
                }
                // TODO: Checking for binary request contents and omitting them
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            if (LogLevel == Level.BODY || LogLevel == Level.HEADERS)
            {
                Console.WriteLine("Response:");
                Console.WriteLine("  headers:");
                foreach (var header in response.Headers)
                {
                    Console.WriteLine("    {0} : {1}", header.Key, string.Join(" ", header.Value));
                }
            }


            if (LogLevel == Level.BODY)
            {
                bool isEncoded = isHeaderExists(response.Content.Headers, "Content-Encoding");
                if (!isEncoded && response.Content != null)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    string contentType = getHeader(response.Content.Headers, "Content-Type");
                    if (contentType != null && contentType.Contains("application/json"))
                    {
                        try
                        {
                            dynamic parsedJson = JsonConvert.DeserializeObject(content);
                            content = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
                        }
                        catch (Exception) { /*ignore and print below as it is*/ }
                    }
                    Console.WriteLine(content);
                }

                // TODO: Checking for binary response content and omitting them
                if (isEncoded)
                {
                    Console.WriteLine("    body: <encoded body omitted>");
                }
            }
            return response;
        }
    }
}
