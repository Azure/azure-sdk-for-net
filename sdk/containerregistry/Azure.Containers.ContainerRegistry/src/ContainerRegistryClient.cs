// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.ContainerRegistry.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> The ContainerRegistry service client. </summary>
    public partial class ContainerRegistryClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ContainerRegistryRestClient RestClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/>.
        /// </summary>
        public ContainerRegistryClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/>.
        /// </summary>
        public ContainerRegistryClient(Uri endpoint, TokenCredential credential, ContainerRegistryClientOptions options)
        {
        }

        /// <summary> Initializes a new instance of ContainerRegistryClient for mocking. </summary>
        protected ContainerRegistryClient()
        {
        }

        /// <summary> Initializes a new instance of ContainerRegistryClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="url"> Registry login URL. </param>
        internal ContainerRegistryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url)
        {
            RestClient = new ContainerRegistryRestClient(clientDiagnostics, pipeline, url);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Tells whether this Docker Registry instance supports Docker Registry HTTP API v2. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CheckDockerV2SupportAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryClient.CheckDockerV2Support");
            scope.Start();
            try
            {
                return await RestClient.CheckDockerV2SupportAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tells whether this Docker Registry instance supports Docker Registry HTTP API v2. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CheckDockerV2Support(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryClient.CheckDockerV2Support");
            scope.Start();
            try
            {
                return RestClient.CheckDockerV2Support(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Pageable<string> GetRepositoryNames(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual AsyncPageable<string> GetRepositoryNamesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary> Get repository attributes. </summary>
        /// <param name="respositoryName"> Name of the image (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RepositoryAttributes>> GetRepositoryAttributesAsync(string respositoryName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryClient.GetRepositoryAttributes");
            scope.Start();
            try
            {
                return await RestClient.GetRepositoryAttributesAsync(respositoryName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get repository attributes. </summary>
        /// <param name="respositoryName"> Name of the image (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RepositoryAttributes> GetRepositoryAttributes(string respositoryName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryClient.GetRepositoryAttributes");
            scope.Start();
            try
            {
                return RestClient.GetRepositoryAttributes(respositoryName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the repository identified by `name`. </summary>
        /// <param name="respositoryName"> Name of the image (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeleteRepositoryResult>> DeleteRepositoryAsync(string respositoryName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryClient.DeleteRepository");
            scope.Start();
            try
            {
                return await RestClient.DeleteRepositoryAsync(respositoryName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the repository identified by `name`. </summary>
        /// <param name="respositoryName"> Name of the image (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeleteRepositoryResult> DeleteRepository(string respositoryName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryClient.DeleteRepository");
            scope.Start();
            try
            {
                return RestClient.DeleteRepository(respositoryName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update the attribute identified by `name` where `reference` is the name of the repository. </summary>
        /// <param name="repositoryName"> Name of the image (including the namespace). </param>
        /// <param name="value"> Repository attribute value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SetRepositoryPermissionsAsync(string repositoryName, ContentPermissions value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryClient.UpdateRepositoryAttributes");
            scope.Start();
            try
            {
                return await RestClient.UpdateRepositoryAttributesAsync(repositoryName, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update the attribute identified by `name` where `reference` is the name of the repository. </summary>
        /// <param name="repositoryName"> Name of the image (including the namespace). </param>
        /// <param name="value"> Repository attribute value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SetRepositoryPermissions(string repositoryName, ContentPermissions value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryClient.UpdateRepositoryAttributes");
            scope.Start();
            try
            {
                return RestClient.UpdateRepositoryAttributes(repositoryName, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual ContainerRegistryRepositoryClient GetRepositoryClient(string repositoryName)
        {
            throw new NotImplementedException();
        }
    }
}
