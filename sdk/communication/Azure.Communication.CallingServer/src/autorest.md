# Azure.Communication.CallingServer

When a new version of the swagger needs to be updated:
1. Open Azure.Communication.sln and under sdk\communication, run `dotnet msbuild /t:GenerateCode` to generate code.

2. Upload the Azure.Communication.Call.dll to the [apiview.dev tool](https://apiview.dev/).
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
title: Calling server
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/3893616381e816729ef9cdd768e87fb2845e189d/specification/communication/data-plane/CallingServer/readme.md
payload-flattening-threshold: 10
clear-output-folder: true
```

### Fixing RecordingChannel 
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    delete $.RecordingChannelType["x-ms-enum"];
    $.RecordingChannelType["x-ms-enum"] = {
        "name": "RecordingChannel",
        "modelAsString": false
    };
```

### Fixing RecordingContent
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    delete $.RecordingContentType["x-ms-enum"];
    $.RecordingContentType["x-ms-enum"] = {
        "name": "RecordingContent",
        "modelAsString": false
    };
```
    
### Fixing RecordingFormat
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    delete $.RecordingFormatType["x-ms-enum"];
    $.RecordingFormatType["x-ms-enum"] = {
        "name": "RecordingFormat",
        "modelAsString": false
    };
```
