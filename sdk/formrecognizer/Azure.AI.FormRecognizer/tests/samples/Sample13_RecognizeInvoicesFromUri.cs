// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task RecognizeInvoicesFromUri()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            Uri invoiceUri = FormRecognizerTestEnvironment.CreateUri("Invoice_1.pdf");

            #region Snippet:FormRecognizerSampleRecognizeInvoicesUri
            var options = new RecognizeInvoicesOptions() { Locale = "en-US" };
            RecognizedFormCollection invoices = await client.StartRecognizeInvoicesFromUriAsync(invoiceUri, options).WaitForCompletionAsync();

            // To see the list of the supported fields returned by service and its corresponding types, consult:
            // https://aka.ms/formrecognizer/invoicefields

            RecognizedForm invoice = invoices.Single();

            FormField invoiceIdField;
            if (invoice.Fields.TryGetValue("InvoiceId", out invoiceIdField))
            {
                if (invoiceIdField.Value.ValueType == FieldValueType.String)
                {
                    string invoiceId = invoiceIdField.Value.AsString();
                    Console.WriteLine($"    Invoice Id: '{invoiceId}', with confidence {invoiceIdField.Confidence}");
                }
            }

            FormField invoiceDateField;
            if (invoice.Fields.TryGetValue("InvoiceDate", out invoiceDateField))
            {
                if (invoiceDateField.Value.ValueType == FieldValueType.Date)
                {
                    DateTime invoiceDate = invoiceDateField.Value.AsDate();
                    Console.WriteLine($"    Invoice Date: '{invoiceDate}', with confidence {invoiceDateField.Confidence}");
                }
            }

            FormField dueDateField;
            if (invoice.Fields.TryGetValue("DueDate", out dueDateField))
            {
                if (dueDateField.Value.ValueType == FieldValueType.Date)
                {
                    DateTime dueDate = dueDateField.Value.AsDate();
                    Console.WriteLine($"    Due Date: '{dueDate}', with confidence {dueDateField.Confidence}");
                }
            }

            FormField vendorNameField;
            if (invoice.Fields.TryGetValue("VendorName", out vendorNameField))
            {
                if (vendorNameField.Value.ValueType == FieldValueType.String)
                {
                    string vendorName = vendorNameField.Value.AsString();
                    Console.WriteLine($"    Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
                }
            }

            FormField vendorAddressField;
            if (invoice.Fields.TryGetValue("VendorAddress", out vendorAddressField))
            {
                if (vendorAddressField.Value.ValueType == FieldValueType.String)
                {
                    string vendorAddress = vendorAddressField.Value.AsString();
                    Console.WriteLine($"    Vendor Address: '{vendorAddress}', with confidence {vendorAddressField.Confidence}");
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

            FormField customerAddressField;
            if (invoice.Fields.TryGetValue("CustomerAddress", out customerAddressField))
            {
                if (customerAddressField.Value.ValueType == FieldValueType.String)
                {
                    string customerAddress = customerAddressField.Value.AsString();
                    Console.WriteLine($"    Customer Address: '{customerAddress}', with confidence {customerAddressField.Confidence}");
                }
            }

            FormField customerAddressRecipientField;
            if (invoice.Fields.TryGetValue("CustomerAddressRecipient", out customerAddressRecipientField))
            {
                if (customerAddressRecipientField.Value.ValueType == FieldValueType.String)
                {
                    string customerAddressRecipient = customerAddressRecipientField.Value.AsString();
                    Console.WriteLine($"    Customer address recipient: '{customerAddressRecipient}', with confidence {customerAddressRecipientField.Confidence}");
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
