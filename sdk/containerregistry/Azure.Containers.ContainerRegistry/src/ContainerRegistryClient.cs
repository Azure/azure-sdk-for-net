// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// The sample secrets client.
    /// </summary>
    public class ContainerRegistryClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal V2SupportRestClient v2SupportRestClient { get; }
        internal ManifestsRestClient manifestsRestClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/>.
        /// </summary>
        public ContainerRegistryClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/>.
        /// </summary>
        public ContainerRegistryClient(Uri endpoint, TokenCredential credential, ContainerRegistryClientOptions options): this(
            new ClientDiagnostics(options),
            HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net/.default")),
            endpoint.ToString())
        {
        }

        /// <summary> Initializes a new instance of ContainerRegistryClient for mocking. </summary>
        protected ContainerRegistryClient()
        {
        }

        /// <summary> Initializes a new instance of ContainerRegistryClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        internal ContainerRegistryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url)
        {
            v2SupportRestClient = new V2SupportRestClient(_clientDiagnostics, pipeline, url);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        public virtual async Task<Response> CheckV2SupportAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MiniSecretClient.GetSecret");
            scope.Start();
            try
            {
                return await v2SupportRestClient.CheckAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response CheckV2Support(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TODO REPLACE");
            scope.Start();
            try
            {
                return v2SupportRestClient.Check(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response CreateManifest(string name, string reference, Manifest payload, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TODO REPLACE");
            scope.Start();
            try
            {
                return manifestsRestClient.Create(name, reference, payload, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<ManifestWrapper> GetManifest(string name, string reference, Manifest payload, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TODO REPLACE");
            scope.Start();
            try
            {
                return manifestsRestClient.Get(name, reference, "application/vnd.docker.distribution.manifest.v2+json", cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
