# Getting error details

This sample demonstrates how get details from an error response from Azure Key Vault with soft delete enabled. You will attempt to create a secret but display a message to the user if the secret has been deleted but not purged.
To get started, you'll need a URI to an Azure Key Vault. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md) for links and instructions.

> Note: Details of an error apart from `code` or `message` are not part of the service contract and should not be used for mission-critical decisions. The error code and message are conveniently defined as properties on `RequestFailedException`.

## Creating a SecretClient

To create a new `SecretClient` to attempt to set a secret, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md) to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:SecretsSample1SecretClient
var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Parsing error details

Azure Key Vault will return an error response if you attempt to create a secret, key, or certificate that is in a deleted state.
If the service returns an HTTP 409 (Conflict) error, you can use `RequestFailedException.GetRawResponse()` to get the raw HTTP response and parse the content for more details.

```C# Snippet:SecretsSample4ErrorResponse
try
{
    KeyVaultSecret secret = client.SetSecret("my-secret", "secret-value");
}
catch (RequestFailedException ex) when (ex.Status == 409)
{
    if (ex.GetRawResponse() is Response response)
    {
        Error error = response.Content.ToObjectFromJson<ErrorResponse>()?.Error;
        if (error?.Code == "Conflict" &&
           (error.InnerError?.Code == "ObjectIsBeingDeleted" || error.InnerError?.Code == "ObjectIsDeletedButRecoverable"))
        {
            Console.WriteLine("Please try again with a new name.");
            return;
        }
    }

    throw;
}
```

### Models

While you can parse the raw response content in different ways and use other deserializers, the sample above uses the following models to deserialize using `System.Text.Json`:

```C# Snippet:SecretsSample4Models
public class ErrorResponse
{
    [JsonPropertyName("error")]
    public Error Error { get; set; }
}

public class Error
{
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("innererror")]
    public InnerError InnerError { get; set; }
}

public class InnerError
{
    [JsonPropertyName("code")]
    public string Code { get; set; }
}
```

Read about [parsing responses](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Response.md) for more information.
