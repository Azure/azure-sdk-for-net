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
    // Backward-compat: baseline had Update overloads accepting SharedAccessAuthorizationRuleCreateOrUpdateContent.
    public partial class NotificationHubNamespaceAuthorizationRuleResource
    {
        /// <summary> Creates an authorization rule for a namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="content"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationHubNamespaceAuthorizationRuleResource>> UpdateAsync(WaitUntil waitUntil, SharedAccessAuthorizationRuleCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This method is obsolete and not supported.");
        }

        /// <summary> Creates an authorization rule for a namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="content"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationHubNamespaceAuthorizationRuleResource> Update(WaitUntil waitUntil, SharedAccessAuthorizationRuleCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This method is obsolete and not supported.");
        }
    }
}
