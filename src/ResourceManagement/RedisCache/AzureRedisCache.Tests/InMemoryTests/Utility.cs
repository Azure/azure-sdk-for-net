using Microsoft.Azure;
using Microsoft.Azure.Management.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AzureRedisCache.Tests
{
    public static class Utility
    {
        public static RedisManagementClient GetRedisManagementClient(string responseString, string requestIdHeader, HttpStatusCode statusCode)
        {
            var httpResponse = new HttpResponseMessage();
            httpResponse.Content = new StreamContent(GenerateStreamFromString(responseString));
            if (!String.IsNullOrEmpty(requestIdHeader))
            {
                httpResponse.Headers.Add("x-ms-request-id", requestIdHeader);
            }
            httpResponse.StatusCode = statusCode;

            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            RedisManagementClient client = new RedisManagementClient(token).WithHandler(new DummyResponseDelegatingHandler(httpResponse));
            return client;
        }

        private static Stream GenerateStreamFromString(string source)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(source);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
