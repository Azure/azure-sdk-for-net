# Recognize form content

This sample demonstrates how to recognize tables, lines, words, and selection marks like radio buttons and check boxes in forms documents, without the need to train a model.

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

## Recognize form content from a file stream

To recognize the content from a file stream, use the `StartRecognizeContent` method. The returned value is a collection of `FormPage` objects -- one for each page in the submitted document.

```C# Snippet:FormRecognizerRecognizeFormContentFromFile
string filePath = "filePath";
using var stream = new FileStream(filePath, FileMode.Open);

Response<FormPageCollection> response = await client.StartRecognizeContentAsync(stream).WaitForCompletionAsync();
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

To see the full example source files, see:

* [Recognize form content from URI](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample1_RecognizeContentFromUri.cs)
* [Recognize form content from file](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample1_RecognizeContentFromFile.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started