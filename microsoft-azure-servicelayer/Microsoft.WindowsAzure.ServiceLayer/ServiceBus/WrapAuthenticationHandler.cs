/*
 * Copyright 2012 Microsoft Corporation
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *    http://www.apache.org/licenses/LICENSE-2.0
 * 
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// HTTP handler for WRAP authentication of outgoing requests.
    /// </summary>
    class WrapAuthenticationHandler: HttpClientHandler
    {
        ServiceConfiguration ServiceConfig { get; set; }         // Configuration parameters
        HttpClient Channel { get; set; }                            // HTTP channel for processing requests
        Dictionary<string, WrapToken> Tokens { get; set; }          // Cached tokens
        Object SyncObject { get; set; }                             // Synchronization object for accessing cached tokens

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="serviceConfig">Configuration</param>
        internal WrapAuthenticationHandler(ServiceConfiguration serviceConfig)
        {
            ServiceConfig = serviceConfig;
            Tokens = new Dictionary<string, WrapToken>(StringComparer.OrdinalIgnoreCase);
            SyncObject = new object();

            HttpMessageHandler handlers = new HttpErrorHandler(
                new HttpClientHandler());
            Channel = new HttpClient(handlers);
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">HTTP request to send</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>HTTP response</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew<WrapToken>(() => { return GetToken(request.RequestUri.AbsolutePath); })
                .ContinueWith<HttpRequestMessage>((tr) => { return tr.Result.Authorize(request); }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith<HttpResponseMessage>((tr) => { return base.SendAsync(tr.Result, cancellationToken).Result; }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets authentication token for a resource with the given path.
        /// </summary>
        /// <param name="resourcePath">Resource path</param>
        /// <returns>Authentication token</returns>
        WrapToken GetToken(string resourcePath)
        {
            WrapToken token;

            lock (SyncObject)
            {
                Tokens.TryGetValue(resourcePath, out token);
                if (token != null && token.IsExpired)
                    Tokens.Remove(resourcePath);
            }

            if (token == null)
            {
                // Issue new authentication request.
                Uri scopeUri = new Uri(ServiceConfig.ScopeHostUri, resourcePath);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ServiceConfig.AuthenticationUri);
                Dictionary<string, string> settings = new Dictionary<string, string>()
                {
                    {"wrap_name",       ServiceConfig.UserName},
                    {"wrap_password",   ServiceConfig.Password},
                    {"wrap_scope",      scopeUri.ToString()},
                };

                request.Headers.Accept.ParseAdd("application/x-www-form-urlencoded");       //TODO: is there a constant for this type?
                request.Content = new FormUrlEncodedContent(settings);

                HttpResponseMessage response = Channel.SendAsync(request).Result;
                Debug.Assert(response.IsSuccessStatusCode);         // Errors should've been handled by the error handler
                token = new WrapToken(resourcePath, response);

                lock (SyncObject)
                {
                    WrapToken existingToken;

                    if (Tokens.TryGetValue(resourcePath, out existingToken) && !existingToken.IsExpired)
                    {
                        // Ignore new results; use existing token
                        token = existingToken;
                    }
                    else
                    {
                        // Cache the token
                        Tokens[resourcePath] = token;
                    }
                }
            }

            return token;
        }
    }
}
