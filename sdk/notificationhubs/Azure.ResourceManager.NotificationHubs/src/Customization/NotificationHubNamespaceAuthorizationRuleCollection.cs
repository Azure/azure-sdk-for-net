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
    // Backward-compat: baseline had CreateOrUpdate overloads accepting SharedAccessAuthorizationRuleCreateOrUpdateContent.
    // Preserves old behavior: GET existing resource first to retain metadata (Tags, Location),
    // then merge with content.Properties before calling the new CreateOrUpdate.
    public partial class NotificationHubNamespaceAuthorizationRuleCollection
    {
        /// <summary> Creates an authorization rule for a namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="authorizationRuleName"> Authorization Rule Name. </param>
        /// <param name="content"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationHubNamespaceAuthorizationRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string authorizationRuleName, SharedAccessAuthorizationRuleCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            Response<NotificationHubNamespaceAuthorizationRuleResource> resource = await GetAsync(authorizationRuleName, cancellationToken).ConfigureAwait(false);
            var data = new NotificationHubAuthorizationRuleData(
                resource.Value.Data.Id,
                resource.Value.Data.Name,
                resource.Value.Data.ResourceType,
                resource.Value.Data.SystemData,
                null,
                resource.Value.Data.Location,
                content.Properties,
                resource.Value.Data.Tags);
            return await CreateOrUpdateAsync(waitUntil, authorizationRuleName, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Creates an authorization rule for a namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="authorizationRuleName"> Authorization Rule Name. </param>
        /// <param name="content"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationHubNamespaceAuthorizationRuleResource> CreateOrUpdate(WaitUntil waitUntil, string authorizationRuleName, SharedAccessAuthorizationRuleCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            Response<NotificationHubNamespaceAuthorizationRuleResource> resource = Get(authorizationRuleName, cancellationToken);
            var data = new NotificationHubAuthorizationRuleData(
                resource.Value.Data.Id,
                resource.Value.Data.Name,
                resource.Value.Data.ResourceType,
                resource.Value.Data.SystemData,
                null,
                resource.Value.Data.Location,
                content.Properties,
                resource.Value.Data.Tags);
            return CreateOrUpdate(waitUntil, authorizationRuleName, data, cancellationToken);
        }
    }
}
