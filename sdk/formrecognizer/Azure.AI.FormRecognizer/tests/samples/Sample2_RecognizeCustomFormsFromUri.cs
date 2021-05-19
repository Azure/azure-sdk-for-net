// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task RecognizeCustomFormsFromUri()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;

            // Firstly, create a trained model we can use to recognize the custom form. Please note that
            // models can also be trained using a graphical user interface such as the Form Recognizer
            // Labeling Tool found here:
            // https://docs.microsoft.com/azure/cognitive-services/form-recognizer/quickstarts/label-tool

            FormTrainingClient trainingClient = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            CustomFormModel model = await trainingClient.StartTrainingAsync(new Uri(trainingFileUrl), useTrainingLabels: false, "My Model").WaitForCompletionAsync();

            // Proceed with the custom form recognition.

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            Uri formUri = FormRecognizerTestEnvironment.CreateUri("Form_1.jpg");
            string modelId = model.ModelId;

            #region Snippet:FormRecognizerSampleRecognizeCustomFormsFromUri
            //@@ string modelId = "<modelId>";
            //@@ Uri formUri = <formUri>;

            RecognizeCustomFormsOperation operation = await client.StartRecognizeCustomFormsFromUriAsync(modelId, formUri);
            Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
            RecognizedFormCollection forms = operationResponse.Value;

            foreach (RecognizedForm form in forms)
            {
                Console.WriteLine($"Form of type: {form.FormType}");
                if (form.FormTypeConfidence.HasValue)
                    Console.WriteLine($"Form type confidence: {form.FormTypeConfidence.Value}");
                Console.WriteLine($"Form was analyzed with model with ID: {form.ModelId}");
                foreach (FormField field in form.Fields.Values)
                {
                    Console.WriteLine($"Field '{field.Name}': ");

                    if (field.LabelData != null)
                    {
                        Console.WriteLine($"  Label: '{field.LabelData.Text}'");
                    }

                    Console.WriteLine($"  Value: '{field.ValueData.Text}'");
                    Console.WriteLine($"  Confidence: '{field.Confidence}'");
                }
            }
            #endregion

            // Delete the model on completion to clean environment.
            await trainingClient.DeleteModelAsync(model.ModelId);
        }
    }
}
