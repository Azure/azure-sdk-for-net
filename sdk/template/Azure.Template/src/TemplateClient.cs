// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Template;
using Azure.Template.Models;

namespace Azure.Template
{
    /// <summary>
    /// The sample client.
    /// </summary>
    public class TemplateClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly AllOperations _operations;

        /// <summary>
        /// Mocking ctor only.
        /// </summary>
        protected TemplateClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateClient"/>.
        /// </summary>
        public TemplateClient(Uri endpoint) : this(endpoint, new TemplateClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateClient"/>.
        /// </summary>
        public TemplateClient(Uri endpoint, TemplateClientOptions options)
        {
            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options /* Add an auth policy here*/);
            _operations = new AllOperations(_diagnostics, _pipeline, endpoint.ToString());
        }

        /// <summary>
        /// Executes a service call that takes and returns the <see cref="Model"/>.
        /// </summary>
        public virtual Response<Model> Transform(Model input, CancellationToken cancellationToken = default)
        {
            return _operations.Operation(input, cancellationToken);
        }

        /// <summary>
        /// Executes a service call that takes and returns the <see cref="Model"/>.
        /// </summary>
        public virtual async Task<Response<Model>> TransformAsync(Model input, CancellationToken cancellationToken = default)
        {
            return await _operations.OperationAsync(input, cancellationToken).ConfigureAwait(false);
        }
    }
}