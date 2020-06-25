// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
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
        /// This sample demonstrates the differences in output that arise when StartRecognizeCustomForms
        /// is called with custom models trained with labels and without labels.

        [Test]
        public async Task OutputModelsTrainedWithLabels()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;
            string formFilePath = FormRecognizerTestEnvironment.CreatePath("Form_1.jpg");

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            FormTrainingClient trainingClient = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Model trained with labels
            CustomFormModel modelTrainedWithLabels = await trainingClient.StartTraining(new Uri(trainingFileUrl), useTrainingLabels: true).WaitForCompletionAsync();

            using (FileStream stream = new FileStream(formFilePath, FileMode.Open))
            {
                RecognizedFormCollection forms = await client.StartRecognizeCustomForms(modelTrainedWithLabels.ModelId, stream).WaitForCompletionAsync();

                // With a form recognized by a model trained with labels, the 'field.Name' key will be the label
                // that you gave it at training time.
                // Note that Label data is not returned for model trained with labels, as the trained model
                // contains this information and therefore the service returns the value of the recognized label.
                Console.WriteLine("---------Recognizing forms using models trained with labels---------");
                foreach (RecognizedForm form in forms)
                {
                    Console.WriteLine($"Form of type: {form.FormType}");
                    foreach (FormField field in form.Fields.Values)
                    {
                        Console.WriteLine($"Field {field.Name}: ");
                        Console.WriteLine($"    Value: '{field.ValueText.Text}");
                        Console.WriteLine($"    Confidence: '{field.Confidence}");
                    }
                }

                // Find a specific labeled field.
                // For this particular sample, we will look for the known training-time label 'VendorName'.
                Console.WriteLine("Find the value for a specific labeled field:");
                foreach (RecognizedForm form in forms)
                {
                    if (form.Fields.TryGetValue("VendorName", out FormField field))
                    {
                        Console.WriteLine($"VendorName is {field.ValueText.Text}");
                    }
                }
            }
        }

        [Test]
        public async Task OutputModelsTrainedWithoutLabels()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;
            string formFilePath = FormRecognizerTestEnvironment.CreatePath("Form_1.jpg");

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            FormTrainingClient trainingClient = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Model trained without labels
            CustomFormModel modelTrainedWithoutLabels = await trainingClient.StartTraining(new Uri(trainingFileUrl), useTrainingLabels: false).WaitForCompletionAsync();

            using (FileStream stream = new FileStream(formFilePath, FileMode.Open))
            {
                RecognizedFormCollection forms = await client.StartRecognizeCustomForms(modelTrainedWithoutLabels.ModelId, stream).WaitForCompletionAsync();

                // With a form recognized by a model trained without labels, the 'field.Name' property will be denoted
                // by a numeric index.
                Console.WriteLine("---------Recognizing forms using models trained without labels---------");
                foreach (RecognizedForm form in forms)
                {
                    Console.WriteLine($"Form of type: {form.FormType}");
                    foreach (FormField field in form.Fields.Values)
                    {
                        Console.WriteLine($"Field {field.Name}: ");

                        if (field.LabelText != null)
                        {
                            Console.WriteLine($"    Label: '{field.LabelText.Text}");
                        }

                        Console.WriteLine($"    Value: '{field.ValueText.Text}");
                        Console.WriteLine($"    Confidence: '{field.Confidence}");
                    }
                }

                // Find the value of a specific unlabeled field.
                // For this particular sample, we will look for the value of field 'Vendor Name'.
                Console.WriteLine("Find the value for a specific unlabeled field:");
                foreach (RecognizedForm form in forms)
                {
                    foreach (FormField field in form.Fields.Values)
                    {
                        if (field.LabelText != null && field.LabelText.Text == "Vendor Name:")
                        {
                            Console.WriteLine($"The Vendor Name is {field.ValueText.Text}");
                        }
                    }
                }
            }
        }
    }
}
