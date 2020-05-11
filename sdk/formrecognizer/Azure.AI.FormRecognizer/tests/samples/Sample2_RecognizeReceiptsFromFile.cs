﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples : SamplesBase<FormRecognizerTestEnvironment>
    {
        [Test]
        public async Task RecognizeReceiptsFromFile()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:FormRecognizerSample1CreateClient
            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            string receiptPath = FormRecognizerTestEnvironment.JpgReceiptPath;

            #region Snippet:FormRecognizerSampleRecognizeReceiptFileStream
            using (FileStream stream = new FileStream(receiptPath, FileMode.Open))
            {
                RecognizedReceiptCollection receipts = await client.StartRecognizeReceipts(stream).WaitForCompletionAsync();
                foreach (var receipt in receipts)
                {
                    USReceipt usReceipt = receipt.AsUSReceipt();

                    string merchantName = usReceipt.MerchantName?.Value ?? default;
                    DateTime transactionDate = usReceipt.TransactionDate?.Value ?? default;
                    IReadOnlyList<USReceiptItem> items = usReceipt.Items ?? default;
                    float subtotal = usReceipt.Subtotal?.Value ?? default;
                    float tax = usReceipt.Tax?.Value ?? default;
                    float tip = usReceipt.Tip?.Value ?? default;
                    float total = usReceipt.Total?.Value ?? default;

                    Console.WriteLine($"Recognized USReceipt fields:");
                    Console.WriteLine($"    Merchant Name: '{merchantName}', with confidence {usReceipt.MerchantName.Confidence}");
                    Console.WriteLine($"    Transaction Date: '{transactionDate}', with confidence {usReceipt.TransactionDate.Confidence}");

                    for (int i = 0; i < items.Count; i++)
                    {
                        USReceiptItem item = usReceipt.Items[i];
                        Console.WriteLine($"    Item {i}:  Name: '{item.Name.Value}', Quantity: '{item.Quantity?.Value}', Price: '{item.Price?.Value}'");
                        Console.WriteLine($"    TotalPrice: '{item.TotalPrice.Value}'");
                    }

                    Console.WriteLine($"    Subtotal: '{subtotal}', with confidence '{usReceipt.Subtotal.Confidence}'");
                    Console.WriteLine($"    Tax: '{tax}', with confidence '{usReceipt.Tax.Confidence}'");
                    Console.WriteLine($"    Tip: '{tip}', with confidence '{usReceipt.Tip?.Confidence ?? 0.0f}'");
                    Console.WriteLine($"    Total: '{total}', with confidence '{usReceipt.Total.Confidence}'");
                }
            }
            #endregion
        }
    }
}
