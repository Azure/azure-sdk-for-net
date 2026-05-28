# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.
To debug autorest run `dotnet msbuild /t:GenerateCode /v:diagnostic /p:Trace=true /p:AutoRestVerbose=true`
### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2024-01-22-preview

require:
    - https://github.com/Azure/azure-rest-api-specs/blob/0b6d009ed96fc5ef8e860b89da8092109ceeec66/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```
