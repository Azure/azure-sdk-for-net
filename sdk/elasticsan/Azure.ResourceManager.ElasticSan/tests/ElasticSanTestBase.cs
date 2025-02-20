// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ElasticSan.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ElasticSan.Tests
{
    public class ElasticSanTestBase : ManagementRecordedTestBase<ElasticsanManagementTestEnvironment>
    {
        public static AzureLocation DefaultLocation => AzureLocation.EastUS2;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        public ElasticSanTestBase(bool isAsync) : base(isAsync)
        {
        }

        public ElasticSanTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected readonly string ResourceGroupName = "testelasticsanrg";
        protected readonly string ElasticSanName = "testelasticsan1";
        protected AzureLocation TestLocation = new("eastus2euap");

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        public static ElasticSanData GetDefaultElasticSanParameters(string location = null, long baseSizeTib = 1, long extendedCapacitySizeTib = 6)
        {
            string locationParameter = location ?? DefaultLocation;
            ElasticSanData parameters = new ElasticSanData(locationParameter,
                new ElasticSanSku(ElasticSanSkuName.PremiumLrs, null, null),
                baseSizeTib,
                extendedCapacitySizeTib);
            return parameters;
        }

        public static ElasticSanVolumeData GetDefaultElasticSanVolumeData()
        {
            ElasticSanVolumeData parameters = new(100);
            return parameters;
        }

        public async Task<ResourceGroupResource> CreateResourceGroupResourceAsync()
        {
            string resourceGroupName = Recording.GenerateAssetName("testelasticsanRG-");
            ArmOperation<ResourceGroupResource> operation = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return operation.Value;
        }

        public async Task<ResourceGroupResource> GetResourceGroupAsync(string resourceGroupName)
        {
            ResourceGroupResource resourceGroup = (await DefaultSubscription.GetResourceGroups().GetAsync(resourceGroupName)).Value;
            return resourceGroup;
        }
    }
}
