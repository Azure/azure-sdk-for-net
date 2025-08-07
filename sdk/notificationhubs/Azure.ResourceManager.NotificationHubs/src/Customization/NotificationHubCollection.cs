// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    /// <summary>
    /// A class representing a collection of <see cref="NotificationHubResource"/> and their operations.
    /// Each <see cref="NotificationHubResource"/> in the collection will belong to the same instance of <see cref="NotificationHubNamespaceResource"/>.
    /// To get a <see cref="NotificationHubCollection"/> instance call the GetNotificationHubs method from an instance of <see cref="NotificationHubNamespaceResource"/>.
    /// </summary>
    public partial class NotificationHubCollection : ArmCollection, IEnumerable<NotificationHubResource>, IAsyncEnumerable<NotificationHubResource>
    {
        /// <summary>
        /// Creates/Update a NotificationHub in a namespace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_CreateOrUpdate</description>
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
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="notificationHubName"> The notification hub name. </param>
        /// <param name="content"> Parameters supplied to the create/update a NotificationHub Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="notificationHubName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="notificationHubName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationHubResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string notificationHubName, NotificationHubCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            Response<NotificationHubResource> resource = await GetAsync(notificationHubName, cancellationToken).ConfigureAwait(false);
            NotificationHubData param = new NotificationHubData(
                resource.Value.Data.Id,
                resource.Value.Data.Name,
                resource.Value.Data.ResourceType,
                resource.Value.Data.SystemData,
                resource.Value.Data.Tags,
                resource.Value.Data.Location,
                content.Sku,
                content.NotificationHubName,
                content.RegistrationTtl,
                new List<SharedAccessAuthorizationRuleProperties>(content.AuthorizationRules),
                content.ApnsCredential,
                content.WnsCredential,
                content.GcmCredential,
                content.MpnsCredential,
                content.AdmCredential,
                content.BaiduCredential,
                null,
                null,
                null,
                null,
                null
            );
            return await CreateOrUpdateAsync(waitUntil, notificationHubName, param, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates/Update a NotificationHub in a namespace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_CreateOrUpdate</description>
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
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="notificationHubName"> The notification hub name. </param>
        /// <param name="content"> Parameters supplied to the create/update a NotificationHub Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="notificationHubName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="notificationHubName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationHubResource> CreateOrUpdate(WaitUntil waitUntil, string notificationHubName, NotificationHubCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            Response<NotificationHubResource> resource = Get(notificationHubName, cancellationToken);
            NotificationHubData param = new NotificationHubData(
                resource.Value.Data.Id,
                resource.Value.Data.Name,
                resource.Value.Data.ResourceType,
                resource.Value.Data.SystemData,
                resource.Value.Data.Tags,
                resource.Value.Data.Location,
                content.Sku,
                content.NotificationHubName,
                content.RegistrationTtl,
                new List<SharedAccessAuthorizationRuleProperties>(content.AuthorizationRules),
                content.ApnsCredential,
                content.WnsCredential,
                content.GcmCredential,
                content.MpnsCredential,
                content.AdmCredential,
                content.BaiduCredential,
                null,
                null,
                null,
                null,
                null
            );
            return CreateOrUpdate(waitUntil, notificationHubName, param, cancellationToken);
        }

        /// <summary>
        /// Lists the notification hubs associated with a namespace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_List</description>
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NotificationHubResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NotificationHubResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(null, null, cancellationToken);

        /// <summary>
        /// Lists the notification hubs associated with a namespace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NotificationHubs_List</description>
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NotificationHubResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NotificationHubResource> GetAll(CancellationToken cancellationToken)
            => GetAll(null, null, cancellationToken);
    }
}
