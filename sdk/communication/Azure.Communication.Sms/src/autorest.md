# Azure.Communication.Sms

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-sms-2025-05-29-preview
model-namespace: true
require:
    -  C:\azure-rest-api-specs\specification\communication\data-plane\Sms\readme.md
payload-flattening-threshold: 10
generation1-convenience-client: true
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