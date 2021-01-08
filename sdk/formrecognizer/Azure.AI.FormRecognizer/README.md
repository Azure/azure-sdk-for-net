# Azure Cognitive Services Form Recognizer client library for .NET
Azure Cognitive Services Form Recognizer is a cloud service that uses machine learning to recognize form fields, text, and tables in form documents.  It includes the following capabilities:

- Recognize Custom Forms - Recognize and extract form fields and other content from your custom forms, using models you trained with your own form types.
- Recognize Form Content - Recognize and extract tables, lines, words, and selection marks like radio buttons and check boxes in form documents, without the need to train a model.
- Recognize Prebuilt models - Recognize data using the following prebuilt models:
  - Receipts - Recognize and extract common fields from receipts, using a pre-trained receipt model.
  - Business Cards - Recognize and extract common fields from business cards, using a pre-trained business cards model.
  - Invoices - Recognize and extract common fields from invoices, using a pre-trained invoice model.

[Source code][formreco_client_src] | [Package (NuGet)][formreco_nuget_package] | [API reference documentation][formreco_refdocs] | [Product documentation][formreco_docs] | [Samples][formreco_samples]

## Getting started

### Install the package
Install the Azure Form Recognizer client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.AI.FormRecognizer
``` 

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
# Create a new resource group to hold the form recognizer resource
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

### Authenticate the client
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

- Recognizing form fields and content, using custom models trained to recognize your custom forms.  These values are returned in a collection of `RecognizedForm` objects. See example [Recognize Custom Forms](#recognize-custom-forms).
- Recognizing form content, including tables, lines, words, and selection marks like radio buttons and check boxes without the need to train a model.  Form content is returned in a collection of `FormPage` objects. See example [Recognize Content](#recognize-content).
- Recognizing common fields from the following form types using prebuilt models. These fields and meta-data are returned in a collection of `RecognizedForm` objects.
  - Sales receipts. See example [Recognize Receipts](#recognize-receipts).
  - Business cards. See example [Recognize Business Cards](#recognize-business-cards).
  - Invoices. See example [Recognize Invoices](#recognize-invoices).

### FormTrainingClient

`FormTrainingClient` provides operations for:

- Training custom models to recognize all fields and values found in your custom forms.  A `CustomFormModel` is returned indicating the form types the model will recognize, and the fields it will extract for each form type.
- Training custom models to recognize specific fields and values you specify by labeling your custom forms.  A `CustomFormModel` is returned indicating the fields the model will extract, as well as the estimated accuracy for each field.
- Managing models created in your account.
- Copying a custom model from one Form Recognizer resource to another.
- Creating a composed model from a collection of existing models trained with labels.

See examples for [Train a Model](#train-a-model) and [Manage Custom Models](#manage-custom-models).

Please note that models can also be trained using a graphical user interface such as the [Form Recognizer Labeling Tool][labeling_tool].

### Long-Running Operations

Because analyzing and training form documents takes time, these operations are implemented as [**long-running operations**][dotnet_lro_guidelines].  Long-running operations consist of an initial request sent to the service to start an operation, followed by polling the service at intervals to determine whether the operation has completed or failed, and if it has succeeded, to get the result.

For long running operations in the Azure SDK, the client exposes a `Start<operation-name>` method that returns an `Operation<T>`.  You can use the extension method `WaitForCompletionAsync()` to wait for the operation to complete and obtain its result.  A sample code snippet is provided to illustrate using long-running operations [below](#recognize-content).

## Examples
The following section provides several code snippets illustrating common patterns used in the Form Recognizer .NET API. Most of the snippets below make use of asynchronous service calls, but keep in mind that the Azure.AI.FormRecognizer package supports both synchronous and asynchronous APIs.

### Async examples
* [Recognize Content](#recognize-content)
* [Recognize Custom Forms](#recognize-custom-forms)
* [Recognize Receipts](#recognize-receipts)
* [Recognize Business Cards](#recognize-business-cards)
* [Recognize Invoices](#recognize-invoices)
* [Train a Model](#train-a-model)
* [Manage Custom Models](#manage-custom-models)

### Sync examples
* [Manage Custom Models Synchronously](#manage-custom-models-synchronously)

### Recognize Content
Recognize text, tables, and selection marks like radio buttons and check boxes data, along with their bounding box coordinates, from documents.

```C# Snippet:FormRecognizerSampleRecognizeContentFromUri
Uri formUri = <formUri>;

Response<FormPageCollection> response = await client.StartRecognizeContentFromUriAsync(formUri).WaitForCompletionAsync();
FormPageCollection formPages = response.Value;

foreach (FormPage page in formPages)
{
    Console.WriteLine($"Form Page {page.PageNumber} has {page.Lines.Count} lines.");

    for (int i = 0; i < page.Lines.Count; i++)
    {
        FormLine line = page.Lines[i];
        Console.WriteLine($"  Line {i} has {line.Words.Count} {(line.Words.Count == 1 ? "word" : "words")}, and text: '{line.Text}'.");

        Console.WriteLine("    Its bounding box is:");
        Console.WriteLine($"    Upper left => X: {line.BoundingBox[0].X}, Y= {line.BoundingBox[0].Y}");
        Console.WriteLine($"    Upper right => X: {line.BoundingBox[1].X}, Y= {line.BoundingBox[1].Y}");
        Console.WriteLine($"    Lower right => X: {line.BoundingBox[2].X}, Y= {line.BoundingBox[2].Y}");
        Console.WriteLine($"    Lower left => X: {line.BoundingBox[3].X}, Y= {line.BoundingBox[3].Y}");
    }

    for (int i = 0; i < page.Tables.Count; i++)
    {
        FormTable table = page.Tables[i];
        Console.WriteLine($"  Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");
        foreach (FormTableCell cell in table.Cells)
        {
            Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) contains text: '{cell.Text}'.");
        }
    }

    for (int i = 0; i < page.SelectionMarks.Count; i++)
    {
        FormSelectionMark selectionMark = page.SelectionMarks[i];
        Console.WriteLine($"  Selection Mark {i} is {selectionMark.State}.");
        Console.WriteLine("    Its bounding box is:");
        Console.WriteLine($"      Upper left => X: {selectionMark.BoundingBox[0].X}, Y= {selectionMark.BoundingBox[0].Y}");
        Console.WriteLine($"      Upper right => X: {selectionMark.BoundingBox[1].X}, Y= {selectionMark.BoundingBox[1].Y}");
        Console.WriteLine($"      Lower right => X: {selectionMark.BoundingBox[2].X}, Y= {selectionMark.BoundingBox[2].Y}");
        Console.WriteLine($"      Lower left => X: {selectionMark.BoundingBox[3].X}, Y= {selectionMark.BoundingBox[3].Y}");
    }
}
```
For more information and samples see [here][recognize_content].

### Recognize Custom Forms
Recognize and extract form fields and other content from your custom forms, using models you train with your own form types.

```C# Snippet:FormRecognizerSampleRecognizeCustomFormsFromUri
string modelId = "<modelId>";
Uri formUri = <formUri>;

RecognizeCustomFormsOperation operation = await client.StartRecognizeCustomFormsFromUriAsync(modelId, formUri);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection forms = operationResponse.Value;

foreach (RecognizedForm form in forms)
{
    Console.WriteLine($"Form of type: {form.FormType}");
    if (form.FormTypeConfidence.HasValue)
        Console.WriteLine($"Form type confidence: {form.FormTypeConfidence.Value}");
    Console.WriteLine($"Form was analyzed with model with ID: {form.ModelId}");
    foreach (FormField field in form.Fields.Values)
    {
        Console.WriteLine($"Field '{field.Name}': ");

        if (field.LabelData != null)
        {
            Console.WriteLine($"  Label: '{field.LabelData.Text}'");
        }

        Console.WriteLine($"  Value: '{field.ValueData.Text}'");
        Console.WriteLine($"  Confidence: '{field.Confidence}'");
    }
}
```
For more information and samples see [here][recognize_custom_forms].

### Recognize Receipts
Recognize data from sales receipts using a prebuilt model. Receipt fields recognized by the service can be found [here][service_recognize_receipt_fields].

```C# Snippet:FormRecognizerSampleRecognizeReceiptFileStream
string receiptPath = "<receiptPath>";

using var stream = new FileStream(receiptPath, FileMode.Open);
var options = new RecognizeReceiptsOptions() { Locale = "en-US" };

RecognizeReceiptsOperation operation = await client.StartRecognizeReceiptsAsync(stream, options);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection receipts = operationResponse.Value;

// To see the list of the supported fields returned by service and its corresponding types, consult:
// https://aka.ms/formrecognizer/receiptfields

foreach (RecognizedForm receipt in receipts)
{
    if (receipt.Fields.TryGetValue("MerchantName", out FormField merchantNameField))
    {
        if (merchantNameField.Value.ValueType == FieldValueType.String)
        {
            string merchantName = merchantNameField.Value.AsString();

            Console.WriteLine($"Merchant Name: '{merchantName}', with confidence {merchantNameField.Confidence}");
        }
    }

    if (receipt.Fields.TryGetValue("TransactionDate", out FormField transactionDateField))
    {
        if (transactionDateField.Value.ValueType == FieldValueType.Date)
        {
            DateTime transactionDate = transactionDateField.Value.AsDate();

            Console.WriteLine($"Transaction Date: '{transactionDate}', with confidence {transactionDateField.Confidence}");
        }
    }

    if (receipt.Fields.TryGetValue("Items", out FormField itemsField))
    {
        if (itemsField.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField itemField in itemsField.Value.AsList())
            {
                Console.WriteLine("Item:");

                if (itemField.Value.ValueType == FieldValueType.Dictionary)
                {
                    IReadOnlyDictionary<string, FormField> itemFields = itemField.Value.AsDictionary();

                    if (itemFields.TryGetValue("Name", out FormField itemNameField))
                    {
                        if (itemNameField.Value.ValueType == FieldValueType.String)
                        {
                            string itemName = itemNameField.Value.AsString();

                            Console.WriteLine($"  Name: '{itemName}', with confidence {itemNameField.Confidence}");
                        }
                    }

                    if (itemFields.TryGetValue("TotalPrice", out FormField itemTotalPriceField))
                    {
                        if (itemTotalPriceField.Value.ValueType == FieldValueType.Float)
                        {
                            float itemTotalPrice = itemTotalPriceField.Value.AsFloat();

                            Console.WriteLine($"  Total Price: '{itemTotalPrice}', with confidence {itemTotalPriceField.Confidence}");
                        }
                    }
                }
            }
        }
    }

    if (receipt.Fields.TryGetValue("Total", out FormField totalField))
    {
        if (totalField.Value.ValueType == FieldValueType.Float)
        {
            float total = totalField.Value.AsFloat();

            Console.WriteLine($"Total: '{total}', with confidence '{totalField.Confidence}'");
        }
    }
}
```
For more information and samples see [here][recognize_receipts].

### Recognize Business Cards
Recognize data from business cards using a prebuilt model. Business card fields recognized by the service can be found [here][service_recognize_business_cards_fields].

```C# Snippet:FormRecognizerSampleRecognizeBusinessCardFileStream
string businessCardsPath = "<businessCardsPath>";

using var stream = new FileStream(businessCardsPath, FileMode.Open);
var options = new RecognizeBusinessCardsOptions() { Locale = "en-US" };

RecognizeBusinessCardsOperation operation = await client.StartRecognizeBusinessCardsAsync(stream, options);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection businessCards = operationResponse.Value;

// To see the list of the supported fields returned by service and its corresponding types, consult:
// https://aka.ms/formrecognizer/businesscardfields

foreach (RecognizedForm businessCard in businessCards)
{
    if (businessCard.Fields.TryGetValue("ContactNames", out FormField contactNamesField))
    {
        if (contactNamesField.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField contactNameField in contactNamesField.Value.AsList())
            {
                Console.WriteLine($"Contact Name: {contactNameField.ValueData.Text}");

                if (contactNameField.Value.ValueType == FieldValueType.Dictionary)
                {
                    IReadOnlyDictionary<string, FormField> contactNameFields = contactNameField.Value.AsDictionary();

                    if (contactNameFields.TryGetValue("FirstName", out FormField firstNameField))
                    {
                        if (firstNameField.Value.ValueType == FieldValueType.String)
                        {
                            string firstName = firstNameField.Value.AsString();

                            Console.WriteLine($"  First Name: '{firstName}', with confidence {firstNameField.Confidence}");
                        }
                    }

                    if (contactNameFields.TryGetValue("LastName", out FormField lastNameField))
                    {
                        if (lastNameField.Value.ValueType == FieldValueType.String)
                        {
                            string lastName = lastNameField.Value.AsString();

                            Console.WriteLine($"  Last Name: '{lastName}', with confidence {lastNameField.Confidence}");
                        }
                    }
                }
            }
        }
    }

    if (businessCard.Fields.TryGetValue("Emails", out FormField emailFields))
    {
        if (emailFields.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField emailField in emailFields.Value.AsList())
            {
                if (emailField.Value.ValueType == FieldValueType.String)
                {
                    string email = emailField.Value.AsString();

                    Console.WriteLine($"Email: '{email}', with confidence {emailField.Confidence}");
                }
            }
        }
    }
}
```
For more information and samples see [here][recognize_business_cards].

### Recognize Invoices
Recognize data from invoices using a prebuilt model. Invoices fields recognized by the service can be found [here][service_recognize_invoices_fields].

```C# Snippet:FormRecognizerSampleRecognizeInvoicesFileStream
string invoicePath = "<invoicePath>";

using var stream = new FileStream(invoicePath, FileMode.Open);
var options = new RecognizeInvoicesOptions() { Locale = "en-US" };

RecognizeInvoicesOperation operation = await client.StartRecognizeInvoicesAsync(stream, options);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection invoices = operationResponse.Value;

// To see the list of the supported fields returned by service and its corresponding types, consult:
// https://aka.ms/formrecognizer/invoicefields

RecognizedForm invoice = invoices.Single();

if (invoice.Fields.TryGetValue("VendorName", out FormField vendorNameField))
{
    if (vendorNameField.Value.ValueType == FieldValueType.String)
    {
        string vendorName = vendorNameField.Value.AsString();
        Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
    }
}

if (invoice.Fields.TryGetValue("CustomerName", out FormField customerNameField))
{
    if (customerNameField.Value.ValueType == FieldValueType.String)
    {
        string customerName = customerNameField.Value.AsString();
        Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
    }
}

if (invoice.Fields.TryGetValue("InvoiceTotal", out FormField invoiceTotalField))
{
    if (invoiceTotalField.Value.ValueType == FieldValueType.Float)
    {
        float invoiceTotal = invoiceTotalField.Value.AsFloat();
        Console.WriteLine($"Invoice Total: '{invoiceTotal}', with confidence {invoiceTotalField.Confidence}");
    }
}
```
For more information and samples see [here][recognize_invoices].


### Train a Model
Train a machine-learned model on your own form types. The resulting model will be able to recognize values from the types of forms it was trained on.

```C# Snippet:FormRecognizerSampleTrainModelWithForms
// For this sample, you can use the training forms found in the `trainingFiles` folder.
// Upload the forms to your storage container and then generate a container SAS URL.
// For instructions on setting up forms for training in an Azure Storage Blob Container, see
// https://docs.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data

Uri trainingFileUri = <trainingFileUri>;
FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

TrainingOperation operation = await client.StartTrainingAsync(trainingFileUri, useTrainingLabels: false, "My Model");
Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
CustomFormModel model = operationResponse.Value;

Console.WriteLine($"Custom Model Info:");
Console.WriteLine($"  Model Id: {model.ModelId}");
Console.WriteLine($"  Model name: {model.ModelName}");
Console.WriteLine($"  Model Status: {model.Status}");
Console.WriteLine($"  Is composed model: {model.Properties.IsComposedModel}");
Console.WriteLine($"  Training model started on: {model.TrainingStartedOn}");
Console.WriteLine($"  Training model completed on: {model.TrainingCompletedOn}");

foreach (CustomFormSubmodel submodel in model.Submodels)
{
    Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
    foreach (CustomFormModelField field in submodel.Fields.Values)
    {
        Console.Write($"  FieldName: {field.Name}");
        if (field.Label != null)
        {
            Console.Write($", FieldLabel: {field.Label}");
        }
        Console.WriteLine("");
    }
}
```
For more information and samples see [here][train_a_model].

### Manage Custom Models
Manage the custom models stored in your account.

```C# Snippet:FormRecognizerSampleManageCustomModelsAsync
FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

// Check number of models in the FormRecognizer account, and the maximum number of models that can be stored.
AccountProperties accountProperties = await client.GetAccountPropertiesAsync();
Console.WriteLine($"Account has {accountProperties.CustomModelCount} models.");
Console.WriteLine($"It can have at most {accountProperties.CustomModelLimit} models.");

// List the models currently stored in the account.
AsyncPageable<CustomFormModelInfo> models = client.GetCustomModelsAsync();

await foreach (CustomFormModelInfo modelInfo in models)
{
    Console.WriteLine($"Custom Model Info:");
    Console.WriteLine($"  Model Id: {modelInfo.ModelId}");
    Console.WriteLine($"  Model name: {modelInfo.ModelName}");
    Console.WriteLine($"  Is composed model: {modelInfo.Properties.IsComposedModel}");
    Console.WriteLine($"  Model Status: {modelInfo.Status}");
    Console.WriteLine($"  Training model started on: {modelInfo.TrainingStartedOn}");
    Console.WriteLine($"  Training model completed on: : {modelInfo.TrainingCompletedOn}");
}

// Create a new model to store in the account
Uri trainingFileUri = <trainingFileUri>;
TrainingOperation operation = await client.StartTrainingAsync(trainingFileUri, useTrainingLabels: false, "My new model");
Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
CustomFormModel model = operationResponse.Value;

// Get the model that was just created
CustomFormModel modelCopy = await client.GetCustomModelAsync(model.ModelId);

Console.WriteLine($"Custom Model with Id {modelCopy.ModelId}  and name {modelCopy.ModelName} recognizes the following form types:");

foreach (CustomFormSubmodel submodel in modelCopy.Submodels)
{
    Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
    foreach (CustomFormModelField field in submodel.Fields.Values)
    {
        Console.Write($"  FieldName: {field.Name}");
        if (field.Label != null)
        {
            Console.Write($", FieldLabel: {field.Label}");
        }
        Console.WriteLine("");
    }
}

// Delete the model from the account.
await client.DeleteModelAsync(model.ModelId);
```
For more information and samples see [here][manage_custom_models].

### Manage Custom Models Synchronously
Manage the custom models stored in your account with a synchronous API. Note that we are still making an asynchronous call to `WaitForCompletionAsync` for training, since this method does not have a synchronous counterpart. For more information on long-running operations, see [Long-Running Operations](#long-running-operations).

```C# Snippet:FormRecognizerSampleManageCustomModels
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
    Console.WriteLine($"  Model Id: {modelInfo.ModelId}");
    Console.WriteLine($"  Model name: {modelInfo.ModelName}");
    Console.WriteLine($"  Is composed model: {modelInfo.Properties.IsComposedModel}");
    Console.WriteLine($"  Model Status: {modelInfo.Status}");
    Console.WriteLine($"  Training model started on: {modelInfo.TrainingStartedOn}");
    Console.WriteLine($"  Training model completed on: {modelInfo.TrainingCompletedOn}");
}

// Create a new model to store in the account

Uri trainingFileUri = <trainingFileUri>;
TrainingOperation operation = client.StartTraining(trainingFileUri, useTrainingLabels: false, "My new model");
Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
CustomFormModel model = operationResponse.Value;

// Get the model that was just created
CustomFormModel modelCopy = client.GetCustomModel(model.ModelId);

Console.WriteLine($"Custom Model with Id {modelCopy.ModelId}  and name {modelCopy.ModelName} recognizes the following form types:");

foreach (CustomFormSubmodel submodel in modelCopy.Submodels)
{
    Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
    foreach (CustomFormModelField field in submodel.Fields.Values)
    {
        Console.Write($"  FieldName: {field.Name}");
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
- [Recognize business cards][recognize_business_cards]
- [Recognize invoices][recognize_invoices]
- [Train a model][train_a_model]
- [Manage custom models][manage_custom_models]
- [Copy a custom model between Form Recognizer resources][copy_custom_models]
- [Create composed model from a collection of models trained with labels][composed_model]

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fformrecognizer%2FAzure.AI.FormRecognizer%2FREADME.png)


<!-- LINKS -->
[formreco_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/src
[formreco_docs]: https://docs.microsoft.com/azure/cognitive-services/form-recognizer/
[formreco_refdocs]: https://aka.ms/azsdk/net/docs/ref/formrecognizer
[formreco_nuget_package]: https://www.nuget.org/packages/Azure.AI.FormRecognizer
[formreco_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/README.md
[formreco_rest_api]: https://westus2.dev.cognitive.microsoft.com/docs/services/form-recognizer-api-v2
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
[service_recognize_receipt_fields]: https://aka.ms/formrecognizer/receiptfields
[service_recognize_business_cards_fields]: https://aka.ms/formrecognizer/businesscardfields
[service_recognize_invoices_fields]: https://aka.ms/formrecognizer/invoicefields
[dotnet_lro_guidelines]: https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning

[logging]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/samples/Diagnostics.md

[recognize_content]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample1_RecognizeFormContent.md
[recognize_custom_forms]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample2_RecognizeCustomForms.md
[recognize_receipts]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample3_RecognizeReceipts.md
[recognize_business_cards]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample9_RecognizeBusinessCards.md
[recognize_invoices]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample10_RecognizeInvoices.md
[train_a_model]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample5_TrainModel.md
[manage_custom_models]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample6_ManageCustomModels.md
[copy_custom_models]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample7_CopyCustomModel.md
[composed_model]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample8_ModelCompose.md

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
