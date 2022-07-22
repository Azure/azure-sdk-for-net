// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.DataFactory.Tests;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.IotHub.Tests.Scenario
{
    internal class LinkedServiceResourceTests : DataFactoryManagementTestBase
    {
        private ResourceIdentifier _dataFactoryIdentifier;
        private DataFactoryResource _dataFactory;
        public LinkedServiceResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("DataFactory-RG-");
            string dataFactoryName = SessionRecording.GenerateAssetName("DataFactory-");
            rgName = "datafactory-rg-custom-0000";
            dataFactoryName = "datafactory-custom-0000";
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

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _dataFactory.GetLinkedServiceResources().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            System.Console.WriteLine(list[2].Data.Properties);

            string key = "th4S/DG4Cz8uq1vbv8a8ooRZqKk+TLmsgSKb004bgen/4epF+E8wYhzFp0pv3PbRF5dy8SDgwHdI+AStU7Ejbw==";

            LinkedService linkedService = new LinkedService()
            {
                LinkedServiceType = "AzureBlobStorage",
            };
            KeyValuePair<string, ParameterSpecification> dic = new KeyValuePair<string, ParameterSpecification>(
                "connectionString",
                new ParameterSpecification(ParameterType.SecureString)
                {
                    //DefaultValue = new BinaryData("DefaultEndpointsProtocol=https;AccountName=storagefordatafac220721;EndpointSuffix=core.windows.net;")
                    //DefaultValue = new BinaryData("{\"connectionString\":\"DefaultEndpointsProtocol=https;AccountName=storagefordatafac220721;EndpointSuffix=core.windows.net;\"}")
                    DefaultValue = $"DefaultEndpointsProtocol=https;AccountName=220722datafactory;AccountKey={key}"
                });
            linkedService.Parameters.Add(dic);
            //linkedService.AdditionalProperties.Add(dic);
            LinkedServiceResourceData data = new LinkedServiceResourceData(linkedService);
            await _dataFactory.GetLinkedServiceResources().CreateOrUpdateAsync(WaitUntil.Completed, "link4", data);
        }
    }
}
