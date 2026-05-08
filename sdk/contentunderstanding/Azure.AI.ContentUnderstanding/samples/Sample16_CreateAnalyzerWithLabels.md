# Create an analyzer with labeled training data

This sample demonstrates how to build an analyzer that uses **labeled training data** stored in Azure Blob Storage. Labeled training data lets you teach the analyzer to extract custom fields from your own document layouts, beyond what prebuilt analyzers can do.

For an easier labeling workflow, use Azure AI Content Understanding Studio at <https://contentunderstanding.ai.azure.com/>.

## About labeled training data

A `LabeledDataKnowledgeSource` points the service at a folder of labeled documents. Each labeled document is a triplet:

- The original file (e.g., `receipt1.jpg`, `receipt1.pdf`).
- A corresponding `<filename>.labels.json` file with the labeled fields.
- An optional `<filename>.result.json` file with OCR results.

The service reads these files via a SAS URL and uses them to ground the analyzer's field schema during creation.

The repo ships labeled receipt training data at `tests/samples/SampleFiles/receipt_labels` (two labeled receipts; each receipt has three associated files).

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance.

For the **labeled training data** path, you'll also need:

- An **Azure Blob Storage** container (any region) where you can upload the labeled files.
- Either a pre-generated **container SAS URL** with Read + List permissions (Option A), or storage account access via `DefaultAzureCredential` so the sample can auto-upload and generate one (Option B).

If neither option is configured, the sample still runs and creates an analyzer **without** labeled training data — useful for exploring the API pattern.

## Creating a `ContentUnderstandingClient`

For full client setup details, see [Sample 00: Configure model deployment defaults][sample00]. Quick reference snippets:

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

## Option A: provide a pre-generated SAS URL

This is the recommended option for production and CI scenarios. Upload your labeled files manually once, then point the sample at the container.

**Manual upload steps:**

1. Create an Azure Blob Storage container (or use an existing one).
2. Upload the contents of `tests/samples/SampleFiles/receipt_labels` into the container. You may upload at the container root or into a subfolder (e.g., `receipt_labels/`).
3. Generate a **container SAS URL** with at least **List** and **Read** permissions. In the Azure Portal, search for "Shared access tokens" on your storage account; set an expiry, grant List + Read, then generate the SAS URL. *(Both `receipt_labels` and `receipt_labels/` work as prefix values — the SDK handles the trailing slash either way.)*
4. Set the environment variables (or the matching `appsettings.json` keys):

   ```
   CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL=https://<account>.blob.core.windows.net/<container>?sv=...&se=...
   # Only if you uploaded into a subfolder:
   CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX=receipt_labels/
   ```

## Option B: let the sample auto-upload

If you'd rather not generate a SAS URL by hand, the sample can upload the local label files for you and generate a User Delegation SAS URL via `DefaultAzureCredential`.

Set instead:

```
CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT=<your-storage-account>
CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER=<your-container>
# Optional, will be honored when the sample uploads:
CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX=receipt_labels/
```

The credential running the sample needs **Storage Blob Data Contributor** (or higher) **on the storage account** so it can upload blobs and call `GetUserDelegationKeyAsync` (an account-scoped operation).

> **Note:** If neither `CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL` nor the storage-account variables are set, the sample creates an analyzer **without** training data and prints a `DEMO MODE` warning to the console. This is the default behavior and requires no extra setup, but it does **not** exercise the labeled-data API path end-to-end.

## Build the receipt field schema

The schema mirrors what is labeled in the JSON files: `MerchantName`, an `Items` array (each item has `Quantity` / `Name` / `Price`), and `TotalPrice`.

```C# Snippet:ContentUnderstandingBuildReceiptFieldSchema
/// <summary>
/// Builds a <see cref="ContentFieldSchema"/> for receipt extraction
/// with MerchantName, Items (array of Quantity / Name / Price), and TotalPrice.
/// </summary>
static ContentFieldSchema BuildReceiptFieldSchema()
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

## Create the analyzer with labeled data

The full create flow resolves the SAS URL (Option A or Option B), builds a `LabeledDataKnowledgeSource`, attaches the field schema, and creates the analyzer:

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
    string? trainingDataPrefix = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX");

    // Option B: upload local label files and auto-generate a SAS URL
    if (string.IsNullOrEmpty(trainingDataSasUrl))
    {
        string? storageAccount = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT");
        string? container = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER");
        if (!string.IsNullOrEmpty(storageAccount) && !string.IsNullOrEmpty(container))
        {
            var credential = new Azure.Identity.DefaultAzureCredential();
            // Default to the bundled receipt files; override via the
            // CONTENTUNDERSTANDING_TRAINING_DATA_LOCAL_DIR env var if you have your own folder.
            string localLabelDir = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_LOCAL_DIR")
                ?? Path.Combine(AppContext.BaseDirectory, "receipt_labels");
            await UploadTrainingDataAsync(storageAccount, container, credential, localLabelDir, trainingDataPrefix);
            trainingDataSasUrl = await GenerateUserDelegationSasUrlAsync(storageAccount, container, credential);
        }
    }

    // Step 3: Create knowledge source from labeled data (if available)
    var knowledgeSources = new List<KnowledgeSource>();
    if (!string.IsNullOrEmpty(trainingDataSasUrl))
    {
        // fileListPath is required by the constructor; pass an empty string
        // when you don't want to filter by an explicit file list.
        var labeledSource = new LabeledDataKnowledgeSource(new Uri(trainingDataSasUrl), fileListPath: string.Empty);
        if (!string.IsNullOrEmpty(trainingDataPrefix))
        {
            labeledSource.Prefix = trainingDataPrefix;
        }
        knowledgeSources.Add(labeledSource);
    }
    else
    {
        Console.WriteLine("DEMO MODE: no training data configured. The analyzer will be created without labeled data.");
        Console.WriteLine("  Set CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL (Option A), or both");
        Console.WriteLine("  CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT and CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER (Option B),");
        Console.WriteLine("  to fully exercise the labeled-data API path.");
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

## Helper: upload labeled files

Used by Option B. Uploads every file in a local folder to the container (with optional virtual prefix) and overwrites blobs with the same name.

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
static async Task UploadTrainingDataAsync(
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

## Helper: generate a User Delegation SAS URL

Used by Option B. Generates a short-lived SAS for the container using the credential — no storage account key required.

```C# Snippet:ContentUnderstandingGenerateUserDelegationSas
/// <summary>
/// Generates a User Delegation SAS URL (Read + List) for an Azure Blob container.
/// Uses <see cref="TokenCredential"/> so no storage account key is needed.
/// </summary>
static async Task<string> GenerateUserDelegationSasUrlAsync(
    string storageAccountName,
    string containerName,
    TokenCredential credential)
{
    var blobServiceClient = new BlobServiceClient(
        new Uri($"https://{storageAccountName}.blob.core.windows.net"),
        credential);

    var userDelegationKey = (await blobServiceClient.GetUserDelegationKeyAsync(
        DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddHours(1),
        CancellationToken.None)).Value;

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

## Clean up

Delete the analyzer when you're done so it doesn't count toward your resource's analyzer quota:

```C# Snippet:ContentUnderstandingDeleteAnalyzerWithLabels
await client.DeleteAnalyzerAsync(analyzerId);
Console.WriteLine($"Analyzer '{analyzerId}' deleted.");
```

## Troubleshooting

| Error | Likely cause | Fix |
| --- | --- | --- |
| `403` / `AuthenticationFailed` when reading the SAS URL | SAS expired or missing **List**/**Read** permission. | Regenerate the SAS with both permissions and an unexpired expiry. |
| `BlobNotFound` during analyzer creation | Wrong prefix, files at the wrong layout, or files not uploaded. | Verify the container layout matches the `.labels.json` filenames; adjust `CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX` accordingly. |
| `DEMO MODE: no training data configured` printed at run time | Neither `CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL` nor the storage-account variables were set. | Configure Option A or Option B above to exercise the labeled-data path. |
| `Forbidden` when calling `GetUserDelegationKeyAsync` | Identity lacks **Storage Blob Data Contributor** on the storage account. | Grant the role and retry, or switch to Option A. |

## Next steps

- [Sample 00: Update model defaults][sample00] - Required first-time setup for any custom analyzer
- [Sample 04: Create analyzer][sample04] - Field schemas without training data
- [Sample 14: Copy analyzer][sample14] - Same-resource analyzer copy
- [Sample 15: Grant copy authorization][sample15] - Cross-resource analyzer copy

## Learn more

- [Content Understanding documentation][cu-docs]
- [Analyzer management][analyzer-docs]

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample14]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample14_CopyAnalyzer.md
[sample15]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample15_GrantCopyAuth.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[analyzer-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference
