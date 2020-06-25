# Azure Cognitive Services Form Recognizer client library for .NET
Azure Cognitive Services Form Recognizer is a cloud service that uses machine learning to recognize form fields, text, and tables in form documents.  It includes the following capabilities:

- Recognize Custom Forms - Recognize and extract form fields and other content from your custom forms, using models you trained with your own form types.
- Recognize Form Content - Recognize and extract tables, lines and words in forms documents, without the need to train a model.
- Recognize Receipts - Recognize and extract common fields from US receipts, using a pre-trained receipt model.

[Source code][formreco_client_src] | [Package (NuGet)][formreco_nuget_package] | [API reference documentation][formreco_refdocs] | [Product documentation][formreco_docs] | [Samples][formreco_samples]

## Getting started

### Install the package
Install the Azure Form Recognizer client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.AI.FormRecognizer --version 1.0.0-preview.3
``` 

**Note:** This package version targets Azure Form Recognizer service API version v2.0-preview.

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Cognitive Services or Form Recognizer resource.

#### Create a Cognitive Services or Form Recognizer resource
Form Recognizer supports both [multi-service and single-service access][cognitive_resource_portal]. Create a Cognitive Services resource if you plan to access multiple cognitive services under a single endpoint/key. For Form Recognizer access only, create a Form Recognizer resource.

You can create either resource using: 

**Option 1:** [Azure Portal][cognitive_resource_portal].

**Option 2:** [Azure CLI][cognitive_resource_cli]. 


Below is an example of how you can create a Form Recognizer resource using the CLI:

```PowerShell
# Create a new resource group to hold the form recognizer resource -
# if using an existing resource group, skip this step
az group create --name <your-resource-name> --location <location>
```

```PowerShell
# Create form recognizer 
az cognitiveservices account create \
    --name <your-resource-name> \
    --resource-group <your-resource-group-name> \
    --kind FormRecognizer \
    --sku <sku> \
    --location <location> \
    --yes
```
For more information about creating the resource or how to get the location and sku information see [here][cognitive_resource_cli].

### Authenticate a Form Recognizer client
In order to interact with the Form Recognizer service, you'll need to create an instance of the [`FormRecognizerClient`][form_recognizer_client_class] class.  You will need an **endpoint** and an **API key** to instantiate a client object.  

#### Get API Key

You can obtain the endpoint and API key from the resource information in the [Azure Portal][azure_portal].

Alternatively, you can use the [Azure CLI][azure_cli] snippet below to get the API key from the Form Recognizer resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create FormRecognizerClient with AzureKeyCredential
Once you have the value for the API key, create an `AzureKeyCredential`.  With the endpoint and key credential, you can create the [`FormRecognizerClient`][form_recognizer_client_class]:

```C# Snippet:CreateFormRecognizerClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new FormRecognizerClient(new Uri(endpoint), credential);
```

#### Create FormRecognizerClient with Azure Active Directory Credential

`AzureKeyCredential` authentication is used in the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity]. Note that regional endpoints do not support AAD authentication. Create a [custom subdomain][custom_subdomain] for your resource in order to use this type of authentication.

To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below, or other credential providers provided with the Azure SDK, please install the `Azure.Identity` package:

```PowerShell
Install-Package Azure.Identity
```

You will also need to [register a new AAD application][register_aad_app] and [grant access][aad_grant_access] to Form Recognizer by assigning the `"Cognitive Services User"` role to your service principal.

Set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

```C# Snippet:CreateFormRecognizerClientTokenCredential
string endpoint = "<endpoint>";
var client = new FormRecognizerClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Key concepts

### FormRecognizerClient

`FormRecognizerClient` provides operations for:

 - Recognizing form fields and content, using custom models trained to recognize your custom forms.  These values are returned in a collection of `RecognizedForm` objects.
 - Recognizing form content, including tables, lines and words, without the need to train a model.  Form content is returned in a collection of `FormPage` objects.
 - Recognizing common fields from US receipts, using a pre-trained receipt model on the Form Recognizer service.  These fields and meta-data are returned in a collection of `RecognizeReceipt` objects.

### FormTrainingClient

`FormTrainingClient` provides operations for:

- Training custom models to recognize all fields and values found in your custom forms.  A `CustomFormModel` is returned indicating the form types the model will recognize, and the fields it will extract for each form type.
- Training custom models to recognize specific fields and values you specify by labeling your custom forms.  A `CustomFormModel` is returned indicating the fields the model will extract, as well as the estimated accuracy for each field.
- Managing models created in your account.
- Copying a custom model from one Form Recognizer resource to another.

Please note that models can also be trained using a graphical user interface such as the [Form Recognizer Labeling Tool][labeling_tool].

### Long-Running Operations

Because analyzing and training form documents takes time, these operations are implemented as [**long-running operations**][dotnet_lro_guidelines].  Long-running operations consist of an initial request sent to the service to start an operation, followed by polling the service at intervals to determine whether the operation has completed or failed, and if it has succeeded, to get the result.

For long running operations in the Azure SDK, the client exposes a `Start<operation-name>` method that returns an `Operation<T>`.  You can use the extension method `WaitForCompletionAsync()` to wait for the operation to complete and obtain its result.  A sample code snippet is provided to illustrate using long-running operations [below](#recognize-receipts).

## Examples
The following section provides several code snippets illustrating common patterns used in the Form Recognizer .NET API.

* [Recognize Content](#recognize-content)
* [Recognize Custom Forms](#recognize-custom-forms)
* [Recognize Receipts](#recognize-receipts)
* [Train a Model](#train-a-model)
* [Manage Custom Models](#manage-custom-models)

### Recognize Content
Recognize text and table data, along with their bounding box coordinates, from documents.

```C# Snippet:FormRecognizerSampleRecognizeContentFromUri
FormPageCollection formPages = await client.StartRecognizeContentFromUri(new Uri(invoiceUri)).WaitForCompletionAsync();
foreach (FormPage page in formPages)
{
    Console.WriteLine($"Form Page {page.PageNumber} has {page.Lines.Count} lines.");

    for (int i = 0; i < page.Lines.Count; i++)
    {
        FormLine line = page.Lines[i];
        Console.WriteLine($"    Line {i} has {line.Words.Count} word{(line.Words.Count > 1 ? "s" : "")}, and text: '{line.Text}'.");
    }

    for (int i = 0; i < page.Tables.Count; i++)
    {
        FormTable table = page.Tables[i];
        Console.WriteLine($"Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");
        foreach (FormTableCell cell in table.Cells)
        {
            Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) contains text: '{cell.Text}'.");
        }
    }
}
```

### Recognize Custom Forms
Recognize and extract form fields and other content from your custom forms, using models you train with your own form types.

```C# Snippet:FormRecognizerSample3RecognizeCustomFormsFromUri
string modelId = "<modelId>";

RecognizedFormCollection forms = await client.StartRecognizeCustomFormsFromUri(modelId, new Uri(formUri)).WaitForCompletionAsync();
foreach (RecognizedForm form in forms)
{
    Console.WriteLine($"Form of type: {form.FormType}");
    foreach (FormField field in form.Fields.Values)
    {
        Console.WriteLine($"Field '{field.Name}: ");

        if (field.LabelText != null)
        {
            Console.WriteLine($"    Label: '{field.LabelText.Text}");
        }

        Console.WriteLine($"    Value: '{field.ValueText.Text}");
        Console.WriteLine($"    Confidence: '{field.Confidence}");
    }
}
```

### Recognize Receipts
Recognize data from US sales receipts using a prebuilt model.

```C# Snippet:FormRecognizerSampleRecognizeReceiptFileStream
using (FileStream stream = new FileStream(receiptPath, FileMode.Open))
{
    RecognizedFormCollection receipts = await client.StartRecognizeReceipts(stream).WaitForCompletionAsync();

    // To see the list of the supported fields returned by service and its corresponding types, consult:
    // https://westus2.dev.cognitive.microsoft.com/docs/services/form-recognizer-api-v2-preview/operations/GetAnalyzeReceiptResult

    foreach (RecognizedForm receipt in receipts)
    {
        FormField merchantNameField;
        if (receipt.Fields.TryGetValue("MerchantName", out merchantNameField))
        {
            if (merchantNameField.Value.Type == FieldValueType.String)
            {
                string merchantName = merchantNameField.Value.AsString();

                Console.WriteLine($"Merchant Name: '{merchantName}', with confidence {merchantNameField.Confidence}");
            }
        }

        FormField transactionDateField;
        if (receipt.Fields.TryGetValue("TransactionDate", out transactionDateField))
        {
            if (transactionDateField.Value.Type == FieldValueType.Date)
            {
                DateTime transactionDate = transactionDateField.Value.AsDate();

                Console.WriteLine($"Transaction Date: '{transactionDate}', with confidence {transactionDateField.Confidence}");
            }
        }

        FormField itemsField;
        if (receipt.Fields.TryGetValue("Items", out itemsField))
        {
            if (itemsField.Value.Type == FieldValueType.List)
            {
                foreach (FormField itemField in itemsField.Value.AsList())
                {
                    Console.WriteLine("Item:");

                    if (itemField.Value.Type == FieldValueType.Dictionary)
                    {
                        IReadOnlyDictionary<string, FormField> itemFields = itemField.Value.AsDictionary();

                        FormField itemNameField;
                        if (itemFields.TryGetValue("Name", out itemNameField))
                        {
                            if (itemNameField.Value.Type == FieldValueType.String)
                            {
                                string itemName = itemNameField.Value.AsString();

                                Console.WriteLine($"    Name: '{itemName}', with confidence {itemNameField.Confidence}");
                            }
                        }

                        FormField itemTotalPriceField;
                        if (itemFields.TryGetValue("TotalPrice", out itemTotalPriceField))
                        {
                            if (itemTotalPriceField.Value.Type == FieldValueType.Float)
                            {
                                float itemTotalPrice = itemTotalPriceField.Value.AsFloat();

                                Console.WriteLine($"    Total Price: '{itemTotalPrice}', with confidence {itemTotalPriceField.Confidence}");
                            }
                        }
                    }
                }
            }
        }

        FormField totalField;
        if (receipt.Fields.TryGetValue("Total", out totalField))
        {
            if (totalField.Value.Type == FieldValueType.Float)
            {
                float total = totalField.Value.AsFloat();

                Console.WriteLine($"Total: '{total}', with confidence '{totalField.Confidence}'");
            }
        }
    }
}
```

### Train a Model
Train a machine-learned model on your own form types. The resulting model will be able to recognize values from the types of forms it was trained on.

```C# Snippet:FormRecognizerSample4TrainModelWithForms
// For instructions on setting up forms for training in an Azure Storage Blob Container, see
// https://docs.microsoft.com/azure/cognitive-services/form-recognizer/quickstarts/curl-train-extract#train-a-form-recognizer-model

FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
CustomFormModel model = await client.StartTrainingAsync(new Uri(trainingFileUrl), useTrainingLabels: false).WaitForCompletionAsync();

Console.WriteLine($"Custom Model Info:");
Console.WriteLine($"    Model Id: {model.ModelId}");
Console.WriteLine($"    Model Status: {model.Status}");
Console.WriteLine($"    Requested on: {model.RequestedOn}");
Console.WriteLine($"    Completed on: {model.CompletedOn}");

foreach (CustomFormSubmodel submodel in model.Submodels)
{
    Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
    foreach (CustomFormModelField field in submodel.Fields.Values)
    {
        Console.Write($"    FieldName: {field.Name}");
        if (field.Label != null)
        {
            Console.Write($", FieldLabel: {field.Label}");
        }
        Console.WriteLine("");
    }
}
```

### Manage Custom Models
Manage the custom models stored in your account.

```C# Snippet:FormRecognizerSample6ManageCustomModels
FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

// Check number of models in the FormRecognizer account, and the maximum number of models that can be stored.
AccountProperties accountProperties = client.GetAccountProperties();
Console.WriteLine($"Account has {accountProperties.CustomModelCount} models.");
Console.WriteLine($"It can have at most {accountProperties.CustomModelLimit} models.");

// List the first ten or fewer models currently stored in the account.
Pageable<CustomFormModelInfo> models = client.GetCustomModels();

foreach (CustomFormModelInfo modelInfo in models.Take(10))
{
    Console.WriteLine($"Custom Model Info:");
    Console.WriteLine($"    Model Id: {modelInfo.ModelId}");
    Console.WriteLine($"    Model Status: {modelInfo.Status}");
    Console.WriteLine($"    Requested on: {modelInfo.RequestedOn}");
    Console.WriteLine($"    Completed on: {modelInfo.CompletedOn}");
}

// Create a new model to store in the account
CustomFormModel model = await client.StartTrainingAsync(new Uri(trainingFileUrl), useTrainingLabels: false).WaitForCompletionAsync();

// Get the model that was just created
CustomFormModel modelCopy = client.GetCustomModel(model.ModelId);

Console.WriteLine($"Custom Model {modelCopy.ModelId} recognizes the following form types:");

foreach (CustomFormSubmodel submodel in modelCopy.Submodels)
{
    Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
    foreach (CustomFormModelField field in submodel.Fields.Values)
    {
        Console.Write($"    FieldName: {field.Name}");
        if (field.Label != null)
        {
            Console.Write($", FieldLabel: {field.Label}");
        }
        Console.WriteLine("");
    }
}

// Delete the model from the account.
client.DeleteModel(model.ModelId);
```

## Troubleshooting

### General
When you interact with the Cognitive Services Form Recognizer client library using the .NET SDK, errors returned by the service will result in a `RequestFailedException` with the same HTTP status code returned by the [REST API][formreco_rest_api] request.

For example, if you submit a receipt image with an invalid `Uri`, a `400` error is returned, indicating "Bad Request".

```C# Snippet:FormRecognizerBadRequest
try
{
    RecognizedFormCollection receipts = await client.StartRecognizeReceiptsFromUri(new Uri("http://invalid.uri")).WaitForCompletionAsync();
}
catch (RequestFailedException e)
{
    Console.WriteLine(e.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

```
Message:
    Azure.RequestFailedException: Service request failed.
    Status: 400 (Bad Request)

Content:
    {"error":{"code":"FailedToDownloadImage","innerError":{"requestId":"8ca04feb-86db-4552-857c-fde903251518"},"message":"Failed to download image from input URL."}}

Headers:
    Transfer-Encoding: chunked
    x-envoy-upstream-service-time: REDACTED
    apim-request-id: REDACTED
    Strict-Transport-Security: REDACTED
    X-Content-Type-Options: REDACTED
    Date: Mon, 20 Apr 2020 22:48:35 GMT
    Content-Type: application/json; charset=utf-8
```

### Setting up console logging
The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use the AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [Diagnostics Samples][logging].

## Next steps

Samples showing how to use the Cognitive Services Form Recognizer library are available in this GitHub repository. Samples are provided for each main functional area:

- [Recognize form content][recognize_content]
- [Recognize custom forms][recognize_custom_forms]
- [Recognize receipts][recognize_receipts]
- [Train a model][train_a_model]
- [Manage custom models][manage_custom_models]
- [Copy a custom model between Form Recognizer resources][copy_custom_models]

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fformrecognizer%2FAzure.AI.FormRecognizer%2FREADME.png)


<!-- LINKS -->
[formreco_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/src
[formreco_docs]: https://docs.microsoft.com/azure/cognitive-services/form-recognizer/
[formreco_refdocs]: https://aka.ms/azsdk-net-formrecognizer-ref-docs
[formreco_nuget_package]: https://www.nuget.org/packages/Azure.AI.FormRecognizer
[formreco_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/README.md
[formreco_rest_api]: https://westus2.dev.cognitive.microsoft.com/docs/services/form-recognizer-api-v2-preview
[cognitive_resource]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account


[form_recognizer_client_class]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/src/FormRecognizerClient.cs
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication
[register_aad_app]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[aad_grant_access]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md
[cognitive_resource_portal]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
[cognitive_resource_cli]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli


[labeling_tool]: https://docs.microsoft.com/azure/cognitive-services/form-recognizer/quickstarts/label-tool
[dotnet_lro_guidelines]: https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning

[logging]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/samples/Diagnostics.md

[recognize_content]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample1_RecognizeFormContent.md
[recognize_custom_forms]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample2_RecognizeCustomForms.md
[recognize_receipts]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample3_RecognizeReceipts.md
[train_a_model]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample5_TrainModel.md
[manage_custom_models]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample6_ManageCustomModels.md
[copy_custom_models]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample7_CopyCustomModel.md

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
