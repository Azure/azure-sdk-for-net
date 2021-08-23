// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    /// A class representing the operations that can be performed over a specific ManagementGroup.
    /// </summary>
    public class ManagementGroup : ArmResource
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ManagementGroupsRestOperations _restClient;
        private readonly ManagementGroupData _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroup"/> class for mocking.
        /// </summary>
        protected ManagementGroup()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroup"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected internal ManagementGroup(ArmResource options, ResourceIdentifier id)
            : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ManagementGroupsRestOperations(_clientDiagnostics, Pipeline, BaseUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementGroup"/> class.
        /// </summary>
        /// <param name="operations"> The operations to copy the client options from. </param>
        /// <param name="resource"> The ManagementGroupData to use in these operations. </param>
        internal ManagementGroup(ArmResource operations, ManagementGroupData resource)
            : base(operations, resource.Id)
        {
            _data = resource;
            HasData = true;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ManagementGroupsRestOperations(_clientDiagnostics, Pipeline, BaseUri);
        }

        /// <summary>
        /// Gets the resource type definition for a ResourceType.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Management/managementGroups";

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <summary>
        /// Gets whether or not the current instance has data.
        /// </summary>
        public bool HasData { get; }

        /// <summary>
        /// Gets the data representing this ManagementGroup.
        /// </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ManagementGroupData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data you must call Get first");
                return _data;
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
        public virtual Response<ManagementGroup> Get(ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroup.Get");
            scope.Start();
            try
            {
                var response = _restClient.Get(Id.Name, expand, recurse, filter, cacheControl, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());

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
            using var scope = _clientDiagnostics.CreateScope("ManagementGroup.Get");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(Id.Name, expand, recurse, filter, cacheControl, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);

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
            using var scope = _clientDiagnostics.CreateScope("ManagementGroup.Delete");
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
            using var scope = _clientDiagnostics.CreateScope("ManagementGroup.Delete");
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
        public virtual ManagementGroupDeleteOperation StartDelete(string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroup.StartDelete");
            scope.Start();
            try
            {
                var originalResponse = _restClient.Delete(Id.Name, cacheControl, cancellationToken);
                return new ManagementGroupDeleteOperation(_clientDiagnostics, Pipeline, _restClient.CreateDeleteRequest(Id.Name, cacheControl).Request, originalResponse);
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
        public async virtual Task<ManagementGroupDeleteOperation> StartDeleteAsync(string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroup.StartDelete");
            scope.Start();
            try
            {
                var originalResponse = await _restClient.DeleteAsync(Id.Name, cacheControl, cancellationToken).ConfigureAwait(false);
                return new ManagementGroupDeleteOperation(_clientDiagnostics, Pipeline, _restClient.CreateDeleteRequest(Id.Name, cacheControl).Request, originalResponse);
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
        public virtual Pageable<DescendantInfo> GetDescendants(string skiptoken = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<DescendantInfo> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementGroup.GetDescendants");
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
                using var scope = _clientDiagnostics.CreateScope("ManagementGroup.GetDescendants");
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
        public virtual AsyncPageable<DescendantInfo> GetDescendantsAsync(string skiptoken = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DescendantInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementGroup.GetDescendants");
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
                using var scope = _clientDiagnostics.CreateScope("ManagementGroup.GetDescendants");
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
        /// <param name="patchGroupOptions"> Management group patch parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagementGroup> Update(PatchManagementGroupOptions patchGroupOptions, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroup.Update");
            scope.Start();
            try
            {
                var response = _restClient.Update(Id.Name, patchGroupOptions, cacheControl, cancellationToken);
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
        /// <param name="patchGroupOptions"> Management group patch parameters. </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ManagementGroup>> UpdateAsync(PatchManagementGroupOptions patchGroupOptions, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementGroup.Update");
            scope.Start();
            try
            {
                var response = await _restClient.UpdateAsync(Id.Name, patchGroupOptions, cacheControl, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ManagementGroup(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the policy definition container for this management group.
        /// </summary>
        /// <returns> A container of the policy definition. </returns>
        public virtual PolicyDefinitionContainer GetPolicyDefinitions()
        {
            return new PolicyDefinitionContainer(this);
        }

        /// <summary>
        /// Gets the policy set definition container for this management group.
        /// </summary>
        /// <returns> A container of the policy set definition. </returns>
        public virtual PolicySetDefinitionContainer GetPolicySetDefinitions()
        {
            return new PolicySetDefinitionContainer(this);
        }
    }
}
