﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Migrate.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using RegionMove.Tests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Migrate.RegionMove.Tests
{
    public class RegionMoveTests : RegionMoveTestsBase
    {
        private const string MoveCollectionResourceGroup = "moveCollectionRg";
        private const string MoveCollectionRegion = "eastus2";
        private const string SourceRegion = "eastus";
        private const string TargetRegion = "westus2";
        private const string MoveCollectionName = "RegionMove-eastus-westus2";
        private const string SourceResourceGroup = "NETSdkEastUS";
        private const string TargetResourceGroup = "NETSdkWestUS2";
        private const string VirtualMachineId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Compute/virtualMachines/vm1";
        private const string AvailabilitySetId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Compute/availabilitySets/AvailabilitySet1";
        private const string NetworkInterfaceId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Network/networkInterfaces/vm1364";
        private const string VirtualNetworkId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Network/virtualNetworks/vnet1";
        private const string NetworkSecurityGroupId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Network/networkSecurityGroups/vm1-nsg";
        private const string PublicIpId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Network/publicIPAddresses/vm1-publicIp";
        private const string LoadBalancerId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Network/loadBalancers/LoadBalancer1";
        private const string ResourceGroupId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS";
        private const string VmMoveResourceName = "2784cefb-8202-42ee-ba82-bbbb499885c5";

        private const string OperationStatusSucceeded = "Succeeded";
        private const string OperationStatusFailed = "Failed";

        private TestHelper TestHelper { get; set; }

        public RegionMoveTests()
        {
            this.TestHelper = new TestHelper();
        }

        [Fact]
        public async Task CreateMoveCollectionAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var moveCollectionProperties = new MoveCollectionProperties()
                {
                    SourceRegion = SourceRegion,
                    TargetRegion = TargetRegion
                };

                var moveCollectionInput = new MoveCollection(
                    location: MoveCollectionRegion,
                    properties: moveCollectionProperties);

                var moveCollection =
                    (await client.MoveCollections.CreateWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        moveCollectionInput)).Body;
                Assert.True(
                    moveCollection.Name == MoveCollectionName,
                    "Resource name can not be different.");
            }
        }

        [Fact]
        public async Task UpdateMoveCollectionAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var updateMoveCollectionRequest = new UpdateMoveCollectionRequest()
                {
                    Tags = new Dictionary<string, string>()
                    {
                        { "Key1", "Value1 " }
                    }
                };

                var moveCollection =
                    (await client.MoveCollections.UpdateWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        updateMoveCollectionRequest)).Body;
                Assert.True(
                    moveCollection.Tags.Keys.Count == 1,
                    "Move collection should contain the updated tag.");
            }
        }

        [Fact]
        public async Task GetMoveCollectionAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var moveCollection =
                    (await client.MoveCollections.GetWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName)).Body;
                Assert.True(
                    moveCollection.Name == MoveCollectionName,
                    "Resource name can not be different.");
            }
        }

        [Fact]
        public async Task DeleteMoveCollectionAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var operationStatus =
                    (await client.MoveCollections.DeleteWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName)).Body;
                Assert.True(operationStatus == null ||
                    OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Delete move collection operation should have succeeded when there are no resources in " +
                    "move collection.");
            }
        }

        [Fact]
        public async Task CreateOrUpdateMoveResourceAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var vmTargetResourceSettings =
                    new VirtualMachineResourceSettings()
                    {
                        TargetResourceName = "targetVm1",
                        TargetAvailabilityZone = "1"
                    };

                // VM redundancy can be set to either availability set or availaiblity zone.
                // We are moving the VM from availability set to availability zone, so overriding the
                // availability set dependency of VM to null.
                var vmDependencyOverrideList = new List<MoveResourceDependencyOverride>()
                {
                    new MoveResourceDependencyOverride()
                    {
                        Id = AvailabilitySetId,
                        TargetId = null
                    }
                };
                var vmMoveResourceProperties = new MoveResourceProperties()
                {
                    SourceId = VirtualMachineId,
                    ResourceSettings = vmTargetResourceSettings,
                    DependsOnOverrides = vmDependencyOverrideList
                };

                var moveResource =
                    (await client.MoveResources.CreateWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        VmMoveResourceName,
                        vmMoveResourceProperties)).Body;

                Assert.True(
                    moveResource.Name == VmMoveResourceName,
                    "Resource name can not be different.");
            }
        }

        [Fact]
        public async Task GetMoveResourceAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var moveResource =
                    (await client.MoveResources.GetWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        VmMoveResourceName)).Body;

                Assert.True(
                    moveResource.Name == VmMoveResourceName,
                    "Resource name can not be different.");
            }
        }

        [Fact]
        public async Task DeleteMoveResourceAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var operationStatus =
                    (await client.MoveResources.DeleteWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        VmMoveResourceName)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Delete move resource operation should have succeeded.");
            }
        }

        [Fact]
        public async Task ListMoveResourcesInMoveCollectionAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var moveResourceList = new List<MoveResource>();
                var moveResources =
                    (await client.MoveResources.ListWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName)).Body;

                moveResourceList.AddRange(moveResources);

                while (!string.IsNullOrEmpty(moveResources.NextPageLink))
                {
                    moveResources =
                    (await client.MoveResources.ListNextWithHttpMessagesAsync(
                        moveResources.NextPageLink)).Body;

                    moveResourceList.AddRange(moveResources);
                }

                Assert.True(
                    moveResourceList.Count > 0,
                    "Move Resource count should not be null with resources in move collection.");
            }
        }

        [Fact]
        public async Task GetUnresolvedDependenciesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = TestHelper.RegionMoveServiceClient;

                var unresolvedDependencies =
                    (await client.UnresolvedDependencies.GetWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName)).Body;

                Assert.NotNull(unresolvedDependencies.Value);
            }
        }

        [Fact]
        public async Task ResolveDependenciesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var operationStatus =
                    (await client.MoveCollections.ResolveDependenciesWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Move Collection Resolve operation should have succeeded.");
            }
        }

        [Fact]
        public async Task ValidatePrepareForMoveResourcesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var prepareRequest = new PrepareRequest()
                {
                    MoveResources = new List<string>()
                    {
                        VirtualMachineId,
                        NetworkInterfaceId,
                        VirtualNetworkId,
                        PublicIpId,
                        NetworkSecurityGroupId,
                        LoadBalancerId
                    },
                    ValidateOnly = true,
                    MoveResourceInputType = MoveResourceInputType.MoveResourceSourceId
                };

                var operationStatus =
                    (await client.MoveCollections.PrepareWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        prepareRequest)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Validate Prepare operation should have succeeded");
            }
        }

        [Fact]
        public async Task InitiatePrepareForMoveResourcesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var prepareRequest = new PrepareRequest()
                {
                    MoveResources = new List<string>()
                    {
                        VirtualMachineId,
                        NetworkInterfaceId,
                        PublicIpId,
                        LoadBalancerId,
                        VirtualNetworkId,
                        NetworkSecurityGroupId
                    },
                    MoveResourceInputType = MoveResourceInputType.MoveResourceSourceId
                };

                var operationStatus =
                    (await client.MoveCollections.PrepareWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        prepareRequest)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Prepare operation should have succeeded.");
            }
        }

        [Fact]
        public async Task ValidateInitiateMoveForMoveResourcesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var moveRequest = new ResourceMoveRequest()
                {
                    MoveResources = new List<string>()
                    {
                        VirtualMachineId,
                        NetworkInterfaceId,
                        PublicIpId,
                        LoadBalancerId,
                        VirtualNetworkId,
                        NetworkSecurityGroupId
                    },
                    ValidateOnly = true,
                    MoveResourceInputType = MoveResourceInputType.MoveResourceSourceId
                };

                var operationStatus =
                    (await client.MoveCollections.InitiateMoveWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        moveRequest)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Validate Move operation should have succeeded.");
            }
        }

        [Fact]
        public async Task InitiateMoveForMoveResourcesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var moveRequest = new ResourceMoveRequest()
                {
                    MoveResources = new List<string>()
                    {
                        VirtualMachineId,
                        NetworkInterfaceId,
                        PublicIpId,
                        LoadBalancerId,
                        VirtualNetworkId,
                        NetworkSecurityGroupId
                    },
                    MoveResourceInputType = MoveResourceInputType.MoveResourceSourceId
                };

                var operationStatus =
                    (await client.MoveCollections.InitiateMoveWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        moveRequest)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Move operation for resources should have succeeded.");
            }
        }

        [Fact]
        public async Task ValidateDiscardForMoveResourcesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var discardRequest = new DiscardRequest()
                {
                    MoveResources = new List<string>()
                    {
                        VirtualMachineId,
                        NetworkInterfaceId,
                        PublicIpId,
                        LoadBalancerId,
                        VirtualNetworkId,
                        NetworkSecurityGroupId
                    },
                    ValidateOnly = true,
                    MoveResourceInputType = MoveResourceInputType.MoveResourceSourceId
                };

                var operationStatus =
                    (await client.MoveCollections.DiscardWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        discardRequest)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Validate Discard operation should have succeeded.");
            }
        }

        [Fact]
        public async Task InitiateDiscardForMoveResourcesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var discardRequest = new DiscardRequest()
                {
                    MoveResources = new List<string>()
                    {
                        VirtualMachineId,
                        NetworkInterfaceId,
                        PublicIpId,
                        LoadBalancerId,
                        VirtualNetworkId,
                        NetworkSecurityGroupId
                    },
                    MoveResourceInputType = MoveResourceInputType.MoveResourceSourceId
                };

                var operationStatus =
                    (await client.MoveCollections.DiscardWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        discardRequest)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Disacrd operation should have succeeded.");
            }
        }

        [Fact]
        public async Task ValidateCommitForMoveResourcesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var commitRequest = new CommitRequest()
                {
                    MoveResources = new List<string>()
                    {
                        VirtualMachineId,
                        NetworkInterfaceId,
                        PublicIpId,
                        LoadBalancerId,
                        VirtualNetworkId,
                        NetworkSecurityGroupId,
                        ResourceGroupId
                    },
                    ValidateOnly = true,
                    MoveResourceInputType = MoveResourceInputType.MoveResourceSourceId
                };

                var operationStatus =
                    (await client.MoveCollections.CommitWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        commitRequest)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Validate Commit operation should have succeeded.");
            }
        }

        [Fact]
        public async Task InitiateCommitForMoveResourcesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.RegionMoveServiceClient;

                var commitRequest = new CommitRequest()
                {
                    MoveResources = new List<string>()
                    {
                        VirtualMachineId,
                        NetworkInterfaceId,
                        PublicIpId,
                        LoadBalancerId,
                        VirtualNetworkId,
                        NetworkSecurityGroupId,
                        ResourceGroupId
                    },
                    MoveResourceInputType = MoveResourceInputType.MoveResourceSourceId
                };

                var operationStatus =
                    (await client.MoveCollections.CommitWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        commitRequest)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Commit operation should have succeeded.");
            }
        }
    }
}
