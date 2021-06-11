# Cognitive Services Language SDK for .NET

This is the AutoRest configuration file the Cognitive Services Language SDK for .NET.

> see https://aka.ms/autorest

## Common C# Settings

```yaml
csharp:
  clear-output-folder: true
  license-header: MICROSOFT_MIT_NO_VERSION

directive:
# - from: swagger-document
#   where: $.definitions.*
#   transform: $["x-accessibility"] = "internal"

- from: swagger-document
  where: $.parameters.Endpoint
  transform: $["format"] = "url"
```
