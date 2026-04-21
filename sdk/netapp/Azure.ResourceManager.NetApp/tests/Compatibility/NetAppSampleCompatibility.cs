// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

global using ElasticCapacityPoolChangeZoneContent = Azure.ResourceManager.NetApp.Models.ChangeZoneContent;
global using ElasticResourceAvailabilityResult = Azure.ResourceManager.NetApp.Models.CheckElasticResourceAvailabilityResult;
global using ElasticVolumeFilePathAvailabilityContent = Azure.ResourceManager.NetApp.Models.CheckElasticVolumeFilePathAvailabilityContent;
global using NetAppActiveDirectoryConfigCollection = Azure.ResourceManager.NetApp.ActiveDirectoryConfigCollection;
global using NetAppActiveDirectoryConfigData = Azure.ResourceManager.NetApp.ActiveDirectoryConfigData;
global using NetAppActiveDirectoryConfigPatch = Azure.ResourceManager.NetApp.Models.ActiveDirectoryConfigPatch;
global using NetAppActiveDirectoryConfigPatchProperties = Azure.ResourceManager.NetApp.Models.ActiveDirectoryConfigUpdateProperties;
global using NetAppActiveDirectoryConfigProperties = Azure.ResourceManager.NetApp.Models.ActiveDirectoryConfigProperties;
global using NetAppActiveDirectoryConfigResource = Azure.ResourceManager.NetApp.ActiveDirectoryConfigResource;
global using NetAppBackupVaultBackupData = Azure.ResourceManager.NetApp.NetAppBackupData;
global using NetAppDayOfWeek = Azure.ResourceManager.NetApp.Models.DayOfWeek;
global using NetAppElasticAccountCollection = Azure.ResourceManager.NetApp.ElasticAccountCollection;
global using NetAppElasticAccountData = Azure.ResourceManager.NetApp.ElasticAccountData;
global using NetAppElasticAccountPatch = Azure.ResourceManager.NetApp.Models.ElasticAccountPatch;
global using NetAppElasticAccountProperties = Azure.ResourceManager.NetApp.Models.ElasticAccountProperties;
global using NetAppElasticAccountResource = Azure.ResourceManager.NetApp.ElasticAccountResource;
global using NetAppElasticBackupCollection = Azure.ResourceManager.NetApp.ElasticBackupCollection;
global using NetAppElasticBackupData = Azure.ResourceManager.NetApp.ElasticBackupData;
global using NetAppElasticBackupPatch = Azure.ResourceManager.NetApp.ElasticBackupData;
global using NetAppElasticBackupPolicyCollection = Azure.ResourceManager.NetApp.ElasticBackupPolicyCollection;
global using NetAppElasticBackupPolicyData = Azure.ResourceManager.NetApp.ElasticBackupPolicyData;
global using NetAppElasticBackupPolicyPatch = Azure.ResourceManager.NetApp.Models.ElasticBackupPolicyPatch;
global using NetAppElasticBackupPolicyPatchProperties = Azure.ResourceManager.NetApp.Models.ElasticBackupPolicyUpdateProperties;
global using NetAppElasticBackupPolicyProperties = Azure.ResourceManager.NetApp.Models.ElasticBackupPolicyProperties;
global using NetAppElasticBackupPolicyResource = Azure.ResourceManager.NetApp.ElasticBackupPolicyResource;
global using NetAppElasticBackupProperties = Azure.ResourceManager.NetApp.Models.ElasticBackupProperties;
global using NetAppElasticBackupResource = Azure.ResourceManager.NetApp.ElasticBackupResource;
global using NetAppElasticBackupVaultCollection = Azure.ResourceManager.NetApp.ElasticBackupVaultCollection;
global using NetAppElasticBackupVaultData = Azure.ResourceManager.NetApp.ElasticBackupVaultData;
global using NetAppElasticBackupVaultPatch = Azure.ResourceManager.NetApp.Models.ElasticBackupVaultPatch;
global using NetAppElasticBackupVaultResource = Azure.ResourceManager.NetApp.ElasticBackupVaultResource;
global using NetAppElasticCapacityPoolCollection = Azure.ResourceManager.NetApp.ElasticCapacityPoolCollection;
global using NetAppElasticCapacityPoolData = Azure.ResourceManager.NetApp.ElasticCapacityPoolData;
global using NetAppElasticCapacityPoolPatch = Azure.ResourceManager.NetApp.Models.ElasticCapacityPoolPatch;
global using NetAppElasticCapacityPoolPatchProperties = Azure.ResourceManager.NetApp.Models.ElasticCapacityPoolUpdateProperties;
global using NetAppElasticCapacityPoolProperties = Azure.ResourceManager.NetApp.Models.ElasticCapacityPoolProperties;
global using NetAppElasticCapacityPoolResource = Azure.ResourceManager.NetApp.ElasticCapacityPoolResource;
global using NetAppElasticProtocolType = Azure.ResourceManager.NetApp.Models.ElasticProtocolType;
global using NetAppElasticSnapshotCollection = Azure.ResourceManager.NetApp.ElasticSnapshotCollection;
global using NetAppElasticSnapshotData = Azure.ResourceManager.NetApp.ElasticSnapshotData;
global using NetAppElasticSnapshotPolicyCollection = Azure.ResourceManager.NetApp.ElasticSnapshotPolicyCollection;
global using NetAppElasticSnapshotPolicyData = Azure.ResourceManager.NetApp.ElasticSnapshotPolicyData;
global using NetAppElasticSnapshotPolicyPatch = Azure.ResourceManager.NetApp.Models.ElasticSnapshotPolicyPatch;
global using NetAppElasticSnapshotPolicyPatchProperties = Azure.ResourceManager.NetApp.Models.ElasticSnapshotPolicyUpdateProperties;
global using NetAppElasticSnapshotPolicyProperties = Azure.ResourceManager.NetApp.Models.ElasticSnapshotPolicyProperties;
global using NetAppElasticSnapshotPolicyResource = Azure.ResourceManager.NetApp.ElasticSnapshotPolicyResource;
global using NetAppElasticSnapshotResource = Azure.ResourceManager.NetApp.ElasticSnapshotResource;
global using NetAppElasticVolumeCollection = Azure.ResourceManager.NetApp.ElasticVolumeCollection;
global using NetAppElasticVolumeData = Azure.ResourceManager.NetApp.ElasticVolumeData;
global using NetAppElasticVolumePatch = Azure.ResourceManager.NetApp.Models.ElasticVolumePatch;
global using NetAppElasticVolumePatchProperties = Azure.ResourceManager.NetApp.Models.ElasticVolumeUpdateProperties;
global using NetAppElasticVolumeProperties = Azure.ResourceManager.NetApp.Models.ElasticVolumeProperties;
global using NetAppElasticVolumeResource = Azure.ResourceManager.NetApp.ElasticVolumeResource;
global using NetAppLdapConfiguration = Azure.ResourceManager.NetApp.Models.LdapConfiguration;
global using NetAppPolicyStatus = Azure.ResourceManager.NetApp.Models.PolicyStatus;
global using NetAppSecretPassword = Azure.ResourceManager.NetApp.Models.SecretPassword;
global using NetAppSecretPasswordIdentity = Azure.ResourceManager.NetApp.Models.SecretPasswordIdentity;
global using NetAppSecretPasswordKeyVaultProperties = Azure.ResourceManager.NetApp.Models.SecretPasswordKeyVaultProperties;
global using NetAppSnapshotUsage = Azure.ResourceManager.NetApp.Models.SnapshotUsage;
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
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp
{
    internal static class NetAppSampleCompatibility
    {
        public static void Add(this ICollection<IPAddress> addresses, string address)
            => addresses.Add(IPAddress.Parse(address));

        public static ActiveDirectoryConfigCollection GetNetAppActiveDirectoryConfigs(this ResourceGroupResource resourceGroupResource)
            => resourceGroupResource.GetActiveDirectoryConfigs();

        public static Pageable<ActiveDirectoryConfigResource> GetNetAppActiveDirectoryConfigs(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => subscriptionResource.GetActiveDirectoryConfigs(cancellationToken);

        public static AsyncPageable<ActiveDirectoryConfigResource> GetNetAppActiveDirectoryConfigsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => subscriptionResource.GetActiveDirectoryConfigsAsync(cancellationToken);

        public static ActiveDirectoryConfigResource GetNetAppActiveDirectoryConfigResource(this ArmClient client, ResourceIdentifier id)
            => client.GetActiveDirectoryConfigResource(id);

        public static ElasticAccountCollection GetNetAppElasticAccounts(this ResourceGroupResource resourceGroupResource)
            => resourceGroupResource.GetElasticAccounts();

        public static Pageable<ElasticAccountResource> GetNetAppElasticAccounts(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => subscriptionResource.GetElasticAccounts(cancellationToken);

        public static AsyncPageable<ElasticAccountResource> GetNetAppElasticAccountsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => subscriptionResource.GetElasticAccountsAsync(cancellationToken);

        public static ElasticAccountResource GetNetAppElasticAccountResource(this ArmClient client, ResourceIdentifier id)
            => client.GetElasticAccountResource(id);

        public static ElasticCapacityPoolCollection GetNetAppElasticCapacityPools(this ElasticAccountResource resource)
            => resource.GetElasticCapacityPools();

        public static ElasticCapacityPoolResource GetNetAppElasticCapacityPoolResource(this ArmClient client, ResourceIdentifier id)
            => client.GetElasticCapacityPoolResource(id);

        public static ElasticVolumeCollection GetNetAppElasticVolumes(this ElasticCapacityPoolResource resource)
            => resource.GetElasticVolumes();

        public static Task<Response<CheckElasticResourceAvailabilityResult>> CheckElasticVolumeFilePathAvailabilityAsync(this ElasticCapacityPoolResource resource, CheckElasticVolumeFilePathAvailabilityContent content, CancellationToken cancellationToken = default)
            => resource.CheckVolumeFilePathAvailabilityAsync(content, cancellationToken);

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

        public static Pageable<ElasticVolumeResource> GetNetAppElasticVolumes(this ElasticSnapshotPolicyResource resource, CancellationToken cancellationToken = default)
            => resource.GetElasticVolumes(cancellationToken);

        public static ElasticVolumeResource GetNetAppElasticVolumeResource(this ArmClient client, ResourceIdentifier id)
            => client.GetElasticVolumeResource(id);

        public static ElasticSnapshotCollection GetNetAppElasticSnapshots(this ElasticVolumeResource resource)
            => resource.GetElasticSnapshots();

        public static ElasticSnapshotResource GetNetAppElasticSnapshotResource(this ArmClient client, ResourceIdentifier id)
            => client.GetElasticSnapshotResource(id);

        public static ElasticSnapshotPolicyCollection GetNetAppElasticSnapshotPolicies(this ElasticAccountResource resource)
            => resource.GetElasticSnapshotPolicies();

        public static ElasticSnapshotPolicyResource GetNetAppElasticSnapshotPolicyResource(this ArmClient client, ResourceIdentifier id)
            => client.GetElasticSnapshotPolicyResource(id);

        public static ElasticBackupVaultCollection GetNetAppElasticBackupVaults(this ElasticAccountResource resource)
            => resource.GetElasticBackupVaults();

        public static ElasticBackupVaultResource GetNetAppElasticBackupVaultResource(this ArmClient client, ResourceIdentifier id)
            => client.GetElasticBackupVaultResource(id);

        public static ElasticBackupCollection GetNetAppElasticBackups(this ElasticBackupVaultResource resource)
            => resource.GetElasticBackups();

        public static ElasticBackupResource GetNetAppElasticBackupResource(this ArmClient client, ResourceIdentifier id)
            => client.GetElasticBackupResource(id);

        public static ElasticBackupPolicyCollection GetNetAppElasticBackupPolicies(this ElasticAccountResource resource)
            => resource.GetElasticBackupPolicies();

        public static ElasticBackupPolicyResource GetNetAppElasticBackupPolicyResource(this ArmClient client, ResourceIdentifier id)
            => client.GetElasticBackupPolicyResource(id);
    }
}
