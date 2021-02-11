# Recognize custom forms

This sample demonstrates how to recognize form fields and other content from your custom forms, using models you trained with your own form types. For more information on how to do the training, see [train a model][train_a_model]. For a suggested approach to extracting information from custom forms with known fields, see [strongly-typing a recognized form][strongly_typing_a_recognized_form].

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `FormRecognizerClient`

To create a new `FormRecognizerClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateFormRecognizerClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new FormRecognizerClient(new Uri(endpoint), credential);
```

## Recognize custom forms from a URI

To recognize form fields and other content from your custom forms from a given file at a URI, use the `StartRecognizeCustomFormsFromUri` method. The returned value is a collection of `RecognizedForm` objects -- one for each form identified in the submitted document.

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

## Recognize custom forms from a file stream

To recognize form fields and other content from your custom forms from a file stream, use the `StartRecognizeCustomForms` method. The returned value is a collection of `RecognizedForm` objects -- one for each form identified in the submitted document.

```C# Snippet:FormRecognizerRecognizeCustomFormsFromFile
string modelId = "<modelId>";
string filePath = "<filePath>";

using var stream = new FileStream(filePath, FileMode.Open);

RecognizeCustomFormsOperation operation = await client.StartRecognizeCustomFormsAsync(modelId, stream);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection forms = operationResponse.Value;

foreach (RecognizedForm form in forms)
{
    Console.WriteLine($"Form of type: {form.FormType}");
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

To see the full example source files, see:

* [Recognize custom forms from URI](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample2_RecognizeCustomFormsFromUri.cs)
* [Recognize custom forms from file](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample2_RecognizeCustomFormsFromFile.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[strongly_typing_a_recognized_form]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample4_StronglyTypingARecognizedForm.md
[train_a_model]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample5_TrainModel.md
