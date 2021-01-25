# Recognize business cards

This sample demonstrates how to recognize and extract common fields from business cards, using a pre-trained model. For a suggested approach to extracting information from business cards, see [strongly-typing a recognized form][strongly_typing_a_recognized_form].

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `FormRecognizerClient`

To create a new `FormRecognizerClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateFormRecognizerClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new FormRecognizerClient(new Uri(endpoint), credential);
```

## Recognize business cards from a URI

To recognize business cards from a URI, use the `StartRecognizeBusinessCardsFromUri` method. The returned value is a collection of `RecognizedForm` objects -- one for each page in the submitted document.

```C# Snippet:FormRecognizerSampleRecognizeBusinessCardsFromUri
Uri businessCardUri = <businessCardUri>;

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
```

## Recognize business cards from a given file

To recognize business cards from a given file, use the `StartRecognizeBusinessCards` method. The returned value is a collection of `RecognizedForm` objects -- one for each page in the submitted document.

```C# Snippet:FormRecognizerSampleRecognizeBusinessCardFileStream
string businessCardsPath = "<businessCardsPath>";

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
```

To see the full example source files, see:

* [Recognize business cards from URI](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample12_RecognizeBusinessCardsFromUri.cs)
* [Recognize business cards from file](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample12_RecognizeBusinessCardsFromFile.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[strongly_typing_a_recognized_form]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample4_StronglyTypingARecognizedForm.md