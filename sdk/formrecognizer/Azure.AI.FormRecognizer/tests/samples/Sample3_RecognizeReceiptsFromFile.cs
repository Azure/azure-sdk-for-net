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

            #region Snippet:FormRecognizerSampleCreateClient
            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            string receiptPath = FormRecognizerTestEnvironment.CreatePath("contoso-receipt.jpg");

            #region Snippet:FormRecognizerSampleRecognizeReceiptFileStream
            using (FileStream stream = new FileStream(receiptPath, FileMode.Open))
            {
                var options = new RecognizeReceiptsOptions() { Locale = "en-US" };
                RecognizedFormCollection receipts = await client.StartRecognizeReceiptsAsync(stream, options).WaitForCompletionAsync();

                // To see the list of the supported fields returned by service and its corresponding types, consult:
                // https://aka.ms/formrecognizer/receiptfields

                foreach (RecognizedForm receipt in receipts)
                {
                    FormField merchantNameField;
                    if (receipt.Fields.TryGetValue("MerchantName", out merchantNameField))
                    {
                        if (merchantNameField.Value.ValueType == FieldValueType.String)
                        {
                            string merchantName = merchantNameField.Value.AsString();

                            Console.WriteLine($"Merchant Name: '{merchantName}', with confidence {merchantNameField.Confidence}");
                        }
                    }

                    FormField transactionDateField;
                    if (receipt.Fields.TryGetValue("TransactionDate", out transactionDateField))
                    {
                        if (transactionDateField.Value.ValueType == FieldValueType.Date)
                        {
                            DateTime transactionDate = transactionDateField.Value.AsDate();

                            Console.WriteLine($"Transaction Date: '{transactionDate}', with confidence {transactionDateField.Confidence}");
                        }
                    }

                    FormField itemsField;
                    if (receipt.Fields.TryGetValue("Items", out itemsField))
                    {
                        if (itemsField.Value.ValueType == FieldValueType.List)
                        {
                            foreach (FormField itemField in itemsField.Value.AsList())
                            {
                                Console.WriteLine("Item:");

                                if (itemField.Value.ValueType == FieldValueType.Dictionary)
                                {
                                    IReadOnlyDictionary<string, FormField> itemFields = itemField.Value.AsDictionary();

                                    FormField itemNameField;
                                    if (itemFields.TryGetValue("Name", out itemNameField))
                                    {
                                        if (itemNameField.Value.ValueType == FieldValueType.String)
                                        {
                                            string itemName = itemNameField.Value.AsString();

                                            Console.WriteLine($"    Name: '{itemName}', with confidence {itemNameField.Confidence}");
                                        }
                                    }

                                    FormField itemTotalPriceField;
                                    if (itemFields.TryGetValue("TotalPrice", out itemTotalPriceField))
                                    {
                                        if (itemTotalPriceField.Value.ValueType == FieldValueType.Float)
                                        {
                                            float itemTotalPrice = itemTotalPriceField.Value.AsFloat();

                                            Console.WriteLine($"    Total Price: '{itemTotalPrice}', with confidence {itemTotalPriceField.Confidence}");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    FormField totalField;
                    if (receipt.Fields.TryGetValue("Total", out totalField))
                    {
                        if (totalField.Value.ValueType == FieldValueType.Float)
                        {
                            float total = totalField.Value.AsFloat();

                            Console.WriteLine($"Total: '{total}', with confidence '{totalField.Confidence}'");
                        }
                    }
                }
            }
            #endregion
        }
    }
}
