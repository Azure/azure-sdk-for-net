// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task RecognizeBusinessCardsFromFile()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string businessCardsPath = FormRecognizerTestEnvironment.CreatePath("businessCard.jpg");

            #region Snippet:FormRecognizerSampleRecognizeBusinessCardFileStream
            //@@ string businessCardsPath = "<businessCardsPath>";

            using var stream = new FileStream(businessCardsPath, FileMode.Open);
            var options = new RecognizeBusinessCardsOptions() { Locale = "en-US" };

            RecognizeBusinessCardsOperation operation = await client.StartRecognizeBusinessCardsAsync(stream, options);
            Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
            RecognizedFormCollection businessCards = operationResponse.Value;

            // To see the list of the supported fields returned by service and its corresponding types, consult:
            // https://aka.ms/formrecognizer/businesscardfields

            foreach (RecognizedForm businessCard in businessCards)
            {
                if (businessCard.Fields.TryGetValue("ContactNames", out FormField contactNamesField))
                {
                    if (contactNamesField.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField contactNameField in contactNamesField.Value.AsList())
                        {
                            Console.WriteLine($"Contact Name: {contactNameField.ValueData.Text}");

                            if (contactNameField.Value.ValueType == FieldValueType.Dictionary)
                            {
                                IReadOnlyDictionary<string, FormField> contactNameFields = contactNameField.Value.AsDictionary();

                                if (contactNameFields.TryGetValue("FirstName", out FormField firstNameField))
                                {
                                    if (firstNameField.Value.ValueType == FieldValueType.String)
                                    {
                                        string firstName = firstNameField.Value.AsString();

                                        Console.WriteLine($"  First Name: '{firstName}', with confidence {firstNameField.Confidence}");
                                    }
                                }

                                if (contactNameFields.TryGetValue("LastName", out FormField lastNameField))
                                {
                                    if (lastNameField.Value.ValueType == FieldValueType.String)
                                    {
                                        string lastName = lastNameField.Value.AsString();

                                        Console.WriteLine($"  Last Name: '{lastName}', with confidence {lastNameField.Confidence}");
                                    }
                                }
                            }
                        }
                    }
                }

                if (businessCard.Fields.TryGetValue("Emails", out FormField emailFields))
                {
                    if (emailFields.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField emailField in emailFields.Value.AsList())
                        {
                            if (emailField.Value.ValueType == FieldValueType.String)
                            {
                                string email = emailField.Value.AsString();

                                Console.WriteLine($"Email: '{email}', with confidence {emailField.Confidence}");
                            }
                        }
                    }
                }
            }
            #endregion
        }
    }
}
