# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/83327afe471d7a2eb923de58b163658d45e0e5a7/specification/communication/data-plane/Email/stable/2023-03-31/CommunicationServicesEmail.json
generation1-convenience-client: true
payload-flattening-threshold: 3
model-namespace: false

directive:
  from: swagger-document
  where: "$.definitions.EmailAttachment.properties.contentInBase64"
  transform: >
    $["x-ms-client-name"] = "content";
```


