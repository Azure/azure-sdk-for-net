# Recognizing Personally Identifiable Information in Documents

This sample demonstrates how to recognize Personally Identifiable Information (PII) in one or more documents.

## Create a `TextAnalysisClient`

To create a new `TextAnalysisClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
var client = new TextAnalysisClient(endpoint, credential, options);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Recognizing Personally Identifiable Information in multiple documents

To recognize Personally Identifiable Information in multiple documents, call `AnalyzeText` on an `TextPiiEntitiesRecognitionInput`.  The results are returned as a `AnalyzeTextPiiResult`.

```C# Snippet:Sample5_AnalyzeTextAsync_RecognizePii
string textA =
    "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
    + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
    + " 998.214.865-68.";

string textB =
    "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
    + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
    + " they confirmed the number was 111000025.";

string textC = string.Empty;

AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
            new MultiLanguageInput("B", textB) { Language = "es" },
            new MultiLanguageInput("C", textC),
        }
    },
    ActionContent = new PiiActionContent()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

foreach (PiiActionResult piiResult in piiTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{piiResult.Id}\":");
    Console.WriteLine($"  Redacted Text: \"{piiResult.RedactedText}\":");
    Console.WriteLine($"  Recognized {piiResult.Entities.Count} entities:");

    foreach (PiiEntity entity in piiResult.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.Subcategory))
            Console.WriteLine($"    SubCategory: {entity.Subcategory}");
        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}

foreach (DocumentError analyzeTextDocumentError in piiTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

## Recognizing Personally Identifiable Information in multiple documents with a redaction policy

To recognize Personally Identifiable Information in multiple documents, call `AnalyzeText` on an `TextPiiEntitiesRecognitionInput`.  The results are returned as a `AnalyzeTextPiiResult`.

```C# Snippet:Sample5_AnalyzeTextAsync_RecognizePii_RedactionPolicy
string textA =
    "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
    + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
    + " 998.214.865-68.";

string textB =
    "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
    + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
    + " they confirmed the number was 111000025.";

string textC = string.Empty;

AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
            new MultiLanguageInput("B", textB) { Language = "es" },
            new MultiLanguageInput("C", textC),
        }
    },
    ActionContent = new PiiActionContent()
    {
        ModelVersion = "latest",
        // Avaliable RedactionPolicies: EntityMaskPolicyType, CharacterMaskPolicyType, and NoMaskPolicyType
        RedactionPolicy = new EntityMaskPolicyType()
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

foreach (PiiActionResult piiResult in piiTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{piiResult.Id}\":");
    Console.WriteLine($"  Redacted Text: \"{piiResult.RedactedText}\":");
    Console.WriteLine($"  Recognized {piiResult.Entities.Count} entities:");

    foreach (PiiEntity entity in piiResult.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.Subcategory))
            Console.WriteLine($"    SubCategory: {entity.Subcategory}");
        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}

foreach (DocumentError analyzeTextDocumentError in piiTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

## Recognizing Personally Identifiable Information in multiple documents with Value Exclusion

To recognize Personally Identifiable Information in multiple documents, call `AnalyzeTextAsync` on an `TextPiiEntitiesRecognitionInput`.  The results are returned as a `AnalyzeTextPiiResult`.

```C# Snippet:Sample5_AnalyzeTextAsync_RecognizePii_WithValueExclusion
string textA =
    "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
    + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
    + " 998.214.865-68.";

string textB =
    "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
    + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
    + " they confirmed the number was 111000025.";

string textC = string.Empty;

AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
            new MultiLanguageInput("B", textB) { Language = "es" },
            new MultiLanguageInput("C", textC),
        }
    },
    ActionContent = new PiiActionContent()
    {
        ModelVersion = "latest",
        // Avaliable RedactionPolicies: EntityMaskPolicyType, CharacterMaskPolicyType, and NoMaskPolicyType
        RedactionPolicy = new EntityMaskPolicyType()
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

foreach (PiiActionResult piiResult in piiTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{piiResult.Id}\":");
    Console.WriteLine($"  Redacted Text: \"{piiResult.RedactedText}\":");
    Console.WriteLine($"  Recognized {piiResult.Entities.Count} entities:");

    foreach (PiiEntity entity in piiResult.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.Subcategory))
            Console.WriteLine($"    SubCategory: {entity.Subcategory}");
        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}

foreach (DocumentError analyzeTextDocumentError in piiTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

## Recognizing Personally Identifiable Information in multiple documents with Synonyms

To recognize Personally Identifiable Information in multiple documents, call `AnalyzeTextAsync` on an `TextPiiEntitiesRecognitionInput`.  The results are returned as a `AnalyzeTextPiiResult`.

```C# Snippet:Sample5_AnalyzeTextAsync_RecognizePii_WithSynonyms
string textA =
    "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
    + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
    + " 998.214.865-68.";

string textB =
    "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
    + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
    + " they confirmed the number was 111000025.";

string textC = string.Empty;

AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
            new MultiLanguageInput("B", textB) { Language = "es" },
            new MultiLanguageInput("C", textC),
        }
    },
    ActionContent = new PiiActionContent()
    {
        ModelVersion = "latest",
        // Avaliable RedactionPolicies: EntityMaskPolicyType, CharacterMaskPolicyType, and NoMaskPolicyType
        RedactionPolicy = new EntityMaskPolicyType()
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

foreach (PiiActionResult piiResult in piiTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{piiResult.Id}\":");
    Console.WriteLine($"  Redacted Text: \"{piiResult.RedactedText}\":");
    Console.WriteLine($"  Recognized {piiResult.Entities.Count} entities:");

    foreach (PiiEntity entity in piiResult.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.Subcategory))
            Console.WriteLine($"    SubCategory: {entity.Subcategory}");
        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}

foreach (DocumentError analyzeTextDocumentError in piiTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

## Recognizing Personally Identifiable Information in multiple documents with new entity types

To recognize Personally Identifiable Information in multiple documents, call `AnalyzeTextAsync` on an `TextPiiEntitiesRecognitionInput`.  The results are returned as a `AnalyzeTextPiiResult`.

```C# Snippet:Sample5_AnalyzeTextAsync_RecognizePii_WithNewEntityTypes
string textA =
    "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
    + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
    + " 998.214.865-68.";

string textB =
    "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
    + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
    + " they confirmed the number was 111000025.";

string textC = string.Empty;

AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
            new MultiLanguageInput("B", textB) { Language = "es" },
            new MultiLanguageInput("C", textC),
        }
    },
    ActionContent = new PiiActionContent()
    {
        ModelVersion = "latest",
        // Avaliable RedactionPolicies: EntityMaskPolicyType, CharacterMaskPolicyType, and NoMaskPolicyType
        RedactionPolicy = new EntityMaskPolicyType()
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

foreach (PiiActionResult piiResult in piiTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{piiResult.Id}\":");
    Console.WriteLine($"  Redacted Text: \"{piiResult.RedactedText}\":");
    Console.WriteLine($"  Recognized {piiResult.Entities.Count} entities:");

    foreach (PiiEntity entity in piiResult.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.Subcategory))
            Console.WriteLine($"    SubCategory: {entity.Subcategory}");
        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}

foreach (DocumentError analyzeTextDocumentError in piiTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/README.md
