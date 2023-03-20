// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault
{
    internal partial class KeyVaultPipeline
    {
        private readonly HttpPipeline _pipeline;
        public ClientDiagnostics Diagnostics { get; }

        public KeyVaultPipeline(Uri vaultUri, string apiVersion, HttpPipeline pipeline, ClientDiagnostics clientDiagnostics)
        {
            VaultUri = vaultUri;
            _pipeline = pipeline;

            Diagnostics = clientDiagnostics;

            ApiVersion = apiVersion;
        }

        public string ApiVersion { get; }

        public Uri VaultUri { get; }

        public Uri CreateFirstPageUri(string path)
        {
            var firstPage = new RequestUriBuilder();
            firstPage.Reset(VaultUri);

            firstPage.AppendPath(path, escape: false);
            firstPage.AppendQuery("api-version", ApiVersion);

            return firstPage.ToUri();
        }

        public Uri CreateFirstPageUri(string path, params ValueTuple<string, string>[] queryParams)
        {
            var firstPage = new RequestUriBuilder();
            firstPage.Reset(VaultUri);

            firstPage.AppendPath(path, escape: false);
            firstPage.AppendQuery("api-version", ApiVersion);

            foreach ((string, string) tuple in queryParams)
            {
                firstPage.AppendQuery(tuple.Item1, tuple.Item2);
            }

            return firstPage.ToUri();
        }

        public HttpMessage CreateMessage(RequestMethod method, Uri uri, bool appendApiVersion)
        {
            // No need to allocate a RequestContext now, but if/when we do accept a RequestContext as a public parameter,
            // consider passing that with a default classifier instead of a separate classifier parameter.
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Common.JsonAccept);
            request.Method = method;
            request.Uri.Reset(uri);

            if (appendApiVersion)
            {
                request.Uri.AppendQuery("api-version", ApiVersion);
            }

            return message;
        }

        public HttpMessage CreateMessage(RequestMethod method, RequestContext context, params string[] path)
        {
            // See comment in CreateMessage overload above for future design consideration.
            HttpMessage message = _pipeline.CreateMessage(context);
            Request request = message.Request;

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Common.JsonAccept);
            request.Method = method;
            request.Uri.Reset(VaultUri);

            foreach (var p in path)
            {
                request.Uri.AppendPath(p, escape: false);
            }

            request.Uri.AppendQuery("api-version", ApiVersion);

            return message;
        }

        public static NullableResponse<T> CreateResponse<T>(HttpMessage message, Func<T> resultFactory)
            where T : IJsonDeserializable
        {
            int status = message.Response.Status;
            if (status == 200 || status == 201 || status == 202)
            {
                T result = resultFactory();
                result.Deserialize(message.Response.ContentStream);
                return Response.FromValue(result, message.Response);
            }

            return new NoValueResponse<T>(message.Response);
        }

        public static Response<T> CreateResponse<T>(Response response, T result)
            where T : IJsonDeserializable
        {
            result.Deserialize(response.ContentStream);
            return Response.FromValue(result, response);
        }

        public DiagnosticScope CreateScope(string name)
        {
            return Diagnostics.CreateScope(name);
        }

        public async Task<Page<T>> GetPageAsync<T>(Uri firstPageUri, string nextLink, Func<T> itemFactory, string operationName, CancellationToken cancellationToken)
                where T : IJsonDeserializable
        {
            using DiagnosticScope scope = Diagnostics.CreateScope(operationName);
            scope.Start();

            try
            {
                // if we don't have a nextLink specified, use firstPageUri
                if (nextLink != null)
                {
                    firstPageUri = new Uri(nextLink);
                }

                using HttpMessage message = CreateMessage(RequestMethod.Get, firstPageUri, false);
                await SendRequestAsync(message, cancellationToken).ConfigureAwait(false);
                Response response = message.Response;

                // read the response
                KeyVaultPage<T> responseAsPage = new KeyVaultPage<T>(itemFactory);
                responseAsPage.Deserialize(response.ContentStream);

                // convert from the Page<T> to PageResponse<T>
                return Page<T>.FromValues(responseAsPage.Items.ToArray(), responseAsPage.NextLink?.AbsoluteUri, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Page<T> GetPage<T>(Uri firstPageUri, string nextLink, Func<T> itemFactory, string operationName, CancellationToken cancellationToken)
            where T : IJsonDeserializable
        {
            using DiagnosticScope scope = Diagnostics.CreateScope(operationName);
            scope.Start();

            try
            {
                // if we don't have a nextLink specified, use firstPageUri
                if (nextLink != null)
                {
                    firstPageUri = new Uri(nextLink);
                }

                using HttpMessage message = CreateMessage(RequestMethod.Get, firstPageUri, false);
                SendRequest(message, cancellationToken);
                Response response = message.Response;

                // read the response
                KeyVaultPage<T> responseAsPage = new KeyVaultPage<T>(itemFactory);
                responseAsPage.Deserialize(response.ContentStream);

                // convert from the Page<T> to PageResponse<T>
                return Page<T>.FromValues(responseAsPage.Items.ToArray(), responseAsPage.NextLink?.AbsoluteUri, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response<TResult>> SendRequestAsync<TContent, TResult>(RequestMethod method, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TContent : IJsonSerializable
            where TResult : IJsonDeserializable
        {
            using HttpMessage message = CreateMessage(method, null, path);
            message.Request.Content = RequestContent.Create(content.Serialize());

            await SendRequestAsync(message, cancellationToken).ConfigureAwait(false);

            return CreateResponse(message.Response, resultFactory());
        }

        public Response<TResult> SendRequest<TContent, TResult>(RequestMethod method, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TContent : IJsonSerializable
            where TResult : IJsonDeserializable
        {
            using HttpMessage message = CreateMessage(method, null, path);
            message.Request.Content = RequestContent.Create(content.Serialize());

            SendRequest(message, cancellationToken);

            return CreateResponse(message.Response, resultFactory());
        }

        public async Task<Response<TResult>> SendRequestAsync<TResult>(RequestMethod method, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TResult : IJsonDeserializable
        {
            using HttpMessage message = CreateMessage(method, null, path);
            await SendRequestAsync(message, cancellationToken).ConfigureAwait(false);

            return CreateResponse(message.Response, resultFactory());
        }

        public async Task<NullableResponse<TResult>> SendRequestAsync<TResult>(RequestMethod method, RequestContext context, Func<TResult> resultFactory, params string[] path)
            where TResult : IJsonDeserializable
        {
            using HttpMessage message = CreateMessage(method, context, path);
            await SendRequestAsync(message, context?.CancellationToken ?? default).ConfigureAwait(false);

            return CreateResponse(message, resultFactory);
        }

        public async Task<Response<TResult>> SendRequestAsync<TResult>(RequestMethod method, Func<TResult> resultFactory, Uri uri, CancellationToken cancellationToken)
            where TResult : IJsonDeserializable
        {
            using HttpMessage message = CreateMessage(method, uri, true);
            await SendRequestAsync(message, cancellationToken).ConfigureAwait(false);

            return CreateResponse(message.Response, resultFactory());
        }

        public Response<TResult> SendRequest<TResult>(RequestMethod method, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TResult : IJsonDeserializable
        {
            using HttpMessage message = CreateMessage(method, null, path);
            SendRequest(message, cancellationToken);

            return CreateResponse(message.Response, resultFactory());
        }

        public NullableResponse<TResult> SendRequest<TResult>(RequestMethod method, RequestContext context, Func<TResult> resultFactory,params string[] path)
            where TResult : IJsonDeserializable
        {
            using HttpMessage message = CreateMessage(method, context, path);
            SendRequest(message, context?.CancellationToken ?? default);

            return CreateResponse(message, resultFactory);
        }

        public Response<TResult> SendRequest<TResult>(RequestMethod method, Func<TResult> resultFactory, Uri uri, CancellationToken cancellationToken)
            where TResult : IJsonDeserializable
        {
            using HttpMessage message = CreateMessage(method, uri, true);
            SendRequest(message, cancellationToken);

            return CreateResponse(message.Response, resultFactory());
        }

        public async Task<Response> SendRequestAsync(RequestMethod method, CancellationToken cancellationToken, params string[] path)
        {
            using HttpMessage message = CreateMessage(method, null, path);
            await SendRequestAsync(message, cancellationToken).ConfigureAwait(false);
            return message.Response;
        }

        public Response SendRequest(RequestMethod method, CancellationToken cancellationToken, params string[] path)
        {
            using HttpMessage message = CreateMessage(method, null, path);
            SendRequest(message, cancellationToken);
            return message.Response;
        }

        public async Task<Response> GetResponseAsync(RequestMethod method, CancellationToken cancellationToken, params string[] path)
        {
            using HttpMessage message = CreateMessage(method, null, path);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            return message.Response;
        }

        public Response GetResponse(RequestMethod method, CancellationToken cancellationToken, params string[] path)
        {
            using HttpMessage message = CreateMessage(method, null, path);
            _pipeline.Send(message, cancellationToken);
            return message.Response;
        }

        private async ValueTask SendRequestAsync(HttpMessage message, CancellationToken cancellationToken)
        {
            message.ResponseClassifier ??= ResponseClassifier200201202204;
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);

            if (message.ResponseClassifier.IsErrorResponse(message))
            {
                throw await Diagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        private void SendRequest(HttpMessage message, CancellationToken cancellationToken)
        {
            message.ResponseClassifier ??= ResponseClassifier200201202204;
            _pipeline.Send(message, cancellationToken);

            if (message.ResponseClassifier.IsErrorResponse(message))
            {
                throw Diagnostics.CreateRequestFailedException(message.Response);
            }
        }

        private static ResponseClassifier s_responseClassifier200201202204;
        private static ResponseClassifier ResponseClassifier200201202204 => s_responseClassifier200201202204 ??= new StatusCodeClassifier(stackalloc ushort[]
        {
            200,
            201,
            202,
            204,
        });
    }
}
