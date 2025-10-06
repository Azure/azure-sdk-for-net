# Azure.Search.Documents Samples - Service Operations

## Get Statistics

Gets service level statistics for a Search Service.

This operation returns the number and type of objects in your service, the
maximum allowed for each object type given the service tier, actual and maximum
storage, and other limits that vary by tier.  This request pulls information
from the service so that you don't have to look up or calculate service limits.

Statistics on document count and storage size are collected every few minutes,
not in real time.  Therefore, the statistics returned by this API may not
reflect changes caused by recent indexing operations.

```C# Snippet:Azure_Search_Tests_Samples_GetStatisticsAsync
// Create a new SearchIndexClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Get and report the Search Service statistics
Response<SearchServiceStatistics> stats = await indexClient.GetServiceStatisticsAsync();
Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} of {stats.Value.Counters.IndexCounter.Quota} indexes.");
```

## Connect a Data Source to an Index

You can index documents already stored in Azure Blob Storage, Azure SQL, Azure Table Storage, Azure Cosmos DB, or MySQL.
This not only provides you flexibility to use existing storage, but to also reduce the index size by only defining the
fields you need in the index and mapping just those fields from your data source. An indexer is responsible for using
those mappings and running optional skillsets to populate your index.

The following sample will index hotel information from Azure Blob Storage and automatically translate English descriptions
to French if not a human translation is not already defined.

### Create a Synonym Map

First we'll create a synonym map for country names and abbreviations. A synonym map contains aliases
and other transformations using the
[Solr format](https://docs.microsoft.com/rest/api/searchservice/create-synonym-map#apache-solr-synonym-format),
for example:

```
United States of America, US, USA
Washington, Wash. => WA
```

You can pass a preformatted string delimited by `\n` characters, or a `TextReader` for
a file you may have downloaded or have stored elsewhere.

```C# Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateSynonymMap
// Create a new SearchIndexClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create a synonym map from a file containing country names and abbreviations
// using the Solr format with entry on a new line using \n, for example:
// United States of America,US,USA\n
string synonymMapName = "countries";
string synonymMapPath = "countries.txt";

SynonymMap synonyms;
using (StreamReader file = File.OpenText(synonymMapPath))
{
    synonyms = new SynonymMap(synonymMapName, file);
}

await indexClient.CreateSynonymMapAsync(synonyms);
```

These synonym maps can be associated with search fields so users can query for terms
with which they may be more familiar. These will be referenced further below when we
create an index.

### Create an Index

Next we'll create an index of hotel information that uses the synonym map we created above
attached to the `country` search field:

```C# Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateIndex
// Create the index
string indexName = "hotels";
SearchIndex index = new SearchIndex(indexName)
{
    Fields =
    {
        new SimpleField("HotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
        new SearchableField("HotelName") { IsFilterable = true, IsSortable = true },
        new SearchableField("Description") { AnalyzerName = LexicalAnalyzerName.EnLucene },
        new SearchableField("DescriptionFr") { AnalyzerName = LexicalAnalyzerName.FrLucene },
        new SearchableField("Tags", collection: true) { IsFilterable = true, IsFacetable = true },
        new ComplexField("Address")
        {
            Fields =
            {
                new SearchableField("StreetAddress"),
                new SearchableField("City") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                new SearchableField("StateProvince") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                new SearchableField("Country") { SynonymMapNames = new[] { synonymMapName }, IsFilterable = true, IsSortable = true, IsFacetable = true },
                new SearchableField("PostalCode") { IsFilterable = true, IsSortable = true, IsFacetable = true }
            }
        }
    }
};

await indexClient.CreateIndexAsync(index);
```

### Create a Data Source Connection

We'll need to create a connection to Azure Blob Storage where our documents are found.
These JSON documents match the schema of our index, but you can map input and output fields to change names
when indexing to better fit your index. You might do this, for example, if you have multiple indexers
indexing data from different data sources with different schemas and data.

```C# Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateDataSourceConnection
// Create a new SearchIndexerClient
SearchIndexerClient indexerClient = new SearchIndexerClient(endpoint, credential);

string dataSourceConnectionName = "hotels";
SearchIndexerDataSourceConnection dataSourceConnection = new SearchIndexerDataSourceConnection(
    dataSourceConnectionName,
    SearchIndexerDataSourceType.AzureBlob,
    Environment.GetEnvironmentVariable("STORAGE_CONNECTION_STRING"),
    new SearchIndexerDataContainer(Environment.GetEnvironmentVariable("STORAGE_CONTAINER")));

await indexerClient.CreateDataSourceConnectionAsync(dataSourceConnection);
```

#### Create SearchClientOptions

To control specific request behaviors such as timeouts and retries, you can create a client with options.

```C# Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_SearchClientOptions
// Create SearchIndexerClient options
SearchClientOptions options = new SearchClientOptions()
{
    Transport = new HttpClientTransport(new HttpClient()
    {
        // Increase timeout for each request to 5 minutes
        Timeout = TimeSpan.FromMinutes(5)
    })
};

// Increase retry attempts to 6
options.Retry.MaxRetries = 6;

// Create a new SearchIndexerClient with options
indexerClient = new SearchIndexerClient(endpoint, credential, options);
```

### Create a Skillset

To provide French translations of descriptions, we'll define a [translation skill](https://docs.microsoft.com/azure/search/cognitive-search-skill-text-translation) to translate from English.
We'll also define a [conditional skill](https://docs.microsoft.com/azure/search/cognitive-search-skill-conditional) to use a human-translated descriptions instead if available.

See all [built-in skills](https://docs.microsoft.com/azure/search/cognitive-search-predefined-skills) for more information
about all available skills.

```C# Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_Skillset
// Translate English descriptions to French.
// See https://docs.microsoft.com/azure/search/cognitive-search-skill-text-translation for details of the Text Translation skill.
TextTranslationSkill translationSkill = new TextTranslationSkill(
    inputs: new[]
    {
        new InputFieldMappingEntry("text") { Source = "/document/Description" }
    },
    outputs: new[]
    {
        new OutputFieldMappingEntry("translatedText") { TargetName = "descriptionFrTranslated" }
    },
    TextTranslationSkillLanguage.Fr)
{
    Name = "descriptionFrTranslation",
    Context = "/document",
    DefaultFromLanguageCode = TextTranslationSkillLanguage.En
};

// Use the human-translated French description if available; otherwise, use the translated description.
// See https://docs.microsoft.com/azure/search/cognitive-search-skill-conditional for details of the Conditional skill.
ConditionalSkill conditionalSkill = new ConditionalSkill(
    inputs: new[]
    {
        new InputFieldMappingEntry("condition") { Source = "= $(/document/DescriptionFr) == null" },
        new InputFieldMappingEntry("whenTrue") { Source = "/document/descriptionFrTranslated" },
        new InputFieldMappingEntry("whenFalse") { Source = "/document/DescriptionFr" }
    },
    outputs: new[]
    {
        new OutputFieldMappingEntry("output") { TargetName = "descriptionFrFinal"}
    })
{
    Name = "descriptionFrConditional",
    Context = "/document",
};

// Create a SearchIndexerSkillset that processes those skills in the order given below.
string skillsetName = "translations";
SearchIndexerSkillset skillset = new SearchIndexerSkillset(
    skillsetName,
    new SearchIndexerSkill[] { translationSkill, conditionalSkill })
{
    CognitiveServicesAccount =  new CognitiveServicesAccountKey(
        Environment.GetEnvironmentVariable("COGNITIVE_SERVICES_KEY")),
    KnowledgeStore = new KnowledgeStore(
        Environment.GetEnvironmentVariable("STORAGE_CONNECTION_STRING"),
        new List<KnowledgeStoreProjection>()),
};

await indexerClient.CreateSkillsetAsync(skillset);
```

### Create an Indexer

Finally we'll create an indexer to index the documents from Azure Blob Storage and process our skillset to translate the
English description to French if required. We also have to tell the indexer to process each blob as a separate JSON document
to maintain the document structure required for skills.

```C# Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateIndexer
string indexerName = "hotels";
SearchIndexer indexer = new SearchIndexer(
    indexerName,
    dataSourceConnectionName,
    indexName)
{
    // We only want to index fields defined in our index, excluding descriptionFr if defined.
    FieldMappings =
    {
        new FieldMapping("HotelId"),
        new FieldMapping("HotelName"),
        new FieldMapping("Description"),
        new FieldMapping("Tags"),
        new FieldMapping("Address")
    },
    OutputFieldMappings =
    {
        new FieldMapping("/document/descriptionFrFinal") { TargetFieldName = "DescriptionFr" }
    },
    Parameters = new IndexingParameters
    {
        // Tell the indexer to parse each blob as a separate JSON document.
        IndexingParametersConfiguration = new IndexingParametersConfiguration
        {
            ParsingMode = BlobIndexerParsingMode.Json
        }
    },
    SkillsetName = skillsetName
};

// Create the indexer which, upon successful creation, also runs the indexer.
await indexerClient.CreateIndexerAsync(indexer);
```

### Querying the Index

Let's query the index and make sure everything works as implemented. Within the test data, hotel "6" has a nice ocean view
but was not authored with a French description.

```C# Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_Query
// Get a SearchClient from the SearchIndexClient to share its pipeline.
SearchClient searchClient = indexClient.GetSearchClient(indexName);

// Query for hotels with an ocean view.
SearchResults<Hotel> results = await searchClient.SearchAsync<Hotel>("ocean view");
await foreach (SearchResult<Hotel> result in results.GetResultsAsync())
{
    Hotel hotel = result.Document;

    Console.WriteLine($"{hotel.HotelName} ({hotel.HotelId})");
    Console.WriteLine($"  Description (English): {hotel.Description}");
    Console.WriteLine($"  Description (French):  {hotel.DescriptionFr}");
}
```

You should see within your results that hotel with a French description translated from the skill we added.
