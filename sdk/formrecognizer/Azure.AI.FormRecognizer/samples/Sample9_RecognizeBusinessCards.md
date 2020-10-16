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
RecognizedFormCollection businessCards = await client.StartRecognizeBusinessCardsFromUriAsync(businessCardUri).WaitForCompletionAsync();

// To see the list of the supported fields returned by service and its corresponding types, consult:
// https://aka.ms/formrecognizer/businesscardfields

foreach (RecognizedForm businessCard in businessCards)
{
    FormField ContactNamesField;
    if (businessCard.Fields.TryGetValue("ContactNames", out ContactNamesField))
    {
        if (ContactNamesField.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField contactNameField in ContactNamesField.Value.AsList())
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

    FormField jobTitlesFields;
    if (businessCard.Fields.TryGetValue("JobTitles", out jobTitlesFields))
    {
        if (jobTitlesFields.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField jobTitleField in jobTitlesFields.Value.AsList())
            {
                if (jobTitleField.Value.ValueType == FieldValueType.String)
                {
                    string jobTitle = jobTitleField.Value.AsString();

                    Console.WriteLine($"  Job Title: '{jobTitle}', with confidence {jobTitleField.Confidence}");
                }
            }
        }
    }

    FormField departmentFields;
    if (businessCard.Fields.TryGetValue("Departments", out departmentFields))
    {
        if (departmentFields.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField departmentField in departmentFields.Value.AsList())
            {
                if (departmentField.Value.ValueType == FieldValueType.String)
                {
                    string department = departmentField.Value.AsString();

                    Console.WriteLine($"  Department: '{department}', with confidence {departmentField.Confidence}");
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

    FormField websiteFields;
    if (businessCard.Fields.TryGetValue("Websites", out websiteFields))
    {
        if (websiteFields.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField websiteField in websiteFields.Value.AsList())
            {
                if (websiteField.Value.ValueType == FieldValueType.String)
                {
                    string website = websiteField.Value.AsString();

                    Console.WriteLine($"  Website: '{website}', with confidence {websiteField.Confidence}");
                }
            }
        }
    }

    FormField mobilePhonesFields;
    if (businessCard.Fields.TryGetValue("MobilePhones", out mobilePhonesFields))
    {
        if (mobilePhonesFields.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField mobilePhoneField in mobilePhonesFields.Value.AsList())
            {
                if (mobilePhoneField.Value.ValueType == FieldValueType.PhoneNumber)
                {
                    string mobilePhone = mobilePhoneField.Value.AsPhoneNumber();

                    Console.WriteLine($"  Mobile phone number: '{mobilePhone}', with confidence {mobilePhoneField.Confidence}");
                }
            }
        }
    }

    FormField otherPhonesFields;
    if (businessCard.Fields.TryGetValue("OtherPhones", out otherPhonesFields))
    {
        if (otherPhonesFields.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField otherPhoneField in otherPhonesFields.Value.AsList())
            {
                if (otherPhoneField.Value.ValueType == FieldValueType.PhoneNumber)
                {
                    string otherPhone = otherPhoneField.Value.AsPhoneNumber();

                    Console.WriteLine($"  Other phone number: '{otherPhone}', with confidence {otherPhoneField.Confidence}");
                }
            }
        }
    }

    FormField faxesFields;
    if (businessCard.Fields.TryGetValue("Faxes", out faxesFields))
    {
        if (faxesFields.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField faxField in faxesFields.Value.AsList())
            {
                if (faxField.Value.ValueType == FieldValueType.PhoneNumber)
                {
                    string fax = faxField.Value.AsPhoneNumber();

                    Console.WriteLine($"  Fax phone number: '{fax}', with confidence {faxField.Confidence}");
                }
            }
        }
    }

    FormField addressesFields;
    if (businessCard.Fields.TryGetValue("Addresses", out addressesFields))
    {
        if (addressesFields.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField addressField in addressesFields.Value.AsList())
            {
                if (addressField.Value.ValueType == FieldValueType.String)
                {
                    string address = addressField.Value.AsString();

                    Console.WriteLine($"  Address: '{address}', with confidence {addressField.Confidence}");
                }
            }
        }
    }

    FormField companyNamesFields;
    if (businessCard.Fields.TryGetValue("CompanyNames", out companyNamesFields))
    {
        if (companyNamesFields.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField companyNameField in companyNamesFields.Value.AsList())
            {
                if (companyNameField.Value.ValueType == FieldValueType.String)
                {
                    string companyName = companyNameField.Value.AsString();

                    Console.WriteLine($"  Company name: '{companyName}', with confidence {companyNameField.Confidence}");
                }
            }
        }
    }
}
```

## Recognize business cards from a given file

To recognize business cards from a given file, use the `StartRecognizeBusinessCards` method. The returned value is a collection of `RecognizedForm` objects -- one for each page in the submitted document.

```C# Snippet:FormRecognizerRecognizeBusinessCardsFromFile
using (FileStream stream = new FileStream(businessCardsPath, FileMode.Open))
{
    RecognizedFormCollection businessCards = await client.StartRecognizeBusinessCardsAsync(stream).WaitForCompletionAsync();
    /*
     *
     */
}
```

To see the full example source files, see:

* [Recognize business cards from URI](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample12_RecognizeBusinessCardsFromUri.cs)
* [Recognize business cards from file](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample12_RecognizeBusinessCardsFromFile.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[strongly_typing_a_recognized_form]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample4_StronglyTypingARecognizedForm.md