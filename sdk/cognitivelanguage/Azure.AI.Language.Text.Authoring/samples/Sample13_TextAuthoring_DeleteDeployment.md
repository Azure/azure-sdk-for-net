# Deleting a Deployment in Azure AI Language

This sample demonstrates how to delete a deployment synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

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

## Delete a Deployment Synchronously

To delete a deployment, call DeleteDeployment on the TextAnalysisAuthoring client.

```C# Snippet:Sample13_TextAuthoring_DeleteDeployment
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

Operation operation = deploymentClient.DeleteDeployment(
    waitUntil: WaitUntil.Completed
);

Console.WriteLine($"Deployment deletion completed with status: {operation.GetRawResponse().Status}");
```

To delete a deployment, the DeleteDeployment method sends a request with the project name and deployment name. The method returns an Operation object indicating the deletion status.

## Delete a Deployment Asynchronously

To delete a deployment, call DeleteDeploymentAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample13_TextAuthoring_DeleteDeploymentAsync
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

Operation operation = await deploymentClient.DeleteDeploymentAsync(
    waitUntil: WaitUntil.Completed
);

Console.WriteLine($"Deployment deletion completed with status: {operation.GetRawResponse().Status}");
```

To delete a deployment, the DeleteDeploymentAsync method sends a request with the project name and deployment name. The method returns an Operation object indicating the deletion status.
