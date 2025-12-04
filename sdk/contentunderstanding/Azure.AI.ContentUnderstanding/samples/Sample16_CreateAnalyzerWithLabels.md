# Create Analyzer with Labeled Training Data

This sample demonstrates how to create a custom analyzer using labeled training data to improve extraction accuracy. Labeled data consists of document samples that have been manually annotated with expected field values, which helps the analyzer learn from examples and better recognize patterns in similar documents.

## Prerequisites

Before running this sample, ensure you have:

1. **Azure Content Understanding Resource**: Set up an Azure AI Content Understanding resource
2. **Model Deployments**: Deploy required models (GPT-4.1 and text-embedding-3-large)
3. **Azure Blob Storage**: An Azure Storage Account with a blob container to store training data
4. **Training Data**: Documents with corresponding `.labels.json` and `.result.json` files

### Setting up Training Data Storage

You have two options for configuring access to your Azure Blob Storage:

#### Option 1: Using Storage Account and Container Name (Recommended)

Set the following environment variables, and the SDK will automatically generate a SAS token using Azure Identity:

```bash
# Storage account and container (SAS token will be auto-generated)
export TRAINING_DATA_STORAGE_ACCOUNT="mmigithubsamplesstorage"
export TRAINING_DATA_CONTAINER_NAME="mmi-github-samples-blob-container"
export TRAINING_DATA_PATH="document_training/"  # Optional, defaults to "training_data/"
```

This approach requires you to be authenticated with Azure (e.g., via `az login` or DefaultAzureCredential), and you must have appropriate permissions on the storage account.

#### Option 2: Using Pre-generated SAS URL

Alternatively, you can provide a pre-generated SAS URL:

```bash
# Pre-generated SAS URL
export TRAINING_DATA_SAS_URL="https://mystorageaccount.blob.core.windows.net/mycontainer?sv=2023-01-03&ss=b&srt=co&sp=racwdl&se=..."
export TRAINING_DATA_PATH="document_training/"  # Optional
```

**Important**: The SAS token must include the following permissions:
- **Read** (r): To read existing blobs
- **Add** (a): To add new blobs (append operations)
- **Create** (c): **Required** to create new blobs when uploading training files
- **Write** (w): To write to blobs
- **Delete** (d): To delete blobs if needed
- **List** (l): To enumerate blobs in the container

The full permission string should be: `sp=racwdl`

### Training Data Structure

Each training document requires three files:

1. **Original Document**: The source file (PDF, image, etc.)
   - Example: `receipt.jpg`

2. **Labels File**: Contains the manually annotated field values
   - Example: `receipt.jpg.labels.json`
   - Structure:
     ```json
     {
       "$schema": "https://schema.ai.azure.com/mmi/2024-12-01-preview/labels.json",
       "fieldLabels": {
         "MerchantName": {
           "type": "string",
           "valueString": "Contoso"
         },
         "TotalPrice": {
           "type": "string",
           "valueString": "$14.50"
         }
       }
     }
     ```

3. **OCR Results File**: Contains the OCR analysis results from `prebuilt-documentSearch`
   - Example: `receipt.jpg.result.json`

## Usage

```C# Snippet:ContentUnderstandingCreateAnalyzerWithLabels
// Generate a unique analyzer ID
string analyzerId = $"receipt_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

// Step 1: Upload training data to Azure Blob Storage
// Get training data configuration from environment
string trainingDataSasUrl = Environment.GetEnvironmentVariable("TRAINING_DATA_SAS_URL") 
    ?? throw new InvalidOperationException("TRAINING_DATA_SAS_URL environment variable is required");
string trainingDataPath = Environment.GetEnvironmentVariable("TRAINING_DATA_PATH") ?? "training_data/";

// Ensure path ends with /
if (!string.IsNullOrEmpty(trainingDataPath) && !trainingDataPath.EndsWith("/"))
{
    trainingDataPath += "/";
}

// Upload training documents with labels and OCR results
string trainingDocsFolder = Path.Combine(
    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? string.Empty,
    "TestData",
    "document_training");

if (Directory.Exists(trainingDocsFolder))
{
    var containerClient = new BlobContainerClient(new Uri(trainingDataSasUrl));
    var files = Directory.GetFiles(trainingDocsFolder);

    foreach (var file in files)
    {
        string fileName = Path.GetFileName(file);

        // Upload document, labels.json, and result.json files
        if (!fileName.EndsWith(".labels.json") && !fileName.EndsWith(".result.json"))
        {
            // Upload the main document
            string blobPath = trainingDataPath + fileName;
            var blobClient = containerClient.GetBlobClient(blobPath);

            using (var fileStream = File.OpenRead(file))
            {
                await blobClient.UploadAsync(fileStream, overwrite: true);
            }

            // Upload associated labels.json
            string labelsFile = file + ".labels.json";
            if (File.Exists(labelsFile))
            {
                string labelsBlobPath = trainingDataPath + fileName + ".labels.json";
                var labelsBlobClient = containerClient.GetBlobClient(labelsBlobPath);
                using (var labelsStream = File.OpenRead(labelsFile))
                {
                    await labelsBlobClient.UploadAsync(labelsStream, overwrite: true);
                }
            }

            // Upload associated result.json
            string resultFile = file + ".result.json";
            if (File.Exists(resultFile))
            {
                string resultBlobPath = trainingDataPath + fileName + ".result.json";
                var resultBlobClient = containerClient.GetBlobClient(resultBlobPath);
                using (var resultStream = File.OpenRead(resultFile))
                {
                    await resultBlobClient.UploadAsync(resultStream, overwrite: true);
                }
            }
        }
    }
    Console.WriteLine("Training data uploaded to blob storage successfully.");
}

// Step 2: Define field schema for receipt extraction
// Create the Items array item definition (object with properties)
var itemDefinition = new ContentFieldDefinition
{
    Type = ContentFieldType.Object,
    Method = GenerationMethod.Extract,
    Description = "Individual item details"
};
itemDefinition.Properties.Add("Quantity", new ContentFieldDefinition
{
    Type = ContentFieldType.String,
    Method = GenerationMethod.Extract,
    Description = "Quantity of the item"
});
itemDefinition.Properties.Add("Name", new ContentFieldDefinition
{
    Type = ContentFieldType.String,
    Method = GenerationMethod.Extract,
    Description = "Name of the item"
});
itemDefinition.Properties.Add("Price", new ContentFieldDefinition
{
    Type = ContentFieldType.String,
    Method = GenerationMethod.Extract,
    Description = "Price of the item"
});

var fieldSchema = new ContentFieldSchema(
    new Dictionary<string, ContentFieldDefinition>
    {
        ["MerchantName"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.String,
            Method = GenerationMethod.Extract,
            Description = "Name of the merchant"
        },
        ["Items"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.Array,
            Method = GenerationMethod.Generate,
            Description = "List of items purchased",
            ItemDefinition = itemDefinition
        },
        ["TotalPrice"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.String,
            Method = GenerationMethod.Extract,
            Description = "Total price on the receipt"
        }
    })
{
    Name = "receipt_schema",
    Description = "Schema for receipt extraction with labeled training data"
};

// Step 3: Configure knowledge sources with labeled data
var knowledgeSource = new LabeledDataKnowledgeSource(new Uri(trainingDataSasUrl), string.Empty)
{
    Prefix = trainingDataPath
};

// Step 4: Create analyzer configuration
var config = new ContentAnalyzerConfig
{
    EnableFormula = false,
    EnableLayout = true,
    EnableOcr = true,
    EstimateFieldSourceAndConfidence = true,
    ReturnDetails = true
};

// Step 5: Create the custom analyzer with knowledge sources
var customAnalyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Receipt analyzer trained with labeled data",
    Config = config,
    FieldSchema = fieldSchema
};

// Add knowledge source
customAnalyzer.KnowledgeSources.Add(knowledgeSource);

// Add model mappings (required when using knowledge sources)
customAnalyzer.Models.Add("completion", "gpt-4.1");
customAnalyzer.Models.Add("embedding", "text-embedding-3-large");

// Create the analyzer
var operation = await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    analyzerId,
    customAnalyzer,
    allowReplace: true);

ContentAnalyzer result = operation.Value;
Console.WriteLine($"Analyzer '{analyzerId}' created successfully with labeled training data!");
```

## Cleanup

After testing, you can delete the analyzer:

```C# Snippet:ContentUnderstandingDeleteAnalyzerWithLabels
// Clean up: delete the analyzer (for testing purposes only)
// In production, trained analyzers are typically kept and reused
await client.DeleteAnalyzerAsync(analyzerId);
Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
```

## Key Concepts

### What is Labeled Data?

Labeled data consists of document samples that have been manually annotated with expected field values. This training data helps the analyzer:

- **Learn from Examples**: Understand how to extract specific fields from similar documents
- **Improve Accuracy**: Better recognize patterns and variations in document formats
- **Handle Edge Cases**: Learn to handle unusual or complex document layouts

### Knowledge Sources

Knowledge sources provide additional context to improve extraction accuracy. When using labeled data:

- **Kind**: Set to `KnowledgeSourceKind.LabeledData`
- **ContainerUrl**: Azure Blob Storage SAS URL containing training files
- **Prefix**: Folder path within the container where training data is stored

### When to Use Training Data

Use labeled training data when:

- You have domain-specific documents that prebuilt analyzers don't handle well
- You need higher accuracy for specific field extractions
- You have a collection of labeled documents ready for training
- You want to improve extraction for custom document types

### Model Requirements

When using knowledge sources with labeled data:

- **Completion Model**: Required for generating and extracting field values (e.g., "gpt-4.1")
- **Embedding Model**: Required for semantic search and matching (e.g., "text-embedding-3-large")

## Related Samples

- [Sample04_CreateAnalyzer](Sample04_CreateAnalyzer.md) - Create a basic custom analyzer
- [Sample06_GetAnalyzer](Sample06_GetAnalyzer.md) - Retrieve analyzer details
- [Sample07_ListAnalyzers](Sample07_ListAnalyzers.md) - List all analyzers

## Additional Resources

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [Analyzer Training Concepts](https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-training)
- [How to Label Training Data](https://learn.microsoft.com/azure/ai-services/content-understanding/how-to/training-data)
