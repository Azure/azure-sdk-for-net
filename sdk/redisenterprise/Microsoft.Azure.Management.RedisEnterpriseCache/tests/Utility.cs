// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure;
using Microsoft.Azure.Management.RedisEnterprise;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AzureRedisEnterpriseCache.Tests
{
    public static class Utility
    {
        public static redisenterpriseClient GetRedisEnterpriseClient(string responseString, string requestIdHeader, HttpStatusCode statusCode)
        {
            var httpResponse = new HttpResponseMessage();
            httpResponse.Content = new StreamContent(GenerateStreamFromString(responseString));
            if (!String.IsNullOrEmpty(requestIdHeader))
            {
                httpResponse.Headers.Add("x-ms-request-id", requestIdHeader);
            }
            httpResponse.StatusCode = statusCode;

            var token = new TokenCredentials(Guid.NewGuid().ToString(), "abc123");
            redisenterpriseClient client = new redisenterpriseClient(token, new DummyResponseDelegatingHandler(httpResponse));
            client.SubscriptionId = "e311648e-a318-4a16-836e-f4a91cc73e9b";
            client.LongRunningOperationRetryTimeout = 0;
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
