// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Samples
{
    public partial class DocumentIntelligenceSamples
    {
        [RecordedTest]
        public async Task ComposeModelAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DocumentIntelligenceSampleBuildVariousModels
            // For this sample, you can use the training documents found in the `trainingFiles` folder.
            // Upload the documents to your storage container and then generate a container SAS URL.
            // For instructions on setting up documents for training in an Azure Storage Blob Container, see
            // https://aka.ms/azsdk/formrecognizer/buildtrainingset

#if SNIPPET
            string officeSuppliesModelId = "<officeSuppliesModelId>";
            Uri officeSuppliesUri = new Uri("<officeSuppliesUri>");
#else
            string officeSuppliesModelId = Guid.NewGuid().ToString();
            Uri officeSuppliesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            var officeSuppliesRequest = new BuildDocumentModelRequest(officeSuppliesModelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(officeSuppliesUri),
                Description = "Purchase order - Office supplies"
            };

            Operation<DocumentModelDetails> officeSuppliesOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeSuppliesRequest);
            DocumentModelDetails officeSuppliesModel = officeSuppliesOperation.Value;

#if SNIPPET
            string officeEquipmentModelId = "<officeEquipmentModelId>";
            Uri officeEquipmentUri = new Uri("<officeEquipmentUri>");
#else
            string officeEquipmentModelId = Guid.NewGuid().ToString();
            Uri officeEquipmentUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            var officeEquipmentRequest = new BuildDocumentModelRequest(officeEquipmentModelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(officeEquipmentUri),
                Description = "Purchase order - Office Equipment"
            };

            Operation<DocumentModelDetails> officeEquipmentOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeEquipmentRequest);
            DocumentModelDetails officeEquipmentModel = officeEquipmentOperation.Value;

#if SNIPPET
            string furnitureModelId = "<furnitureModelId>";
            Uri furnitureUri = new Uri("<purchaseOrderFurnitureUri>");
#else
            string furnitureModelId = Guid.NewGuid().ToString();
            Uri furnitureUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            var furnitureRequest = new BuildDocumentModelRequest(furnitureModelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(furnitureUri),
                Description = "Purchase order - Furniture"
            };

            Operation<DocumentModelDetails> furnitureOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, furnitureRequest);
            DocumentModelDetails furnitureModel = furnitureOperation.Value;

#if SNIPPET
            string cleaningSuppliesModelId = "<cleaningSuppliesModelId>";
            Uri cleaningSuppliesUri = new Uri("<cleaningSuppliesUri>");
#else
            string cleaningSuppliesModelId = Guid.NewGuid().ToString();
            Uri cleaningSuppliesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            var cleaningSuppliesRequest = new BuildDocumentModelRequest(cleaningSuppliesModelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(cleaningSuppliesUri),
                Description = "Purchase order - Cleaning Supplies"
            };

            Operation<DocumentModelDetails> cleaningSuppliesOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, cleaningSuppliesRequest);
            DocumentModelDetails cleaningSuppliesModel = cleaningSuppliesOperation.Value;
            #endregion

            #region Snippet:DocumentIntelligenceSampleComposeModel
#if SNIPPET
            string purchaseOrderModelId = "<purchaseOrderModelId>";
#else
            string purchaseOrderModelId = Guid.NewGuid().ToString();
#endif
            var componentModelIds = new List<ComponentDocumentModelDetails>()
            {
                new ComponentDocumentModelDetails(officeSuppliesModelId),
                new ComponentDocumentModelDetails(officeEquipmentModelId),
                new ComponentDocumentModelDetails(furnitureModelId),
                new ComponentDocumentModelDetails(cleaningSuppliesModelId)
            };
            var purchaseOrderRequest = new ComposeDocumentModelRequest("", componentModelIds)
            {
                Description = "Composed Purchase order"
            };

            Operation<DocumentModelDetails> purchaseOrderOperation = await client.ComposeModelAsync(WaitUntil.Completed, purchaseOrderRequest);
            DocumentModelDetails purchaseOrderModel = purchaseOrderOperation.Value;

            Console.WriteLine($"Model ID: {purchaseOrderModel.ModelId}");
            Console.WriteLine($"Model description: {purchaseOrderModel.Description}");
            Console.WriteLine($"Created on: {purchaseOrderModel.CreatedDateTime}");
            #endregion

            // Delete the models on completion to clean environment.
            await client.DeleteModelAsync(officeSuppliesModelId);
            await client.DeleteModelAsync(officeEquipmentModelId);
            await client.DeleteModelAsync(furnitureModelId);
            await client.DeleteModelAsync(cleaningSuppliesModelId);
            await client.DeleteModelAsync(purchaseOrderModelId);
        }
    }
}
