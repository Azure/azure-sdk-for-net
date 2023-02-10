# Azure.Communication.AlphaIds

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
input-file:
    -  $(this-folder)/swagger/alphaids.json
payload-flattening-threshold: 3
generation1-convenience-client: true
```