//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Foundation;

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// A channel for processing HTTP requests.
    /// </summary>
    public sealed class HttpChannel
    {
        private System.Net.Http.HttpClient _client;         // HTTP client.
        private List<IHttpHandler> _handlers;               // HTTP handlers.

        /// <summary>
        /// Initializes the channel with the given handlers.
        /// </summary>
        /// <param name="handlers">Handlers to put to the channel.</param>
        public HttpChannel(params IHttpHandler[] handlers)
        {
            Validator.ArgumentIsNotNull("handlers", handlers);

            _client = new System.Net.Http.HttpClient();
            _handlers = new List<IHttpHandler>(handlers);
        }

        /// <summary>
        /// Creates a new channel by taking handlers from the given channel
        /// and adding extra handlers at the head of the queue.
        /// </summary>
        /// <param name="originalChannel">Original HTTP processing channel.</param>
        /// <param name="handlers">Handlers to add to new channel's queue.</param>
        public HttpChannel(HttpChannel originalChannel, params IHttpHandler[] handlers)
        {
            Validator.ArgumentIsNotNull("originalChannel", originalChannel);
            Validator.ArgumentIsNotNull("handlers", handlers);

            _client = originalChannel._client;
            _handlers = new List<IHttpHandler>(handlers);
            _handlers.AddRange(originalChannel._handlers);
        }

        /// <summary>
        /// Creates a default HTTP channel.
        /// </summary>
        /// <remarks>The default channel includes only WRAP authentication
        /// handler, which uses private HTTP channel for processing its own 
        /// requests.</remarks>
        /// <param name="serviceNamespace">Service namespace.</param>
        /// <param name="issuerName">Issuer name.</param>
        /// <param name="issuerPassword">Issuer password.</param>
        public static HttpChannel CreateDefault(string serviceNamespace, string issuerName, string issuerPassword)
        {
            Validator.ArgumentIsValidPath("serviceNamespace", serviceNamespace);
            Validator.ArgumentIsNotNull("issuerName", issuerName);
            Validator.ArgumentIsNotNull("issuerPassword", issuerPassword);

            WrapAuthenticationHandler wrapHandler = new WrapAuthenticationHandler(
                new HttpChannel(), serviceNamespace, issuerName, issuerPassword);
            return new HttpChannel(wrapHandler);
        }
        
        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">HTTP request to send.</param>
        /// <returns>Response to the given request.</returns>
        public IAsyncOperation<HttpResponse> SendAsync(HttpRequest request)
        {
            Validator.ArgumentIsNotNull("request", request);

            return Task.Factory
                .StartNew(() => ProcessRequest(request))
                .ContinueWith(t => SendRequest(request), TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(t => ProcessResponse(t.Result), TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation();
        }

        /// <summary>
        /// Sends the requests and passes the response through extra handlers.
        /// </summary>
        /// <param name="request">Request to send.</param>
        /// <param name="handlers">Extra response handlers.</param>
        /// <returns></returns>
        internal Task<HttpResponse> SendAsyncInternal(HttpRequest request, params Func<HttpResponse, HttpResponse>[] handlers)
        {
            return SendAsync(request).AsTask()
                .ContinueWith(t => ProcessResponse(t.Result, handlers), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Passes the request through all registered handlers.
        /// </summary>
        /// <param name="request">Request to process.</param>
        /// <returns>Processed request.</returns>
        private HttpRequest ProcessRequest(HttpRequest request)
        {
            for (int i = 0; i < _handlers.Count; i++)
            {
                request = _handlers[i].ProcessRequest(request);
            }

            return request;
        }

        /// <summary>
        /// Sends the HTTP request.
        /// </summary>
        /// <param name="request">Request to send.</param>
        /// <returns>Response to the given request.</returns>
        private HttpResponse SendRequest(HttpRequest request)
        {
            return _client
                .SendAsync(request.CreateNetRequest())
                .ContinueWith(t => new HttpResponse(request, t.Result), TaskContinuationOptions.OnlyOnRanToCompletion)
                .Result;
        }

        /// <summary>
        /// Passes the response through all registered handlers.
        /// </summary>
        /// <param name="response">Response to process.</param>
        /// <returns>Processed response.</returns>
        private HttpResponse ProcessResponse(HttpResponse response)
        {
            for (int i = _handlers.Count - 1; i >= 0; i--)
            {
                response = _handlers[i].ProcessResponse(response);
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new WindowsAzureHttpException(Resources.ErrorFailedRequest, response);
            }

            return response;
        }

        /// <summary>
        /// Passes the response through all specified handlers.
        /// </summary>
        /// <param name="response">Response to process.</param>
        /// <param name="handlers">Response handlers.</param>
        /// <returns>Processed response.</returns>
        private HttpResponse ProcessResponse(HttpResponse response, Func<HttpResponse, HttpResponse>[] handlers)
        {
            for (int i = 0; i < handlers.Length; i++)
            {
                response = handlers[i](response);
            }

            return response;
        }

        /// <summary>
        /// Throws exceptions for response with no content.
        /// </summary>
        /// <param name="response">Source response.</param>
        /// <returns>Processed HTTP response.</returns>
        internal static HttpResponse CheckNoContent(HttpResponse response)
        {
            if (response.StatusCode == (int)System.Net.HttpStatusCode.NoContent || response.StatusCode == (int)System.Net.HttpStatusCode.ResetContent)
            {
                throw new WindowsAzureHttpException(Resources.ErrorNoContent, response);
            }
            return response;
        }
    }
}
