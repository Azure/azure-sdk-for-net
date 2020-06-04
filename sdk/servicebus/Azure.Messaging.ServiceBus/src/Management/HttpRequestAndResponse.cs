// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Core;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Primitives;
using Azure.Core.Pipeline;
using System.Collections.Generic;
using System.Globalization;

namespace Azure.Messaging.ServiceBus.Management
{
    internal class HttpRequestAndResponse
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _fullyQualifiedNamespace;
        private readonly TokenCredential _tokenCredential;
        private readonly int _port;

        /// <summary>
        /// Initializes a new <see cref="HttpRequestAndResponse"/> which can be used to send http request and response.
        /// </summary>
        public HttpRequestAndResponse(
            HttpPipeline pipeline,
            TokenCredential tokenCredential,
            string fullyQualifiedNamespace
            )
        {
            _pipeline = pipeline;
            _tokenCredential = tokenCredential;
            _fullyQualifiedNamespace = fullyQualifiedNamespace;
            _port = GetPort(_fullyQualifiedNamespace);
        }
        private static async Task<Exception> ValidateHttpResponse(Response response, Request request)
        {
            if ((response.Status >= 200) && (response.Status < 400))
            {
                return null;
            }

            string exceptionMessage = string.Empty;
            if (response.ContentStream != null)
            {
                exceptionMessage = await ReadAsString(response).ConfigureAwait(false);
            }
            exceptionMessage = ParseDetailIfAvailable(exceptionMessage) ?? response.ReasonPhrase;

            if (response.Status == (int)HttpStatusCode.Unauthorized)
            {
                return new ServiceBusException(exceptionMessage, ServiceBusException.FailureReason.Unauthorized);
            }

            if (response.Status == (int)HttpStatusCode.NotFound || response.Status == (int)HttpStatusCode.NoContent)
            {
                return new ServiceBusException(exceptionMessage, ServiceBusException.FailureReason.MessagingEntityNotFound);
            }

            if (response.Status == (int)HttpStatusCode.Conflict)
            {
                if (request.Method.Equals(RequestMethod.Delete))
                {
                    return new ServiceBusException(true, exceptionMessage);
                }

                if (request.Method.Equals(RequestMethod.Put) && request.Headers.TryGetValue("If-Match", out _))
                {
                    // response.RequestMessage.Headers.IfMatch.Count > 0 is true for UpdateEntity scenario
                    return new ServiceBusException(true, exceptionMessage);
                }

                if (exceptionMessage.Contains(ManagementClientConstants.ConflictOperationInProgressSubCode))
                {
                    return new ServiceBusException(true, exceptionMessage);
                }

                return new ServiceBusException(exceptionMessage, ServiceBusException.FailureReason.MessagingEntityAlreadyExists);
            }

            if (response.Status == (int)HttpStatusCode.Forbidden)
            {
                if (exceptionMessage.Contains(ManagementClientConstants.ForbiddenInvalidOperationSubCode))
                {
                    return new InvalidOperationException(exceptionMessage);
                }

                return new ServiceBusException(exceptionMessage, ServiceBusException.FailureReason.QuotaExceeded);
            }

            if (response.Status == (int)HttpStatusCode.BadRequest)
            {
                return new ArgumentException(exceptionMessage);
            }

            if (response.Status == (int)HttpStatusCode.ServiceUnavailable)
            {
                return new ServiceBusException(exceptionMessage, ServiceBusException.FailureReason.ServiceBusy);
            }

            return new ServiceBusException(true, exceptionMessage + "; response status code: " + response.Status);
        }

        private static string ParseDetailIfAvailable(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return null;
            }

            try
            {
                var errorContentXml = XElement.Parse(content);
                XElement detail = errorContentXml.Element("Detail");

                return detail?.Value ?? content;
            }
            catch (Exception)
            {
                return content;
            }
        }

        private Task<string> GetToken(Uri requestUri) =>
            GetTokenAsync(requestUri.GetLeftPart(UriPartial.Path));

        public async Task<string> GetTokenAsync(string requestUri)
        {
            var scope = requestUri;
            var credential = (ServiceBusTokenCredential)_tokenCredential;
            if (!credential.IsSharedAccessSignatureCredential)
            {
                scope = Constants.DefaultScope;
            }
            AccessToken token = await _tokenCredential.GetTokenAsync(new TokenRequestContext(new[] { scope }), CancellationToken.None).ConfigureAwait(false);
            return token.Token;
        }

        public async Task<Page<T>> GetEntitiesPageAsync<T>(
            string path,
            string nextSkip,
            Func<string, IReadOnlyList<T>> parseFunction,
            CancellationToken cancellationToken)
        {
            int skip = 0;
            int maxCount = 100;
            if (nextSkip != null)
            {
                skip = int.Parse(nextSkip, CultureInfo.InvariantCulture);
            }
            Response response = await GetEntityAsync(path, $"$skip={skip}&$top={maxCount}", false, cancellationToken).ConfigureAwait(false);
            string result = await ReadAsString(response).ConfigureAwait(false);

            IReadOnlyList<T> description = parseFunction.Invoke(result);
            skip += maxCount;
            nextSkip = skip.ToString(CultureInfo.InvariantCulture);

            if (description.Count < maxCount || description.Count == 0)
            {
                nextSkip = null;
            }
            return Page<T>.FromValues(description, nextSkip, response);
        }

        public async Task<Response> GetEntityAsync(
            string entityPath,
            string query,
            bool enrich,
            CancellationToken cancellationToken)
        {
            var queryString = $"{ManagementClientConstants.apiVersionQuery}&enrich={enrich}";
            if (query != null)
            {
                queryString = queryString + "&" + query;
            }
            Uri uri = new UriBuilder(_fullyQualifiedNamespace)
            {
                Path = entityPath,
                Scheme = Uri.UriSchemeHttps,
                Port = _port,
                Query = queryString
            }.Uri;

            RequestUriBuilder requestUriBuilder = new RequestUriBuilder();
            requestUriBuilder.Reset(uri);

            Request request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri = requestUriBuilder;
            Response response = await SendHttpRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return response;
        }

        public async Task<Response> PutEntityAsync(
            string entityPath,
            string requestBody,
            bool isUpdate,
            string forwardTo,
            string fwdDeadLetterTo,
            CancellationToken cancellationToken)
        {
            Uri uri = new UriBuilder(_fullyQualifiedNamespace)
            {
                Path = entityPath,
                Port = _port,
                Scheme = Uri.UriSchemeHttps,
                Query = $"{ManagementClientConstants.apiVersionQuery}"
            }.Uri;
            var requestUriBuilder = new RequestUriBuilder();
            requestUriBuilder.Reset(uri);

            Request request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Put;
            request.Uri = requestUriBuilder;
            request.Content = RequestContent.Create(Encoding.UTF8.GetBytes(requestBody));
            request.Headers.Add("Content-Type", ManagementClientConstants.AtomContentType);

            if (isUpdate)
            {
                request.Headers.Add("If-Match", "*");
            }

            var credential = (ServiceBusTokenCredential)_tokenCredential;
            if (!string.IsNullOrWhiteSpace(forwardTo))
            {
                var token = await GetTokenAsync(forwardTo).ConfigureAwait(false);
                request.Headers.Add(
                    ManagementClientConstants.ServiceBusSupplementartyAuthorizationHeaderName,
                    credential.IsSharedAccessSignatureCredential == true ? token : $"Bearer { token }");
            }

            if (!string.IsNullOrWhiteSpace(fwdDeadLetterTo))
            {
                var token = await GetTokenAsync(fwdDeadLetterTo).ConfigureAwait(false);
                request.Headers.Add(
                    ManagementClientConstants.ServiceBusDlqSupplementaryAuthorizationHeaderName,
                    credential.IsSharedAccessSignatureCredential == true ? token : $"Bearer { token }");
            }

            Response response = await SendHttpRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return response;
        }

        public async Task<Response> DeleteEntityAsync(
            string entityPath,
            CancellationToken cancellationToken)
        {
            Uri uri = new UriBuilder(_fullyQualifiedNamespace)
            {
                Path = entityPath,
                Scheme = Uri.UriSchemeHttps,
                Port = _port,
                Query = ManagementClientConstants.apiVersionQuery
            }.Uri;
            var requestUriBuilder = new RequestUriBuilder();
            requestUriBuilder.Reset(uri);

            Request request = _pipeline.CreateRequest();
            request.Uri = requestUriBuilder;
            request.Method = RequestMethod.Delete;

            Response response = await SendHttpRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return response;
        }

        private async Task<Response> SendHttpRequestAsync(
            Request request,
            CancellationToken cancellationToken)
        {
            var credential = (ServiceBusTokenCredential)_tokenCredential;
            if (credential.IsSharedAccessSignatureCredential)
            {
                var token = await GetToken(request.Uri.ToUri()).ConfigureAwait(false);
                request.Headers.Add("Authorization", token);
            }
            request.Headers.Add("UserAgent", $"SERVICEBUS/{ManagementClientConstants.ApiVersion}(api-origin={ClientInfo.Framework};os={ClientInfo.Platform};version={ClientInfo.Version};product={ClientInfo.Product})");

            Response response;
            try
            {
                response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                throw new ServiceBusException(true, exception.Message);
            }

            Exception exceptionReturned = await ValidateHttpResponse(response, request).ConfigureAwait(false);
            if (exceptionReturned == null)
            {
                return response;
            }
            else
            {
                throw exceptionReturned;
            }
        }

        private static async Task<string> ReadAsString(Response response)
        {
            string exceptionMessage;
            using StreamReader reader = new StreamReader(response.ContentStream);
            exceptionMessage = await reader.ReadToEndAsync().ConfigureAwait(false);
            return exceptionMessage;
        }

        private static int GetPort(string endpoint)
        {
            // used for internal testing
            if (endpoint.EndsWith("onebox.windows-int.net", StringComparison.InvariantCultureIgnoreCase))
            {
                return 4446;
            }

            return -1;
        }
    }
}
