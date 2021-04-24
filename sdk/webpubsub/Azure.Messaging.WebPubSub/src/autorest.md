# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  $(this-folder)/swagger/WebPubSub.json
```

### Make WebPubSubPermission a regular enum
``` yaml
directive:
- from: swagger-document
  where: $..[?(@.name=="WebPubSubPermission")]
  transform: $.modelAsString = false;
```
