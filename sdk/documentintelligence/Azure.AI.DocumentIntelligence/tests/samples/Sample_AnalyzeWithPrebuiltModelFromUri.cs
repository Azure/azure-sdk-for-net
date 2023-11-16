// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.DocumentIntelligence.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Samples
{
    public partial class DocumentIntelligenceSamples
    {
        [RecordedTest]
        public async Task AnalyzeWithPrebuiltModelFromUriAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DocumentIntelligenceAnalyzeWithPrebuiltModelFromUriAsync
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("Form_1.jpg");
#endif

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = uriSource
            };

            Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-invoice", content);
            AnalyzeResult result = operation.Value;

            // To see the list of all the supported fields returned by service and its corresponding types for the
            // prebuilt-invoice model, see:
            // https://aka.ms/azsdk/formrecognizer/invoicefieldschema

            for (int i = 0; i < result.Documents.Count; i++)
            {
                Console.WriteLine($"Document {i}:");

                AnalyzedDocument document = result.Documents[i];

                if (document.Fields.TryGetValue("VendorName", out DocumentField vendorNameField)
                    && vendorNameField.Type == DocumentFieldType.String)
                {
                    string vendorName = vendorNameField.ValueString;
                    Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
                }

                if (document.Fields.TryGetValue("CustomerName", out DocumentField customerNameField)
                    && customerNameField.Type == DocumentFieldType.String)
                {
                    string customerName = customerNameField.ValueString;
                    Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
                }

                if (document.Fields.TryGetValue("Items", out DocumentField itemsField)
                    && itemsField.Type == DocumentFieldType.Array)
                {
                    foreach (DocumentField itemField in itemsField.ValueArray)
                    {
                        Console.WriteLine("Item:");

                        if (itemField.Type == DocumentFieldType.Object)
                        {
                            IReadOnlyDictionary<string, DocumentField> itemFields = itemField.ValueObject;

                            if (itemFields.TryGetValue("Description", out DocumentField itemDescriptionField)
                                && itemDescriptionField.Type == DocumentFieldType.String)
                            {
                                string itemDescription = itemDescriptionField.ValueString;
                                Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                            }

                            if (itemFields.TryGetValue("Amount", out DocumentField itemAmountField)
                                && itemAmountField.Type == DocumentFieldType.Currency)
                            {
                                CurrencyValue itemAmount = itemAmountField.ValueCurrency;
                                Console.WriteLine($"  Amount: '{itemAmount.CurrencySymbol}{itemAmount.Amount}', with confidence {itemAmountField.Confidence}");
                            }
                        }
                    }
                }

                if (document.Fields.TryGetValue("SubTotal", out DocumentField subTotalField)
                    && subTotalField.Type == DocumentFieldType.Currency)
                {
                    CurrencyValue subTotal = subTotalField.ValueCurrency;
                    Console.WriteLine($"Sub Total: '{subTotal.CurrencySymbol}{subTotal.Amount}', with confidence {subTotalField.Confidence}");
                }

                if (document.Fields.TryGetValue("TotalTax", out DocumentField totalTaxField)
                    && totalTaxField.Type == DocumentFieldType.Currency)
                {
                    CurrencyValue totalTax = totalTaxField.ValueCurrency;
                    Console.WriteLine($"Total Tax: '{totalTax.CurrencySymbol}{totalTax.Amount}', with confidence {totalTaxField.Confidence}");
                }

                if (document.Fields.TryGetValue("InvoiceTotal", out DocumentField invoiceTotalField)
                    && invoiceTotalField.Type == DocumentFieldType.Currency)
                {
                    CurrencyValue invoiceTotal = invoiceTotalField.ValueCurrency;
                    Console.WriteLine($"Invoice Total: '{invoiceTotal.CurrencySymbol}{invoiceTotal.Amount}', with confidence {invoiceTotalField.Confidence}");
                }
            }
            #endregion
        }
    }
}
