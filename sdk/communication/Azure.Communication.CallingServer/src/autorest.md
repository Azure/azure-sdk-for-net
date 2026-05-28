# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
input-file:
    -  $(this-folder)/Swagger/2022-04-07.json

clear-output-folder: true
client-side-validation: false
payload-flattening-threshold: 1

openapi-type: data-plane
tag: V2022_04_07_preview

model-namespace: false

title:
  Call Automation

generation1-convenience-client: true
```
