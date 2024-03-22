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

        /// <summary>
        /// Patch a NotificationHub in a namespace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NotificationHubResource>> UpdateAsync(NotificationHubPatch patch, CancellationToken cancellationToken = default)
            => await UpdateAsync(
                new NotificationHubUpdateContent (
                patch.Sku,
                patch.Tags,
                patch.NotificationHubName,
                patch.RegistrationTtl,
                patch.AuthorizationRules,
                patch.ApnsCredential,
                patch.WnsCredential,
                patch.GcmCredential,
                patch.MpnsCredential,
                patch.AdmCredential,
                patch.BaiduCredential,
                null, null, null, null, null),
                cancellationToken
            ).ConfigureAwait(false);

        /// <summary>
        /// Patch a NotificationHub in a namespace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NotificationHubResource> Update(NotificationHubPatch patch, CancellationToken cancellationToken = default)
            => Update(
                new NotificationHubUpdateContent (
                patch.Sku,
                patch.Tags,
                patch.NotificationHubName,
                patch.RegistrationTtl,
                patch.AuthorizationRules,
                patch.ApnsCredential,
                patch.WnsCredential,
                patch.GcmCredential,
                patch.MpnsCredential,
                patch.AdmCredential,
                patch.BaiduCredential,
                null, null, null, null, null),
                cancellationToken
            );

        /// <summary>
        /// Patch a NotificationHub in a namespace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<NotificationHubResource>> UpdateAsync(NotificationHubUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _notificationHubClientDiagnostics.CreateScope("NotificationHubResource.Update");
            scope.Start();
            try
            {
                var response = await _notificationHubRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new NotificationHubResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Patch a NotificationHub in a namespace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<NotificationHubResource> Update(NotificationHubUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _notificationHubClientDiagnostics.CreateScope("NotificationHubResource.Update");
            scope.Start();
            try
            {
                var response = _notificationHubRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, cancellationToken);
                return Response.FromValue(new NotificationHubResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
