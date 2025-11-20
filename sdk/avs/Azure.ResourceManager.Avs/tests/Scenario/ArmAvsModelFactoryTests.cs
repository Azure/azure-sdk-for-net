// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Avs.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Avs.Tests
{
    [TestFixture]
    public class ArmAvsModelFactoryTests
    {
        private readonly ResourceIdentifier _testId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.AVS/privateClouds/test-cloud");
        private readonly AzureLocation _testLocation = AzureLocation.EastUS;

        [Test]
        public void AddonHcxProperties_TwoParameter_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.AddonHcxProperties(
                provisioningState: AddonProvisioningState.Succeeded,
                offer: "VMware MaaS Cloud Provider (Enterprise)");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(AddonProvisioningState.Succeeded, result.ProvisioningState);
            Assert.AreEqual("VMware MaaS Cloud Provider (Enterprise)", result.Offer);
        }

        [Test]
        public void AddonHcxProperties_WithNullValues_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.AddonHcxProperties(
                provisioningState: null,
                offer: null);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ProvisioningState);
            Assert.IsNull(result.Offer);
        }

        [Test]
        public void AvsCloudLinkData_WithoutProvisioningState_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.AvsCloudLinkData(
                id: _testId,
                name: "test-link",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds/cloudLinks"),
                systemData: null,
                status: AvsCloudLinkStatus.Active,
                linkedCloud: _testId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test-link", result.Name);
            Assert.AreEqual(AvsCloudLinkStatus.Active, result.Status);
            Assert.AreEqual(_testId, result.LinkedCloud);
        }

        [Test]
        public void AvsManagementCluster_FourParameter_ShouldNotThrow()
        {
            // Arrange
            var hosts = new List<string> { "host1.example.com", "host2.example.com" };

            // Act
            var result = ArmAvsModelFactory.AvsManagementCluster(
                clusterSize: 3,
                provisioningState: AvsPrivateCloudClusterProvisioningState.Succeeded,
                clusterId: 1,
                hosts: hosts);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.ClusterSize);
            Assert.AreEqual(AvsPrivateCloudClusterProvisioningState.Succeeded, result.ProvisioningState);
            Assert.AreEqual(1, result.ClusterId);
            Assert.IsNotNull(result.Hosts);
            Assert.AreEqual(2, result.Hosts.Count);
        }

        [Test]
        public void AvsManagementCluster_WithNullHosts_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.AvsManagementCluster(
                clusterSize: null,
                provisioningState: null,
                clusterId: null,
                hosts: null);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ClusterSize);
            Assert.IsNull(result.ProvisioningState);
            Assert.IsNull(result.ClusterId);
        }

        [Test]
        public void AvsPrivateCloudClusterVirtualMachineData_WithoutProvisioningState_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.AvsPrivateCloudClusterVirtualMachineData(
                id: _testId,
                name: "test-vm",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds/clusters/virtualMachines"),
                systemData: null,
                displayName: "Test VM",
                moRefId: "vm-123",
                folderPath: "/datacenter/vm",
                restrictMovement: VirtualMachineRestrictMovementState.Enabled);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test-vm", result.Name);
            Assert.AreEqual("Test VM", result.DisplayName);
            Assert.AreEqual("vm-123", result.MoRefId);
            Assert.AreEqual("/datacenter/vm", result.FolderPath);
            Assert.AreEqual(VirtualMachineRestrictMovementState.Enabled, result.RestrictMovement);
        }

        [Test]
        public void AvsPrivateCloudData_WithSkuIdentityZones_ShouldNotThrow()
        {
            // Arrange
            var tags = new Dictionary<string, string> { { "env", "test" } };
            var sku = new AvsSku("AV36");
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var managementCluster = ArmAvsModelFactory.AvsManagementCluster(
                clusterSize: 3,
                provisioningState: AvsPrivateCloudClusterProvisioningState.Succeeded,
                clusterId: 1,
                hosts: new List<string>());
            var zones = new List<string> { "1", "2" };

            // Act
            var result = ArmAvsModelFactory.AvsPrivateCloudData(
                id: _testId,
                name: "test-cloud",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds"),
                systemData: null,
                tags: tags,
                location: _testLocation,
                managementCluster: managementCluster,
                internet: InternetConnectivityState.Enabled,
                identitySources: null,
                availability: null,
                encryption: null,
                extendedNetworkBlocks: null,
                provisioningState: AvsPrivateCloudProvisioningState.Succeeded,
                circuit: null,
                endpoints: null,
                networkBlock: "10.0.0.0/22",
                managementNetwork: "10.0.0.0/24",
                provisioningNetwork: "10.0.1.0/24",
                vMotionNetwork: "10.0.2.0/24",
                vCenterPassword: null,
                nsxtPassword: null,
                vCenterCertificateThumbprint: null,
                nsxtCertificateThumbprint: null,
                externalCloudLinks: null,
                secondaryCircuit: null,
                nsxPublicIPQuotaRaised: null,
                virtualNetworkId: null,
                dnsZoneType: null,
                sku: sku,
                identity: identity,
                zones: zones);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test-cloud", result.Name);
            Assert.AreEqual(_testLocation, result.Location);
            Assert.IsNotNull(result.Sku);
            Assert.AreEqual("AV36", result.Sku.Name);
            Assert.IsNotNull(result.Identity);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, result.Identity.ManagedServiceIdentityType);
        }

        [Test]
        public void AvsPrivateCloudData_AlternateParameterOrder_ShouldNotThrow()
        {
            // Arrange
            var tags = new Dictionary<string, string> { { "env", "test" } };
            var sku = new AvsSku("AV36");
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var managementCluster = ArmAvsModelFactory.AvsManagementCluster(
                clusterSize: 3,
                provisioningState: AvsPrivateCloudClusterProvisioningState.Succeeded,
                clusterId: 1,
                hosts: new List<string>());

            // Act - Testing the overload with sku/identity earlier in parameter list
            var result = ArmAvsModelFactory.AvsPrivateCloudData(
                id: _testId,
                name: "test-cloud",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds"),
                systemData: null,
                tags: tags,
                location: _testLocation,
                sku: sku,
                identity: identity,
                managementCluster: managementCluster,
                internet: InternetConnectivityState.Enabled,
                identitySources: null,
                availability: null,
                encryption: null,
                extendedNetworkBlocks: null,
                provisioningState: AvsPrivateCloudProvisioningState.Succeeded,
                circuit: null,
                endpoints: null,
                networkBlock: "10.0.0.0/22",
                managementNetwork: "10.0.0.0/24",
                provisioningNetwork: "10.0.1.0/24",
                vMotionNetwork: "10.0.2.0/24",
                vCenterPassword: null,
                nsxtPassword: null,
                vCenterCertificateThumbprint: null,
                nsxtCertificateThumbprint: null,
                externalCloudLinks: null,
                secondaryCircuit: null,
                nsxPublicIPQuotaRaised: null,
                virtualNetworkId: null,
                dnsZoneType: null);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test-cloud", result.Name);
            Assert.IsNotNull(result.Sku);
            Assert.AreEqual("AV36", result.Sku.Name);
        }

        [Test]
        public void AvsPrivateCloudDatastoreData_WithElasticSan_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.AvsPrivateCloudDatastoreData(
                id: _testId,
                name: "test-datastore",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds/datastores"),
                systemData: null,
                provisioningState: AvsPrivateCloudDatastoreProvisioningState.Succeeded,
                netAppVolumeId: null,
                diskPoolVolume: null,
                elasticSanVolumeTargetId: new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.ElasticSan/elasticSans/test-san"),
                status: DatastoreStatus.Accessible);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test-datastore", result.Name);
            Assert.AreEqual(AvsPrivateCloudDatastoreProvisioningState.Succeeded, result.ProvisioningState);
            Assert.IsNotNull(result.ElasticSanVolumeTargetId);
            Assert.AreEqual(DatastoreStatus.Accessible, result.Status);
        }

        [Test]
        public void AvsPrivateCloudDatastoreData_WithoutElasticSan_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.AvsPrivateCloudDatastoreData(
                id: _testId,
                name: "test-datastore",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds/datastores"),
                systemData: null,
                provisioningState: AvsPrivateCloudDatastoreProvisioningState.Succeeded,
                netAppVolumeId: new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account"),
                diskPoolVolume: null,
                status: DatastoreStatus.Accessible);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test-datastore", result.Name);
            Assert.IsNotNull(result.NetAppVolumeId);
            Assert.IsNull(result.ElasticSanVolumeTargetId);
        }

        [Test]
        public void AvsPrivateCloudEndpoints_ThreeParameter_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.AvsPrivateCloudEndpoints(
                nsxtManager: "nsxt.example.com",
                vcsa: "vcenter.example.com",
                hcxCloudManager: "hcx.example.com");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("nsxt.example.com", result.NsxtManager);
            Assert.AreEqual("vcenter.example.com", result.Vcsa);
            Assert.AreEqual("hcx.example.com", result.HcxCloudManager);
        }

        [Test]
        public void AvsPrivateCloudEndpoints_WithNullValues_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.AvsPrivateCloudEndpoints(
                nsxtManager: null,
                vcsa: null,
                hcxCloudManager: null);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.NsxtManager);
            Assert.IsNull(result.Vcsa);
            Assert.IsNull(result.HcxCloudManager);
        }

        [Test]
        public void HcxEnterpriseSiteData_WithoutProvisioningState_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.HcxEnterpriseSiteData(
                id: _testId,
                name: "test-site",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds/hcxEnterpriseSites"),
                systemData: null,
                activationKey: "test-key-12345",
                status: HcxEnterpriseSiteStatus.Available);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test-site", result.Name);
            Assert.AreEqual("test-key-12345", result.ActivationKey);
            Assert.AreEqual(HcxEnterpriseSiteStatus.Available, result.Status);
        }

        [Test]
        public void ScriptCmdletData_WithoutProvisioningState_ShouldNotThrow()
        {
            // Arrange
            // ScriptParameter has internal constructors, so we pass null for testing
            List<ScriptParameter> parameters = null;

            // Act
            var result = ArmAvsModelFactory.ScriptCmdletData(
                id: _testId,
                name: "test-cmdlet",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds/scriptPackages/scriptCmdlets"),
                systemData: null,
                description: "Test cmdlet",
                timeout: TimeSpan.FromMinutes(30),
                parameters: parameters);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test-cmdlet", result.Name);
            Assert.AreEqual("Test cmdlet", result.Description);
            Assert.AreEqual(TimeSpan.FromMinutes(30), result.Timeout);
        }

        [Test]
        public void ScriptPackageData_WithoutProvisioningState_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.ScriptPackageData(
                id: _testId,
                name: "test-package",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds/scriptPackages"),
                systemData: null,
                description: "Test package",
                version: "1.0.0",
                company: "Microsoft",
                uri: new Uri("https://example.com/package"));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test-package", result.Name);
            Assert.AreEqual("Test package", result.Description);
            Assert.AreEqual("1.0.0", result.Version);
            Assert.AreEqual("Microsoft", result.Company);
            Assert.AreEqual(new Uri("https://example.com/package"), result.Uri);
        }

        [Test]
        public void WorkloadNetworkData_WithoutProvisioningState_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.WorkloadNetworkData(
                id: _testId,
                name: "default",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds/workloadNetworks"),
                systemData: null);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("default", result.Name);
        }

        [Test]
        public void WorkloadNetworkGatewayData_WithoutProvisioningState_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.WorkloadNetworkGatewayData(
                id: _testId,
                name: "test-gateway",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds/workloadNetworks/gateways"),
                systemData: null,
                displayName: "Test Gateway",
                path: "/infra/tier-1s/gateway1");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test-gateway", result.Name);
            Assert.AreEqual("Test Gateway", result.DisplayName);
            Assert.AreEqual("/infra/tier-1s/gateway1", result.Path);
        }

        [Test]
        public void WorkloadNetworkVirtualMachineData_WithoutProvisioningState_ShouldNotThrow()
        {
            // Arrange & Act
            var result = ArmAvsModelFactory.WorkloadNetworkVirtualMachineData(
                id: _testId,
                name: "test-vm",
                resourceType: new ResourceType("Microsoft.AVS/privateClouds/workloadNetworks/virtualMachines"),
                systemData: null,
                displayName: "Test VM",
                vmType: WorkloadNetworkVmType.Regular);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test-vm", result.Name);
            Assert.AreEqual("Test VM", result.DisplayName);
            Assert.AreEqual(WorkloadNetworkVmType.Regular, result.VmType);
        }

        [Test]
        public void AllFactoryMethods_WithNullOptionalParameters_ShouldNotThrow()
        {
            // This test ensures all factory methods handle null optional parameters gracefully
            Assert.DoesNotThrow(() =>
            {
                ArmAvsModelFactory.AddonHcxProperties(null, null);
                ArmAvsModelFactory.AvsCloudLinkData(null, null, default, null, null, null);
                ArmAvsModelFactory.AvsManagementCluster(null, null, null, null);
                ArmAvsModelFactory.AvsPrivateCloudClusterVirtualMachineData(null, null, default, null, null, null, null, null);
                ArmAvsModelFactory.AvsPrivateCloudEndpoints(null, null, null);
                ArmAvsModelFactory.HcxEnterpriseSiteData(null, null, default, null, null, null);
                ArmAvsModelFactory.ScriptCmdletData(null, null, default, null, null, null, null);
                ArmAvsModelFactory.ScriptPackageData(null, null, default, null, null, null, null, null);
                ArmAvsModelFactory.WorkloadNetworkData(null, null, default, null);
                ArmAvsModelFactory.WorkloadNetworkGatewayData(null, null, default, null, null, null);
                ArmAvsModelFactory.WorkloadNetworkVirtualMachineData(null, null, default, null, null, null);
            });
        }
    }
}
