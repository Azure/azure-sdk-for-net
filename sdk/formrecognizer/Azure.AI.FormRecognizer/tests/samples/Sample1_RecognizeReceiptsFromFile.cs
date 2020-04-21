// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    [LiveOnly]
    public partial class FormRecognizerSamples
    {
        [Test]
        public async Task RecognizeReceiptsFromFile()
        {
            string endpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");
            string apiKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_API_KEY");

            #region Snippet:FormRecognizerSample1CreateClient
            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            string receiptPath = TestEnvironment.JpgReceiptPath;

            #region Snippet:FormRecognizerSample1RecognizeReceiptFileStream
            using (FileStream stream = new FileStream(receiptPath, FileMode.Open))
            {
                Response<IReadOnlyList<RecognizedReceipt>> receipts = await client.StartRecognizeReceipts(stream).WaitForCompletionAsync();
                foreach (var receipt in receipts.Value)
                {
                    USReceipt usReceipt = receipt.AsUSReceipt();

                    string merchantName = usReceipt.MerchantName;
                    DateTime transactionDate = usReceipt.TransactionDate;
                    IReadOnlyList<USReceiptItem> items = usReceipt.Items;
                    float subtotal = usReceipt.Subtotal;
                    float tax = usReceipt.Tax;
                    float total = usReceipt.Total;

                    Console.WriteLine($"Recognized USReceipt fields:");
                    Console.WriteLine($"    Merchant Name: '{merchantName}', with confidence {usReceipt.MerchantName.Confidence}");
                    Console.WriteLine($"    Transaction Date: '{transactionDate}', with confidence {usReceipt.TransactionDate.Confidence}");

                    for (int i = 0; i < items.Count; i++)
                    {
                        USReceiptItem item = usReceipt.Items[i];
                        Console.WriteLine($"    Item {i}:  Name: '{item.Name.Value}', Quantity: '{item.Quantity?.Value}', TotalPrice: '{item.TotalPrice.Value}'");
                    }

                    Console.WriteLine($"    Subtotal: '{subtotal}', with confidence '{usReceipt.Subtotal.Confidence}'");
                    Console.WriteLine($"    Tax: '{tax}', with confidence '{usReceipt.Tax.Confidence}'");
                    Console.WriteLine($"    Total: '{total}', with confidence '{usReceipt.Total.Confidence}'");
                }
            }
            #endregion
        }
    }
}
