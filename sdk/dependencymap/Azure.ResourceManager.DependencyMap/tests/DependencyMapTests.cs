// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DependencyMap.Tests
{
    public class DependencyMapTests : DependencyMapManagementTestBase
    {
        public DependencyMapTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task CreateClients()
        {
            if (Mode == RecordedTestMode.Playback || Mode == RecordedTestMode.Record)
            {
                await CreateCommonClient();
            }
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Ignore until we have a stable API for Dependency Map")]
        public async Task TestMapsResourceCRUD()
        {
            var rgName = Recording.GenerateAssetName("rgdependencyMap");
            var mapName = Recording.GenerateAssetName("mapsTest1");
            var location = AzureLocation.WestUS2;
            var subscription = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            var mapResourceId = DependencyMapResource.CreateResourceIdentifier(subscription.Id, rgName, mapName);
            var mapsCollection = new DependencyMapCollection(Client, mapResourceId);
            var createMapsOperations = await mapsCollection.CreateOrUpdateAsync(WaitUntil.Completed, mapName, new DependencyMapData(location));
            await createMapsOperations.WaitForCompletionAsync();

            Assert.That(createMapsOperations.HasCompleted, Is.True);
            Assert.That(createMapsOperations.HasValue, Is.True);
            Assert.That(createMapsOperations.GetRawResponse().Status, Is.EqualTo(200));

            var mapsResource = await mapsCollection.GetAsync(mapName);
            Assert.That(mapsResource, Is.Not.Null);
            Assert.That(mapsResource.Value.Data.Name, Is.EqualTo(mapName));
            Assert.That(mapsResource.GetRawResponse().Status, Is.EqualTo(200));

            var deleteOperation = await mapsResource.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();
            Assert.That(deleteOperation.HasCompleted, Is.True);
        }
    }
}
