# Deleting a Deployment Asynchronously in Azure AI Language

This sample demonstrates how to delete a deployment asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Delete a Deployment Asynchronously

To delete a deployment, call DeleteDeploymentAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample13_TextAuthoring_DeleteDeploymentAsync
string projectName = "MyDeploymentProjectAsync";
string deploymentName = "Deployment1";
TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

Operation operation = await deploymentClient.DeleteDeploymentAsync(
    waitUntil: WaitUntil.Completed
);

Console.WriteLine($"Deployment deletion completed with status: {operation.GetRawResponse().Status}");
```

To delete a deployment, the DeleteDeploymentAsync method sends a request with the project name and deployment name. The method returns an Operation object indicating the deletion status.
