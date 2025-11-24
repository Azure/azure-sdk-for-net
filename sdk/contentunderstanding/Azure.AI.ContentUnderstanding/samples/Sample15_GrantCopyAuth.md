# Grant copy authorization and copy analyzer

This sample demonstrates how to grant copy authorization and copy an analyzer from a source resource to a target resource (cross-resource copying). This is useful for copying analyzers between different Azure resources or subscriptions.

## Before you begin

This sample builds on concepts introduced in previous samples:
- [Sample 04: Create a custom analyzer][sample04] - Understanding analyzer creation
- [Sample 14: Copy analyzer][sample14] - Understanding same-resource copying

## About cross-resource copying

The `GrantCopyAuthorization` and `CopyAnalyzer` APIs allow you to copy an analyzer between different Azure resources:

- **Cross-resource copy**: Copies an analyzer from one Azure resource to another
- **Authorization required**: You must grant copy authorization before copying
- **Use cases**: Cross-subscription copying, resource migration, multi-region deployment

**Note**: For same-resource copying (copying within the same Azure resource), use the [CopyAnalyzer sample][sample14] instead.

## Prerequisites

To get started you'll need:
- **Source Microsoft Foundry resource** with model deployments configured
- **Target Microsoft Foundry resource** with model deployments configured
- Both resources require 'Cognitive Services User' role for cross-resource copying
- See [Sample 00][sample00] for setup instructions

## Configuration

This sample requires additional environment variables for the source resource (that contains the source analyzers) and the target resource (that the analyzers will be copied into):

```json
{
  "AZURE_CONTENT_UNDERSTANDING_ENDPOINT": "https://source-resource.services.ai.azure.com/",
  "AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{name}",
  "AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION": "eastus",
  "AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT": "https://target-resource.services.ai.azure.com/",
  "AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{name}",
  "AZURE_CONTENT_UNDERSTANDING_TARGET_REGION": "westus",
  "AZURE_CONTENT_UNDERSTANDING_KEY": "optional-source-api-key",
  "AZURE_CONTENT_UNDERSTANDING_TARGET_KEY": "optional-target-api-key"
}
```

**Note**: API keys (`AZURE_CONTENT_UNDERSTANDING_KEY` and `AZURE_CONTENT_UNDERSTANDING_TARGET_KEY`) are only required when `DefaultAzureCredential` is not used. If you're using Azure authentication (e.g., `az login` or managed identity), you can omit the keys and the sample will use `DefaultAzureCredential` for authentication.

## Creating a `ContentUnderstandingClient`

See [Sample 01][sample01] for authentication examples using `DefaultAzureCredential` or API key.

## Grant copy authorization and copy analyzer

Create a source analyzer, grant copy authorization, and copy it to a target resource:

```C# Snippet:ContentUnderstandingGrantCopyAuth
// Generate unique analyzer IDs
string sourceAnalyzerId = $"my_analyzer_source_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
string targetAnalyzerId = $"my_analyzer_target_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

// Get source and target resource information from configuration
string sourceResourceId = Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID") ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID is required");
string sourceRegion = Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION") ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION is required");
string targetEndpoint = Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT") ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT is required");
string targetResourceId = Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID") ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID is required");
string targetRegion = Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_TARGET_REGION") ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_TARGET_REGION is required");
string? targetKey = Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_TARGET_KEY");

// Create target client
var targetClientOptions = new ContentUnderstandingClientOptions();
ContentUnderstandingClient targetClient = !string.IsNullOrEmpty(targetKey)
    ? new ContentUnderstandingClient(new Uri(targetEndpoint), new AzureKeyCredential(targetKey), targetClientOptions)
    : new ContentUnderstandingClient(new Uri(targetEndpoint), new DefaultAzureCredential(), targetClientOptions);

// Step 1: Create the source analyzer
var sourceConfig = new ContentAnalyzerConfig
{
    EnableFormula = false,
    EnableLayout = true,
    EnableOcr = true,
    EstimateFieldSourceAndConfidence = true,
    ReturnDetails = true
};

var sourceFieldSchema = new ContentFieldSchema(
    new Dictionary<string, ContentFieldDefinition>
    {
        ["company_name"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.String,
            Method = GenerationMethod.Extract,
            Description = "Name of the company"
        },
        ["total_amount"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.Number,
            Method = GenerationMethod.Extract,
            Description = "Total amount on the document"
        }
    })
{
    Name = "company_schema",
    Description = "Schema for extracting company information"
};

var sourceAnalyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Source analyzer for cross-resource copying",
    Config = sourceConfig,
    FieldSchema = sourceFieldSchema
};
sourceAnalyzer.Models.Add("completion", "gpt-4.1");

var createOperation = await sourceClient.CreateAnalyzerAsync(
    WaitUntil.Completed,
    sourceAnalyzerId,
    sourceAnalyzer);
var sourceResult = createOperation.Value;
Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' created successfully!");

try
{
    // Step 2: Grant copy authorization
    var copyAuth = await sourceClient.GrantCopyAuthorizationAsync(
        sourceAnalyzerId,
        targetResourceId,
        targetRegion);

    Console.WriteLine("Copy authorization granted successfully!");
    Console.WriteLine($"  Target Azure Resource ID: {copyAuth.Value.TargetAzureResourceId}");
    Console.WriteLine($"  Target Region: {targetRegion}");
    Console.WriteLine($"  Expires at: {copyAuth.Value.ExpiresAt}");

    // Step 3: Copy the analyzer to target resource
    var copyOperation = await targetClient.CopyAnalyzerAsync(
        WaitUntil.Completed,
        targetAnalyzerId,
        sourceAnalyzerId,
        sourceResourceId,
        sourceRegion);

    var targetResult = copyOperation.Value;
    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' copied successfully to target resource!");
    Console.WriteLine($"Target analyzer description: {targetResult.Description}");
}
finally
{
    // Clean up: delete both analyzers
    try
    {
        await sourceClient.DeleteAnalyzerAsync(sourceAnalyzerId);
        Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully.");
    }
    catch
    {
        // Ignore cleanup errors
    }

    try
    {
        await targetClient.DeleteAnalyzerAsync(targetAnalyzerId);
        Console.WriteLine($"Target analyzer '{targetAnalyzerId}' deleted successfully.");
    }
    catch
    {
        // Ignore cleanup errors
    }
}
```

## When to use cross-resource copying

Use cross-resource copying when you need to:
- **Copy between subscriptions**: Move analyzers between different Azure subscriptions
- **Multi-region deployment**: Deploy the same analyzer to multiple regions
- **Resource migration**: Migrate analyzers from one resource to another
- **Environment promotion**: Promote analyzers from development to production across resources

**Note**: Both source and target resources require 'Cognitive Services User' role for cross-resource copying. The copy authorization expires after a certain time, so copy operations should be performed soon after granting authorization.

## Next Steps

- [Sample 14: Copy analyzer][sample14] - Learn about same-resource copying
- [Sample 04: Create analyzer][sample04] - Learn more about creating custom analyzers
- [Sample 09: Delete analyzer][sample09] - Learn about analyzer lifecycle management

## Learn More

- [Content Understanding Documentation][cu-docs]
- [Analyzer Management][analyzer-docs] - Learn about managing analyzers

[sample00]: Sample00_ConfigureDefaults.md
[sample01]: Sample01_AnalyzeBinary.md
[sample04]: Sample04_CreateAnalyzer.md
[sample09]: Sample09_DeleteAnalyzer.md
[sample14]: Sample14_CopyAnalyzer.md
[cu-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/
[analyzer-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/concepts/analyzer-reference

