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
    public class RoleAssignmentArtifactTest : BlueprintManagementTestBase
    {
        public RoleAssignmentArtifactTest(bool isAsync) :
            base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            //prepare
            string printName = Recording.GenerateAssetName("blueprint-");
            string roleassignmentArtifactName = Recording.GenerateAssetName("roleassignmentArtifact-");
            string roleassignmentArtifactName2 = Recording.GenerateAssetName("roleassignmentArtifact-");
            string roleassignmentArtifactName3 = Recording.GenerateAssetName("roleassignmentArtifact-");
            var resourceGroup = await CreateResourceGroupAsync();
            string resourceScope = $"/subscriptions/{resourceGroup.Data.Id.SubscriptionId}";
            ResourceIdentifier scopeId = new ResourceIdentifier(string.Format("{0}", resourceScope));
            BlueprintCollection blueprintCollection = Client.GetBlueprints(scopeId);
            var printInput = ResourceDataHelpers.GetBlueprintData();
            var blueprintResource = (await blueprintCollection.CreateOrUpdateAsync(WaitUntil.Completed, printName, printInput)).Value;
            var artifactCollection = blueprintResource.GetBlueprintArtifacts();
            //CreateOrUpdate(role assignment Artifact)
            var roleAssignmentArtifactInput = ResourceDataHelpers.GetRoleAssignmentData();
            var roleAssignmentArtifactResource = (await artifactCollection.CreateOrUpdateAsync(WaitUntil.Completed, roleassignmentArtifactName, roleAssignmentArtifactInput)).Value;
            Assert.AreEqual(roleassignmentArtifactName, roleAssignmentArtifactResource.Data.Name);
            //Get
            var policy2 = (await artifactCollection.GetAsync(roleassignmentArtifactName)).Value;
            ResourceDataHelpers.AssertArtifactData(roleAssignmentArtifactResource.Data, policy2.Data);
            //GetAll
            _ = await artifactCollection.CreateOrUpdateAsync(WaitUntil.Completed, roleassignmentArtifactName2, roleAssignmentArtifactInput);
            _ = await artifactCollection.CreateOrUpdateAsync(WaitUntil.Completed, roleassignmentArtifactName3, roleAssignmentArtifactInput);
            int count = 0;
            await foreach (var availabilitySet in artifactCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exist
            Assert.IsTrue(await artifactCollection.ExistsAsync(roleassignmentArtifactName));
            Assert.IsFalse(await artifactCollection.ExistsAsync(roleassignmentArtifactName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await artifactCollection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var resource3 = (await roleAssignmentArtifactResource.GetAsync()).Value;
            ResourceDataHelpers.AssertArtifactData(roleAssignmentArtifactResource.Data, resource3.Data);
            //2. Delete
            await resource3.DeleteAsync(WaitUntil.Completed);
        }
    }
}
