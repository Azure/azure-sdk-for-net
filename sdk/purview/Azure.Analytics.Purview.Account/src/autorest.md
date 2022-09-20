# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: PurviewAccount
input-file: https://github.com/Azure/azure-rest-api-specs/blob/b2bddfe2e59b5b14e559e0433b6e6d057bcff95d/specification/purview/data-plane/Azure.Analytics.Purview.Account/preview/2019-11-01-preview/account.json
namespace: Azure.Analytics.Purview.Account
security: AADToken
security-scopes:  https://purview.azure.net/.default
```

# Model endpoint parameter as a url, not a string.

```yaml
directive:
  - from: swagger-document
    where: $.parameters.endpoint
    transform: >
      if ($.format === undefined) {
        $.format = "url";
      }
```

# Promote collectionName to be a client parameter.

```yaml
directive:
  - from: swagger-document
    where: $.parameters
    transform: >
      $["collectionName"] = {
        "in": "path",
        "name": "collectionName",
        "required": true,
        "type": "string",
        "x-ms-parameter-location": "client"
      };

  - from: swagger-document
    where: $.paths..parameters[?(@.name=='collectionName')]
    transform: >
      $ = { "$ref": "#/parameters/collectionName" };
```

# Promote List Methods to Account Client

```yaml
directive:
  - from: swagger-document
    where: $..[?(@.operationId !== undefined)]
    transform: >
      const mappingTable = {
        "Collections_ListCollections": "Accounts_GetCollections",
        "ResourceSetRules_ListResourceSetRules": "Accounts_GetResourceSetRules"
      };

      $.operationId = (mappingTable[$.operationId] ?? $.operationId);
```
