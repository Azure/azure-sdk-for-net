# Getting secrets

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/README.md#getting-started) for details.

## Import the namespaces

```C# Snippet:Azure_Template_Namespaces
using Azure.Template.Models;
```

## Get secrets synchronously

You can create a client and get secrets synchronously:

```C# Snippet:Azure_Template_GetSecret
string endpoint = "https://myvault.vault.azure.net";
var client = new MiniSecretClient(new Uri(endpoint), new DefaultAzureCredential());

SecretBundle secret = client.GetSecret("TestSecret");

Console.WriteLine(secret.Value);
```

## Get secrets asynchronously

You can also get secrets asynchronously:

```C# Snippet:Azure_Template_GetSecretAsync
string endpoint = "https://myvault.vault.azure.net";
var client = new MiniSecretClient(new Uri(endpoint), new DefaultAzureCredential());

SecretBundle secret = await client.GetSecretAsync("TestSecret");

Console.WriteLine(secret.Value);
```
