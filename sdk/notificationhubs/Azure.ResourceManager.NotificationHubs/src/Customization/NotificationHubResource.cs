// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    // Backward-compat: baseline had DebugSend overloads accepting BinaryData parameter,
    // and Update overloads accepting NotificationHubUpdateContent.
    public partial class NotificationHubResource
    {
        /// <summary> Test send a push notification. </summary>
        /// <param name="anyObject"> Debug send parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NotificationHubTestSendResult>> DebugSendAsync(BinaryData anyObject, CancellationToken cancellationToken)
            => await DebugSendAsync(cancellationToken).ConfigureAwait(false);

        /// <summary> Test send a push notification. </summary>
        /// <param name="anyObject"> Debug send parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NotificationHubTestSendResult> DebugSend(BinaryData anyObject, CancellationToken cancellationToken)
            => DebugSend(cancellationToken);

        /// <summary> Patch a NotificationHub in a namespace. </summary>
        /// <param name="content"> Request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NotificationHubResource>> UpdateAsync(NotificationHubUpdateContent content, CancellationToken cancellationToken = default)
            => await UpdateAsync(ContentToPatch(content), cancellationToken).ConfigureAwait(false);

        /// <summary> Patch a NotificationHub in a namespace. </summary>
        /// <param name="content"> Request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NotificationHubResource> Update(NotificationHubUpdateContent content, CancellationToken cancellationToken = default)
            => Update(ContentToPatch(content), cancellationToken);

        private static NotificationHubPatch ContentToPatch(NotificationHubUpdateContent content)
        {
            Argument.AssertNotNull(content, nameof(content));
            var patch = new NotificationHubPatch(default)
            {
                Sku = content.Sku,
                NotificationHubName = content.NotificationHubName,
                RegistrationTtl = content.RegistrationTtl,
                ApnsCredential = content.ApnsCredential,
                WnsCredential = content.WnsCredential,
                GcmCredential = content.GcmCredential,
                MpnsCredential = content.MpnsCredential,
                AdmCredential = content.AdmCredential,
                BaiduCredential = content.BaiduCredential,
                BrowserCredential = content.BrowserCredential,
                XiaomiCredential = content.XiaomiCredential,
                FcmV1Credential = content.FcmV1Credential,
            };
            foreach (var tag in content.Tags)
            {
                patch.Tags[tag.Key] = tag.Value;
            }
            foreach (var rule in content.AuthorizationRules)
            {
                patch.AuthorizationRules.Add(rule);
            }
            return patch;
        }
    }
}
