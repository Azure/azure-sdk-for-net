// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.NetApp. </summary>
    public static partial class NetAppExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="NetAppAccountBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NetAppAccountBackupResource.CreateResourceIdentifier" /> to create a <see cref="NetAppAccountBackupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetAppAccountBackupResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppAccountBackupResource GetNetAppAccountBackupResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppAccountBackupResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NetAppVolumeBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NetAppVolumeBackupResource.CreateResourceIdentifier" /> to create a <see cref="NetAppVolumeBackupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetAppVolumeBackupResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]

        public static NetAppVolumeBackupResource GetNetAppVolumeBackupResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppVolumeBackupResource(id);
        }

        /// <summary>
        /// Get the default and current limits for quotas
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetApp/locations/{location}/quotaLimits</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NetAppResourceQuotaLimits_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-09-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableNetAppSubscriptionResource.GetNetAppQuotaLimits(AzureLocation,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="NetAppSubscriptionQuotaItem"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimitsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimitsAsync(location, cancellationToken);
        }

        /// <summary>
        /// Get the default and current limits for quotas
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetApp/locations/{location}/quotaLimits</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NetAppResourceQuotaLimits_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-09-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableNetAppSubscriptionResource.GetNetAppQuotaLimits(AzureLocation,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="NetAppSubscriptionQuotaItem"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimits(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimits(location, cancellationToken);
        }
    }
}
