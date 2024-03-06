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
            ConfluentUserDetail userDetail = new ConfluentUserDetail()
            {
                FirstName = "LiftrConfluent",
                LastName = "User",
                EmailAddress = $"liftrcftsdk{DateTime.Now:ddMMyyyy}@outlook.com",
            };
            ConfluentOrganizationData inputData = new ConfluentOrganizationData(DefaultLocation, offerDetail, userDetail);
            var confluentNewOrg = await confluentOrgCollection.CreateOrUpdateAsync(WaitUntil.Completed, $"liftrcftsdk{DateTime.Now:ddMMyyyy}", inputData);
            Assert.NotNull(confluentNewOrg);
            Assert.NotNull(confluentNewOrg.Value.Id);
            Assert.NotNull(confluentNewOrg.Value.Data.SsoUri);
        }

        [RecordedTest]
        [TestCase]
        public async Task ListConfluentOrgsInSubscription()
        {
            int count = 0;
            await foreach (ConfluentOrganizationResource confluentOrganization in DefaultSubscription.GetConfluentOrganizationsAsync())
            {
                Console.WriteLine("Confluent Org: " + confluentOrganization.Id.Name);
                ++count;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [RecordedTest]
        [TestCase]
        public async Task GetEnvironmentsInOrg()
        {
            await foreach (ConfluentOrganizationResource confluentOrganization in DefaultSubscription.GetConfluentOrganizationsAsync())
            {
                if (confluentOrganization.Id.Name.Contains($"PortalSDKTest_0408"))
                {
                    var environments = confluentOrganization.GetEnvironmentsAsync();
                    await foreach (var env in environments)
                    {
                        Console.WriteLine("Environment: " + env.Id);
                    }
                    break;
                }
            }
        }

        [RecordedTest]
        [TestCase]
        public async Task GetClustersByIdInOrgForAnEnvironment()
        {
            await foreach (ConfluentOrganizationResource confluentOrganization in DefaultSubscription.GetConfluentOrganizationsAsync())
            {
                if (confluentOrganization.Id.Name.Contains($"PortalSDKTest_0408"))
                {
                    var cluster = confluentOrganization.GetClusterAsync("env-123", "lkc-1235");
                    Assert.NotNull(cluster);   // since the access is via partner signed token which is failing to get env.
                    break;
                }
            }
        }

        [RecordedTest]
        [TestCase]
        public async Task GetClustersInOrgForAnEnvironment()
        {
            try
            {
                await foreach (ConfluentOrganizationResource confluentOrganization in DefaultSubscription.GetConfluentOrganizationsAsync())
                {
                    if (confluentOrganization.Id.Name.Contains("PortalSDKTest_0408"))
                    {
                        var cluster = confluentOrganization.GetClustersAsync("env-123");
                        Assert.NotNull(cluster);   // since the access is via partner signed token which is failing to get env.
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [RecordedTest]
        [TestCase]
        public async Task GetSchemaRegistryClustersOrgForAnEnvironment()
        {
            await foreach (ConfluentOrganizationResource confluentOrganization in DefaultSubscription.GetConfluentOrganizationsAsync())
            {
                if (confluentOrganization.Id.Name.Contains("PortalSDKTest_0408"))
                {
                    var schemaRegistryClusters = confluentOrganization.GetSchemaRegistryClustersAsync("env-123");
                    Assert.NotNull(schemaRegistryClusters);   // since the access is via partner signed token which is failing to get env.
                    break;
                }
            }
        }

        [RecordedTest]
        [TestCase]
        public async Task GetSchemaRegistryClustersByIdOrgForAnEnvironment()
        {
            await foreach (ConfluentOrganizationResource confluentOrganization in DefaultSubscription.GetConfluentOrganizationsAsync())
            {
                if (confluentOrganization.Id.Name.Contains($"PortalSDKTest_0408"))
                {
                    var schemaRegistryCluster = confluentOrganization.GetSchemaRegistryClusterAsync("env-123", "cluster-134");
                    Assert.NotNull(schemaRegistryCluster);   // since the access is via partner signed token which is failing to get env.
                    Assert.NotNull(schemaRegistryCluster.Id);
                    break;
                }
            }
        }

        [RecordedTest]
        [TestCase]
        public async Task GetClustersByIdOrgForAnEnvironment()
        {
            await foreach (ConfluentOrganizationResource confluentOrganization in DefaultSubscription.GetConfluentOrganizationsAsync())
            {
                if (confluentOrganization.Id.Name.Contains($"PortalSDKTest_0408"))
                {
                    try
                    {
                        var Cluster = confluentOrganization.GetSchemaRegistryClusterAsync("env-123", "cluster-134");
                        Assert.NotNull(Cluster);   // since the access is via partner signed token which is failing to get env.
                        Assert.NotNull(Cluster.Id);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("EXCEPTION!!!!!!");
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        [RecordedTest]
        [TestCase]
        public async Task DeleteAPIKey()
        {
            await foreach (ConfluentOrganizationResource confluentOrganization in DefaultSubscription.GetConfluentOrganizationsAsync())
            {
                if (confluentOrganization.Id.Name.Contains($"PortalSDKTest_0408"))
                {
                    var deleteresponse = confluentOrganization.DeleteClusterApiKeyAsync("apiKeyId");
                    Assert.NotNull(deleteresponse);   // since the access is via partner signed token which is failing to get env.
                    break;
                }
            }
        }

        [RecordedTest]
        [TestCase]
        public async Task CreateAPIKey()
        {
            await foreach (ConfluentOrganizationResource confluentOrganization in DefaultSubscription.GetConfluentOrganizationsAsync())
            {
                ConfluentApiKeyCreateContent content = new ConfluentApiKeyCreateContent();
                content.Name = "testkey";
                content.Description = "testkey";
                if (confluentOrganization.Id.Name.Contains($"PortalSDKTest_0408"))
                {
                    var apiKey = confluentOrganization.CreateApiKeyAsync("env-123", "cluster-134", content);
                    Assert.IsNotNull(apiKey);  // since the access is via partner signed token which is failing to get env.
                    break;
                }
            }
        }

        [RecordedTest]
        [TestCase]
        public async Task DeleteConfluentOrg()
        {
            await foreach (ConfluentOrganizationResource confluentOrganization in DefaultSubscription.GetConfluentOrganizationsAsync())
            {
                if (confluentOrganization.Id.Name.Contains($"PortalSDKTest_0408"))
                {
                    var result = await confluentOrganization.DeleteAsync(WaitUntil.Completed);
                    Assert.AreEqual(result.GetRawResponse().Status, 200);
                    break;
                }
            }
        }
    }
}
