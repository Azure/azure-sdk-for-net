# Grant copy authorization and copy analyzer

This sample demonstrates how to grant copy authorization and copy an analyzer from a source Microsoft Foundry resource to a target Microsoft Foundry resource (cross-resource copying). This is useful for copying analyzers between different Azure resources or subscriptions.

## About cross-resource copying

The `GrantCopyAuthorization` and `CopyAnalyzer` APIs allow you to copy an analyzer between different Azure resources:

- **Cross-resource copy**: Copies an analyzer from one Azure resource to another
- **Authorization required**: You must grant copy authorization before copying

**When to use cross-resource copying**: Use cross-resource copying when you need to:
- **Copy between subscriptions**: Move analyzers between different Azure subscriptions
- **Multi-region deployment**: Deploy the same analyzer to multiple regions
- **Resource migration**: Migrate analyzers from one resource to another
- **Environment promotion**: Promote analyzers from development to production across resources

**Note**: For same-resource copying (copying within the same Microsoft Foundry resource), use the [CopyAnalyzer sample][sample14] instead.

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance. For this cross-resource scenario, you'll also need:
- **Source Microsoft Foundry resource** with model deployments configured
- **Target Microsoft Foundry resource** with model deployments configured

> **Important**: Both the source and target resources require the **'Cognitive Services User'** role to be granted to the credential used to run the code. This role is required for cross-resource copying operations. Without this role, the `GrantCopyAuthorizationAsync` and `CopyAnalyzerAsync` operations will fail with authorization errors.

## Grant copy authorization and copy analyzer

This sample demonstrates how to copy an analyzer from one Microsoft Foundry resource to another. The goal is to enable cross-resource analyzer sharing, which is useful for scenarios like multi-region deployments, resource migration, or sharing analyzers across different Azure subscriptions.

**Why authorization is required**: When copying analyzers across different Microsoft Foundry resources, the source resource needs to explicitly grant permission to the target resource. This authorization mechanism ensures security and access control, preventing unauthorized copying of analyzers between resources. The authorization is time-limited and includes the target resource ID and region to ensure the copy operation is performed by the intended recipient.

**How grant authorization works**: The `GrantCopyAuthorizationAsync` method must be called on the **source Microsoft Foundry resource** (where the analyzer currently exists). This is because the source resource needs to explicitly grant permission for its analyzer to be copied. The method creates a time-limited authorization record that grants permission to a specific target resource. The method takes:
- The source analyzer ID to be copied
- The target Azure resource ID that is allowed to receive the copy
- The target region where the copy will be performed (optional, defaults to current region)

The method returns a `CopyAuthorization` object containing:
- The full path of the source analyzer
- The target Azure resource ID
- An expiration timestamp for the authorization

**Where copy is performed**: The `CopyAnalyzerAsync` method must be called on the **target Microsoft Foundry resource** (where the analyzer will be copied to). This is because the target resource is the one receiving and creating the copy. When the target resource calls `CopyAnalyzerAsync`, the service validates that authorization was previously granted by the source resource. The authorization must be active (not expired) and match the target resource ID and region specified in the copy request.

**Sample steps**:
1. **Create a source analyzer** in the source Microsoft Foundry resource using the source client (the analyzer to be copied)
2. **Grant copy authorization** on the source resource using the source client's `GrantCopyAuthorizationAsync` method. This must be called on the source resource because it needs to grant permission for its analyzer to be copied. Specify:
   - The source analyzer ID
   - The target Azure resource ID
   - The target region (optional)
3. **Copy the analyzer** to the target resource using the target client's `CopyAnalyzerAsync` method. This must be called on the target resource because it is the one receiving and creating the copy. Provide:
   - The target analyzer ID (name for the copied analyzer)
   - The source analyzer ID
   - The source Azure resource ID
   - The source region

The service validates that authorization was granted by the source resource before allowing the copy operation to proceed. Both source and target resources require 'Cognitive Services User' role for cross-resource copying. The copy authorization expires after a certain time, so copy operations should be performed soon after granting authorization.

```C# Snippet:ContentUnderstandingGrantCopyAuth
// Get source endpoint from configuration
// Note: configuration is already loaded in Main method
string sourceEndpoint = "https://source-resource.services.ai.azure.com/";

// Create source client using DefaultAzureCredential
ContentUnderstandingClient sourceClient = new ContentUnderstandingClient(new Uri(sourceEndpoint), new DefaultAzureCredential());

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

// Create target client using DefaultAzureCredential
ContentUnderstandingClient targetClient = new ContentUnderstandingClient(new Uri(targetEndpoint), new DefaultAzureCredential());

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
sourceAnalyzer.Models["completion"] = "gpt-4.1";

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

    // Step 3: Copy analyzer to target resource
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

## Next steps

- [Sample 14: Copy analyzer][sample14] - Learn about same-resource copying
- [Sample 04: Create analyzer][sample04] - Learn more about creating custom analyzers
- [Sample 09: Delete analyzer][sample09] - Learn about analyzer lifecycle management

## Learn more

- [Content Understanding documentation][cu-docs]
- [Analyzer management][analyzer-docs] - Learn about managing analyzers

## Troubleshooting

If you encounter authorization errors when running this sample, verify the following:

> **Note**: Cross-resource copying requires credential-based authentication (such as `DefaultAzureCredential`). API keys cannot be used for cross-resource operations.

- **Cognitive Services User role**: Ensure that the credential you're using (user, service principal, or managed identity) has been granted the **'Cognitive Services User'** role on both the source and target Microsoft Foundry resources. This role is required for:
  - Granting copy authorization on the source resource
  - Copying analyzers to the target resource

To check or assign the role:
1. Go to the Azure portal
2. Navigate to your Microsoft Foundry resource
3. Open "Access control (IAM)"
4. Verify that your credential (user, service principal, or managed identity) has the "Cognitive Services User" role assigned
5. Repeat this check for both the source and target resources

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample09]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample09_DeleteAnalyzer.md
[sample14]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample14_CopyAnalyzer.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[analyzer-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference

