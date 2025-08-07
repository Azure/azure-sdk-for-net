// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.NotificationHubs.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NotificationHubs
{
    /// <summary>
    /// A class representing a collection of <see cref="NotificationHubNamespaceResource"/> and their operations.
    /// Each <see cref="NotificationHubNamespaceResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="NotificationHubNamespaceCollection"/> instance call the GetNotificationHubNamespaces method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class NotificationHubNamespaceCollection : ArmCollection, IEnumerable<NotificationHubNamespaceResource>, IAsyncEnumerable<NotificationHubNamespaceResource>
    {
        /// <summary>
        /// Creates/Updates a service namespace. Once created, this namespace's resource manifest is immutable. This operation is idempotent.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Namespaces_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubNamespaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="namespaceName"> The namespace name. </param>
        /// <param name="content"> Parameters supplied to create a Namespace Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationHubNamespaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string namespaceName, NotificationHubNamespaceCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            Response<NotificationHubNamespaceResource> resource = await GetAsync(namespaceName, cancellationToken).ConfigureAwait(false);
            NotificationHubNamespaceData param = new NotificationHubNamespaceData(
                resource.Value.Data.Id,
                resource.Value.Data.Name,
                resource.Value.Data.ResourceType,
                resource.Value.Data.SystemData,
                resource.Value.Data.Tags,
                resource.Value.Data.Location,
                content.Sku,
                content.NamespaceName,
                content.ProvisioningState,
                content.Status,
                content.IsEnabled,
                content.IsCritical,
                content.SubscriptionId,
                content.Region,
                content.MetricId,
                content.CreatedOn,
                content.UpdatedOn,
                content.NamespaceType.ToString(),
                null,
                null,
                null,
                null,
                content.ServiceBusEndpoint,
                null,
                content.ScaleUnit,
                content.DataCenter,
                null,
                null);
            return await CreateOrUpdateAsync(waitUntil, namespaceName, param, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates/Updates a service namespace. Once created, this namespace's resource manifest is immutable. This operation is idempotent.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Namespaces_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubNamespaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="namespaceName"> The namespace name. </param>
        /// <param name="content"> Parameters supplied to create a Namespace Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationHubNamespaceResource> CreateOrUpdate(WaitUntil waitUntil, string namespaceName, NotificationHubNamespaceCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            Response<NotificationHubNamespaceResource> resource = Get(namespaceName, cancellationToken);
            NotificationHubNamespaceData param = new NotificationHubNamespaceData(
                resource.Value.Data.Id,
                resource.Value.Data.Name,
                resource.Value.Data.ResourceType,
                resource.Value.Data.SystemData,
                resource.Value.Data.Tags,
                resource.Value.Data.Location,
                content.Sku,
                content.NamespaceName,
                content.ProvisioningState,
                content.Status,
                content.IsEnabled,
                content.IsCritical,
                content.SubscriptionId,
                content.Region,
                content.MetricId,
                content.CreatedOn,
                content.UpdatedOn,
                content.NamespaceType.ToString(),
                null,
                null,
                null,
                null,
                content.ServiceBusEndpoint,
                null,
                content.ScaleUnit,
                content.DataCenter,
                null,
                null);
            return CreateOrUpdate(waitUntil, namespaceName, param, cancellationToken);
        }

        /// <summary>
        /// Lists the available namespaces within a resourceGroup.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Namespaces_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubNamespaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NotificationHubNamespaceResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NotificationHubNamespaceResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(null, null, cancellationToken);

        /// <summary>
        /// Lists the available namespaces within a resourceGroup.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Namespaces_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubNamespaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NotificationHubNamespaceResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NotificationHubNamespaceResource> GetAll(CancellationToken cancellationToken)
            => GetAll(null, null, cancellationToken);
    }
}
