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

            string purchaseOrderOfficeSuppliesUrl = trainingFileUrl;
            string purchaseOrderOfficeEquipmentUrl = trainingFileUrl;
            string purchaseOrderFurnitureUrl = trainingFileUrl;
            string purchaseOrderCleaningSuppliesUrl = trainingFileUrl;

            #region Snippet:FormRecognizerSampleTrainVariousModels
            // For this sample, you can use the training forms found in the `trainingFiles` folder.
            // Upload the forms to your storage container and then generate a container SAS URL.
            // For instructions on setting up forms for training in an Azure Storage Blob Container, see
            // https://docs.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data

            //@@ string purchaseOrderOfficeSuppliesUrl = "<purchaseOrderOfficeSupplies>";
            //@@ string purchaseOrderOfficeEquipmentUrl = "<purchaseOrderOfficeEquipment>";
            //@@ string purchaseOrderFurnitureUrl = "<purchaseOrderFurniture>";
            //@@ string purchaseOrderCleaningSuppliesUrl = "<purchaseOrderCleaningSupplies>";

            Response<CustomFormModel> purchaseOrderOfficeSuppliesModel = await client.StartTrainingAsync(new Uri(purchaseOrderOfficeSuppliesUrl), useTrainingLabels: true, new TrainingOptions() { ModelDisplayName = "Purchase order - Office supplies" }).WaitForCompletionAsync();
            Response<CustomFormModel> purchaseOrderOfficeEquipmentModel = await client.StartTrainingAsync(new Uri(purchaseOrderOfficeEquipmentUrl), useTrainingLabels: true, new TrainingOptions() { ModelDisplayName = "Purchase order - Office Equipment" }).WaitForCompletionAsync();
            Response<CustomFormModel> purchaseOrderFurnitureModel = await client.StartTrainingAsync(new Uri(purchaseOrderFurnitureUrl), useTrainingLabels: true, new TrainingOptions() { ModelDisplayName = "Purchase order - Furniture" }).WaitForCompletionAsync();
            Response<CustomFormModel> purchaseOrderCleaningSuppliesModel = await client.StartTrainingAsync(new Uri(purchaseOrderCleaningSuppliesUrl), useTrainingLabels: true, new TrainingOptions() { ModelDisplayName = "Purchase order - Cleaning Supplies" }).WaitForCompletionAsync();

            #endregion

            #region Snippet:FormRecognizerSampleCreateComposedModel

            List<string> modelIds = new List<string>()
            {
                purchaseOrderOfficeSuppliesModel.Value.ModelId,
                purchaseOrderOfficeEquipmentModel.Value.ModelId,
                purchaseOrderFurnitureModel.Value.ModelId,
                purchaseOrderCleaningSuppliesModel.Value.ModelId
            };

            Response<CustomFormModel> purchaseOrderModelResponse = await client.StartCreateComposedModelAsync(modelIds).WaitForCompletionAsync();
            CustomFormModel purchaseOrderModel = purchaseOrderModelResponse.Value;

            Console.WriteLine($"Purchase Order Model Info:");
            Console.WriteLine($"    Is composed model: {purchaseOrderModel.Properties.IsComposedModel}");
            Console.WriteLine($"    Model Id: {purchaseOrderModel.ModelId}");
            Console.WriteLine($"    Model Status: {purchaseOrderModel.Status}");
            Console.WriteLine($"    Create model started on: {purchaseOrderModel.TrainingStartedOn}");
            Console.WriteLine($"    Create model completed on: {purchaseOrderModel.TrainingCompletedOn}");

            #endregion

            #region Snippet:FormRecognizerSampleSubmodelsInComposedModel

            Dictionary<string, List<TrainingDocumentInfo>> trainingDocsPerModel = purchaseOrderModel.TrainingDocuments.GroupBy(doc => doc.ModelId).ToDictionary(g => g.Key, g => g.ToList());

            Console.WriteLine($"The purchase order model is based on {purchaseOrderModel.Submodels.Count} model{(purchaseOrderModel.Submodels.Count > 1 ? "s" : "")}.");
            foreach (CustomFormSubmodel model in purchaseOrderModel.Submodels)
            {
                Console.WriteLine($"    Model Id: {model.ModelId}");
                Console.WriteLine("    The documents used to trained the model are: ");
                foreach (var doc in trainingDocsPerModel[model.ModelId])
                {
                    Console.WriteLine($"        {doc.Name}");
                }
            }

            #endregion

            string purchaseOrderFilePath = FormRecognizerTestEnvironment.CreatePath("Form_1.jpg");

            #region Snippet:FormRecognizerSampleRecognizeCustomFormWithComposedModel

            //@@ string purchaseOrderFilePath = "<purchaseOrderFilePath>";
            FormRecognizerClient formRecognizerClient = client.GetFormRecognizerClient();

            RecognizedFormCollection forms;
            using (FileStream stream = new FileStream(purchaseOrderFilePath, FileMode.Open))
            {
                forms = await formRecognizerClient.StartRecognizeCustomFormsAsync(purchaseOrderModel.ModelId, stream).WaitForCompletionAsync();

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
            }

            #endregion

            // Delete the models on completion to clean environment.
            await client.DeleteModelAsync(purchaseOrderOfficeSuppliesModel.Value.ModelId).ConfigureAwait(false);
            await client.DeleteModelAsync(purchaseOrderOfficeEquipmentModel.Value.ModelId).ConfigureAwait(false);
            await client.DeleteModelAsync(purchaseOrderFurnitureModel.Value.ModelId).ConfigureAwait(false);
            await client.DeleteModelAsync(purchaseOrderCleaningSuppliesModel.Value.ModelId).ConfigureAwait(false);
            await client.DeleteModelAsync(purchaseOrderModel.ModelId).ConfigureAwait(false);
        }
    }
}
