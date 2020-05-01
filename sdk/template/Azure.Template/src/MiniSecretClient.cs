// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Template
{
    /// <summary>
    /// The sample secrets client.
    /// </summary>
    [CodeGenClient("ServiceClient")]
    public partial class MiniSecretClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MiniSecretClient"/>.
        /// </summary>
        public MiniSecretClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new MiniSecretClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiniSecretClient"/>.
        /// </summary>
        public MiniSecretClient(Uri endpoint, TokenCredential credential, MiniSecretClientOptions options): this(
            new ClientDiagnostics(options),
            HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net/.default")),
            endpoint.ToString(),
            options.Version)
        {
        }
    }
}