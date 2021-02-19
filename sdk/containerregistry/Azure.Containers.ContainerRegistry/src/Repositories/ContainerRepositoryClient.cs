// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.ContainerRegistry.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> The ContainerRegistryRepository service client. </summary>
    public partial class ContainerRepositoryClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ContainerRegistryRepositoryRestClient RestClient { get; }

        // Name of the image (including the namespace).
        private string _repositoryName;

        public ContainerRepositoryClient(Uri endpoint, string repositoryName, TokenCredential credential) : this(endpoint, repositoryName, credential, new ContainerRegistryClientOptions())
        {
        }

        public ContainerRepositoryClient(Uri endpoint, string repositoryName, TokenCredential credential, ContainerRegistryClientOptions options)
        {
            _repositoryName = repositoryName;
        }

        public ContainerRepositoryClient(Uri endpoint, string repositoryName, string username, string password) : this(endpoint, repositoryName, username, password, new ContainerRegistryClientOptions())
        {
        }

        public ContainerRepositoryClient(Uri endpoint, string repositoryName, string username, string password, ContainerRegistryClientOptions options)
        {
            _repositoryName = repositoryName;
        }

        /// <summary>
        /// anonymous access
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="repositoryName"></param>
        public ContainerRepositoryClient(Uri endpoint, string repositoryName) : this(endpoint, repositoryName, new ContainerRegistryClientOptions())
        {
        }

        public ContainerRepositoryClient(Uri endpoint, string repositoryName, ContainerRegistryClientOptions options)
        {
            _repositoryName = repositoryName;
        }

        /// <summary> Initializes a new instance of ContainerRegistryRepositoryClient for mocking. </summary>
        protected ContainerRepositoryClient()
        {
        }
        /// <summary> Initializes a new instance of ContainerRegistryRepositoryClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="url"> Registry login URL. </param>
        internal ContainerRepositoryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url)
        {
            RestClient = new ContainerRegistryRepositoryRestClient(clientDiagnostics, pipeline, url);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        // TODO: Confirm in FDG that IEnumerable is how to model this input collection
        /// <summary> Get the manifest identified by `name` and `reference` where `reference` can be a tag or digest. </summary>        
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CombinedManifest>> GetManifestAsync(string tagOrDigest, IEnumerable<ManifestMediaType> acceptMediaTypes = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifest");
            scope.Start();

            // <param name="acceptMediaType"> Accept header string delimited by comma. For example, application/vnd.docker.distribution.manifest.v2+json. </param>
            //TODO: pull media types from collection and create comma-delimited string.
            string accept = string.Empty; // = CreateCommaDelimitedString(acceptMediaTypes)
            // TODO: what is default behavior if accept it null/list is empty?

            try
            {
                return await RestClient.GetManifestAsync(_repositoryName, tagOrDigest, accept, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the manifest identified by `name` and `reference` where `reference` can be a tag or digest. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CombinedManifest> GetManifest(string tagOrDigest, IEnumerable<ManifestMediaType> acceptMediaTypes = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifest");
            scope.Start();

            // <param name="acceptMediaType"> Accept header string delimited by comma. For example, application/vnd.docker.distribution.manifest.v2+json. </param>
            //TODO: pull media types from collection and create comma-delimited string.
            string accept = string.Empty; // = CreateCommaDelimitedString(acceptMediaTypes)
            // TODO: what is default behavior if accept it null/list is empty?
            try
            {
                return RestClient.GetManifest(_repositoryName, tagOrDigest, accept, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put the manifest identified by `name` and `reference` where `reference` can be a tag or digest. </summary>
        
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CreateManifestAsync(string tagOrDigest, Manifest manifest, CancellationToken cancellationToken = default)
        {
            // TODO: How should we handle the accept header?  This feels like part of the polymorphic/strong-typing story around manifests
            ///// <param name="payload"> Manifest body, can take v1 or v2 values depending on accept header. </param>

            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.CreateManifest");
            scope.Start();
            try
            {
                return await RestClient.CreateManifestAsync(_repositoryName, tagOrDigest, manifest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put the manifest identified by `name` and `reference` where `reference` can be a tag or digest. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CreateManifest(string tagOrDigest, Manifest manifest, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.CreateManifest");
            scope.Start();
            try
            {
                return RestClient.CreateManifest(_repositoryName, tagOrDigest, manifest, cancellationToken);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<TagAttributes> GetTagsAsync(GetTagOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            //using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetTags");
            //scope.Start();
            //try
            //{
            //    return await RestClient.GetTagsAsync(name, last, n, orderby, digest, cancellationToken).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> List tags of a repository. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<TagAttributes> GetTags(GetTagOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            //using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetTags");
            //scope.Start();
            //try
            //{
            //    return RestClient.GetTags(name, last, n, orderby, digest, cancellationToken);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Get tag attributes by tag. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TagAttributes>> GetTagAttributesAsync(string tagName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetTagAttributes");
            scope.Start();
            try
            {
                return await RestClient.GetTagAttributesAsync(_repositoryName, tagName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get tag attributes by tag. </summary>
        public virtual Response<TagAttributes> GetTagAttributes(string tagName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetTagAttributes");
            scope.Start();
            try
            {
                return RestClient.GetTagAttributes(_repositoryName, tagName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update tag attributes. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SetTagPermissionsAsync(string tagName, ContentPermissions permissions, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.UpdateTagAttributes");
            scope.Start();
            try
            {
                return await RestClient.UpdateTagAttributesAsync(_repositoryName, tagName, permissions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update tag attributes. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SetTagPermissions(string tagName, ContentPermissions permissions, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.UpdateTagAttributes");
            scope.Start();
            try
            {
                return RestClient.UpdateTagAttributes(_repositoryName, tagName, permissions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete tag. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteTagAsync(string tagName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.DeleteTag");
            scope.Start();
            try
            {
                return await RestClient.DeleteTagAsync(_repositoryName, tagName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete tag. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeleteTag(string tagName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.DeleteTag");
            scope.Start();
            try
            {
                return RestClient.DeleteTag(_repositoryName, tagName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // TODO: concern here with this name -- GetManifests doesn't return the same thing as GetManifest.  Will this lead to 
        // caller confusion?
        /// <summary> List manifests of a repository. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ManifestAttributes> GetManifestsAsync(GetManifestOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            // call await RestClient.GetManifestsAsync(**_repositoryName**, last, n, orderby, cancellationToken).ConfigureAwait(false);            

            //using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifests");
            //scope.Start();
            //try
            //{
            //    return await RestClient.GetManifestsAsync(name, last, n, orderby, cancellationToken).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> List manifests of a repository. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ManifestAttributes> GetManifests(GetManifestOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            // call RestClient.GetManifests(**_repositoryName**, last, n, orderby, cancellationToken).ConfigureAwait(false);            

            //using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifests");
            //scope.Start();
            //try
            //{
            //    return RestClient.GetManifests(name, last, n, orderby, cancellationToken);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Get manifest attributes. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ManifestAttributes>> GetManifestAttributesAsync(string tagOrDigest, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifestAttributes");
            scope.Start();
            try
            {
                return await RestClient.GetManifestAttributesAsync(_repositoryName, tagOrDigest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get manifest attributes. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManifestAttributes> GetManifestAttributes(string tagOrDigest, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.GetManifestAttributes");
            scope.Start();
            try
            {
                return RestClient.GetManifestAttributes(_repositoryName, tagOrDigest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SetManifestPermissionsAsync(string tagOrDigest, ContentPermissions value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.UpdateManifestAttributes");
            scope.Start();
            try
            {
                return await RestClient.UpdateManifestAttributesAsync(_repositoryName, tagOrDigest, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SetManifestPermissions(string tagOrDigest, ContentPermissions value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryRepositoryClient.UpdateManifestAttributes");
            scope.Start();
            try
            {
                return RestClient.UpdateManifestAttributes(_repositoryName, tagOrDigest, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
