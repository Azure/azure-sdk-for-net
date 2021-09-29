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
    -  https://raw.githubusercontent.com/navali-msft/azure-rest-api-specs/f34504721cc42ad0c07aa20d333f9cb7fbbe31ef/specification/communication/data-plane/CallingServer/readme.md
payload-flattening-threshold: 10
clear-output-folder: true
```
