// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.HealthcareApis.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HealthcareApis.Tests
{
    internal class HealthcareApisIotConnectorTests : HealthcareApisManagementTestBase
    {
        private const string _iotConnectorPrefixName = "medtech";
        private ResourceGroupResource _resourceGroup;
        private HealthcareApisWorkspaceResource _workspace;
        private HealthcareApisIotConnectorCollection _iotConnectorCollection;

        public HealthcareApisIotConnectorTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _workspace = await CreateHealthcareApisWorkspace(_resourceGroup, Recording.GenerateAssetName("workspace"));
            _iotConnectorCollection = _workspace.GetHealthcareApisIotConnectors();
        }

        [RecordedTest]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // Create
            string iotConnectorName = Recording.GenerateAssetName(_iotConnectorPrefixName);
            var iotConnector = await CreateHealthcareApisIotConnector(_resourceGroup, _workspace, iotConnectorName);
            ValidateHealthcareApisIotConnector(iotConnector.Data, iotConnectorName);

            // Exist
            bool flag = await _iotConnectorCollection.ExistsAsync(iotConnectorName);
            Assert.IsTrue(flag);

            // Get
            var getIotConnector = await _iotConnectorCollection.GetAsync(iotConnectorName);
            ValidateHealthcareApisIotConnector(getIotConnector.Value.Data, iotConnectorName);

            // GetAll
            var list = await _iotConnectorCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateHealthcareApisIotConnector(list.FirstOrDefault().Data, iotConnectorName);

            // Delete
            await iotConnector.DeleteAsync(WaitUntil.Completed);
            flag = await _iotConnectorCollection.ExistsAsync(iotConnectorName);
            Assert.IsFalse(flag);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string iotConnectorName = Recording.GenerateAssetName("iotconnector");
            var iotConnector = await CreateHealthcareApisIotConnector(_resourceGroup, _workspace, iotConnectorName);

            // AddTag
            await iotConnector.AddTagAsync("addtagkey", "addtagvalue");
            iotConnector = await _iotConnectorCollection.GetAsync(iotConnectorName);
            Assert.AreEqual(1, iotConnector.Data.Tags.Count);
            KeyValuePair<string, string> tag = iotConnector.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await iotConnector.RemoveTagAsync("addtagkey");
            iotConnector = await _iotConnectorCollection.GetAsync(iotConnectorName);
            Assert.AreEqual(0, iotConnector.Data.Tags.Count);
        }

        private void ValidateHealthcareApisIotConnector(HealthcareApisIotConnectorData iotConnector, string iotConnectorName)
        {
            Assert.IsNotNull(iotConnector);
            Assert.IsNotNull(iotConnector.ETag);
            Assert.IsNotNull(iotConnector.DeviceMappingContent);
            Assert.AreEqual(iotConnectorName, iotConnector.Id.Name);
            Assert.AreEqual(DefaultLocation, iotConnector.Location);
            Assert.AreEqual("Microsoft.HealthcareApis/workspaces/iotconnectors", iotConnector.ResourceType.ToString());
            Assert.AreEqual("$Default", iotConnector.IngestionEndpointConfiguration.ConsumerGroup);
        }
    }
}
