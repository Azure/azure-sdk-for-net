# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/a79c221ae230276973e4e5477dcbedbdad52cf7c/specification/communication/data-plane/Email/preview/2025-01-15-preview/CommunicationServicesEmail.json
generation1-convenience-client: true
payload-flattening-threshold: 3
model-namespace: false

directive:
  from: swagger-document
  where: "$.definitions.EmailAttachment.properties.contentInBase64"
  transform: >
    $["x-ms-client-name"] = "content";
```
