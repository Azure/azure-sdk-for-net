# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  https://quickpulsespecs.blob.core.windows.net/specs/swagger-v2-for%20sdk%20only.json.
generation1-convenience-client: true
```

``` yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"]="internal"
```
