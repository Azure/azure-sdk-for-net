// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples
    {
        [RecordedTest]
        public async Task ComposeModelAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;

            var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerSampleBuildVariousModels
            // For this sample, you can use the training documents found in the `trainingFiles` folder.
            // Upload the documents to your storage container and then generate a container SAS URL.
            // For instructions on setting up documents for training in an Azure Storage Blob Container, see
            // https://aka.ms/azsdk/formrecognizer/buildtrainingset

#if SNIPPET
            Uri officeSuppliesUri = new Uri("<purchaseOrderOfficeSuppliesUri>");
#else
            Uri officeSuppliesUri = new Uri(trainingFileUrl);
#endif
            var officeSupplieOptions = new BuildDocumentModelOptions() { Description = "Purchase order - Office supplies" };

            BuildDocumentModelOperation suppliesOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: officeSupplieOptions);
            DocumentModelDetails officeSuppliesModel = suppliesOperation.Value;

#if SNIPPET
            Uri officeEquipmentUri = new Uri("<purchaseOrderOfficeEquipmentUri>");
#else
            Uri officeEquipmentUri = new Uri(trainingFileUrl);
#endif
            var equipmentOptions = new BuildDocumentModelOptions() { Description = "Purchase order - Office Equipment" };

            BuildDocumentModelOperation equipmentOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: equipmentOptions);
            DocumentModelDetails officeEquipmentModel = equipmentOperation.Value;

#if SNIPPET
            Uri furnitureUri = new Uri("<purchaseOrderFurnitureUri>");
#else
            Uri furnitureUri = new Uri(trainingFileUrl);
#endif
            var furnitureOptions = new BuildDocumentModelOptions() { Description = "Purchase order - Furniture" };

            BuildDocumentModelOperation furnitureOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: equipmentOptions);
            DocumentModelDetails furnitureModel = furnitureOperation.Value;

#if SNIPPET
            Uri cleaningSuppliesUri = new Uri("<purchaseOrderCleaningSuppliesUri>");
#else
            Uri cleaningSuppliesUri = new Uri(trainingFileUrl);
#endif
            var cleaningOptions = new BuildDocumentModelOptions() { Description = "Purchase order - Cleaning Supplies" };

            BuildDocumentModelOperation cleaningOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: equipmentOptions);
            DocumentModelDetails cleaningSuppliesModel = cleaningOperation.Value;

            #endregion

            #region Snippet:FormRecognizerSampleComposeModel

            List<string> modelIds = new List<string>()
            {
                officeSuppliesModel.ModelId,
                officeEquipmentModel.ModelId,
                furnitureModel.ModelId,
                cleaningSuppliesModel.ModelId
            };

            ComposeDocumentModelOperation operation = await client.ComposeDocumentModelAsync(WaitUntil.Completed, modelIds, description: "Composed Purchase order");
            DocumentModelDetails purchaseOrderModel = operation.Value;

            Console.WriteLine($"  Model Id: {purchaseOrderModel.ModelId}");
            if (string.IsNullOrEmpty(purchaseOrderModel.Description))
                Console.WriteLine($"  Model description: {purchaseOrderModel.Description}");
            Console.WriteLine($"  Created on: {purchaseOrderModel.CreatedOn}");

            #endregion

            // Delete the models on completion to clean environment.
            await client.DeleteDocumentModelAsync(officeSuppliesModel.ModelId).ConfigureAwait(false);
            await client.DeleteDocumentModelAsync(officeEquipmentModel.ModelId).ConfigureAwait(false);
            await client.DeleteDocumentModelAsync(furnitureModel.ModelId).ConfigureAwait(false);
            await client.DeleteDocumentModelAsync(cleaningSuppliesModel.ModelId).ConfigureAwait(false);
            await client.DeleteDocumentModelAsync(purchaseOrderModel.ModelId).ConfigureAwait(false);
        }
    }
}
