// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.TestFramework;

using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    public class NetworkServiceClientTestBase : ManagementRecordedTestBase<NetworkManagementTestEnvironment>
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";
        public NetworkServiceClientTestBase(bool isAsync) : base(isAsync)
        {
        }

        public NetworkServiceClientTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected NetworkServiceClientTestBase(bool isAsync, ResourceType resourceType, string apiVersion, RecordedTestMode? mode = null)
            : base(isAsync, resourceType, apiVersion, mode)
        {
        }

        public bool IsTestTenant = false;
        public static TimeSpan ZeroPollingInterval { get; } = TimeSpan.FromSeconds(0);
        public Dictionary<string, string> Tags { get; internal set; }

        public ArmClient ArmClient { get; set; }

        public Resources.SubscriptionResource Subscription
        {
            get
            {
                return ArmClient.GetDefaultSubscription();
            }
        }

        public Resources.ResourceGroupResource ResourceGroup
        {
            get
            {
                return Subscription.GetResourceGroups().Get(TestEnvironment.ResourceGroup).Value;
            }
        }

        public Resources.ResourceGroupResource GetResourceGroup(string name)
        {
            return Subscription.GetResourceGroups().Get(name).Value;
        }

        protected void Initialize()
        {
            ArmClient = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(string name)
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            return (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, name, new ResourceGroupData(TestEnvironment.Location))).Value;
        }
        protected async Task<ResourceGroupResource> CreateResourceGroup(string name, string location)
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            return (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, name, new ResourceGroupData(location))).Value;
        }

        public async Task<GenericResource> CreateLinuxVM(string vmName, string networkInterfaceName, string location, ResourceGroupResource resourceGroup)
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            var vnet = await CreateVirtualNetwork(Recording.GenerateAssetName("vnet_"), Recording.GenerateAssetName("subnet_"), location, resourceGroup.GetVirtualNetworks());
            var networkInterface = await CreateNetworkInterface(networkInterfaceName, null, vnet.Data.Subnets[0].Id, location, Recording.GenerateAssetName("ipconfig_"), resourceGroup.GetNetworkInterfaces());

            var adminUsername = Recording.GenerateAssetName("admin");
            var vmId = new ResourceIdentifier($"{resourceGroup.Id}/providers/Microsoft.Compute/virtualMachines/{vmName}");
            var genericResouces = subscription.GetGenericResources();
            var data = new GenericResourceData(location)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>
                {
                    { "hardwareProfile", new Dictionary<string, object> { { "vmSize", "Standard_F2" } } },
                    {
                        "storageProfile",
                        new Dictionary<string, object>
                        {
                            {
                                "imageReference",
                                new Dictionary<string, object>
                                {
                                    { "sku", "16.04-LTS" }, { "publisher", "Canonical" }, { "version", "latest" }, { "offer", "UbuntuServer" }
                                }
                            },
                            {
                                "osDisk",
                                new Dictionary<string, object>
                                {
                                    { "name", $"{vmName}_os_disk" },
                                    { "osType", "Linux" },
                                    { "caching", "ReadWrite" },
                                    { "createOption", "FromImage" },
                                    { "managedDisk", new Dictionary<string, object> { { "storageAccountType", "Standard_LRS" } } }
                                }
                            }
                        }
                    },
                    {
                        "osProfile",
                        new Dictionary<string, object>
                        {
                            { "adminUsername", adminUsername },
                            { "computerName", vmName },
                            {
                                "linuxConfiguration",
                                new Dictionary<string, object>
                                {
                                    {
                                        "ssh",
                                        new Dictionary<string, object>
                                        {
                                            {
                                                "publicKeys",
                                                new List<object>
                                                {
                                                    new Dictionary<string, object>
                                                    {
                                                        { "path", $"/home/{adminUsername}/.ssh/authorized_keys" }, { "keyData", dummySSHKey }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    { "disablePasswordAuthentication", true },
                                }
                            },
                        }
                    },
                    {
                        "networkProfile",
                        new Dictionary<string, object>
                        {
                            {
                                "networkInterfaces",
                                new List<object>
                                {
                                    new Dictionary<string, object>
                                    {
                                        { "id", networkInterface.Id.ToString() },
                                        { "properties", new Dictionary<string, object> { { "primary", true } } }
                                    }
                                }
                            }
                        }
                    }
                })
            };
            var operation = InstrumentOperation(await ArmClient.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, vmId, data));
            operation.WaitForCompletion();
            return operation.Value;
        }
        public async Task<GenericResource> CreateLinuxVM(string vmName, string networkInterfaceName, string location, ResourceGroupResource resourceGroup, VirtualNetworkResource vnet)
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            var networkInterface = await CreateNetworkInterface(networkInterfaceName, null, vnet.Data.Subnets[0].Id, location, Recording.GenerateAssetName("ipconfig_"), resourceGroup.GetNetworkInterfaces());
            var genericResouces = subscription.GetGenericResourcesAsync();
            var adminUsername = Recording.GenerateAssetName("admin");
            var vmId = new ResourceIdentifier($"{resourceGroup.Id}/providers/Microsoft.Compute/virtualMachines/{vmName}");
            GenericResourceData data = new(location)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>
                {
                    { "hardwareProfile", new Dictionary<string, object>
                        {
                            { "vmSize", "Standard_F2" }
                        }
                    },
                    { "storageProfile", new Dictionary<string, object>
                        {
                            { "imageReference", new Dictionary<string, object>
                                {
                                    { "sku", "16.04-LTS" },
                                    { "publisher", "Canonical" },
                                    { "version", "latest" },
                                    { "offer", "UbuntuServer" }
                                }
                            },
                            { "osDisk", new Dictionary<string, object>
                                {
                                    { "name", $"{vmName}_os_disk" },
                                    { "osType", "Linux" },
                                    { "caching", "ReadWrite" },
                                    { "createOption", "FromImage" },
                                    { "managedDisk", new Dictionary<string, object>
                                        {
                                            { "storageAccountType", "Standard_LRS" }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    { "osProfile", new Dictionary<string, object>
                        {
                            { "adminUsername",  adminUsername },
                            { "computerName", vmName },
                            { "linuxConfiguration", new Dictionary<string, object>
                                {
                                    { "ssh", new Dictionary<string, object>
                                        {
                                            { "publicKeys", new List<object>
                                                { new Dictionary<string, object>
                                                    {
                                                        { "path", $"/home/{adminUsername}/.ssh/authorized_keys" },
                                                        { "keyData", dummySSHKey }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    { "disablePasswordAuthentication", true },
                                }
                            },
                        }
                    },
                    { "networkProfile", new Dictionary<string, object>
                        {
                            { "networkInterfaces", new List<object>
                                { new Dictionary<string, object>
                                    {
                                        { "id", networkInterface.Id.ToString() },
                                        { "properties", new Dictionary<string, object>
                                            {
                                                { "primary", true }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                })
            };
            var operation = await ArmClient.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, vmId, data);
            return operation.Value;
        }

        public async Task<GenericResource> CreateWindowsVM(string vmName, string networkInterfaceName, string location, ResourceGroupResource resourceGroup)
        {
            var vnet = await CreateVirtualNetwork(Recording.GenerateAssetName("vnet_"), Recording.GenerateAssetName("subnet_"), location, resourceGroup.GetVirtualNetworks());
            var networkInterface = await CreateNetworkInterface(networkInterfaceName, null, vnet.Data.Subnets[0].Id, location, Recording.GenerateAssetName("ipconfig_"), resourceGroup.GetNetworkInterfaces());

            var vmId = new ResourceIdentifier($"{resourceGroup.Id}/providers/Microsoft.Compute/virtualMachines/{vmName}");
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            var genericResouces = subscription.GetGenericResourcesAsync();
            GenericResourceData data = new GenericResourceData(location)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>
                {
                    { "hardwareProfile", new Dictionary<string, object>
                        {
                            { "vmSize", "Standard_D1_v2" }
                        }
                    },
                    { "storageProfile", new Dictionary<string, object>
                        {
                            { "imageReference", new Dictionary<string, object>
                                {
                                    { "sku", "2016-Datacenter" },
                                    { "publisher", "MicrosoftWindowsServer" },
                                    { "version", "latest" },
                                    { "offer", "WindowsServer" }
                                }
                            },
                            { "osDisk", new Dictionary<string, object>
                                {
                                    { "name", $"{vmName}_os_disk" },
                                    { "osType", "Windows" },
                                    { "caching", "ReadWrite" },
                                    { "createOption", "FromImage" },
                                    { "managedDisk", new Dictionary<string, object>
                                        {
                                            { "storageAccountType", "Standard_LRS" }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    { "osProfile", new Dictionary<string, object>
                        {
                            { "adminUsername", Recording.GenerateAssetName("admin") },
                            { "adminPassword", Recording.GenerateAlphaNumericId("adminPass!") },
                            { "computerName", vmName }
                        }
                    },
                    { "networkProfile", new Dictionary<string, object>
                        {
                            { "networkInterfaces", new List<object>
                                { new Dictionary<string, object>
                                    {
                                        { "id", networkInterface.Id.ToString() },
                                        { "properties", new Dictionary<string, object>
                                            {
                                                { "primary", true }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                })
            };
            var operation = InstrumentOperation(await ArmClient.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, vmId, data));
            operation.WaitForCompletion();
            return operation.Value;
        }

        protected async Task<GenericResource> deployWindowsNetworkAgent(string virtualMachineName, string location, ResourceGroupResource resourceGroup)
        {
            var extensionId = new ResourceIdentifier($"{resourceGroup.Id}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}/extensions/NetworkWatcherAgent");
            return (await ArmClient.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, extensionId, new GenericResourceData(location)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>
                {
                    { "publisher", "Microsoft.Azure.NetworkWatcher" },
                    { "typeHandlerVersion", "1.4" },
                    { "type", "NetworkWatcherAgentWindows" },
                })
            })).Value;
            //VirtualMachineExtensionData parameters = new VirtualMachineExtensionData(location)
            //{
            //    Publisher = "Microsoft.Azure.NetworkWatcher",
            //    TypeHandlerVersion = "1.4",
            //    TypePropertiesType = "NetworkWatcherAgentWindows"
            //};

            //VirtualMachineExtensionCreateOrUpdateOperation createOrUpdateOperation = await vm.GetVirtualMachineExtensionVirtualMachines().CreateOrUpdateAsync("NetworkWatcherAgent", parameters);
            //await createOrUpdateOperation.WaitForCompletionAsync();;
        }

        // TODO: we should try to create using template after new `Azure.ResourceManager.Resource` is available
        //public async Task CreateVm(
        //    string resourceGroupName,
        //    string location,
        //    string virtualMachineName,
        //    string storageAccountName,
        //    string networkInterfaceName,
        //    string networkSecurityGroupName,
        //    string diagnosticsStorageAccountName,
        //    string deploymentName,
        //    string adminPassword)
        //{
        //    string deploymentParams = "{" +
        //        "\"resourceGroupName\": {\"value\": \"" + resourceGroupName + "\"}," +
        //        "\"location\": {\"value\": \"" + location + "\"}," +
        //        "\"virtualMachineName\": { \"value\": \"" + virtualMachineName + "\"}," +
        //        "\"virtualMachineSize\": { \"value\": \"Standard_DS1_v2\"}," +
        //        "\"adminUsername\": { \"value\": \"netanalytics32\"}," +
        //        "\"storageAccountName\": { \"value\": \"" + storageAccountName + "\"}," +
        //        "\"routeTableName\": { \"value\": \"" + resourceGroupName + "RT\"}," +
        //        "\"virtualNetworkName\": { \"value\": \"" + resourceGroupName + "-vnet\"}," +
        //        "\"networkInterfaceName\": { \"value\": \"" + networkInterfaceName + "\"}," +
        //        "\"networkSecurityGroupName\": { \"value\": \"" + networkSecurityGroupName + "\"}," +
        //        "\"adminPassword\": { \"value\": \"" + adminPassword + "\"}," +
        //        "\"storageAccountType\": { \"value\": \"Premium_LRS\"}," +
        //        "\"diagnosticsStorageAccountName\": { \"value\": \"" + diagnosticsStorageAccountName + "\"}," +
        //        "\"diagnosticsStorageAccountId\": { \"value\": \"Microsoft.Storage/storageAccounts/" + diagnosticsStorageAccountName + "\"}," +
        //        "\"diagnosticsStorageAccountType\": { \"value\": \"Standard_LRS\"}," +
        //        "\"addressPrefix\": { \"value\": \"10.17.3.0/24\"}," +
        //        "\"subnetName\": { \"value\": \"default\"}, \"subnetPrefix\": { \"value\": \"10.17.3.0/24\"}," +
        //        "\"publicIpAddressName\": { \"value\": \"" + virtualMachineName + "-ip\"}," +
        //        "\"publicIpAddressType\": { \"value\": \"Dynamic\"}" +
        //        "}";
        //    string templateString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", "DeploymentTemplate.json"));

        //    DeploymentProperties deploymentProperties = new DeploymentProperties(DeploymentMode.Incremental)
        //    {
        //        Template = templateString,
        //        Parameters = deploymentParams
        //    };
        //    Deployment deploymentModel = new Deployment(deploymentProperties);

        //    Operation<DeploymentExtended> deploymentWait = await resourcesClient.Deployments.CreateOrUpdateAsync(resourceGroupName, deploymentName, deploymentModel);
        //    await deploymentWait.WaitForCompletionAsync();
        //}

        public async Task CreateVmss(ResourceGroupResource resourceGroup, string deploymentName)
        {
            string templateString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", "VmssDeploymentTemplate.json"));

            var deploymentProperties = new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
            {
                Template = BinaryData.FromString(templateString)
            };
            var deploymentModel = new ArmDeploymentContent(deploymentProperties);
            var deploymentWait = await resourceGroup.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, deploymentModel);
            await deploymentWait.WaitForCompletionAsync();
        }

        public async Task<ExpressRouteCircuitResource> CreateDefaultExpressRouteCircuit(Resources.ResourceGroupResource resourceGroup, string circuitName, string location)
        {
            var sku = new ExpressRouteCircuitSku
            {
                Name = "Premium_MeteredData",
                Tier = "Premium",
                Family = "MeteredData"
            };

            var provider = new ExpressRouteCircuitServiceProviderProperties
            {
                BandwidthInMbps = Convert.ToInt32(ExpressRouteTests.Circuit_BW),
                PeeringLocation = ExpressRouteTests.Circuit_Location,
                ServiceProviderName = ExpressRouteTests.Circuit_Provider
            };

            var circuit = new ExpressRouteCircuitData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                Sku = sku,
                ServiceProviderProperties = provider
            };

            // Put circuit
            var circuitCollection = resourceGroup.GetExpressRouteCircuits();
            Operation<ExpressRouteCircuitResource> circuitOperation = await circuitCollection.CreateOrUpdateAsync(WaitUntil.Completed, circuitName, circuit);
            Response<ExpressRouteCircuitResource> circuitResponse = await circuitOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", circuitResponse.Value.Data.ProvisioningState.ToString());
            Response<ExpressRouteCircuitResource> getCircuitResponse = await circuitCollection.GetAsync(circuitName);

            return getCircuitResponse;
        }

        public async Task<ExpressRouteCircuitResource> UpdateDefaultExpressRouteCircuitWithMicrosoftPeering(Resources.ResourceGroupResource resourceGroup, string circuitName)
        {
            var peering = new ExpressRouteCircuitPeeringData()
            {
                Name = ExpressRoutePeeringType.MicrosoftPeering.ToString(),
                PeeringType = ExpressRoutePeeringType.MicrosoftPeering,
                PeerASN = Convert.ToInt32(ExpressRouteTests.MS_PeerASN),
                VlanId = Convert.ToInt32(ExpressRouteTests.MS_VlanId),
                PrimaryPeerAddressPrefix = ExpressRouteTests.MS_PrimaryPrefix,
                SecondaryPeerAddressPrefix = ExpressRouteTests.MS_SecondaryPrefix,
                MicrosoftPeeringConfig = new ExpressRouteCircuitPeeringConfig()
                {
                    AdvertisedPublicPrefixes = {
                        ExpressRouteTests.MS_PublicPrefix
                    },
                    LegacyMode = Convert.ToInt32(true)
                },
            };

            var circuitCollection = resourceGroup.GetExpressRouteCircuits();
            Operation<ExpressRouteCircuitPeeringResource> peerOperation = await circuitCollection.Get(circuitName).Value.GetExpressRouteCircuitPeerings().CreateOrUpdateAsync(WaitUntil.Completed, ExpressRouteTests.Peering_Microsoft, peering);
            Response<ExpressRouteCircuitPeeringResource> peerResponse = await peerOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", peerResponse.Value.Data.ProvisioningState.ToString());
            Response<ExpressRouteCircuitResource> getCircuitResponse = await circuitCollection.GetAsync(circuitName);

            return getCircuitResponse;
        }

        public async Task<ExpressRouteCircuitResource> UpdateDefaultExpressRouteCircuitWithIpv6MicrosoftPeering(Resources.ResourceGroupResource resourceGroup, string circuitName)
        {
            var iPv6Peering = new IPv6ExpressRouteCircuitPeeringConfig()
            {
                PrimaryPeerAddressPrefix = ExpressRouteTests.MS_PrimaryPrefix_V6,
                SecondaryPeerAddressPrefix = ExpressRouteTests.MS_SecondaryPrefix_V6,
                MicrosoftPeeringConfig = new ExpressRouteCircuitPeeringConfig()
                {
                    AdvertisedPublicPrefixes = {
                        ExpressRouteTests.MS_PublicPrefix_V6
                    },
                    LegacyMode = Convert.ToInt32(true)
                },
            };

            var peering = new ExpressRouteCircuitPeeringData()
            {
                Name = ExpressRoutePeeringType.MicrosoftPeering.ToString(),
                PeeringType = ExpressRoutePeeringType.MicrosoftPeering,
                PeerASN = Convert.ToInt32(ExpressRouteTests.MS_PeerASN),
                VlanId = Convert.ToInt32(ExpressRouteTests.MS_VlanId),
                IPv6PeeringConfig = iPv6Peering
            };

            var circuitCollection = resourceGroup.GetExpressRouteCircuits();
            Operation<ExpressRouteCircuitPeeringResource> peerOperation = await circuitCollection.Get(circuitName).Value.GetExpressRouteCircuitPeerings().CreateOrUpdateAsync(WaitUntil.Completed, ExpressRouteTests.Peering_Microsoft, peering);
            Response<ExpressRouteCircuitPeeringResource> peerResponse = await peerOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", peerResponse.Value.Data.ProvisioningState.ToString());
            Response<ExpressRouteCircuitResource> getCircuitResponse = await circuitCollection.GetAsync(circuitName);

            return getCircuitResponse;
        }

        public async Task<ExpressRouteCircuitResource> UpdateDefaultExpressRouteCircuitWithMicrosoftPeering(string resourceGroupName, string circuitName,
            RouteFilterResource filter)
        {
            var peering = new ExpressRouteCircuitPeeringData()
            {
                Name = ExpressRoutePeeringType.MicrosoftPeering.ToString(),
                PeeringType = ExpressRoutePeeringType.MicrosoftPeering,
                PeerASN = Convert.ToInt32(ExpressRouteTests.MS_PeerASN),
                PrimaryPeerAddressPrefix = ExpressRouteTests.MS_PrimaryPrefix,
                SecondaryPeerAddressPrefix = ExpressRouteTests.MS_SecondaryPrefix,
                VlanId = Convert.ToInt32(ExpressRouteTests.MS_VlanId),
                MicrosoftPeeringConfig = new ExpressRouteCircuitPeeringConfig()
                {
                    AdvertisedPublicPrefixes = {
                        ExpressRouteTests.MS_PublicPrefix
                    },
                    LegacyMode = Convert.ToInt32(true)
                },
                RouteFilter = { Id = filter.Id }
            };

            Operation<ExpressRouteCircuitPeeringResource> peerOperation = await GetResourceGroup(resourceGroupName).GetExpressRouteCircuits().Get(circuitName).Value.GetExpressRouteCircuitPeerings().CreateOrUpdateAsync(WaitUntil.Completed, ExpressRouteTests.Peering_Microsoft, peering);
            Response<ExpressRouteCircuitPeeringResource> peerResponse = await peerOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", peerResponse.Value.Data.ProvisioningState.ToString());
            Response<ExpressRouteCircuitResource> getCircuitResponse = await GetResourceGroup(resourceGroupName).GetExpressRouteCircuits().GetAsync(circuitName);

            return getCircuitResponse;
        }

        public async Task<PublicIPAddressResource> CreateDefaultPublicIpAddress(string name, string domainNameLabel, string location, PublicIPAddressCollection publicIPAddressCollection)
        {
            var publicIp = new PublicIPAddressData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings() { DomainNameLabel = domainNameLabel }
            };

            // Put nic1PublicIpAddress
            Operation<PublicIPAddressResource> putPublicIpAddressOperation = await publicIPAddressCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, publicIp);
            Response<PublicIPAddressResource> putPublicIpAddressResponse = await putPublicIpAddressOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());
            Response<PublicIPAddressResource> getPublicIpAddressResponse = await publicIPAddressCollection.GetAsync(name);

            return getPublicIpAddressResponse;
        }

        public async Task<PublicIPAddressResource> CreateStaticPublicIpAddress(string name, string domainNameLabel, string location, PublicIPAddressCollection publicIPAddressCollection)
        {
            var publicIp = new PublicIPAddressData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                Sku = new PublicIPAddressSku()
                {
                    Name = PublicIPAddressSkuName.Standard,
                    Tier = PublicIPAddressSkuTier.Regional
                },
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Static,
                DnsSettings = new PublicIPAddressDnsSettings() { DomainNameLabel = domainNameLabel }
            };

            // Put nic1PublicIpAddress
            Operation<PublicIPAddressResource> putPublicIpAddressOperation = await publicIPAddressCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, publicIp);
            Response<PublicIPAddressResource> putPublicIpAddressResponse = await putPublicIpAddressOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());
            Response<PublicIPAddressResource> getPublicIpAddressResponse = await publicIPAddressCollection.GetAsync(name);

            return getPublicIpAddressResponse;
        }

        public async Task<PublicIPAddressResource> CreateDefaultPublicIpAddress(string name, string resourceGroupName, string domainNameLabel, string location)
        {
            var publicIp = new PublicIPAddressData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings() { DomainNameLabel = domainNameLabel }
            };

            // Put nic1PublicIpAddress
            var publicIPAddressCollection = GetResourceGroup(resourceGroupName).GetPublicIPAddresses();
            Operation<PublicIPAddressResource> putPublicIpAddressOperation = await publicIPAddressCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, publicIp);
            Response<PublicIPAddressResource> putPublicIpAddressResponse = await putPublicIpAddressOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());
            Response<PublicIPAddressResource> getPublicIpAddressResponse = await publicIPAddressCollection.GetAsync(name);

            return getPublicIpAddressResponse;
        }

        public async Task<NetworkInterfaceResource> CreateNetworkInterface(string name, string resourceGroupName, string publicIpAddressId, string subnetId,
            string location, string ipConfigName)
        {
            var nicParameters = new NetworkInterfaceData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                IPConfigurations = {
                    new NetworkInterfaceIPConfigurationData()
                    {
                         Name = ipConfigName,
                         PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                         Subnet = new SubnetData() { Id = new ResourceIdentifier(subnetId) }
                    }
                }
            };

            if (!string.IsNullOrEmpty(publicIpAddressId))
            {
                nicParameters.IPConfigurations[0].PublicIPAddress = new PublicIPAddressData() { /*Id = publicIpAddressId*/ };
            }

            // Test NIC apis
            var networkInterfaceCollection = GetResourceGroup(resourceGroupName).GetNetworkInterfaces();
            await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, nicParameters);
            Response<NetworkInterfaceResource> getNicResponse = await networkInterfaceCollection.GetAsync(name);
            Assert.AreEqual(getNicResponse.Value.Data.Name, name);

            // because its a single CA nic, primaryOnCA is always true
            Assert.True(getNicResponse.Value.Data.IPConfigurations[0].Primary);

            Assert.AreEqual("Succeeded", getNicResponse.Value.Data.ProvisioningState.ToString());

            return getNicResponse;
        }

        public async Task<NetworkInterfaceResource> CreateNetworkInterface(string name, string publicIpAddressId, string subnetId,
            string location, string ipConfigName, NetworkInterfaceCollection networkInterfaceCollection)
        {
            var nicParameters = new NetworkInterfaceData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                IPConfigurations = {
                    new NetworkInterfaceIPConfigurationData()
                    {
                         Name = ipConfigName,
                         PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                         Subnet = new SubnetData() { Id = new ResourceIdentifier(subnetId) }
                    }
                }
            };

            if (!string.IsNullOrEmpty(publicIpAddressId))
            {
                nicParameters.IPConfigurations[0].PublicIPAddress = new PublicIPAddressData() { /*Id = publicIpAddressId*/ };
            }

            // Test NIC apis
            var operation = InstrumentOperation(await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, nicParameters));
            await operation.WaitForCompletionAsync();
            Response<NetworkInterfaceResource> getNicResponse = await networkInterfaceCollection.GetAsync(name);
            Assert.AreEqual(getNicResponse.Value.Data.Name, name);

            // because its a single CA nic, primaryOnCA is always true
            Assert.True(getNicResponse.Value.Data.IPConfigurations[0].Primary);

            Assert.AreEqual("Succeeded", getNicResponse.Value.Data.ProvisioningState.ToString());

            return getNicResponse;
        }

        public async Task<VirtualNetworkResource> CreateVirtualNetwork(string vnetName, string subnetName, string resourceGroupName, string location)
        {
            var vnet = new VirtualNetworkData()
            {
                Location = location,

                AddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new SubnetData() { Name = subnetName, AddressPrefix = "10.0.0.0/24", } }
            };

            var virtualNetworkCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworks();
            await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet);
            Response<VirtualNetworkResource> getVnetResponse = await virtualNetworkCollection.GetAsync(vnetName);

            return getVnetResponse;
        }

        public async Task<VirtualNetworkResource> CreateVirtualNetwork(string vnetName, string subnetName, string location, VirtualNetworkCollection virtualNetworkCollection)
        {
            var vnet = new VirtualNetworkData()
            {
                Location = location,

                AddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new SubnetData() { Name = subnetName, AddressPrefix = "10.0.0.0/24", } }
            };

            await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet);
            Response<VirtualNetworkResource> getVnetResponse = await virtualNetworkCollection.GetAsync(vnetName);

            return getVnetResponse;
        }

        public static ResourceIdentifier GetChildLbResourceId(string subscriptionId, string resourceGroupName, string lbname, string childResourceType, string childResourceName)
        {
            return
                new ResourceIdentifier(string.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/{3}/{4}",
                    subscriptionId,
                    resourceGroupName,
                    lbname,
                    childResourceType,
                    childResourceName));
        }

        protected ApplicationGatewayCollection GetApplicationGatewayCollection(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetApplicationGateways();
        }

        protected LoadBalancerCollection GetLoadBalancerCollection(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetLoadBalancers();
        }

        protected LoadBalancerCollection GetLoadBalancerCollection(Resources.ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetLoadBalancers();
        }

        protected PublicIPAddressCollection GetPublicIPAddressCollection(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetPublicIPAddresses();
        }

        protected VirtualNetworkCollection GetVirtualNetworkCollection(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetVirtualNetworks();
        }

        protected VirtualNetworkCollection GetVirtualNetworkCollection(Resources.ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetVirtualNetworks();
        }

        protected NetworkInterfaceCollection GetNetworkInterfaceCollection(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetNetworkInterfaces();
        }

        protected NetworkInterfaceCollection GetNetworkInterfaceCollection(Resources.ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetNetworkInterfaces();
        }

        protected NetworkSecurityGroupCollection GetNetworkSecurityGroupCollection(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetNetworkSecurityGroups();
        }

        protected RouteTableCollection GetRouteTableCollection(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetRouteTables();
        }

        protected RouteFilterCollection GetRouteFilterCollection(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetRouteFilters();
        }

        protected NetworkWatcherCollection GetNetworkWatcherCollection(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetNetworkWatchers();
        }

        protected VirtualNetworkGatewayCollection GetVirtualNetworkGatewayCollection(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
        }

        protected async Task<BackendAddressPoolResource> GetFirstPoolAsync(LoadBalancerResource loadBalancer)
        {
            await foreach (var pool in loadBalancer.GetBackendAddressPools())
            {
                return pool;
            }
            throw new InvalidOperationException($"Pool list was empty for {loadBalancer.Id}");
        }
    }
}
