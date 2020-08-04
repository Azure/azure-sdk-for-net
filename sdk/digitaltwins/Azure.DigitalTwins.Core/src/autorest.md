# Azure.DigitalTwins.Core

Run `generate.ps1` in this directory to generate the code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
#when generating from local changes:
input-file: $(this-folder)/swagger/digitaltwins.json

#when generating from official source
#require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/c3dd5df2863101b56eef256b810927cdcc4e44d2/specification/digitaltwins/data-plane/readme.md

#azure-arm: true
#license-header: MICROSOFT_MIT_NO_VERSION
#payload-flattening-threshold: 1
#namespace: Azure.DigitalTwins.Core
```
