# Break Sentence

## Create a `TranslatorClient`

To create a new `TranslatorClient`, you will need the service endpoint and credentials of your Translator resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential` and region, which you can create with an API key.

```C# Snippet:CreateTranslatorClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TranslatorClient client = new(endpoint, credential, "<region>");
```

The values of the `endpoint`, `apiKey` and `region` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.


See the [README] of the Text Translator client library for more information, including useful links and instructions.

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/texttranslator/Azure.AI.TextTranslator/README.md
