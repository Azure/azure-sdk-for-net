// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources.Models;

[assembly:CodeGenSuppressType("ResourceGroupUpdateOperation")]
namespace Azure.ResourceManager.Resources
{
    /// <summary> A Class representing a ResourceGroupResource along with the instance operations that can be performed on it. </summary>
    public partial class ResourceGroupResource : ArmResource
    {
        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/resources
        /// ContextualPath: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// OperationId: Resources_ListByResourceGroup
        /// <summary> Get all the resources for a resource group. </summary>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;The properties you can use for eq (equals) or ne (not equals) are: location, resourceType, name, resourceGroup, identity, identity/principalId, plan, plan/publisher, plan/product, plan/name, plan/version, and plan/promotionCode.&lt;br&gt;&lt;br&gt;For example, to filter by a resource type, use: $filter=resourceType eq &apos;Microsoft.Network/virtualNetworks&apos;&lt;br&gt;&lt;br&gt;You can use substringof(value, property) in the filter. The properties you can use for substring are: name and resourceGroup.&lt;br&gt;&lt;br&gt;For example, to get all resources with &apos;demo&apos; anywhere in the name, use: $filter=substringof(&apos;demo&apos;, name)&lt;br&gt;&lt;br&gt;You can link more than one substringof together by adding and/or operators.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. When you filter by a tag name and value, the tags for each resource are not returned in the results.&lt;br&gt;&lt;br&gt;You can use some properties together when filtering. The combinations you can use are: substringof and/or resourceType, plan and plan/publisher and plan/name, identity and identity/principalId. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GenericResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetGenericResourcesAsync(string filter = null, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<GenericResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceGroupResourcesClientDiagnostics.CreateScope("ResourceGroupResource.GetGenericResources");
                scope.Start();
                try
                {
                    var response = await _resourceGroupResourcesRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, filter, expand, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new GenericResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<GenericResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupResource.GetGenericResources");
                scope.Start();
                try
                {
                    var response = await _resourceGroupResourcesRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, expand, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new GenericResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/resources
        /// ContextualPath: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// OperationId: Resources_ListByResourceGroup
        /// <summary> Get all the resources for a resource group. </summary>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;The properties you can use for eq (equals) or ne (not equals) are: location, resourceType, name, resourceGroup, identity, identity/principalId, plan, plan/publisher, plan/product, plan/name, plan/version, and plan/promotionCode.&lt;br&gt;&lt;br&gt;For example, to filter by a resource type, use: $filter=resourceType eq &apos;Microsoft.Network/virtualNetworks&apos;&lt;br&gt;&lt;br&gt;You can use substringof(value, property) in the filter. The properties you can use for substring are: name and resourceGroup.&lt;br&gt;&lt;br&gt;For example, to get all resources with &apos;demo&apos; anywhere in the name, use: $filter=substringof(&apos;demo&apos;, name)&lt;br&gt;&lt;br&gt;You can link more than one substringof together by adding and/or operators.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. When you filter by a tag name and value, the tags for each resource are not returned in the results.&lt;br&gt;&lt;br&gt;You can use some properties together when filtering. The combinations you can use are: substringof and/or resourceType, plan and plan/publisher and plan/name, identity and identity/principalId. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GenericResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetGenericResources(string filter = null, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<GenericResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceGroupResourcesClientDiagnostics.CreateScope("ResourceGroupResource.GetGenericResources");
                scope.Start();
                try
                {
                    var response = _resourceGroupResourcesRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, filter, expand, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new GenericResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<GenericResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupResource.GetGenericResources");
                scope.Start();
                try
                {
                    var response = _resourceGroupResourcesRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, expand, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new GenericResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<ResourceGroupResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _resourceGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    ResourceGroupResource current = await GetAsync(cancellationToken).ConfigureAwait(false);
                    ResourceGroupPatch patch = new ResourceGroupPatch();
                    foreach (var tag in current.Data.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var originalResponse = await _resourceGroupRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, patch, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<ResourceGroupResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _resourceGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    ResourceGroupResource current = Get(cancellationToken);
                    ResourceGroupPatch patch = new ResourceGroupPatch();
                    foreach (var tag in current.Data.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var originalResponse = _resourceGroupRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, patch, cancellationToken);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<ResourceGroupResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _resourceGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    ResourceGroupPatch patch = new ResourceGroupPatch();
                    foreach (var tag in tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    var originalResponse = await _resourceGroupRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, patch, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<ResourceGroupResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _resourceGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    ResourceGroupPatch patch = new ResourceGroupPatch();
                    foreach (var tag in tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    var originalResponse = _resourceGroupRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, patch, cancellationToken);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<ResourceGroupResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _resourceGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    ResourceGroupResource current = await GetAsync(cancellationToken).ConfigureAwait(false);
                    ResourceGroupPatch patch = new ResourceGroupPatch();
                    foreach (var tag in current.Data.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var originalResponse = await _resourceGroupRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, patch, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<ResourceGroupResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _resourceGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    ResourceGroupResource current = Get(cancellationToken);
                    ResourceGroupPatch patch = new ResourceGroupPatch();
                    foreach (var tag in current.Data.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var originalResponse = _resourceGroupRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, patch, cancellationToken);
                    return Response.FromValue(new ResourceGroupResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
