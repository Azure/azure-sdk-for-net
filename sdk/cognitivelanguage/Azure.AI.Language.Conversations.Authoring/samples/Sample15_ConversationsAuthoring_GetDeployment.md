# Retrieving Deployment Information in Azure AI Language

This sample demonstrates how to retrieve details of an existing deployment using the synchronous API of the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

## Get Deployment Information

To retrieve deployment details, call `GetDeployment` on the `ConversationAuthoringDeployment` client. This allows you to access metadata such as the model ID, timestamps, and assigned resource configuration.

```C# Snippet:Sample15_ConversationsAuthoring_GetDeployment
string projectName = "EmailAppEnglish";
string deploymentName = "assignedDeployment";

ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

Response<ConversationAuthoringProjectDeployment> response = deploymentClient.GetDeployment();

ConversationAuthoringProjectDeployment deployment = response.Value;

Console.WriteLine($"Deployment Name: {deployment.DeploymentName}");
Console.WriteLine($"Model Id: {deployment.ModelId}");
Console.WriteLine($"Last Trained On: {deployment.LastTrainedOn}");
Console.WriteLine($"Last Deployed On: {deployment.LastDeployedOn}");
Console.WriteLine($"Deployment Expired On: {deployment.DeploymentExpiredOn}");
Console.WriteLine($"Model Training Config Version: {deployment.ModelTrainingConfigVersion}");

// Print assigned resources info
if (deployment.AssignedResources != null)
{
    foreach (var assignedResource in deployment.AssignedResources)
    {
        Console.WriteLine($"Resource ID: {assignedResource.ResourceId}");
        Console.WriteLine($"Region: {assignedResource.Region}");

        if (assignedResource.AssignedAoaiResource != null)
        {
            Console.WriteLine($"AOAI Kind: {assignedResource.AssignedAoaiResource.Kind}");
            Console.WriteLine($"AOAI Resource ID: {assignedResource.AssignedAoaiResource.ResourceId}");
            Console.WriteLine($"AOAI Deployment Name: {assignedResource.AssignedAoaiResource.DeploymentName}");
        }
    }
}
```
