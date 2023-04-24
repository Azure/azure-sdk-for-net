// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CostManagement.Models;
using Azure.ResourceManager.Storage;
using NUnit.Framework;

namespace Azure.ResourceManager.CostManagement.Tests
{
    internal class ExportTests : CostManagementManagementTestBase
    {
        private CostManagementExportCollection _exportCollection;

        public ExportTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _exportCollection = Client.GetCostManagementExports(DefaultScope);
        }

        [RecordedTest]
        [Ignore("service issue: returned id is not start with /")]
        public async Task List()
        {
            var list = await _exportCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }

        [RecordedTest]
        [Ignore("service issue: returned id is not start with /")]
        public async Task Get()
        {
            var list = await _exportCollection.GetAsync("export230424");
        }

        [RecordedTest]
        [Ignore("service issue: returned id is not start with /")]
        public async Task Create()
        {
            var rg = await CreateResourceGroup();
            string storageAccountName = Recording.GenerateAssetName("azstorageforcost");
            string exportName = Recording.GenerateAssetName("export");
            await CreateStorageAccount(rg, storageAccountName);
            var saId = StorageAccountResource.CreateResourceIdentifier(rg.Id.SubscriptionId, rg.Id.Name, storageAccountName);
            ExportDeliveryDestination exportDeliveryDestination = new ExportDeliveryDestination("container152")
            {
                ResourceId = new ResourceIdentifier(saId),
            };
            var data = new CostManagementExportData()
            {
                Format = ExportFormatType.Csv,
                Definition = new ExportDefinition(ExportType.Usage, TimeframeType.TheLastMonth),
                DeliveryInfo = new ExportDeliveryInfo(exportDeliveryDestination),
            };
            var export = await _exportCollection.CreateOrUpdateAsync(WaitUntil.Completed, exportName, data);
            Assert.IsNotNull(export);

            await export.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
