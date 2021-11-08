# Extract words from fields

This sample demonstrates how to select the `DocumentWord` instances that are part of a `DocumentField`. Please note that the same approach can be used for other document elements, such as `DocumentLine`, `DocumentTable`, `DocumentTableCell`,`DocumentKeyValueElement`, `DocumentEntity`, and `AnalyzedDocument`.

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `DocumentAnalysisClient`

To create a new `DocumentAnalysisClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentAnalysisClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new DocumentAnalysisClient(new Uri(endpoint), credential);
```

## Select words by correlating spans

In general, a `DocumentWord` is not hierarchically contained in other document elements. The only way to select the words that are part of a `DocumentField`, for example, is by correlating their spans. The following piece of code can be used as a helper method to filter all words by a specified list of spans.

```C# Snippet:FormRecognizerSampleGetWordsInSpans
```

## Extract words from fields

Once you have the `GetWordsInSpans` helper method in place, you can use it to select the words that are part of any `DocumentField`. Be aware that every method call has an associated execution cost, so multiple calls per field should be avoided. It's recommended to make a single call per field and have the result stored for later use if necessary.

```C# Snippet:FormRecognizerSampleExtractWordsFromFields
```

To see the full example source files, see:

* [Extract words from fields](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_ExtractWordsFromFieldsAsync.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
