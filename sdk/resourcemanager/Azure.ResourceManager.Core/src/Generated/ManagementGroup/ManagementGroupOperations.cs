// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific ManagementGroup.
    /// </summary>
    public class ManagementGroupOperations : ResourceOperationsBase<TenantResourceIdentifier, ManagementGroup>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private ManagementGroupsRestOperations _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupOperations"/> class for mocking.
        /// </summary>
        protected ManagementGroupOperations()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected internal ManagementGroupOperations(OperationsBase options, TenantResourceIdentifier id)
            : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ManagementGroupsRestOperations(_clientDiagnostics, Pipeline, BaseUri);
        }

        /// <summary>
        /// Gets the resource type definition for a ResourceType.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Management/managementGroups";

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc/>
        public override Response<ManagementGroup> Get(CancellationToken cancellationToken = default)
        {
            return Get(null, null, null, null, cancellationToken);
        }

        /// <inheritdoc/>
        public async override Task<Response<ManagementGroup>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await GetAsync(null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the details of the management group.
        /// .
        /// </summary>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagementGroup> Get(ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.Get");
            scope.Start();
            try
            {
                var response = _restClient.Get(Id.Name, expand, recurse, filter, cacheControl, cancellationToken);
                return Response.FromValue(new ManagementGroup(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the details of the management group.
        /// .
        /// </summary>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ManagementGroup>> GetAsync(ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.Get");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(Id.Name, expand, recurse, filter, cacheControl, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ManagementGroup(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete management group.
        /// If a management group contains child resources, the request will fail.
        /// .
        /// </summary>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.Delete");
            scope.Start();
            try
            {
                var operation = StartDelete(cacheControl, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete management group.
        /// If a management group contains child resources, the request will fail.
        /// .
        /// </summary>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response> DeleteAsync(string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.Delete");
            scope.Start();
            try
            {
                var operation = await StartDeleteAsync(cacheControl, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete management group.
        /// If a management group contains child resources, the request will fail.
        /// .
        /// </summary>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ManagementGroupsDeleteOperation StartDelete(string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.StartDelete");
            scope.Start();
            try
            {
                var originalResponse = _restClient.Delete(Id.Name, cacheControl, cancellationToken);
                return new ManagementGroupsDeleteOperation(_clientDiagnostics, Pipeline, _restClient.CreateDeleteRequest(Id.Name, cacheControl).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete management group.
        /// If a management group contains child resources, the request will fail.
        /// .
        /// </summary>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ManagementGroupsDeleteOperation> StartDeleteAsync(string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.StartDelete");
            scope.Start();
            try
            {
                var originalResponse = await _restClient.DeleteAsync(Id.Name, cacheControl, cancellationToken).ConfigureAwait(false);
                return new ManagementGroupsDeleteOperation(_clientDiagnostics, Pipeline, _restClient.CreateDeleteRequest(Id.Name, cacheControl).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List all entities that descend from a management group.
        /// .
        /// </summary>
        /// <param name="skiptoken">
        /// Page continuation token is only used if a previous operation returned a partial result.
        /// If a previous response contains a nextLink element, the value of the nextLink element will include a token parameter that specifies a starting point to use for subsequent calls.
        /// .
        /// </param>
        /// <param name="top"> Number of elements to return when retrieving results. Passing this in will override $skipToken. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<DescendantInfo> ListDescendants(string skiptoken = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<DescendantInfo> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.ListDescendants");
                scope.Start();
                try
                {
                    var response = _restClient.GetDescendants(Id.Name, skiptoken, top, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DescendantInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.ListDescendants");
                scope.Start();
                try
                {
                    var response = _restClient.GetDescendantsNextPage(nextLink, Id.Name, skiptoken, top, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List all entities that descend from a management group.
        /// .
        /// </summary>
        /// <param name="skiptoken">
        /// Page continuation token is only used if a previous operation returned a partial result.
        /// If a previous response contains a nextLink element, the value of the nextLink element will include a token parameter that specifies a starting point to use for subsequent calls.
        /// .
        /// </param>
        /// <param name="top"> Number of elements to return when retrieving results. Passing this in will override $skipToken. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<DescendantInfo> ListDescendantsAsync(string skiptoken = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DescendantInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.ListDescendants");
                scope.Start();
                try
                {
                    var response = await _restClient.GetDescendantsAsync(Id.Name, skiptoken, top, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DescendantInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.ListDescendants");
                scope.Start();
                try
                {
                    var response = await _restClient.GetDescendantsNextPageAsync(nextLink, Id.Name, skiptoken, top, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Update a management group.
        /// .
        /// </summary>
        /// <param name="patchGroupRequest"> Management group patch parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagementGroup> Update(PatchManagementGroupRequest patchGroupRequest, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.Update");
            scope.Start();
            try
            {
                var response = _restClient.Update(Id.Name, patchGroupRequest, cacheControl, cancellationToken);
                return Response.FromValue(new ManagementGroup(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update a management group.
        /// .
        /// </summary>
        /// <param name="patchGroupRequest"> Management group patch parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ManagementGroup>> UpdateAsync(PatchManagementGroupRequest patchGroupRequest, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupOperations.Update");
            scope.Start();
            try
            {
                var response = await _restClient.UpdateAsync(Id.Name, patchGroupRequest, cacheControl, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ManagementGroup(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
