// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp
{
    public static partial class NetAppExtensions
    {
        public static NetAppElasticAccountResource GetNetAppElasticAccountResource(this ArmClient client, ResourceIdentifier id) => GetMockableNetAppArmClient(client).GetNetAppElasticAccountResource(id);
        public static NetAppElasticCapacityPoolResource GetNetAppElasticCapacityPoolResource(this ArmClient client, ResourceIdentifier id) => GetMockableNetAppArmClient(client).GetNetAppElasticCapacityPoolResource(id);
        public static NetAppElasticVolumeResource GetNetAppElasticVolumeResource(this ArmClient client, ResourceIdentifier id) => GetMockableNetAppArmClient(client).GetNetAppElasticVolumeResource(id);
        public static NetAppElasticSnapshotResource GetNetAppElasticSnapshotResource(this ArmClient client, ResourceIdentifier id) => GetMockableNetAppArmClient(client).GetNetAppElasticSnapshotResource(id);
        public static NetAppElasticSnapshotPolicyResource GetNetAppElasticSnapshotPolicyResource(this ArmClient client, ResourceIdentifier id) => GetMockableNetAppArmClient(client).GetNetAppElasticSnapshotPolicyResource(id);
        public static NetAppElasticBackupVaultResource GetNetAppElasticBackupVaultResource(this ArmClient client, ResourceIdentifier id) => GetMockableNetAppArmClient(client).GetNetAppElasticBackupVaultResource(id);
        public static NetAppElasticBackupPolicyResource GetNetAppElasticBackupPolicyResource(this ArmClient client, ResourceIdentifier id) => GetMockableNetAppArmClient(client).GetNetAppElasticBackupPolicyResource(id);
        public static NetAppElasticBackupResource GetNetAppElasticBackupResource(this ArmClient client, ResourceIdentifier id) => GetMockableNetAppArmClient(client).GetNetAppElasticBackupResource(id);
        public static NetAppElasticAccountCollection GetNetAppElasticAccounts(this ResourceGroupResource resourceGroupResource) => GetMockableNetAppResourceGroupResource(resourceGroupResource).GetNetAppElasticAccounts();
        [ForwardsClientCalls]
        public static Task<Response<NetAppElasticAccountResource>> GetNetAppElasticAccountAsync(this ResourceGroupResource resourceGroupResource, string accountName, CancellationToken cancellationToken = default) => GetMockableNetAppResourceGroupResource(resourceGroupResource).GetNetAppElasticAccountAsync(accountName, cancellationToken);
        [ForwardsClientCalls]
        public static Response<NetAppElasticAccountResource> GetNetAppElasticAccount(this ResourceGroupResource resourceGroupResource, string accountName, CancellationToken cancellationToken = default) => GetMockableNetAppResourceGroupResource(resourceGroupResource).GetNetAppElasticAccount(accountName, cancellationToken);
        public static AsyncPageable<NetAppElasticAccountResource> GetNetAppElasticAccountsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) => GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppElasticAccountsAsync(cancellationToken);
        public static Pageable<NetAppElasticAccountResource> GetNetAppElasticAccounts(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) => GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppElasticAccounts(cancellationToken);
    }
}

namespace Azure.ResourceManager.NetApp.Mocking
{
}
