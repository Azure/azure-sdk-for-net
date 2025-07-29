# Deploying a Project in Azure AI Language

This sample demonstrates how to deploy a project synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

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

## Deploy a Project Asynchronously

To deploy a project, call DeployProjectAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample14_TextAuthoring_DeployProjectAsync
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

var deploymentConfig = new TextAuthoringCreateDeploymentDetails(trainedModelLabel: "{modelLabel}");

Operation operation = await deploymentClient.DeployProjectAsync(
    waitUntil: WaitUntil.Completed,
    details: deploymentConfig
);

Console.WriteLine($"Deployment operation status: {operation.GetRawResponse().Status}");
```

To deploy a project, the DeployProjectAsync method sends a request with the project name, deployment name, and deployment configuration. The method returns an Operation object indicating the deployment status.
