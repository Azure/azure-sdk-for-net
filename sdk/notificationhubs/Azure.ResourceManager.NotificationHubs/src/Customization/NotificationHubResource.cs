// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    /// <summary>
    /// A Class representing a NotificationHub along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="NotificationHubResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetNotificationHubResource method.
    /// Otherwise you can get one from its parent resource <see cref="NotificationHubNamespaceResource"/> using the GetNotificationHub method.
    /// </summary>
    public partial class NotificationHubResource : ArmResource
    {
        /// <summary>
        /// test send a push notification
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}/debugsend</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_DebugSend</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="anyObject"> Debug send parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NotificationHubTestSendResult>> DebugSendAsync(BinaryData anyObject, CancellationToken cancellationToken)
            => await DebugSendAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// test send a push notification
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}/debugsend</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_DebugSend</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="anyObject"> Debug send parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NotificationHubTestSendResult> DebugSend(BinaryData anyObject, CancellationToken cancellationToken)
            => DebugSend(cancellationToken);
    }
}
