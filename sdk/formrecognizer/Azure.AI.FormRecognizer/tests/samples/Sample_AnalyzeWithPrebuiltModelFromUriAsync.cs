// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples
    {
        [RecordedTest]
        public async Task AnalyzeWithPrebuiltModelFromUriAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerAnalyzeWithPrebuiltModelFromUriAsync
#if SNIPPET
            Uri fileUri = new Uri("<fileUri>");
#else
            Uri fileUri = DocumentAnalysisTestEnvironment.CreateUri("Form_1.jpg");
#endif

            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-invoice", fileUri);
            AnalyzeResult result = operation.Value;

            // To see the list of all the supported fields returned by service and its corresponding types for the
            // prebuilt-invoice model, consult:
            // https://aka.ms/azsdk/formrecognizer/invoicefieldschema

            for (int i = 0; i < result.Documents.Count; i++)
            {
                Console.WriteLine($"Document {i}:");

                AnalyzedDocument document = result.Documents[i];

                if (document.Fields.TryGetValue("VendorName", out DocumentField vendorNameField))
                {
                    if (vendorNameField.FieldType == DocumentFieldType.String)
                    {
                        string vendorName = vendorNameField.Value.AsString();
                        Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
                    }
                }

                if (document.Fields.TryGetValue("CustomerName", out DocumentField customerNameField))
                {
                    if (customerNameField.FieldType == DocumentFieldType.String)
                    {
                        string customerName = customerNameField.Value.AsString();
                        Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
                    }
                }

                if (document.Fields.TryGetValue("Items", out DocumentField itemsField))
                {
                    if (itemsField.FieldType == DocumentFieldType.List)
                    {
                        foreach (DocumentField itemField in itemsField.Value.AsList())
                        {
                            Console.WriteLine("Item:");

                            if (itemField.FieldType == DocumentFieldType.Dictionary)
                            {
                                IReadOnlyDictionary<string, DocumentField> itemFields = itemField.Value.AsDictionary();

                                if (itemFields.TryGetValue("Description", out DocumentField itemDescriptionField))
                                {
                                    if (itemDescriptionField.FieldType == DocumentFieldType.String)
                                    {
                                        string itemDescription = itemDescriptionField.Value.AsString();

                                        Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                                    }
                                }

                                if (itemFields.TryGetValue("Amount", out DocumentField itemAmountField))
                                {
                                    if (itemAmountField.FieldType == DocumentFieldType.Currency)
                                    {
                                        CurrencyValue itemAmount = itemAmountField.Value.AsCurrency();

                                        Console.WriteLine($"  Amount: '{itemAmount.Symbol}{itemAmount.Amount}', with confidence {itemAmountField.Confidence}");
                                    }
                                }
                            }
                        }
                    }
                }

                if (document.Fields.TryGetValue("SubTotal", out DocumentField subTotalField))
                {
                    if (subTotalField.FieldType == DocumentFieldType.Currency)
                    {
                        CurrencyValue subTotal = subTotalField.Value.AsCurrency();
                        Console.WriteLine($"Sub Total: '{subTotal.Symbol}{subTotal.Amount}', with confidence {subTotalField.Confidence}");
                    }
                }

                if (document.Fields.TryGetValue("TotalTax", out DocumentField totalTaxField))
                {
                    if (totalTaxField.FieldType == DocumentFieldType.Currency)
                    {
                        CurrencyValue totalTax = totalTaxField.Value.AsCurrency();
                        Console.WriteLine($"Total Tax: '{totalTax.Symbol}{totalTax.Amount}', with confidence {totalTaxField.Confidence}");
                    }
                }

                if (document.Fields.TryGetValue("InvoiceTotal", out DocumentField invoiceTotalField))
                {
                    if (invoiceTotalField.FieldType == DocumentFieldType.Currency)
                    {
                        CurrencyValue invoiceTotal = invoiceTotalField.Value.AsCurrency();
                        Console.WriteLine($"Invoice Total: '{invoiceTotal.Symbol}{invoiceTotal.Amount}', with confidence {invoiceTotalField.Confidence}");
                    }
                }
            }
            #endregion
        }
    }
}
