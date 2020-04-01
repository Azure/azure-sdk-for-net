// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Samples
{
    /// <summary>
    /// </summary>
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // TODO: Move these into proper tests!
            // https://github.com/Azure/azure-sdk-for-net/issues/10409

            //string sasUrlUnsupervised = "https://annelostorage01.blob.core.windows.net/container-formreco?sp=rl&st=2020-03-12T18:30:06Z&se=2020-03-13T18:30:06Z&sv=2019-02-02&sr=c&sig=79mJyXIhkJZTbKYECs8eWgHr%2BbMkhVGJ9aJrfw88LN0%3D";
            //string sasMultiPage = "https://annelostorage01.blob.core.windows.net/formreco-multipage-form?sp=rl&st=2020-03-12T22:20:21Z&se=2020-03-13T22:20:21Z&sv=2019-02-02&sr=c&sig=sT3EOV5GEYXZAC76ywCgDZDs8k%2FuyXI%2BIVdrg4nKQJA%3D";
            //string sasDuplicatedForm = "https://annelostorage01.blob.core.windows.net/formreco-singlepage-duplicated-form?sp=rl&st=2020-03-12T22:48:24Z&se=2020-03-13T22:48:24Z&sv=2019-02-02&sr=c&sig=gBht9B1uIzv90Tvlgp3DcPAOUnTlLtladV5aDWwVfBI%3D";
            //string unsupervisedModelId = "9c18b4fc-78a0-457a-b975-b18361d9f453";
            //string multiPageUnsupervisedModelId = "0a0a321b-5a0a-40c7-8178-88d478aa8bc8";

            //string sasUrlSupervised = "https://annelostorage01.blob.core.windows.net/formreco-labeled-training?sp=rl&st=2020-03-12T18:30:23Z&se=2020-03-13T18:30:23Z&sv=2019-02-02&sr=c&sig=xR6SSg5G7Yp%2FVBg6e%2B2cX%2FY249ugKsxFCBQHRdlw3sY%3D";
            //string kristasMultipageContainer = "https://krpraticstorageacc.blob.core.windows.net/form-recognizer-multipage?sp=rl&st=2020-03-12T20:15:41Z&se=2020-03-13T20:15:41Z&sv=2019-02-02&sr=c&sig=YSUjgtGvSMrF0Y%2F2iuZ9mHBcn0Nz3KrrDhRXI28qlKQ%3D";

            //string supervisedModelId = "436a33e3-9c49-448e-94f8-3cf50dfca85f";
            //string supervisedMultipageModelId = "90cf67f6-4bbe-434e-b8e1-8982f392ecd0";

            //string ccauth1 = "https://uxstudystorage.blob.core.windows.net/mixeddata/CCAuth-1.pdf?sp=rl&st=2020-03-23T16:30:33Z&se=2020-03-24T16:30:33Z&sv=2019-02-02&sr=b&sig=6e53cC2i4qoVNq5qC2laUJZLrECAE8H4YUg1YbhOxxI%3D";
            //string uxstudymodelId = "1c511fa3-8ca9-40b5-8c0f-e3b371bccfde";

            //await TrainCustomModel(sasMultiPage);
            //await ExtractCustomModelStream(multiPageUnsupervisedModelId);
            //await ExtractCustomModelUri(unsupervisedModelId);
            //await ExtractCustomModelPlusOcrData(unsupervisedModelId);

            //await TrainCustomLabeledModel(kristasMultipageContainer);
            //await ExtractCustomLabeledModel(supervisedMultipageModelId);
            //await ExtractCustomLabeledModelUri(uxstudymodelId, ccauth1);
            //await ExtractCustomLabeledModelPlusOcrData(supervisedModelId);

            //await ExtractReceipts();
            //await ExtractReceiptUri();

            //await ExtractLayout();
            //await ExtractLayoutUri();

            //GetCustomModelsSummary();
            //GetCustomModels();

            await TestResumeOperation();

            Console.ReadLine();
        }

        private static async Task TrainCustomLabeledModel(Uri sasUrl)
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomModelClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var trainingOperation = client.StartTrainingWithLabels(sasUrl);
            var operation = client.StartTrainingWithLabels(sasUrl);

            await trainingOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
            if (trainingOperation.HasValue)
            {
                CustomLabeledModel model = trainingOperation.Value;
            }
            else
            {
                Console.WriteLine("LRO did not return a value.");
            }
        }

        private static async Task TrainCustomModel(Uri sasUrl)
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomModelClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var trainingOperation = client.StartTraining(sasUrl);

            await trainingOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
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
            //string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";
            string multiPageFormFile = @"C:\src\samples\cognitive\formrecognizer\multiform_documents\multipage_forms\Reg1_3.pdf";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new FormRecognizerClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(multiPageFormFile, FileMode.Open))
            {
                var extractFormOperation = client.StartRecognizeCustomForms(modelId, stream);

                await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
                if (extractFormOperation.HasValue)
                {
                    IReadOnlyList<RecognizedForm> forms = extractFormOperation.Value;
                    foreach (var form in forms)
                    {
                        foreach (var page in form.Pages)
                        {
                            foreach (var table in page.Tables)
                            {
                                table.WriteAscii(Console.Out);
                            }
                        }

                        FormField invoiceField;
                        if (form.TryGetFieldValue("Invoice Number:", out invoiceField))
                        {
                            Console.WriteLine($"FieldLabel: {invoiceField.FieldLabel.Text}, Value: {invoiceField.ValueText.Text}");
                        }

                        foreach (var field in form.Fields)
                        {
                            Console.WriteLine($"Field \"{field.Name}\" is made of the following Raw Extracted Words:");

                            if (field.FieldLabel.TextContent != null)
                            {
                                foreach (var word in field.FieldLabel.TextContent)
                                {
                                    Console.WriteLine($"Word is: {word.Text}");
                                }
                            }

                            foreach (var word in field.ValueText.TextContent)
                            {
                                Console.WriteLine($"Word is: {word.Text}");
                            }
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

            var client = new FormRecognizerClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var extractFormOperation = client.StartRecognizeCustomForms(modelId, testFormPath);

            await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
            if (extractFormOperation.HasValue)
            {
                IReadOnlyList<RecognizedForm> forms = extractFormOperation.Value;
                foreach (var form in forms)
                {
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

        private static async Task ExtractCustomModelPlusOcrData(string modelId)
        {
            string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new FormRecognizerClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(pdfFormFile, FileMode.Open))
            {
                var extractFormOperation = client.StartRecognizeCustomForms(modelId, stream, new RecognizeOptions() { IncludeTextContent = true });

                await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
                if (extractFormOperation.HasValue)
                {
                    IReadOnlyList<RecognizedForm> forms = extractFormOperation.Value;
                    foreach (var form in forms)
                    {
                        foreach (var page in form.Pages)
                        {
                            foreach (var table in page.Tables)
                            {
                                table.WriteAscii(Console.Out);
                            }
                        }

                        foreach (var field in form.Fields)
                        {
                            Console.WriteLine($"Field \"{field.Name}\" is made of the following Text Elements:");

                            if (field.FieldLabel.TextContent != null)
                            {
                                foreach (var extractedItem in field.FieldLabel.TextContent)
                                {
                                    Console.WriteLine(extractedItem.Text);
                                }
                            }

                            foreach (var extractedItem in field.ValueText.TextContent)
                            {
                                Console.WriteLine(extractedItem.Text);
                            }
                        }
                    }
                }
            }
        }


        private static async Task ExtractCustomLabeledModel(string modelId)
        {
            Console.WriteLine("Supervised Model - Stream Input: ");
            // string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";
            string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\multiform_documents\from_krista\Document1.pdf";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new FormRecognizerClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(pdfFormFile, FileMode.Open))
            {
                var extractFormOperation = client.StartRecognizeCustomForms(modelId, stream);

                await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
                if (extractFormOperation.HasValue)
                {
                    IReadOnlyList<RecognizedForm> forms = extractFormOperation.Value;
                    foreach (var form in forms)
                    {
                        foreach (var page in form.Pages)
                        {
                            foreach (var table in page.Tables)
                            {
                                table.WriteAscii(Console.Out);
                            }
                        }

                        FormField field;
                        if (form.TryGetFieldValue("Charges", out field))
                        {
                            Console.WriteLine($"Name: {field.FieldLabel.Text}, ValueText: {field.ValueText.Text}, Value: {field.Value.AsFloat()}");
                        }
                    }
                }
            }
        }


        private static async Task ExtractCustomLabeledModelUri(string modelId, string formPath)
        {
            Console.WriteLine("Supervised Model - URI Input: ");

            //Uri testFormPath = new Uri("https://krpraticstorageacc.blob.core.windows.net/form-recognizer-multipage/Document1.pdf");
            //Uri testFormPath = new Uri("https://annelostorage01.blob.core.windows.net/formreco-training-test/Invoice_6.pdf");

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new FormRecognizerClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var extractFormOperation = client.StartRecognizeCustomForms(modelId, new Uri(formPath));

            await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
            if (extractFormOperation.HasValue)
            {
                IReadOnlyList<RecognizedForm> forms = extractFormOperation.Value;
                foreach (var form in forms)
                {
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

        private static async Task ExtractCustomLabeledModelPlusOcrData(string modelId)
        {
            // TODO: Q14 - currently blocked due to known issue on the service.
            Console.WriteLine("Supervised Model - Stream Input: ");

            string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new FormRecognizerClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(pdfFormFile, FileMode.Open))
            {
                var extractFormOperation = client.StartRecognizeCustomForms(modelId, stream, new RecognizeOptions() { IncludeTextContent = true });

                await extractFormOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
                if (extractFormOperation.HasValue)
                {
                    IReadOnlyList<RecognizedForm> forms = extractFormOperation.Value;
                    foreach (var form in forms)
                    {
                        foreach (var page in form.Pages)
                        {
                            foreach (var table in page.Tables)
                            {
                                table.WriteAscii(Console.Out);
                            }
                        }

                        foreach (var field in form.Fields)
                        {
                            Console.WriteLine($"Field \"{field.FieldLabel}\" is made of the following Raw Extracted Words:");

                            if (field.ValueText.TextContent != null)
                            {
                                foreach (var extractedItem in field.ValueText.TextContent)
                                {
                                    Console.WriteLine(extractedItem.Text);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static async Task ExtractReceipts()
        {
            string contosoReceipt = @"C:\src\samples\cognitive\formrecognizer\receipt_data\contoso-allinone.jpg";
            //string differentReceipts = @"C:\src\samples\cognitive\formrecognizer\multiform_documents\from_krista\different_receipts_2_page.pdf";
            //string multipageReceipt = @"C:\src\samples\cognitive\formrecognizer\multiform_documents\from_krista\one_receipt_2_pages.pdf";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new FormRecognizerClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(contosoReceipt, FileMode.Open))
            {
                //var extractReceiptOperation = await client.StartRecognizeReceiptsAsync(stream, "en-us", new RecognizeOptions() { IncludeTextContent = true });

                //await extractReceiptOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
                //if (extractReceiptOperation.HasValue)
                //{
                //    IReadOnlyList<RecognizedReceipt> result = extractReceiptOperation.Value;

                //    foreach (var receipt in result)
                //    {
                //        var usReceipt = receipt.AsUSReceipt();

                //        // Extract merchant value with confidence for visual highlighting.
                //        string merchantStr = usReceipt.MerchantName.Value;
                //        float merchantConfidence = usReceipt.MerchantName.Confidence ?? 0;
                //    }
                //}

                var result = await client.StartRecognizeReceiptsAsync(stream, "en-us", new RecognizeOptions() { IncludeTextContent = true }).WaitForCompletionAsync();
                foreach (var receipt in result.Value)
                {
                    var usReceipt = receipt.AsUSReceipt();

                    // Extract merchant value with confidence for visual highlighting.
                    string merchantStr = usReceipt.MerchantName.Value;
                    float merchantConfidence = usReceipt.MerchantName.Confidence ?? 0;
                }
            }
        }

        private static void ExtractReceiptUri()
        {
            Uri receiptUri = new Uri("https://docs.microsoft.com/en-us/azure/cognitive-services/form-recognizer/media/contoso-allinone.jpg");

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new FormRecognizerClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));
            var extractedReceipt = client.StartRecognizeReceipts(receiptUri, "en-us");
        }

        private static async Task ExtractLayout()
        {
            string pdfFormFile = @"C:\src\samples\cognitive\formrecognizer\sample_data\Test\Invoice_6.pdf";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new FormRecognizerClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            using (FileStream stream = new FileStream(pdfFormFile, FileMode.Open))
            {
                var extractLayoutOperation = client.StartRecognizeContent(stream);

                await extractLayoutOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
                if (extractLayoutOperation.HasValue)
                {
                    var result = extractLayoutOperation.Value;
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

            var client = new FormRecognizerClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var extractLayoutOperation = client.StartRecognizeContent(testFormPath);

            await extractLayoutOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
            if (extractLayoutOperation.HasValue)
            {
                var result = extractLayoutOperation.Value;
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

            var client = new CustomModelClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var modelCount = client.GetAccountProperties();
            Console.WriteLine($"CustomModelCount: {modelCount.Value.CustomModelCount}");
        }

        private static void GetCustomModels()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomModelClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var models = client.GetModelInfos();
            foreach (var model in models)
            {
                Console.WriteLine($"Model, Id={model.ModelId}, Status={model.Status.ToString()}");
            }
        }

        private static async Task TestResumeOperation()
        {
            string contosoReceipt = @"C:\src\samples\cognitive\formrecognizer\receipt_data\contoso-allinone.jpg";

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new FormRecognizerClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            string operationId = default;

            using (FileStream stream = new FileStream(contosoReceipt, FileMode.Open))
            {
                var extractReceiptOperation = await client.StartRecognizeReceiptsAsync(stream, "en-us", new RecognizeOptions() { IncludeTextContent = true });
                operationId = extractReceiptOperation.Id;

                await extractReceiptOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), default);
                if (extractReceiptOperation.HasValue)
                {
                    IReadOnlyList<RecognizedReceipt> result = extractReceiptOperation.Value;
                }
            }

            RecognizeReceiptsOperation operation = new RecognizeReceiptsOperation(operationId, client);
            var value = await operation.WaitForCompletionAsync();
            if (operation.HasValue)
            {
                IReadOnlyList<RecognizedReceipt> result = operation.Value;
            }
        }
    }
}
