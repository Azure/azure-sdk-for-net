// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class FirewallPolicyTests : NetworkServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private VirtualNetworkResource _network;
        private PublicIPAddressResource _publicIPAddress;
        private AzureFirewallResource _firewall;

        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _networkIdentifier;
        private ResourceIdentifier _publicIPAddressIdentifier;
        private ResourceIdentifier _firewallIdentifier;

        private string _firewallLocation;
        private string _policyLocation;

        public FirewallPolicyTests(bool isAsync)
            : base(isAsync) { }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            _firewallLocation = AzureLocation.WestUS2;
            SubscriptionResource subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            var rgLro = await subscription
                .GetResourceGroups()
                .CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    SessionRecording.GenerateAssetName("FirewallPolicyRG-"),
                    new ResourceGroupData(_firewallLocation)
                );
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;

            VirtualNetworkData vnetData = new VirtualNetworkData()
            {
                Location = _firewallLocation,
                AddressSpace = new VirtualNetworkAddressSpace() { AddressPrefixes = { "10.26.0.0/16", } },
                Subnets =
                {
                    new SubnetData() { Name = "Default", AddressPrefix = "10.26.1.0/26", },
                    new SubnetData()
                    {
                        Name = "AzureFirewallSubnet",
                        AddressPrefix = "10.26.2.0/26",
                    },
                },
            };
            var vnetLro = await rg.GetVirtualNetworks()
                .CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    SessionRecording.GenerateAssetName("vnet-"),
                    vnetData
                );
            _network = vnetLro.Value;
            _networkIdentifier = _network.Id;

            PublicIPAddressData ipData = new PublicIPAddressData()
            {
                Location = _firewallLocation,
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Static,
                Sku = new PublicIPAddressSku() { Name = PublicIPAddressSkuName.Standard },
            };
            var ipLro = await rg.GetPublicIPAddresses()
                .CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    SessionRecording.GenerateAssetName("publicIp-"),
                    ipData
                );
            _publicIPAddress = ipLro.Value;
            _publicIPAddressIdentifier = _publicIPAddress.Id;

            AzureFirewallData firewallData = new AzureFirewallData();
            firewallData.Location = _firewallLocation;
            firewallData.IPConfigurations.Add(
                new AzureFirewallIPConfiguration()
                {
                    Name = "fwpip",
                    PublicIPAddress = new WritableSubResource() { Id = _publicIPAddressIdentifier },
                    Subnet = new WritableSubResource()
                    {
                        Id = _networkIdentifier.AppendChildResource(
                            "subnets",
                            "AzureFirewallSubnet"
                        )
                    },
                }
            );
            var firewallLro = await rg.GetAzureFirewalls()
                .CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    SessionRecording.GenerateAssetName("firewall-"),
                    firewallData
                );
            _firewall = firewallLro.Value;
            _firewallIdentifier = _firewall.Id;

            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client
                .GetResourceGroupResource(_resourceGroupIdentifier)
                .GetAsync();
            _network = await _resourceGroup.GetVirtualNetworks().GetAsync(_networkIdentifier.Name);
            _publicIPAddress = await _resourceGroup
                .GetPublicIPAddresses()
                .GetAsync(_publicIPAddressIdentifier.Name);
            _firewall = await _resourceGroup.GetAzureFirewalls().GetAsync(_firewallIdentifier.Name);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to research how to associate with firewalls")]
        public async Task CreateOrUpdate()
        {
            string FirewallPolicyName = Recording.GenerateAssetName("policy-");
            FirewallPolicyData data = new FirewallPolicyData();
            data.Location = AzureLocation.WestUS2;
            await _resourceGroup
                .GetFirewallPolicies()
                .CreateOrUpdateAsync(WaitUntil.Completed, FirewallPolicyName, data);
        }

        [Test]
        [RecordedTest]
        public async Task CreateAndDeployDraft()
        {
            _policyLocation = AzureLocation.CanadaCentral;
            var policyName = Recording.GenerateAssetName("policy-");
            var policyData = new FirewallPolicyData();
            policyData.SkuTier = FirewallPolicySkuTier.Standard;
            policyData.Location = _policyLocation;
            policyData.ThreatIntelMode = AzureFirewallThreatIntelMode.Alert;
            var policy = await _resourceGroup
                .GetFirewallPolicies()
                .CreateOrUpdateAsync(WaitUntil.Completed, policyName, policyData);
            Assert.AreEqual(FirewallPolicySkuTier.Standard.ToString(), policy.Value.Data.Sku.Tier.ToString());
            Assert.AreEqual(AzureFirewallThreatIntelMode.Alert.ToString(), policy.Value.Data.ThreatIntelMode.ToString());
            var rcg = new FirewallPolicyRuleCollectionGroupData()
            {
                Priority = 110,
                RuleCollections =
                {
                    new FirewallPolicyFilterRuleCollectionInfo()
                    {
                        ActionType = FirewallPolicyFilterRuleCollectionActionType.Deny,
                        Rules =
                        {
                            new ApplicationRule()
                            {
                                SourceAddresses = { "216.58.216.164", "10.0.0.0/24" },
                                Protocols =
                                {
                                    new FirewallPolicyRuleApplicationProtocol()
                                    {
                                        ProtocolType =
                                            FirewallPolicyRuleApplicationProtocolType.Https,
                                        Port = 443,
                                    }
                                },
                                WebCategories = { "Hacking" },
                                Name = "rule1",
                                Description = "Deny inbound rule",
                            }
                        },
                        Name = "RuleCollectionGroup",
                    }
                }
            };
            var policyResource = await _resourceGroup.GetFirewallPolicies().GetAsync(policyName);
            var client = GetArmClient();
            var rcgResponse = await client
                .GetFirewallPolicyRuleCollectionGroupResource(FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier(_resourceGroupIdentifier.SubscriptionId, _resourceGroupIdentifier.Name, policyName, "RuleCollectionGroup"))
                .UpdateAsync(WaitUntil.Completed, rcg);
            Assert.AreEqual(
                rcgResponse.Value.Data.ProvisioningState.ToString(),
                NetworkProvisioningState.Succeeded.ToString()
            );
            var policyDraft = new FirewallPolicyDraftData()
            {
                ThreatIntelMode = AzureFirewallThreatIntelMode.Deny,
            };
            var draftResource = new FirewallPolicyDraftResource(client, FirewallPolicyDraftResource.CreateResourceIdentifier(_resourceGroupIdentifier.SubscriptionId, _resourceGroupIdentifier.Name, policyName));
            await draftResource.CreateOrUpdateAsync(WaitUntil.Completed, policyDraft);
            var rcgPolicyDraft = new FirewallPolicyRuleCollectionGroupDraftData()
            {
                Priority = 111,
                RuleCollections =
                {
                    new FirewallPolicyFilterRuleCollectionInfo()
                    {
                        ActionType = FirewallPolicyFilterRuleCollectionActionType.Deny,
                        Rules =
                        {
                            new ApplicationRule()
                            {
                                SourceAddresses = { "*" },
                                Protocols =
                                {
                                    new FirewallPolicyRuleApplicationProtocol()
                                    {
                                        ProtocolType =
                                            FirewallPolicyRuleApplicationProtocolType.Https,
                                        Port = 443,
                                    }
                                },
                                WebCategories = { "Hacking" },
                                Name = "rule1",
                                Description = "Deny inbound rule",
                            }
                        },
                        Name = "RuleCollectionGroup",
                    }
                }
            };
            var rcgDraftResource = new FirewallPolicyRuleCollectionGroupDraftResource(
                client,
                FirewallPolicyRuleCollectionGroupDraftResource.CreateResourceIdentifier(_resourceGroupIdentifier.SubscriptionId, _resourceGroupIdentifier.Name, policyName, "RuleCollectionGroup")
            );
            await rcgDraftResource.CreateOrUpdateAsync(WaitUntil.Completed, rcgPolicyDraft);
            await policyResource.Value.DeployFirewallPolicyDeploymentAsync(WaitUntil.Completed);
            var updatedPolicy = await _resourceGroup.GetFirewallPolicies().GetAsync(policyName);
            Assert.AreEqual(
                updatedPolicy.Value.Data.ThreatIntelMode.ToString(),
                AzureFirewallThreatIntelMode.Deny.ToString()
            );
            Assert.AreEqual(
                updatedPolicy.Value.Data.ProvisioningState.ToString(),
                NetworkProvisioningState.Succeeded.ToString()
            );
            var updatedRcg = await updatedPolicy.Value.GetFirewallPolicyRuleCollectionGroupAsync(
                "RuleCollectionGroup"
            );
            Assert.AreEqual(
                updatedRcg.Value.Data.ProvisioningState.ToString(),
                NetworkProvisioningState.Succeeded.ToString()
            );
            Assert.AreEqual(updatedRcg.Value.Data.Priority, 111);
            var ruleCollection = (FirewallPolicyFilterRuleCollectionInfo)
                updatedRcg.Value.Data.RuleCollections[0];
            var rule = (ApplicationRule)ruleCollection.Rules[0];
            Assert.AreEqual(rule.SourceAddresses[0], "*");
        }
    }
}
