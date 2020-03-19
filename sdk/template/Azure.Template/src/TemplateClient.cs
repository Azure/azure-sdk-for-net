// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Template;
using Azure.Template.Models;

namespace Azure.Template
{
    /// <summary>
    /// The sample client.
    /// </summary>
    [CodeGenClient("")]
    public partial class TemplateClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateClient"/>.
        /// </summary>
        public TemplateClient(Uri endpoint) : this(endpoint, new TemplateClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateClient"/>.
        /// </summary>
        public TemplateClient(Uri endpoint, TemplateClientOptions options): this(
            new ClientDiagnostics(options),
            HttpPipelineBuilder.Build(options /* Add an auth policy here*/),
            endpoint.ToString())
        {
        }
    }
}