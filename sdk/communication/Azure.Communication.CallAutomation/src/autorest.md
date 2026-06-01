# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.
To debug autorest run `dotnet msbuild /t:GenerateCode /v:diagnostic /p:Trace=true /p:AutoRestVerbose=true`
### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2024-01-22-preview

require:
    - https://github.com/Azure/azure-rest-api-specs/blob/d5a57406de58c38a8ba53b0f9a74eca34b6bc877/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```
