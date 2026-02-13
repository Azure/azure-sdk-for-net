# Sample 16: Create Analyzer with Labeled Training Data

This sample demonstrates how to create custom analyzers using labeled training data from Azure Blob Storage.

## Overview

Labeled training data allows you to train custom analyzers on annotated sample documents. This is useful when you need domain-specific field extraction beyond what prebuilt analyzers provide.

This sample mainly demonstrates the API pattern for creating an analyzer with labeled training data. For an easier labeling workflow, use **Azure AI Content Understanding Studio** at https://contentunderstanding.ai.azure.com/.

## Prerequisites

- An Azure Content Understanding resource
- Required models deployed: `gpt-4.1`, `text-embedding-3-large`
- (Optional) An Azure Blob Storage container with labeled training data

### Preparing labeled training data

Labeled receipt data is available in this repo at `tests/samples/sample_files/receipt_labels/`. To use real training data in LIVE mode:

1. Upload the `receipt_labels/` folder contents to an Azure Blob Storage container
2. Generate a container SAS URL with **List** and **Read** permissions
3. Set the environment variables below

### Environment variables

| Variable | Required | Description |
|---|---|---|
| `CONTENTUNDERSTANDING_ENDPOINT` | Yes | Azure Content Understanding endpoint URL |
| `CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL` | No | SAS URL for the Azure Blob container with labeled training data |
| `CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX` | No | Path prefix within the container (e.g., `"receipt_labels/"`). Omit if files are at the container root |

### Training data file structure

Each training document requires three files:
- `document.jpg` — The source document image
- `document.jpg.labels.json` — Field labels and annotations
- `document.jpg.result.json` — Pre-computed OCR results

## Example

```C# Snippet:ContentUnderstandingCreateAnalyzerWithLabels
// Generate a unique analyzer ID
string analyzerId = $"receipt_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

// Step 1: Define field schema for receipt extraction
var itemDefinition = new ContentFieldDefinition
{
    Type = ContentFieldType.Object,
    Method = GenerationMethod.Extract,
    Description = "Individual item details",
};
itemDefinition.Properties.Add("Quantity", new ContentFieldDefinition
{
    Type = ContentFieldType.String,
    Method = GenerationMethod.Extract,
    Description = "Quantity of the item",
});
itemDefinition.Properties.Add("Name", new ContentFieldDefinition
{
    Type = ContentFieldType.String,
    Method = GenerationMethod.Extract,
    Description = "Name of the item",
});
itemDefinition.Properties.Add("Price", new ContentFieldDefinition
{
    Type = ContentFieldType.String,
    Method = GenerationMethod.Extract,
    Description = "Price of the item",
});

var fieldSchema = new ContentFieldSchema(
    new Dictionary<string, ContentFieldDefinition>
    {
        ["MerchantName"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.String,
            Method = GenerationMethod.Extract,
            Description = "Name of the merchant",
        },
        ["Items"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.Array,
            Method = GenerationMethod.Generate,
            Description = "List of items purchased",
            ItemDefinition = itemDefinition,
        },
        ["Total"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.String,
            Method = GenerationMethod.Extract,
            Description = "Total amount",
        },
    }
)
{
    Name = "receipt_schema",
    Description = "Schema for receipt extraction with items",
};

// Step 2: Create labeled data knowledge source (optional, based on environment variable)
string? trainingDataSasUrl = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL");
string? trainingDataPrefix = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX");

var knowledgeSources = new List<KnowledgeSource>();
if (!string.IsNullOrEmpty(trainingDataSasUrl))
{
    var knowledgeSource = new LabeledDataKnowledgeSource(new Uri(trainingDataSasUrl));
    if (!string.IsNullOrEmpty(trainingDataPrefix))
    {
        knowledgeSource.Prefix = trainingDataPrefix;
    }
    knowledgeSources.Add(knowledgeSource);
    Console.WriteLine($"Using labeled training data from: {trainingDataSasUrl[..Math.Min(50, trainingDataSasUrl.Length)]}...");
}
else
{
    Console.WriteLine("No CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL set, creating analyzer without labeled training data");
}

// Step 3: Create analyzer (with or without labeled data)
var customAnalyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Receipt analyzer with labeled training data",
    Config = new ContentAnalyzerConfig
    {
        EnableLayout = true,
        EnableOcr = true,
    },
    FieldSchema = fieldSchema,
};
customAnalyzer.Models.Add("completion", "gpt-4.1");
customAnalyzer.Models.Add("embedding", "text-embedding-3-large");

if (knowledgeSources.Count > 0)
{
    foreach (var ks in knowledgeSources)
    {
        customAnalyzer.KnowledgeSources.Add(ks);
    }
}

var operation = await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    analyzerId,
    customAnalyzer,
    allowReplace: true
);

ContentAnalyzer result = operation.Value;
Console.WriteLine($"Analyzer created: {analyzerId}");
Console.WriteLine($"  Description: {result.Description}");
Console.WriteLine($"  Base analyzer: {result.BaseAnalyzerId}");
Console.WriteLine($"  Fields: {result.FieldSchema?.Fields?.Count}");
```
