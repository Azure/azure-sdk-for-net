# Swapping Deployments Synchronously in Azure AI Language

This sample demonstrates how to swap deployments synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Swap Deployments Synchronously

To swap deployments, call SwapDeployments on the TextAnalysisAuthoring client.

```C# Snippet:Sample11_TextAuthoring_SwapDeployments
string projectName = "LoanAgreements";
string firstDeploymentName = "DeploymentA";
string secondDeploymentName = "DeploymentB";
TextAuthoringProject porjectClient = client.GetProject(projectName);

var swapDetails = new TextAuthoringSwapDeploymentsDetails(
    firstDeploymentName: firstDeploymentName,
    secondDeploymentName: secondDeploymentName
    );

Operation operation = porjectClient.SwapDeployments(
    waitUntil: WaitUntil.Completed,
    details: swapDetails
);

Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
```

To swap deployments, the SwapDeployments method sends a request with the project name and the deployment swap configuration. The method returns an Operation object indicating the swap status.
