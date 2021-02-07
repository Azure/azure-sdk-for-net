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
    /// <summary> The ContainerRegistryRepository service client. </summary>
    public partial class ContainerRegistryRepositoryClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ContainerRegistryRepositoryRestClient RestClient { get; }

        public ContainerRegistryRepositoryClient(Uri endpoint, string repositoryName, TokenCredential credential) : this(endpoint, repositoryName, credential, new ContainerRegistryClientOptions())
        {
        }

        public ContainerRegistryRepositoryClient(Uri endpoint, string repositoryName, TokenCredential credential, ContainerRegistryClientOptions options)
        {
        }

        /// <summary> Initializes a new instance of ContainerRegistryRepositoryClient for mocking. </summary>
        protected ContainerRegistryRepositoryClient()
        {
        }
        /// <summary> Initializes a new instance of ContainerRegistryRepositoryClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="url"> Registry login URL. </param>
        internal ContainerRegistryRepositoryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url)
        {
            RestClient = new ContainerRegistryRepositoryRestClient(clientDiagnostics, pipeline, url);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get the manifest identified by `name` and `reference` where `reference` can be a tag or digest. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> A tag or a digest, pointing to a specific image. </param>
        /// <param name="accept"> Accept header string delimited by comma. For example, application/vnd.docker.distribution.manifest.v2+json. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ManifestWrapper>> GetManifestAsync(string name, string reference, string accept = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifest");
            scope.Start();
            try
            {
                return await RestClient.GetManifestAsync(name, reference, accept, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the manifest identified by `name` and `reference` where `reference` can be a tag or digest. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> A tag or a digest, pointing to a specific image. </param>
        /// <param name="accept"> Accept header string delimited by comma. For example, application/vnd.docker.distribution.manifest.v2+json. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManifestWrapper> GetManifest(string name, string reference, string accept = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifest");
            scope.Start();
            try
            {
                return RestClient.GetManifest(name, reference, accept, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put the manifest identified by `name` and `reference` where `reference` can be a tag or digest. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> A tag or a digest, pointing to a specific image. </param>
        /// <param name="payload"> Manifest body, can take v1 or v2 values depending on accept header. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<object>> CreateManifestAsync(string name, string reference, Manifest payload, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.CreateManifest");
            scope.Start();
            try
            {
                return await RestClient.CreateManifestAsync(name, reference, payload, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put the manifest identified by `name` and `reference` where `reference` can be a tag or digest. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> A tag or a digest, pointing to a specific image. </param>
        /// <param name="payload"> Manifest body, can take v1 or v2 values depending on accept header. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<object> CreateManifest(string name, string reference, Manifest payload, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.CreateManifest");
            scope.Start();
            try
            {
                return RestClient.CreateManifest(name, reference, payload, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the manifest identified by `name` and `reference`. Note that a manifest can _only_ be deleted by `digest`. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> A tag or a digest, pointing to a specific image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteManifestAsync(string name, string reference, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.DeleteManifest");
            scope.Start();
            try
            {
                return await RestClient.DeleteManifestAsync(name, reference, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the manifest identified by `name` and `reference`. Note that a manifest can _only_ be deleted by `digest`. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> A tag or a digest, pointing to a specific image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeleteManifest(string name, string reference, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.DeleteManifest");
            scope.Start();
            try
            {
                return RestClient.DeleteManifest(name, reference, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List tags of a repository. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="last"> Query parameter for the last item in previous query. Result set will include values lexically after last. </param>
        /// <param name="n"> query parameter for max number of items. </param>
        /// <param name="orderby"> orderby query parameter. </param>
        /// <param name="digest"> filter by digest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TagList>> GetTagsAsync(string name, string last = null, int? n = null, string orderby = null, string digest = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetTags");
            scope.Start();
            try
            {
                return await RestClient.GetTagsAsync(name, last, n, orderby, digest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List tags of a repository. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="last"> Query parameter for the last item in previous query. Result set will include values lexically after last. </param>
        /// <param name="n"> query parameter for max number of items. </param>
        /// <param name="orderby"> orderby query parameter. </param>
        /// <param name="digest"> filter by digest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TagList> GetTags(string name, string last = null, int? n = null, string orderby = null, string digest = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetTags");
            scope.Start();
            try
            {
                return RestClient.GetTags(name, last, n, orderby, digest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get tag attributes by tag. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TagAttributes>> GetTagAttributesAsync(string name, string reference, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetTagAttributes");
            scope.Start();
            try
            {
                return await RestClient.GetTagAttributesAsync(name, reference, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get tag attributes by tag. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TagAttributes> GetTagAttributes(string name, string reference, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetTagAttributes");
            scope.Start();
            try
            {
                return RestClient.GetTagAttributes(name, reference, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update tag attributes. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> Tag name. </param>
        /// <param name="value"> Repository attribute value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> UpdateTagAttributesAsync(string name, string reference, ContentPermissions value = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.UpdateTagAttributes");
            scope.Start();
            try
            {
                return await RestClient.UpdateTagAttributesAsync(name, reference, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update tag attributes. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> Tag name. </param>
        /// <param name="value"> Repository attribute value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response UpdateTagAttributes(string name, string reference, ContentPermissions value = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.UpdateTagAttributes");
            scope.Start();
            try
            {
                return RestClient.UpdateTagAttributes(name, reference, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete tag. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteTagAsync(string name, string reference, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.DeleteTag");
            scope.Start();
            try
            {
                return await RestClient.DeleteTagAsync(name, reference, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete tag. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeleteTag(string name, string reference, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.DeleteTag");
            scope.Start();
            try
            {
                return RestClient.DeleteTag(name, reference, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List manifests of a repository. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="last"> Query parameter for the last item in previous query. Result set will include values lexically after last. </param>
        /// <param name="n"> query parameter for max number of items. </param>
        /// <param name="orderby"> orderby query parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AcrManifests>> GetManifestsAsync(string name, string last = null, int? n = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifests");
            scope.Start();
            try
            {
                return await RestClient.GetManifestsAsync(name, last, n, orderby, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List manifests of a repository. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="last"> Query parameter for the last item in previous query. Result set will include values lexically after last. </param>
        /// <param name="n"> query parameter for max number of items. </param>
        /// <param name="orderby"> orderby query parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AcrManifests> GetManifests(string name, string last = null, int? n = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifests");
            scope.Start();
            try
            {
                return RestClient.GetManifests(name, last, n, orderby, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get manifest attributes. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> A tag or a digest, pointing to a specific image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ManifestAttributes>> GetManifestAttributesAsync(string name, string reference, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifestAttributes");
            scope.Start();
            try
            {
                return await RestClient.GetManifestAttributesAsync(name, reference, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get manifest attributes. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> A tag or a digest, pointing to a specific image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManifestAttributes> GetManifestAttributes(string name, string reference, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifestAttributes");
            scope.Start();
            try
            {
                return RestClient.GetManifestAttributes(name, reference, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update attributes of a manifest. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> A tag or a digest, pointing to a specific image. </param>
        /// <param name="value"> Repository attribute value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> UpdateManifestAttributesAsync(string name, string reference, ContentPermissions value = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.UpdateManifestAttributes");
            scope.Start();
            try
            {
                return await RestClient.UpdateManifestAttributesAsync(name, reference, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update attributes of a manifest. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="reference"> A tag or a digest, pointing to a specific image. </param>
        /// <param name="value"> Repository attribute value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response UpdateManifestAttributes(string name, string reference, ContentPermissions value = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.UpdateManifestAttributes");
            scope.Start();
            try
            {
                return RestClient.UpdateManifestAttributes(name, reference, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
