// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryGlobalParameterTests : DataFactoryManagementTestBase
    {
        private ResourceIdentifier _dataFactoryIdentifier;
        private DataFactoryResource _dataFactory;
        private const string _globalParameterName = "default";
        public DataFactoryGlobalParameterTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("DataFactory-RG-");
            string dataFactoryName = SessionRecording.GenerateAssetName("DataFactory-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            var dataFactoryLro = await CreateDataFactory(rgLro.Value, dataFactoryName);
            _dataFactoryIdentifier = dataFactoryLro.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _dataFactory = await Client.GetDataFactoryResource(_dataFactoryIdentifier).GetAsync();
        }

        private async Task<DataFactoryGlobalParameterResource> CreateOrUpdateGlobalParameter(DataFactoryResource dataFactory)
        {
            var parameters = new Dictionary<string, DataFactoryGlobalParameterProperties>();
            parameters.Add("test", new DataFactoryGlobalParameterProperties(DataFactoryGlobalParameterType.Int, new BinaryData("5")));
            DataFactoryGlobalParameterData data = new DataFactoryGlobalParameterData(parameters);
            var globalParameters = await dataFactory.GetDataFactoryGlobalParameters().CreateOrUpdateAsync(WaitUntil.Completed, _globalParameterName, data);
            return globalParameters.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var globalParameters = await CreateOrUpdateGlobalParameter(_dataFactory);
            Assert.IsNotNull(globalParameters);
            Assert.AreEqual(_globalParameterName, globalParameters.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            await CreateOrUpdateGlobalParameter(_dataFactory);
            bool flag = await _dataFactory.GetDataFactoryGlobalParameters().ExistsAsync(_globalParameterName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            await CreateOrUpdateGlobalParameter(_dataFactory);
            var globalParameters = await _dataFactory.GetDataFactoryGlobalParameters().GetAsync(_globalParameterName);
            Assert.IsNotNull(globalParameters);
            Assert.AreEqual(_globalParameterName, globalParameters.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            await CreateOrUpdateGlobalParameter(_dataFactory);
            var list = await _dataFactory.GetDataFactoryGlobalParameters().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(_globalParameterName,list.FirstOrDefault().Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            var globalParameters = await CreateOrUpdateGlobalParameter(_dataFactory);
            bool flag = await _dataFactory.GetDataFactoryGlobalParameters().ExistsAsync(_globalParameterName);
            Assert.IsTrue(flag);

            await globalParameters.DeleteAsync(WaitUntil.Completed);
            flag = await _dataFactory.GetDataFactoryGlobalParameters().ExistsAsync(_globalParameterName);
            Assert.IsFalse(flag);
        }
    }
}
