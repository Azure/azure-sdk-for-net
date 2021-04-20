// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> The repository service client. </summary>
    public partial class ContainerRepository
    {
        //private readonly ClientDiagnostics _clientDiagnostics;
        //private readonly ContainerRegistryRepositoryRestClient _restClient;

        /// <summary>
        /// Gets the name of the repository.
        /// </summary>
        public virtual string Name { get; }

        /// <summary> Initializes a new instance of RepositoryClient for mocking. </summary>
        protected ContainerRepository()
        {
        }

        #region Repository methods
        /// <summary> Get repository properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RepositoryProperties>> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(1, cancellationToken).ConfigureAwait(false);
            throw new NotImplementedException();
            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetProperties)}");
            //scope.Start();
            //try
            //{
            //    return await _restClient.GetPropertiesAsync(Name, cancellationToken).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Get repository properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RepositoryProperties> GetProperties(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetProperties)}");
            //scope.Start();
            //try
            //{
            //    return _restClient.GetProperties(Name, cancellationToken);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Update the attribute identified by `name` where `reference` is the name of the repository. </summary>
        /// <param name="value"> Repository attribute value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RepositoryProperties>> SetPropertiesAsync(ContentProperties value, CancellationToken cancellationToken = default)
        {
            await Task.Delay(1, cancellationToken).ConfigureAwait(false);
            throw new NotImplementedException();
            //Argument.AssertNotNull(value, nameof(value));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(SetProperties)}");
            //scope.Start();
            //try
            //{
            //    return await _restClient.SetPropertiesAsync(Name, value, cancellationToken).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary>Update the repository properties.</summary>
        /// <param name="value"> Repository properties to set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RepositoryProperties> SetProperties(ContentProperties value, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            //Argument.AssertNotNull(value, nameof(value));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(SetProperties)}");
            //scope.Start();
            //try
            //{
            //    return _restClient.SetProperties(Name, value, cancellationToken);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Delete the repository. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeleteRepositoryResult>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(1, cancellationToken).ConfigureAwait(false);
            throw new NotImplementedException();
            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(Delete)}");
            //scope.Start();
            //try
            //{
            //    return await _registryRestClient.DeleteRepositoryAsync(Name, cancellationToken).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Delete the repository. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeleteRepositoryResult> Delete(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(Delete)}");
            //scope.Start();
            //try
            //{
            //    return _registryRestClient.DeleteRepository(Name, cancellationToken);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }
        #endregion

        #region Registry Artifact/Manifest methods
        /// <summary> Get the collection of registry artifacts for a repository. </summary>
        /// <param name="options"> Options to override default collection getting behavior. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ManifestProperties> GetArtifactManifestsAsync(GetArtifactManifestsOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            //    async Task<Page<RegistryArtifactProperties>> FirstPageFunc(int? pageSizeHint)
            //    {
            //        using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetRegistryArtifacts)}");
            //        scope.Start();
            //        try
            //        {
            //            var response = await _restClient.GetManifestsAsync(Name, last: null, n: pageSizeHint, orderby: options?.OrderBy.ToString(), cancellationToken: cancellationToken).ConfigureAwait(false);
            //            return Page.FromValues(response.Value.RegistryArtifacts, response.Headers.Link, response.GetRawResponse());
            //        }
            //        catch (Exception e)
            //        {
            //            scope.Failed(e);
            //            throw;
            //        }
            //    }

            //    async Task<Page<RegistryArtifactProperties>> NextPageFunc(string nextLink, int? pageSizeHint)
            //    {
            //        using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetRegistryArtifacts)}");
            //        scope.Start();
            //        try
            //        {
            //            string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
            //            var response = await _restClient.GetManifestsNextPageAsync(uriReference, Name, last: null, n: null, orderby: options?.OrderBy.ToString(), cancellationToken).ConfigureAwait(false);
            //            return Page.FromValues(response.Value.RegistryArtifacts, response.Headers.Link, response.GetRawResponse());
            //        }
            //        catch (Exception e)
            //        {
            //            scope.Failed(e);
            //            throw;
            //        }
            //    }

            //    return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get the collection of tags for a repository. </summary>
        /// <param name="options"> Options to override default collection getting behavior. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ManifestProperties> GetArtifactManifests(GetArtifactManifestsOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            //Page<RegistryArtifactProperties> FirstPageFunc(int? pageSizeHint)
            //{
            //    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetRegistryArtifacts)}");
            //    scope.Start();
            //    try
            //    {
            //        var response = _restClient.GetManifests(Name, last: null, n: pageSizeHint, orderby: options?.OrderBy.ToString(), cancellationToken: cancellationToken);
            //        return Page.FromValues(response.Value.RegistryArtifacts, response.Headers.Link, response.GetRawResponse());
            //    }
            //    catch (Exception e)
            //    {
            //        scope.Failed(e);
            //        throw;
            //    }
            //}

            //Page<RegistryArtifactProperties> NextPageFunc(string nextLink, int? pageSizeHint)
            //{
            //    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetRegistryArtifacts)}");
            //    scope.Start();
            //    try
            //    {
            //        string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
            //        var response = _restClient.GetManifestsNextPage(uriReference, Name, last: null, n: null, orderby: options?.OrderBy.ToString(), cancellationToken);
            //        return Page.FromValues(response.Value.RegistryArtifacts, response.Headers.Link, response.GetRawResponse());
            //    }
            //    catch (Exception e)
            //    {
            //        scope.Failed(e);
            //        throw;
            //    }
            //}

            //return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        #endregion
    }
}
