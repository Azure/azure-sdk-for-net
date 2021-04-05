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
        public async Task RecognizeIdDocumentsFromFile()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string sourcePath = FormRecognizerTestEnvironment.CreatePath("license.jpg");

            #region Snippet:FormRecognizerSampleRecognizeIdDocumentsFileStream
            //@@ string invoicePath = "<invoicePath>";

            using var stream = new FileStream(sourcePath, FileMode.Open);

            RecognizeIdDocumentsOperation operation = await client.StartRecognizeIdDocumentsAsync(stream);
            Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
            RecognizedFormCollection idDocuments = operationResponse.Value;

            // To see the list of all the supported fields returned by service and its corresponding types, consult:
            // https://aka.ms/formrecognizer/iddocumentfields

            RecognizedForm idDocument = idDocuments.Single();

            if (idDocument.Fields.TryGetValue("Address", out FormField addressField))
            {
                if (addressField.Value.ValueType == FieldValueType.String)
                {
                    string address = addressField.Value.AsString();
                    Console.WriteLine($"Address: '{address}', with confidence {addressField.Confidence}");
                }
            }

            if (idDocument.Fields.TryGetValue("Country", out FormField countryField))
            {
                if (countryField.Value.ValueType == FieldValueType.String)
                {
                    string country = countryField.Value.AsString();
                    Console.WriteLine($"Country: '{country}', with confidence {countryField.Confidence}");
                }
            }

            if (idDocument.Fields.TryGetValue("DateOfBirth", out FormField dateOfBirthField))
            {
                if (dateOfBirthField.Value.ValueType == FieldValueType.Date)
                {
                    DateTime dateOfBirth = dateOfBirthField.Value.AsDate();
                    Console.WriteLine($"Date Of Birth: '{dateOfBirth}', with confidence {dateOfBirthField.Confidence}");
                }
            }

            if (idDocument.Fields.TryGetValue("SubTotal", out FormField subTotalField))
            {
                if (dateOfBirthField.Value.ValueType == FieldValueType.Float)
                {
                    float subTotal = dateOfBirthField.Value.AsFloat();
                    Console.WriteLine($"Sub Total: '{subTotal}', with confidence {dateOfBirthField.Confidence}");
                }
            }

            if (idDocument.Fields.TryGetValue("TotalTax", out FormField totalTaxField))
            {
                if (totalTaxField.Value.ValueType == FieldValueType.Float)
                {
                    float totalTax = totalTaxField.Value.AsFloat();
                    Console.WriteLine($"Total Tax: '{totalTax}', with confidence {totalTaxField.Confidence}");
                }
            }

            if (idDocument.Fields.TryGetValue("InvoiceTotal", out FormField invoiceTotalField))
            {
                if (invoiceTotalField.Value.ValueType == FieldValueType.Float)
                {
                    float invoiceTotal = invoiceTotalField.Value.AsFloat();
                    Console.WriteLine($"Invoice Total: '{invoiceTotal}', with confidence {invoiceTotalField.Confidence}");
                }
            }

            #endregion
        }
    }
}
