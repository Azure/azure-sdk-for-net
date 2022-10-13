// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    public class SourceControlResourceTests : SecurityInsightsManagementTestBase
    {
        public SourceControlResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<SourceControlResource> CreateSourceControlAsync(string sourceName)
        {
            var collection = (await CreateResourceGroupAsync()).GetSourceControls(workspaceName);
            var input = ResourceDataHelpers.GetSourceControlData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, sourceName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task SourceControlResourceApiTests()
        {
            //1.Get
            var settingName = Recording.GenerateAssetName("testSourceControls-");
            var source1 = await CreateSourceControlAsync(settingName);
            SourceControlResource setting1 = await source1.GetAsync();

            ResourceDataHelpers.AssertSourceControlData(source1.Data, setting1.Data);
            //2.Delete
            await source1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
