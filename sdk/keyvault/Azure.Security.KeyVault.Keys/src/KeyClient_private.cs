using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;

namespace Azure.Security.KeyVault.Keys
{
    public partial class KeyClient
    {
        private const string KeysPath = "/keys/";
        private const string DeletedKeysPath = "/deletedkeys/";
        private readonly string ApiVersion;

        private async Task<Response<TResult>> SendRequestAsync<TContent, TResult>(RequestMethod method, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TContent : Model
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                request.Content = HttpPipelineRequestContent.Create(content.Serialize());

                Response response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                return this.CreateResponse(response, resultFactory());
            }
        }

        private async Task<Response<TResult>> SendRequestAsync<TResult>(RequestMethod method, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                Response response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                return this.CreateResponse(response, resultFactory());
            }
        }

        private async Task<Response> SendRequestAsync(RequestMethod method, CancellationToken cancellationToken, params string[] path)
        {
            using (Request request = CreateRequest(method, path))
            {
                return await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

            switch (response.Status)
            {
                case 200:
                case 201:
                case 204:
                    return response;
                default:
                    throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
            }
        }

        private Response<TResult> SendRequest<TContent, TResult>(RequestMethod method, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TContent : Model
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                request.Content = HttpPipelineRequestContent.Create(content.Serialize());

                Response response = SendRequest(request, cancellationToken);

                return CreateResponse(response, resultFactory());
            }
        }

        private Response<TResult> SendRequest<TResult>(RequestMethod method, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                Response response = SendRequest(request, cancellationToken);

                return CreateResponse(response, resultFactory());
            }
        }

        private Response SendRequest(RequestMethod method, CancellationToken cancellationToken, params string[] path)
        {
            using (Request request = CreateRequest(method, path))
            {
                return SendRequest(request, cancellationToken);
            }
        }

        private Response SendRequest(Request request, CancellationToken cancellationToken)
        {
            var response = _pipeline.SendRequest(request, cancellationToken);

            switch (response.Status)
            {
                case 200:
                case 201:
                case 204:
                    return response;
                default:
                    throw response.CreateRequestFailedException();
            }
        }

        private Request CreateRequest(RequestMethod method, params string[] path)
        {
            Request request = _pipeline.CreateRequest();

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Common.JsonAccept);
            request.Method = method;
            request.UriBuilder.Uri = _vaultUri;

            foreach (var p in path)
            {
                if (!string.IsNullOrEmpty(p))
                {
                    request.UriBuilder.AppendPath(p);
                }
            }

            request.UriBuilder.AppendQuery("api-version", ApiVersion);

            return request;
        }

        private Request CreateRequest(RequestMethod method, Uri uri)
        {
            Request request = _pipeline.CreateRequest();

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Common.JsonAccept);
            request.Method = method;
            request.UriBuilder.Uri = uri;

            return request;
        }

        private Uri CreateFirstPageUri(string path)
        {
            var firstPage = new RequestUriBuilder();
            firstPage.Uri = _vaultUri;
            firstPage.AppendPath(path);
            firstPage.AppendQuery("api-version", ApiVersion);

            return firstPage.Uri;
        }

        private Response<T> CreateResponse<T>(Response response, T result)
            where T : Model
        {
            result.Deserialize(response.ContentStream);

            return new Response<T>(response, result);
        }

        private async Task<Page<T>> GetPageAsync<T>(Uri firstPageUri, string nextLink, Func<T> itemFactory, string operationName, CancellationToken cancellationToken)
                where T : Model
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope(operationName);
            scope.Start();

            try
            {
                // if we don't have a nextLink specified, use firstPageUri
                if (nextLink != null)
                {
                    firstPageUri = new Uri(nextLink);
                }

                using (Request request = CreateRequest(RequestMethod.Get, firstPageUri))
                {
                    Response response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                    // read the respose
                    KeyVaultPage<T> responseAsPage = new KeyVaultPage<T>(itemFactory);
                    responseAsPage.Deserialize(response.ContentStream);

                    // convert from the Page<T> to PageResponse<T>
                    return new Page<T>(responseAsPage.Items.ToArray(), responseAsPage.NextLink?.ToString(), response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Page<T> GetPage<T>(Uri firstPageUri, string nextLink, Func<T> itemFactory, string operationName, CancellationToken cancellationToken)
            where T : Model
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope(operationName);
            scope.Start();

            try
            {
                // if we don't have a nextLink specified, use firstPageUri
                if (nextLink != null)
                {
                    firstPageUri = new Uri(nextLink);
                }

                using (Request request = CreateRequest(RequestMethod.Get, firstPageUri))
                {
                    Response response = SendRequest(request, cancellationToken);

                    // read the respose
                    KeyVaultPage<T> responseAsPage = new KeyVaultPage<T>(itemFactory);
                    responseAsPage.Deserialize(response.ContentStream);

                    // convert from the Page<T> to PageResponse<T>
                    return new Page<T>(responseAsPage.Items.ToArray(), responseAsPage.NextLink?.ToString(), response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
