// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            //string sasUrlUnsupervised = "https://annelostorage01.blob.core.windows.net/container-formreco?sp=rl&st=2020-03-05T17:51:47Z&se=2020-03-06T17:51:47Z&sv=2019-02-02&sr=c&sig=vDE74j%2FsOohf5zLhJr9Y2Xf2dQnwkELvqu3PPPVW7Yc%3D";
            string unsupervisedModelId = "fddc5f4d-06da-4bac-b368-15522b733c73";

            //string sasUrlSupervised = "https://annelostorage01.blob.core.windows.net/formreco-labeled-training?sp=rl&st=2020-03-05T18:09:38Z&se=2020-03-06T18:09:38Z&sv=2019-02-02&sr=c&sig=mYpNFe9%2BV9y6UVXOLwwqVNCNG1Kr38tZhqWkc%2BF321o%3D";
            //string supervisedModelId = "178c93a0-c522-4862-a8c8-57ef873c6168";

            //Console.WriteLine("Hello World!");

            //TrainCustomModel(sasUrl).Wait();
            ExtractCustomModelStream(unsupervisedModelId).Wait();
            //ExtractCustomModelUri(unsupervisedModelId).Wait();
            //ExtractCustomModelPlusOcrData(unsupervisedModelId).Wait();

            //TrainCustomLabeledModel(sasUrlSupervised).Wait();
            //ExtractCustomLabeledModel(supervisedModelId).Wait();
            //ExtractCustomLabeledModelUri(supervisedModelId).Wait();
            //ExtractCustomLabeledModelPlusOcrData(supervisedModelId).Wait();

            //ExtractReceipt();
            //ExtractReceiptUri();

            //ExtractLayout().Wait();
            //ExtractLayoutUri().Wait();

            //GetCustomModelsSummary();
            //GetCustomModels();
        }

        private static async Task TrainCustomLabeledModel(string sasUrl)
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

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

        private static async Task TrainCustomModel(string sasUrl)
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

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

        private static async Task ExtractCustomModelStream(string modelId)
        {
            string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";

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
                    foreach (var page in form.Pages)
                    {
                        foreach (var table in page.Tables)
                        {
                            table.WriteAscii(Console.Out);
                        }

                        if (page.RawExtractedPage != null)
                        {
                            //foreach (var field in page.Fields)
                            //{
                            //    Console.WriteLine($"Field \"{field.Label}\" is made of the following Raw Extracted Words:");

                            //    if (field.LabelRawWordReferences != null)
                            //    {
                            //        foreach (var wordReference in field.LabelRawWordReferences)
                            //        {
                            //            Console.WriteLine($"{wordReference}: {page.RawExtractedPage.GetRawExtractedWord(wordReference).Text}");
                            //        }
                            //    }

                            //    foreach (var wordReference in field.ValueRawWordReferences)
                            //    {
                            //        Console.WriteLine($"{wordReference}: {page.RawExtractedPage.GetRawExtractedWord(wordReference).Text}");
                            //    }
                            //}
                        }
                    }
                }
            }
        }

        private static async Task ExtractCustomModelUri(string modelId)
        {
            Console.WriteLine("Unsupervised Model Table: ");

            Uri testFormPath = new Uri("https://annelostorage01.blob.core.windows.net/formreco-training-test/Invoice_6.pdf");

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var extractFormOperation = client.StartExtractForm(modelId, testFormPath);

            await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));
            if (extractFormOperation.HasValue)
            {
                ExtractedForm form = extractFormOperation.Value;
                foreach (var page in form.Pages)
                {
                    foreach (var table in page.Tables)
                    {
                        table.WriteAscii(Console.Out);
                    }
                }
            }
        }

        private static async Task ExtractCustomModelPlusOcrData(string modelId)
        {
            string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(pdfFormFile, FileMode.Open))
            {
                var extractFormOperation = client.StartExtractForm(modelId, stream, contentType: FormContentType.Pdf, includeRawPageExtractions: true);

                await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));
                if (extractFormOperation.HasValue)
                {
                    ExtractedForm form = extractFormOperation.Value;
                    foreach (var page in form.Pages)
                    {
                        foreach (var table in page.Tables)
                        {
                            table.WriteAscii(Console.Out);
                        }

                        if (page.RawExtractedPage != null)
                        {
                            foreach (var field in page.Fields)
                            {
                                Console.WriteLine($"Field \"{field.Label}\" is made of the following Raw Extracted Words:");

                                if (field.LabelRawExtractedItems != null)
                                {
                                    foreach (var extractedItem in field.LabelRawExtractedItems)
                                    {
                                        Console.WriteLine(extractedItem.Text);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("<Unlabeled>");
                                }

                                foreach (var extractedItem in field.ValueRawExtractedItems)
                                {
                                    Console.WriteLine(extractedItem.Text);
                                }
                            }
                        }
                    }
                }
            }
        }


        private static async Task ExtractCustomLabeledModel(string modelId)
        {
            Console.WriteLine("Supervised Model - Stream Input: ");

            string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";

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
                    foreach (var page in form.Pages)
                    {
                        foreach (var table in page.Tables)
                        {
                            table.WriteAscii(Console.Out);
                        }
                    }
                }
            }
        }


        private static async Task ExtractCustomLabeledModelUri(string modelId)
        {
            Console.WriteLine("Supervised Model - URI Input: ");

            // TODO: This fails, with a URI that works for unsupervised.  What is wrong?
            Uri testFormPath = new Uri("https://annelostorage01.blob.core.windows.net/formreco-training-test/Invoice_6.pdf");

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var extractFormOperation = client.StartExtractForm(modelId, testFormPath);

            await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));
            if (extractFormOperation.HasValue)
            {
                ExtractedForm form = extractFormOperation.Value;
                foreach (var page in form.Pages)
                {
                    foreach (var table in page.Tables)
                    {
                        table.WriteAscii(Console.Out);
                    }
                }
            }
        }

        private static async Task ExtractCustomLabeledModelPlusOcrData(string modelId)
        {
            // TODO: Q14 - currently blocked due to deserialization of array only handles string.
            Console.WriteLine("Supervised Model - Stream Input: ");

            string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(pdfFormFile, FileMode.Open))
            {
                var extractFormOperation = client.StartExtractForm(modelId, stream, contentType: FormContentType.Pdf, includeRawPageExtractions: true);

                await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));
                if (extractFormOperation.HasValue)
                {
                    ExtractedForm form = extractFormOperation.Value;
                    foreach (var page in form.Pages)
                    {
                        foreach (var table in page.Tables)
                        {
                            table.WriteAscii(Console.Out);
                        }

                        if (page.RawExtractedPage != null)
                        {
                            foreach (var field in page.Fields)
                            {
                                Console.WriteLine($"Field \"{field.Label}\" is made of the following Raw Extracted Words:");

                                if (field.LabelRawExtractedItems != null)
                                {
                                    foreach (var extractedItem in field.LabelRawExtractedItems)
                                    {
                                        Console.WriteLine(extractedItem.Text);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("<Unlabeled>");
                                }

                                foreach (var extractedItem in field.ValueRawExtractedItems)
                                {
                                    Console.WriteLine(extractedItem.Text);
                                }
                            }
                        }
                    }
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
                var extractedReceipt = client.ExtractReceipt(stream, contentType: FormContentType.Jpeg, includeRawPageExtractions: false);

            }
        }

        private static void ExtractReceiptUri()
        {
            Uri receiptUri = new Uri("https://docs.microsoft.com/en-us/azure/cognitive-services/form-recognizer/media/contoso-allinone.jpg");

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new ReceiptClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));
            var extractedReceipt = client.ExtractReceipt(receiptUri);
        }

        private static async Task ExtractLayout()
        {
            string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new FormLayoutClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(pdfFormFile, FileMode.Open))
            {
                var extractLayoutOperation = client.StartExtractLayout(stream, contentType: FormContentType.Pdf);

                await extractLayoutOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));
                if (extractLayoutOperation.HasValue)
                {
                    IReadOnlyList<ExtractedLayoutPage> result = extractLayoutOperation.Value;
                    foreach (var page in result)
                    {
                        foreach (var table in page.Tables)
                        {
                            table.WriteAscii(Console.Out);
                        }
                    }
                }
            }
        }

        private static async Task ExtractLayoutUri()
        {
            Uri testFormPath = new Uri("https://annelostorage01.blob.core.windows.net/formreco-training-test/Invoice_6.pdf");

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new FormLayoutClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var extractLayoutOperation = client.StartExtractLayout(testFormPath);

            await extractLayoutOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));
            if (extractLayoutOperation.HasValue)
            {
                IReadOnlyList<ExtractedLayoutPage> result = extractLayoutOperation.Value;
                foreach (var page in result)
                {
                    foreach (var table in page.Tables)
                    {
                        table.WriteAscii(Console.Out);
                    }
                }
            }
        }

        private static void GetCustomModelsSummary()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var modelCount = client.GetModelSubscriptionProperties();
            Console.WriteLine($"CustomModelCount: {modelCount.Value.Count}");
        }

        private static void GetCustomModels()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var models = client.GetModels();
            foreach (var model in models)
            {
                Console.WriteLine($"Model, Id={model.ModelId}, Status={model.TrainingStatus.ToString()}");
            }
        }
    }
}
