// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.OperationalInsights.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;
using Microsoft.Identity.Client.AppConfig;
using NUnit.Framework;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class OperationalInsightsDataExportTest : OperationalInsightsManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        public OperationalInsightsDataExportTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        { }

        [Test]
        public async Task OperationalInsightsDataExportTestCase()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "OperationalInsightsDataExport-test", _location);

            var workSpaceName = Recording.GenerateAssetName("InWorkspace");
            var workSpaceData = new OperationalInsightsWorkspaceData(_location);
            var workSpace = (await _resourceGroup.GetOperationalInsightsWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName, workSpaceData)).Value;
            var _collection = workSpace.GetOperationalInsightsDataExports();
            var eventHubName = Recording.GenerateAssetName("exportHub");
            var eventHub = await CreateEventHubs(eventHubName);

            //OperationalInsightsDataExportCollection_Create
            var dataExportName = Recording.GenerateAssetName("OpDataExport");
            var ExportData = new OperationalInsightsDataExportData()
            {
                DataExportId = Guid.NewGuid(),
                TableNames =
                {
                    "SecurityEvent"
                },
                EventHubName = eventHub.Data.Name,
                ResourceId  = eventHub.Data.Id
            };
            var dataExport = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, dataExportName, ExportData)).Value;
            Assert.IsNotNull(dataExport);
            Assert.AreEqual(dataExportName, dataExport.Data.Name);

            //OperationalInsightsDataExportCollection_Exist
            var exist = await _collection.ExistsAsync(dataExportName);
            Assert.IsTrue(exist);

            //OperationalInsightsDataExportCollection_Get
            var getResult = await _collection.GetAsync(dataExportName);
            Assert.IsNotEmpty(getResult.Value.Data.Id);
            Assert.AreEqual(getResult.Value.Data.Name, dataExport.Data.Name);

            //OperationalInsightsDataExportCollection_GetAll
            var eventHubName2 = Recording.GenerateAssetName("EventExport2nd");
            var eventHub2 = await CreateEventHubs(eventHubName2);
            var dataExportName2 = Recording.GenerateAssetName("OpDataExport2nd");
            var ExportData2 = new OperationalInsightsDataExportData()
            {
                DataExportId = Guid.NewGuid(),
                TableNames =
                {
                    "Export2"
                },
                ResourceId = eventHub2.Data.Id,
                EventHubName = eventHub2.Data.Name
            };
            var dataExport2 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, dataExportName2, ExportData2)).Value;
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count > 1);
            Assert.IsTrue(list.Exists(item => item.Data.Name == dataExport.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == dataExport2.Data.Name));
            await dataExport2.DeleteAsync(WaitUntil.Completed);

            //OperationalInsightsDataExportCollection_GetIfExists
            var getIfExists = (await _collection.GetIfExistsAsync(dataExportName)).Value;
            Assert.IsNotNull(getIfExists);
            Assert.AreEqual(dataExport.Data.Name, getIfExists.Data.Name);
            Assert.AreEqual(dataExport.Data.Id, getIfExists.Data.Id);

            //OperationalInsightsDataExportResource_CreateResourceIdentifier and Get
            var resourceId = OperationalInsightsDataExportResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId, _resourceGroup.Data.Name, workSpace.Data.Name,dataExport.Data.Name);
            var identifierResource = Client.GetOperationalInsightsDataExportResource(resourceId);
            Assert.IsNotNull(identifierResource);
            var verify = (await identifierResource.GetAsync()).Value; //Get
            Assert.IsNotNull(verify);
            Assert.AreEqual(dataExport.Data.Id, verify.Data.Id);
            Assert.AreEqual(dataExport.Data.Name, verify.Data.Name);

            //OperationalInsightsDataExportResource_Update
            var updateEventName = Recording.GenerateAssetName("exportUpdate");
            var updateEvent = await CreateEventHubs(updateEventName);
            var updateData = new OperationalInsightsDataExportData()
            {
                TableNames =
                {
                    "UpdateTest"
                },
                ResourceId = updateEvent.Data.Id,
                EventHubName  = updateEvent.Data.Name
            };
            var update = (await dataExport.UpdateAsync(WaitUntil.Completed, updateData)).Value;
            Assert.IsNotNull(update);
            Assert.IsFalse(update.Data.TableNames == dataExport.Data.TableNames);
            Assert.IsFalse(update.Data.ResourceId == dataExport.Data.ResourceId);
            Assert.IsFalse(update.Data.EventHubName == dataExport.Data.EventHubName);

            //OperationalInsightsDataExportResource_Delete
            var delete = await dataExport.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(delete.HasCompleted);
            Assert.IsFalse(await _collection.ExistsAsync(dataExportName));
            await workSpace.DeleteAsync(WaitUntil.Completed);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        public async Task<EventHubsNamespaceResource> CreateEventHubs(string eventHubName)
        {
            var eventHubData = new EventHubsNamespaceData(_location)
            {
                Sku = new EventHubsSku(EventHubsSkuName.Standard)
            };
            return (await _resourceGroup.GetEventHubsNamespaces().CreateOrUpdateAsync(WaitUntil.Completed, eventHubName, eventHubData)).Value;
        }
    }
}
