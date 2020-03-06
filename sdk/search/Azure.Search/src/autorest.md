# Azure.Search Code Generation

Run `/sdk/search/generate.ps1` to generate code.

## AutoRest Configuration
> see https://aka.ms/autorest

## Swagger Source(s)
AutoRest doesn't play nicely with multiple remote swagger files.  It will
however merge two local swagger files together automagically.  At some point,
we should merge the Service and Index swagger files together but for now we
copy them locally in `/sdk/search/generate.ps1` and reference them here.
```yaml
input-file:
    -  $(this-folder)/swagger/searchindex.json
    -  $(this-folder)/swagger/searchservice.json
```

## Release Schedule hacks
We're planning to roll out the API in stages so I'm temporarily removing APIs
that shouldn't be part of the first preview.  All of this needs to eventually
disappear.  Note - we're doing these transforms first to scope down the other
transforms needed below.

### Only expose document operations or service stats
And also only include the POST variants when there are two.
``` yaml
directive:
- from: swagger-document
  where: $.paths
  transform: >
    return {
        // Service operations
        "/servicestats": $["/servicestats"],

        // Document operations
        "/docs/$count": $["/docs/$count"],
        "/docs/search": $["/docs/search.post.search"],
        "/docs('{key}')": $["/docs('{key}')"],
        "/docs/suggest": $["/docs/search.post.suggest"],
        "/docs/search.index": $["/docs/search.index"],
        "/docs/autocomplete": $["/docs/search.post.autocomplete"]
    };
```

### Only expose models used by the above operations
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    return {
        // Service Statistics models
        "ServiceStatistics": $["ServiceStatistics"],
        "ServiceCounters": $["ServiceCounters"],
        "ServiceLimits": $["ServiceLimits"],
        "ResourceCounter": $["ResourceCounter"],

        // Documents models
        "SuggestDocumentsResult": $["SuggestDocumentsResult"],
        "SuggestResult": $["SuggestResult"],
        "FacetResult": $["FacetResult"],
        "SearchDocumentsResult": $["SearchDocumentsResult"],
        "SearchResult": $["SearchResult"],
        "IndexBatch": $["IndexBatch"],
        "IndexAction": $["IndexAction"],
        "IndexingResult": $["IndexingResult"],
        "IndexDocumentsResult": $["IndexDocumentsResult"],
        "SearchMode": $["SearchMode"],
        "QueryType": $["QueryType"],
        "AutocompleteMode": $["AutocompleteMode"],
        "SearchRequest": $["SearchRequest"],
        "SuggestRequest": $["SuggestRequest"],
        "AutocompleteRequest": $["AutocompleteRequest"],
        "AutocompleteResult": $["AutocompleteResult"],
        "AutocompleteItem": $["AutocompleteItem"]
    };
```

## CodeGen hacks
These should eventually be fixed in the code generator.

### `request` can't be used as a parameter name
The swagger and the codegen both use the name `request` which is problematic.
``` yaml
directive:
- from: swagger-document
  where: $.paths["/indexes('{indexName}')/search.analyze"].post.parameters[1]
  transform: >
    $["x-ms-client-name"] = "request_todo";
    return $;
```

## Swagger hacks
These should eventually be fixed in the swagger files.

### Switch to full URIs for Service operations
``` yaml
directive:
- from: $(this-folder)/swagger/searchservice.json
  where: $["x-ms-parameterized-host"]
  transform: >
    return {
      "hostTemplate": "{endpoint}",
      "useSchemePrefix": false,
      "parameters": [
        {
          "name": "endpoint",
          "in": "path",
          "required": true,
          "type": "string",
          "format": "uri",
          "x-ms-skip-url-encoding": true,
          "description": "The URI endpoint of the search service.",
          "x-ms-parameter-location": "client"
        }
      ]
    };
```

### Switch to full URIs for Document operations
``` yaml
directive:
- from: $(this-folder)/swagger/searchindex.json
  where: $["x-ms-parameterized-host"]
  transform: >
    return {
      "hostTemplate": "{endpoint}/indexes('{indexName}')",
      "useSchemePrefix": false,
      "parameters": [
        {
          "name": "endpoint",
          "in": "path",
          "required": true,
          "type": "string",
          "format": "uri",
          "x-ms-skip-url-encoding": true,
          "description": "The URI endpoint of the search service.",
          "x-ms-parameter-location": "client"
        },
        {
          "name": "indexName",
          "in": "path",
          "required": true,
          "type": "string",
          "x-ms-skip-url-encoding": false,
          "description": "The name of the index.",
          "x-ms-parameter-location": "client"
        }
      ]
    };
```

### Mark definitions as objects
The modeler warns about all of these.
``` yaml
directive:
- from: swagger-document
  where:
    - $.definitions.ServiceStatistics
    - $.definitions.ServiceCounters
    - $.definitions.ServiceLimits
    - $.definitions.ResourceCounter
    - $.definitions.SearchRequest
    - $.definitions.SearchResult
    - $.definitions.SearchDocumentsResult
    - $.definitions.AutocompleteRequest
    - $.definitions.AutocompleteResult
    - $.definitions.AutocompleteItem
    - $.definitions.IndexDocumentsResult
    - $.definitions.IndexingResult
    - $.definitions.IndexAction
    - $.definitions.IndexBatch
    - $.definitions.FacetResult
    - $.definitions.SuggestRequest
    - $.definitions.SuggestResult
    - $.definitions.SuggestDocumentsResult
  transform: $.type = "object";
```

### Add default responses
TODO...

## C# Customizations
Shape the swagger APIs to produce the best C# API possible.  We can consider
fixing these in the swagger files if they would benefit other languages.
