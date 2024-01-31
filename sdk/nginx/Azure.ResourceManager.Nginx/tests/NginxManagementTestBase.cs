// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Nginx.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Nginx.Tests
{
    public class NginxManagementTestBase : ManagementRecordedTestBase<NginxManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation Location { get; set; }
        protected string ResourceGroupPrefix { get; set; }
        protected SubscriptionResource Subscription { get; set; }
        protected string NginxDeploymentResourceType { get; set; }
        protected string NginxConfigurationContent { get; set; }

        protected NginxManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            IgnoreNetworkDependencyVersions();
            IgnoreTestInLiveMode();
        }

        protected NginxManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreNetworkDependencyVersions();
            IgnoreTestInLiveMode();
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Location = AzureLocation.WestCentralUS;
            ResourceGroupPrefix = "Default-Nginx-";
            NginxDeploymentResourceType = "NGINX.NGINXPLUS/nginxDeployments";
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
            NginxConfigurationContent = "aHR0cCB7CiAgICBzZXJ2ZXIgewogICAgICAgIGxpc3RlbiA4MDsKICAgICAgICBsb2NhdGlvbiAvIHsKICAgICAgICAgICAgZGVmYXVsdF90eXBlIHRleHQvaHRtbDsKICAgICAgICAgICAgcmV0dXJuIDIwMCAnPCFET0NUWVBFIGh0bWw+PGgxIHN0eWxlPSJmb250LXNpemU6MzBweDsiPk5naW54IGNvbmZpZyBpcyB3b3JraW5nITwvaDE+JzsKICAgICAgICB9CiAgICB9Cn0=";
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string resourceGroupNamePrefix, AzureLocation location)
        {
            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }

            if (resourceGroupNamePrefix == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupNamePrefix));
            }

            string rgName = Recording.GenerateAssetName(resourceGroupNamePrefix);
            ResourceGroupData input = new(location);
            ArmOperation<ResourceGroupResource> lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<NetworkSecurityGroupResource> CreateNetworkSecurityGroup(ResourceGroupResource resourceGroup, AzureLocation location)
        {
            if (resourceGroup == null)
            {
                throw new ArgumentNullException(nameof(resourceGroup));
            }

            SecurityRuleData rule100 = new SecurityRuleData
            {
                Name = "http",
                Priority = 100,
                Access = SecurityRuleAccess.Allow,
                Direction = SecurityRuleDirection.Inbound,
                SourceAddressPrefix = "*",
                SourcePortRange = "*",
                DestinationAddressPrefix = "*",
                Protocol = SecurityRuleProtocol.Asterisk
            };
            rule100.DestinationPortRanges.Add("80");

            SecurityRuleData rule103 = new SecurityRuleData
            {
                Name = "NRMS-Rule-103",
                Priority = 103,
                Access = SecurityRuleAccess.Allow,
                Direction = SecurityRuleDirection.Inbound,
                SourceAddressPrefix = "CorpNetPublic",
                SourcePortRange = "*",
                DestinationAddressPrefix = "*",
                DestinationPortRange = "*",
                Protocol = SecurityRuleProtocol.Asterisk,
                Description = "Created by Azure Core Security managed policy, rule can be deleted but do not change source ips, please see aka.ms/cainsgpolicy"
            };

            NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData
            {
                Location = location,
                SecurityRules =
                {
                    rule100,
                    rule103
                }
            };

            string nsgName = Recording.GenerateAssetName("testNSG-");
            ArmOperation<NetworkSecurityGroupResource> lro = await resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(WaitUntil.Completed, nsgName, networkSecurityGroupData);
            return lro.Value;
        }

        protected async Task<VirtualNetworkResource> CreateVirtualNetwork(ResourceGroupResource resourceGroup, AzureLocation location, NetworkSecurityGroupData networkSecurityGroupData)
        {
            if (resourceGroup == null)
            {
                throw new ArgumentNullException(nameof(resourceGroup));
            }

            if (networkSecurityGroupData == null)
            {
                throw new ArgumentNullException(nameof(networkSecurityGroupData));
            }

            ServiceDelegation delegation = new ServiceDelegation
            {
                Name = NginxDeploymentResourceType,
                ServiceName = NginxDeploymentResourceType
            };

            string subnetName = Recording.GenerateAssetName("testSubnet-");
            SubnetData subnetData = new SubnetData
            {
                Name = subnetName,
                AddressPrefix = "10.0.2.0/24",
                NetworkSecurityGroup = networkSecurityGroupData,
                Delegations =
                {
                    delegation
                },
                PrivateEndpointNetworkPolicy = VirtualNetworkPrivateEndpointNetworkPolicy.Enabled,
                PrivateLinkServiceNetworkPolicy = VirtualNetworkPrivateLinkServiceNetworkPolicy.Enabled
            };

            VirtualNetworkData virtualNetworkData = new VirtualNetworkData
            {
                Location = location,
                AddressPrefixes = { "10.0.0.0/16" },
                Subnets =
                {
                    subnetData
                }
            };

            string vnetName = Recording.GenerateAssetName("testVNet-");
            ArmOperation<VirtualNetworkResource> lro = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, virtualNetworkData);
            return lro.Value;
        }

        protected static ResourceIdentifier GetSubnetId(VirtualNetworkResource vnet)
        {
            if (vnet == null)
            {
                throw new ArgumentNullException(nameof(vnet));
            }

            return new ResourceIdentifier(vnet.Data.Subnets.FirstOrDefault().Id);
        }

        protected async Task<PublicIPAddressResource> CreatePublicIP(ResourceGroupResource resourceGroup, AzureLocation location)
        {
            if (resourceGroup == null)
            {
                throw new ArgumentNullException(nameof(resourceGroup));
            }

            PublicIPAddressSku sku = new PublicIPAddressSku
            {
                Name = PublicIPAddressSkuName.Standard
            };

            PublicIPAddressData publicIPAddressData = new PublicIPAddressData
            {
                Sku = sku,
                PublicIPAddressVersion = NetworkIPVersion.IPv4,
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Static,
                Location = location
            };
            string publicIPName = Recording.GenerateAssetName("testPublicIP-");
            ArmOperation<PublicIPAddressResource> lro = await resourceGroup.GetPublicIPAddresses().CreateOrUpdateAsync(WaitUntil.Completed, publicIPName, publicIPAddressData);
            return lro.Value;
        }

        protected static string GetPublicIPAddress(PublicIPAddressResource publicIP)
        {
            if (publicIP == null)
            {
                throw new ArgumentNullException(nameof(publicIP));
            }

            return publicIP.Data.IPAddress;
        }

        protected async Task<NginxDeploymentResource> CreateNginxDeployment(ResourceGroupResource resourceGroup, AzureLocation location, string nginxDeploymentName)
        {
            if (resourceGroup == null)
            {
                throw new ArgumentNullException(nameof(resourceGroup));
            }

            if (nginxDeploymentName == null)
            {
                throw new ArgumentNullException(nameof(nginxDeploymentName));
            }

            PublicIPAddressResource publicIP = await CreatePublicIP(resourceGroup, location);
            NginxFrontendIPConfiguration frontEndIPConfiguration = new NginxFrontendIPConfiguration();
            frontEndIPConfiguration.PublicIPAddresses.Add(new WritableSubResource
            {
                Id = publicIP.Data.Id
            });

            NetworkSecurityGroupResource nsg = await CreateNetworkSecurityGroup(resourceGroup, location);
            VirtualNetworkResource vnet = await CreateVirtualNetwork(resourceGroup, location, nsg.Data);
            ResourceIdentifier subnetId = GetSubnetId(vnet);

            NginxNetworkProfile networkProfile = new NginxNetworkProfile
            {
                FrontEndIPConfiguration = frontEndIPConfiguration,
                NetworkInterfaceSubnetId = subnetId
            };

            NginxDeploymentProperties deploymentProperties = new NginxDeploymentProperties
            {
                NetworkProfile = networkProfile,
                EnableDiagnosticsSupport = true,
                ScalingCapacity = 10,
                UserPreferredEmail = "test@mail.com"
            };

            ManagedServiceIdentity identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            identity.UserAssignedIdentities.Add(new ResourceIdentifier(TestEnvironment.ManagedIdentityResourceID), new UserAssignedIdentity());

            NginxDeploymentData nginxDeploymentData = new NginxDeploymentData(location)
            {
                Identity = identity,
                Properties = deploymentProperties,
                SkuName = "standard_Monthly"
            };
            ArmOperation<NginxDeploymentResource> lro = await resourceGroup.GetNginxDeployments().CreateOrUpdateAsync(WaitUntil.Completed, nginxDeploymentName, nginxDeploymentData);
            return lro.Value;
        }

        protected async Task<NginxConfigurationResource> CreateNginxConfiguration(AzureLocation location, NginxDeploymentResource nginxDeployment, string nginxConfigurationName, string virtualPath)
        {
            if (nginxDeployment == null)
            {
                throw new ArgumentNullException(nameof(nginxDeployment));
            }

            if (nginxConfigurationName == null)
            {
                throw new ArgumentNullException(nameof(nginxConfigurationName));
            }

            NginxConfigurationFile rootConfigFile = new NginxConfigurationFile
            {
                Content = NginxConfigurationContent,
                VirtualPath = virtualPath
            };

            NginxConfigurationProperties configurationProperties = new NginxConfigurationProperties
            {
                RootFile = rootConfigFile.VirtualPath
            };
            configurationProperties.Files.Add(rootConfigFile);

            NginxConfigurationData nginxConfigurationData = new NginxConfigurationData
            {
                Location = location,
                Properties = configurationProperties
            };
            ArmOperation<NginxConfigurationResource> lro = await nginxDeployment.GetNginxConfigurations().CreateOrUpdateAsync(WaitUntil.Completed, nginxConfigurationName, nginxConfigurationData);
            return lro.Value;
        }

        protected async Task<NginxCertificateResource> CreateNginxCertificate(AzureLocation location, NginxDeploymentResource nginxDeployment, string nginxCertificateName, string certificateVirtualPath, string keyVirtualPath)
        {
            if (nginxDeployment == null)
            {
                throw new ArgumentNullException(nameof(nginxDeployment));
            }

            if (nginxCertificateName == null)
            {
                throw new ArgumentNullException(nameof(nginxCertificateName));
            }

            NginxCertificateProperties certificateProperties = new NginxCertificateProperties
            {
                CertificateVirtualPath = certificateVirtualPath,
                KeyVirtualPath = keyVirtualPath,
                KeyVaultSecretId = TestEnvironment.KeyVaultSecretId
            };

            NginxCertificateData nginxCertificateData = new NginxCertificateData
            {
                Location = location,
                Properties = certificateProperties
            };
            ArmOperation<NginxCertificateResource> lro = await nginxDeployment.GetNginxCertificates().CreateOrUpdateAsync(WaitUntil.Completed, nginxCertificateName, nginxCertificateData);
            return lro.Value;
        }

        private void IgnoreTestInLiveMode()
        {
            if (Mode == RecordedTestMode.Live)
            {
                Assert.Ignore();
            }
        }
    }
}
