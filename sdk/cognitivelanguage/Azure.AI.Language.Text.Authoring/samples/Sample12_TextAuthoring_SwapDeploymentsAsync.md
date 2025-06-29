# Swapping Deployments Asynchronously in Azure AI Language

This sample demonstrates how to swap deployments asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Swap Deployments Asynchronously

To swap deployments, call SwapDeploymentsAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample12_TextAuthoring_SwapDeploymentsAsync
string projectName = "LoanAgreements";
string firstDeploymentName = "DeploymentA";
string secondDeploymentName = "DeploymentB";
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
