// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Template;
using Azure.Template.Mocdels;
using Azure.Template.Models;

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The sample client.
    /// </summary>
    public class CustomFormClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly AllOperations _operations;

        /// <summary>
        /// Mocking ctor only.
        /// </summary>
        protected CustomFormClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public CustomFormClient(Uri endpoint, FormRecognizerApiKeyCredential credential) : this(endpoint, credential, new FormRecognizerClientOptions())
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public CustomFormClient(Uri endpoint, FormRecognizerApiKeyCredential credential, FormRecognizerClientOptions options)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new ApiKeyAuthenticationPolicy(credential));
            _operations = new AllOperations(_diagnostics, _pipeline, endpoint.ToString());
        }

        /// <summary>
        /// Executes a service call that takes and returns the <see cref="CustomModelCollection"/>.
        /// </summary>
        public virtual Response<CustomModelCollection> GetCustomModelSummary(CancellationToken cancellationToken = default)
        {
            return _operations.GetCustomModels(SomeEnum.Summary, cancellationToken);
        }

        /// <summary>
        /// Executes a service call that takes and returns the <see cref="CustomModelCollection"/>.
        /// </summary>
        public virtual async Task<Response<CustomModelCollection>> GetCustomModelSummaryAsync(CancellationToken cancellationToken = default)
        {
            return await _operations.GetCustomModelsAsync(SomeEnum.Summary, cancellationToken).ConfigureAwait(false);
        }
    }
}
