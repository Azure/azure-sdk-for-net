# Create Text Translation Client

## Creating Cognitive Services resource

Text translation supports both [multi-service and single-service access][service_access]. Create a Cognitive Services resource if you plan to access multiple Cognitive Services under a single endpoint and API key. To access the features of the Text translation service only, create a Text translation service resource instead.

You can create Cognitive Services resource via the [Azure portal][cognitive_resource_azure_portal] or, alternatively, you can follow the steps in [this document][cognitive_resource_azure_cli] to create it using the [Azure CLI][azure_cli].

## Create a `TextTranslationClient` using an API key from Global Text Translator resource

Once you have the value for the API key, create an `AzureKeyCredential`.

With the value of the `AzureKeyCredential`, you can create the [TextTranslationClient][translator_client_class]:

```C# Snippet:CreateTextTranslationClientWithKey
string apiKey = "<Text Translator Resource API Key>";
TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey));
```

> Replace `<apiKey>` with a value created in [Creating Cognitive Services resource](#creating-cognitive-services-resource).

## Create a `TextTranslationClient` using an API key and Region credential

Once you have the value for the API key and Region, create an `AzureKeyCredential`. This will allow you to update the API key without creating a new client.

With the value of the `AzureKeyCredential` and a `Region`, you can create the [TextTranslationClient][translator_client_class]:

```C# Snippet:CreateTextTranslationClientWithRegion
string apiKey = "<Text Translator Resource API Key>";
string region = "<Text Translator Azure Region>";
TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), region);
```

> Replace `<apiKey>` and `<region>` with a value created in [Creating Cognitive Services resource](#creating-cognitive-services-resource).

## Create a `TextTranslationClient` using a Custom Subdomain and Api Key

When Translator service is configured to use [Virtual Network (VNET)][translator_vnet] capability you need to use [custom subdomain][custom_subdomain].

Once you have your resource configured and you have your custom subdomain value and your API key, you can create the [TextTranslationClient][translator_client_class]:

```C# Snippet:CreateTextTranslationClientWithEndpoint
string endpoint = "<Text Translator Resource Endpoint>";
string apiKey = "<Text Translator Resource API Key>";
TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), new Uri(endpoint));
```

> Replace `<apiKey>` with a value created in [Creating Cognitive Services resource](#creating-cognitive-services-resource).

## Create a `TextTranslationClient` using a Token Authentication

Instead of API key and Region authentication you can use JWT token. For information on how to create token refer to [Authenticating with an access token][translator_token].

Once you have the value for the token, create an class that extends `Azure.Core.TokenCredential`. With the value of the `AzureKeyCredential` and your service returning tokens, you can create the [TextTranslationClient][translator_client_class]:

```C# Snippet:CreateTextTranslationClientWithToken
string token = "<Cognitive Services Token>";
TokenCredential credential = new StaticAccessTokenCredential(new AccessToken(token, DateTimeOffset.Now.AddMinutes(1)));
TextTranslationClient client = new(credential);
```

[translator_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Text/src/Custom/TextTranslationClient.cs
[translator_vnet]: https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-reference#virtual-network-support
[custom_subdomain]: https://learn.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[translator_token]: https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-reference#authenticating-with-an-access-token
[cognitive_resource_azure_portal]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
[cognitive_resource_azure_cli]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli
[azure_cli]: https://learn.microsoft.com/cli/azure
[service_access]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
