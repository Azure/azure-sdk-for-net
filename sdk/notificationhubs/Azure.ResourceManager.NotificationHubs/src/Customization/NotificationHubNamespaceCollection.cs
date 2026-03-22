// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    // Backward-compat: baseline had CreateOrUpdate overloads accepting NotificationHubNamespaceCreateOrUpdateContent
    // and GetAll overloads with CancellationToken-only parameter.
    public partial class NotificationHubNamespaceCollection
    {
        /// <summary> Creates/Updates a service namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="namespaceName"> The namespace name. </param>
        /// <param name="content"> Parameters supplied to create a Namespace Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationHubNamespaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string namespaceName, NotificationHubNamespaceCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            var data = ContentToData(content);
            return await CreateOrUpdateAsync(waitUntil, namespaceName, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Creates/Updates a service namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="namespaceName"> The namespace name. </param>
        /// <param name="content"> Parameters supplied to create a Namespace Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationHubNamespaceResource> CreateOrUpdate(WaitUntil waitUntil, string namespaceName, NotificationHubNamespaceCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            var data = ContentToData(content);
            return CreateOrUpdate(waitUntil, namespaceName, data, cancellationToken);
        }

        /// <summary> Lists the available namespaces within a resourceGroup. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NotificationHubNamespaceResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(null, null, cancellationToken);

        /// <summary> Lists the available namespaces within a resourceGroup. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NotificationHubNamespaceResource> GetAll(CancellationToken cancellationToken)
            => GetAll(null, null, cancellationToken);

        private static NotificationHubNamespaceData ContentToData(NotificationHubNamespaceCreateOrUpdateContent content)
        {
            // Build NamespaceProperties via internal constructor to set output-only read-only properties
            var props = new NotificationHubNamespaceProperties(
                content.NamespaceName,
                string.IsNullOrEmpty(content.ProvisioningState) ? null : new OperationProvisioningState(content.ProvisioningState),
                string.IsNullOrEmpty(content.Status) ? null : new NotificationHubNamespaceStatus(content.Status),
                content.IsEnabled,
                content.IsCritical,
                content.SubscriptionId,
                content.Region,
                null, // metricId
                content.CreatedOn,
                content.UpdatedOn,
                content.NamespaceType.HasValue ? new NotificationHubNamespaceTypeExt(content.NamespaceType.Value.ToString()) : null,
                null, // replicationRegion
                null, // zoneRedundancy
                null, // networkAcls
                null, // pnsCredentials
                content.ServiceBusEndpoint,
                null, // privateEndpointConnections
                content.ScaleUnit,
                content.DataCenter,
                null, // publicNetworkAccess
                null  // additionalBinaryDataProperties
            );

            var tags = new Dictionary<string, string>();
            if (content.Tags != null)
            {
                foreach (var tag in content.Tags)
                    tags[tag.Key] = tag.Value;
            }

            return new NotificationHubNamespaceData(
                null, null, default, null, null,
                tags,
                content.Location,
                props,
                content.Sku
            );
        }
    }
}
