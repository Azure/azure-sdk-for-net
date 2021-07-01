// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Migrate.ResourceMover.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Management.Migrate.ResourceMover.Tests
{
    public class ResourceMoverTests : ResourceMoverTestsBase
    {
        private const string MoveCollectionResourceGroup = "moveCollectionRg";
        private const string MoveCollectionRegion = "eastus2euap";
        private const string SourceRegion = "eastus";
        private const string TargetRegion = "westus2";
        private const string MoveCollectionName = "ResourceMover-eastus-westus2";
        private const string VirtualMachineId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Compute/virtualMachines/vm1";
        private const string AvailabilitySetId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Compute/availabilitySets/AvailabilitySet1";
        private const string NetworkInterfaceId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Network/networkInterfaces/vm1294";
        private const string VirtualNetworkId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Network/virtualNetworks/vnet1";
        private const string NetworkSecurityGroupId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Network/networkSecurityGroups/vm1nsg799";
        private const string PublicIpId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Network/publicIPAddresses/vm1-publicIp";
        private const string LoadBalancerId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS/providers/Microsoft.Network/loadBalancers/LoadBalancer1";
        private const string ResourceGroupId = "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/NETSdkEastUS";
        private const string VmMoveResourceName = "2784cefb-8202-42ee-ba82-bbbb499885c5";

        private const string OperationStatusSucceeded = "Succeeded";

        private const string SystemAssignedIdentityType = "SystemAssigned";
        private const string NoneIdentityType = "None";

        private const string DescendentDependencyLevel = "Descendant";

        private TestHelper TestHelper { get; set; }

        public ResourceMoverTests()
        {
            this.TestHelper = new TestHelper();
        }

        [Fact]
        public async Task CreateMoveCollectionAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.ResourceMoverServiceClient;

                var moveCollectionProperties = new MoveCollectionProperties()
                {
                    SourceRegion = SourceRegion,
                    TargetRegion = TargetRegion
                };

                var identity = new Identity()
                {
                    Type = SystemAssignedIdentityType
                };

                var moveCollectionInput = new MoveCollection()
                {
                    Location = MoveCollectionRegion,
                    Properties = moveCollectionProperties,
                    Identity = identity
                };

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
                var client = this.TestHelper.ResourceMoverServiceClient;

                var updateMoveCollectionRequest = new UpdateMoveCollectionRequest()
                {
                    Tags = new Dictionary<string, string>()
                    {
                        { "Key1", "Value1" }
                    },
                    Identity = new Identity()
                    {
                        Type = SystemAssignedIdentityType
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
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = this.TestHelper.ResourceMoverServiceClient;

                var vmTargetResourceSettings =
                    new VirtualMachineResourceSettings()
                    {
                        TargetResourceName = "targetVm1",
                        TargetAvailabilityZone = "1"
                    };

                // VM redundancy can be set to either availability set or availaiblity zone.
                // We are moving the VM from availability set to availability zone,
                // so overriding the availability set dependency of VM to null.
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
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = TestHelper.ResourceMoverServiceClient;
                var unresolvedDependencies = new List<UnresolvedDependency>();
                var response =
                    (await client.UnresolvedDependencies.GetWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        dependencyLevel: DescendentDependencyLevel)).Body;
                unresolvedDependencies.AddRange(response);
                while(!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response =
                        (await client.UnresolvedDependencies.GetNextWithHttpMessagesAsync(
                            response.NextPageLink)).Body;
                    unresolvedDependencies.AddRange(response);
                }

                var unresolvedDependencySourceIds = unresolvedDependencies.Select(
                    dependency => dependency.Id).ToList();

                Assert.Contains(
                    NetworkInterfaceId,
                    unresolvedDependencySourceIds,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Contains(
                    VirtualNetworkId,
                    unresolvedDependencySourceIds,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Contains(
                    LoadBalancerId,
                    unresolvedDependencySourceIds,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Contains(
                    ResourceGroupId,
                    unresolvedDependencySourceIds,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Contains(
                    NetworkSecurityGroupId,
                    unresolvedDependencySourceIds,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Contains(
                    PublicIpId,
                    unresolvedDependencySourceIds,
                    StringComparer.OrdinalIgnoreCase);
            }
        }

        [Fact]
        public async Task ResolveDependenciesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = this.TestHelper.ResourceMoverServiceClient;

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
                var client = this.TestHelper.ResourceMoverServiceClient;

                var commitRequest = new CommitRequest()
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
                var client = this.TestHelper.ResourceMoverServiceClient;

                var commitRequest = new CommitRequest()
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

        [Fact]
        public async Task ValidateBulkRemoveForMoveResourcesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.ResourceMoverServiceClient;

                var bulkRemoveRequest = new BulkRemoveRequest()
                {
                    MoveResources = new List<string>()
                    {
                        VirtualMachineId,
                        PublicIpId,
                        VirtualNetworkId,
                        NetworkSecurityGroupId,
                        ResourceGroupId,
                        NetworkInterfaceId,
                        LoadBalancerId
                    },
                    ValidateOnly = true,
                    MoveResourceInputType = MoveResourceInputType.MoveResourceSourceId
                };

                var operationStatus =
                    (await client.MoveCollections.BulkRemoveWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        bulkRemoveRequest)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Validate Bulk remove operation should have succeeded.");
            }
        }

        [Fact]
        public async Task InitiateBulkRemoveForMoveResourcesAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.TestHelper.Initialize(context);
                var client = this.TestHelper.ResourceMoverServiceClient;

                var bulkRemoveRequest = new BulkRemoveRequest()
                {
                    MoveResources = new List<string>()
                    {
                        VirtualMachineId,
                        PublicIpId,
                        VirtualNetworkId,
                        NetworkSecurityGroupId,
                        ResourceGroupId,
                        NetworkInterfaceId,
                        LoadBalancerId
                    },
                    MoveResourceInputType = MoveResourceInputType.MoveResourceSourceId
                };

                var operationStatus =
                    (await client.MoveCollections.BulkRemoveWithHttpMessagesAsync(
                        MoveCollectionResourceGroup,
                        MoveCollectionName,
                        bulkRemoveRequest)).Body;

                Assert.True(OperationStatusSucceeded.Equals(
                    operationStatus.Status,
                    StringComparison.OrdinalIgnoreCase),
                    "Bulk Remove operation should have succeeded.");
            }
        }
    }
}
