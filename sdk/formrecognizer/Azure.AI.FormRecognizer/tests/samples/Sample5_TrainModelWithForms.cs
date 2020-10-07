﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public async Task TrainModelWithForms()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;

            #region Snippet:FormRecognizerSampleTrainModelWithForms
            // For this sample, you can use the training forms found in the `trainingFiles` folder.
            // Upload the forms to your storage container and then generate a container SAS URL.
            // For instructions on setting up forms for training in an Azure Storage Blob Container, see
            // https://docs.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data

            FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            CustomFormModel model = await client.StartTrainingAsync(new Uri(trainingFileUrl), useTrainingLabels: false, new TrainingOptions() { ModelDisplayName = "My Model" }).WaitForCompletionAsync();

            Console.WriteLine($"Custom Model Info:");
            Console.WriteLine($"    Model Id: {model.ModelId}");
            Console.WriteLine($"    Model display name: {model.DisplayName}");
            Console.WriteLine($"    Model Status: {model.Status}");
            Console.WriteLine($"    Is composed model: {model.Properties.IsComposedModel}");
            Console.WriteLine($"    Training model started on: {model.TrainingStartedOn}");
            Console.WriteLine($"    Training model completed on: {model.TrainingCompletedOn}");

            foreach (CustomFormSubmodel submodel in model.Submodels)
            {
                Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
                foreach (CustomFormModelField field in submodel.Fields.Values)
                {
                    Console.Write($"    FieldName: {field.Name}");
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
