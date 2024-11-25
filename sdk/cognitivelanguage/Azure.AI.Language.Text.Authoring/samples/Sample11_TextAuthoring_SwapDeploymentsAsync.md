# Swapping Deployments Asynchronously in Azure AI Language

This sample demonstrates how to swap deployments asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion_Async
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your-api-key");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

## Swap Deployments Asynchronously

To swap deployments, call SwapDeploymentsAsync on the TextAnalysisAuthoring client.

```C#
string projectName = "LoanAgreements";
var swapConfig = new SwapDeploymentsConfig
(
    firstDeploymentName: "DeploymentA",
    secondDeploymentName: "DeploymentB"
);

Operation operation = await authoringClient.SwapDeploymentsAsync(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    body: swapConfig
);

Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
```

To swap deployments, the SwapDeploymentsAsync method sends a request with the project name and the deployment swap configuration. The method returns an Operation object indicating the swap status.
