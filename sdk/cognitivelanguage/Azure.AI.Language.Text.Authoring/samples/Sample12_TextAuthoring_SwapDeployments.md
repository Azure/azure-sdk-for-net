# Swapping Deployments in Azure AI Language

This sample demonstrates how to swap deployments synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

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

## Swap Deployments Synchronously

To swap deployments, call SwapDeployments on the TextAnalysisAuthoring client.

```C# Snippet:Sample12_TextAuthoring_SwapDeployments
string projectName = "{projectName}";
string firstDeploymentName = "{deploymentName1}";
string secondDeploymentName = "{deploymentName2}";
TextAuthoringProject projectClient = client.GetProject(projectName);

var swapDetails = new TextAuthoringSwapDeploymentsDetails(
    firstDeploymentName: firstDeploymentName,
    secondDeploymentName: secondDeploymentName
    );

Operation operation = projectClient.SwapDeployments(
    waitUntil: WaitUntil.Completed,
    details: swapDetails
);

Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
```

To swap deployments, the SwapDeployments method sends a request with the project name and the deployment swap configuration. The method returns an Operation object indicating the swap status.

## Swap Deployments Asynchronously

To swap deployments, call SwapDeploymentsAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample12_TextAuthoring_SwapDeploymentsAsync
string projectName = "{projectName}";
string firstDeploymentName = "{deploymentName1}";
string secondDeploymentName = "{deploymentName2}";
TextAuthoringProject projectClient = client.GetProject(projectName);

var swapDetails = new TextAuthoringSwapDeploymentsDetails
(
    firstDeploymentName: firstDeploymentName,
    secondDeploymentName: secondDeploymentName
    );

Operation operation = await projectClient.SwapDeploymentsAsync(
    waitUntil: WaitUntil.Completed,
    details: swapDetails
);

Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
```

To swap deployments, the SwapDeploymentsAsync method sends a request with the project name and the deployment swap configuration. The method returns an Operation object indicating the swap status.
