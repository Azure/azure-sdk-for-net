// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

global using NetAppActiveDirectoryConfigData = Azure.ResourceManager.NetApp.ActiveDirectoryConfigData;
global using NetAppActiveDirectoryConfigResource = Azure.ResourceManager.NetApp.ActiveDirectoryConfigResource;
global using NetAppBackupVaultBackupData = Azure.ResourceManager.NetApp.NetAppBackupData;
global using NetAppElasticAccountData = Azure.ResourceManager.NetApp.ElasticAccountData;
global using NetAppElasticAccountResource = Azure.ResourceManager.NetApp.ElasticAccountResource;
global using NetAppLdapConfiguration = Azure.ResourceManager.NetApp.Models.LdapConfiguration;
global using NetAppVolumeData = Azure.ResourceManager.NetApp.VolumeData;
global using ReplicationObject = Azure.ResourceManager.NetApp.Models.NetAppReplicationObject;
global using ReplicationStatus = Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp
{
    internal static class NetAppSampleCompatibility
    {
        public static void Add(this ICollection<IPAddress> addresses, string address)
            => addresses.Add(IPAddress.Parse(address));

        public static AsyncPageable<ActiveDirectoryConfigResource> GetNetAppActiveDirectoryConfigsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => subscriptionResource.GetActiveDirectoryConfigsAsync(cancellationToken);

        public static AsyncPageable<ElasticAccountResource> GetNetAppElasticAccountsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => subscriptionResource.GetElasticAccountsAsync(cancellationToken);

        public static Task<ArmOperation<VolumeResource>> CreateOrUpdateAsync(this VolumeCollection collection, WaitUntil waitUntil, string volumeName, NetAppVolumeData data, CancellationToken cancellationToken = default)
        {
            var translated = new VolumeData(data.Location, data.CreationToken, data.UsageThreshold, data.SubnetId)
            {
                ServiceLevel = data.ServiceLevel,
                VolumeType = data.VolumeType,
                DataProtection = data.DataProtection,
            };
            return collection.CreateOrUpdateAsync(waitUntil, volumeName, translated, cancellationToken);
        }
    }
}
