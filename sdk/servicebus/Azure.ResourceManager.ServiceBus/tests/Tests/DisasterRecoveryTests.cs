﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.ServiceBus.Models;
using Azure.ResourceManager.ServiceBus.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceBus.Tests
{
    public class DisasterRecoveryTests : ServiceBusTestBase
    {
        private ResourceGroup _resourceGroup;
        public DisasterRecoveryTests(bool isAsync) : base(isAsync)
        {
        }
        [Test]
        [RecordedTest]
        public async Task CreateGetUpdateDeleteDisasterRecovery()
        {
            IgnoreTestInLiveMode();
            _resourceGroup = await CreateResourceGroupAsync();
            //create namespace1
            string namespaceName1 = await CreateValidNamespaceName("testnamespacemgmt");
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceData parameters1 = new ServiceBusNamespaceData(DefaultLocation)
            {
                Sku = new Models.Sku(SkuName.Premium)
                {
                    Tier = SkuTier.Premium,
                    Capacity = 1
                }
            };
            ServiceBusNamespace serviceBusNamespace1 = (await namespaceCollection.CreateOrUpdateAsync(true, namespaceName1, parameters1)).Value;

            //create namespace2 with a different location
            string namespaceName2 = await CreateValidNamespaceName("testnamespacemgmt");
            ServiceBusNamespaceData parameters2 = new ServiceBusNamespaceData(AzureLocation.EastUS)
            {
                Sku = new Models.Sku(SkuName.Premium)
                {
                    Tier = SkuTier.Premium,
                    Capacity = 1
                }
            };
            ServiceBusNamespace serviceBusNamespace2 = (await namespaceCollection.CreateOrUpdateAsync(true, namespaceName2, parameters2)).Value;

            //create authorization rule on namespace1
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            ServiceBusAuthorizationRuleData ruleParameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            NamespaceAuthorizationRule authorizationRule = (await serviceBusNamespace1.GetNamespaceAuthorizationRules().CreateOrUpdateAsync(true, ruleName, ruleParameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, ruleParameter.Rights.Count);

            //create a disaster recovery
            string disasterRecoveryName = Recording.GenerateAssetName("disasterrecovery");
            DisasterRecoveryData parameter = new DisasterRecoveryData()
            {
                PartnerNamespace = serviceBusNamespace2.Id
            };
            DisasterRecovery disasterRecovery = (await serviceBusNamespace1.GetDisasterRecoveries().CreateOrUpdateAsync(true, disasterRecoveryName, parameter)).Value;
            Assert.NotNull(disasterRecovery);
            Assert.AreEqual(disasterRecovery.Id.Name, disasterRecoveryName);
            Assert.AreEqual(disasterRecovery.Data.PartnerNamespace, serviceBusNamespace2.Id.ToString());

            //get the disaster recovery - primary
            disasterRecovery = await serviceBusNamespace1.GetDisasterRecoveries().GetAsync(disasterRecoveryName);
            Assert.AreEqual(disasterRecovery.Data.Role, RoleDisasterRecovery.Primary);

            //get the disaster recovery - secondary
            DisasterRecovery disasterRecoverySec = await serviceBusNamespace2.GetDisasterRecoveries().GetAsync(disasterRecoveryName);
            Assert.AreEqual(disasterRecoverySec.Data.Role, RoleDisasterRecovery.Secondary);

            //wait for completion, this may take several minutes in live and record mode
            disasterRecovery = await serviceBusNamespace1.GetDisasterRecoveries().GetAsync(disasterRecoveryName);
            int i = 0;
            while (disasterRecovery.Data.ProvisioningState != ProvisioningStateDisasterRecovery.Succeeded && i < 100)
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(5000);
                }
                i++;
                disasterRecovery = await serviceBusNamespace1.GetDisasterRecoveries().GetAsync(disasterRecoveryName);
            }

            //check name availability
            CheckNameAvailabilityResult nameAvailability = await serviceBusNamespace1.CheckDisasterRecoveryNameAvailabilityAsync(new CheckNameAvailability(disasterRecoveryName));
            Assert.IsFalse(nameAvailability.NameAvailable);

            List<NamespaceDisasterRecoveryAuthorizationRule> rules = await disasterRecovery.GetNamespaceDisasterRecoveryAuthorizationRules().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(rules.Count > 0);

            //get access keys of the authorization rule
            NamespaceDisasterRecoveryAuthorizationRule rule = rules.First();
            AccessKeys keys = await rule.GetKeysAsync();
            Assert.NotNull(keys);

            //break pairing and wait for competion
            await disasterRecovery.BreakPairingAsync();
            disasterRecovery = await serviceBusNamespace1.GetDisasterRecoveries().GetAsync(disasterRecoveryName);
            i = 0;
            while (disasterRecovery.Data.ProvisioningState != ProvisioningStateDisasterRecovery.Succeeded && i < 100)
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(5000);
                }
                i++;
                disasterRecovery = await serviceBusNamespace1.GetDisasterRecoveries().GetAsync(disasterRecoveryName);
            }

            //get all disaster recoveries for a name space
            List<DisasterRecovery> disasterRcoveries = await serviceBusNamespace1.GetDisasterRecoveries().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(disasterRcoveries.Count >= 1);

            //delete disaster recovery;
            await disasterRecovery.DeleteAsync(true);
        }
    }
}
