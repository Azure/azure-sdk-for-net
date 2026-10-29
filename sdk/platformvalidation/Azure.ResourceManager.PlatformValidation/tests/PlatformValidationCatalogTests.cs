// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PlatformValidation.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.PlatformValidation.Tests
{
    public class PlatformValidationCatalogTests : PlatformValidationManagementTestBase
    {
        public PlatformValidationCatalogTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetAndListPublicTestsAndCategories()
        {
            ValidationTestCollection tests = DefaultSubscription.GetValidationTests();
            List<ValidationTestResource> entries = new();
            await foreach (ValidationTestResource entry in tests.GetAllAsync())
            {
                AssertCatalogSubscription(entry.Id);
                entries.Add(entry);
            }

            ValidationTestResource selected = entries.Single(entry => entry.Data.Name == TestEnvironment.CatalogTestName);
            ValidationTestResource fetched = (await tests.GetAsync(selected.Data.Name)).Value;
            AssertCatalogSubscription(fetched.Id);
            AssertCatalogSubscription(fetched.Data.Properties.CurrentVersion);
            AssertCatalogSubscription(fetched.Data.Properties.LatestPublishedVersion);
            Assert.That(fetched.Id, Is.EqualTo(selected.Id));
            Assert.That(fetched.Data.Properties.Audience, Is.EqualTo(CatalogAudience.Public));

            ValidationTestCategoryCollection categories = DefaultSubscription.GetValidationTestCategories();
            List<ValidationTestCategoryResource> publicCategories = new();
            await foreach (ValidationTestCategoryResource category in categories.GetAllAsync())
            {
                AssertCatalogSubscription(category.Id);
                if (category.Data.Properties.Audience == CatalogAudience.Public)
                {
                    publicCategories.Add(category);
                }
            }

            Assert.That(publicCategories, Is.Not.Empty);
            ValidationTestCategoryResource selectedCategory = publicCategories[0];
            ValidationTestCategoryResource fetchedCategory = (await categories.GetAsync(selectedCategory.Data.Name)).Value;
            AssertCatalogSubscription(fetchedCategory.Id);
            Assert.That(fetchedCategory.Id, Is.EqualTo(selectedCategory.Id));
            Assert.That(fetchedCategory.Data.Properties.Audience, Is.EqualTo(CatalogAudience.Public));
            ValidationTestCategoryResource refreshedCategory = (await fetchedCategory.GetAsync()).Value;
            Assert.That(refreshedCategory.Id, Is.EqualTo(fetchedCategory.Id));
        }

        [RecordedTest]
        public async Task GetAndListPublicVersionsFromReturnedTest()
        {
            ValidationTestResource test = (await DefaultSubscription.GetValidationTests()
                .GetAsync(TestEnvironment.CatalogTestName)).Value;
            AssertCatalogSubscription(test.Id);
            ValidationTestVersionCollection versions = test.GetValidationTestVersions();
            List<ValidationTestVersionResource> publicVersions = new();
            await foreach (ValidationTestVersionResource version in versions.GetAllAsync())
            {
                AssertCatalogSubscription(version.Id);
                Assert.That(version.Id.Parent, Is.EqualTo(test.Id));
                if (version.Data.Properties.Audience == CatalogAudience.Public)
                {
                    publicVersions.Add(version);
                }
            }

            Assert.That(publicVersions, Is.Not.Empty);
            ValidationTestVersionResource selected = publicVersions[0];
            ValidationTestVersionResource fetched = (await versions.GetAsync(selected.Data.Name)).Value;
            AssertCatalogSubscription(fetched.Id);
            Assert.That(fetched.Id, Is.EqualTo(selected.Id));
            Assert.That(fetched.Data.Properties.Audience, Is.EqualTo(CatalogAudience.Public));
            ValidationTestVersionResource refreshed = (await fetched.GetAsync()).Value;
            Assert.That(refreshed.Id, Is.EqualTo(fetched.Id));
        }

        [RecordedTest]
        public async Task RefreshReturnedTest()
        {
            ValidationTestResource test = (await DefaultSubscription.GetValidationTests()
                .GetAsync(TestEnvironment.CatalogTestName)).Value;
            AssertCatalogSubscription(test.Id);
            ValidationTestResource refreshed = (await test.GetAsync()).Value;
            Assert.That(refreshed.Id, Is.EqualTo(test.Id));
            Assert.That(refreshed.Data.Name, Is.EqualTo(test.Data.Name));
        }

        [RecordedTest]
        [LiveOnly(Reason = "Verifies explicit-scope access against the live service independently of response-ID contract checks.")]
        public async Task GetCatalogUsingExplicitSubscriptionScope()
        {
            string subscriptionId = DefaultSubscription.Id.SubscriptionId;
            ValidationTestCollection tests = DefaultSubscription.GetValidationTests();
            List<ValidationTestResource> entries = new();
            await foreach (ValidationTestResource entry in tests.GetAllAsync())
            {
                entries.Add(entry);
            }

            ValidationTestResource selected = entries.Single(entry => entry.Data.Name == TestEnvironment.CatalogTestName);
            ValidationTestResource scopedTest = Client.GetValidationTestResource(
                ValidationTestResource.CreateResourceIdentifier(subscriptionId, selected.Data.Name));
            for (int i = 0; i < 2; i++)
            {
                ValidationTestResource fetched = (await tests.GetAsync(selected.Data.Name)).Value;
                Assert.That(fetched.Id, Is.EqualTo(selected.Id));
                Assert.That(fetched.Data.Properties.Audience, Is.EqualTo(CatalogAudience.Public));

                // Retain the explicitly scoped handle rather than replacing it with the response resource.
                ValidationTestResource refreshed = (await scopedTest.GetAsync()).Value;
                Assert.That(refreshed.Id, Is.EqualTo(fetched.Id));
                Assert.That(refreshed.Data.Name, Is.EqualTo(selected.Data.Name));
            }

            ValidationTestVersionCollection versions = scopedTest.GetValidationTestVersions();
            List<ValidationTestVersionResource> publicVersions = new();
            await foreach (ValidationTestVersionResource version in versions.GetAllAsync())
            {
                if (version.Data.Properties.Audience == CatalogAudience.Public)
                {
                    publicVersions.Add(version);
                }
            }

            Assert.That(publicVersions, Is.Not.Empty);
            ValidationTestVersionResource selectedVersion = publicVersions[0];
            ValidationTestVersionResource fetchedVersion = (await versions.GetAsync(selectedVersion.Data.Name)).Value;
            Assert.That(fetchedVersion.Id, Is.EqualTo(selectedVersion.Id));
            Assert.That(fetchedVersion.Data.Properties.Audience, Is.EqualTo(CatalogAudience.Public));
            ValidationTestVersionResource scopedVersion = Client.GetValidationTestVersionResource(
                ValidationTestVersionResource.CreateResourceIdentifier(subscriptionId, selected.Data.Name, selectedVersion.Data.Name));
            ValidationTestVersionResource refreshedVersion = (await scopedVersion.GetAsync()).Value;
            Assert.That(refreshedVersion.Id, Is.EqualTo(fetchedVersion.Id));
            Assert.That(refreshedVersion.Data.Name, Is.EqualTo(selectedVersion.Data.Name));

            ValidationTestCategoryCollection categories = DefaultSubscription.GetValidationTestCategories();
            List<ValidationTestCategoryResource> publicCategories = new();
            await foreach (ValidationTestCategoryResource category in categories.GetAllAsync())
            {
                if (category.Data.Properties.Audience == CatalogAudience.Public)
                {
                    publicCategories.Add(category);
                }
            }

            Assert.That(publicCategories, Is.Not.Empty);
            ValidationTestCategoryResource selectedCategory = publicCategories[0];
            ValidationTestCategoryResource fetchedCategory = (await categories.GetAsync(selectedCategory.Data.Name)).Value;
            Assert.That(fetchedCategory.Id, Is.EqualTo(selectedCategory.Id));
            Assert.That(fetchedCategory.Data.Properties.Audience, Is.EqualTo(CatalogAudience.Public));
            ValidationTestCategoryResource scopedCategory = Client.GetValidationTestCategoryResource(
                ValidationTestCategoryResource.CreateResourceIdentifier(subscriptionId, selectedCategory.Data.Name));
            ValidationTestCategoryResource refreshedCategory = (await scopedCategory.GetAsync()).Value;
            Assert.That(refreshedCategory.Id, Is.EqualTo(fetchedCategory.Id));
            Assert.That(refreshedCategory.Data.Name, Is.EqualTo(selectedCategory.Data.Name));
        }

        private void AssertCatalogSubscription(ResourceIdentifier id)
        {
            Assert.That(id, Is.Not.Null);
            Assert.That(id.SubscriptionId, Is.EqualTo(DefaultSubscription.Id.SubscriptionId),
                "Catalog responses must return subscription-scoped IDs matching the requested subscription.");
        }
    }
}
