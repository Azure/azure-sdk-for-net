// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of ManagementGroupContainer and their operations over a ManagementGroup.
    /// </summary>
    public class ManagementGroupContainer : ResourceContainerBase<TenantResourceIdentifier, ManagementGroup, ManagementGroupData>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private ManagementGroupsRestOperations _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementGroupContainer"/> class for mocking.
        /// </summary>
        protected ManagementGroupContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementGroupContainer"/> class.
        /// </summary>
        /// <param name="tenant"> The parent tenant. </param>
        internal ManagementGroupContainer(TenantOperations tenant)
            : base(tenant)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ManagementGroupsRestOperations(_clientDiagnostics, Pipeline, BaseUri);
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => TenantOperations.ResourceType;

        /// <summary>
        /// List management groups for the authenticated user.
        /// .
        /// </summary>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="skiptoken">
        /// Page continuation token is only used if a previous operation returned a partial result.
        /// If a previous response contains a nextLink element, the value of the nextLink element will include a token parameter that specifies a starting point to use for subsequent calls.
        /// .
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ManagementGroupInfo> List(string cacheControl = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            Page<ManagementGroupInfo> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.List(cacheControl, skiptoken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(d => new ManagementGroupInfo(this, d)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagementGroupInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListNextPage(nextLink, cacheControl, skiptoken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(d => new ManagementGroupInfo(this, d)), response.Value.NextLink, response.GetRawResponse());
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
        /// List management groups for the authenticated user.
        /// .
        /// </summary>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="skiptoken">
        /// Page continuation token is only used if a previous operation returned a partial result.
        /// If a previous response contains a nextLink element, the value of the nextLink element will include a token parameter that specifies a starting point to use for subsequent calls.
        /// .
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ManagementGroupInfo> ListAsync(string cacheControl = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagementGroupInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListAsync(cacheControl, skiptoken, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(d => new ManagementGroupInfo(this, d)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagementGroupInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListNextPageAsync(nextLink, cacheControl, skiptoken, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(d => new ManagementGroupInfo(this, d)), response.Value.NextLink, response.GetRawResponse());
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
        /// Get the details of the management group.
        /// .
        /// </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagementGroup> Get(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.Get");
            scope.Start();
            try
            {
                var response = _restClient.Get(groupId, expand, recurse, filter, cacheControl, cancellationToken);
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
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ManagementGroup>> GetAsync(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.Get");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(groupId, expand, recurse, filter, cacheControl, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ManagementGroup(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get the details of the management group.
        /// .
        /// </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ManagementGroup TryGet(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.TryGet");
            scope.Start();
            try
            {
                return Get(groupId, expand, recurse, filter, cacheControl, cancellationToken).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get the details of the management group.
        /// .
        /// </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ManagementGroup> TryGetAsync(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.TryGet");
            scope.Start();
            try
            {
                return await GetAsync(groupId, expand, recurse, filter, cacheControl, cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the management group exists.
        /// .
        /// </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual bool DoesExist(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.DoesExist");
            scope.Start();
            try
            {
                return TryGet(groupId, expand, recurse, filter, cacheControl, cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the management group exists.
        /// .
        /// </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<bool> DoesExistAsync(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.DoesExist");
            scope.Start();
            try
            {
                return await TryGetAsync(groupId, expand, recurse, filter, cacheControl, cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update a management group.
        /// If a management group is already created and a subsequent create request is issued with different properties, the management group properties will be updated.
        /// .
        /// </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="createManagementGroupRequest"> Management group creation parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="createManagementGroupRequest"/> is null. </exception>
        public virtual Response<ManagementGroup> CreateOrUpdate(string groupId, CreateManagementGroupRequest createManagementGroupRequest, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (createManagementGroupRequest == null)
            {
                throw new ArgumentNullException(nameof(createManagementGroupRequest));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(groupId, createManagementGroupRequest, cacheControl, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update a management group.
        /// If a management group is already created and a subsequent create request is issued with different properties, the management group properties will be updated.
        /// .
        /// </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="createManagementGroupRequest"> Management group creation parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="createManagementGroupRequest"/> is null. </exception>
        public async virtual Task<Response<ManagementGroup>> CreateOrUpdateAsync(string groupId, CreateManagementGroupRequest createManagementGroupRequest, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (createManagementGroupRequest == null)
            {
                throw new ArgumentNullException(nameof(createManagementGroupRequest));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(groupId, createManagementGroupRequest, cacheControl, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update a management group.
        /// If a management group is already created and a subsequent create request is issued with different properties, the management group properties will be updated.
        /// .
        /// </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="createManagementGroupRequest"> Management group creation parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="createManagementGroupRequest"/> is null. </exception>
        public virtual ManagementGroupsCreateOrUpdateOperation StartCreateOrUpdate(string groupId, CreateManagementGroupRequest createManagementGroupRequest, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (createManagementGroupRequest == null)
            {
                throw new ArgumentNullException(nameof(createManagementGroupRequest));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = _restClient.CreateOrUpdate(groupId, createManagementGroupRequest, cacheControl, cancellationToken);
                return new ManagementGroupsCreateOrUpdateOperation(this, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(groupId, createManagementGroupRequest, cacheControl).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update a management group.
        /// If a management group is already created and a subsequent create request is issued with different properties, the management group properties will be updated.
        /// .
        /// </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="createManagementGroupRequest"> Management group creation parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="createManagementGroupRequest"/> is null. </exception>
        public async virtual Task<ManagementGroupsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string groupId, CreateManagementGroupRequest createManagementGroupRequest, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (createManagementGroupRequest == null)
            {
                throw new ArgumentNullException(nameof(createManagementGroupRequest));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = await _restClient.CreateOrUpdateAsync(groupId, createManagementGroupRequest, cacheControl, cancellationToken).ConfigureAwait(false);
                return new ManagementGroupsCreateOrUpdateOperation(this, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(groupId, createManagementGroupRequest, cacheControl).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks if the specified management group name is valid and unique. </summary>
        /// <param name="checkNameAvailabilityRequest"> Management group name availability check parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CheckNameAvailabilityResult> CheckNameAvailability(CheckNameAvailabilityRequest checkNameAvailabilityRequest, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.CheckNameAvailability");
            scope.Start();
            try
            {
                return _restClient.CheckNameAvailability(checkNameAvailabilityRequest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks if the specified management group name is valid and unique. </summary>
        /// <param name="checkNameAvailabilityRequest"> Management group name availability check parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(CheckNameAvailabilityRequest checkNameAvailabilityRequest, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroupContainer.CheckNameAvailability");
            scope.Start();
            try
            {
                return await _restClient.CheckNameAvailabilityAsync(checkNameAvailabilityRequest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
