// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

            string invoicePath = FormRecognizerTestEnvironment.CreatePath("Invoice_1.pdf");

            #region Snippet:FormRecognizerSampleRecognizeInvoicesFileStream
            using (FileStream stream = new FileStream(invoicePath, FileMode.Open))
            {
                var options = new RecognizeInvoicesOptions() { Locale = "en-US" };
                RecognizedFormCollection invoices = await client.StartRecognizeInvoicesAsync(stream, options).WaitForCompletionAsync();

                // To see the list of the supported fields returned by service and its corresponding types, consult:
                // https://aka.ms/formrecognizer/invoicefields

                RecognizedForm invoice = invoices.Single();

                FormField vendorNameField;
                if (invoice.Fields.TryGetValue("VendorName", out vendorNameField))
                {
                    if (vendorNameField.Value.ValueType == FieldValueType.String)
                    {
                        string vendorName = vendorNameField.Value.AsString();
                        Console.WriteLine($"    Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
                    }
                }

                FormField customerNameField;
                if (invoice.Fields.TryGetValue("CustomerName", out customerNameField))
                {
                    if (customerNameField.Value.ValueType == FieldValueType.String)
                    {
                        string customerName = customerNameField.Value.AsString();
                        Console.WriteLine($"    Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
                    }
                }

                FormField invoiceTotalField;
                if (invoice.Fields.TryGetValue("InvoiceTotal", out invoiceTotalField))
                {
                    if (invoiceTotalField.Value.ValueType == FieldValueType.Float)
                    {
                        float invoiceTotal = invoiceTotalField.Value.AsFloat();
                        Console.WriteLine($"    Invoice Total: '{invoiceTotal}', with confidence {invoiceTotalField.Confidence}");
                    }
                }
            }
            #endregion
        }
    }
}
