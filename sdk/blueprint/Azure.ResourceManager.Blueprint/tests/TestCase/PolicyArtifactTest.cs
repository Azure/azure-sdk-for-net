// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Blueprint;
using Azure.ResourceManager.Blueprint.Models;
using NUnit.Framework;
using Azure.ResourceManager.Blueprint.Tests.Helpers;
using System;

namespace Azure.ResourceManager.Blueprint.Tests
{
    public class PolicyArtifactTest : BlueprintManagementTestBase
    {
        public PolicyArtifactTest(bool isAsync) :
            base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            //prepare
            string printName = Recording.GenerateAssetName("blueprint-");
            string policyArtifactName = Recording.GenerateAssetName("policyArtifact-");
            string policyArtifactName2 = Recording.GenerateAssetName("policyArtifact-");
            string policyArtifactName3 = Recording.GenerateAssetName("policyArtifact-");
            var resourceGroup = await CreateResourceGroupAsync();
            string resourceScope = $"/subscriptions/{resourceGroup.Data.Id.SubscriptionId}";
            ResourceIdentifier scopeId = new ResourceIdentifier(string.Format("{0}", resourceScope));
            BlueprintCollection blueprintCollection = Client.GetBlueprints(scopeId);
            var printInput = ResourceDataHelpers.GetBlueprintData();
            var blueprintResource = (await blueprintCollection.CreateOrUpdateAsync(WaitUntil.Completed, printName, printInput)).Value;
            var artifactCollection = blueprintResource.GetBlueprintArtifacts();
            //CreateOrUpdate(policy assignment Artifact)
            var policyAssignmentArtifactInput = ResourceDataHelpers.GetPolicyAssignmentArtifactData();
            var policyAssignmentArtifactResource = (await artifactCollection.CreateOrUpdateAsync(WaitUntil.Completed, policyArtifactName, policyAssignmentArtifactInput)).Value;
            Assert.AreEqual(policyArtifactName, policyAssignmentArtifactResource.Data.Name);
            //Get
            var policy2 = (await artifactCollection.GetAsync(policyArtifactName)).Value;
            ResourceDataHelpers.AssertArtifactData(policyAssignmentArtifactResource.Data, policy2.Data);
            //GetAll
            _ = await artifactCollection.CreateOrUpdateAsync(WaitUntil.Completed, policyArtifactName2, policyAssignmentArtifactInput);
            _ = await artifactCollection.CreateOrUpdateAsync(WaitUntil.Completed, policyArtifactName3, policyAssignmentArtifactInput);
            int count = 0;
            await foreach (var num in artifactCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exist
            Assert.IsTrue(await artifactCollection.ExistsAsync(policyArtifactName));
            Assert.IsFalse(await artifactCollection.ExistsAsync(policyArtifactName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await artifactCollection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var resource3 = (await policyAssignmentArtifactResource.GetAsync()).Value;
            ResourceDataHelpers.AssertArtifactData(policyAssignmentArtifactResource.Data, resource3.Data);
            //2. Delete
            await resource3.DeleteAsync(WaitUntil.Completed);
        }
    }
}
