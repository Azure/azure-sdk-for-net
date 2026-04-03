// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ServiceFabric.Mocking;

namespace Azure.ResourceManager.ServiceFabric
{
    // Generator bug: missing GetMockableServiceFabricArmClient helper method
    public static partial class ServiceFabricExtensions
    {
        private static MockableServiceFabricArmClient GetMockableServiceFabricArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockableServiceFabricArmClient(client0, ResourceIdentifier.Root));
        }
    }
}
