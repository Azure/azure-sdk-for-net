# Deploying a Project Synchronously in Azure AI Language

This sample demonstrates how to deploy a project synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Deploy a Project Synchronously

To deploy a project, call DeployProject on the TextAnalysisAuthoring client.

```C# Snippet:Sample14_TextAuthoring_DeployProject
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

var deploymentDetails = new TextAuthoringCreateDeploymentDetails(trainedModelLabel: "{modelLabel}");

Operation operation = deploymentClient.DeployProject(
    waitUntil: WaitUntil.Completed,
    details: deploymentDetails
);

Console.WriteLine($"Deployment operation status: {operation.GetRawResponse().Status}");
```

To deploy a project, the DeployProject method sends a request with the project name, deployment name, and deployment configuration. The method returns an Operation object indicating the deployment status.
