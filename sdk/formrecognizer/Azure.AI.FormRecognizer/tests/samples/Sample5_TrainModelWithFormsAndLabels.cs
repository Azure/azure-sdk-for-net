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
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;

            #region Snippet:FormRecognizerSample5TrainModelWithFormsAndLabels
            // For instructions to set up forms for training in an Azure Storage Blob Container, please see:
            // https://docs.microsoft.com/en-us/azure/cognitive-services/form-recognizer/quickstarts/curl-train-extract#train-a-form-recognizer-model

            // For instructions to create a label file for your training forms, please see:
            // https://docs.microsoft.com/en-us/azure/cognitive-services/form-recognizer/quickstarts/label-tool

            FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            CustomFormModel model = await client.StartTrainingAsync(new Uri(trainingFileUrl), useTrainingLabels: true).WaitForCompletionAsync();

            Console.WriteLine($"Custom Model Info:");
            Console.WriteLine($"    Model Id: {model.ModelId}");
            Console.WriteLine($"    Model Status: {model.Status}");
            Console.WriteLine($"    Requested on: {model.RequestedOn}");
            Console.WriteLine($"    Completed on: {model.CompletedOn}");

            foreach (CustomFormSubmodel submodel in model.Submodels)
            {
                Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
                foreach (CustomFormModelField field in submodel.Fields.Values)
                {
                    Console.Write($"    FieldName: {field.Name}");
                    if (field.Accuracy != null)
                    {
                        Console.Write($", Accuracy: {field.Accuracy}");
                    }
                    Console.WriteLine("");
                }
            }
            #endregion

            // Delete the model on completion to clean environment.
            client.DeleteModel(model.ModelId);
        }
    }
}
