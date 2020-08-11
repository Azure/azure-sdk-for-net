# Azure.Search.Documents Samples - IndexingParametersExtensions

You can include the following code in your own projects to simplify setting indexing parameters,
or to migrate existing code from using Microsoft.Azure.Search to use Azure.Search.Documents.

- [IndexingParametersExtensions.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/search/Azure.Search.Documents/tests/Samples/IndexingParametersExtensions/IndexingParametersExtensions.cs) is a set of extension methods to set configuration parameters.
- [BlobExtractionMode.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/search/Azure.Search.Documents/tests/Samples/IndexingParametersExtensions/BlobExtractionMode.cs) is an extensible enumeration used by `IndexingParametersExtensions`.
- [ImageAction.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/search/Azure.Search.Documents/tests/Samples/IndexingParametersExtensions/ImageAction.cs) is an extensible enumeration used by `IndexingParametersExtensions`.
- [PdfTextRotationAlgorithm.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/search/Azure.Search.Documents/tests/Samples/IndexingParametersExtensions/PdfTextRotationAlgorithm.cs) is an extensible enumeration used by `IndexingParametersExtensions`.

If your Azure Blob Storage data source you want to index contains many different types of files, for example, and you only
want to index JSON documents matching the file name pattern "*.json", you could run the following code when creating your indexer:

```C# Snippet:IndexingParametersExtensions_IndexOnlyJsonDocuments
SearchIndexer indexer = new SearchIndexer("hotelsIndexer", "hotelsDataSource", "hotelsIndex")
{
    Parameters = new IndexingParameters()
        .SetIndexedFileNameExtensions(".json")
        .SetParseJson()
};
```
