# Deleting a Deployment Synchronously in Azure AI Language

This sample demonstrates how to delete a deployment synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

## Delete a Deployment Synchronously

To delete a deployment, call DeleteDeployment on the TextAnalysisAuthoring client.

```C# Snippet:Sample12_TextAuthoring_DeleteDeployment
string projectName = "LoanAgreements";
string deploymentName = "DeploymentA";

Operation operation = authoringClient.DeleteDeployment(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    deploymentName: deploymentName
);

Console.WriteLine($"Deployment deletion completed with status: {operation.GetRawResponse().Status}");
```

To delete a deployment, the DeleteDeployment method sends a request with the project name and deployment name. The method returns an Operation object indicating the deletion status.
