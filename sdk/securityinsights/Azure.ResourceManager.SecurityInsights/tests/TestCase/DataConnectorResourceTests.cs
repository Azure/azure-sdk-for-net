// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class DataConnectorResourceTests : SecurityInsightsManagementTestBase
    {
        public DataConnectorResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<DataConnectorResource> CreateDataConnectorAsync(string dataName)
        {
            var collection = (await CreateResourceGroupAsync()).GetDataConnectors(workspaceName);
            var input = ResourceDataHelpers.GetDataConnectorData(workspaceName);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, dataName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task DataConnectorResourceApiTests()
        {
            //1.Get
            var dataName = Recording.GenerateAssetName("testDataConnectors-");
            var data1 = await CreateDataConnectorAsync(dataName);
            DataConnectorResource data2 = await data1.GetAsync();

            ResourceDataHelpers.AssertDataConnectorData(data1.Data, data2.Data);
            //2.Delete
            await data1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
