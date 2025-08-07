# Recognizing Personally Identifiable Information in Documents

This sample demonstrates how to recognize Personally Identifiable Information (PII) in one or more documents.

## Create a `TextAnalysisClient`

To create a new `TextAnalysisClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
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

The new features � `ValueExclusion`, `Synonyms`, and `new entity types` � are supported in version V2025_05_15_Preview or later.
```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
var client = new TextAnalysisClient(endpoint, credential, options);
```


## Recognizing Personally Identifiable Information in multiple documents with Value Exclusion

To recognize Personally Identifiable Information in multiple documents, call `AnalyzeTextAsync` on an `TextPiiEntitiesRecognitionInput`.  The results are returned as a `AnalyzeTextPiiResult`.

```C# Snippet:Sample5_AnalyzeTextAsync_RecognizePii_WithValueExclusion
string text = "My SSN is 859-98-0987.";

AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("3", text) { Language = "en" },
        }
    },
    ActionContent = new PiiActionContent()
    {
        ModelVersion = "latest",
        ValueExclusionPolicy = new ValueExclusionPolicy(
            caseSensitive: false,
            excludedValues: new[] { "859-98-0987" }
        )
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

foreach (PiiActionResult result in piiTaskResult.Results.Documents)
{
    Console.WriteLine($"Document Id: {result.Id}");
    Console.WriteLine($"  Redacted Text: {result.RedactedText}");
    Console.WriteLine($"  Number of recognized entities: {result.Entities.Count}");

    foreach (PiiEntity entity in result.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.Subcategory))
            Console.WriteLine($"    SubCategory: {entity.Subcategory}");
        Console.WriteLine($"    Confidence Score: {entity.ConfidenceScore}");
    }

    Console.WriteLine();
}

foreach (DocumentError error in piiTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {error.Id}!");
    Console.WriteLine($"  Document error code: {error.Error.Code}");
    Console.WriteLine($"  Message: {error.Error.Message}");
    Console.WriteLine();
}
```

## Recognizing Personally Identifiable Information in multiple documents with Synonyms

To recognize Personally Identifiable Information in multiple documents, call `AnalyzeTextAsync` on an `TextPiiEntitiesRecognitionInput`.  The results are returned as a `AnalyzeTextPiiResult`.

```C# Snippet:Sample5_AnalyzeTextAsync_RecognizePii_WithSynonyms
PiiActionContent actionContent = new PiiActionContent();
actionContent.ExcludePiiCategories.Add(PiiCategoriesExclude.PhoneNumber);
actionContent.EntitySynonyms.Add(
    new EntitySynonyms(
        new EntityCategory("USBankAccountNumber"),
        new List<EntitySynonym>
        {
            new EntitySynonym("FAN") { Language = "en" },
            new EntitySynonym("RAN") { Language = "en" }
        }
    )
);

// Create request
AnalyzeTextInput input = new TextPiiEntitiesRecognitionInput
{
    TextInput = new MultiLanguageTextInput
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("1", "My FAN is 281314478878") { Language = "en" },
            new MultiLanguageInput("2", "My bank account number is 281314478873.") { Language = "en" },
            new MultiLanguageInput("3", "My FAN is 281314478878 and Tom's RAN is 281314478879.") { Language = "en" },
        }
    },
    ActionContent = actionContent
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(input);
AnalyzeTextPiiResult piiResult = (AnalyzeTextPiiResult)response.Value;

Console.WriteLine("Recognized PII entities and redacted texts:\n");
foreach (PiiActionResult doc in piiResult.Results.Documents)
{
    Console.WriteLine($"Document ID: {doc.Id}");
    Console.WriteLine($"  Redacted Text: {doc.RedactedText}");
    Console.WriteLine($"  Number of recognized entities: {doc.Entities.Count}");

    foreach (PiiEntity entity in doc.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Category: {entity.Category}");
        Console.WriteLine($"    Type: {entity.Type}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Confidence Score: {entity.ConfidenceScore}");

        if (entity.Tags != null && entity.Tags.Count > 0)
        {
            Console.WriteLine("    Tags:");
            foreach (EntityTag tag in entity.Tags)
            {
                Console.WriteLine($"      - Name: {tag.Name}, ConfidenceScore: {tag.ConfidenceScore}");
            }
        }

        Console.WriteLine();
    }

    Console.WriteLine();
}

// Handle potential errors
foreach (DocumentError error in piiResult.Results.Errors)
{
    Console.WriteLine($"Error in document {error.Id}!");
    Console.WriteLine($"  Error code: {error.Error.Code}");
    Console.WriteLine($"  Message: {error.Error.Message}");
    Console.WriteLine();
}
```

## Recognizing Personally Identifiable Information in multiple documents with new entity types

To recognize Personally Identifiable Information in multiple documents, call `AnalyzeTextAsync` on an `TextPiiEntitiesRecognitionInput`.  The results are returned as a `AnalyzeTextPiiResult`.

```C# Snippet:Sample5_AnalyzeTextAsync_RecognizePii_WithNewEntityTypes
AnalyzeTextInput input = new TextPiiEntitiesRecognitionInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("1", "The date of birth is May 15th, 2015") { Language = "en" },
            new MultiLanguageInput("2", "The phone number is (555) 123-4567") { Language = "en" }
        }
    },
    ActionContent = new PiiActionContent()
    {
        ModelVersion = "2025-05-15-preview"
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(input);
AnalyzeTextPiiResult result = (AnalyzeTextPiiResult)response.Value;

Console.WriteLine($"Model Version: {result.Results.ModelVersion}");
Console.WriteLine();

foreach (PiiActionResult doc in result.Results.Documents)
{
    Console.WriteLine($"Document ID: {doc.Id}");
    Console.WriteLine($"  Redacted Text: {doc.RedactedText}");
    Console.WriteLine($"  Number of recognized entities: {doc.Entities.Count}");

    foreach (PiiEntity entity in doc.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Category: {entity.Category}");
        Console.WriteLine($"    Type: {entity.Type}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Confidence Score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }

    Console.WriteLine();
}

// Handle potential errors
foreach (DocumentError error in result.Results.Errors)
{
    Console.WriteLine($"Error in document {error.Id}!");
    Console.WriteLine($"  Error code: {error.Error.Code}");
    Console.WriteLine($"  Message: {error.Error.Message}");
    Console.WriteLine();
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/README.md
