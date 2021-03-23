// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

            Uri receiptUri = FormRecognizerTestEnvironment.CreateUri("contoso-receipt.jpg");

            #region Snippet:FormRecognizerSampleStronglyTypingARecognizedForm
            //@@ Uri receiptUri = <receiptUri>;

            RecognizeReceiptsOperation operation = await client.StartRecognizeReceiptsFromUriAsync(receiptUri);
            Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
            RecognizedFormCollection recognizedForms = operationResponse.Value;

            foreach (RecognizedForm recognizedForm in recognizedForms)
            {
                Receipt receipt = new Receipt(recognizedForm);

                if (receipt.MerchantName != null)
                {
                    string merchantName = receipt.MerchantName;
                    Console.WriteLine($"Merchant Name: '{merchantName}', with confidence {receipt.MerchantName.Confidence}");
                }

                if (receipt.TransactionDate != null)
                {
                    DateTime transactionDate = receipt.TransactionDate;
                    Console.WriteLine($"Transaction Date: '{transactionDate}', with confidence {receipt.TransactionDate.Confidence}");
                }

                foreach (ReceiptItem item in receipt.Items)
                {
                    Console.WriteLine("Item:");

                    if (item.Name != null)
                    {
                        string name = item.Name;
                        Console.WriteLine($"  Name: '{name}', with confidence {item.Name.Confidence}");
                    }

                    if (item.TotalPrice != null)
                    {
                        float totalPrice = item.TotalPrice;
                        Console.WriteLine($"  Total Price: '{totalPrice}', with confidence {item.TotalPrice.Confidence}");
                    }
                }

                if (receipt.Total != null)
                {
                    float total = receipt.Total;
                    Console.WriteLine($"Total: '{total}', with confidence {receipt.Total.Confidence}");
                }
            }
            #endregion
        }
    }
}
