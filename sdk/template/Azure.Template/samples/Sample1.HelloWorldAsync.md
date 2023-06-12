# Get secret asynchronously

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/README.md#getting-started) for details.

## Import the namespaces

```C# Snippet:Azure_Template
using Azure.Identity;
using Azure.Template.Models;
```

## Get secrets asynchronously

You can also get secrets asynchronously:

```C# Snippet:Azure_Template_GetSecretAsync
string endpoint = "https://myvault.vault.azure.net";
var credential = new DefaultAzureCredential();
var client = new TemplateClient(endpoint, credential);

SecretBundle secret = await client.GetSecretValueAsync("TestSecret");

Console.WriteLine(secret.Value);
```
