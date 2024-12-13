# Deploying a Project Synchronously in Azure AI Language

This sample demonstrates how to deploy a project synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

## Deploy a Project Synchronously

To deploy a project, call DeployProject on the TextAnalysisAuthoring client.

```C# Snippet:Sample10_TextAuthoring_DeployProject
string projectName = "LoanAgreements";
string deploymentName = "DeploymentName";
var deploymentDetails = new CreateDeploymentDetails(trainedModelLabel: "29886710a2ae49259d62cffca977db66");

Operation operation = authoringClient.DeployProject(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    deploymentName: deploymentName,
    body: deploymentDetails
);

Console.WriteLine($"Deployment operation status: {operation.GetRawResponse().Status}");
```

To deploy a project, the DeployProject method sends a request with the project name, deployment name, and deployment configuration. The method returns an Operation object indicating the deployment status.
