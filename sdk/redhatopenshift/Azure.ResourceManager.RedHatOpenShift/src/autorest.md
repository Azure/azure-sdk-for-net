# Azure Red Hat OpenShift

> see https://aka.ms/autorest

This is the AutoRest configuration file for Azure Red Hat OpenShift.

## Getting Started

To build the SDK for Red Hat OpenShift, simply [Install AutoRest](https://github.com/Azure/autorest/blob/main/docs/install/readme.md) and in this folder, run:

> `autorest`

To see additional help and options, run:

> `autorest --help`

## Configuration

### Basic Information

These are the global settings for the Azure Red Hat OpenShift API.

```yaml
title: RedHatOpenShiftManagementClient
description: Red Hat OpenShift Client
openapi-type: arm
azure-arm: true
csharp: true
library-name: RedHatOpenShift
namespace: Azure.ResourceManager.RedHatOpenShift
require: https://github.com/Azure/azure-rest-api-specs/tree/886e1a5fb328ebe056e7ba64892d8c665e079355/specification/redhatopenshift/resource-manager/Microsoft.RedHatOpenShift/OpenShiftClusters#readme
tag: package-2025-07-25
output-folder: Generated/
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RedHatOpenShift/openShiftClusters/{resourceName}: OpenShiftCluster
override-client-name: RedHatOpenShiftManagementClient

directive:
  - from: swagger-document
    where: $.definitions
    transform: >
      $.OpenShiftCluster.properties.properties['x-ms-client-flatten'] = true;
```

### Tag: package-2025-07-25

These settings apply only when `--tag=package-2025-07-25` is specified on the command line.

```yaml $(tag) == 'package-2025-07-25'
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/main/specification/redhatopenshift/resource-manager/Microsoft.RedHatOpenShift/stable/2025-07-25/redhatopenshift.json
```
