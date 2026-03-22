// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    // Backward-compat: baseline had Update overloads accepting SharedAccessAuthorizationRuleCreateOrUpdateContent.
    // Preserves old behavior: uses existing Data metadata (Id, Name, Tags, Location) and merges with content.Properties.
    public partial class NotificationHubAuthorizationRuleResource
    {
        /// <summary> Creates/Updates an authorization rule for a NotificationHub. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="content"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationHubAuthorizationRuleResource>> UpdateAsync(WaitUntil waitUntil, SharedAccessAuthorizationRuleCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            var data = new NotificationHubAuthorizationRuleData(
                Data.Id,
                Data.Name,
                Data.ResourceType,
                Data.SystemData,
                null,
                Data.Location,
                content.Properties,
                Data.Tags);
            return await UpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Creates/Updates an authorization rule for a NotificationHub. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="content"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationHubAuthorizationRuleResource> Update(WaitUntil waitUntil, SharedAccessAuthorizationRuleCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            var data = new NotificationHubAuthorizationRuleData(
                Data.Id,
                Data.Name,
                Data.ResourceType,
                Data.SystemData,
                null,
                Data.Location,
                content.Properties,
                Data.Tags);
            return Update(waitUntil, data, cancellationToken);
        }
    }
}
