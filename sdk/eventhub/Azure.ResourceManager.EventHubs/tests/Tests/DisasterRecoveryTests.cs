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
using Azure.ResourceManager.EventHubs.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.EventHubs.Tests.Tests
{
    public class DisasterRecoveryTests : EventHubTestBase
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
                EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
                List<EHNamespace> namespaceList = await namespaceContainer.GetAllAsync().ToEnumerableAsync();
                foreach (EHNamespace eHNamespace in namespaceList)
                {
                    await eHNamespace.DeleteAsync();
                }
                _resourceGroup = null;
            }
        }
        [Test]
        [RecordedTest]
        [Ignore("error occurred")]
        public async Task CreateGetUpdateDeleteDisasterRecovery()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            //create namespace1
            string namespaceName1 = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace1 = (await namespaceContainer.CreateOrUpdateAsync(namespaceName1, new EHNamespaceData(DefaultLocation))).Value;

            //create namespace2
            string namespaceName2 = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespace eHNamespace2 = (await namespaceContainer.CreateOrUpdateAsync(namespaceName2, new EHNamespaceData(Location.EastUS))).Value;

            //create a disaster recovery
            string disaterRecoveryName = Recording.GenerateAssetName("disasterrecovery");
            ArmDisasterRecoveryData parameter = new ArmDisasterRecoveryData()
            {
                PartnerNamespace = eHNamespace2.Id
            };
            ArmDisasterRecovery armDisasterRecovery = (await eHNamespace1.GetArmDisasterRecoveries().CreateOrUpdateAsync(disaterRecoveryName, parameter)).Value;
            Assert.NotNull(armDisasterRecovery);
            Assert.AreEqual(armDisasterRecovery.Id.Name, disaterRecoveryName);
            Assert.AreEqual(armDisasterRecovery.Data.PartnerNamespace, eHNamespace2.Id.ToString());

            //get the disaster recovery - primary
            armDisasterRecovery = await eHNamespace1.GetArmDisasterRecoveries().GetAsync(disaterRecoveryName);
            Assert.AreEqual(armDisasterRecovery.Data.Role, RoleDisasterRecovery.Primary);

            //get the disaster recovery - secondary
            ArmDisasterRecovery armDisasterRecoverySec = await eHNamespace2.GetArmDisasterRecoveries().GetAsync(disaterRecoveryName);
            Assert.AreEqual(armDisasterRecoverySec.Data.Role, RoleDisasterRecovery.Secondary);

            //break pairing
            await armDisasterRecovery.BreakPairingAsync();

            //fail over
            await armDisasterRecovery.FailOverAsync();

            //get all disaster recoveries for a name space
            List<ArmDisasterRecovery> disaterRcoveries = await eHNamespace1.GetArmDisasterRecoveries().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(disaterRcoveries.Count >= 1);

            //delete disaster recovery;
            await armDisasterRecovery.DeleteAsync();
        }
    }
}
