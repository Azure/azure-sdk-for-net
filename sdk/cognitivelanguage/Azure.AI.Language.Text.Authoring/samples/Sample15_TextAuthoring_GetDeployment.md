# Retrieving Deployment Details in Azure AI Language

This sample demonstrates how to retrieve deployment details synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create a TextAnalysisAuthoringClient

To create a `TextAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `TextAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

Or you can also create a `TextAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Retrieve Deployment Details Synchronously

To retrieve deployment details, call `GetDeployment` on the `TextAuthoringDeployment` client. The method returns a `Response<TextAuthoringProjectDeployment>` containing the deployment details.
  
```C# Snippet:Sample15_TextAuthoring_GetDeployment
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

Response<TextAuthoringProjectDeployment> response = deploymentClient.GetDeployment();

TextAuthoringProjectDeployment deployment = response.Value;

Console.WriteLine($"Deployment Name: {deployment.DeploymentName}");
Console.WriteLine($"Model Id: {deployment.ModelId}");
Console.WriteLine($"Last Trained On: {deployment.LastTrainedOn}");
Console.WriteLine($"Last Deployed On: {deployment.LastDeployedOn}");
Console.WriteLine($"Deployment Expired On: {deployment.DeploymentExpiredOn}");
Console.WriteLine($"Model Training Config Version: {deployment.ModelTrainingConfigVersion}");
```

## Retrieve Deployment Details Asynchronously

To retrieve deployment details, call `GetDeploymentAsync` on the `TextAuthoringDeployment` client. The method returns a `Response<TextAuthoringProjectDeployment>` containing the deployment details.

```C# Snippet:Sample15_TextAuthoring_GetDeploymentAsync
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

Response<TextAuthoringProjectDeployment> response = await deploymentClient.GetDeploymentAsync();

TextAuthoringProjectDeployment deployment = response.Value;

Console.WriteLine($"Deployment Name: {deployment.DeploymentName}");
Console.WriteLine($"Model Id: {deployment.ModelId}");
Console.WriteLine($"Last Trained On: {deployment.LastTrainedOn}");
Console.WriteLine($"Last Deployed On: {deployment.LastDeployedOn}");
Console.WriteLine($"Deployment Expired On: {deployment.DeploymentExpiredOn}");
Console.WriteLine($"Model Training Config Version: {deployment.ModelTrainingConfigVersion}");
```
