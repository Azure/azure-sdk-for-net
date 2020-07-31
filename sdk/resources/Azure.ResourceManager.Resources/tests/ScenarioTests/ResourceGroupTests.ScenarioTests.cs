// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class LiveResourceGroupTests : ResourceOperationsTestsBase
    {
        public LiveResourceGroupTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        private const string DefaultLocation = "South Central US";

        [Test]
        public async Task CanCreateResourceGroup()
        {
            string groupName = Recording.GenerateAssetName("csmrg");
            var result = await ResourceGroupsOperations.CreateOrUpdateAsync(groupName,
                new ResourceGroup(DefaultLocation)
                {
                    Tags = new Dictionary<string, string>() { { "department", "finance" }, { "tagname", "tagvalue" } },
                });
            var listResult = await ResourceGroupsOperations.ListAsync().ToEnumerableAsync();
            var listedGroup = listResult.FirstOrDefault((g) => string.Equals(g.Name, groupName, StringComparison.Ordinal));
            Assert.NotNull(listedGroup);
            Assert.AreEqual("finance", listedGroup.Tags["department"]);
            Assert.AreEqual("tagvalue", listedGroup.Tags["tagname"]);
            Assert.True(Utilities.LocationsAreEqual(DefaultLocation, listedGroup.Location),
               string.Format("Expected location '{0}' did not match actual location '{1}'", DefaultLocation, listedGroup.Location));
            var gottenGroup = (await ResourceGroupsOperations.GetAsync(groupName)).Value;
            Assert.NotNull(gottenGroup);
            Assert.AreEqual(groupName, gottenGroup.Name);
            Assert.True(Utilities.LocationsAreEqual(DefaultLocation, gottenGroup.Location),
                string.Format("Expected location '{0}' did not match actual location '{1}'", DefaultLocation, gottenGroup.Location));
        }

        [Test]
        public async Task CheckExistenceReturnsCorrectValue()
        {
            string groupName = Recording.GenerateAssetName("csmrg");;

            var checkExistenceFirst = await ResourceGroupsOperations.CheckExistenceAsync(groupName);
            Assert.AreEqual(404, checkExistenceFirst.Status);

            await ResourceGroupsOperations.CreateOrUpdateAsync(groupName, new ResourceGroup(DefaultLocation));

            var checkExistenceSecond = await ResourceGroupsOperations.CheckExistenceAsync(groupName);

            Assert.AreEqual(204, checkExistenceSecond.Status);
        }

        [Test]
        public async Task DeleteResourceGroupRemovesGroup()
        {
            var resourceGroupName = Recording.GenerateAssetName("csmrg");
            var createResult = await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(DefaultLocation));
            var getResult = await ResourceGroupsOperations.GetAsync(resourceGroupName);
            var rawDeleteResult = await ResourceGroupsOperations.StartDeleteAsync(resourceGroupName);
            var deleteResult = (await WaitForCompletionAsync(rawDeleteResult)).Value;
            var listResult = await ResourceGroupsOperations.ListAsync(null).ToEnumerableAsync();

            Assert.AreEqual(200, deleteResult.Status);
            foreach (var rg in listResult)
            {
                if (rg.Name == resourceGroupName)
                {
                    Assert.AreNotEqual("Deleting", rg.Properties.ProvisioningState);
                }
            }
        }
    }
}
