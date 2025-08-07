// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryGlobalParameterTests : DataFactoryManagementTestBase
    {
        public DataFactoryGlobalParameterTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<DataFactoryGlobalParameterResource> CreateOrUpdateGlobalParameter(DataFactoryResource dataFactory, string globalParameterName)
        {
            var parameters = new Dictionary<string, DataFactoryGlobalParameterProperties>();
            parameters.Add("test", new DataFactoryGlobalParameterProperties(DataFactoryGlobalParameterType.Int, new BinaryData("5")));
            DataFactoryGlobalParameterData data = new DataFactoryGlobalParameterData(parameters);
            var globalParameters = await dataFactory.GetDataFactoryGlobalParameters().CreateOrUpdateAsync(WaitUntil.Completed, globalParameterName, data);
            return globalParameters.Value;
        }

        [Test]
        [RecordedTest]
        public async Task GlobalParameter_Create_Exists_Get_List_Delete()
        {
            string globalParameterName = "default";
            // Get the resource group
            string rgName = Recording.GenerateAssetName("adf-rg-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName("adf-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            // CreateOrUpdate
            var globalParameters = await CreateOrUpdateGlobalParameter(dataFactory, globalParameterName);
            Assert.IsNotNull(globalParameters);
            Assert.AreEqual(globalParameterName, globalParameters.Data.Name);
            // Exist
            bool flag = await dataFactory.GetDataFactoryGlobalParameters().ExistsAsync(globalParameterName);
            Assert.IsTrue(flag);
            // Get
            var globalParametersGet = await dataFactory.GetDataFactoryGlobalParameters().GetAsync(globalParameterName);
            Assert.IsNotNull(globalParameters);
            Assert.AreEqual(globalParameterName, globalParametersGet.Value.Data.Name);
            // GetAll
            var list = await dataFactory.GetDataFactoryGlobalParameters().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(globalParameterName, list.FirstOrDefault().Data.Name);
            // Delete
            await globalParameters.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryGlobalParameters().ExistsAsync(globalParameterName);
            Assert.IsFalse(flag);
        }
    }
}
