# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: WebPubSubServiceClient
input-file:
    -  $(this-folder)/swagger/WebPubSub.json
low-level-client: true
credential-types: AzureKeyCredential
credential-header-name: Ocp-Apim-Subscription-Key
```

### Make WebPubSubPermission a regular enum
``` yaml
directive:
- from: swagger-document
  where: $..[?(@.name=="WebPubSubPermission")]
  transform: $.modelAsString = false;
```
