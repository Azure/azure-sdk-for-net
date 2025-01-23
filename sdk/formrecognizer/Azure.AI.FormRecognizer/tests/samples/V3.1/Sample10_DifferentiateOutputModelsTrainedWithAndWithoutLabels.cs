// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    public partial class FormRecognizerSamples
    {
        /// This sample demonstrates the differences in output that arise when StartRecognizeCustomForms
        /// is called with custom models trained with labels and without labels.
        /// For this sample, you can use the training forms found in the `trainingFiles` folder.
        /// Upload the forms to your storage container and then generate a container SAS URL.

        /// For more information see https://docs.microsoft.com/azure/cognitive-services/form-recognizer/overview#custom-models

        [RecordedTest]
        public async Task OutputModelsTrainedWithLabels()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;
            string formFilePath = FormRecognizerTestEnvironment.CreatePath("Form_1.jpg");

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            FormTrainingClient trainingClient = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Model trained with labels
            CustomFormModel modelTrainedWithLabels = await trainingClient.StartTrainingAsync(new Uri(trainingFileUrl), useTrainingLabels: true, "My Model with labels").WaitForCompletionAsync();

            using (FileStream stream = new FileStream(formFilePath, FileMode.Open))
            {
                RecognizedFormCollection forms = await client.StartRecognizeCustomFormsAsync(modelTrainedWithLabels.ModelId, stream).WaitForCompletionAsync();

                // With a form recognized by a model trained with labels, the 'field.Name' key will be the label
                // that you gave it at training time.
                // Note that Label data is not returned for model trained with labels, as the trained model
                // contains this information and therefore the service returns the value of the recognized label.
                Console.WriteLine("---------Recognizing forms using models trained with labels---------");
                foreach (RecognizedForm form in forms)
                {
                    Console.WriteLine($"Form of type: {form.FormType}");
                    Console.WriteLine($"Form has form type confidence: {form.FormTypeConfidence.Value}");
                    Console.WriteLine($"Form was analyzed with model with ID: {form.ModelId}");
                    foreach (FormField field in form.Fields.Values)
                    {
                        Console.WriteLine($"Field {field.Name}: ");
                        Console.WriteLine($"    Value: '{field.ValueData.Text}");
                        Console.WriteLine($"    Confidence: '{field.Confidence}");
                    }
                }

                // Find labeled field.
                foreach (RecognizedForm form in forms)
                {
                    // Find the specific labeled field.
                    Console.WriteLine("Find the value for a specific labeled field:");
                    if (form.Fields.TryGetValue("VendorName", out FormField field))
                    {
                        Console.WriteLine($"VendorName is {field.ValueData.Text}");
                    }

                    // Find labeled fields with specific words
                    Console.WriteLine("Find the value for labeled field with specific words:");
                    form.Fields.Where(kv => kv.Key.StartsWith("Ven"))
                               .ToList().ForEach(v => Console.WriteLine($"{v.Key} is {v.Value.ValueData.Text}"));
                    form.Fields.Where(kv => kv.Key.Contains("Name"))
                               .ToList().ForEach(v => Console.WriteLine($"{v.Key} is {v.Value.ValueData.Text}"));
                }
            }
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        public async Task OutputModelsTrainedWithoutLabels()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;
            string formFilePath = FormRecognizerTestEnvironment.CreatePath("Form_1.jpg");

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            FormTrainingClient trainingClient = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Model trained without labels
            CustomFormModel modelTrainedWithoutLabels = await trainingClient.StartTrainingAsync(new Uri(trainingFileUrl), useTrainingLabels: false, "My Model").WaitForCompletionAsync();

            using (FileStream stream = new FileStream(formFilePath, FileMode.Open))
            {
                RecognizedFormCollection forms = await client.StartRecognizeCustomFormsAsync(modelTrainedWithoutLabels.ModelId, stream).WaitForCompletionAsync();

                // With a form recognized by a model trained without labels, the 'field.Name' property will be denoted
                // by a numeric index. To look for the labels identified during the training step,
                // use the `field.LabelText` property.
                Console.WriteLine("---------Recognizing forms using models trained without labels---------");
                foreach (RecognizedForm form in forms)
                {
                    Console.WriteLine($"Form of type: {form.FormType}");
                    Console.WriteLine($"Form was analyzed with model with ID: {form.ModelId}");
                    foreach (FormField field in form.Fields.Values)
                    {
                        Console.WriteLine($"Field {field.Name}: ");

                        if (field.LabelData != null)
                        {
                            Console.WriteLine($"    Label: '{field.LabelData.Text}");
                        }

                        Console.WriteLine($"    Value: '{field.ValueData.Text}");
                        Console.WriteLine($"    Confidence: '{field.Confidence}");
                    }
                }

                // Find the value of unlabeled fields.
                foreach (RecognizedForm form in forms)
                {
                    // Find the value of a specific unlabeled field.
                    Console.WriteLine("Find the value for a specific unlabeled field:");
                    foreach (FormField field in form.Fields.Values)
                    {
                        if (field.LabelData != null && field.LabelData.Text == "Vendor Name:")
                        {
                            Console.WriteLine($"The Vendor Name is {field.ValueData.Text}");
                        }
                    }

                    // Find the value of unlabeled fields with specific words
                    Console.WriteLine("Find the value for labeled field with specific words:");
                    form.Fields.Values.Where(field => field.LabelData.Text.StartsWith("Ven"))
                                      .ToList().ForEach(v => Console.WriteLine($"{v.LabelData.Text} is {v.ValueData.Text}"));
                    form.Fields.Values.Where(field => field.LabelData.Text.Contains("Name"))
                                      .ToList().ForEach(v => Console.WriteLine($"{v.LabelData.Text} is {v.ValueData.Text}"));
                }
            }
        }
    }
}
