### AutoRest Configuration
> see https://aka.ms/autorest

# Azure.IoT.Hub.Service

Run `./generateCode.ps1` in this directory to generate the code.

``` yaml
input-file:
    -  $(this-folder)/swagger/iothubservice.json
generation1-convenience-client: true
model-factory-for-hlc: true
modelerfour:
    seal-single-value-enum-by-default: true
```
