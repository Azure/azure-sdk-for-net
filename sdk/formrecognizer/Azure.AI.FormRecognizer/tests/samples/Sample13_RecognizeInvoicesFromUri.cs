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
            //@@ Uri invoiceUri = <invoiceUri>;
            var options = new RecognizeInvoicesOptions() { Locale = "en-US" };

            RecognizeInvoicesOperation operation = await client.StartRecognizeInvoicesFromUriAsync(invoiceUri, options);
            Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
            RecognizedFormCollection invoices = operationResponse.Value;

            // To see the list of the supported fields returned by service and its corresponding types, consult:
            // https://aka.ms/formrecognizer/invoicefields

            RecognizedForm invoice = invoices.Single();

            if (invoice.Fields.TryGetValue("InvoiceId", out FormField invoiceIdField))
            {
                if (invoiceIdField.Value.ValueType == FieldValueType.String)
                {
                    string invoiceId = invoiceIdField.Value.AsString();
                    Console.WriteLine($"Invoice Id: '{invoiceId}', with confidence {invoiceIdField.Confidence}");
                }
            }

            if (invoice.Fields.TryGetValue("InvoiceDate", out FormField invoiceDateField))
            {
                if (invoiceDateField.Value.ValueType == FieldValueType.Date)
                {
                    DateTime invoiceDate = invoiceDateField.Value.AsDate();
                    Console.WriteLine($"Invoice Date: '{invoiceDate}', with confidence {invoiceDateField.Confidence}");
                }
            }

            if (invoice.Fields.TryGetValue("DueDate", out FormField dueDateField))
            {
                if (dueDateField.Value.ValueType == FieldValueType.Date)
                {
                    DateTime dueDate = dueDateField.Value.AsDate();
                    Console.WriteLine($"Due Date: '{dueDate}', with confidence {dueDateField.Confidence}");
                }
            }

            if (invoice.Fields.TryGetValue("VendorName", out FormField vendorNameField))
            {
                if (vendorNameField.Value.ValueType == FieldValueType.String)
                {
                    string vendorName = vendorNameField.Value.AsString();
                    Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
                }
            }

            if (invoice.Fields.TryGetValue("VendorAddress", out FormField vendorAddressField))
            {
                if (vendorAddressField.Value.ValueType == FieldValueType.String)
                {
                    string vendorAddress = vendorAddressField.Value.AsString();
                    Console.WriteLine($"Vendor Address: '{vendorAddress}', with confidence {vendorAddressField.Confidence}");
                }
            }

            if (invoice.Fields.TryGetValue("CustomerName", out FormField customerNameField))
            {
                if (customerNameField.Value.ValueType == FieldValueType.String)
                {
                    string customerName = customerNameField.Value.AsString();
                    Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
                }
            }

            if (invoice.Fields.TryGetValue("CustomerAddress", out FormField customerAddressField))
            {
                if (customerAddressField.Value.ValueType == FieldValueType.String)
                {
                    string customerAddress = customerAddressField.Value.AsString();
                    Console.WriteLine($"Customer Address: '{customerAddress}', with confidence {customerAddressField.Confidence}");
                }
            }

            if (invoice.Fields.TryGetValue("CustomerAddressRecipient", out FormField customerAddressRecipientField))
            {
                if (customerAddressRecipientField.Value.ValueType == FieldValueType.String)
                {
                    string customerAddressRecipient = customerAddressRecipientField.Value.AsString();
                    Console.WriteLine($"Customer address recipient: '{customerAddressRecipient}', with confidence {customerAddressRecipientField.Confidence}");
                }
            }

            if (invoice.Fields.TryGetValue("InvoiceTotal", out FormField invoiceTotalField))
            {
                if (invoiceTotalField.Value.ValueType == FieldValueType.Float)
                {
                    float invoiceTotal = invoiceTotalField.Value.AsFloat();
                    Console.WriteLine($"Invoice Total: '{invoiceTotal}', with confidence {invoiceTotalField.Confidence}");
                }
            }
        }
        #endregion
    }
}
