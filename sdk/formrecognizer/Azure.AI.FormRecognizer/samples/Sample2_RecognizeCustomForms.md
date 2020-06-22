# Recognize custom forms

This sample demonstrates how to recognize form fields and other content from your custom forms, using models you trained with your own form types. For more information on how to do the training, see [train a model][train_a_model].

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

To recognize form fields and other content from your custom forms from a given file at a URI, use the `StartRecognizeCustomFormsFromUri` method. The returned value is a collection of `RecognizedForm` objects -- one for each page in the submitted document.

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

## Recognize custom forms from a file stream

To recognize form fields and other content from your custom forms from a file stream, use the `StartRecognizeCustomForms` method. The returned value is a collection of `RecognizedForm` objects -- one for each page in the submitted document.

```C# Snippet:FormRecognizerRecognizeCustomFormsFromFile
using (FileStream stream = new FileStream(formFilePath, FileMode.Open))
{
    string modelId = "<modelId>";

    RecognizedFormCollection forms = await client.StartRecognizeCustomForms(modelId, stream).WaitForCompletionAsync();
    /*
     *
     */
}
```

To see the full example source files, see:

* [Recognize custom forms from URI](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample2_RecognizeCustomFormsFromUri.cs)
* [Recognize custom forms from file](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample2_RecognizeCustomFormsFromFile.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[train_a_model]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample4_TrainModel.md