// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests.Scenario
{
    [TestFixture("create")]
    public class CreateMccfTest : MccfManagementTestBase
    {
        public CreateMccfTest(string testFixtureName) : base(true, testFixtureName)
        {
        }

        [RecordedTest]
        public async Task TestCreateMccfApp()
        {
            // Create Mccf App
            await CreateMccf(mccfName);

            ManagedCcfResource mccfResource = await GetMccfByName(mccfName);

            Assert.NotNull(mccfResource);
            Assert.AreEqual(mccfName, mccfResource.Data.Properties.AppName);
            Assert.NotNull(mccfResource.Data.Properties.AppUri);
        }
    }
}
