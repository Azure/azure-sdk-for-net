// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Management
{
    /// <summary>
    /// A class representing collection of ManagementGroupContainer and their operations over a ManagementGroup.
    /// </summary>
    public class ManagementGroupContainer : ArmContainer
    {
        private ClientDiagnostics _clientDiagnostics;
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
        internal ManagementGroupContainer(Tenant tenant)
            : base(tenant)
        {
        }

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected new Tenant Parent { get {return base.Parent as Tenant;} }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => Tenant.ResourceType;

        private ManagementGroupsRestOperations RestClient => _restClient ??= new ManagementGroupsRestOperations(_clientDiagnostics, Pipeline, BaseUri);

        private ClientDiagnostics Diagnostics => _clientDiagnostics ??= new ClientDiagnostics(ClientOptions);

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
        public virtual Pageable<ManagementGroup> GetAll(string cacheControl = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            Page<ManagementGroup> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ManagementGroupContainer.GetAll");
                scope.Start();
                try
                {
                    var response = RestClient.List(cacheControl, skiptoken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(d => new ManagementGroup(this, d)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagementGroup> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ManagementGroupContainer.GetAll");
                scope.Start();
                try
                {
                    var response = RestClient.ListNextPage(nextLink, cacheControl, skiptoken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(d => new ManagementGroup(this, d)), response.Value.NextLink, response.GetRawResponse());
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
        public virtual AsyncPageable<ManagementGroup> GetAllAsync(string cacheControl = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagementGroup>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ManagementGroupContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAsync(cacheControl, skiptoken, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(d => new ManagementGroup(this, d)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagementGroup>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ManagementGroupContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await RestClient.ListNextPageAsync(nextLink, cacheControl, skiptoken, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(d => new ManagementGroup(this, d)), response.Value.NextLink, response.GetRawResponse());
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
            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.Get");
            scope.Start();
            try
            {
                var response = RestClient.Get(groupId, expand, recurse, filter, cacheControl, cancellationToken);
                if (response.Value == null)
                    throw Diagnostics.CreateRequestFailedException(response.GetRawResponse());

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
            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.Get");
            scope.Start();
            try
            {
                var response = await RestClient.GetAsync(groupId, expand, recurse, filter, cacheControl, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await Diagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);

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
        public virtual Response<ManagementGroup> GetIfExists(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.GetIfExists");
            scope.Start();
            try
            {
                var response = RestClient.Get(groupId, expand, recurse, filter, cacheControl, cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ManagementGroup>(null, response.GetRawResponse())
                    : Response.FromValue(new ManagementGroup(this, response.Value), response.GetRawResponse());
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
        public async virtual Task<Response<ManagementGroup>> GetIfExistsAsync(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.GetIfExists");
            scope.Start();
            try
            {
                var response = await RestClient.GetAsync(groupId, expand, recurse, filter, cacheControl, cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ManagementGroup>(null, response.GetRawResponse())
                    : Response.FromValue(new ManagementGroup(this, response.Value), response.GetRawResponse());
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
        public virtual Response<bool> CheckIfExists(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.CheckIfExists");
            scope.Start();
            try
            {
                var response = GetIfExists(groupId, expand, recurse, filter, cacheControl, cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
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
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.CheckIfExists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(groupId, expand, recurse, filter, cacheControl, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
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
        /// <param name="createManagementGroupOptions"> Management group creation parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="createManagementGroupOptions"/> is null. </exception>
        public virtual Response<ManagementGroup> CreateOrUpdate(string groupId, CreateManagementGroupOptions createManagementGroupOptions, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (createManagementGroupOptions == null)
            {
                throw new ArgumentNullException(nameof(createManagementGroupOptions));
            }

            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(groupId, createManagementGroupOptions, cacheControl, cancellationToken);
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
        /// <param name="createManagementGroupOptions"> Management group creation parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="createManagementGroupOptions"/> is null. </exception>
        public async virtual Task<Response<ManagementGroup>> CreateOrUpdateAsync(string groupId, CreateManagementGroupOptions createManagementGroupOptions, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (createManagementGroupOptions == null)
            {
                throw new ArgumentNullException(nameof(createManagementGroupOptions));
            }

            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(groupId, createManagementGroupOptions, cacheControl, cancellationToken).ConfigureAwait(false);
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
        /// <param name="createManagementGroupOptions"> Management group creation parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="createManagementGroupOptions"/> is null. </exception>
        public virtual ManagementGroupCreateOrUpdateOperation StartCreateOrUpdate(string groupId, CreateManagementGroupOptions createManagementGroupOptions, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (createManagementGroupOptions == null)
            {
                throw new ArgumentNullException(nameof(createManagementGroupOptions));
            }

            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = RestClient.CreateOrUpdate(groupId, createManagementGroupOptions, cacheControl, cancellationToken);
                return new ManagementGroupCreateOrUpdateOperation(this, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(groupId, createManagementGroupOptions, cacheControl).Request, originalResponse);
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
        /// <param name="createManagementGroupOptions"> Management group creation parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="createManagementGroupOptions"/> is null. </exception>
        public async virtual Task<ManagementGroupCreateOrUpdateOperation> StartCreateOrUpdateAsync(string groupId, CreateManagementGroupOptions createManagementGroupOptions, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (createManagementGroupOptions == null)
            {
                throw new ArgumentNullException(nameof(createManagementGroupOptions));
            }

            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.CreateOrUpdateAsync(groupId, createManagementGroupOptions, cacheControl, cancellationToken).ConfigureAwait(false);
                return new ManagementGroupCreateOrUpdateOperation(this, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(groupId, createManagementGroupOptions, cacheControl).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks if the specified management group name is valid and unique. </summary>
        /// <param name="checkNameAvailabilityOptions"> Management group name availability check parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CheckNameAvailabilityResult> CheckNameAvailability(CheckNameAvailabilityOptions checkNameAvailabilityOptions, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.CheckNameAvailability");
            scope.Start();
            try
            {
                return RestClient.CheckNameAvailability(checkNameAvailabilityOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks if the specified management group name is valid and unique. </summary>
        /// <param name="checkNameAvailabilityOptions"> Management group name availability check parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(CheckNameAvailabilityOptions checkNameAvailabilityOptions, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ManagementGroupContainer.CheckNameAvailability");
            scope.Start();
            try
            {
                return await RestClient.CheckNameAvailabilityAsync(checkNameAvailabilityOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
