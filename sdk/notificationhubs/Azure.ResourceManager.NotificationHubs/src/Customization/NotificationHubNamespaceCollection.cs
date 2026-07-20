// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
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
        [Obsolete("This method is obsolete and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationHubNamespaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string namespaceName, NotificationHubNamespaceCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This method is obsolete and not supported.");
        }

        /// <summary> Creates/Updates a service namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="namespaceName"> The namespace name. </param>
        /// <param name="content"> Parameters supplied to create a Namespace Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationHubNamespaceResource> CreateOrUpdate(WaitUntil waitUntil, string namespaceName, NotificationHubNamespaceCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This method is obsolete and not supported.");
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
    }
}
