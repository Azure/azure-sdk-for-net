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
            using (FileStream stream = new FileStream(businessCardsPath, FileMode.Open))
            {
                var options = new RecognizeBusinessCardsOptions() { Locale = "en-US" };
                RecognizedFormCollection businessCards = await client.StartRecognizeBusinessCardsAsync(stream, options).WaitForCompletionAsync();

                // To see the list of the supported fields returned by service and its corresponding types, consult:
                // https://aka.ms/formrecognizer/businesscardfields

                foreach (RecognizedForm businessCard in businessCards)
                {
                    FormField contactNamesField;
                    if (businessCard.Fields.TryGetValue("ContactNames", out contactNamesField))
                    {
                        if (contactNamesField.Value.ValueType == FieldValueType.List)
                        {
                            foreach (FormField contactNameField in contactNamesField.Value.AsList())
                            {
                                Console.WriteLine($"Contact Name: {contactNameField.ValueData.Text}");

                                if (contactNameField.Value.ValueType == FieldValueType.Dictionary)
                                {
                                    IReadOnlyDictionary<string, FormField> contactNameFields = contactNameField.Value.AsDictionary();

                                    FormField firstNameField;
                                    if (contactNameFields.TryGetValue("FirstName", out firstNameField))
                                    {
                                        if (firstNameField.Value.ValueType == FieldValueType.String)
                                        {
                                            string firstName = firstNameField.Value.AsString();

                                            Console.WriteLine($"    First Name: '{firstName}', with confidence {firstNameField.Confidence}");
                                        }
                                    }

                                    FormField lastNameField;
                                    if (contactNameFields.TryGetValue("LastName", out lastNameField))
                                    {
                                        if (lastNameField.Value.ValueType == FieldValueType.String)
                                        {
                                            string lastName = lastNameField.Value.AsString();

                                            Console.WriteLine($"    Last Name: '{lastName}', with confidence {lastNameField.Confidence}");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    FormField emailFields;
                    if (businessCard.Fields.TryGetValue("Emails", out emailFields))
                    {
                        if (emailFields.Value.ValueType == FieldValueType.List)
                        {
                            foreach (FormField emailField in emailFields.Value.AsList())
                            {
                                if (emailField.Value.ValueType == FieldValueType.String)
                                {
                                    string email = emailField.Value.AsString();

                                    Console.WriteLine($"  Email: '{email}', with confidence {emailField.Confidence}");
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }
    }
}
