# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.
To debug autorest run `dotnet msbuild /t:GenerateCode /v:diagnostic /p:Trace=true /p:AutoRestVerbose=true`
### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2024-01-22-preview

require:
    - https://github.com/Azure/azure-rest-api-specs/blob/591f1c76d20023921c6925c5707465072dc25f15/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```
