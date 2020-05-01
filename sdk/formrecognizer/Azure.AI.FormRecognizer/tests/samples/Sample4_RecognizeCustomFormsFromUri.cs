// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples : SamplesBase<FormRecognizerTestEnvironment>
    {
        [Test]
        public async Task RecognizeCustomFormsFromUri()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;

            // Firstly, create a trained model we can use to recognize the custom form.

            FormTrainingClient trainingClient = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            CustomFormModel model = await trainingClient.StartTraining(new Uri(trainingFileUrl)).WaitForCompletionAsync();

            // Proceed with the custom form recognition.

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string formUri = FormRecognizerTestEnvironment.CreateUri("Form_1.jpg");
            string modelId = model.ModelId;

            #region Snippet:FormRecognizerSample4RecognizeCustomFormsFromUri

            Response<IReadOnlyList<RecognizedForm>> forms = await client.StartRecognizeCustomFormsFromUri(modelId, new Uri(formUri)).WaitForCompletionAsync();
            foreach (RecognizedForm form in forms.Value)
            {
                Console.WriteLine($"Form of type: {form.FormType}");
                foreach (FormField field in form.Fields.Values)
                {
                    Console.WriteLine($"Field '{field.Name}: ");

                    if (field.LabelText != null)
                    {
                        Console.WriteLine($"    Label: '{field.LabelText.Text}");
                    }

                    Console.WriteLine($"    Value: '{field.ValueText.Text}");
                    Console.WriteLine($"    Confidence: '{field.Confidence}");
                }
            }
            #endregion

            // Delete the model on completion to clean environment.
            trainingClient.DeleteModel(model.ModelId);
        }
    }
}
