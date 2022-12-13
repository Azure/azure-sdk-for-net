# Recognize Identity Documents

This sample demonstrates how to recognize and extract common fields from identity documents, using a pre-trained model. For a suggested approach to extracting information from identity documents, see [strongly-typing a recognized form][strongly_typing_a_recognized_form].

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

## Recognize identity documents from a URI

To recognize identity documents from a URI, use the `StartRecognizeIdentityDocumentsFromUriAsync` method.

For simplicity, we are not showing all the fields that the service returns. To see the list of all the supported fields returned by service and its corresponding types, consult: [here](https://aka.ms/formrecognizer/iddocumentfields).

```C# Snippet:FormRecognizerSampleRecognizeIdentityDocumentsUri
Uri sourceUri = new Uri("<sourceUri>");

RecognizeIdentityDocumentsOperation operation = await client.StartRecognizeIdentityDocumentsFromUriAsync(sourceUri);
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
```

## Recognize identity documents from a given file

To recognize identity documents from a given file, use the `StartRecognizeIdentityDocumentsAsync` method.

For simplicity, we are not showing all the fields that the service returns. To see the list of all the supported fields returned by service and its corresponding types, consult: [here](https://aka.ms/formrecognizer/iddocumentfields).

```C# Snippet:FormRecognizerSampleRecognizeIdentityDocumentsFileStream
string sourcePath = "<sourcePath>";

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
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[strongly_typing_a_recognized_form]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample4_StronglyTypingARecognizedForm.md
