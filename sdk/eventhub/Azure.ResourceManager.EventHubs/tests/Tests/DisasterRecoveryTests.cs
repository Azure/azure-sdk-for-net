// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class DisasterRecoveryTests : EventHubTestBase
    {
        private ResourceGroupResource _resourceGroup;
        public DisasterRecoveryTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetUpdateDeleteDisasterRecovery()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            //create namespace1
            string namespaceName1 = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            EventHubsNamespaceResource eHNamespace1 = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName1, new EventHubsNamespaceData(DefaultLocation))).Value;

            //create namespace2 with a different location
            string namespaceName2 = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eHNamespace2 = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName2, new EventHubsNamespaceData(AzureLocation.EastUS))).Value;

            //create authorization rule on namespace1
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            EventHubsAuthorizationRuleData ruleParameter = new EventHubsAuthorizationRuleData()
            {
                Rights = { EventHubsAccessRight.Listen, EventHubsAccessRight.Send }
            };
            EventHubsNamespaceAuthorizationRuleResource authorizationRule = (await eHNamespace1.GetEventHubsNamespaceAuthorizationRules().CreateOrUpdateAsync(WaitUntil.Completed, ruleName, ruleParameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, ruleParameter.Rights.Count);

            //create a disaster recovery
            string disasterRecoveryName = Recording.GenerateAssetName("disasterrecovery");
            EventHubsDisasterRecoveryData parameter = new EventHubsDisasterRecoveryData()
            {
                PartnerNamespace = eHNamespace2.Id
            };
            EventHubsDisasterRecoveryResource armDisasterRecovery = (await eHNamespace1.GetEventHubsDisasterRecoveries().CreateOrUpdateAsync(WaitUntil.Completed, disasterRecoveryName, parameter)).Value;
            Assert.NotNull(armDisasterRecovery);
            Assert.AreEqual(armDisasterRecovery.Id.Name, disasterRecoveryName);
            Assert.AreEqual(armDisasterRecovery.Data.PartnerNamespace, eHNamespace2.Id.ToString());

            //get the disaster recovery - primary
            armDisasterRecovery = await eHNamespace1.GetEventHubsDisasterRecoveries().GetAsync(disasterRecoveryName);
            Assert.AreEqual(armDisasterRecovery.Data.Role, EventHubsDisasterRecoveryRole.Primary);

            //get the disaster recovery - secondary
            EventHubsDisasterRecoveryResource armDisasterRecoverySec = await eHNamespace2.GetEventHubsDisasterRecoveries().GetAsync(disasterRecoveryName);
            Assert.AreEqual(armDisasterRecoverySec.Data.Role, EventHubsDisasterRecoveryRole.Secondary);

            //wait for completion, this may take several minutes in live and record mode
            armDisasterRecovery = await eHNamespace1.GetEventHubsDisasterRecoveries().GetAsync(disasterRecoveryName);
            int i = 0;
            while (armDisasterRecovery.Data.ProvisioningState != EventHubsDisasterRecoveryProvisioningState.Succeeded && i < 100)
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(5000);
                }
                i++;
                armDisasterRecovery = await eHNamespace1.GetEventHubsDisasterRecoveries().GetAsync(disasterRecoveryName);
            }
            System.Console.WriteLine(i);

            //check name availability
            EventHubsNameAvailabilityResult nameAvailability = await eHNamespace1.CheckEventHubsDisasterRecoveryNameAvailabilityAsync(new EventHubsNameAvailabilityContent(disasterRecoveryName));
            Assert.IsFalse(nameAvailability.NameAvailable);

            List<EventHubsDisasterRecoveryAuthorizationRuleResource> rules = await armDisasterRecovery.GetEventHubsDisasterRecoveryAuthorizationRules().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(rules.Count > 0);

            //get access keys of the authorization rule
            EventHubsDisasterRecoveryAuthorizationRuleResource rule = rules.First();
            EventHubsAccessKeys keys = await rule.GetKeysAsync();
            Assert.NotNull(keys);

            //break pairing and wait for completion
            await armDisasterRecovery.BreakPairingAsync();
            armDisasterRecovery = await eHNamespace1.GetEventHubsDisasterRecoveries().GetAsync(disasterRecoveryName);
            i = 0;
            while (armDisasterRecovery.Data.ProvisioningState != EventHubsDisasterRecoveryProvisioningState.Succeeded && i < 100)
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(5000);
                }
                i++;
                armDisasterRecovery = await eHNamespace1.GetEventHubsDisasterRecoveries().GetAsync(disasterRecoveryName);
            }

            //get all disaster recoveries for a name space
            List<EventHubsDisasterRecoveryResource> disasterRcoveries = await eHNamespace1.GetEventHubsDisasterRecoveries().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(disasterRcoveries.Count >= 1);

            //delete disaster recovery;
            await armDisasterRecovery.DeleteAsync(WaitUntil.Completed);
        }
    }
}
