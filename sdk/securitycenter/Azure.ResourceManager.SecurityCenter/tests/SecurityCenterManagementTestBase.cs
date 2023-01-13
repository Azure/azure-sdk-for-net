// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute;
using System.Linq;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.Logic;
using System;
using System.IO;
using Azure.ResourceManager.IotHub.Models;
using Azure.ResourceManager.IotHub;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    public class SecurityCenterManagementTestBase : ManagementRecordedTestBase<SecurityCenterManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected const string rgNamePrefix = "SecurityCenterRG";
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        protected SecurityCenterManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected SecurityCenterManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<NetworkSecurityGroupResource> CreateNetworkSecurityGroup(ResourceGroupResource resourceGroup, string nsgName)
        {
            var nsgData = new NetworkSecurityGroupData() { Location = resourceGroup.Data.Location, };
            var nsg = await resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(WaitUntil.Completed, nsgName, nsgData);
            return nsg.Value;
        }

        protected async Task<VirtualNetworkResource> CreateNetwork(ResourceGroupResource resourceGroup, NetworkSecurityGroupResource nsg, string vnetName)
        {
            VirtualNetworkData data = new VirtualNetworkData()
            {
                Location = resourceGroup.Data.Location,
            };
            data.AddressPrefixes.Add("10.10.0.0/16");
            data.Subnets.Add(new SubnetData() { Name = "subnet1", AddressPrefix = "10.10.1.0/24", PrivateLinkServiceNetworkPolicy = VirtualNetworkPrivateLinkServiceNetworkPolicy.Disabled, NetworkSecurityGroup = nsg.Data });
            data.Subnets.Add(new SubnetData() { Name = "subnet2", AddressPrefix = "10.10.2.0/24" });
            var vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, data);
            return vnet.Value;
        }

        protected async Task<NetworkInterfaceResource> CreateNetworkInterface(ResourceGroupResource resourceGroup, VirtualNetworkResource network, string nicName)
        {
            // Create Public IP
            string publicIPName = Recording.GenerateAssetName("publicIP");
            var publicIPData = new PublicIPAddressData()
            {
                Location = resourceGroup.Data.Location,
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
            };
            var publicIP = await resourceGroup.GetPublicIPAddresses().CreateOrUpdateAsync(WaitUntil.Completed, publicIPName, publicIPData);

            // Get subnet id AsyncPageable<SubnetResource>
            var list = await network.GetSubnets().GetAllAsync().ToEnumerableAsync();
            var subnetId = list.FirstOrDefault().Id;

            var data = new NetworkInterfaceData()
            {
                Location = resourceGroup.Data.Location,
                IPConfigurations =
                {
                    new NetworkInterfaceIPConfigurationData()
                    {
                        Name = Recording.GenerateAssetName("ipconfig"),
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new PublicIPAddressData()
                        {
                            Id = publicIP.Value.Id
                        },
                        Subnet = new SubnetData()
                        {
                            Id = subnetId
                        }
                    }
                }
            };
            var networkInterface = await resourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync(WaitUntil.Completed, nicName, data);
            return networkInterface.Value;
        }

        protected async Task<VirtualMachineResource> CreateVirtualMachine(ResourceGroupResource resourceGroup, ResourceIdentifier networkInterfaceIP, string vmName)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                var vmId = VirtualMachineResource.CreateResourceIdentifier(resourceGroup.Id.SubscriptionId, resourceGroup.Id.Name, vmName);

                return Client.GetVirtualMachineResource(vmId);
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    string adminUsername = "adminUser";
                    VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
                    VirtualMachineData input = new VirtualMachineData(resourceGroup.Data.Location)
                    {
                        HardwareProfile = new VirtualMachineHardwareProfile()
                        {
                            VmSize = VirtualMachineSizeType.StandardF2
                        },
                        OSProfile = new VirtualMachineOSProfile()
                        {
                            AdminUsername = adminUsername,
                            ComputerName = vmName,
                            LinuxConfiguration = new LinuxConfiguration()
                            {
                                DisablePasswordAuthentication = true,
                                SshPublicKeys = {
                            new SshPublicKeyConfiguration()
                            {
                                Path = $"/home/{adminUsername}/.ssh/authorized_keys",
                                KeyData = dummySSHKey,
                            }
                        }
                            }
                        },
                        NetworkProfile = new VirtualMachineNetworkProfile()
                        {
                            NetworkInterfaces =
                    {
                        new VirtualMachineNetworkInterfaceReference()
                        {
                            Id = networkInterfaceIP,
                            Primary = true,
                        }
                    }
                        },
                        StorageProfile = new VirtualMachineStorageProfile()
                        {
                            OSDisk = new VirtualMachineOSDisk(DiskCreateOptionType.FromImage)
                            {
                                OSType = SupportedOperatingSystemType.Linux,
                                Caching = CachingType.ReadWrite,
                                ManagedDisk = new VirtualMachineManagedDisk()
                                {
                                    StorageAccountType = StorageAccountType.StandardLrs
                                }
                            },
                            ImageReference = new ImageReference()
                            {
                                Publisher = "Canonical",
                                Offer = "UbuntuServer",
                                Sku = "16.04-LTS",
                                Version = "latest",
                            }
                        }
                    };
                    ArmOperation<VirtualMachineResource> lro = await vmCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
                    return lro.Value;
                }
            }
        }

        protected async Task<LogicWorkflowResource> CreateLogicWorkFlow(ResourceGroupResource resourceGroup)
        {
            // create integration Account
            string integrationAccountName = Recording.GenerateAssetName("integrationAccount");
            IntegrationAccountData integrationAccountData = new IntegrationAccountData(resourceGroup.Data.Location)
            {
                SkuName = IntegrationAccountSkuName.Standard,
            };
            var integrationAccount = await resourceGroup.GetIntegrationAccounts().CreateOrUpdateAsync(WaitUntil.Completed, integrationAccountName, integrationAccountData);

            // create logic work flow
            string logicWorkflowName = Recording.GenerateAssetName("logicWorkFlow");
            byte[] definition = File.ReadAllBytes(@"TestData/WorkflowDefinition.json");
            LogicWorkflowData logicWorkflowData = new LogicWorkflowData(resourceGroup.Data.Location)
            {
                Definition = new BinaryData(definition),
                IntegrationAccount = new LogicResourceReference() { Id = integrationAccount.Value.Data.Id },
            };
            var workflow = await resourceGroup.GetLogicWorkflows().CreateOrUpdateAsync(WaitUntil.Completed, logicWorkflowName, logicWorkflowData);
            return workflow.Value;
        }

        protected async Task<IotHubDescriptionResource> CreateIotHub(ResourceGroupResource resourceGroup, string iotHubName)
        {
            var sku = new IotHubSkuInfo("S1")
            {
                Name = "S1",
                Capacity = 1
            };
            IotHubDescriptionData data = new IotHubDescriptionData(resourceGroup.Data.Location, sku) { };
            var iotHub = await resourceGroup.GetIotHubDescriptions().CreateOrUpdateAsync(WaitUntil.Completed, iotHubName, data);
            return iotHub.Value;
        }

        protected async Task<IotSecuritySolutionResource> CreateIotSecuritySolution(ResourceGroupResource resourceGroup, string iotHubId, string solutionModelName)
        {
            IotSecuritySolutionData data = new IotSecuritySolutionData(resourceGroup.Data.Location)
            {
                Status = SecuritySolutionStatus.Enabled,
                UnmaskedIPLoggingStatus = UnmaskedIPLoggingStatus.Enabled,
                DisplayName = solutionModelName,
                IotHubs =
                {
                    iotHubId
                },
                RecommendationsConfiguration =
                {
                    new RecommendationConfigurationProperties(IotSecurityRecommendationType.IotOpenPorts,RecommendationConfigStatus.Disabled),
                    new RecommendationConfigurationProperties(IotSecurityRecommendationType.IotSharedCredentials,RecommendationConfigStatus.Disabled),
                }
            };
            var iotSecuritySolutionModel = await resourceGroup.GetIotSecuritySolutions().CreateOrUpdateAsync(WaitUntil.Completed, solutionModelName, data);
            return iotSecuritySolutionModel.Value;
        }
    }
}
