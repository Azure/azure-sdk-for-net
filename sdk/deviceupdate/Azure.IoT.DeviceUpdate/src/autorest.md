# Azure.IoT.DeviceUpdate

Run `generate.ps1` or `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
title: DeviceUpdate

input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/d7c9be23749467be1aea18f02ba2f4948a39db6a/specification/deviceupdate/data-plane/Microsoft.DeviceUpdate/stable/2022-10-01/deviceupdate.json

namespace: Azure.IoT.DeviceUpdate
security: AADToken
security-scopes:  https://api.adu.microsoft.com/.default
# disable renaming pagination parameter "top" since the SDK is GAed
disable-pagination-top-renaming: true
keep-non-overloadable-protocol-signature: true
```

### Fix 304s
AutoRest will generate code that throws an exception on 304 if we allow it fall
through to `default` so we'll explicitly add them for the operations that support
conditional requests.
``` yaml
directive:
- from: swagger-document
  where:
  - $.paths["/deviceUpdate/{instanceId}/updates/providers/{provider}/names/{name}/versions/{version}"]
  - $.paths["/deviceUpdate/{instanceId}/updates/providers/{provider}/names/{name}/versions/{version}/files/{fileId}"]
  - $.paths["/deviceUpdate/{instanceId}/updates/operations/{operationId}"]
  - $.paths["/deviceUpdate/{instanceId}/management/operations/{operationId}"]
  transform: >
    $.get.responses["304"] = { description: "The condition specified using HTTP conditional header(s) is not met." };
```

### Add StartImportUpdate method with no final response body
```yaml
directive:
- from: swagger-document
  where: $.paths
  transform: >
    const o = $["/deviceUpdate/{instanceId}/updates:import"];
    const r = Object.assign({}, o.post.responses);
    delete r["200"];
    $["/deviceUpdate/{instanceId}/updates:import?"] = { // Add ? to avoid stomping
      post: {
        tags: o.post.tags.slice(),
        operationId: "DeviceUpdate_StartImportUpdate",
        "x-ms-long-running-operation": true,
        description: o.post.description,
        parameters: o.post.parameters.slice(),
        responses: r,
      }
    };
    return $;
```

### Remove duplicate ImportUpdate LRO for now
This can be deleted when https://github.com/Azure/autorest.csharp/issues/2672 is
fixed and it'll generate a correct `ImportUpdate` method next to the workaround
`StartImportUpdate` method.
```yaml
directive:
- from: swagger-document
  where: $.paths
  transform: >
    delete $["/deviceUpdate/{instanceId}/updates:import"];
    return $;
```
