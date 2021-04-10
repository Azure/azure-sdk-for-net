// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Tests;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples : SamplesBase<FormRecognizerTestEnvironment>
    {
        [Test]
        public async Task TrainModelWithFormsAndLabels()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            #region Snippet:FormRecognizerSampleTrainModelWithFormsAndLabels
            // For this sample, you can use the training forms found in the `trainingFiles` folder.
            // Upload the forms to your storage container and then generate a container SAS URL.
            // For instructions to set up forms for training in an Azure Storage Blob Container, please see:
            // https://docs.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data

            // For instructions to create a label file for your training forms, please see:
            // https://docs.microsoft.com/azure/cognitive-services/form-recognizer/quickstarts/label-tool

            //@@ Uri trainingFileUri = <trainingFileUri>;
            string modelName = "My Model with labels";
            FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            TrainingOperation operation = await client.StartTrainingAsync(trainingFileUri, useTrainingLabels: true, modelName);
            Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
            CustomFormModel model = operationResponse.Value;

            Console.WriteLine($"Custom Model Info:");
            Console.WriteLine($"  Model Id: {model.ModelId}");
            Console.WriteLine($"  Model name: {model.ModelName}");
            Console.WriteLine($"  Model Status: {model.Status}");
            Console.WriteLine($"  Is composed model: {model.Properties.IsComposedModel}");
            Console.WriteLine($"  Training model started on: {model.TrainingStartedOn}");
            Console.WriteLine($"  Training model completed on: {model.TrainingCompletedOn}");

            foreach (CustomFormSubmodel submodel in model.Submodels)
            {
                Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
                foreach (CustomFormModelField field in submodel.Fields.Values)
                {
                    Console.Write($"  FieldName: {field.Name}");
                    if (field.Accuracy != null)
                    {
                        Console.Write($", Accuracy: {field.Accuracy}");
                    }
                    Console.WriteLine("");
                }
            }
            #endregion

            // Delete the model on completion to clean environment.
            await client.DeleteModelAsync(model.ModelId);
        }
    }
}
