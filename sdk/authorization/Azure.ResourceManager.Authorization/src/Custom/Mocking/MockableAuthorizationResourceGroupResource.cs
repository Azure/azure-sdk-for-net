// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// TypeSpec places this legacy variable-resource permissions route on ArmClient.
// This partial preserves the shipped ResourceGroupResource mocking surface.

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Authorization.Models;

namespace Azure.ResourceManager.Authorization.Mocking
{
    public partial class MockableAuthorizationResourceGroupResource
    {
        private MockableAuthorizationArmClient GetMockableAuthorizationArmClient()
        {
            return GetCachedClient(client => new MockableAuthorizationArmClient(client, ResourceIdentifier.Root));
        }

        /// <summary>
        /// Gets all permissions the caller has for a resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/permissions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzurePermissionsForResource_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="parentResourcePath"> The parent resource identity. </param>
        /// <param name="resourceType"> The resource type of the resource. </param>
        /// <param name="resourceName"> The name of the resource to get the permissions for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/>, <paramref name="parentResourcePath"/>, <paramref name="resourceType"/> or <paramref name="resourceName"/> is null. </exception>
        /// <returns> An async collection of <see cref="RoleDefinitionPermission"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RoleDefinitionPermission> GetAzurePermissionsForResourcesAsync(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceProviderNamespace, nameof(resourceProviderNamespace));
            Argument.AssertNotNull(parentResourcePath, nameof(parentResourcePath));
            Argument.AssertNotNull(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            if (resourceProviderNamespace.Length == 0 || parentResourcePath.Length == 0 || resourceType.Length == 0)
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                return new PermissionsGetAzurePermissionsForResourceAsyncCollectionResultOfT(
                    PermissionsRestClient,
                    Id.SubscriptionId,
                    Id.ResourceGroupName,
                    resourceProviderNamespace,
                    parentResourcePath,
                    resourceType,
                    resourceName,
                    context,
                    "MockableAuthorizationResourceGroupResource.GetAzurePermissionsForResources");
            }

            return GetMockableAuthorizationArmClient().GetAzurePermissionsForResourceAsync(
                Id,
                Id.ResourceGroupName,
                resourceProviderNamespace,
                parentResourcePath,
                resourceType,
                resourceName,
                Id.SubscriptionId,
                cancellationToken);
        }

        /// <summary>
        /// Gets all permissions the caller has for a resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/permissions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzurePermissionsForResource_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="parentResourcePath"> The parent resource identity. </param>
        /// <param name="resourceType"> The resource type of the resource. </param>
        /// <param name="resourceName"> The name of the resource to get the permissions for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/>, <paramref name="parentResourcePath"/>, <paramref name="resourceType"/> or <paramref name="resourceName"/> is null. </exception>
        /// <returns> A collection of <see cref="RoleDefinitionPermission"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RoleDefinitionPermission> GetAzurePermissionsForResources(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceProviderNamespace, nameof(resourceProviderNamespace));
            Argument.AssertNotNull(parentResourcePath, nameof(parentResourcePath));
            Argument.AssertNotNull(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            if (resourceProviderNamespace.Length == 0 || parentResourcePath.Length == 0 || resourceType.Length == 0)
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                return new PermissionsGetAzurePermissionsForResourceCollectionResultOfT(
                    PermissionsRestClient,
                    Id.SubscriptionId,
                    Id.ResourceGroupName,
                    resourceProviderNamespace,
                    parentResourcePath,
                    resourceType,
                    resourceName,
                    context,
                    "MockableAuthorizationResourceGroupResource.GetAzurePermissionsForResources");
            }

            return GetMockableAuthorizationArmClient().GetAzurePermissionsForResource(
                Id,
                Id.ResourceGroupName,
                resourceProviderNamespace,
                parentResourcePath,
                resourceType,
                resourceName,
                Id.SubscriptionId,
                cancellationToken);
        }
    }
}
