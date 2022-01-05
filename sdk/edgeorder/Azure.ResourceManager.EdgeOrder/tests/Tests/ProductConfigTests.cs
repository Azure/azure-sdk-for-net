// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeOrder.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOrder.Tests.Tests
{
    [TestFixture]
    public class ProductConfigTests : EdgeOrderManagementClientBase
    {
        public ProductConfigTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [OneTimeTearDown]
        public void CleanupResourceGroup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        public async Task TestListProductFamiliesMetadata()
        {
            AsyncPageable<ProductFamiliesMetadataDetails> productFamiliesMetadata =
                SubscriptionExtensions.GetProductFamiliesMetadataAsync(Subscription);
            List<ProductFamiliesMetadataDetails> productFamiliesMetadataResult = await productFamiliesMetadata.ToEnumerableAsync();

            Assert.NotNull(productFamiliesMetadataResult);
            Assert.IsTrue(productFamiliesMetadataResult.Count >= 1);
        }

        [TestCase]
        public async Task TestListProductFamilies()
        {
            IList<FilterableProperty> filterableProperty = new List<FilterableProperty>()
            {
                new FilterableProperty(SupportedFilterTypes.ShipToCountries, new List<string>() { "US" })
            };
            IDictionary<string, IList<FilterableProperty>> filterableProperties =
                new Dictionary<string, IList<FilterableProperty>>() { { "azurestackedge", filterableProperty } };
            ProductFamiliesRequest productFamiliesRequest = new(filterableProperties);
            AsyncPageable<ProductFamily> productFamilies = SubscriptionExtensions.GetProductFamiliesAsync(Subscription, productFamiliesRequest);
            List<ProductFamily> productFamiliesResult = await productFamilies.ToEnumerableAsync();

            Assert.NotNull(productFamiliesResult);
            Assert.IsTrue(productFamiliesResult.Count >= 1);
        }

        [TestCase]
        public async Task TestListConfigurations()
        {
            ConfigurationFilters configurationFilters = new(GetHierarchyInformation());
            configurationFilters.FilterableProperty.Add(new FilterableProperty(SupportedFilterTypes.ShipToCountries,
                new List<string>() { "US" }));
            ConfigurationsRequest configurationsRequest = new(
                new List<ConfigurationFilters>() { configurationFilters });
            AsyncPageable<ProductConfiguration> configurations = SubscriptionExtensions.GetConfigurationsAsync(Subscription,
                configurationsRequest);
            List<ProductConfiguration> configurationsResult = await configurations.ToEnumerableAsync();

            Assert.NotNull(configurationsResult);
            Assert.IsTrue(configurationsResult.Count >= 1);
        }
    }
}
