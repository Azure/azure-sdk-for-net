// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Collections.Generic;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subscription.
    /// </summary>
    public partial class SubscriptionResource : ArmResource
    {
        /// RequestPath: /subscriptions/{subscriptionId}/resources
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Resources_List
        /// <summary> Get all the resources in a subscription. </summary>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;The properties you can use for eq (equals) or ne (not equals) are: location, resourceType, name, resourceGroup, identity, identity/principalId, plan, plan/publisher, plan/product, plan/name, plan/version, and plan/promotionCode.&lt;br&gt;&lt;br&gt;For example, to filter by a resource type, use: $filter=resourceType eq &apos;Microsoft.Network/virtualNetworks&apos;&lt;br&gt;&lt;br&gt;You can use substringof(value, property) in the filter. The properties you can use for substring are: name and resourceGroup.&lt;br&gt;&lt;br&gt;For example, to get all resources with &apos;demo&apos; anywhere in the name, use: $filter=substringof(&apos;demo&apos;, name)&lt;br&gt;&lt;br&gt;You can link more than one substringof together by adding and/or operators.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. When you filter by a tag name and value, the tags for each resource are not returned in the results.&lt;br&gt;&lt;br&gt;You can use some properties together when filtering. The combinations you can use are: substringof and/or resourceType, plan and plan/publisher and plan/name, identity and identity/principalId. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resource groups. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GenericResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetGenericResourcesAsync(string filter = null, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<GenericResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subscriptionClientDiagnostics.CreateScope("SubscriptionResource.GetGenericResources");
                scope.Start();
                try
                {
                    var response = await _subscriptionResourcesRestClient.ListAsync(Id.SubscriptionId, filter, expand, top, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _subscriptionResourcesClientDiagnostics.CreateScope("SubscriptionResource.GetGenericResources");
                scope.Start();
                try
                {
                    var response = await _subscriptionResourcesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, filter, expand, top, cancellationToken: cancellationToken).ConfigureAwait(false);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resources
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Resources_List
        /// <summary> Get all the resources in a subscription. </summary>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;The properties you can use for eq (equals) or ne (not equals) are: location, resourceType, name, resourceGroup, identity, identity/principalId, plan, plan/publisher, plan/product, plan/name, plan/version, and plan/promotionCode.&lt;br&gt;&lt;br&gt;For example, to filter by a resource type, use: $filter=resourceType eq &apos;Microsoft.Network/virtualNetworks&apos;&lt;br&gt;&lt;br&gt;You can use substringof(value, property) in the filter. The properties you can use for substring are: name and resourceGroup.&lt;br&gt;&lt;br&gt;For example, to get all resources with &apos;demo&apos; anywhere in the name, use: $filter=substringof(&apos;demo&apos;, name)&lt;br&gt;&lt;br&gt;You can link more than one substringof together by adding and/or operators.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. When you filter by a tag name and value, the tags for each resource are not returned in the results.&lt;br&gt;&lt;br&gt;You can use some properties together when filtering. The combinations you can use are: substringof and/or resourceType, plan and plan/publisher and plan/name, identity and identity/principalId. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resource groups. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GenericResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetGenericResources(string filter = null, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<GenericResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subscriptionResourcesClientDiagnostics.CreateScope("SubscriptionResource.GetGenericResources");
                scope.Start();
                try
                {
                    var response = _subscriptionResourcesRestClient.List(Id.SubscriptionId, filter, expand, top, cancellationToken: cancellationToken);
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
                using var scope = _subscriptionResourcesClientDiagnostics.CreateScope("SubscriptionResource.GetGenericResources");
                scope.Start();
                try
                {
                    var response = _subscriptionResourcesRestClient.ListNextPage(nextLink, Id.SubscriptionId, filter, expand, top, cancellationToken: cancellationToken);
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
        /// Gets the RestApi definition for a given Azure namespace.
        /// </summary>
        /// <param name="azureNamespace"> The namespace to get the rest API for. </param>
        /// <returns> A collection representing the rest apis for the namespace. </returns>
        public virtual ArmRestApiCollection GetArmRestApis(string azureNamespace)
        {
            return new ArmRestApiCollection(this, azureNamespace);
        }
    }
}
