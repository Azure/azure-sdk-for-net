// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    // ActiveDirectory configuration was removed from the generated 2026-04-01 surface.
    // These SDK-side compatibility shells preserve the previously shipped public API so
    // the package continues to satisfy ApiCompat and source callers.

    public static partial class NetAppExtensions
    {
        public static NetAppActiveDirectoryConfigResource GetNetAppActiveDirectoryConfigResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableNetAppArmClient(client).GetNetAppActiveDirectoryConfigResource(id);
        }

        public static NetAppActiveDirectoryConfigCollection GetNetAppActiveDirectoryConfigs(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetAppResourceGroupResource(resourceGroupResource).GetNetAppActiveDirectoryConfigs();
        }

        [ForwardsClientCalls]
        public static async Task<Response<NetAppActiveDirectoryConfigResource>> GetNetAppActiveDirectoryConfigAsync(this ResourceGroupResource resourceGroupResource, string activeDirectoryConfigName, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppResourceGroupResource(resourceGroupResource).GetNetAppActiveDirectoryConfigAsync(activeDirectoryConfigName, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        public static Response<NetAppActiveDirectoryConfigResource> GetNetAppActiveDirectoryConfig(this ResourceGroupResource resourceGroupResource, string activeDirectoryConfigName, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppResourceGroupResource(resourceGroupResource).GetNetAppActiveDirectoryConfig(activeDirectoryConfigName, cancellationToken);
        }

        public static AsyncPageable<NetAppActiveDirectoryConfigResource> GetNetAppActiveDirectoryConfigsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppActiveDirectoryConfigsAsync(cancellationToken);
        }

        public static Pageable<NetAppActiveDirectoryConfigResource> GetNetAppActiveDirectoryConfigs(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppActiveDirectoryConfigs(cancellationToken);
        }
    }
}

namespace Azure.ResourceManager.NetApp.Mocking
{
}
