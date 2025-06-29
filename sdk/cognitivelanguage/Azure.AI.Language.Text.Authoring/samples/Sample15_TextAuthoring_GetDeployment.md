# Retrieving Deployment Details Synchronously in Azure AI Language

This sample demonstrates how to retrieve deployment details synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Retrieve Deployment Details Synchronously

To retrieve deployment details, call `GetDeployment` on the `TextAuthoringDeployment` client. The method returns a `Response<TextAuthoringProjectDeployment>` containing the deployment details.
  
```C# Snippet:Sample15_TextAuthoring_GetDeployment
string projectName = "MyDeploymentProject";
string deploymentName = "MyDeployment";
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
