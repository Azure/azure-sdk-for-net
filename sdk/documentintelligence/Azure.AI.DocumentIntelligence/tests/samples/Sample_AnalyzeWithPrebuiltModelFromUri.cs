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
            var client = new DocumentIntelligenceClient(new Uri(endpoint), TestEnvironment.Credential);

            #region Snippet:DocumentIntelligenceAnalyzeWithPrebuiltModelFromUriAsync
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("Form_1.jpg");
#endif
            Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-invoice", uriSource);
            AnalyzeResult result = operation.Value;

            // To see the list of all the supported fields returned by service and its corresponding types for the
            // prebuilt-invoice model, see:
            // https://aka.ms/azsdk/formrecognizer/invoicefieldschema

            for (int i = 0; i < result.Documents.Count; i++)
            {
                Console.WriteLine($"Document {i}:");

                AnalyzedDocument document = result.Documents[i];

                if (document.Fields.TryGetValue("VendorName", out DocumentField vendorNameField)
                    && vendorNameField.FieldType == DocumentFieldType.String)
                {
                    string vendorName = vendorNameField.ValueString;
                    Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
                }

                if (document.Fields.TryGetValue("CustomerName", out DocumentField customerNameField)
                    && customerNameField.FieldType == DocumentFieldType.String)
                {
                    string customerName = customerNameField.ValueString;
                    Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
                }

                if (document.Fields.TryGetValue("Items", out DocumentField itemsField)
                    && itemsField.FieldType == DocumentFieldType.List)
                {
                    foreach (DocumentField itemField in itemsField.ValueList)
                    {
                        Console.WriteLine("Item:");

                        if (itemField.FieldType == DocumentFieldType.Dictionary)
                        {
                            IReadOnlyDictionary<string, DocumentField> itemFields = itemField.ValueDictionary;

                            if (itemFields.TryGetValue("Description", out DocumentField itemDescriptionField)
                                && itemDescriptionField.FieldType == DocumentFieldType.String)
                            {
                                string itemDescription = itemDescriptionField.ValueString;
                                Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                            }

                            if (itemFields.TryGetValue("Amount", out DocumentField itemAmountField)
                                && itemAmountField.FieldType == DocumentFieldType.Currency)
                            {
                                CurrencyValue itemAmount = itemAmountField.ValueCurrency;
                                Console.WriteLine($"  Amount: '{itemAmount.CurrencySymbol}{itemAmount.Amount}', with confidence {itemAmountField.Confidence}");
                            }
                        }
                    }
                }

                if (document.Fields.TryGetValue("SubTotal", out DocumentField subTotalField)
                    && subTotalField.FieldType == DocumentFieldType.Currency)
                {
                    CurrencyValue subTotal = subTotalField.ValueCurrency;
                    Console.WriteLine($"Sub Total: '{subTotal.CurrencySymbol}{subTotal.Amount}', with confidence {subTotalField.Confidence}");
                }

                if (document.Fields.TryGetValue("TotalTax", out DocumentField totalTaxField)
                    && totalTaxField.FieldType == DocumentFieldType.Currency)
                {
                    CurrencyValue totalTax = totalTaxField.ValueCurrency;
                    Console.WriteLine($"Total Tax: '{totalTax.CurrencySymbol}{totalTax.Amount}', with confidence {totalTaxField.Confidence}");
                }

                if (document.Fields.TryGetValue("InvoiceTotal", out DocumentField invoiceTotalField)
                    && invoiceTotalField.FieldType == DocumentFieldType.Currency)
                {
                    CurrencyValue invoiceTotal = invoiceTotalField.ValueCurrency;
                    Console.WriteLine($"Invoice Total: '{invoiceTotal.CurrencySymbol}{invoiceTotal.Amount}', with confidence {invoiceTotalField.Confidence}");
                }
            }
            #endregion
        }
    }
}
