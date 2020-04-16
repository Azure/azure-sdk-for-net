# Azure Cognitive Services Form Recognizer client library for .NET
Azure Cognitive Services Form Recognizer is a cloud service that uses machine learning recognize form fields, text, and tables in form documents.  It includes the following capabilities:

- Recognize Custom Forms - Recognize and extract form fields and other content from your custom forms, using models you train with your own form types.
- Recognize Form Content - Recognize and extract tables, lines and words in forms documents, without the need to train a model.
- Recognize Receipts - Recognize and extract common fields from US receipts, using a pre-trained receipt model.

[Source code][formreco_client_src] | <!--[Package (NuGet)]() | [API reference documentation]() |--> [Product documentation][formreco_docs] <!--| [Samples]()-->

## Getting started

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Form Recognizer resource. If you need to create the resource, you can use the [Azure Portal][azure_portal] or [Azure CLI][azure_cli].

If you use the Azure CLI, replace `<your-resource-group-name>`, `<your-resource-name>`, `<location>`, and `<sku>` with your values:

```PowerShell
az cognitiveservices account create --kind FormRecognizer --resource-group <your-resource-group-name> --name <your-resource-name> --location <location> --sku <sku>
``` -->

<!-- 
### Install the package
Install the Azure Form Recognizer client library for .NET with [NuGet][nuget].  To use the [.NET CLI](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli), run the following command from PowerShell in the directory that contains your project file:

```PowerShell
dotnet add package Azure.AI.FormRecognizer --version 1.0.0-preview.1
``` 
For other installation methods, please see the package information on [NuGet][nuget].


### Authenticate a Form Recognizer client
In order to interact with the Form Recognizer service, you'll need to create an instance of the `FormRecognizerClient` class.  You will need an **endpoint** and an **API key** to instantiate a client object.  

#### Get Subscription Key

You can obtain the endpoint and API key from the resource information in the [Azure Portal][azure_portal].

Alternatively, you can use the [Azure CLI][azure_cli] snippet below to get the API key from the Form Recognizer resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create `FormRecognizerClient` with Azure Key Credential
Once you have the value for the API key, create an `AzureKeyCredential`.  With the endpoint and key credential, you can create the [FormRecognizerClient][form_recognizer_client_class]:

```C# Snippet:CreateFormRecognizerClient
```


## Key concepts

### FormRecognizerClient

`FormRecognizerClient` provides operations for:

 - Recognizing form fields and content, using custom models trained to recognize your custom forms.  These values are returned in a collection of `RecognizedForm` objects.
 - Recognizing form content, including tables, lines and words, without having to train a model.  These values are returned in a collection of `RecognizedPage` objects.
 - Recognizing common fields from US receipts, using a pre-trained receipt model on the Form Recognizer service.  These values are returned in a collection of `RecognizeReceipt` objects.

### FormTrainingClient

`FormTrainingClient` provides operations for:

- Training custom models to recognize all fields and values found in your custom forms.  A `CustomFormModel` is returned indicating the form types the model will recognize, and the fields it will extract for each form type.
- Training custom models to recognize specific fields and values you specify by labeling your custom forms.  A `CustomFormModel` is returned indicating the fields the model will extract, as well as the estimated accuracy for each field.
- Managing models created in your account.

Please note that models can also be trained using a graphical user interface such as the [Form Recognizer Labeling Tool][labeling_tool].

### Long-Running Operations

Because analyzing and training form documents takes time, these operations are implemented as [*long-running operations*][dotnet_lro_guidelines].  Long-running operations consist of an initial request sent to the service to start an operation, followed by polling the service at intervals to determine whether the operation has completed or failed, and if it has succeeded, to get the result.

For long running operations in the Azure SDK, the client exposes a `Start<operation-name>` method that returns an `Operation<T>`.  You can use the extension method `WaitForCompletionAsync()` to wait for the operation to complete and obtain its result.  A sample code snippet is provided to illustrate using long-running operations [below](#extracting-receipt-values-with-a-long-running-operation).

## Examples
The following section provides several code snippets illustrating common patterns used in the Form Recognizer .NET API.

* [Recognize Receipts](#recognize-receipts)
* [Recognize Content](#recognize-content)
* [Recognize Custom Forms](#recognize-custom-forms)
* [Train with Forms Only](#train-with-forms-only)
* [Train with Forms and Labels](#train-with-forms-and-labels)
* [Manage Custom Forms](#manage-custom-forms)

### Recognize Receipts
```C# Snippet:FormRecognizerSample1CreateClient
```

### Recognize Content
```C#
```

### Recognize Custom Forms
```C#
```

### Train with Forms Only
```C#
```

### Train with Forms and Labels
```C#
```

### Manage Custom Forms
```C#
```


## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftextanalytics%2FAzure.AI.TextAnalytics%2FREADME.png)


<!-- LINKS -->
[formreco_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/src
[formreco_docs]: https://docs.microsoft.com/en-us/azure/cognitive-services/form-recognizer/
[formreco_refdocs]: https://aka.ms/azsdk-net-textanalytics-ref-docs
<!-- [formreco_nuget_package]: https://www.nuget.org/packages/Azure.AI.TextAnalytics -->
<!-- [formreco_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples -->
[formreco_rest_api]: https://westus2.dev.cognitive.microsoft.com/docs/services/form-recognizer-api-v2-preview
[cognitive_resource]: https://docs.microsoft.com/en-us/azure/cognitive-services/cognitive-services-apis-create-account


[form_recognizer_client_class]: src/FormRecognizerClient.cs
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[cognitive_auth]: https://docs.microsoft.com/en-us/azure/cognitive-services/authentication
[register_aad_app]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[aad_grant_access]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: ../../identity/Azure.Identity/README.md

[labeling_tool]: https://docs.microsoft.com/en-us/azure/cognitive-services/form-recognizer/quickstarts/label-tool
[dotnet_lro_guidelines]: https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning

<!-- [detect_language_sample0]: tests/samples/Sample1_DetectLanguage.cs
[detect_language_sample1]: tests/samples/Sample1_DetectLanguageBatchConvenience.cs
[detect_language_sample2]: tests/samples/Sample1_DetectLanguageBatch.cs
[detect_language_sample_async]: tests/samples/Sample1_DetectLanguageAsync.cs
[analyze_sentiment_sample0]: tests/samples/Sample2_AnalyzeSentiment.cs
[analyze_sentiment_sample1]: tests/samples/Sample2_AnalyzeSentimentBatchConvenience.cs
[analyze_sentiment_sample2]: tests/samples/Sample2_AnalyzeSentimentBatch.cs
[extract_key_phrases_sample0]: tests/samples/Sample3_ExtractKeyPhrases.cs
[extract_key_phrases_sample1]: tests/samples/Sample3_ExtractKeyPhrasesBatchConvenience.cs
[extract_key_phrases_sample2]: tests/samples/Sample3_ExtractKeyPhrasesBatch.cs
[recognize_entities_sample0]: tests/samples/Sample4_RecognizeEntities.cs
[recognize_entities_sample1]: tests/samples/Sample4_RecognizeEntitiesBatchConvenience.cs
[recognize_entities_sample2]: tests/samples/Sample4_RecognizeEntitiesBatch.cs
[recognize_entities_sample_async]: tests/samples/Sample4_RecognizeEntitiesAsync.cs
[recognize_pii_entities_sample0]: tests/samples/Sample5_RecognizePiiEntities.cs
[recognize_pii_entities_sample1]: tests/samples/Sample5_RecognizePiiEntitiesBatch.cs
[recognize_pii_entities_sample2]: tests/samples/Sample5_RecognizePiiEntitiesBatchConvenience.cs
[recognize_linked_entities_sample0]: tests/samples/Sample6_RecognizeLinkedEntities.cs
[recognize_linked_entities_sample1]: tests/samples/Sample6_RecognizeLinkedEntitiesBatch.cs
[recognize_linked_entities_sample2]: tests/samples/Sample6_RecognizeLinkedEntitiesBatchConvenience.cs -->

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com