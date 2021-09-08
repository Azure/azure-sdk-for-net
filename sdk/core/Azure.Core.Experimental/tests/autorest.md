# Pet Shop Service

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
  - $(this-folder)/swagger/petStoreService.json
#namespace: Azure.Analytics.Synapse.Administration
public-clients: true
low-level-client: true
security: AADToken
security-scopes: https://example.azurepetshop.com/.default
```

### Make Endpoint type as Uri

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
```
