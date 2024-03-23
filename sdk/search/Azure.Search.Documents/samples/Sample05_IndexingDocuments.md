# Azure.Search.Documents Samples - Indexing Documents

If we want to build a search experience for a product catalog, we need to get
all of that data into Azure Cognitive Search.  If your data lives in Azure
Cosmos DB, Azure SQL Database, or Azure Blob Storage you can setup an indexer
to do that for you.  But if your data lives elsewhere, this sample will show you
how to move it into a search index.

Let's start with a simple model type:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_LegacyProduct
public class Product
{
    [SimpleField(IsKey = true)]
    public string Id { get; set; }

    [SearchableField(IsFilterable = true)]
    public string Name { get; set; }

    [SimpleField(IsSortable = true)]
    public double Price { get; set; }

    public override string ToString() =>
        $"{Id}: {Name} for {Price:C}";
}
```

Let's generate a sample catalog of products using Microsoft's naming conventions
from the mid-2000s because that's old enough to be vintage now:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_GenerateCatalog
public IEnumerable<Product> GenerateCatalog(int count = 1000)
{
    // Adapted from https://weblogs.asp.net/dfindley/Microsoft-Product-Name-Generator
    var prefixes = new[] { null, "Visual", "Compact", "Embedded", "Expression" };
    var products = new[] { null, "Windows", "Office", "SQL", "FoxPro", "BizTalk" };
    var terms = new[] { "Web", "Robotics", "Network", "Testing", "Project", "Small Business", "Team", "Management", "Graphic", "Presentation", "Communication", "Workflow", "Ajax", "XML", "Content", "Source Control" };
    var type = new[] { null, "Client", "Workstation", "Server", "System", "Console", "Shell", "Designer" };
    var suffix = new[] { null, "Express", "Standard", "Professional", "Enterprise", "Ultimate", "Foundation", ".NET", "Framework" };
    var components = new[] { prefixes, products, terms, type, suffix };

    var random = new Random();
    string RandomElement(string[] values) => values[(int)(random.NextDouble() * values.Length)];
    double RandomPrice() => (random.Next(2, 20) * 100.0) / 2.0 - .01;

    for (int i = 1; i <= count; i++)
    {
        yield return new Product
        {
            Id = i.ToString(),
            Name = string.Join(" ", components.Select(RandomElement).Where(n => n != null)),
            Price = RandomPrice()
        };
    }
}
```

That'll output classic software titles like "Visual Office Management Console
Enterprise" for the artisinal price of only $149.99.

We need to get that data into the service so let's create a `SearchIndexClient`:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_CreateIndex_Connect
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");

// Create a client for manipulating search indexes
AzureKeyCredential credential = new AzureKeyCredential(key);
SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
```

We'll use `FieldBuilder` to do the heavy lifting and create our search index:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_CreateIndex_Create
// Create the search index
string indexName = "products";
await indexClient.CreateIndexAsync(
    new SearchIndex(indexName)
    {
        Fields = new FieldBuilder().Build(typeof(Product))
    });
```

And finally we can get a `SearchClient` to the index we just created:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_CreateIndex_Client
SearchClient searchClient = indexClient.GetSearchClient(indexName);
```

## Simple indexing

The lowest level way to manage documents in your index is by using the
`IndexDocuments` method or its conveniences like `UploadDocuments`,
`DeleteDocuments`, etc.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_SimpleIndexing1
IEnumerable<Product> products = GenerateCatalog(count: 1000);
await searchClient.UploadDocumentsAsync(products);
```

We can quickly check that the document count matches our expections:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_SimpleIndexing2
Assert.AreEqual(1000, (int)await searchClient.GetDocumentCountAsync());
```

We do need to be careful to understand the limits of this API though.  For
example, trying to upload all of our products in one shot via

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_SimpleIndexing3
IEnumerable<Product> all = GenerateCatalog(count: 100000);
await searchClient.UploadDocumentsAsync(all);
```

results in a `RequestFailedException` with status code `400` because of "too
many indexing actions found in the request...".  We also would need to check the
response because the service can return `207` for a well formed request with
partial failures inside.  Most of those failures are errors, but some like
`409`, `422`, and `503` can be tried again.

## SearchIndexingBufferedSender

The easiest way to get data into a search index is using
`SearchIndexingBufferedSender`.  Let's try sending a massive amount of data
again.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_BufferedSender1
await using SearchIndexingBufferedSender<Product> indexer =
    new SearchIndexingBufferedSender<Product>(searchClient);
await indexer.UploadDocumentsAsync(GenerateCatalog(count: 100000));
```

If we checked the count immediately, we wouldn't see it reflect the right
number.  The buffered sender will split the indexing actions into batches,
submit them sequentially, retry failures, etc.  You can call `FlushAsync` to
wait for everything to be sent to the service.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_BufferedSender2
await indexer.FlushAsync();
Assert.AreEqual(100000, (int)await searchClient.GetDocumentCountAsync());
```
