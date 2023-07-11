# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/512e966e15cd8e6ffd756279971c478702f4e19e/specification/communication/data-plane/Email/stable/2023-03-31/CommunicationServicesEmail.json
generation1-convenience-client: true
payload-flattening-threshold: 3
model-namespace: false

directive:
  from: swagger-document
  where: "$.definitions.EmailAttachment.properties.contentInBase64"
  transform: >
    $["x-ms-client-name"] = "content";
```
