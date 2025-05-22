# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2023-10-03-preview

input-file: /workspaces/ACS-API-SDK/alpha4/incremental.json

title: Azure Communication Services

generation1-convenience-client: true
```
