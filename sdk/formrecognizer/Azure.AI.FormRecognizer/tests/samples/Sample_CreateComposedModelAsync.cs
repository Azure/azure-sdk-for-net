// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples : SamplesBase<DocumentAnalysisTestEnvironment>
    {
        [Test]
        public async Task CreateComposedModelAsync()
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
            var officeSupplieOptions = new BuildModelOptions() { ModelDescription = "Purchase order - Office supplies" };

            BuildModelOperation suppliesOperation = await client.StartBuildModelAsync(officeSuppliesUri, DocumentBuildMode.Template, buildModelOptions: officeSupplieOptions);
            Response<DocumentModel> suppliesOperationResponse = await suppliesOperation.WaitForCompletionAsync();
            DocumentModel officeSuppliesModel = suppliesOperationResponse.Value;

#if SNIPPET
            Uri officeEquipmentUri = new Uri("<purchaseOrderOfficeEquipmentUri>");
#else
            Uri officeEquipmentUri = new Uri(trainingFileUrl);
#endif
            var equipmentOptions = new BuildModelOptions() { ModelDescription = "Purchase order - Office Equipment" };

            BuildModelOperation equipmentOperation = await client.StartBuildModelAsync(officeSuppliesUri, DocumentBuildMode.Template, buildModelOptions: equipmentOptions);
            Response<DocumentModel> equipmentOperationResponse = await equipmentOperation.WaitForCompletionAsync();
            DocumentModel officeEquipmentModel = equipmentOperationResponse.Value;

#if SNIPPET
            Uri furnitureUri = new Uri("<purchaseOrderFurnitureUri>");
#else
            Uri furnitureUri = new Uri(trainingFileUrl);
#endif
            var furnitureOptions = new BuildModelOptions() { ModelDescription = "Purchase order - Furniture" };

            BuildModelOperation furnitureOperation = await client.StartBuildModelAsync(officeSuppliesUri, DocumentBuildMode.Template, buildModelOptions: equipmentOptions);
            Response<DocumentModel> furnitureOperationResponse = await furnitureOperation.WaitForCompletionAsync();
            DocumentModel furnitureModel = furnitureOperationResponse.Value;

#if SNIPPET
            Uri cleaningSuppliesUri = new Uri("<purchaseOrderCleaningSuppliesUri>");
#else
            Uri cleaningSuppliesUri = new Uri(trainingFileUrl);
#endif
            var cleaningOptions = new BuildModelOptions() { ModelDescription = "Purchase order - Cleaning Supplies" };

            BuildModelOperation cleaningOperation = await client.StartBuildModelAsync(officeSuppliesUri, DocumentBuildMode.Template, buildModelOptions: equipmentOptions);
            Response<DocumentModel> cleaningOperationResponse = await cleaningOperation.WaitForCompletionAsync();
            DocumentModel cleaningSuppliesModel = cleaningOperationResponse.Value;

            #endregion

            #region Snippet:FormRecognizerSampleCreateComposedModel

            List<string> modelIds = new List<string>()
            {
                officeSuppliesModel.ModelId,
                officeEquipmentModel.ModelId,
                furnitureModel.ModelId,
                cleaningSuppliesModel.ModelId
            };

            BuildModelOperation operation = await client.StartCreateComposedModelAsync(modelIds, modelDescription: "Composed Purchase order");
            Response<DocumentModel> operationResponse = await operation.WaitForCompletionAsync();
            DocumentModel purchaseOrderModel = operationResponse.Value;

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
