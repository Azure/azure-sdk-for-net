// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [TearDown]
        public async Task ClearNamespaces()
        {
            //remove all namespaces under current resource group
            if (_resourceGroup != null)
            {
                ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
                List<ServiceBusNamespace> namespaceList = await namespaceCollection.GetAllAsync().ToEnumerableAsync();
                foreach (ServiceBusNamespace serviceBusNamespace in namespaceList)
                {
                    await serviceBusNamespace.DeleteAsync();
                }
                _resourceGroup = null;
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateGetUpdateDeleteDisasterRecovery()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            //create namespace1
            string namespaceName1 = await CreateValidNamespaceName("testnamespacemgmt");
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceData parameters1 = new ServiceBusNamespaceData(DefaultLocation)
            {
                Sku = new ServiceBusSku(SkuName.Premium)
                {
                    Tier = SkuTier.Premium,
                    Capacity = 1
                }
            };
            ServiceBusNamespace serviceBusNamespace1 = (await namespaceCollection.CreateOrUpdateAsync(namespaceName1, parameters1)).Value;

            //create namespace2 with a different location
            string namespaceName2 = await CreateValidNamespaceName("testnamespacemgmt");
            ServiceBusNamespaceData parameters2 = new ServiceBusNamespaceData(Location.EastUS)
            {
                Sku = new ServiceBusSku(SkuName.Premium)
                {
                    Tier = SkuTier.Premium,
                    Capacity = 1
                }
            };
            ServiceBusNamespace serviceBusNamespace2 = (await namespaceCollection.CreateOrUpdateAsync(namespaceName2, parameters2)).Value;

            //create authorization rule on namespace1
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            ServiceBusAuthorizationRuleData ruleParameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            NamespaceServiceBusAuthorizationRule authorizationRule = (await serviceBusNamespace1.GetNamespaceServiceBusAuthorizationRules().CreateOrUpdateAsync(ruleName, ruleParameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, ruleParameter.Rights.Count);

            //create a disaster recovery
            string disasterRecoveryName = Recording.GenerateAssetName("disasterrecovery");
            ArmDisasterRecoveryData parameter = new ArmDisasterRecoveryData()
            {
                PartnerNamespace = serviceBusNamespace2.Id
            };
            ArmDisasterRecovery armDisasterRecovery = (await serviceBusNamespace1.GetArmDisasterRecoveries().CreateOrUpdateAsync(disasterRecoveryName, parameter)).Value;
            Assert.NotNull(armDisasterRecovery);
            Assert.AreEqual(armDisasterRecovery.Id.Name, disasterRecoveryName);
            Assert.AreEqual(armDisasterRecovery.Data.PartnerNamespace, serviceBusNamespace2.Id.ToString());

            //get the disaster recovery - primary
            armDisasterRecovery = await serviceBusNamespace1.GetArmDisasterRecoveries().GetAsync(disasterRecoveryName);
            Assert.AreEqual(armDisasterRecovery.Data.Role, RoleDisasterRecovery.Primary);

            //get the disaster recovery - secondary
            ArmDisasterRecovery armDisasterRecoverySec = await serviceBusNamespace2.GetArmDisasterRecoveries().GetAsync(disasterRecoveryName);
            Assert.AreEqual(armDisasterRecoverySec.Data.Role, RoleDisasterRecovery.Secondary);

            //wait for completion, this may take several minutes in live and record mode
            armDisasterRecovery = await serviceBusNamespace1.GetArmDisasterRecoveries().GetAsync(disasterRecoveryName);
            int i = 0;
            while (armDisasterRecovery.Data.ProvisioningState != ProvisioningStateDR.Succeeded || i > 100)
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(5000);
                }
                i++;
                armDisasterRecovery = await serviceBusNamespace1.GetArmDisasterRecoveries().GetAsync(disasterRecoveryName);
            }

            //check name availability
            CheckNameAvailabilityResult nameAvailability = await serviceBusNamespace1.CheckDisasterRecoveryConfigNameAvailabilityAsync(new CheckNameAvailability(disasterRecoveryName));
            Assert.IsFalse(nameAvailability.NameAvailable);

            List<DisasterRecoveryConfigServiceBusAuthorizationRule> rules = await armDisasterRecovery.GetDisasterRecoveryConfigServiceBusAuthorizationRules().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(rules.Count > 0);

            //get access keys of the authorization rule
            DisasterRecoveryConfigServiceBusAuthorizationRule rule = rules.First();
            AccessKeys keys = await rule.GetKeysAsync();
            Assert.NotNull(keys);

            //break pairing and wait for competion
            await armDisasterRecovery.BreakPairingAsync();
            armDisasterRecovery = await serviceBusNamespace1.GetArmDisasterRecoveries().GetAsync(disasterRecoveryName);
            i = 0;
            while (armDisasterRecovery.Data.ProvisioningState != ProvisioningStateDR.Succeeded && i < 100)
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(5000);
                }
                i++;
                armDisasterRecovery = await serviceBusNamespace1.GetArmDisasterRecoveries().GetAsync(disasterRecoveryName);
            }

            //get all disaster recoveries for a name space
            List<ArmDisasterRecovery> disasterRcoveries = await serviceBusNamespace1.GetArmDisasterRecoveries().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(disasterRcoveries.Count >= 1);

            //delete disaster recovery;
            await armDisasterRecovery.DeleteAsync();
        }
    }
}
