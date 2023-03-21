# Create Text Translation Client

## Creating Cognitive Services resource
Text translation supports both [multi-service and single-service access][service_access]. Create a Cognitive Services resource if you plan to access multiple cognitive services under a single endpoint and API key. To access the features of the Text translation service only, create a Text translation service resource instead.

You can create Cognitive Services resource via the [Azure portal][cognitive_resource_azure_portal] or, alternatively, you can follow the steps in [this document][cognitive_resource_azure_cli] to create it using the [Azure CLI][azure_cli].

## Create a `TextTranslationClient` using an API key using Global Text Translator resource

Once you have the value for the API key, create an `AzureKeyCredential`. This will allow you to
update the API key without creating a new client.

With the value of the `AzureKeyCredential`, you can create the [TextTranslationClient][translator_client_class]:

```C# Snippet:CreateTextTranslationClient
AzureKeyCredential credential = new("<apiKey>");
TextTranslationClient client = new(credential);
```

## Create a `TextTranslationClient` using an API key and Region credential

Once you have the value for the API key and Region, create an `AzureKeyCredential`. This will allow you to update the API key without creating a new client.

With the value of the `AzureKeyCredential` and a `Region`, you can create the [TextTranslationClient][translator_client_class]:

```C# Snippet:CreateTextTranslationClient
AzureKeyCredential credential = new("<apiKey>");
TextTranslationClient client = new(credential, "<region>");
```

## Create a `TextTranslationClient` using a Custom Endpoint and Api Key
When Translator service is configured to use [Virtual Network (VNET)][translator_vnet] capability you need to use [custom subdomain][custom_subdomain].

Once you have your resource configured and you have your custom endpoint value and your API key, you can create the [TextTranslationClient][translator_client_class]:

```C# Snippet:CreateTextTranslationClientCustom
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextTranslationClient client = new(credential, endpoint);
```

## Create a `TextTranslationClient` using a Token Authentication

Instead of API key and Region authentication you can use JWT token. For information on how to create token refer to [Authenticating with an access token][translator_token].

Once you have the value for the token, create an class that extends `Azure.Core.TokenCredentials`. With the value of the `AzureKeyCredential` and your service returning tokens, you can create the [TextTranslationClient][translator_client_class]:

```C# Snippet:CreateTextTranslationClientToken
TokenCredential credential = new("<token>");
TextTranslationClient client = new(credential);
```

[translator_client_class]: https://github.com/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Text/src/TextTranslationClient.cs
[translator_vnet]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-reference#virtual-network-support
[custom_subdomain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[translator_token]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-reference#authenticating-with-an-access-token
[cognitive_resource_azure_portal]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
[cognitive_resource_azure_cli]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli
[azure_cli]: https://docs.microsoft.com/cli/azure
[service_access]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
