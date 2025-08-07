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
    /// A Class representing a NotificationHubAuthorizationRule along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="NotificationHubAuthorizationRuleResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetNotificationHubAuthorizationRuleResource method.
    /// Otherwise you can get one from its parent resource <see cref="NotificationHubResource"/> using the GetNotificationHubAuthorizationRule method.
    /// </summary>
    public partial class NotificationHubAuthorizationRuleResource : ArmResource
    {
        /// <summary>
        /// Creates/Updates an authorization rule for a NotificationHub
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}/AuthorizationRules/{authorizationRuleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_CreateOrUpdateAuthorizationRule</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubAuthorizationRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationHubAuthorizationRuleResource>> UpdateAsync(WaitUntil waitUntil, SharedAccessAuthorizationRuleCreateOrUpdateContent content, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil,
                                 new NotificationHubAuthorizationRuleData(
                                        Data.Id,
                                        Data.Name,
                                        Data.ResourceType,
                                        Data.SystemData,
                                        Data.Tags,
                                        Data.Location,
                                        content.Properties.AccessRights,
                                        content.Properties.PrimaryKey,
                                        content.Properties.SecondaryKey,
                                        content.Properties.KeyName,
                                        content.Properties.ModifiedOn,
                                        content.Properties.CreatedOn,
                                        content.Properties.ClaimType,
                                        content.Properties.ClaimValue,
                                        content.Properties.Revision,
                                        null),
                                 cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates/Updates an authorization rule for a NotificationHub
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}/AuthorizationRules/{authorizationRuleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_CreateOrUpdateAuthorizationRule</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubAuthorizationRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationHubAuthorizationRuleResource> Update(WaitUntil waitUntil, SharedAccessAuthorizationRuleCreateOrUpdateContent content, CancellationToken cancellationToken)
            => Update(waitUntil,
                      new NotificationHubAuthorizationRuleData(
                            Data.Id,
                            Data.Name,
                            Data.ResourceType,
                            Data.SystemData,
                            Data.Tags,
                            Data.Location,
                            content.Properties.AccessRights,
                            content.Properties.PrimaryKey,
                            content.Properties.SecondaryKey,
                            content.Properties.KeyName,
                            content.Properties.ModifiedOn,
                            content.Properties.CreatedOn,
                            content.Properties.ClaimType,
                            content.Properties.ClaimValue,
                            content.Properties.Revision,
                            null),
                      cancellationToken);
    }
}
