// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples
    {
        [RecordedTest]
        public async Task RecognizeIdentityDocumentsFromFile()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerSampleRecognizeIdentityDocumentsFileStream
#if SNIPPET
            string sourcePath = "<sourcePath>";
#else
            string sourcePath = FormRecognizerTestEnvironment.CreatePath("license.jpg");
#endif

            using var stream = new FileStream(sourcePath, FileMode.Open);

            RecognizeIdentityDocumentsOperation operation = await client.StartRecognizeIdentityDocumentsAsync(stream);
            Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
            RecognizedFormCollection identityDocuments = operationResponse.Value;

            // To see the list of all the supported fields returned by service and its corresponding types, consult:
            // https://aka.ms/formrecognizer/iddocumentfields

            RecognizedForm identityDocument = identityDocuments.Single();

            if (identityDocument.Fields.TryGetValue("Address", out FormField addressField))
            {
                if (addressField.Value.ValueType == FieldValueType.String)
                {
                    string address = addressField.Value.AsString();
                    Console.WriteLine($"Address: '{address}', with confidence {addressField.Confidence}");
                }
            }

            if (identityDocument.Fields.TryGetValue("CountryRegion", out FormField countryRegionField))
            {
                if (countryRegionField.Value.ValueType == FieldValueType.CountryRegion)
                {
                    string countryRegion = countryRegionField.Value.AsCountryRegion();
                    Console.WriteLine($"CountryRegion: '{countryRegion}', with confidence {countryRegionField.Confidence}");
                }
            }

            if (identityDocument.Fields.TryGetValue("DateOfBirth", out FormField dateOfBirthField))
            {
                if (dateOfBirthField.Value.ValueType == FieldValueType.Date)
                {
                    DateTime dateOfBirth = dateOfBirthField.Value.AsDate();
                    Console.WriteLine($"Date Of Birth: '{dateOfBirth}', with confidence {dateOfBirthField.Confidence}");
                }
            }

            if (identityDocument.Fields.TryGetValue("DateOfExpiration", out FormField dateOfExpirationField))
            {
                if (dateOfExpirationField.Value.ValueType == FieldValueType.Date)
                {
                    DateTime dateOfExpiration = dateOfExpirationField.Value.AsDate();
                    Console.WriteLine($"Date Of Expiration: '{dateOfExpiration}', with confidence {dateOfExpirationField.Confidence}");
                }
            }

            if (identityDocument.Fields.TryGetValue("DocumentNumber", out FormField documentNumberField))
            {
                if (documentNumberField.Value.ValueType == FieldValueType.String)
                {
                    string documentNumber = documentNumberField.Value.AsString();
                    Console.WriteLine($"Document Number: '{documentNumber}', with confidence {documentNumberField.Confidence}");
                }
            }

            if (identityDocument.Fields.TryGetValue("FirstName", out FormField firstNameField))
            {
                if (firstNameField.Value.ValueType == FieldValueType.String)
                {
                    string firstName = firstNameField.Value.AsString();
                    Console.WriteLine($"First Name: '{firstName}', with confidence {firstNameField.Confidence}");
                }
            }

            if (identityDocument.Fields.TryGetValue("LastName", out FormField lastNameField))
            {
                if (lastNameField.Value.ValueType == FieldValueType.String)
                {
                    string lastName = lastNameField.Value.AsString();
                    Console.WriteLine($"Last Name: '{lastName}', with confidence {lastNameField.Confidence}");
                }
            }

            if (identityDocument.Fields.TryGetValue("Region", out FormField regionfield))
            {
                if (regionfield.Value.ValueType == FieldValueType.String)
                {
                    string region = regionfield.Value.AsString();
                    Console.WriteLine($"Region: '{region}', with confidence {regionfield.Confidence}");
                }
            }

            if (identityDocument.Fields.TryGetValue("Sex", out FormField sexfield))
            {
                if (sexfield.Value.ValueType == FieldValueType.String)
                {
                    string sex = sexfield.Value.AsString();
                    Console.WriteLine($"Sex: '{sex}', with confidence {sexfield.Confidence}");
                }
            }

            #endregion
        }
    }
}
