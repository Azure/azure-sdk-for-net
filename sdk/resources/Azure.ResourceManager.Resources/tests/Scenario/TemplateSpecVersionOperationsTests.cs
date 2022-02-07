﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class TemplateSpecVersionOperationsTests : ResourcesTestBase
    {
        public TemplateSpecVersionOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(true, rgName, rgData);
            ResourceGroup rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-C-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpec templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(true, templateSpecName, templateSpecData)).Value;
            const string version = "v1";
            TemplateSpecVersionData templateSpecVersionData = CreateTemplateSpecVersionData();
            TemplateSpecVersion templateSpecVersion = (await templateSpec.GetTemplateSpecVersions().CreateOrUpdateAsync(true, version, templateSpecVersionData)).Value;
            await templateSpecVersion.DeleteAsync(true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await templateSpecVersion.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}
