# Microsoft.Azure.Synapse

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

<!--
```yaml
branch: master
repo: D:\code\AzureSDK\azure-rest-api-specs
```
-->

```yaml
branch: master
repo: https://github.com/Azure/azure-rest-api-specs/blob/$(branch)
```

``` yaml
input-file:
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-11-01-preview/sparkJob.json
```
