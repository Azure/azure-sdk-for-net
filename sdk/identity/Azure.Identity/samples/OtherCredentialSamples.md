# AzurePipelinesCredential Example

This example demonstrates authenticating the Key Vault `SecretClient` using the `AzurePipelinesCredential` in an Azure Pipelines environment with [service connections](https://learn.microsoft.com/azure/devops/pipelines/library/service-endpoints).

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

***Note:*** This credential is **not** included in the `DefaultAzureCredential` chain.


# OnBehalfOfCredential with Managed Identity FIC Example

This example demonstrates the use of the `OnBehalfOfCredential` to authenticate the Key Vault `SecretClient` using a managed identity as the client assertion. More information about the On Behalf Of Flow can be found [here](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-on-behalf-of-flow).

```C# Snippet:FederatedOboWithManagedIdentityCredential_Example
// Replace the following values with the actual values for your tenant and client ids.
string tenantId = "<tenant_id>";
string clientId = "<client_id>";

// Replace the following value with the actual user assertion.
string userAssertion = "<user_assertion>";

Func<CancellationToken, Task<string>> getManagedIdentityAssertion = async (cancellationToken) =>
{
    // Create a new instance of the ManagedIdentityCredential.
    var miCred = new ManagedIdentityCredential();

    // Get the token from the ManagedIdentityCredential using the token exchange scope.
    var result = await miCred.GetTokenAsync(new TokenRequestContext(new[] { "api://AzureADTokenExchange" }), cancellationToken: cancellationToken);

    // Return the token.
    return result.Token;
};

// Construct the credential.
var credential = new OnBehalfOfCredential(tenantId, clientId, getManagedIdentityAssertion, userAssertion);

// Use the credential to authenticate with the Key Vault client.
var client = new SecretClient(new Uri("https://keyvault-name.vault.azure.net/"), credential);
```
