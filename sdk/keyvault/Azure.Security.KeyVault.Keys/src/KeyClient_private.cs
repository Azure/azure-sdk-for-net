﻿using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    public partial class KeyClient
    {
        private const string KeysPath = "/keys/";
        private const string DeletedKeysPath = "/deletedkeys/";

        private async Task<Response<TResult>> SendRequestAsync<TContent, TResult>(HttpPipelineMethod method, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TContent : Model
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                request.Content = HttpPipelineRequestContent.Create(content.Serialize());

                Response response = await SendRequestAsync(request, cancellationToken);

                return this.CreateResponse(response, resultFactory());
            }
        }

        private async Task<Response<TResult>> SendRequestAsync<TResult>(HttpPipelineMethod method, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                Response response = await SendRequestAsync(request, cancellationToken);

                return this.CreateResponse(response, resultFactory());
            }
        }

        private async Task<Response> SendRequestAsync(HttpPipelineMethod method, CancellationToken cancellationToken, params string[] path)
        {
            using (Request request = CreateRequest(HttpPipelineMethod.Get, path))
            {
                return await SendRequestAsync(request, cancellationToken);
            }
        }

        private async Task<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

            switch (response.Status)
            {
                case 200:
                case 201:
                    return response;
                default:
                    throw await response.CreateRequestFailedExceptionAsync();
            }
        }

        private Request CreateRequest(HttpPipelineMethod method, params string[] path)
        {
            // duplicating the code from the overload which takes a URI here because there is currently a bug in 
            // request.UriBuilder when you call AppendQuery before AppendPath
            Request request = _pipeline.CreateRequest();

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Names.Accept, "application/json");
            request.Method = method;
            request.UriBuilder.Uri = _vaultUri;

            foreach (var p in path)
            {
                if (!string.IsNullOrEmpty(p))
                {
                    var pp = !p.StartsWith("/") ? "/" + p : p;

                    request.UriBuilder.AppendPath(pp);
                }
            }

            request.UriBuilder.AppendQuery("api-version", ApiVersion);

            return request;
        }

        private Response<T> CreateResponse<T>(Response response, T result)
            where T : Model
        {
            result.Deserialize(response.ContentStream);

            return new Response<T>(response, result);
        }
    }
}
