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
        public async Task RecognizeReceiptsFromUri()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string receiptUri = FormRecognizerTestEnvironment.CreateUriString("contoso-receipt.jpg");

            #region Snippet:FormRecognizerSampleRecognizeReceiptFileFromUri
            RecognizedReceiptCollection receipts = await client.StartRecognizeReceiptsFromUri(new Uri(receiptUri)).WaitForCompletionAsync();

            foreach (var receipt in receipts)
            {
                FormField merchantNameField;
                if (receipt.RecognizedForm.Fields.TryGetValue("MerchantName", out merchantNameField))
                {
                    if (merchantNameField.Value.Type == FieldValueType.String)
                    {
                        string merchantName = merchantNameField.Value.AsString();

                        Console.WriteLine($"    Merchant Name: '{merchantName}', with confidence {merchantNameField.Confidence}");
                    }
                }

                FormField transactionDateField;
                if (receipt.RecognizedForm.Fields.TryGetValue("TransactionDate", out transactionDateField))
                {
                    if (transactionDateField.Value.Type == FieldValueType.Date)
                    {
                        DateTime transactionDate = transactionDateField.Value.AsDate();

                        Console.WriteLine($"    Transaction Date: '{transactionDate}', with confidence {transactionDateField.Confidence}");
                    }
                }

                FormField itemsField;
                if (receipt.RecognizedForm.Fields.TryGetValue("Items", out itemsField))
                {
                    if (itemsField.Value.Type == FieldValueType.List)
                    {
                        foreach (FormField itemField in itemsField.Value.AsList())
                        {
                            if (itemField.Value.Type == FieldValueType.Dictionary)
                            {
                                IReadOnlyDictionary<string, FormField> itemFields = itemField.Value.AsDictionary();

                                FormField itemNameField;
                                if (itemFields.TryGetValue("MerchantName", out itemNameField))
                                {
                                    if (itemNameField.Value.Type == FieldValueType.String)
                                    {
                                        string itemName = itemNameField.Value.AsString();

                                        Console.WriteLine($"    Merchant Name: '{itemName}', with confidence {itemNameField.Confidence}");
                                    }
                                }

                                FormField itemTotalPriceField;
                                if (itemFields.TryGetValue("TotalPriceField", out itemTotalPriceField))
                                {
                                    if (itemTotalPriceField.Value.Type == FieldValueType.Float)
                                    {
                                        float itemTotalPrice = itemTotalPriceField.Value.AsFloat();

                                        Console.WriteLine($"    Merchant Name: '{itemTotalPrice}', with confidence {itemTotalPriceField.Confidence}");
                                    }
                                }
                            }
                        }
                    }
                }

                FormField totalField;
                if (receipt.RecognizedForm.Fields.TryGetValue("Total", out totalField))
                {
                    if (totalField.Value.Type == FieldValueType.Float)
                    {
                        float total = totalField.Value.AsFloat();

                        Console.WriteLine($"    Total: '{total}', with confidence '{totalField.Confidence}'");
                    }
                }
            }
            #endregion
        }
    }
}
