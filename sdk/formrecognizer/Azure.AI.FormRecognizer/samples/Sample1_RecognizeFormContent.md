# Recognize form content

This sample demonstrates how to recognize tables, lines, and words in documents, without the need to train a model.

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

## Recognize form content from a URI

To recognize the content from a given file at a URI, use the `StartRecognizeContentFromUri` method. The returned value is a collection of `FormPage` objects -- one for each page in the submitted document.

```C# Snippet:FormRecognizerSampleRecognizeContentFromUri
FormPageCollection formPages = await client.StartRecognizeContentFromUri(invoiceUri).WaitForCompletionAsync();
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

## Recognize form content from a file stream

To recognize the content from a file stream, use the `StartRecognizeContent` method. The returned value is a collection of `FormPage` objects -- one for each page in the submitted document.

```C# Snippet:FormRecognizerRecognizeFormContentFromFile
using (FileStream stream = new FileStream(invoiceFilePath, FileMode.Open))
{
    FormPageCollection formPages = await client.StartRecognizeContent(stream).WaitForCompletionAsync();
    /*
     *
     */
}
```

To see the full example source files, see:

* [Recognize form content from URI](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample1_RecognizeContentFromUri.cs)
* [Recognize form content from file](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample1_RecognizeContentFromFile.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started