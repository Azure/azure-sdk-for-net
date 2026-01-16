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
            Assert.That(flag, Is.True);

            // Get
            var getIotConnector = await _iotConnectorCollection.GetAsync(iotConnectorName);
            ValidateHealthcareApisIotConnector(getIotConnector.Value.Data, iotConnectorName);

            // GetAll
            var list = await _iotConnectorCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            ValidateHealthcareApisIotConnector(list.FirstOrDefault().Data, iotConnectorName);

            // Delete
            await iotConnector.DeleteAsync(WaitUntil.Completed);
            flag = await _iotConnectorCollection.ExistsAsync(iotConnectorName);
            Assert.That(flag, Is.False);
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
            Assert.That(iotConnector.Data.Tags.Count, Is.EqualTo(1));
            KeyValuePair<string, string> tag = iotConnector.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.That(tag.Key, Is.EqualTo("addtagkey"));
            Assert.That(tag.Value, Is.EqualTo("addtagvalue"));

            // RemoveTag
            await iotConnector.RemoveTagAsync("addtagkey");
            iotConnector = await _iotConnectorCollection.GetAsync(iotConnectorName);
            Assert.That(iotConnector.Data.Tags.Count, Is.EqualTo(0));
        }

        private void ValidateHealthcareApisIotConnector(HealthcareApisIotConnectorData iotConnector, string iotConnectorName)
        {
            Assert.That(iotConnector, Is.Not.Null);
            Assert.That(iotConnector.ETag, Is.Not.Null);
            Assert.That(iotConnector.DeviceMappingContent, Is.Not.Null);
            Assert.That(iotConnector.Id.Name, Is.EqualTo(iotConnectorName));
            Assert.That(iotConnector.Location, Is.EqualTo(DefaultLocation));
            Assert.That(iotConnector.ResourceType.ToString(), Is.EqualTo("Microsoft.HealthcareApis/workspaces/iotconnectors"));
            Assert.That(iotConnector.IngestionEndpointConfiguration.ConsumerGroup, Is.EqualTo("$Default"));
        }
    }
}
