# Azure Cognitive Services Form Recognizer client library for .NET
Azure Cognitive Services Form Recognizer is a cloud service that uses machine learning to extract text and table data from form documents. It allows you to train custom models using your own forms, to extract field names and values, and table data from them.  It also provides a prebuilt models you can use to extract values from receipts, or tables from any form.

[Source code][formreco_client_src] | <!--[Package (NuGet)]() | [API reference documentation]() |--> [Product documentation][formreco_docs] <!--| [Samples]()-->

## Getting started

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Form Recognizer resource. If you need to create the resource, you can use the [Azure Portal][azure_portal] or [Azure CLI][azure_cli].
<!-- 
If you use the Azure CLI, replace `<your-resource-group-name>`, `<your-resource-name>`, `<location>`, and `<sku>` with your values:

```PowerShell
az cognitiveservices account create --kind TextAnalytics --resource-group <your-resource-group-name> --name <your-resource-name> --location <location> --sku <sku>
``` -->
<!-- 
### Install the package
Install the Azure Text Analytics client library for .NET with [NuGet][nuget].  To use the [.NET CLI](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli), run the following command from PowerShell in the directory that contains your project file:

```PowerShell
dotnet add package Azure.AI.TextAnalytics --version 1.0.0-preview.1
``` 
For other installation methods, please see the package information on [NuGet][nuget].
-->

### Authenticate a Form Recognizer client
In order to interact with the Form Recognizer service, you'll need to select either a `ReceiptClient`, `FormLayoutClient`, or `CustomFormClient`, and create an instance of this class.  In the following samples, we will use CustomFormClient as an example.  You will need an **endpoint**, and either an **API key** or ``TokenCredential`` to instantiate a client object.  For more information regarding authenticating with cognitive services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get Subscription Key

You can obtain the endpoint and subscription key from the resource information in the [Azure Portal][azure_portal].

Alternatively, you can use the [Azure CLI][azure_cli] snippet below to get the subscription key from the Form Recognizer resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create CustomFormClient with Subscription Key Credential
Once you have the value for the subscription key, create a `FormRecognizerApiKeyCredential`. This will allow you to update the subscription key by using the `UpdateCredential` method without creating a new client.

With the value of the endpoint and a `FormRecognizerApiKeyCredential`, you can create the [CustomFormClient][formreco_custom_client_class]:

```C#
string endpoint = "<endpoint>";
string subscriptionKey = "<subscriptionKey>";
var credential = new FormRecognizerApiKeyCredential(subscriptionKey);
var client = new CustomFormClient(new Uri(endpoint), credential);
```

<!-- #### Create CustomFormClient with Azure Active Directory Credential

Client subscription key authentication is used in most of the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity].  Note that regional endpoints do not support AAD authentication. Create a [custom subdomain][custom_subdomain] for your resource in order to use this type of authentication.  

To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below,
or other credential providers provided with the Azure SDK, please install the Azure.Identity package:

```PowerShell
Install-Package Azure.Identity
```

You will also need to [register a new AAD application][register_aad_app] and [grant access][aad_grant_access] to Text Analytics by assigning the `"Cognitive Services User"` role to your service principal.

Set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

```
string endpoint = "<endpoint>";
var client = new TextAnalyticsClient(new Uri(endpoint), new DefaultAzureCredential());
``` -->

## Key concepts

### ReceiptClient
A `ReceiptClient` is the Form Recognizer interface to use for analyzing receipts.  It provides operations to extract receipt field values and locations from receipts from the United States.

### FormLayoutClient
A `FormLayoutClient` is the Form Recognizer interface to extract layout items from forms.  It provides operations to extract table data and geometry.

### CustomFormClient
A `CustomFormClient` is the Form Recognizer interface to use for creating, using, and managing custom machine-learned models. It provides operations for training models on forms you provide, and extracting field values and locations from your custom forms.  It also provides operations for viewing and deleting models, as well as understanding how close you are to reaching subscription limits for the number of models you can train.

### Long-Running Operations
Long-running operations are operations which consist of an initial request sent to the service to start an operation,followed by polling the service at intervals to determine whether the operation has completed or failed, and if it has succeeded, to get the result.

Methods that train models or extract values from forms are modeled as long-running operations.  The client exposes a `Start<operation-name>` method that returns an `Operation<T>`.  Callers should wait for the operation to complete by calling `WaitForCompletionAsync()` on the operation returned from the `Start<operation-name>` method.  A sample code snippet is provided to illustrate using long-running operations [below](#extracting-receipt-values-with-a-long-running-operation).

### Training models
Using the `CustomFormClient`, you can train a machine-learned model on your own form type.  The resulting model will be able to extract values from the types of forms it was trained on.

#### Training without labels
A model trained without labels uses unsupervised learning to understand the layout and relationships between field names and values in your forms. The learning algorithm clusters the training forms by type and learns what fields and tables are present in each form type. 

This approach doesn't require manual data labeling or intensive coding and maintenance, and we recommend you try this method first when training custom models.

#### Training with labels
A model trained with labels uses supervised learning to extract values you specify by adding labels to your training forms.  The learning algorithm uses a label file you provide to learn what fields are found at various locations in the form, and learns to extract just those values.

This approach can result in better-performing models, and those models can work with more complex form structures.

### Extracting values from forms
Using the `CustomFormClient`, you can use your own trained models to extract field values and locations, as well as table data, from forms of the type you trained your models on.  The output of models trained with and without labels differs as described below.

#### Using models trained without labels
Models trained without labels consider each form page to be a different form type.  For example, if you train your model on 3-page forms, it will learn that these are three different types of forms.  When you send a form to it for analysis, it will return a collection of three pages, where each page contains the field names, values, and locations, as well as table data, found on that page.

#### Using models trained with labels
Models trained with labels consider a form as a single unit.  For example, if you train your model on 3-page forms with labels, it will learn to extract field values from the locations you've labeled across all pages in the form.  If you sent a document containing two forms to it for analysis, it would return a collection of two forms, where each form contains the field names, values, and locations, as well as table data, found in that form.  Fields and tables have page numbers to identify the pages where they were found.

### Managing Custom Models
Using the `CustomFormClient`, you can get, list, and delete the custom models you've trained.  You can also view the count of models you've trained and the maximum number of models your subscription will allow you to store.

## Examples
The following section provides several code snippets illustrating common patterns used in the Form Recognizer .NET API.

### Extracting receipt values with a long-running operation
```C#
string endpoint = "<endpoint>";
string subscriptionKey = "<subscriptionKey>";
var credential = new FormRecognizerApiKeyCredential(subscriptionKey);
var client = new ReceiptClient(new Uri(endpoint), credential);

using (FileStream stream = new FileStream(@"C:\path\to\receipt.jpg", FileMode.Open))
{
    var extractReceiptOperation = client.StartExtractReceipts(stream, FormContentType.Jpeg);
    await extractReceiptOperation.WaitForCompletionAsync();
    if (extractReceiptOperation.HasValue)
    {
        IReadOnlyList<ExtractedReceipt> result = extractReceiptOperation.Value;
    }
}
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

<!-- [language_detection]: https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-language-detection
[sentiment_analysis]: https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-sentiment-analysis
[key_phrase_extraction]: https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-keyword-extraction
[named_entity_recognition]: https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-entity-linking -->


[formreco_custom_client_class]: src/CustomFormClient.cs
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[cognitive_auth]: https://docs.microsoft.com/en-us/azure/cognitive-services/authentication
[register_aad_app]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[aad_grant_access]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: ../../identity/Azure.Identity/README.md

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