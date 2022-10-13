// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class MetadataModelResourceTests : SecurityInsightsManagementTestBase
    {
        public MetadataModelResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }
        private MetadataModelCollection GetFrontDoorCollectionAsync(ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetMetadataModels(workspaceName);
        }

        private async Task<MetadataModelResource> CreateMetadataModelResourceAsync(string modelName)
        {
            var resourceGroup = await GetResourceGroupAsync();
            var collection = GetFrontDoorCollectionAsync(resourceGroup);
            var groupName = resourceGroup.Data.Name;
            var input = ResourceDataHelpers.GetMetadataModelData(groupName, DefaultSubscription.Id);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, modelName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task MetadataModelResourceApiTests()
        {
            //1.Get
            var modelName = Recording.GenerateAssetName("testMetaDataModel");
            var model1 = await CreateMetadataModelResourceAsync(modelName);
            MetadataModelResource model2 = await model1.GetAsync();

            ResourceDataHelpers.AssertMetadataModelData(model1.Data, model2.Data);
            //2.Delete
            await model1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
