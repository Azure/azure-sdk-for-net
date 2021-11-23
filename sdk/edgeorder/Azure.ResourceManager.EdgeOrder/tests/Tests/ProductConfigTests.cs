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
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase]
        public async Task TestListProductFamiliesMetadata()
        {
            var productFamiliesMetadata = EdgeOrderManagementOperations.ListProductFamiliesMetadataAsync();
            var productFamiliesMetadataResult = await productFamiliesMetadata.ToEnumerableAsync();

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
            ProductFamiliesRequest productFamiliesRequest = new ProductFamiliesRequest(filterableProperties);
            var productFamilies = EdgeOrderManagementOperations.ListProductFamiliesAsync(productFamiliesRequest, "configurations");
            var productFamiliesResult = await productFamilies.ToEnumerableAsync();

            Assert.NotNull(productFamiliesResult);
            Assert.IsTrue(productFamiliesResult.Count >= 1);
        }

        [TestCase]
        public async Task TestListConfigurations()
        {
            ConfigurationFilters configurationFilters = new ConfigurationFilters(GetHierarchyInformation());
            configurationFilters.FilterableProperty.Add(new FilterableProperty(SupportedFilterTypes.ShipToCountries,
                new List<string>() { "US" }));
            ConfigurationsRequest configurationsRequest = new ConfigurationsRequest(
                new List<ConfigurationFilters>() { configurationFilters });
            var configurations = EdgeOrderManagementOperations.ListConfigurationsAsync(configurationsRequest);
            var configurationsResult = await configurations.ToEnumerableAsync();

            Assert.NotNull(configurationsResult);
            Assert.IsTrue(configurationsResult.Count >= 1);
        }
    }
}
