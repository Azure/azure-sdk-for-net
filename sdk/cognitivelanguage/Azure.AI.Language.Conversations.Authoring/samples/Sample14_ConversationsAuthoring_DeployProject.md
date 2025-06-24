# Deploying a Project in Azure AI Language

This sample demonstrates how to deploy a project using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

## Deploy a Project

To deploy a project, call `DeployProject` on the `ConversationAuthoringDeployment` client. Deploying a project ensures that the trained model is available for use.

```C# Snippet:Sample14_ConversationsAuthoring_DeployProject
string projectName = "Test-data-labels";
string deploymentName = "staging";

ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

ConversationAuthoringCreateDeploymentDetails trainedModeDetails = new ConversationAuthoringCreateDeploymentDetails("m1");

Operation operation = deploymentClient.DeployProject(
    waitUntil: WaitUntil.Completed,
    trainedModeDetails
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
Console.WriteLine($"Delete operation-location: {operationLocation}");
Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
```

## Deploy a Project with Assigned Resources

To deploy a project with assigned resources, create a `ConversationAuthoringCreateDeploymentDetails` object and populate its `AssignedResources` list with the desired configuration. Then call `DeployProject` on the `ConversationAuthoringDeployment` client.

```C# Snippet:Sample14_ConversationsAuthoring_DeployProjectWithAssignedResources
string projectName = "EmailAppEnglish";
string deploymentName = "assignedDeployment";

// Create AOAI resource reference
AnalyzeConversationAuthoringDataGenerationConnectionInfo assignedAoaiResource =
    new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
        AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
        deploymentName: "gpt-4o")
    {
        ResourceId = "/subscriptions/e54a2925-af7f-4b05-9ba1-2155c5fe8a8e/resourceGroups/gouri-eastus/providers/Microsoft.CognitiveServices/accounts/sdk-test-openai"
    };

// Create Cognitive Services resource with AOAI linkage
ConversationAuthoringDeploymentResource assignedResource =
    new ConversationAuthoringDeploymentResource(
        resourceId: "/subscriptions/b72743ec-8bb3-453f-83ad-a53e8a50712e/resourceGroups/language-sdk-rg/providers/Microsoft.CognitiveServices/accounts/sdk-test-01",
        region: "East US")
    {
        AssignedAoaiResource = assignedAoaiResource
    };

// Set up deployment details with assigned resources
ConversationAuthoringCreateDeploymentDetails deploymentDetails =
    new ConversationAuthoringCreateDeploymentDetails("ModelWithDG");
deploymentDetails.AssignedResources.Add(assignedResource);

// Get deployment client
ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

// Start deployment
Operation operation = deploymentClient.DeployProject(WaitUntil.Started, deploymentDetails);

// Output result
Console.WriteLine($"Deployment started with status: {operation.GetRawResponse().Status}");

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location)
    ? location : "Not found";
Console.WriteLine($"Operation-Location header: {operationLocation}");
```
