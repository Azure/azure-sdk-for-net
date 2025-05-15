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

            Assert.IsTrue(createMapsOperations.HasCompleted);
            Assert.IsTrue(createMapsOperations.HasValue);
            Assert.IsTrue(createMapsOperations.GetRawResponse().Status == 200);

            var mapsResource = await mapsCollection.GetAsync(mapName);
            Assert.IsNotNull(mapsResource);
            Assert.AreEqual(mapName, mapsResource.Value.Data.Name);
            Assert.IsTrue(mapsResource.GetRawResponse().Status == 200);

            var deleteOperation = await mapsResource.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteOperation.HasCompleted);
        }
    }
}
