# Create an analyzer with labeled training data

This sample demonstrates the API pattern for creating a custom analyzer with labeled training data from Azure Blob Storage. Labeled data improves extraction accuracy by providing annotated examples that teach the model how to identify and extract specific fields from your documents.

This sample is mainly to show the API pattern for creating an analyzer with labeled training data. For an easier labeling workflow, use [Content Understanding Studio][content-understanding-studio-portal], a web-based UI that provides a convenient way to label documents, manage training data, and build custom analyzers in the same interface.

## About labeled training data

Labeled training data consists of annotated sample documents that teach the model how to extract specific fields. Each labeled document includes:

| File | Description |
|---|---|
| `receipt1.jpg` | The source document (image, PDF, etc.) |
| `receipt1.jpg.labels.json` | Field labels and bounding box annotations |
| `receipt1.jpg.result.json` | Pre-computed OCR results (optional, speeds up training) |

When you create an analyzer with a `LabeledDataKnowledgeSource`, the service uses these annotations as in-context learning examples to improve field extraction quality. This is especially useful when:
- Prebuilt analyzers don't extract the fields you need
- Your documents have a specialized layout or terminology
- You need higher accuracy for specific fields

Labeled receipt data is available in this repo at `tests/samples/sample_files/receipt_labels/`.

## Preparing training data in Azure Blob Storage

The labeled data must be stored in an Azure Blob Storage container accessible via a SAS URL with **Read** and **List** permissions. You have two options to set this up:

### Option A: Manual upload (recommended for production)

1. Create an Azure Blob Storage container (or use an existing one).
2. Upload the contents of `tests/samples/sample_files/receipt_labels/` into the container.
   You may upload into the container root or a subfolder (e.g., `receipt_labels/`).
3. Generate a SAS (Shared Access Signature) URL for the container with at least **List** and
   **Read** permissions. In Azure Portal: Storage account → Containers → your container →
   Shared access token; set expiry and permissions, then generate the SAS URL.
4. Set `CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL` to the full SAS URL
   (e.g., `https://<account>.blob.core.windows.net/<container>?sv=...&se=...`).
5. If you uploaded into a subfolder, set `CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX` to that
   path (e.g., `receipt_labels/`). If files are at the container root, omit the prefix or
   leave it unset.

### Option B: Auto-upload (convenient for development)

Instead of uploading manually, provide the storage account name and container name. The sample
will upload local label files and generate a User Delegation SAS URL via `DefaultAzureCredential`.
This requires your credential to have **read/write/list** permissions on the storage account.

Set these environment variables:
- `CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT` — Storage account name
- `CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER` — Container name
- `CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX` — (Optional) Path prefix within the container

### Environment variables

| Variable | Required | Description |
|---|---|---|
| `CONTENTUNDERSTANDING_ENDPOINT` | Yes | Azure Content Understanding endpoint URL |
| `CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL` | No | SAS URL for the container with labeled data (Option A) |
| `CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT` | No | Storage account name for auto-upload (Option B) |
| `CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER` | No | Container name for auto-upload (Option B) |
| `CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX` | No | Path prefix within the container (e.g., `"receipt_labels/"`) |

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance.

## Creating a `ContentUnderstandingClient`

For full client setup details, see [Sample 00: Configure model deployment defaults][sample00]. Quick reference snippets are below—pick the one that matches the authentication method you plan to use.

```C# Snippet:CreateContentUnderstandingClient
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

```C# Snippet:CreateContentUnderstandingClientApiKey
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Create an analyzer with labeled training data

The sample follows four steps:

1. **Build field schema** — Define the fields you want to extract (e.g., MerchantName, Items, TotalPrice)
2. **Resolve training data** — Read the SAS URL from the environment, or auto-upload local files and generate one
3. **Create knowledge source** — Wrap the SAS URL in a `LabeledDataKnowledgeSource`
4. **Create the analyzer** — Pass the field schema and knowledge source to `CreateAnalyzerAsync`

```C# Snippet:ContentUnderstandingCreateAnalyzerWithLabels
string analyzerId = $"receipt_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

// Step 1: Build the receipt field schema
ContentFieldSchema fieldSchema = BuildReceiptFieldSchema();

// Step 2: Resolve training data SAS URL
// You can either provide a pre-generated SAS URL (Option A) or let the sample
// upload local label files and generate one automatically (Option B).
// See Sample16_CreateAnalyzerWithLabels.md for manual upload instructions.
// Option A: use a pre-generated SAS URL with Read + List permissions
string? trainingDataSasUrl = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL");

// Option B: upload local label files and auto-generate a SAS URL
if (string.IsNullOrEmpty(trainingDataSasUrl))
{
    string? storageAccount = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT");
    string? container = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER");
    if (!string.IsNullOrEmpty(storageAccount) && !string.IsNullOrEmpty(container))
    {
        var credential = new Azure.Identity.DefaultAzureCredential();
        string localLabelDir = "<path_to_local_receipt_labels_folder>";
        string? prefix = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX");
        await UploadTrainingDataAsync(storageAccount, container, credential, localLabelDir, prefix);
        trainingDataSasUrl = await GenerateUserDelegationSasUrlAsync(storageAccount, container, credential);
    }
}

string? trainingDataPrefix = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX");

// Step 3: Create knowledge source from labeled data (if available)
var knowledgeSources = new List<KnowledgeSource>();
if (!string.IsNullOrEmpty(trainingDataSasUrl))
{
    var labeledSource = new LabeledDataKnowledgeSource(new Uri(trainingDataSasUrl));
    if (!string.IsNullOrEmpty(trainingDataPrefix))
    {
        labeledSource.Prefix = trainingDataPrefix;
    }
    knowledgeSources.Add(labeledSource);
}

// Step 4: Create the analyzer
var customAnalyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Receipt analyzer with labeled training data",
    Config = new ContentAnalyzerConfig { EnableLayout = true, EnableOcr = true },
    FieldSchema = fieldSchema,
};
customAnalyzer.Models.Add("completion", "gpt-4.1");
customAnalyzer.Models.Add("embedding", "text-embedding-3-large");
foreach (var source in knowledgeSources)
{
    customAnalyzer.KnowledgeSources.Add(source);
}

var operation = await client.CreateAnalyzerAsync(
    WaitUntil.Completed, analyzerId, customAnalyzer, allowReplace: true);

ContentAnalyzer result = operation.Value;
Console.WriteLine($"Analyzer created: {analyzerId}");
Console.WriteLine($"  Description: {result.Description}");
Console.WriteLine($"  Base analyzer: {result.BaseAnalyzerId}");
Console.WriteLine($"  Fields: {result.FieldSchema?.Fields?.Count ?? 0}");
Console.WriteLine($"  Knowledge srcs: {result.KnowledgeSources?.Count ?? 0}");
```

### Helper: Build receipt field schema

This helper defines a `ContentFieldSchema` for receipt extraction with three top-level fields:
- `MerchantName` (string, extract) — Name of the merchant
- `Items` (array of objects, generate) — Each item has `Quantity`, `Name`, and `Price`
- `TotalPrice` (string, extract) — Total amount

```C# Snippet:ContentUnderstandingBuildReceiptFieldSchema
/// <summary>
/// Builds a <see cref="ContentFieldSchema"/> for receipt extraction
/// with MerchantName, Items (array of Quantity / Name / Price), and TotalPrice.
/// </summary>
private static ContentFieldSchema BuildReceiptFieldSchema()
{
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

    return new ContentFieldSchema(
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
            ["TotalPrice"] = new ContentFieldDefinition
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
}
```

### Helper: Upload local training data to Blob Storage

Used by Option B to upload label files from a local directory to an Azure Blob container. Requires a credential with **read/write/list** permissions on the storage account. The container is created if it does not already exist.

```C# Snippet:ContentUnderstandingUploadTrainingData
/// <summary>
/// Uploads local training data files (images, .labels.json, .result.json) to an
/// Azure Blob container. Existing blobs with the same name are overwritten.
/// </summary>
/// <param name="storageAccountName">Storage account name.</param>
/// <param name="containerName">Container name (created if it does not exist).</param>
/// <param name="credential">Credential with write access to the container.</param>
/// <param name="localDirectory">Local folder containing the label files.</param>
/// <param name="prefix">
/// Optional blob prefix (virtual folder) to prepend, e.g. "receipt_labels/".
/// </param>
private static async Task UploadTrainingDataAsync(
    string storageAccountName,
    string containerName,
    TokenCredential credential,
    string localDirectory,
    string? prefix = null)
{
    var containerClient = new BlobContainerClient(
        new Uri($"https://{storageAccountName}.blob.core.windows.net/{containerName}"),
        credential);

    await containerClient.CreateIfNotExistsAsync();

    foreach (string filePath in Directory.GetFiles(localDirectory))
    {
        string blobName = string.IsNullOrEmpty(prefix)
            ? Path.GetFileName(filePath)
            : prefix!.TrimEnd('/') + "/" + Path.GetFileName(filePath);

        Console.WriteLine($"Uploading {Path.GetFileName(filePath)} -> {blobName}");
        await containerClient.GetBlobClient(blobName)
            .UploadAsync(filePath, overwrite: true);
    }
}
```

### Helper: Generate User Delegation SAS URL

Used by Option B to generate a container SAS URL with **Read** and **List** permissions using a User Delegation Key. This approach uses `TokenCredential` (e.g., `DefaultAzureCredential`) so no storage account key is needed.

```C# Snippet:ContentUnderstandingGenerateUserDelegationSas
/// <summary>
/// Generates a User Delegation SAS URL (Read + List) for an Azure Blob container.
/// Uses <see cref="TokenCredential"/> so no storage account key is needed.
/// </summary>
private static async Task<string> GenerateUserDelegationSasUrlAsync(
    string storageAccountName,
    string containerName,
    TokenCredential credential)
{
    var blobServiceClient = new BlobServiceClient(
        new Uri($"https://{storageAccountName}.blob.core.windows.net"),
        credential);

    var userDelegationKey = (await blobServiceClient.GetUserDelegationKeyAsync(
        DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddHours(1))).Value;

    var sasBuilder = new BlobSasBuilder
    {
        BlobContainerName = containerName,
        Resource = "c",
        ExpiresOn = DateTimeOffset.UtcNow.AddHours(1),
    };
    sasBuilder.SetPermissions(BlobContainerSasPermissions.Read | BlobContainerSasPermissions.List);

    string sasToken = sasBuilder.ToSasQueryParameters(userDelegationKey, storageAccountName).ToString();
    return $"https://{storageAccountName}.blob.core.windows.net/{containerName}?{sasToken}";
}
```

## Delete the analyzer (optional)

**Note:** In production code, you typically keep analyzers and reuse them for multiple analyses. Deletion is mainly useful for testing and development cleanup.

```C# Snippet:ContentUnderstandingDeleteAnalyzerWithLabels
await client.DeleteAnalyzerAsync(analyzerId);
Console.WriteLine($"Analyzer '{analyzerId}' deleted.");
```

## Next steps

- [Sample 04: Create a custom analyzer][sample04] — Learn how to create custom analyzers without labeled data
- [Sample 06: Get analyzer information][sample06] — Learn how to retrieve analyzer details
- [Sample 07: List analyzers][sample07] — Learn how to list all analyzers

## Learn more

- [Content Understanding documentation][cu-docs]
- [Create and improve your custom analyzer in Content Understanding Studio][content-understanding-studio-docs] — Learn how to create custom analyzers using the web-based UI with testing and in-context learning capabilities
- [Content Understanding Studio Portal][content-understanding-studio-portal] — Access the web-based UI to label documents and manage custom analyzers
- [Analyzer reference documentation][analyzer-reference-docs] — Complete reference for analyzer configuration, field schemas, and knowledge sources

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample06]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample06_GetAnalyzer.md
[sample07]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample07_ListAnalyzers.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[content-understanding-studio-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/how-to/customize-analyzer-content-understanding-studio?tabs=portal
[content-understanding-studio-portal]: https://contentunderstanding.ai.azure.com/home
[analyzer-reference-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference#analyzer-configuration-structure
