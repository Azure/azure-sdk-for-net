# Azure.DigitalTwins.Core

Run `generate.ps1` in this directory to generate the code.

## AutoRest Configuration

> see <https://aka.ms/autorest>

``` yaml
#when generating from official source
input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/digitaltwins/data-plane/Microsoft.DigitalTwins/preview/2020-05-31-preview/digitaltwins.json

#if you want to generate using local changes:
#input-file: $(this-folder)/swagger/2020-05-31-preview/digitaltwins.json

#azure-arm: true
#license-header: MICROSOFT_MIT_NO_VERSION
#payload-flattening-threshold: 1
#namespace: Azure.DigitalTwins.Core
```
