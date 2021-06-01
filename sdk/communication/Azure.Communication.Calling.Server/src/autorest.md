# Azure.Communication.CallingServer

When a new version of the swagger needs to be updated:
1. Open Azure.Communication.sln and under sdk\communication, run `dotnet msbuild /t:GenerateCode` to generate code.

2. Upload the Azure.Communication.Call.dll to the [apiview.dev tool](https://apiview.dev/).
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev.

## General settings
> see https://aka.ms/autorest 

## Configuration 
The following are the settings for generating this API with AutoRest.

```yaml
tag: beta
input-file: https://github.com/Azure/azure-rest-api-specs/blob/1d36d17a6bb4d5dd098f47df1d4f46799bde0d5d/specification/communication/data-plane/CallingServer/preview/2021-04-15-preview1/communicationservicescallingserver.json
payload-flattening-threshold: 10
clear-output-folder: true
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.Calling.Server"
```
