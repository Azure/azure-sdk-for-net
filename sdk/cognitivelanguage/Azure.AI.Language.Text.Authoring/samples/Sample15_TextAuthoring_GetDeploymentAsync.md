# Retrieving Deployment Details Asynchronously in Azure AI Language

This sample demonstrates how to retrieve deployment details asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Retrieve Deployment Details Asynchronously

To retrieve deployment details, call `GetDeploymentAsync` on the `TextAuthoringDeployment` client. The method returns a `Response<TextAuthoringProjectDeployment>` containing the deployment details.

```C# Snippet:Sample15_TextAuthoring_GetDeploymentAsync
string projectName = "LoanAgreements";
string deploymentName = "DeploymentName";
TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

var deploymentConfig = new TextAuthoringCreateDeploymentDetails(trainedModelLabel: "29886710a2ae49259d62cffca977db66");

Operation operation = await deploymentClient.DeployProjectAsync(
    waitUntil: WaitUntil.Completed,
    details: deploymentConfig
);

Console.WriteLine($"Deployment operation status: {operation.GetRawResponse().Status}");
```
