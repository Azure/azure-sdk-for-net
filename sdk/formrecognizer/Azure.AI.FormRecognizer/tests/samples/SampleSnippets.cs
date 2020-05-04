// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class Snippets : SamplesBase<FormRecognizerTestEnvironment>
    {
        [Test]
        public void CreateFormRecognizerClient()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:CreateFormRecognizerClient
            //@@ string endpoint = "<endpoint>";
            //@@ string apiKey = "<apiKey>";
            var credential = new AzureKeyCredential(apiKey);
            var client = new FormRecognizerClient(new Uri(endpoint), credential);
            #endregion
        }

        [Test]
        public void CreateFormTrainingClient()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:CreateFormTrainingClient
            //@@ string endpoint = "<endpoint>";
            //@@ string apiKey = "<apiKey>";
            var credential = new AzureKeyCredential(apiKey);
            var client = new FormTrainingClient(new Uri(endpoint), credential);
            #endregion
        }

        [Test]
        public async Task BadRequestSnippet()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var credential = new AzureKeyCredential(apiKey);
            var client = new FormRecognizerClient(new Uri(endpoint), credential);

            #region Snippet:FormRecognizerBadRequest
            try
            {
                Response<IReadOnlyList<RecognizedReceipt>> receipts = await client.StartRecognizeReceiptsFromUri(new Uri("http://invalid.uri")).WaitForCompletionAsync();
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }

        [Test]
        public async Task RecognizeFormContentFromFile()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var credential = new AzureKeyCredential(apiKey);
            var client = new FormRecognizerClient(new Uri(endpoint), credential);

            string invoiceFilePath = FormRecognizerTestEnvironment.CreatePath("Invoice_1.pdf");

            #region Snippet:FormRecognizerRecognizeFormContentFromFile
            using (FileStream stream = new FileStream(invoiceFilePath, FileMode.Open))
            {
                Response<IReadOnlyList<FormPage>> formPages = await client.StartRecognizeContent(stream).WaitForCompletionAsync();
                /*
                 *
                 */
            }
            #endregion
        }

        [Test]
        public async Task RecognizeReceiptFromFile()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var credential = new AzureKeyCredential(apiKey);
            var client = new FormRecognizerClient(new Uri(endpoint), credential);

            string receiptPath = FormRecognizerTestEnvironment.JpgReceiptPath;

            #region Snippet:FormRecognizerRecognizeReceiptFromFile
            using (FileStream stream = new FileStream(receiptPath, FileMode.Open))
            {
                Response<IReadOnlyList<RecognizedReceipt>> receipts = await client.StartRecognizeReceipts(stream).WaitForCompletionAsync();
                /*
                 *
                 */
            }
            #endregion
        }

        [Test]
        public async Task RecognizeCustomFormsFromFile()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;

            // Firstly, create a trained model we can use to recognize the custom form.

            FormTrainingClient trainingClient = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            CustomFormModel model = await trainingClient.StartTraining(new Uri(trainingFileUrl)).WaitForCompletionAsync();

            // Proceed with the custom form recognition.

            var credential = new AzureKeyCredential(apiKey);
            var client = new FormRecognizerClient(new Uri(endpoint), credential);

            string formFilePath = FormRecognizerTestEnvironment.CreatePath("Form_1.jpg");
            string modelId = model.ModelId;

            #region Snippet:FormRecognizerRecognizeCustomFormsFromFile
            using (FileStream stream = new FileStream(formFilePath, FileMode.Open))
            {
                //@@ string modelId = "<modelId>";

                Response<IReadOnlyList<RecognizedForm>> forms = await client.StartRecognizeCustomForms(modelId, stream).WaitForCompletionAsync();
                /*
                 *
                 */
            }
            #endregion

            // Delete the model on completion to clean environment.
            trainingClient.DeleteModel(model.ModelId);
        }
    }
}
