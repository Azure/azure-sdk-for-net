# Azure.Communication.Sms

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-sms-2026-01-23
model-namespace: true
require:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ee1579c284a9d032eaa70b1a183b661813decd41/specification/communication/data-plane/Sms/readme.md
payload-flattening-threshold: 10
generation1-convenience-client: true
```

### Make error response models internal - using Azure.Core error handling

``` yaml
directive:
  - from: swagger-document
    where: $.definitions.BadRequestErrorResponse
    transform: >
      $["x-accessibility"] = "internal";
  - from: swagger-document
    where: $.definitions.ErrorDetail
    transform: >
      $["x-accessibility"] = "internal";
  - from: swagger-document
    where: $.definitions.ErrorResponse
    transform: >
      $["x-accessibility"] = "internal";
  - from: swagger-document
    where: $.definitions.StandardErrorResponse
    transform: >
      $["x-accessibility"] = "internal";
```

``` yaml
directive:
  from: swagger-document
  where: "$.definitions.SmsSendResponseItem"
  transform: >
    $["x-ms-client-name"] = "SmsSendResult";
    $["x-namespace"] = "Azure.Communication.Sms";
```

``` yaml
directive:
  from: swagger-document
  where: "$.definitions.SmsSendOptions"
  transform: >
    $["x-namespace"] = "Azure.Communication.Sms";
```

``` yaml
directive:
  from: swagger-document
  where: "$.definitions.MessagingConnectOptions"
  transform: >
    $["x-namespace"] = "Azure.Communication.Sms";
```

``` yaml
directive:
  from: swagger-document
  where: "$.definitions.SmsRecipient"
  transform: >
    $["x-accessibility"] = "internal";
```

``` yaml
directive:
  from: swagger-document
  where: "$.definitions.SmsSendResponse"
  transform: >
    $["x-accessibility"] = "internal";
```

``` yaml
directive:
  from: swagger-document
  where: "$.definitions.SmsSendResponseItem.properties.repeatabilityResult"
  transform: >
    $["x-accessibility"] = "internal";
    $["x-namespace"] = "Azure.Communication.Sms";
```

``` yaml
directive:
  from: swagger-document
  where: "$.definitions.OptOutRecipient"
  transform: >
    $["x-accessibility"] = "internal";
```
