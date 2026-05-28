// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using System.Linq;
using System.Collections.Generic;

namespace Azure.ResourceManager.DnsResolver.Tests
{
    public class DnsSecurityRuleTests : DnsResolverTestBase
    {
        private DnsResolverPolicyCollection _dnsResolverPolicyCollection;
        private DnsResolverDomainListCollection _dnsResolverDomainListCollection;
        private DnsResolverPolicyResource _dnsResolverPolicy;
        private DnsResolverDomainListResource _dnsResolverDomainList;
        private string _dnsResolverPolicyName;
        private string _dnsResolverDomainListName;

        public DnsSecurityRuleTests(bool async) : base(async)//, RecordedTestMode.Record)
        {
        }

        public async Task CreateDnsResolverCollection()
        {
            _dnsResolverPolicyName = Recording.GenerateAssetName("dnsResolverPolicy-");
            _dnsResolverDomainListName = Recording.GenerateAssetName("dnsResolverDomainList-");
            var resourceGroup = await CreateResourceGroupAsync();
            _dnsResolverPolicyCollection = resourceGroup.GetDnsResolverPolicies();
            _dnsResolverDomainListCollection = resourceGroup.GetDnsResolverDomainLists();

            _dnsResolverPolicy = await CreateDnsResolverPolicy(_dnsResolverPolicyName);
            _dnsResolverDomainList = await CreateDnsResolverDomainList(_dnsResolverDomainListName);
        }

        private async Task<DnsResolverPolicyResource> CreateDnsResolverPolicy(string dnsResolverPolicyName)
        {
            var dnsResolverPolicyData = new DnsResolverPolicyData(this.DefaultLocation);

            return (await _dnsResolverPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverPolicyName, dnsResolverPolicyData)).Value;
        }

        private async Task<DnsResolverDomainListResource> CreateDnsResolverDomainList(string dnsResolverDomainListName)
        {
            var dnsResolverDomainListData = new DnsResolverDomainListData(this.DefaultLocation);
            dnsResolverDomainListData.Domains.Add("test.com.");
            dnsResolverDomainListData.Domains.Add("env.com.");

            return (await _dnsResolverDomainListCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverDomainListName, dnsResolverDomainListData)).Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateDnsSecurityRule()
        {
            // ARRANGE
            var dnsSecurityRuleName = Recording.GenerateAssetName("dnsSecurityRule-");
            await CreateDnsResolverCollection();
            var dnsSecurityRuleAction = new DnsSecurityRuleAction() { ActionType = DnsSecurityRuleActionType.Block };

            var dnsSecurityRuleData = new DnsSecurityRuleData(this.DefaultLocation, this.DefaultDnsSecurityRulePriority, dnsSecurityRuleAction,
                new List<WritableSubResource> {
                    new WritableSubResource
                    {
                        Id = new ResourceIdentifier(_dnsResolverDomainList.Id),
                    }
                }
            );

            // ACT
            var createdDnsSecurityRule = await _dnsResolverPolicy.GetDnsSecurityRules().CreateOrUpdateAsync(WaitUntil.Completed, dnsSecurityRuleName, dnsSecurityRuleData);

            // ASSERT
            Assert.AreEqual(createdDnsSecurityRule.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetDnsSecurityRule()
        {
            // ARRANGE
            var dnsSecurityRuleName = Recording.GenerateAssetName("dnsSecurityRule-");
            await CreateDnsResolverCollection();
            var dnsSecurityRuleAction = new DnsSecurityRuleAction() { ActionType = DnsSecurityRuleActionType.Block };

            var dnsSecurityRuleData = new DnsSecurityRuleData(this.DefaultLocation, this.DefaultDnsSecurityRulePriority, dnsSecurityRuleAction,
                new List<WritableSubResource> {
                    new WritableSubResource
                    {
                        Id = new ResourceIdentifier(_dnsResolverDomainList.Id),
                    }
                }
            );

            await _dnsResolverPolicy.GetDnsSecurityRules().CreateOrUpdateAsync(WaitUntil.Completed, dnsSecurityRuleName, dnsSecurityRuleData);

            // ACT
            var retrievedDnsSecurityRule = await _dnsResolverPolicy.GetDnsSecurityRules().GetAsync(dnsSecurityRuleName);

            // ASSERT
            Assert.AreEqual(retrievedDnsSecurityRule.Value.Data.Name, dnsSecurityRuleName);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateDnsSecurityRule()
        {
            // ARRANGE
            var dnsSecurityRuleName = Recording.GenerateAssetName("dnsSecurityRule-");
            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");
            await CreateDnsResolverCollection();
            var dnsSecurityRuleAction = new DnsSecurityRuleAction() { ActionType = DnsSecurityRuleActionType.Block };

            var dnsSecurityRuleData = new DnsSecurityRuleData(this.DefaultLocation, this.DefaultDnsSecurityRulePriority, dnsSecurityRuleAction,
                new List<WritableSubResource> {
                    new WritableSubResource
                    {
                        Id = new ResourceIdentifier(_dnsResolverDomainList.Id),
                    }
                }
            );

            var createdDnsSecurityRule = await _dnsResolverPolicy.GetDnsSecurityRules().CreateOrUpdateAsync(WaitUntil.Completed, dnsSecurityRuleName, dnsSecurityRuleData);

            var patchableDnsSecurityRuleData = new DnsSecurityRulePatch();
            patchableDnsSecurityRuleData.Tags.Add(newTagKey, newTagValue);

            // ACT
            var patchedDnsSecurityRule = await createdDnsSecurityRule.Value.UpdateAsync(WaitUntil.Completed, patchableDnsSecurityRuleData);

            // ASSERT
            CollectionAssert.AreEquivalent(patchedDnsSecurityRule.Value.Data.Tags, patchableDnsSecurityRuleData.Tags);
        }

        [Test]
        [RecordedTest]
        public async Task RemoveDnsSecurityRule()
        {
            // ARRANGE
            var dnsSecurityRuleName = Recording.GenerateAssetName("dnsSecurityRule-");
            await CreateDnsResolverCollection();
            var dnsSecurityRuleAction = new DnsSecurityRuleAction() { ActionType = DnsSecurityRuleActionType.Block };

            var dnsSecurityRuleData = new DnsSecurityRuleData(this.DefaultLocation, this.DefaultDnsSecurityRulePriority, dnsSecurityRuleAction,
                new List<WritableSubResource> {
                    new WritableSubResource
                    {
                        Id = new ResourceIdentifier(_dnsResolverDomainList.Id),
                    }
                }
            );

            var createdDnsSecurityRule = await _dnsResolverPolicy.GetDnsSecurityRules().CreateOrUpdateAsync(WaitUntil.Completed, dnsSecurityRuleName, dnsSecurityRuleData);

            // ACT
            await createdDnsSecurityRule.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getDnsSecurityRule = await _dnsResolverPolicy.GetDnsSecurityRules().ExistsAsync(dnsSecurityRuleName);
            Assert.AreEqual(getDnsSecurityRule.Value, false);
        }
    }
}
