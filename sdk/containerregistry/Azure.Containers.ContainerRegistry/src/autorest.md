# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  https://github.com/Azure/azure-sdk-for-js/blob/026346952c4ca27a5a992b5ed49464efd1092e28/sdk/containerregistry/container-registry/swagger/containerregistry.json
model-namespace: false
```

#``` yaml
#directive:
#  from: swagger-document
#  where: $.definitions.*
#  transform: >
#    $["x-accessibility"] = "internal"
#```
