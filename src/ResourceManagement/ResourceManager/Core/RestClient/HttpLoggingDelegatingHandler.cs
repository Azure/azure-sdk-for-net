// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public class HttpLoggingDelegatingHandler : DelegatingHandlerBase
    {
        public enum Level
        {
            None,
            Basic,
            Headers,
            Body,
            BodyAndHeaders
        };

        public Level LogLevel { get; set; }

        public HttpLoggingDelegatingHandler() 
            : base() { }

        public HttpLoggingDelegatingHandler(HttpMessageHandler innerHandler) 
            : base(innerHandler)
        { }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (LogLevel == Level.None)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            ServiceClientTracing.Information("Request: {0} {1}", request.Method, request.RequestUri);
            if (LogLevel == Level.BodyAndHeaders || LogLevel == Level.Headers)
            {
                ServiceClientTracing.Information("  headers:");
                foreach (var header in request.Headers)
                {
                    ServiceClientTracing.Information("    {0} : {1}", header.Key, string.Join(" ", header.Value));
                }
            }

            if (LogLevel == Level.Body || LogLevel == Level.BodyAndHeaders)
            {
                if (request.Content != null)
                {
                    string content = await request.Content.ReadAsStringAsync();
                    ServiceClientTracing.Information("  body: " + content);
                }
                // TODO: Checking for binary request contents and omitting them
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            if (LogLevel == Level.BodyAndHeaders || LogLevel == Level.Headers)
            {
                ServiceClientTracing.Information("Response:");
                ServiceClientTracing.Information("  headers:");
                foreach (var header in response.Headers)
                {
                    ServiceClientTracing.Information("    {0} : {1}", header.Key, string.Join(" ", header.Value));
                }
            }


            if (LogLevel == Level.Body || LogLevel == Level.BodyAndHeaders)
            {
                bool isEncoded = IsHeaderPresent(response.Content.Headers, "Content-Encoding");
                if (!isEncoded && response.Content != null)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    string contentType = GetHeader(response.Content.Headers, "Content-Type");
                    if (contentType != null && contentType.Contains("application/json"))
                    {
                        try
                        {
                            dynamic parsedJson = JsonConvert.DeserializeObject(content);
                            content = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
                        }
                        catch (Exception) { /*ignore and print below as it is*/ }
                    }
                    ServiceClientTracing.Information(content);
                }

                // TODO: Checking for binary response content and omitting them
                if (isEncoded)
                {
                    ServiceClientTracing.Information("    body: <encoded body omitted>");
                }
            }
            return response;
        }
    }
}
