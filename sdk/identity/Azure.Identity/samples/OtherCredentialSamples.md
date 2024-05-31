# AzurePipelinesCredential Example

This example demonstrates authenticating the `SecretClient` using the `AzurePipelinesCredential` in an Azure Pipelines environment with [service connections](https://learn.microsoft.com/azure/devops/pipelines/library/service-endpoints).

In the below sample, it is recommended to assign the value of the System.AccessToken to a secure variable in the Azure Pipelines environment.
More information about the System.AccessToken can be found [here](https://learn.microsoft.com/azure/devops/pipelines/build/variables?view=azure-devops&tabs=yaml#systemaccesstoken).

```C# Snippet:AzurePipelinesCredential_Example
// Replace the following values with the actual values from the details for your service connection.
string clientId = "<the value of ClientId for the service connections>";
string tenantId = "<the value of TenantId for the service connections>";
string serviceConnectionId = "<the value of service connection Id>";

// Construct the credential.
var credential = new AzurePipelinesCredential(Environment.GetEnvironmentVariable("SYSTEM_ACCESSTOKEN"), clientId, tenantId, serviceConnectionId);

// Use the credential to authenticate with the Key Vault client.
var client = new SecretClient(new Uri("https://keyvault-name.vault.azure.net/"), credential);
```

***Note:*** This credential is **not** included in the `DefaultAzureCredential` chain.
