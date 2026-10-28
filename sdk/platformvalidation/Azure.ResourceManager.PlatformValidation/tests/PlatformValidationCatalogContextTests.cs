// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PlatformValidation.Tests
{
    public class PlatformValidationCatalogContextTests : ClientTestBase
    {
        public PlatformValidationCatalogContextTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CatalogHandlesRetainRequestedSubscription()
        {
            const string defaultSubscription = "11111111-1111-1111-1111-111111111111";
            const string requestedSubscription = "22222222-2222-2222-2222-222222222222";
            MockTransport transport = new(CreateCatalogResponse);
            ArmClient client = InstrumentClient(new ArmClient(new MockCredential(), defaultSubscription,
                new ArmClientOptions { Transport = transport }));
            SubscriptionResource subscription = client.GetSubscriptionResource(
                new ResourceIdentifier($"/subscriptions/{requestedSubscription}"));
            ValidationTestCollection tests = subscription.GetValidationTests();
            List<ValidationTestResource> returnedTests = new()
            {
                (await subscription.GetValidationTestAsync("boot")).Value,
                (await tests.GetIfExistsAsync("boot")).Value,
                (await client.GetValidationTestResource(
                    ValidationTestResource.CreateResourceIdentifier(requestedSubscription, "boot")).GetAsync()).Value
            };
            await foreach (ValidationTestResource test in tests.GetAllAsync())
            {
                returnedTests.Add(test);
            }

            foreach (ValidationTestResource test in returnedTests)
            {
                Assert.That(test.Id.SubscriptionId, Is.Null);
                Assert.That(test.Data.Id, Is.EqualTo(test.Id));
                ValidationTestResource refreshed = (await test.GetAsync()).Value;
                refreshed = (await refreshed.GetAsync()).Value;
                Assert.That(refreshed.Id, Is.EqualTo(test.Id));

                ValidationTestVersionCollection versions = refreshed.GetValidationTestVersions();
                List<ValidationTestVersionResource> returnedVersions = new()
                {
                    (await versions.GetAsync("v1")).Value,
                    (await versions.GetIfExistsAsync("v1")).Value
                };
                await foreach (ValidationTestVersionResource version in versions.GetAllAsync())
                {
                    returnedVersions.Add(version);
                }

                foreach (ValidationTestVersionResource version in returnedVersions)
                {
                    Assert.That(version.Id.SubscriptionId, Is.Null);
                    Assert.That(version.Data.Id, Is.EqualTo(version.Id));
                    ValidationTestVersionResource refreshedVersion = (await version.GetAsync()).Value;
                    refreshedVersion = (await refreshedVersion.GetAsync()).Value;
                    Assert.That(refreshedVersion.Id, Is.EqualTo(version.Id));
                }
            }

            ValidationTestCategoryCollection categories = subscription.GetValidationTestCategories();
            List<ValidationTestCategoryResource> returnedCategories = new()
            {
                (await subscription.GetValidationTestCategoryAsync("images")).Value,
                (await categories.GetIfExistsAsync("images")).Value
            };
            await foreach (ValidationTestCategoryResource category in categories.GetAllAsync())
            {
                returnedCategories.Add(category);
            }

            foreach (ValidationTestCategoryResource category in returnedCategories)
            {
                Assert.That(category.Id.SubscriptionId, Is.Null);
                Assert.That(category.Data.Id, Is.EqualTo(category.Id));
                ValidationTestCategoryResource refreshed = (await category.GetAsync()).Value;
                refreshed = (await refreshed.GetAsync()).Value;
                Assert.That(refreshed.Id, Is.EqualTo(category.Id));
            }

            Assert.That(transport.Requests, Is.Not.Empty);
            foreach (MockRequest request in transport.Requests)
            {
                Assert.That(request.Uri.ToUri().AbsolutePath,
                    Does.StartWith($"/subscriptions/{requestedSubscription}/providers/Microsoft.PlatformValidation/"));
            }
        }

        private static MockResponse CreateCatalogResponse(MockRequest request)
        {
            string path = request.Uri.ToUri().AbsolutePath;
            string id = path[path.IndexOf("/providers/", StringComparison.Ordinal)..];
            bool isList = id.EndsWith("/validationTests", StringComparison.Ordinal)
                || id.EndsWith("/validationTestCategories", StringComparison.Ordinal)
                || id.EndsWith("/versions", StringComparison.Ordinal);
            if (isList)
            {
                id += id.EndsWith("/validationTests", StringComparison.Ordinal) ? "/boot"
                    : id.EndsWith("/versions", StringComparison.Ordinal) ? "/v1" : "/images";
            }

            string type = id.Contains("/validationTestCategories/", StringComparison.Ordinal)
                ? "Microsoft.PlatformValidation/validationTestCategories"
                : id.Contains("/versions/", StringComparison.Ordinal)
                    ? "Microsoft.PlatformValidation/validationTests/versions"
                    : "Microsoft.PlatformValidation/validationTests";
            var data = new
            {
                id,
                name = id[(id.LastIndexOf('/') + 1)..],
                type,
                properties = new { audience = "Public" }
            };
            string body = isList ? JsonSerializer.Serialize(new { value = new[] { data } }) : JsonSerializer.Serialize(data);
            return new MockResponse(200).AddHeader("Content-Type", "application/json").SetContent(body);
        }
    }
}
