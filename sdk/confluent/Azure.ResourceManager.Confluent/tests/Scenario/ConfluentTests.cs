// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Confluent.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Confluent.Tests.Scenario
{
    public class ConfluentTests : ConfluentManagementTestBase
    {
        public ConfluentTests(bool async)
           : base(async)
        {
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }
        [RecordedTest]
        [TestCase]
        public async Task CreateorUpdateConfluentOrg()
        {
            var confluentOrgCollection = GetConfluentOrganizationCollectionAsync();
            ConfluentOfferDetail offerDetail = new ConfluentOfferDetail("confluentinc", "confluent-cloud-azure-stag", "confluent-cloud-azure-payg-stag", "Confluent Cloud - Pay as you Go", "P1M");
            offerDetail.TermId = "gmz7xq9ge3py";
            var resourceName = $"liftrcftsdk";
            ConfluentUserDetail userDetail = new ConfluentUserDetail()
            {
                FirstName = "LiftrConfluent",
                LastName = "User",
                EmailAddress = $"{resourceName}@outlook.com",
            };
            ConfluentOrganizationData inputData = new ConfluentOrganizationData(DefaultLocation, offerDetail, userDetail);
            var confluentNewOrg = await confluentOrgCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, inputData);
            Assert.NotNull(confluentNewOrg);
            Assert.NotNull(confluentNewOrg.Value.Id);
            Assert.NotNull(confluentNewOrg.Value.Data.SsoUri);
        }

        [RecordedTest]
        [TestCase]
        public async Task ListConfluentOrgsInSubscription()
        {
            int count = 0;
            var confluentOrgCollection = GetConfluentOrganizationCollectionAsync();
            ConfluentOfferDetail offerDetail = new ConfluentOfferDetail("confluentinc", "confluent-cloud-azure-stag", "confluent-cloud-azure-payg-stag", "Confluent Cloud - Pay as you Go", "P1M");
            offerDetail.TermId = "gmz7xq9ge3py";
            var resourceName = $"liftrcftsdk";
            ConfluentUserDetail userDetail = new ConfluentUserDetail()
            {
                FirstName = "LiftrConfluent",
                LastName = "User",
                EmailAddress = $"liftrcftsdk@outlook.com",
            };
            ConfluentOrganizationData inputData = new ConfluentOrganizationData(DefaultLocation, offerDetail, userDetail);
            var confluentNewOrg = await confluentOrgCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, inputData);
            Console.WriteLine("Confluent Org Created: " + confluentNewOrg.Value.Id.Name);
            await foreach (ConfluentOrganizationResource confluentOrganization in DefaultSubscription.GetConfluentOrganizationsAsync())
            {
                if (confluentOrganization.Id.Name.Equals(resourceName))
                {
                    ++count;
                    break;
                }
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [RecordedTest]
        [TestCase]
        public async Task DeleteConfluentOrg()
        {
            var confluentOrgCollection = GetConfluentOrganizationCollectionAsync();
            ConfluentOfferDetail offerDetail = new ConfluentOfferDetail("confluentinc", "confluent-cloud-azure-stag", "confluent-cloud-azure-payg-stag", "Confluent Cloud - Pay as you Go", "P1M");
            offerDetail.TermId = "gmz7xq9ge3py";
            var resourceName = $"liftrcftsdk";
            ConfluentUserDetail userDetail = new ConfluentUserDetail()
            {
                FirstName = "LiftrConfluent",
                LastName = "User",
                EmailAddress = $"liftrcftsdk@outlook.com",
            };
            ConfluentOrganizationData inputData = new ConfluentOrganizationData(DefaultLocation, offerDetail, userDetail);
            var confluentNewOrg = await confluentOrgCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, inputData);
            var result = await confluentNewOrg.Value.DeleteAsync(WaitUntil.Completed);
            Assert.AreEqual(result.GetRawResponse().Status,200);
        }
    }
}
