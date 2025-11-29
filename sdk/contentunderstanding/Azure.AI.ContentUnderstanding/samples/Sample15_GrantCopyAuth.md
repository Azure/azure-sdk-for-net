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

> **Note:** This snippet requires `using Azure.Identity;` for `DefaultAzureCredential`.

```C# Snippet:ContentUnderstandingGrantCopyAuth
// Get source endpoint from configuration
// Note: configuration is already loaded in Main method
string sourceEndpoint = "https://source-resource.services.ai.azure.com/";
string? sourceKey = "optional-source-api-key"; // Set to null to use DefaultAzureCredential

// Create source client
ContentUnderstandingClient sourceClient = !string.IsNullOrEmpty(sourceKey)
    ? new ContentUnderstandingClient(new Uri(sourceEndpoint), new AzureKeyCredential(sourceKey))
    : new ContentUnderstandingClient(new Uri(sourceEndpoint), new DefaultAzureCredential());

// Source analyzer ID (must already exist in the source resource)
string sourceAnalyzerId = "my_source_analyzer_id_in_the_source_resource";
// Target analyzer ID (will be created during copy)
string targetAnalyzerId = "my_target_analyzer_id_in_the_target_resource";

// Get source and target resource information from configuration
string sourceResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{name}";
string sourceRegion = "eastus"; // Replace with actual source region
string targetEndpoint = "https://target-resource.services.ai.azure.com/";
string targetResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{name}";
string targetRegion = "westus"; // Replace with actual target region
string? targetKey = "optional-target-api-key"; // Set to null to use DefaultAzureCredential

// Create target client
ContentUnderstandingClient targetClient = !string.IsNullOrEmpty(targetKey)
    ? new ContentUnderstandingClient(new Uri(targetEndpoint), new AzureKeyCredential(targetKey))
    : new ContentUnderstandingClient(new Uri(targetEndpoint), new DefaultAzureCredential());

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

Console.WriteLine("📋 Source Analyzer Creation Verification (For Cross-Resource Copy):");

// Verify analyzer IDs
Assert.IsNotNull(sourceAnalyzerId, "Source analyzer ID should not be null");
Assert.IsFalse(string.IsNullOrWhiteSpace(sourceAnalyzerId), "Source analyzer ID should not be empty");
Assert.IsNotNull(targetAnalyzerId, "Target analyzer ID should not be null");
Assert.IsFalse(string.IsNullOrWhiteSpace(targetAnalyzerId), "Target analyzer ID should not be empty");
Assert.AreNotEqual(sourceAnalyzerId, targetAnalyzerId, "Source and target IDs should be different");
Console.WriteLine($"Source analyzer ID: {sourceAnalyzerId}");
Console.WriteLine($"Target analyzer ID: {targetAnalyzerId}");

// Verify resource information
Assert.IsNotNull(sourceResourceId, "Source resource ID should not be null");
Assert.IsFalse(string.IsNullOrWhiteSpace(sourceResourceId), "Source resource ID should not be empty");
Assert.IsNotNull(sourceRegion, "Source region should not be null");
Assert.IsFalse(string.IsNullOrWhiteSpace(sourceRegion), "Source region should not be empty");
Assert.IsNotNull(targetResourceId, "Target resource ID should not be null");
Assert.IsFalse(string.IsNullOrWhiteSpace(targetResourceId), "Target resource ID should not be empty");
Assert.IsNotNull(targetRegion, "Target region should not be null");
Assert.IsFalse(string.IsNullOrWhiteSpace(targetRegion), "Target region should not be empty");
Assert.IsNotNull(targetEndpoint, "Target endpoint should not be null");
Assert.IsFalse(string.IsNullOrWhiteSpace(targetEndpoint), "Target endpoint should not be empty");

Console.WriteLine($"Source resource: {sourceResourceId}");
Console.WriteLine($"Source region: {sourceRegion}");
Console.WriteLine($"Target resource: {targetResourceId}");
Console.WriteLine($"Target region: {targetRegion}");
Console.WriteLine($"Target endpoint: {targetEndpoint}");

// Verify clients
Assert.IsNotNull(sourceClient, "Source client should not be null");
Assert.IsNotNull(targetClient, "Target client should not be null");
Console.WriteLine("Source and target clients created");

// Verify source analyzer configuration
Assert.IsNotNull(sourceConfig, "Source config should not be null");
Assert.AreEqual(false, sourceConfig.EnableFormula, "EnableFormula should be false");
Assert.AreEqual(true, sourceConfig.EnableLayout, "EnableLayout should be true");
Assert.AreEqual(true, sourceConfig.EnableOcr, "EnableOcr should be true");
Assert.AreEqual(true, sourceConfig.EstimateFieldSourceAndConfidence, "EstimateFieldSourceAndConfidence should be true");
Assert.AreEqual(true, sourceConfig.ReturnDetails, "ReturnDetails should be true");
Console.WriteLine("Source config verified");

// Verify source field schema
Assert.IsNotNull(sourceFieldSchema, "Source field schema should not be null");
Assert.AreEqual("company_schema", sourceFieldSchema.Name, "Field schema name should match");
Assert.AreEqual("Schema for extracting company information", sourceFieldSchema.Description, "Field schema description should match");
Assert.AreEqual(2, sourceFieldSchema.Fields.Count, "Should have 2 fields");
Assert.IsTrue(sourceFieldSchema.Fields.ContainsKey("company_name"), "Should contain company_name field");
Assert.IsTrue(sourceFieldSchema.Fields.ContainsKey("total_amount"), "Should contain total_amount field");
Console.WriteLine($"Source field schema verified: {sourceFieldSchema.Name} ({sourceFieldSchema.Fields.Count} fields)");

// Verify source analyzer object
Assert.IsNotNull(sourceAnalyzer, "Source analyzer object should not be null");
Assert.AreEqual("prebuilt-document", sourceAnalyzer.BaseAnalyzerId, "Base analyzer ID should match");
Assert.AreEqual("Source analyzer for cross-resource copying", sourceAnalyzer.Description, "Description should match");
Assert.IsTrue(sourceAnalyzer.Models.ContainsKey("completion"), "Should have completion model");
Assert.AreEqual("gpt-4.1", sourceAnalyzer.Models["completion"], "Completion model should be gpt-4.1");
Console.WriteLine("Source analyzer object verified");

// Verify create operation
Assert.IsNotNull(createOperation, "Create operation should not be null");
Assert.IsTrue(createOperation.HasCompleted, "Operation should be completed");
Assert.IsTrue(createOperation.HasValue, "Operation should have a value");
Assert.IsNotNull(createOperation.GetRawResponse(), "Create operation should have a raw response");
Assert.IsTrue(createOperation.GetRawResponse().Status >= 200 && createOperation.GetRawResponse().Status < 300,
    $"Response status should be successful, but was {createOperation.GetRawResponse().Status}");
Console.WriteLine($"Create operation status: {createOperation.GetRawResponse().Status}");

// Verify source result
Assert.IsNotNull(sourceResult, "Source analyzer result should not be null");
Assert.AreEqual("prebuilt-document", sourceResult.BaseAnalyzerId, "Base analyzer ID should match");
Assert.AreEqual("Source analyzer for cross-resource copying", sourceResult.Description, "Description should match");
Assert.IsNotNull(sourceResult.Config, "Config should not be null");
Assert.IsNotNull(sourceResult.FieldSchema, "Field schema should not be null");
Assert.AreEqual(2, sourceResult.FieldSchema.Fields.Count, "Should have 2 fields");
Assert.IsNotNull(sourceResult.Models, "Models should not be null");
Assert.IsTrue(sourceResult.Models.ContainsKey("completion"), "Should have completion model");
Console.WriteLine($"Source analyzer created: '{sourceAnalyzerId}'");

Console.WriteLine($"\nSource analyzer creation completed:");
Console.WriteLine($"  ID: {sourceAnalyzerId}");
Console.WriteLine($"  Base: {sourceResult.BaseAnalyzerId}");
Console.WriteLine($"  Fields: {sourceResult.FieldSchema.Fields.Count}");
Console.WriteLine($"  Models: {sourceResult.Models.Count}");
Console.WriteLine($"  Ready for cross-resource copy");

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

    Console.WriteLine("\n🔐 Copy Authorization Grant Verification:");

    // Verify copyAuth response
    Assert.IsNotNull(copyAuth, "Copy authorization response should not be null");
    Assert.IsTrue(copyAuth.HasValue, "Copy authorization should have a value");
    Assert.IsNotNull(copyAuth.Value, "Copy authorization value should not be null");
    Console.WriteLine("Copy authorization response received");

    // Verify raw response
    var copyAuthRawResponse = copyAuth.GetRawResponse();
    Assert.IsNotNull(copyAuthRawResponse, "Raw response should not be null");
    Assert.IsTrue(copyAuthRawResponse.Status >= 200 && copyAuthRawResponse.Status < 300,
        $"Response status should be successful, but was {copyAuthRawResponse.Status}");
    Console.WriteLine($"Response status: {copyAuthRawResponse.Status}");

    // Verify target resource ID
    Assert.IsNotNull(copyAuth.Value.TargetAzureResourceId, "Target Azure resource ID should not be null");
    Assert.IsFalse(string.IsNullOrWhiteSpace(copyAuth.Value.TargetAzureResourceId),
        "Target Azure resource ID should not be empty");
    Assert.AreEqual(targetResourceId, copyAuth.Value.TargetAzureResourceId,
        $"Target resource ID should match, but got '{copyAuth.Value.TargetAzureResourceId}' instead of '{targetResourceId}'");
    Console.WriteLine($"Target Azure Resource ID verified: {copyAuth.Value.TargetAzureResourceId}");
    // Note: TargetRegion is not available in the CopyAuthorization response
    // The target region is tracked separately in the targetRegion variable
    Console.WriteLine($"Target region (tracked): {targetRegion}");

    // Verify expiration time
    var expiresAt = copyAuth.Value.ExpiresAt;
    var now = DateTimeOffset.UtcNow;

    Assert.IsTrue(expiresAt > now,
        $"Expiration time should be in the future, but expires at {expiresAt} (now: {now})");

    // Calculate time until expiration
    var timeUntilExpiration = expiresAt - now;
    Assert.IsTrue(timeUntilExpiration.TotalMinutes > 0,
        "Should have positive time until expiration");

    Console.WriteLine($"Expiration time verified: {expiresAt:yyyy-MM-dd HH:mm:ss} UTC");
    Console.WriteLine($"  Time until expiration: {timeUntilExpiration.TotalMinutes:F2} minutes");

    // Verify expiration is reasonable (typically several hours)
    if (timeUntilExpiration.TotalHours < 24)
    {
        Console.WriteLine($"  ⚠️ Note: Authorization expires in less than 24 hours");
    }

    // Summary
    Console.WriteLine($"\nCopy authorization granted successfully:");
    Console.WriteLine($"  Source analyzer: {sourceAnalyzerId}");
    Console.WriteLine($"  Target resource: {copyAuth.Value.TargetAzureResourceId}");
    Console.WriteLine($"\nCopy authorization granted successfully:");
    Console.WriteLine($"  Source analyzer: {sourceAnalyzerId}");
    Console.WriteLine($"  Target resource: {copyAuth.Value.TargetAzureResourceId}");
    Console.WriteLine($"  Target region: {targetRegion}");
    Console.WriteLine($"  Expires: {copyAuth.Value.ExpiresAt:yyyy-MM-dd HH:mm:ss} UTC");
    Console.WriteLine($"  Authorization ready for cross-resource copy");
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

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_ConfigureDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample09]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample09_DeleteAnalyzer.md
[sample14]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample14_CopyAnalyzer.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[analyzer-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference

