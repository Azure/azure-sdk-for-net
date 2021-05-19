// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public async Task RecognizeBusinessCardsFromUri()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            Uri businessCardUri = FormRecognizerTestEnvironment.CreateUri("businessCard.jpg");

            #region Snippet:FormRecognizerSampleRecognizeBusinessCardsFromUri
            //@@ Uri businessCardUri = <businessCardUri>;

            RecognizeBusinessCardsOperation operation = await client.StartRecognizeBusinessCardsFromUriAsync(businessCardUri);
            Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
            RecognizedFormCollection businessCards = operationResponse.Value;

            // To see the list of the supported fields returned by service and its corresponding types, consult:
            // https://aka.ms/formrecognizer/businesscardfields

            foreach (RecognizedForm businessCard in businessCards)
            {
                if (businessCard.Fields.TryGetValue("ContactNames", out FormField ContactNamesField))
                {
                    if (ContactNamesField.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField contactNameField in ContactNamesField.Value.AsList())
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

                if (businessCard.Fields.TryGetValue("JobTitles", out FormField jobTitlesFields))
                {
                    if (jobTitlesFields.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField jobTitleField in jobTitlesFields.Value.AsList())
                        {
                            if (jobTitleField.Value.ValueType == FieldValueType.String)
                            {
                                string jobTitle = jobTitleField.Value.AsString();

                                Console.WriteLine($"Job Title: '{jobTitle}', with confidence {jobTitleField.Confidence}");
                            }
                        }
                    }
                }

                if (businessCard.Fields.TryGetValue("Departments", out FormField departmentFields))
                {
                    if (departmentFields.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField departmentField in departmentFields.Value.AsList())
                        {
                            if (departmentField.Value.ValueType == FieldValueType.String)
                            {
                                string department = departmentField.Value.AsString();

                                Console.WriteLine($"Department: '{department}', with confidence {departmentField.Confidence}");
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

                if (businessCard.Fields.TryGetValue("Websites", out FormField websiteFields))
                {
                    if (websiteFields.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField websiteField in websiteFields.Value.AsList())
                        {
                            if (websiteField.Value.ValueType == FieldValueType.String)
                            {
                                string website = websiteField.Value.AsString();

                                Console.WriteLine($"Website: '{website}', with confidence {websiteField.Confidence}");
                            }
                        }
                    }
                }

                if (businessCard.Fields.TryGetValue("MobilePhones", out FormField mobilePhonesFields))
                {
                    if (mobilePhonesFields.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField mobilePhoneField in mobilePhonesFields.Value.AsList())
                        {
                            if (mobilePhoneField.Value.ValueType == FieldValueType.PhoneNumber)
                            {
                                string mobilePhone = mobilePhoneField.Value.AsPhoneNumber();

                                Console.WriteLine($"Mobile phone number: '{mobilePhone}', with confidence {mobilePhoneField.Confidence}");
                            }
                        }
                    }
                }

                if (businessCard.Fields.TryGetValue("OtherPhones", out FormField otherPhonesFields))
                {
                    if (otherPhonesFields.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField otherPhoneField in otherPhonesFields.Value.AsList())
                        {
                            if (otherPhoneField.Value.ValueType == FieldValueType.PhoneNumber)
                            {
                                string otherPhone = otherPhoneField.Value.AsPhoneNumber();

                                Console.WriteLine($"Other phone number: '{otherPhone}', with confidence {otherPhoneField.Confidence}");
                            }
                        }
                    }
                }

                if (businessCard.Fields.TryGetValue("Faxes", out FormField faxesFields))
                {
                    if (faxesFields.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField faxField in faxesFields.Value.AsList())
                        {
                            if (faxField.Value.ValueType == FieldValueType.PhoneNumber)
                            {
                                string fax = faxField.Value.AsPhoneNumber();

                                Console.WriteLine($"Fax phone number: '{fax}', with confidence {faxField.Confidence}");
                            }
                        }
                    }
                }

                if (businessCard.Fields.TryGetValue("Addresses", out FormField addressesFields))
                {
                    if (addressesFields.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField addressField in addressesFields.Value.AsList())
                        {
                            if (addressField.Value.ValueType == FieldValueType.String)
                            {
                                string address = addressField.Value.AsString();

                                Console.WriteLine($"Address: '{address}', with confidence {addressField.Confidence}");
                            }
                        }
                    }
                }

                if (businessCard.Fields.TryGetValue("CompanyNames", out FormField companyNamesFields))
                {
                    if (companyNamesFields.Value.ValueType == FieldValueType.List)
                    {
                        foreach (FormField companyNameField in companyNamesFields.Value.AsList())
                        {
                            if (companyNameField.Value.ValueType == FieldValueType.String)
                            {
                                string companyName = companyNameField.Value.AsString();

                                Console.WriteLine($"Company name: '{companyName}', with confidence {companyNameField.Confidence}");
                            }
                        }
                    }
                }
            }
            #endregion
        }
    }
}
