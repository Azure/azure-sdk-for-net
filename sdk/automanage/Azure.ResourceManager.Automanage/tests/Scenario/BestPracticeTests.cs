// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class BestPracticeTests : BestPracticeTestBase
    {
        public BestPracticeTests(bool async) : base(async) { }

        [TestCase]
        public async Task CanGetBestPracticesProductionProfile()
        {
            string profileName = "AzureBestPracticesProduction";

            // fetch tenant collection
            var collection = Tenant.GetAutomanageBestPractices();
            var profile = await collection.GetAsync(profileName);

            // assert
            AssertValues(profile, profileName);
        }

        [TestCase]
        public async Task CanGetBestPracticesDevTestProfile()
        {
            string profileName = "AzureBestPracticesDevTest";

            // fetch tenant collection
            var collection = Tenant.GetAutomanageBestPractices();
            var profile = await collection.GetAsync(profileName);

            // assert
            AssertValues(profile, profileName);
        }

        [TestCase]
        public async Task CanGetAllBestPracticesProfiles()
        {
            // fetch tenant collection
            var collection = Tenant.GetAutomanageBestPractices();
            var profiles = collection.GetAllAsync();

            int count = 0;
            await foreach (var profile in profiles)
                count++;

            // assert
            // there are two best practices profiles, Production & DevTest
            Assert.AreEqual(2, count);
        }
    }
}
