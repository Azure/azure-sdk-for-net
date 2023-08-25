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
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using NUnit.Framework;

namespace Azure.ResourceManager.CostManagement.Tests
{
    internal class ExportTests : CostManagementManagementTestBase
    {
        private CostManagementExportCollection _exportCollection;
        private ResourceGroupResource _resourceGroup;

        public ExportTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _exportCollection = Client.GetCostManagementExports(DefaultScope);
            _resourceGroup = await CreateResourceGroup();
        }

        private async Task<CostManagementExportResource> CreateExport(string exportName, ResourceIdentifier storageAccountId)
        {
            string containerName = "exportcontainer";
            ExportDeliveryDestination exportDeliveryDestination = new ExportDeliveryDestination(containerName)
            {
                ResourceId = new ResourceIdentifier(storageAccountId),
            };
            var data = new CostManagementExportData()
            {
                Format = ExportFormatType.Csv,
                Definition = new ExportDefinition(ExportType.Usage, TimeframeType.TheLastMonth),
                DeliveryInfo = new ExportDeliveryInfo(exportDeliveryDestination),
            };
            var export = await _exportCollection.CreateOrUpdateAsync(WaitUntil.Completed, exportName, data);
            return export.Value;
        }

        [RecordedTest]
        //[Ignore("Linked issue: https://github.com/Azure/azure-rest-api-specs/issues/23704")] //customization as the temporary workaround
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // create a storage account
            string exportName = Recording.GenerateAssetName("export");
            string storageAccountName = Recording.GenerateAssetName("azstorageforcost");
            await CreateStorageAccount(_resourceGroup, storageAccountName);
            var saId = StorageAccountResource.CreateResourceIdentifier(_resourceGroup.Id.SubscriptionId, _resourceGroup.Id.Name, storageAccountName);

            // CreateOrUpdate
            var export = await CreateExport(exportName, saId);
            ValidateCostManagementExport(export.Data, exportName);

            // Exist
            var flag = await _exportCollection.ExistsAsync(exportName);
            Assert.IsTrue(flag);

            // Get
            var getexport = await _exportCollection.GetAsync(exportName);
            ValidateCostManagementExport(getexport.Value.Data, exportName);

            // GetAll
            var list = await _exportCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateCostManagementExport(list.FirstOrDefault(item => item.Data.Name == exportName).Data, exportName);

            // Delete
            await export.DeleteAsync(WaitUntil.Completed);
        }

        private void ValidateCostManagementExport(CostManagementExportData export, string exportName)
        {
            Assert.IsNotNull(export);
            Assert.IsNotEmpty(export.Id);
            Assert.AreEqual(exportName, export.Name);
            Assert.AreEqual(ExportFormatType.Csv, export.Format);
        }
    }
}
