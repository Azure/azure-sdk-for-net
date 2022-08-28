// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples : SamplesBase<DocumentAnalysisTestEnvironment>
    {
        [RecordedTest]
        public async Task ComposeModelAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;

            var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerSampleBuildVariousModels
            // For this sample, you can use the training forms found in the `trainingFiles` folder.
            // Upload the forms to your storage container and then generate a container SAS URL.
            // For instructions on setting up forms for training in an Azure Storage Blob Container, see
            // https://aka.ms/azsdk/formrecognizer/buildtrainingset

#if SNIPPET
            Uri officeSuppliesUri = new Uri("<purchaseOrderOfficeSuppliesUri>");
#else
            Uri officeSuppliesUri = new Uri(trainingFileUrl);
#endif
            var officeSupplieOptions = new BuildModelOptions() { Description = "Purchase order - Office supplies" };

            BuildModelOperation suppliesOperation = await client.BuildModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: officeSupplieOptions);
            DocumentModelDetails officeSuppliesModel = suppliesOperation.Value;

#if SNIPPET
            Uri officeEquipmentUri = new Uri("<purchaseOrderOfficeEquipmentUri>");
#else
            Uri officeEquipmentUri = new Uri(trainingFileUrl);
#endif
            var equipmentOptions = new BuildModelOptions() { Description = "Purchase order - Office Equipment" };

            BuildModelOperation equipmentOperation = await client.BuildModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: equipmentOptions);
            DocumentModelDetails officeEquipmentModel = equipmentOperation.Value;

#if SNIPPET
            Uri furnitureUri = new Uri("<purchaseOrderFurnitureUri>");
#else
            Uri furnitureUri = new Uri(trainingFileUrl);
#endif
            var furnitureOptions = new BuildModelOptions() { Description = "Purchase order - Furniture" };

            BuildModelOperation furnitureOperation = await client.BuildModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: equipmentOptions);
            DocumentModelDetails furnitureModel = furnitureOperation.Value;

#if SNIPPET
            Uri cleaningSuppliesUri = new Uri("<purchaseOrderCleaningSuppliesUri>");
#else
            Uri cleaningSuppliesUri = new Uri(trainingFileUrl);
#endif
            var cleaningOptions = new BuildModelOptions() { Description = "Purchase order - Cleaning Supplies" };

            BuildModelOperation cleaningOperation = await client.BuildModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: equipmentOptions);
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

            ComposeModelOperation operation = await client.ComposeModelAsync(WaitUntil.Completed, modelIds, description: "Composed Purchase order");
            DocumentModelDetails purchaseOrderModel = operation.Value;

            Console.WriteLine($"  Model Id: {purchaseOrderModel.ModelId}");
            if (string.IsNullOrEmpty(purchaseOrderModel.Description))
                Console.WriteLine($"  Model description: {purchaseOrderModel.Description}");
            Console.WriteLine($"  Created on: {purchaseOrderModel.CreatedOn}");

            #endregion

            // Delete the models on completion to clean environment.
            await client.DeleteModelAsync(officeSuppliesModel.ModelId).ConfigureAwait(false);
            await client.DeleteModelAsync(officeEquipmentModel.ModelId).ConfigureAwait(false);
            await client.DeleteModelAsync(furnitureModel.ModelId).ConfigureAwait(false);
            await client.DeleteModelAsync(cleaningSuppliesModel.ModelId).ConfigureAwait(false);
            await client.DeleteModelAsync(purchaseOrderModel.ModelId).ConfigureAwait(false);
        }
    }
}
