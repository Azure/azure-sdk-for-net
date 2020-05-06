// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;

namespace Microsoft.Azure.Management.SqlVirtualMachine.Tests.Utilities
{
    public class MockClient : IDisposable
    {
        public SqlVirtualMachineManagementClient sqlClient { get; }
        public ResourceManagementClient resourceClient { get; }
        public ComputeManagementClient computeClient { get; }
        public StorageManagementClient storageClient { get; }
        public NetworkManagementClient networkClient { get; }
        public ResourceManager.ResourceManagementClient resourceManagerClient { get; }

        public MockClient(MockContext context)
        {
            sqlClient = context.GetServiceClient<SqlVirtualMachineManagementClient>();
            resourceClient = context.GetServiceClient<ResourceManagementClient>();
            computeClient = context.GetServiceClient<ComputeManagementClient>();
            networkClient = context.GetServiceClient<NetworkManagementClient>();
            storageClient = context.GetServiceClient<StorageManagementClient>();
            resourceManagerClient = context.GetServiceClient<ResourceManager.ResourceManagementClient>();
        }

        public void Dispose()
        {
            sqlClient.Dispose();
            resourceClient.Dispose();
            computeClient.Dispose();
            networkClient.Dispose();
            storageClient.Dispose();
            resourceManagerClient.Dispose();
        }
    }
}
