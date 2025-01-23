# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: EventGridClient
require: https://github.com/Azure/azure-rest-api-specs/blob/c18f249c85d002b7b2ddcc36b648512b574e1f4a/specification/eventgrid/data-plane/readme.md
generation1-convenience-client: true
model-factory-for-hlc:
- MediaJobOutputAsset
```

## Swagger workarounds

### Add nullable annotations

``` yaml
directive:
  from: swagger-document
  where: $.definitions.CloudEventEvent
  transform: >
    $.properties.data["x-nullable"] = true;
```

### Suppress Abstract Base Class

``` yaml
suppress-abstract-base-class: MediaJobOutput
```

### Append `EventData` suffix to Resource Manager system event data models

``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.ResourceActionCancelData["x-ms-client-name"] = "ResourceActionCancelEventData";
    $.ResourceActionFailureData["x-ms-client-name"] = "ResourceActionFailureEventData";
    $.ResourceActionSuccessData["x-ms-client-name"] = "ResourceActionSuccessEventData";
    $.ResourceDeleteCancelData["x-ms-client-name"] = "ResourceDeleteCancelEventData";
    $.ResourceDeleteFailureData["x-ms-client-name"] = "ResourceDeleteFailureEventData";
    $.ResourceDeleteSuccessData["x-ms-client-name"] = "ResourceDeleteSuccessEventData";
    $.ResourceWriteCancelData["x-ms-client-name"] = "ResourceWriteCancelEventData";
    $.ResourceWriteFailureData["x-ms-client-name"] = "ResourceWriteFailureEventData";
    $.ResourceWriteSuccessData["x-ms-client-name"] = "ResourceWriteSuccessEventData";
```

### Fix casing of Redis events

``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.RedisExportRDBCompletedEventData["x-ms-client-name"] = "RedisExportRdbCompletedEventData";
    $.RedisImportRDBCompletedEventData["x-ms-client-name"] = "RedisImportRdbCompletedEventData";
```

### Fix casing of KeyVault events

``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.KeyVaultVaultAccessPolicyChangedEventData["properties"]["NBF"]["x-ms-client-name"] = "Nbf";
    $.KeyVaultVaultAccessPolicyChangedEventData["properties"]["EXP"]["x-ms-client-name"] = "Exp";
    $.KeyVaultCertificateNewVersionCreatedEventData["properties"]["NBF"]["x-ms-client-name"] = "Nbf";
    $.KeyVaultCertificateNewVersionCreatedEventData["properties"]["EXP"]["x-ms-client-name"] = "Exp";
    $.KeyVaultCertificateNearExpiryEventData["properties"]["NBF"]["x-ms-client-name"] = "Nbf";
    $.KeyVaultCertificateNearExpiryEventData["properties"]["EXP"]["x-ms-client-name"] = "Exp";
    $.KeyVaultCertificateExpiredEventData["properties"]["NBF"]["x-ms-client-name"] = "Nbf";
    $.KeyVaultCertificateExpiredEventData["properties"]["EXP"]["x-ms-client-name"] = "Exp";
    $.KeyVaultKeyNewVersionCreatedEventData["properties"]["NBF"]["x-ms-client-name"] = "Nbf";
    $.KeyVaultKeyNewVersionCreatedEventData["properties"]["EXP"]["x-ms-client-name"] = "Exp";
    $.KeyVaultKeyNearExpiryEventData["properties"]["NBF"]["x-ms-client-name"] = "Nbf";
    $.KeyVaultKeyNearExpiryEventData["properties"]["EXP"]["x-ms-client-name"] = "Exp";
    $.KeyVaultKeyExpiredEventData["properties"]["NBF"]["x-ms-client-name"] = "Nbf";
    $.KeyVaultKeyExpiredEventData["properties"]["EXP"]["x-ms-client-name"] = "Exp";
    $.KeyVaultSecretNewVersionCreatedEventData["properties"]["NBF"]["x-ms-client-name"] = "Nbf";
    $.KeyVaultSecretNewVersionCreatedEventData["properties"]["EXP"]["x-ms-client-name"] = "Exp";
    $.KeyVaultSecretNearExpiryEventData["properties"]["NBF"]["x-ms-client-name"] = "Nbf";
    $.KeyVaultSecretNearExpiryEventData["properties"]["EXP"]["x-ms-client-name"] = "Exp";
    $.KeyVaultSecretExpiredEventData["properties"]["NBF"]["x-ms-client-name"] = "Nbf";
    $.KeyVaultSecretExpiredEventData["properties"]["EXP"]["x-ms-client-name"] = "Exp";
```

### Apply converters and update namespace for system event data models
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    const namespace = "Azure.Messaging.EventGrid.SystemEvents";
    for (var path in $)
    {
      if (!path.includes("CloudEventEvent") && !path.includes("EventGridEvent"))
      {
        $[path]["x-namespace"] = namespace;
      }
      if (path.endsWith("EventData") ||
          path.includes("EventGridEvent") ||
         ($[path]["x-ms-client-name"] && $[path]["x-ms-client-name"].endsWith("EventData")))
      {
        $[path]["x-csharp-usage"] = "model,output,converter";
      }
      if (path.endsWith("SubscriptionValidationResponse"))
      {
        $[path]["x-csharp-usage"] = "model,input,output,converter";
      }
      $[path]["x-csharp-formats"] = "json";
      if (path.includes("WebAppServicePlanUpdatedEventData"))
      {
          $[path]["properties"]["sku"]["x-namespace"] = namespace;
          $[path]["properties"]["sku"]["x-csharp-formats"] = "json";
      }
      if (path.includes("DeviceTwinInfo"))
      {
          $[path]["properties"]["properties"]["x-namespace"] = namespace;
          $[path]["properties"]["properties"]["x-csharp-formats"] = "json";
          $[path]["properties"]["x509Thumbprint"]["x-namespace"] = namespace;
          $[path]["properties"]["x509Thumbprint"]["x-csharp-formats"] = "json";
      }
      if (path.includes("AcsRecordingFileStatusUpdatedEventData"))
      {
          $[path]["properties"]["recordingContentType"]["x-namespace"] = namespace;
          $[path]["properties"]["recordingContentType"]["x-ms-client-name"] = "ContentType";
          $[path]["properties"]["recordingContentType"]["x-ms-enum"]["name"] = "AcsRecordingContentType";
          $[path]["properties"]["recordingChannelType"]["x-namespace"] = namespace;
          $[path]["properties"]["recordingChannelType"]["x-ms-client-name"] = "ChannelType";
          $[path]["properties"]["recordingChannelType"]["x-ms-enum"]["name"] = "AcsRecordingChannelType";
          $[path]["properties"]["recordingFormatType"]["x-namespace"] = namespace;
          $[path]["properties"]["recordingFormatType"]["x-ms-client-name"] = "FormatType";
          $[path]["properties"]["recordingFormatType"]["x-ms-enum"]["name"] = "AcsRecordingFormatType";
      }
      if (path.includes("AcsEmailDeliveryReportReceivedEventData"))
      {
          $[path]["properties"]["status"]["x-namespace"] = namespace;
      }
      if (path.includes("AcsEmailEngagementTrackingReportReceivedEventData"))
      {
          $[path]["properties"]["engagementType"]["x-namespace"] = namespace;
      }
      if (path.includes("StorageTaskCompletedEventData"))
      {
          $[path]["properties"]["status"]["x-namespace"] = namespace;
          $[path]["properties"]["summaryReportBlobUrl"]["x-ms-client-name"] = "SummaryReportBlobUri";
      }
      if (path.includes("StorageTaskAssignmentCompletedEventData"))
      {
          $[path]["properties"]["status"]["x-namespace"] = namespace;
      }
      if (path.includes("EventGridMQTTClientCreatedOrUpdatedEventData"))
      {
          $[path]["properties"]["state"]["x-namespace"] = namespace;
      }
      if (path.includes("EventGridMQTTClientSessionDisconnectedEventData"))
      {
          $[path]["properties"]["disconnectionReason"]["x-namespace"] = namespace;
      }
      if (path.includes("AcsRouterJobReceivedEventData"))
      {
          $[path]["properties"]["jobStatus"]["x-namespace"] = namespace;
      }
      if (path.includes("AcsRouterWorkerSelector"))
      {
          $[path]["properties"]["labelOperator"]["x-namespace"] = namespace;
          $[path]["properties"]["state"]["x-namespace"] = namespace;
      }
      if (path.includes("AcsMessageDeliveryStatusUpdatedEventData"))
      {
          $[path]["properties"]["status"]["x-namespace"] = namespace;
          $[path]["properties"]["channelType"]["x-namespace"] = namespace;
      }
      if (path.includes("AcsRouterWorkerUpdatedEventData"))
      {
          $[path]["properties"]["updatedWorkerProperties"]["items"]["x-namespace"] = namespace;
      }
      if (path.includes("AcsMessageInteractiveContent"))
      {
          $[path]["properties"]["type"]["x-namespace"] = namespace;
      }
      if (path.includes("StorageLifecyclePolicyRunSummary"))
      {
          $[path]["properties"]["completionStatus"]["x-namespace"] = namespace;
      }
    }
```

### Discriminator properties have to be required

``` yaml
directive:
- from: swagger-document
  where: $.definitions.MediaJobOutput
  transform: >
    $["x-csharp-usage"] = "model,output";
```

### Fix Media types

``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.MediaLiveEventChannelArchiveHeartbeatEventData["properties"]["channelLatencyMs"]["x-ms-client-name"] = "ChannelLatencyMsInternal";
    $.MediaLiveEventIngestHeartbeatEventData["properties"]["ingestDriftValue"]["x-ms-client-name"] = "IngestDriftValueInternal";
    $.MediaLiveEventIngestHeartbeatEventData["properties"]["lastFragmentArrivalTime"]["format"] = "date-time";
```
