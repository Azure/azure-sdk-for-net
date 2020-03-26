# Azure.Search.Documents Code Generation

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
- $(this-folder)/swagger/searchindex.json
- $(this-folder)/swagger/searchservice.json
```

## Release hacks
We only want certain client methods for our search query client.
``` yaml
directive:
- remove-operation: Documents_AutocompleteGet
- remove-operation: Documents_SearchGet
- remove-operation: Documents_SuggestGet
```

## CodeGen hacks
These should eventually be fixed in the code generator.

## Swagger hacks
These should eventually be fixed in the swagger files.

### Mark definitions as objects
The modeler warns about models without an explicit type.
``` yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    if (typeof $.type === "undefined") {
        $.type = "object";
    }
```

### Make Loookup Document behave a little friendlier
It's currently an empty object and adding Additional Properties will generate
a more useful model.
``` yaml
directive:
- from: swagger-document
  where: $.paths["/docs('{key}')"].get.responses["200"].schema
  transform:  >
    $.additionalProperties = true;
```

### Rename one of SearchError definitions

SearchError is duplicated between two swaggers, rename one of them

``` yaml
directive:
- from: searchservice.json
  where: $.definitions.SearchError
  transform: $["x-ms-client-name"] = "SearchServiceError"
```

## C# Customizations
Shape the swagger APIs to produce the best C# API possible.  We can consider
fixing these in the swagger files if they would benefit other languages.

### Add documentation
Add documentation to nodes that do not have it. These should be fixed in swagger.
``` yaml
directive:
- from: swagger-document
  where: $.definitions..properties["@odata.type"]
  transform: $.description = "The model type.";
- from: swagger-document
  where: $.definitions.CognitiveServicesAccount.properties.description
  transform: $.description = "Description of the cognitive resource attached to a skillset.";
- from: swagger-document
  where: $.definitions.CognitiveServicesAccountKey.properties.key
  transform: $.description = "The key used to provision a cognitive resource attached to a skillset.";
- from: swagger-document
  where: $.definitions.ScoringFunction.properties.type
  transform: $.description = "Required for scoring functions. Indicates the type of function to use. Valid values include magnitude, freshness, distance, and tag. You can include more than one function in each scoring profile. The function name must be lower case.";
```

### Property name changes
Change the name of some properties so they are properly CamelCased.
``` yaml
modelerfour:
  naming:
    override:
      "@odata.type": ODataType
```
