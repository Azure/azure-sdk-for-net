// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Network;
using Azure.Management.Resources;
using Azure.Management.Storage;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Tests;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using Operations = Azure.ResourceManager.Compute.Operations;

namespace Azure.ResourceManager
{
    [RunFrequency(RunTestFrequency.Manually)]
    [ClientTestFixture]
    [NonParallelizable]
    public abstract class ComputeClientBase : ManagementRecordedTestBase<ComputeManagementTestEnvironment>
    {
        protected string DefaultLocation = "southeastasia";
        protected string LocationEastUs2UpperCase = "EastUS2";
        protected string LocationEastUs2 = "eastus2";
        protected string LocationWestCentralUs = "westcentralus";
        protected string LocationAustraliaSouthEast = "australiasoutheast";
        protected string LocationNorthEurope = "northeurope";
        protected string LocationCentralUs = "centralus";
        protected string LocationCentralUsEuap = "centraluseuap";
        protected string LocationSouthCentralUs = "southcentralus";

        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
        public ProvidersOperations ProvidersOperations { get; set; }
        public DeploymentsOperations DeploymentsOperations { get; set; }
        public TagsOperations TagsOperations { get; set; }
        public ResourcesOperations ResourcesOperations { get; set; }
        public VirtualMachineImagesOperations VirtualMachineImagesOperations { get; set; }
        public AvailabilitySetsOperations AvailabilitySetsOperations { get; set; }
        public ContainerServicesOperations ContainerServicesOperations { get; set; }
        public DedicatedHostGroupsOperations DedicatedHostGroupsOperations { get; set; }
        public DedicatedHostsOperations DedicatedHostsOperations { get; set; }
        public VirtualMachineExtensionImagesOperations VirtualMachineExtensionImagesOperations { get; set; }
        public ResourceSkusOperations ResourceSkusOperations { get; set; }
        public LogAnalyticsOperations LogAnalyticsOperations { get; set; }
        public Operations Operations { get; set; }
        public ProximityPlacementGroupsOperations ProximityPlacementGroupsOperations { get; set; }
        public VirtualMachinesOperations VirtualMachinesOperations { get; set; }
        public VirtualMachineRunCommandsOperations VirtualMachineRunCommandsOperations { get; set; }
        public VirtualMachineScaleSetExtensionsOperations VirtualMachineScaleSetExtensionsOperations { get; set; }
        public VirtualMachineScaleSetsOperations VirtualMachineScaleSetsOperations { get; set; }
        public VirtualMachineScaleSetVMsOperations VirtualMachineScaleSetVMsOperations { get; set; }
        public VirtualMachineScaleSetRollingUpgradesOperations VirtualMachineScaleSetRollingUpgradesOperations { get; set; }
        public DisksOperations DisksOperations { get; set; }
        public VirtualMachineSizesOperations VirtualMachineSizesOperations { get; set; }
        public SnapshotsOperations SnapshotsOperations { get; set; }
        public DiskEncryptionSetsOperations DiskEncryptionSetsOperations { get; set; }
        public VirtualNetworksOperations VirtualNetworksOperations { get; set; }
        public PublicIPAddressesOperations PublicIPAddressesOperations { get; set; }
        public StorageAccountsOperations StorageAccountsOperations { get; set; }
        public SubnetsOperations SubnetsOperations { get; set; }
        public NetworkInterfacesOperations NetworkInterfacesOperations { get; set; }
        public VirtualMachineExtensionsOperations VirtualMachineExtensionsOperations { get; set; }
        public GalleriesOperations GalleriesOperations { get; set; }
        public GalleryImagesOperations GalleryImagesOperations { get; set; }
        public GalleryImageVersionsOperations GalleryImageVersionsOperations { get; set; }
        public ImagesOperations ImagesOperations { get; set; }
        public GalleryApplicationsOperations GalleryApplicationsOperations { get; set; }
        public GalleryApplicationVersionsOperations GalleryApplicationVersionsOperations { get; set; }
        public BlobContainersOperations BlobContainersOperations { get; set; }
        public UsageOperations UsageClient { get; set; }
        public ApplicationGatewaysOperations ApplicationGatewaysOperations { get; set; }
        public LoadBalancersOperations LoadBalancersOperations { get; set; }
        public NetworkSecurityGroupsOperations NetworkSecurityGroupsOperations { get; set; }
        public PublicIPPrefixesOperations PublicIPPrefixesOperations { get; set; }
        public ComputeManagementClient ComputeManagementClient { get; set; }

        protected ComputeClientBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected void InitializeBase()
        {
            var resourceManagementClient = GetResourceManagementClient();
            ResourceGroupsOperations = resourceManagementClient.ResourceGroups;
            ProvidersOperations = resourceManagementClient.Providers;
            DeploymentsOperations = resourceManagementClient.Deployments;
            TagsOperations = resourceManagementClient.Tags;
            ResourcesOperations = resourceManagementClient.Resources;
            ComputeManagementClient = GetComputeManagementClient();
            VirtualMachineImagesOperations = ComputeManagementClient.VirtualMachineImages;
            AvailabilitySetsOperations = ComputeManagementClient.AvailabilitySets;
            ContainerServicesOperations = ComputeManagementClient.ContainerServices;
            DedicatedHostGroupsOperations = ComputeManagementClient.DedicatedHostGroups;
            DedicatedHostsOperations = ComputeManagementClient.DedicatedHosts;
            VirtualMachineExtensionImagesOperations = ComputeManagementClient.VirtualMachineExtensionImages;
            ResourceSkusOperations = ComputeManagementClient.ResourceSkus;
            LogAnalyticsOperations = ComputeManagementClient.LogAnalytics;
            Operations = ComputeManagementClient.Operations;
            ProximityPlacementGroupsOperations = ComputeManagementClient.ProximityPlacementGroups;
            VirtualMachinesOperations = ComputeManagementClient.VirtualMachines;
            VirtualMachineRunCommandsOperations = ComputeManagementClient.VirtualMachineRunCommands;
            VirtualMachineScaleSetExtensionsOperations = ComputeManagementClient.VirtualMachineScaleSetExtensions;
            VirtualMachineScaleSetsOperations = ComputeManagementClient.VirtualMachineScaleSets;
            VirtualMachineScaleSetVMsOperations = ComputeManagementClient.VirtualMachineScaleSetVMs;
            VirtualMachineScaleSetRollingUpgradesOperations = ComputeManagementClient.VirtualMachineScaleSetRollingUpgrades;
            DisksOperations = ComputeManagementClient.Disks;
            VirtualMachineSizesOperations = ComputeManagementClient.VirtualMachineSizes;
            SnapshotsOperations = ComputeManagementClient.Snapshots;
            DiskEncryptionSetsOperations = ComputeManagementClient.DiskEncryptionSets;
            VirtualMachineExtensionsOperations = ComputeManagementClient.VirtualMachineExtensions;
            GalleriesOperations = ComputeManagementClient.Galleries;
            GalleryImagesOperations = ComputeManagementClient.GalleryImages;
            GalleryImageVersionsOperations = ComputeManagementClient.GalleryImageVersions;
            ImagesOperations = ComputeManagementClient.Images;
            GalleryApplicationsOperations = ComputeManagementClient.GalleryApplications;
            GalleryApplicationVersionsOperations = ComputeManagementClient.GalleryApplicationVersions;
            UsageClient = ComputeManagementClient.Usage;
            var NetworkManagementClient = GetNetworkManagementClient();
            PublicIPAddressesOperations = NetworkManagementClient.PublicIPAddresses;
            SubnetsOperations = NetworkManagementClient.Subnets;
            NetworkInterfacesOperations = NetworkManagementClient.NetworkInterfaces;
            ApplicationGatewaysOperations = NetworkManagementClient.ApplicationGateways;
            LoadBalancersOperations = NetworkManagementClient.LoadBalancers;
            NetworkSecurityGroupsOperations = NetworkManagementClient.NetworkSecurityGroups;
            PublicIPPrefixesOperations = NetworkManagementClient.PublicIPPrefixes;
            VirtualNetworksOperations = NetworkManagementClient.VirtualNetworks;
            var StorageManagementClient = GetStorageManagementClient();
            StorageAccountsOperations = StorageManagementClient.StorageAccounts;
            BlobContainersOperations = StorageManagementClient.BlobContainers;
        }
        internal ComputeManagementClient GetComputeManagementClient()
        {
            return CreateClient<ComputeManagementClient>(this.TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new ComputeManagementClientOptions()));
        }
        internal NetworkManagementClient GetNetworkManagementClient()
        {
            return CreateClient<NetworkManagementClient>(this.TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new NetworkManagementClientOptions()));
        }
        internal StorageManagementClient GetStorageManagementClient()
        {
            return CreateClient<StorageManagementClient>(this.TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new StorageManagementClientOptions()));
        }

        public void WaitSeconds(int seconds)
        {
            SleepInTest(seconds * 1000);
        }

        public void WaitMinutes(int minutes)
        {
            WaitSeconds(minutes * 60);
        }
    }
}
