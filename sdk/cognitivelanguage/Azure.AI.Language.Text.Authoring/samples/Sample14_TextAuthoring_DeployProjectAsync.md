# Deploying a Project Asynchronously in Azure AI Language

This sample demonstrates how to deploy a project asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Deploy a Project Asynchronously

To deploy a project, call DeployProjectAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample14_TextAuthoring_DeployProjectAsync
string projectName = "MyDeploymentProjectAsync";
string deploymentName = "Deployment1";
TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

var deploymentConfig = new TextAuthoringCreateDeploymentDetails(trainedModelLabel: "29886710a2ae49259d62cffca977db66");

Operation operation = await deploymentClient.DeployProjectAsync(
    waitUntil: WaitUntil.Completed,
    details: deploymentConfig
);

Console.WriteLine($"Deployment operation status: {operation.GetRawResponse().Status}");
```

To deploy a project, the DeployProjectAsync method sends a request with the project name, deployment name, and deployment configuration. The method returns an Operation object indicating the deployment status.
