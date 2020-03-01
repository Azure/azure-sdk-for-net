// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Custom;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Samples
{
    /// <summary>
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //TrainCustomModel().Wait();
            //ExtractCustomModel().Wait();

            //TrainCustomLabeledModel().Wait();
            //ExtractCustomLabeledModel().Wait();
            ExtractReceipt();

            //GetCustomModelsSummary();
            //GetCustomModels();
        }

        private static async Task TrainCustomLabeledModel()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            string sasUrl = "https://annelostorage01.blob.core.windows.net/formreco-labeled-training?sp=rl&st=2020-02-29T23:40:52Z&se=2020-03-01T23:40:52Z&sv=2019-02-02&sr=c&sig=p2hvqDtcYSONgck6JC48ZJLaxTCKk%2FBNNMVztXs2lnU%3D";
            var trainingOperation = client.StartTrainingWithLabels(sasUrl);

            await trainingOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));
            if (trainingOperation.HasValue)
            {
                CustomLabeledModel model = trainingOperation.Value;
            }
            else
            {
                Console.WriteLine("LRO did not return a value.");
            }
        }

        private static async Task TrainCustomModel()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            string sasUrl = "https://annelostorage01.blob.core.windows.net/container-formreco?sp=rl&st=2020-02-29T17:07:48Z&se=2020-03-01T17:07:48Z&sv=2019-02-02&sr=c&sig=Ls4zfs2hidZ4VS%2BiEkRv1Y6brqjf0te1VfI72HodsRE%3D";
            var trainingOperation = client.StartTraining(sasUrl);

            await trainingOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));
            if (trainingOperation.HasValue)
            {
                CustomModel model = trainingOperation.Value;
            }
            else
            {
                Console.WriteLine("LRO did not return a value.");
            }
        }

        private static async Task ExtractCustomModel()
        {
            string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";
            string modelId = "6973638e-91e6-4f51-89d6-8198afaefecf";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(pdfFormFile, FileMode.Open))
            {
                var extractFormOperation = client.StartExtractForm(modelId, stream, contentType: FormContentType.Pdf);

                await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));
                if (extractFormOperation.HasValue)
                {
                    ExtractedForm form = extractFormOperation.Value;
                }
            }
        }

        private static async Task ExtractCustomLabeledModel()
        {
            string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";
            string modelId = "be5360ca-9742-4bc8-b6ef-a16e40a6c64f";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(pdfFormFile, FileMode.Open))
            {
                var extractFormOperation = client.StartExtractForm(modelId, stream, contentType: FormContentType.Pdf);

                await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));
                if (extractFormOperation.HasValue)
                {
                    ExtractedForm form = extractFormOperation.Value;
                }
            }
        }

        private static void ExtractReceipt()
        {
            string contosoReceipt = @"C:\src\samples\cognitive\formrecognizer\receipt_data\contoso-allinone.jpg";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new ReceiptClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(contosoReceipt, FileMode.Open))
            {
                var extractedReceipt = client.ExtractReceipt(stream, contentType: FormContentType.Jpeg);

            }
        }

        private static void GetCustomModelsSummary()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var models = client.GetCustomModelSummary();
        }

        private static void GetCustomModels()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var models = client.GetCustomModels();
            foreach (var model in models)
            {
                Console.WriteLine($"Model, Id={model.ModelId}, Status={model.Status.ToString()}");
            }
        }
    }
}
