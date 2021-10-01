// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples : SamplesBase<DocumentAnalysisTestEnvironment>
    {
        [Test]
        public async Task AnalyzeWithPrebuiltModelFromUriAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerAnalyzeWithPrebuiltModelFromUriAsync
#if SNIPPET
            string fileUri = "<fileUri>";
#else
            Uri fileUri = DocumentAnalysisTestEnvironment.CreateUri("Form_1.jpg");
#endif

            AnalyzeDocumentOperation operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-invoice", fileUri);

            await operation.WaitForCompletionAsync();

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
                    if (vendorNameField.ValueType == DocumentFieldType.String)
                    {
                        string vendorName = vendorNameField.AsString();
                        Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
                    }
                }

                if (document.Fields.TryGetValue("CustomerName", out DocumentField customerNameField))
                {
                    if (customerNameField.ValueType == DocumentFieldType.String)
                    {
                        string customerName = customerNameField.AsString();
                        Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
                    }
                }

                if (document.Fields.TryGetValue("Items", out DocumentField itemsField))
                {
                    if (itemsField.ValueType == DocumentFieldType.List)
                    {
                        foreach (DocumentField itemField in itemsField.AsList())
                        {
                            Console.WriteLine("Item:");

                            if (itemField.ValueType == DocumentFieldType.Dictionary)
                            {
                                IReadOnlyDictionary<string, DocumentField> itemFields = itemField.AsDictionary();

                                if (itemFields.TryGetValue("Description", out DocumentField itemDescriptionField))
                                {
                                    if (itemDescriptionField.ValueType == DocumentFieldType.String)
                                    {
                                        string itemDescription = itemDescriptionField.AsString();

                                        Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                                    }
                                }

                                if (itemFields.TryGetValue("Amount", out DocumentField itemAmountField))
                                {
                                    if (itemAmountField.ValueType == DocumentFieldType.Double)
                                    {
                                        double itemAmount = itemAmountField.AsDouble();

                                        Console.WriteLine($"  Amount: '{itemAmount}', with confidence {itemAmountField.Confidence}");
                                    }
                                }
                            }
                        }
                    }
                }

                if (document.Fields.TryGetValue("SubTotal", out DocumentField subTotalField))
                {
                    if (subTotalField.ValueType == DocumentFieldType.Double)
                    {
                        double subTotal = subTotalField.AsDouble();
                        Console.WriteLine($"Sub Total: '{subTotal}', with confidence {subTotalField.Confidence}");
                    }
                }

                if (document.Fields.TryGetValue("TotalTax", out DocumentField totalTaxField))
                {
                    if (totalTaxField.ValueType == DocumentFieldType.Double)
                    {
                        double totalTax = totalTaxField.AsDouble();
                        Console.WriteLine($"Total Tax: '{totalTax}', with confidence {totalTaxField.Confidence}");
                    }
                }

                if (document.Fields.TryGetValue("InvoiceTotal", out DocumentField invoiceTotalField))
                {
                    if (invoiceTotalField.ValueType == DocumentFieldType.Double)
                    {
                        double invoiceTotal = invoiceTotalField.AsDouble();
                        Console.WriteLine($"Invoice Total: '{invoiceTotal}', with confidence {invoiceTotalField.Confidence}");
                    }
                }
            }
            #endregion
        }
    }
}
