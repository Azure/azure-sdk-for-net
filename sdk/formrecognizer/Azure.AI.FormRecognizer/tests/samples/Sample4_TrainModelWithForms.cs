// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Tests;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.Testing;
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

            #region Snippet:FormRecognizerSample4TrainModelWithForms
            // For instructions on setting up forms for training in an Azure Storage Blob Container, see
            // https://docs.microsoft.com/azure/cognitive-services/form-recognizer/quickstarts/curl-train-extract#train-a-form-recognizer-model

            FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            CustomFormModel model = await client.StartTrainingAsync(new Uri(trainingFileUrl)).WaitForCompletionAsync();

            Console.WriteLine($"Custom Model Info:");
            Console.WriteLine($"    Model Id: {model.ModelId}");
            Console.WriteLine($"    Model Status: {model.Status}");
            Console.WriteLine($"    Created On: {model.CreatedOn}");
            Console.WriteLine($"    Last Modified: {model.LastModified}");

            foreach (CustomFormSubModel subModel in model.Models)
            {
                Console.WriteLine($"SubModel Form Type: {subModel.FormType}");
                foreach (CustomFormModelField field in subModel.Fields.Values)
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
            client.DeleteModel(model.ModelId);
        }
    }
}
