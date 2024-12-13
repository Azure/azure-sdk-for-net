# Swapping Deployments Synchronously in Azure AI Language

This sample demonstrates how to swap deployments synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

## Swap Deployments Synchronously

To swap deployments, call SwapDeployments on the TextAnalysisAuthoring client.

```C# Snippet:Sample11_TextAuthoring_SwapDeployments
string projectName = "LoanAgreements";
var swapDetails = new SwapDeploymentsDetails(
    firstDeploymentName: "DeploymentA",
    secondDeploymentName: "DeploymentB"
    );

Operation operation = authoringClient.SwapDeployments(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    body: swapDetails
);

Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
```

To swap deployments, the SwapDeployments method sends a request with the project name and the deployment swap configuration. The method returns an Operation object indicating the swap status.
