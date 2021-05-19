// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples : SamplesBase<FormRecognizerTestEnvironment>
    {
        [Test]
        public async Task CreateComposedModel()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;

            FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            Uri officeSuppliesUri = new Uri(trainingFileUrl);
            Uri officeEquipmentUri = new Uri(trainingFileUrl);
            Uri furnitureUri = new Uri(trainingFileUrl);
            Uri cleaningSuppliesUri = new Uri(trainingFileUrl);

            #region Snippet:FormRecognizerSampleTrainVariousModels
            // For this sample, you can use the training forms found in the `trainingFiles` folder.
            // Upload the forms to your storage container and then generate a container SAS URL.
            // For instructions on setting up forms for training in an Azure Storage Blob Container, see
            // https://docs.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data

            bool useLabels = true;

            //@@ Uri officeSuppliesUri = <purchaseOrderOfficeSuppliesUri>;
            string suppliesModelName = "Purchase order - Office supplies";

            TrainingOperation suppliesOperation = await client.StartTrainingAsync(officeSuppliesUri, useLabels, suppliesModelName);
            Response<CustomFormModel> suppliesOperationResponse = await suppliesOperation.WaitForCompletionAsync();
            CustomFormModel officeSuppliesModel = suppliesOperationResponse.Value;

            //@@ Uri officeEquipmentUri = <purchaseOrderOfficeEquipmentUri>;
            string equipmentModelName = "Purchase order - Office Equipment";

            TrainingOperation equipmentOperation = await client.StartTrainingAsync(officeEquipmentUri, useLabels, equipmentModelName);
            Response<CustomFormModel> equipmentOperationResponse = await equipmentOperation.WaitForCompletionAsync();
            CustomFormModel officeEquipmentModel = equipmentOperationResponse.Value;

            //@@ Uri furnitureUri = <purchaseOrderFurnitureUri>;
            string furnitureModelName = "Purchase order - Furniture";

            TrainingOperation furnitureOperation = await client.StartTrainingAsync(furnitureUri, useLabels, furnitureModelName);
            Response<CustomFormModel> furnitureOperationResponse = await furnitureOperation.WaitForCompletionAsync();
            CustomFormModel furnitureModel = furnitureOperationResponse.Value;

            //@@ Uri cleaningSuppliesUri = <purchaseOrderCleaningSuppliesUri>;
            string cleaningModelName = "Purchase order - Cleaning Supplies";

            TrainingOperation cleaningOperation = await client.StartTrainingAsync(cleaningSuppliesUri, useLabels, cleaningModelName);
            Response<CustomFormModel> cleaningOperationResponse = await cleaningOperation.WaitForCompletionAsync();
            CustomFormModel cleaningSuppliesModel = cleaningOperationResponse.Value;

            #endregion

            #region Snippet:FormRecognizerSampleCreateComposedModel

            List<string> modelIds = new List<string>()
            {
                officeSuppliesModel.ModelId,
                officeEquipmentModel.ModelId,
                furnitureModel.ModelId,
                cleaningSuppliesModel.ModelId
            };

            string purchaseModelName = "Composed Purchase order";
            CreateComposedModelOperation operation = await client.StartCreateComposedModelAsync(modelIds, purchaseModelName);
            Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
            CustomFormModel purchaseOrderModel = operationResponse.Value;

            Console.WriteLine($"Purchase Order Model Info:");
            Console.WriteLine($"  Is composed model: {purchaseOrderModel.Properties.IsComposedModel}");
            Console.WriteLine($"  Model Id: {purchaseOrderModel.ModelId}");
            Console.WriteLine($"  Model name: {purchaseOrderModel.ModelName}");
            Console.WriteLine($"  Model Status: {purchaseOrderModel.Status}");
            Console.WriteLine($"  Create model started on: {purchaseOrderModel.TrainingStartedOn}");
            Console.WriteLine($"  Create model completed on: {purchaseOrderModel.TrainingCompletedOn}");

            #endregion

            #region Snippet:FormRecognizerSampleSubmodelsInComposedModel

            Dictionary<string, List<TrainingDocumentInfo>> trainingDocsPerModel;
            trainingDocsPerModel = purchaseOrderModel.TrainingDocuments.GroupBy(doc => doc.ModelId).ToDictionary(g => g.Key, g => g.ToList());

            Console.WriteLine($"The purchase order model is based on {purchaseOrderModel.Submodels.Count} models");

            foreach (CustomFormSubmodel model in purchaseOrderModel.Submodels)
            {
                Console.WriteLine($"  Model Id: {model.ModelId}");
                Console.WriteLine("  The documents used to trained the model are: ");
                foreach (var doc in trainingDocsPerModel[model.ModelId])
                {
                    Console.WriteLine($"    {doc.Name}");
                }
            }

            #endregion

            string purchaseOrderFilePath = FormRecognizerTestEnvironment.CreatePath("Form_1.jpg");

            #region Snippet:FormRecognizerSampleRecognizeCustomFormWithComposedModel

            //@@ string purchaseOrderFilePath = "<purchaseOrderFilePath>";
            FormRecognizerClient recognizeClient = client.GetFormRecognizerClient();
            using var stream = new FileStream(purchaseOrderFilePath, FileMode.Open);

            RecognizeCustomFormsOperation recognizeOperation = await recognizeClient.StartRecognizeCustomFormsAsync(purchaseOrderModel.ModelId, stream);
            Response<RecognizedFormCollection> recognizeOperationResponse = await recognizeOperation.WaitForCompletionAsync();
            RecognizedFormCollection forms = recognizeOperationResponse.Value;

            // Find labeled field.
            foreach (RecognizedForm form in forms)
            {
                // Setting an arbitrary confidence level
                if (form.FormTypeConfidence.Value > 0.9)
                {
                    if (form.Fields.TryGetValue("Total", out FormField field))
                    {
                        Console.WriteLine($"Total value in the form `{form.FormType}` is `{field.ValueData.Text}`");
                    }
                }
                else
                {
                    Console.WriteLine("Unable to recognize form.");
                }
            }

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
