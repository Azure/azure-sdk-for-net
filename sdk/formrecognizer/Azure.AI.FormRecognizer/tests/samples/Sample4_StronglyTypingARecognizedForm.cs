// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public async Task StronglyTypingARecognizedForm()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string receiptUri = FormRecognizerTestEnvironment.CreateUriString("contoso-receipt.jpg");

            RecognizedFormCollection recognizedForms = await client.StartRecognizeReceiptsFromUri(new Uri(receiptUri)).WaitForCompletionAsync();
            List<Receipt> receipts = new List<Receipt>();

            foreach (RecognizedForm recognizedForm in recognizedForms)
            {
                Receipt receipt = new Receipt(recognizedForm);
                receipts.Add(receipt);

                if (receipt.MerchantName != null)
                {
                    Console.WriteLine($"Merchant Name: '{receipt.MerchantName.Value}', with confidence {receipt.MerchantName.Confidence}");
                }

                if (receipt.TransactionDate != null)
                {
                    Console.WriteLine($"Transaction Date: '{receipt.TransactionDate.Value}', with confidence {receipt.TransactionDate.Confidence}");
                }

                foreach (ReceiptItem item in receipt.Items)
                {
                    Console.WriteLine("Item:");

                    if (item.Name != null)
                    {
                        Console.WriteLine($"    Name: '{item.Name.Value}', with confidence {item.Name.Confidence}");
                    }

                    if (item.TotalPrice != null)
                    {
                        Console.WriteLine($"    Total Price: '{item.TotalPrice.Value}', with confidence {item.TotalPrice.Confidence}");
                    }
                }
            }
        }
    }
}
