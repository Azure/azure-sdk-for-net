// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                entries.Add(entry);
            }

            ValidationTestResource selected = entries.Single(entry => entry.Data.Name == TestEnvironment.CatalogTestName);
            ValidationTestResource fetched = (await tests.GetAsync(selected.Data.Name)).Value;
            Assert.That(fetched.Id, Is.EqualTo(selected.Id));
            Assert.That(fetched.Data.Properties.Audience, Is.EqualTo(CatalogAudience.Public));

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
            ValidationTestCategoryResource refreshedCategory = (await fetchedCategory.GetAsync()).Value;
            Assert.That(refreshedCategory.Id, Is.EqualTo(fetchedCategory.Id));
        }

        [RecordedTest]
        public async Task GetAndListPublicVersionsFromReturnedTest()
        {
            ValidationTestResource test = (await DefaultSubscription.GetValidationTests()
                .GetAsync(TestEnvironment.CatalogTestName)).Value;
            ValidationTestVersionCollection versions = test.GetValidationTestVersions();
            List<ValidationTestVersionResource> publicVersions = new();
            await foreach (ValidationTestVersionResource version in versions.GetAllAsync())
            {
                if (version.Data.Properties.Audience == CatalogAudience.Public)
                {
                    publicVersions.Add(version);
                }
            }

            Assert.That(publicVersions, Is.Not.Empty);
            ValidationTestVersionResource selected = publicVersions[0];
            ValidationTestVersionResource fetched = (await versions.GetAsync(selected.Data.Name)).Value;
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
            ValidationTestResource refreshed = (await test.GetAsync()).Value;
            Assert.That(refreshed.Id, Is.EqualTo(test.Id));
            Assert.That(refreshed.Data.Name, Is.EqualTo(test.Data.Name));
        }
    }
}
