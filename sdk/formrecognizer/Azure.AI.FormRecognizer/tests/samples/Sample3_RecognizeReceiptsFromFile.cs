// Copyright (c) Microsoft Corporation. All rights reserved.
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

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string receiptPath = FormRecognizerTestEnvironment.CreatePath("contoso-receipt.jpg");

            #region Snippet:FormRecognizerSampleRecognizeReceiptFileStream
            //@@ string receiptPath = "<receiptPath>";

            using var stream = new FileStream(receiptPath, FileMode.Open);
            var options = new RecognizeReceiptsOptions() { Locale = "en-US" };

            RecognizeReceiptsOperation operation = await client.StartRecognizeReceiptsAsync(stream, options);
            Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
            RecognizedFormCollection receipts = operationResponse.Value;

            // To see the list of the supported fields returned by service and its corresponding types, consult:
            // https://aka.ms/formrecognizer/receiptfields

            foreach (RecognizedForm receipt in receipts)
            {
                if (receipt.Fields.TryGetValue("MerchantName", out FormField merchantNameField))
                {
                    if (merchantNameField.Value.ValueType == FieldValueType.String)
                    {
                        string merchantName = merchantNameField.Value.AsString();

                        Console.WriteLine($"Merchant Name: '{merchantName}', with confidence {merchantNameField.Confidence}");
                    }
                }

                if (receipt.Fields.TryGetValue("TransactionDate", out FormField transactionDateField))
                {
                    if (transactionDateField.Value.ValueType == FieldValueType.Date)
                    {
                        DateTime transactionDate = transactionDateField.Value.AsDate();

                        Console.WriteLine($"Transaction Date: '{transactionDate}', with confidence {transactionDateField.Confidence}");
                    }
                }

                if (receipt.Fields.TryGetValue("Items", out FormField itemsField))
                {
                    if (itemsField.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField itemField in itemsField.Value.AsList())
                        {
                            Console.WriteLine("Item:");

                            if (itemField.Value.ValueType == FieldValueType.Dictionary)
                            {
                                IReadOnlyDictionary<string, FormField> itemFields = itemField.Value.AsDictionary();

                                if (itemFields.TryGetValue("Name", out FormField itemNameField))
                                {
                                    if (itemNameField.Value.ValueType == FieldValueType.String)
                                    {
                                        string itemName = itemNameField.Value.AsString();

                                        Console.WriteLine($"  Name: '{itemName}', with confidence {itemNameField.Confidence}");
                                    }
                                }

                                if (itemFields.TryGetValue("TotalPrice", out FormField itemTotalPriceField))
                                {
                                    if (itemTotalPriceField.Value.ValueType == FieldValueType.Float)
                                    {
                                        float itemTotalPrice = itemTotalPriceField.Value.AsFloat();

                                        Console.WriteLine($"  Total Price: '{itemTotalPrice}', with confidence {itemTotalPriceField.Confidence}");
                                    }
                                }
                            }
                        }
                    }
                }

                if (receipt.Fields.TryGetValue("Total", out FormField totalField))
                {
                    if (totalField.Value.ValueType == FieldValueType.Float)
                    {
                        float total = totalField.Value.AsFloat();

                        Console.WriteLine($"Total: '{total}', with confidence '{totalField.Confidence}'");
                    }
                }
            }
            #endregion
        }
    }
}
