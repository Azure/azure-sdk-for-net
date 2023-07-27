// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.TestFramework.Tests
{
    public class MockClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly HttpPipeline _pipeline;

        public MockClient() : this(new MockClientOptions())
        {
        }

        public MockClient(MockClientOptions options)
        {
            options ??= new();

            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options);
        }

        public virtual Response GetResource(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(MockClient)}.{nameof(GetResource)}");
            scope.Start();

            try
            {
                Request request = CreateGetResourceRequest(id);
                return _pipeline.SendRequest(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        public virtual async Task<Response> GetResourceAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(MockClient)}.{nameof(GetResource)}");
            scope.Start();

            try
            {
                Request request = CreateGetResourceRequest(id);
                return await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private Request CreateGetResourceRequest(string id)
        {
            Request request = _pipeline.CreateRequest();
            request.Headers.Add(HttpHeader.Common.JsonAccept);
            request.Method = RequestMethod.Get;

            request.Uri.Reset(new("https://mock"));
            request.Uri.AppendPath("/resources/", false);
            request.Uri.AppendPath(id);
            request.Uri.AppendQuery("api-version", "2022-12-07");

            return request;
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class MockClientOptions : ClientOptions
    {
    }
#pragma warning restore SA1402 // File may only contain a single type
}
