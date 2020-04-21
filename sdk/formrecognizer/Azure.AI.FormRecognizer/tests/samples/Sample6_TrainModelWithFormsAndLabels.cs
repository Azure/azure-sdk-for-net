// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    [LiveOnly]
    public partial class FormRecognizerSamples
    {
        [Test]
        public async Task TrainModelWithFormsAndLabels()
        {
            string endpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");
            string apiKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_API_KEY");
            string trainingFileUrl = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_BLOB_CONTAINER_SAS_URL");

            // For instructions to set up forms for training in an Azure Storage Blob Container, please see:
            // https://docs.microsoft.com/en-us/azure/cognitive-services/form-recognizer/quickstarts/curl-train-extract#train-a-form-recognizer-model

            // For instructions to create a label file for your training forms, please see:
            // https://docs.microsoft.com/en-us/azure/cognitive-services/form-recognizer/quickstarts/label-tool

            FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            CustomFormModel model = await client.StartTrainingAsync(new Uri(trainingFileUrl), useLabels: true).WaitForCompletionAsync();

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
                    if (field.Accuracy != null)
                    {
                        Console.Write($", Accuracy: {field.Accuracy}");
                    }
                    Console.WriteLine("");
                }
            }

            // Delete the model on completion.
            client.DeleteModel(model.ModelId);
        }
    }
}
