﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of resources and their operations over their parent.
    /// </summary>
    public class GenericResourceContainer : ResourceContainerBase<TenantResourceIdentifier, GenericResource, GenericResourceData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceContainer"/> class for mocking.
        /// </summary>
        protected GenericResourceContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceContainer"/> class.
        /// </summary>
        /// <param name="clientContext"> The client context to use. </param>
        /// <param name="id"> The id for the subscription that owns this container. </param>
        internal GenericResourceContainer(ClientContext clientContext, SubscriptionResourceIdentifier id)
            : base(clientContext, id)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;

        /// <inheritdoc/>
        protected override void Validate(ResourceIdentifier identifier)
        {
        }

        private ResourcesRestOperations RestClient
        {
            get
            {
                string subscription;
                if (!Id.TryGetSubscriptionId(out subscription))
                {
                    subscription = Guid.Empty.ToString();
                }

                return new ResourcesRestOperations(
                    Diagnostics,
                    Pipeline,
                    subscription,
                    BaseUri);
            }
        }

        /// <summary>
        /// Gets details for this resource from the service.
        /// </summary>
        /// <param name="resourceId"> The ID of the resource to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="Response{GenericResource}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> resourceId cannot be null or a whitespace. </exception>
        public Response<GenericResource> Get(string resourceId, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("GenericResourceContainer.Get");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(resourceId, cancellationToken);
                var result = RestClient.GetById(resourceId, apiVersion, cancellationToken);
                return Response.FromValue(new GenericResource(this, result), result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets details for this resource from the service.
        /// </summary>
        /// <param name="resourceId"> The ID of the resource to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{GenericResource}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> resourceId cannot be null or a whitespace. </exception>
        public virtual async Task<Response<GenericResource>> GetAsync(string resourceId, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("GenericResourceContainer.Get");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(resourceId, cancellationToken).ConfigureAwait(false);
                var result = await RestClient.GetByIdAsync(resourceId, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(this, result), result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get all the resources in a subscription. </summary>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;The properties you can use for eq (equals) or ne (not equals) are: location, resourceType, name, resourceGroup, identity, identity/principalId, plan, plan/publisher, plan/product, plan/name, plan/version, and plan/promotionCode.&lt;br&gt;&lt;br&gt;For example, to filter by a resource type, use: $filter=resourceType eq &apos;Microsoft.Network/virtualNetworks&apos;&lt;br&gt;&lt;br&gt;You can use substringof(value, property) in the filter. The properties you can use for substring are: name and resourceGroup.&lt;br&gt;&lt;br&gt;For example, to get all resources with &apos;demo&apos; anywhere in the name, use: $filter=substringof(&apos;demo&apos;, name)&lt;br&gt;&lt;br&gt;You can link more than one substringof together by adding and/or operators.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. When you filter by a tag name and value, the tags for each resource are not returned in the results.&lt;br&gt;&lt;br&gt;You can use some properties together when filtering. The combinations you can use are: substringof and/or resourceType, plan and plan/publisher and plan/name, identity and identity/principalId. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resource groups. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<GenericResourceExpanded> List(string filter = null, string expand = null, int ? top = null, CancellationToken cancellationToken = default)
        {
            Page<GenericResourceExpanded> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("GenericResourceContainer.List");
                scope.Start();
                try
                {
                    var response = RestClient.List(filter, expand, top, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new GenericResourceExpanded(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<GenericResourceExpanded> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("GenericResourceContainer.List");
                scope.Start();
                try
                {
                    var response = RestClient.ListNextPage(nextLink, filter, expand, top, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new GenericResourceExpanded(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get all the resources in a subscription. </summary>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;The properties you can use for eq (equals) or ne (not equals) are: location, resourceType, name, resourceGroup, identity, identity/principalId, plan, plan/publisher, plan/product, plan/name, plan/version, and plan/promotionCode.&lt;br&gt;&lt;br&gt;For example, to filter by a resource type, use: $filter=resourceType eq &apos;Microsoft.Network/virtualNetworks&apos;&lt;br&gt;&lt;br&gt;You can use substringof(value, property) in the filter. The properties you can use for substring are: name and resourceGroup.&lt;br&gt;&lt;br&gt;For example, to get all resources with &apos;demo&apos; anywhere in the name, use: $filter=substringof(&apos;demo&apos;, name)&lt;br&gt;&lt;br&gt;You can link more than one substringof together by adding and/or operators.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. When you filter by a tag name and value, the tags for each resource are not returned in the results.&lt;br&gt;&lt;br&gt;You can use some properties together when filtering. The combinations you can use are: substringof and/or resourceType, plan and plan/publisher and plan/name, identity and identity/principalId. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resource groups. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<GenericResourceExpanded> ListAsync(string filter = null, string expand = null, int ? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<GenericResourceExpanded>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("GenericResourceContainer.List");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAsync(filter, expand, top, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new GenericResourceExpanded(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<GenericResourceExpanded>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("GenericResourceContainer.List");
                scope.Start();
                try
                {
                    var response = await RestClient.ListNextPageAsync(nextLink, filter, expand, top, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new GenericResourceExpanded(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get all the resources for a resource group. </summary>
        /// <param name="resourceGroupName"> The resource group with the resources to get. </param>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;The properties you can use for eq (equals) or ne (not equals) are: location, resourceType, name, resourceGroup, identity, identity/principalId, plan, plan/publisher, plan/product, plan/name, plan/version, and plan/promotionCode.&lt;br&gt;&lt;br&gt;For example, to filter by a resource type, use: $filter=resourceType eq &apos;Microsoft.Network/virtualNetworks&apos;&lt;br&gt;&lt;br&gt;You can use substringof(value, property) in the filter. The properties you can use for substring are: name and resourceGroup.&lt;br&gt;&lt;br&gt;For example, to get all resources with &apos;demo&apos; anywhere in the name, use: $filter=substringof(&apos;demo&apos;, name)&lt;br&gt;&lt;br&gt;You can link more than one substringof together by adding and/or operators.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. When you filter by a tag name and value, the tags for each resource are not returned in the results.&lt;br&gt;&lt;br&gt;You can use some properties together when filtering. The combinations you can use are: substringof and/or resourceType, plan and plan/publisher and plan/name, identity and identity/principalId. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public virtual Pageable<GenericResourceExpanded> ListByResourceGroup(string resourceGroupName, string filter = null, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            Page<GenericResourceExpanded> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("GenericResourceContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = RestClient.ListByResourceGroup(resourceGroupName, filter, expand, top, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new GenericResourceExpanded(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<GenericResourceExpanded> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("GenericResourceContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = RestClient.ListByResourceGroupNextPage(nextLink, resourceGroupName, filter, expand, top, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new GenericResourceExpanded(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get all the resources for a resource group. </summary>
        /// <param name="resourceGroupName"> The resource group with the resources to get. </param>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;The properties you can use for eq (equals) or ne (not equals) are: location, resourceType, name, resourceGroup, identity, identity/principalId, plan, plan/publisher, plan/product, plan/name, plan/version, and plan/promotionCode.&lt;br&gt;&lt;br&gt;For example, to filter by a resource type, use: $filter=resourceType eq &apos;Microsoft.Network/virtualNetworks&apos;&lt;br&gt;&lt;br&gt;You can use substringof(value, property) in the filter. The properties you can use for substring are: name and resourceGroup.&lt;br&gt;&lt;br&gt;For example, to get all resources with &apos;demo&apos; anywhere in the name, use: $filter=substringof(&apos;demo&apos;, name)&lt;br&gt;&lt;br&gt;You can link more than one substringof together by adding and/or operators.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. When you filter by a tag name and value, the tags for each resource are not returned in the results.&lt;br&gt;&lt;br&gt;You can use some properties together when filtering. The combinations you can use are: substringof and/or resourceType, plan and plan/publisher and plan/name, identity and identity/principalId. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public virtual AsyncPageable<GenericResourceExpanded> ListByResourceGroupAsync(string resourceGroupName, string filter = null, string expand = null, int ? top = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            async Task<Page<GenericResourceExpanded>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("GenericResourceContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = await RestClient.ListByResourceGroupAsync(resourceGroupName, filter, expand, top, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new GenericResourceExpanded(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<GenericResourceExpanded>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("GenericResourceContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = await RestClient.ListByResourceGroupNextPageAsync(nextLink, resourceGroupName, filter, expand, top, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new GenericResourceExpanded(this, data)).ToList(), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Create a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="parameters"> Create or update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<GenericResource> CreateOrUpdate(string resourceId, GenericResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("GenericResourceContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(resourceId, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="parameters"> Create or update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<Response<GenericResource>> CreateOrUpdateAsync(string resourceId, GenericResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("GenericResourceContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(resourceId, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="parameters"> Create or update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ResourcesCreateOrUpdateByIdOperation StartCreateOrUpdate(string resourceId, GenericResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("GenericResourceContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(resourceId, cancellationToken);
                var originalResponse = RestClient.CreateOrUpdateById(resourceId, apiVersion, parameters, cancellationToken);
                return new ResourcesCreateOrUpdateByIdOperation(this, Diagnostics, Pipeline, RestClient.CreateCreateOrUpdateByIdRequest(resourceId, apiVersion, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="parameters"> Create or update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ResourcesCreateOrUpdateByIdOperation> StartCreateOrUpdateAsync(string resourceId, GenericResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("GenericResourceContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(resourceId, cancellationToken).ConfigureAwait(false);
                var originalResponse = await RestClient.CreateOrUpdateByIdAsync(resourceId, apiVersion, parameters, cancellationToken).ConfigureAwait(false);
                return new ResourcesCreateOrUpdateByIdOperation(this, Diagnostics, Pipeline, RestClient.CreateCreateOrUpdateByIdRequest(resourceId, apiVersion, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        protected override ResourceOperationsBase<TenantResourceIdentifier, GenericResource> GetOperation(string resourceId)
        {
            return new GenericResourceOperations(this, resourceId);
        }

        private string GetApiVersion(ResourceIdentifier resourceId, CancellationToken cancellationToken)
        {
            string version = ClientOptions.ApiVersions.TryGetApiVersion(resourceId.ResourceType, cancellationToken);
            if (version is null)
            {
                throw new InvalidOperationException($"An invalid resouce id was given {resourceId}");
            }
            return version;
        }

        private async Task<string> GetApiVersionAsync(ResourceIdentifier resourceId, CancellationToken cancellationToken)
        {
            string version = await ClientOptions.ApiVersions.TryGetApiVersionAsync(resourceId.ResourceType, cancellationToken).ConfigureAwait(false);
            if (version is null)
            {
                throw new InvalidOperationException($"An invalid resouce id was given {resourceId}");
            }
            return version;
        }
    }
}
