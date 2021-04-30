# Recognize ID Documents

This sample demonstrates how to recognize and extract common fields from ID documents, using a pre-trained model. For a suggested approach to extracting information from ID documents, see [strongly-typing a recognized form][strongly_typing_a_recognized_form].

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

## Recognize ID documents from a URI

To recognize ID documents from a URI, use the `StartRecognizeIdDocumentsFromUriAsync` method.

For simplicity, we are not showing all the fields that the service returns. To see the list of all the supported fields returned by service and its corresponding types, consult: [here](https://aka.ms/formrecognizer/iddocumentfields).

```C# Snippet:FormRecognizerSampleRecognizeIdDocumentsUri
Uri sourceUri = "<sourceUri>";

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
```

## Recognize ID documents from a given file

To recognize ID documents from a given file, use the `StartRecognizeIdDocumentsAsync` method.

For simplicity, we are not showing all the fields that the service returns. To see the list of all the supported fields returned by service and its corresponding types, consult: [here](https://aka.ms/formrecognizer/iddocumentfields).

```C# Snippet:FormRecognizerSampleRecognizeIdDocumentsFileStream
string sourcePath = "<sourcePath>";

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
```

To see the full example source files, see:

* [Recognize ID documents from URI](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample15_RecognizeIdDocumentsFromUri.cs)
* [Recognize ID documents from file](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample15_RecognizeIdDocumentsFromFile.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[strongly_typing_a_recognized_form]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample4_StronglyTypingARecognizedForm.md