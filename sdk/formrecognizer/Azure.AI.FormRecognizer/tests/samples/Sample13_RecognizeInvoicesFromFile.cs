// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public async Task RecognizeInvoicesFromFile()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerSampleRecognizeInvoicesFileStream
#if SNIPPET
            string invoicePath = "<invoicePath>";
#else
            string invoicePath = FormRecognizerTestEnvironment.CreatePath("recommended_invoice.jpg");
#endif

            using var stream = new FileStream(invoicePath, FileMode.Open);
            var options = new RecognizeInvoicesOptions() { Locale = "en-US" };

            RecognizeInvoicesOperation operation = await client.StartRecognizeInvoicesAsync(stream, options);
            Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
            RecognizedFormCollection invoices = operationResponse.Value;

            // To see the list of all the supported fields returned by service and its corresponding types, consult:
            // https://aka.ms/formrecognizer/invoicefields

            RecognizedForm invoice = invoices.Single();

            if (invoice.Fields.TryGetValue("VendorName", out FormField vendorNameField))
            {
                if (vendorNameField.Value.TryParse<string>(out string vendorName))
                {
                    Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
                }
                else
                {
                    Console.WriteLine($"Not able to parse Vendor Name. Consider using 'ValueData.Text' property which current value is '{vendorNameField.ValueData.Text}'");
                }
            }

            if (invoice.Fields.TryGetValue("CustomerName", out FormField customerNameField))
            {
                if (customerNameField.Value.TryParse<string>(out string customerName))
                {
                    Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
                }
                else
                {
                    Console.WriteLine($"Not able to parse Customer Name. Consider using 'ValueData.Text' property which current value is '{customerNameField.ValueData.Text}'");
                }
            }

            if (invoice.Fields.TryGetValue("Items", out FormField itemsField))
            {
                if (itemsField.Value.TryParse(out IReadOnlyList<FormField> itemFieldsList))
                {
                    foreach (FormField itemField in itemFieldsList)
                    {
                        Console.WriteLine("Item:");

                        if (itemField.Value.TryParse(out IReadOnlyDictionary<string, FormField> itemFields))
                        {
                            if (itemFields.TryGetValue("Description", out FormField itemDescriptionField))
                            {
                                if (itemDescriptionField.Value.TryParse(out string itemDescription))
                                {
                                    Console.WriteLine($"Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                                }
                                else
                                {
                                    Console.WriteLine($"Not able to parse Description. Consider using 'ValueData.Text' property which current value is '{itemDescriptionField.ValueData.Text}'");
                                }
                            }

                            if (itemFields.TryGetValue("Unit", out FormField itemUnitField))
                            {
                                if (itemUnitField.Value.TryParse(out float itemUnit))
                                {
                                    Console.WriteLine($"  Unit: '{itemUnit}', with confidence {itemUnitField.Confidence}");
                                }
                                else
                                {
                                    Console.WriteLine($"  Not able to parse Unit. Consider using 'ValueData.Text' property which current value is '{itemUnitField.ValueData.Text}'");
                                }
                            }

                            if (itemFields.TryGetValue("Quantity", out FormField itemQuantityField))
                            {
                                if (itemQuantityField.Value.ValueType == FieldValueType.Float)
                                {
                                    float quantityAmount = itemQuantityField.Value.AsFloat();

                                    Console.WriteLine($"  Quantity: '{quantityAmount}', with confidence {itemQuantityField.Confidence}");
                                }
                            }

                            if (itemFields.TryGetValue("UnitPrice", out FormField itemUnitPriceField))
                            {
                                if (itemUnitPriceField.Value.TryParse(out float itemUnitPrice))
                                {
                                    Console.WriteLine($"  UnitPrice: '{itemUnitPrice}', with confidence {itemUnitPriceField.Confidence}");
                                }
                                else
                                {
                                    Console.WriteLine($"  Not able to parse UnitPrice. Consider using 'ValueData.Text' property which current value is '{itemUnitPriceField.ValueData.Text}'");
                                }
                            }

                            if (itemFields.TryGetValue("Tax", out FormField itemTaxPriceField))
                            {
                                if (itemQuantityField.Value.TryParse(out float quantityAmount))
                                {
                                    Console.WriteLine($"  Quantity: '{quantityAmount}', with confidence {itemQuantityField.Confidence}");
                                }
                                else
                                {
                                    Console.WriteLine($"  Not able to parse Quantity. Consider using 'ValueData.Text' property which current value is '{itemQuantityField.ValueData.Text}'");
                                }
                            }

                            if (itemFields.TryGetValue("Amount", out FormField itemAmountField))
                            {
                                if (itemAmountField.Value.TryParse(out float itemAmount))
                                {
                                    Console.WriteLine($"  Amount: '{itemAmount}', with confidence {itemAmountField.Confidence}");
                                }
                                else
                                {
                                    Console.WriteLine($"  Not able to parse Amount. Consider using 'ValueData.Text' property which current value is '{itemAmountField.ValueData.Text}'");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Error. Not able to parse to {itemField.Value.ValueType}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Error. Not able to parse to {itemsField.Value.ValueType}");
                }
            }

            if (invoice.Fields.TryGetValue("SubTotal", out FormField subTotalField))
            {
                if (subTotalField.Value.TryParse(out float subTotal))
                {
                    Console.WriteLine($"  Sub Total: '{subTotal}', with confidence {subTotalField.Confidence}");
                }
                else
                {
                    Console.WriteLine($"  Not able to parse Sub Total. Consider using 'ValueData.Text' property which current value is '{subTotalField.ValueData.Text}'");
                }
            }

            if (invoice.Fields.TryGetValue("TotalTax", out FormField totalTaxField))
            {
                if (totalTaxField.Value.TryParse(out float totalTax))
                {
                    Console.WriteLine($"  Total Tax: '{totalTax}', with confidence {totalTaxField.Confidence}");
                }
                else
                {
                    Console.WriteLine($"  Not able to parse Total Tax. Consider using 'ValueData.Text' property which current value is '{totalTaxField.ValueData.Text}'");
                }
            }

            if (invoice.Fields.TryGetValue("InvoiceTotal", out FormField invoiceTotalField))
            {
                if (invoiceTotalField.Value.TryParse(out float invoiceTotal))
                {
                    Console.WriteLine($" Invoice Total: '{invoiceTotal}', with confidence {invoiceTotalField.Confidence}");
                }
                else
                {
                    Console.WriteLine($"  Not able to parse Invoice Total. Consider using 'ValueData.Text' property which current value is '{invoiceTotalField.ValueData.Text}'");
                }
            }

            #endregion
        }
    }
}
