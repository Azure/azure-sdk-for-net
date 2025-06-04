# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/e64ad693df24b47d4009eece6663c8d95cf94be6/specification/communication/data-plane/Email/preview/2024-07-01-preview/CommunicationServicesEmail.json
generation1-convenience-client: true
payload-flattening-threshold: 3
model-namespace: false

directive:
  from: swagger-document
  where: "$.definitions.EmailAttachment.properties.contentInBase64"
  transform: >
    $["x-ms-client-name"] = "content";
```
