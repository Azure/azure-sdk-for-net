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
        public async Task RecognizeIdDocumentsFromUri()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerSampleRecognizeIdDocumentsUri
#if SNIPPET
            Uri sourceUri = "<sourceUri>";
#else
            Uri sourceUri = FormRecognizerTestEnvironment.CreateUri("license.jpg");
#endif

            RecognizeIdDocumentsOperation operation = await client.StartRecognizeIdDocumentsFromUriAsync(sourceUri);
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
                if (countryField.Value.ValueType == FieldValueType.Country)
                {
                    string country = countryField.Value.AsCountryCode();
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

            if (idDocument.Fields.TryGetValue("DateOfExpiration", out FormField dateOfExpirationField))
            {
                if (dateOfExpirationField.Value.ValueType == FieldValueType.Date)
                {
                    DateTime dateOfExpiration = dateOfExpirationField.Value.AsDate();
                    Console.WriteLine($"Date Of Expiration: '{dateOfExpiration}', with confidence {dateOfExpirationField.Confidence}");
                }
            }

            if (idDocument.Fields.TryGetValue("DocumentNumber", out FormField documentNumberField))
            {
                if (documentNumberField.Value.ValueType == FieldValueType.String)
                {
                    string documentNumber = documentNumberField.Value.AsString();
                    Console.WriteLine($"Document Number: '{documentNumber}', with confidence {documentNumberField.Confidence}");
                }
            }

            if (idDocument.Fields.TryGetValue("FirstName", out FormField firstNameField))
            {
                if (firstNameField.Value.ValueType == FieldValueType.String)
                {
                    string firstName = firstNameField.Value.AsString();
                    Console.WriteLine($"First Name: '{firstName}', with confidence {firstNameField.Confidence}");
                }
            }

            if (idDocument.Fields.TryGetValue("LastName", out FormField lastNameField))
            {
                if (lastNameField.Value.ValueType == FieldValueType.String)
                {
                    string lastName = lastNameField.Value.AsString();
                    Console.WriteLine($"Last Name: '{lastName}', with confidence {lastNameField.Confidence}");
                }
            }

            if (idDocument.Fields.TryGetValue("Region", out FormField regionfield))
            {
                if (regionfield.Value.ValueType == FieldValueType.String)
                {
                    string region = regionfield.Value.AsString();
                    Console.WriteLine($"Region: '{region}', with confidence {regionfield.Confidence}");
                }
            }

            #endregion
        }
    }
}
