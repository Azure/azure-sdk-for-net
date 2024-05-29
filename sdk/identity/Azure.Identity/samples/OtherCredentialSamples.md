# AzurePipelinesCredential Example

This example demonstrates authenticating the `SecretClient` using the `AzurePipelinesCredential` in an Azure Pipelines environment with [service connections](https://learn.microsoft.com/azure/devops/pipelines/library/service-endpoints).
***Note:*** This credential requires environment variables which are only available in the context of an Azure [PowerShell](https://learn.microsoft.com/azure/devops/pipelines/tasks/reference/powershell-v2?view=azure-pipelines) or [Azure CLI](https://learn.microsoft.com/azure/devops/pipelines/tasks/reference/azure-cli-v2?view=azure-pipelines) task.

More information about the System.AccessToken can be found [here](https://learn.microsoft.com/azure/devops/pipelines/build/variables?view=azure-devops&tabs=yaml#systemaccesstoken).

```C# Snippet:AzurePipelinesCredential_Example
// Replace the following values with the actual values for the System.AccessToken and the details for your service connection.
string systemAccessToken = "<the value of System.AccessToken>";
string clientId = "<the value of ClientId for the service connections>";
string tenantId = "<the value of TenantId for the service connections>";
string serviceConnectionId = "<the value of service connection Id>";

// Construct the credential.
var credential = new AzurePipelinesCredential(systemAccessToken, clientId, tenantId, serviceConnectionId);

// Use the credential to authenticate with the Key Vault client.
var client = new SecretClient(new Uri("https://keyvault-name.vault.azure.net/"), credential);
```

***Note:*** This credential is **not** included in the `DefaultAzureCredential` chain.
