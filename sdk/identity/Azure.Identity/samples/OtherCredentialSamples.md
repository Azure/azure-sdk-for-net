# AzurePipelinesCredential Example

This example demonstrates authenticating the `SecretClient` using the `AzurePipelinesCredential` in an Azure Pipelines environment with [service connections](https://learn.microsoft.com/azure/devops/pipelines/library/service-endpoints).

```C# Snippet:AzurePipelinesCredential_Example
// Replace the following values with the actual values for the service connection.
string clientId = "<service_connection_client_id>";
string tenantId = "<service_connection_tenant_id>";
string serviceConnectionId = "<service_connection_id>";

// Construct the credential.
var credential = new AzurePipelinesCredential(tenantId, clientId, serviceConnectionId);

// Use the credential to authenticate with the Key Vault client.
var client = new SecretClient(new Uri("https://keyvault-name.vault.azure.net/"), credential);
```

***Note:*** This credential is **not** included in the `DefaultAzureCredential` chain and must be used explicitly.
