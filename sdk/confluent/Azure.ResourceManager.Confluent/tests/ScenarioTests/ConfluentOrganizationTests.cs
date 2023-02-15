// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Confluent.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Confluent.Tests
{
    public  class ConfluentOrganizationTests : ConfluentManagementTestBase
    {
        public ConfluentOrganizationTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }
        private ConfluentOrganizationCollection ConfluentCollection { get; set; }

        [SetUp]
        public async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ConfluentCollection = ResourceGroup.GetConfluentOrganizations();
        }

        [Test]
        [Ignore("Need service team to run the case")]
        public async Task CRUDTest()
        {
            // Create test
            var offerDetail = new ConfluentOfferDetail(publisherId: "isvtestuklegacy", id: "liftr_cf_dev", planId: "payg", planName: "Pay as you go", termUnit: "P1M");
            var userDetail = new ConfluentUserDetail(firstName: "TestName", lastName: "TestName", emailAddress: "testsdk@sdktest.com");
            var data = new ConfluentOrganizationData(DefaultLocation, offerDetail, userDetail);
            var resourceName = Recording.GenerateAssetName("confluent-sdk-test-");

            var resource = (await ConfluentCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data)).Value;

            Assert.AreEqual(resourceName, resource.Data.Name);
            Assert.AreEqual(DefaultLocation, resource.Data.Location);
            AssertConfluentData(data, resource.Data);

            // Get test - 1
            resource = await ConfluentCollection.GetAsync(resourceName);
            Assert.AreEqual(resourceName, resource.Data.Name);
            Assert.AreEqual(DefaultLocation, resource.Data.Location);
            AssertConfluentData(data, resource.Data);

            // Exists test
            bool trueResult = await ConfluentCollection.ExistsAsync(resourceName);
            Assert.IsTrue(trueResult);
            bool falseResult = await ConfluentCollection.ExistsAsync("foo");
            Assert.IsFalse(falseResult);

            // Validate test
            var result = (await ResourceGroup.ValidateOrganizationAsync(resourceName, data)).Value;
            Assert.AreEqual(resourceName, result.Data.Name);
            Assert.AreEqual(DefaultLocation, result.Data.Location);
            AssertConfluentData(data, result.Data);

            // Update test
            data.OfferDetail.Id = "update_id";
            data.UserDetail.FirstName = "UpdateName";

            resource = (await ConfluentCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data)).Value;
            Assert.AreEqual(resourceName, resource.Data.Name);
            Assert.AreEqual(DefaultLocation, resource.Data.Location);
            AssertConfluentData(data, resource.Data);

            // GetAll test
            var list = await ConfluentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(resourceName, list[0].Data.Name);
            Assert.AreEqual(DefaultLocation, list[0].Data.Location);
            AssertConfluentData(data, list[0].Data);

            // Patch test
            var patch = new ConfluentOrganizationPatch()
            {
                Tags = { { "newkey", "newvalue" } }
            };
            resource = await resource.UpdateAsync(patch);
            Assert.AreEqual(resourceName, resource.Data.Name);
            Assert.AreEqual(DefaultLocation, resource.Data.Location);
            AssertConfluentData(data, resource.Data);
            Assert.IsTrue(resource.Data.Tags.ContainsKey("newkey"));
            Assert.AreEqual(resource.Data.Tags["newkey"], "newvalue");

            // Get test - 2
            resource = await resource.GetAsync();
            Assert.AreEqual(resourceName, resource.Data.Name);
            Assert.AreEqual(DefaultLocation, resource.Data.Location);
            AssertConfluentData(data, resource.Data);

            // Delete test
            await resource.DeleteAsync(WaitUntil.Completed);
            falseResult = await ConfluentCollection.ExistsAsync(resourceName);
            Assert.IsFalse(falseResult);
        }

        public void AssertConfluentData(ConfluentOrganizationData expected, ConfluentOrganizationData actual)
        {
            Assert.AreEqual(expected.OfferDetail.PublisherId, actual.OfferDetail.PublisherId);
            Assert.AreEqual(expected.OfferDetail.Id, actual.OfferDetail.Id);
            Assert.AreEqual(expected.OfferDetail.PlanId, actual.OfferDetail.PlanId);
            Assert.AreEqual(expected.OfferDetail.PlanName, actual.OfferDetail.PlanName);
            Assert.AreEqual(expected.OfferDetail.TermUnit, actual.OfferDetail.TermUnit);
            Assert.AreEqual(expected.UserDetail.FirstName, actual.UserDetail.FirstName);
            Assert.AreEqual(expected.UserDetail.LastName, actual.UserDetail.LastName);
            Assert.AreEqual(expected.UserDetail.EmailAddress, actual.UserDetail.EmailAddress);
        }
    }
}
