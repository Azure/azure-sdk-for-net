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
    public class BlueprintTemplateArtifactTest : BlueprintManagementTestBase
    {
        public BlueprintTemplateArtifactTest(bool isAsync) :
            base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task CreateOrUpdateTests()
        {
            //prepare
            string printName = Recording.GenerateAssetName("blueprint-");
            string templateArtifactName = Recording.GenerateAssetName("templateartifact-");
            string templateArtifactName2 = Recording.GenerateAssetName("templateartifact-");
            string templateArtifactName3 = Recording.GenerateAssetName("templateartifact-");
            var resourceGroup = await CreateResourceGroupAsync();
            string resourceScope = $"/subscriptions/{resourceGroup.Data.Id.SubscriptionId}";
            ResourceIdentifier scopeId = new ResourceIdentifier(string.Format("{0}", resourceScope));
            BlueprintCollection blueprintCollection = Client.GetBlueprints(scopeId);
            var printInput = ResourceDataHelpers.GetBlueprintData();
            var blueprintResource = (await blueprintCollection.CreateOrUpdateAsync(WaitUntil.Completed, printName, printInput)).Value;
            var artifactCollection = blueprintResource.GetBlueprintArtifacts();
            //CreateOrUpdate(Template Artifact)
            var artifactInput = ResourceDataHelpers.GetTemplateArtifactData();
            var artifactResource = (await artifactCollection.CreateOrUpdateAsync(WaitUntil.Completed, templateArtifactName, artifactInput)).Value;
            Assert.AreEqual(templateArtifactName, artifactResource.Data.Name);
            //Get
            var template2 = (await artifactCollection.GetAsync(templateArtifactName)).Value;
            ResourceDataHelpers.AssertArtifactData(artifactResource.Data, template2.Data);
            //GetAll
            _ = await artifactCollection.CreateOrUpdateAsync(WaitUntil.Completed, templateArtifactName2, artifactInput);
            _ = await artifactCollection.CreateOrUpdateAsync(WaitUntil.Completed, templateArtifactName3, artifactInput);
            int count = 0;
            await foreach (var num in artifactCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exist
            Assert.IsTrue(await artifactCollection.ExistsAsync(templateArtifactName));
            Assert.IsFalse(await artifactCollection.ExistsAsync(templateArtifactName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await artifactCollection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var resource3 = (await artifactResource.GetAsync()).Value;
            ResourceDataHelpers.AssertArtifactData(artifactResource.Data, resource3.Data);
            //2. Delete
            await resource3.DeleteAsync(WaitUntil.Completed);
        }
    }
}
