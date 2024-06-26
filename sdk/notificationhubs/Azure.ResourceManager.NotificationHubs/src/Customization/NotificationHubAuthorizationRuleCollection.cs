// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    /// <summary>
    /// A class representing a collection of <see cref="NotificationHubAuthorizationRuleResource"/> and their operations.
    /// Each <see cref="NotificationHubAuthorizationRuleResource"/> in the collection will belong to the same instance of <see cref="NotificationHubResource"/>.
    /// To get a <see cref="NotificationHubAuthorizationRuleCollection"/> instance call the GetNotificationHubAuthorizationRules method from an instance of <see cref="NotificationHubResource"/>.
    /// </summary>
    public partial class NotificationHubAuthorizationRuleCollection : ArmCollection, IEnumerable<NotificationHubAuthorizationRuleResource>, IAsyncEnumerable<NotificationHubAuthorizationRuleResource>
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
        /// <param name="authorizationRuleName"> Authorization Rule Name. </param>
        /// <param name="content"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationHubAuthorizationRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string authorizationRuleName, SharedAccessAuthorizationRuleCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            Response<NotificationHubAuthorizationRuleResource> resource = await GetAsync(authorizationRuleName, cancellationToken).ConfigureAwait(false);
            NotificationHubAuthorizationRuleData param = new NotificationHubAuthorizationRuleData(
                resource.Value.Data.Id,
                resource.Value.Data.Name,
                resource.Value.Data.ResourceType,
                resource.Value.Data.SystemData,
                resource.Value.Data.Tags,
                resource.Value.Data.Location,
                content.Properties.AccessRights,
                content.Properties.PrimaryKey,
                content.Properties.SecondaryKey,
                content.Properties.KeyName,
                content.Properties.ModifiedOn,
                content.Properties.CreatedOn,
                content.Properties.ClaimType,
                content.Properties.ClaimValue,
                content.Properties.Revision,
                null);
            return await CreateOrUpdateAsync(waitUntil, authorizationRuleName, param, cancellationToken).ConfigureAwait(false);
        }

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
        /// <param name="authorizationRuleName"> Authorization Rule Name. </param>
        /// <param name="content"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationHubAuthorizationRuleResource> CreateOrUpdate(WaitUntil waitUntil, string authorizationRuleName, SharedAccessAuthorizationRuleCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            Response<NotificationHubAuthorizationRuleResource> resource = Get(authorizationRuleName, cancellationToken);
            NotificationHubAuthorizationRuleData param = new NotificationHubAuthorizationRuleData(
                resource.Value.Data.Id,
                resource.Value.Data.Name,
                resource.Value.Data.ResourceType,
                resource.Value.Data.SystemData,
                resource.Value.Data.Tags,
                resource.Value.Data.Location,
                content.Properties.AccessRights,
                content.Properties.PrimaryKey,
                content.Properties.SecondaryKey,
                content.Properties.KeyName,
                content.Properties.ModifiedOn,
                content.Properties.CreatedOn,
                content.Properties.ClaimType,
                content.Properties.ClaimValue,
                content.Properties.Revision,
                null);
            return CreateOrUpdate(waitUntil, authorizationRuleName, param, cancellationToken);
        }
    }
}
