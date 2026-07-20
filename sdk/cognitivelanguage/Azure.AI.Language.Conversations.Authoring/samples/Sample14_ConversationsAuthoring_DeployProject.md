# Deploying a Project in Azure AI Language

This sample demonstrates how to deploy a project using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2025_11_15_Preview);
ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential, options);
```

Or you can also create a `ConversationAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Deploy a Project

To deploy a project, call `DeployProject` on the `ConversationAuthoringDeployment` client. Deploying a project ensures that the trained model is available for use.

```C# Snippet:Sample14_ConversationsAuthoring_DeployProject
ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
ConversationAuthoringCreateDeploymentDetails trainedModeDetails = new ConversationAuthoringCreateDeploymentDetails("m1");

Operation operation = deploymentClient.DeployProject(
    WaitUntil.Completed,
    projectName,
    deploymentName,
    trainedModeDetails
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
Console.WriteLine($"Delete operation-location: {operationLocation}");
Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
```

## Deploy a Project with Assigned Resources

This feature is supported in both the `2025-11-01` GA version and the `2025-11-15-preview` version of the service.

If you are using `2025-11-15-preview`, create a `ConversationAuthoringCreateDeploymentDetails` instance and add one or more `ConversationAuthoringAssignedProjectResource` items to its `AzureResourceIds` collection, then call `DeployProject` on the `ConversationAuthoringDeployment` client:

```C# Snippet:Sample14_ConversationsAuthoring_DeployProjectWithAssignedResources
ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

string projectName = "{projectName}";
string deploymentName = "{deploymentName}";

// Create AOAI resource reference
AnalyzeConversationAuthoringDataGenerationConnectionInfo assignedAoaiResource =
    new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
        AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
        deploymentName: "gpt-4o")
    {
        ResourceId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
    };

// Create Cognitive Services resource with AOAI linkage
ConversationAuthoringDeploymentResource assignedResource =
    new ConversationAuthoringDeploymentResource(
        resourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
        region: "{region}")
    {
        AssignedAoaiResource = assignedAoaiResource
    };

// Set up deployment details with assigned resources
ConversationAuthoringCreateDeploymentDetails deploymentDetails =
    new ConversationAuthoringCreateDeploymentDetails("ModelWithDG");
deploymentDetails.AssignedResources.Add(assignedResource);
// Start deployment
Operation operation = deploymentClient.DeployProject(WaitUntil.Started, projectName, deploymentName, deploymentDetails);

// Output result
Console.WriteLine($"Deployment started with status: {operation.GetRawResponse().Status}");

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location)
    ? location : "Not found";
Console.WriteLine($"Operation-Location header: {operationLocation}");
```

If you are using `2025-11-01` (GA), the service expects `azureResourceIds` as a list of strings. Use the overload of `ConversationAuthoringCreateDeploymentDetails` that accepts `IList<string>`:

```C# Snippet:Sample14_ConversationsAuthoring_DeployProjectWithAssignedResources_20251101
Uri endpoint = TestEnvironment.Endpoint;
AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);

// Use the 2025-11-01 GA version of the service
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2025_11_01);

ConversationAnalysisAuthoring client =
    new ConversationAnalysisAuthoring(endpoint, credential, options);
ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

string projectName = "{projectName}";
string deploymentName = "{deploymentName}";

// Set up deployment details
ConversationAuthoringCreateDeploymentDetails deploymentDetails =
    new ConversationAuthoringCreateDeploymentDetails("ModelWithDG");
// Start deployment
Operation operation = deploymentClient.DeployProject(WaitUntil.Started, projectName, deploymentName, deploymentDetails);
```

## Deploy a Project Async

To deploy a project asynchronously, call `DeployProjectAsync` on the `ConversationAuthoringDeployment` client. This ensures that the trained model is deployed and available for use without blocking execution.

```C# Snippet:Sample14_ConversationsAuthoring_DeployProjectAsync
ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
ConversationAuthoringCreateDeploymentDetails trainedModeDetails = new ConversationAuthoringCreateDeploymentDetails("m1");

Operation operation = await deploymentClient.DeployProjectAsync(
    WaitUntil.Completed,
    projectName,
    deploymentName,
    trainedModeDetails
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
Console.WriteLine($"Delete operation-location: {operationLocation}");
Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
```

## Deploy with Assigned Resources Async

This async version feature is also supported in both the `2025-11-01` GA version and the `2025-11-15-preview` version of the service.

If you are using `2025-11-15-preview`, create a `ConversationAuthoringCreateDeploymentDetails` instance and add one or more `ConversationAuthoringAssignedProjectResource` items to its `AzureResourceIds` collection, then call `DeployProjectAsync` on the `ConversationAuthoringDeployment` client:

```C# Snippet:Sample14_ConversationsAuthoring_DeployProjectAsyncWithAssignedResources
ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

string projectName = "{projectName}";
string deploymentName = "{deploymentName}";

// Create AOAI resource reference
AnalyzeConversationAuthoringDataGenerationConnectionInfo assignedAoaiResource =
    new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
        AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
        deploymentName: "gpt-4o")
    {
        ResourceId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
    };

// Create Cognitive Services resource with AOAI linkage
ConversationAuthoringDeploymentResource assignedResource =
    new ConversationAuthoringDeploymentResource(
        resourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
        region: "{region}")
    {
        AssignedAoaiResource = assignedAoaiResource
    };

// Set up deployment details with assigned resources
ConversationAuthoringCreateDeploymentDetails deploymentDetails =
    new ConversationAuthoringCreateDeploymentDetails("ModelWithDG");
deploymentDetails.AssignedResources.Add(assignedResource);
// Start deployment
Operation operation = await deploymentClient.DeployProjectAsync(WaitUntil.Started, projectName, deploymentName, deploymentDetails);

// Output result
Console.WriteLine($"Deployment started with status: {operation.GetRawResponse().Status}");

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location)
    ? location : "Not found";
Console.WriteLine($"Operation-Location header: {operationLocation}");
```

If you are using `2025-11-01` (GA), the service expects `azureResourceIds` as a list of strings. Use the overload of `ConversationAuthoringCreateDeploymentDetails` that accepts `IList<string>`:

```C# Snippet:Sample14_ConversationsAuthoring_DeployProjectAsyncWithAssignedResources_20251101
Uri endpoint = TestEnvironment.Endpoint;
AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);

// Use the 2025-11-01 GA version of the service
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2025_11_01);

ConversationAnalysisAuthoring client =
    new ConversationAnalysisAuthoring(endpoint, credential, options);
ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

string projectName = "{projectName}";
string deploymentName = "{deploymentName}";

// Set up deployment details
ConversationAuthoringCreateDeploymentDetails deploymentDetails =
    new ConversationAuthoringCreateDeploymentDetails("ModelWithDG");
// Start deployment asynchronously
Operation operation = await deploymentClient.DeployProjectAsync(WaitUntil.Started, projectName, deploymentName, deploymentDetails);
```
