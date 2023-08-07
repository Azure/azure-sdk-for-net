// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests.Scenario
{
    [TestFixture("delete")]
    public class DeleteMccfTest : MccfManagementTestBase
    {
        private ManagedCcfResource _mccfResource;
        public DeleteMccfTest(string testFixtureName) : base(true, testFixtureName)
        {
        }

        [SetUp]
        public async Task FixtureSetup()
        {
            await CreateMccf(mccfName);
            _mccfResource = await GetMccfByName(mccfName);
        }

        [RecordedTest]
        public async Task TestDeleteMccfApp()
        {
            await _mccfResource.DeleteAsync(WaitUntil.Completed);
            try
            {
                await GetMccfByName(mccfName);
                Assert.Fail("Mccf app should not exist after delete operation");
            }
            catch (Exception exception)
            {
                Assert.True(exception.Message.Contains("ResourceNotFound"));
            }
        }
    }
}
