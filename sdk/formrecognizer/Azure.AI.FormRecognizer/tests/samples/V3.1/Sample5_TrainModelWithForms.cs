// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples
    {
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        public async Task TrainModelWithForms()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:FormRecognizerSampleTrainModelWithForms
            // For this sample, you can use the training forms found in the `trainingFiles` folder.
            // Upload the forms to your storage container and then generate a container SAS URL. Note
            // that a container URI without SAS is accepted only when the container is public or has a
            // managed identity configured.
            //
            // For instructions on setting up forms for training in an Azure Blob Storage Container, see
            // https://learn.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data

#if SNIPPET
            Uri trainingFileUri = new Uri("<trainingFileUri>");
#else
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            TrainingOperation operation = await client.StartTrainingAsync(trainingFileUri, useTrainingLabels: false, "My Model");
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
                    if (field.Label != null)
                    {
                        Console.Write($", FieldLabel: {field.Label}");
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
