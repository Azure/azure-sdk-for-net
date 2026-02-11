# AutoRest Configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: RedHatOpenShiftManagementClient
description: Red Hat OpenShift Client
openapi-type: arm
azure-arm: true
csharp: true
library-name: RedHatOpenShift
namespace: Azure.ResourceManager.RedHatOpenShift
require: https://github.com/Azure/azure-rest-api-specs/blob/d45f04200fe13e29863dd7669adb05a2639af64d/specification/redhatopenshift/resource-manager/Microsoft.RedHatOpenShift/OpenShiftClusters/readme.md
tag: package-2025-07-25
output-folder: Generated/
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true
request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RedHatOpenShift/openShiftClusters/{resourceName}: OpenShiftCluster
override-client-name: RedHatOpenShiftManagementClient

directive:
  - from: swagger-document
    where: $.paths[*][*]
    transform: >
      if ($.operationId && $.operationId.startsWith("PlatformWorkloadIdentityRoleSets_")) {
        $.operationId = $.operationId.replace("PlatformWorkloadIdentityRoleSets_", "PlatformWorkloadIdentityRoleSet_");
      }
  - from: swagger-document
    where: $.definitions
    transform: >
      $.OpenShiftCluster.properties.properties['x-ms-client-flatten'] = true;
```
