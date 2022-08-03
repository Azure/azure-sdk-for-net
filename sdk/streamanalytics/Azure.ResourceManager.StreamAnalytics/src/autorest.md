# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: StreamAnalytics
namespace: Azure.ResourceManager.StreamAnalytics
require: https://github.com/Azure/azure-rest-api-specs/blob/692cb8b5eb71505afa267cfbbee322d520eb15ff/specification/streamanalytics/resource-manager/readme.md
tag: package-2021-10-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

mgmt-debug: 
  show-serialized-names: true

list-exception:
- /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.StreamAnalytics/streamingjobs/{jobName}/transformations/{transformationName}

rename-mapping:
  Cluster: StreamAnalyticsCluster
  Function: StreamingJobFunction
  SubResource: StreamAnalyticsSubResource
  UpdateMode: FunctionUpdateMode
  UdfType: FunctionUdfType
  Input: StreamingJobInput
  Encoding: StreamEncoding
  Output: StreamingJobOutput
  PrivateEndpoint: StreamAnalyticsPrivateEndpoint
  Transformation: StreamingJobTransformation
  External: ExternalStorageAccount
  TestInput: StreamAnalyticsTestInputContent
  TestOutput: StreamAnalyticsTestOutputContent
  TestQuery: StreamAnalyticsTestQueryContent
  TestDatasourceResult: StreamAnalyticsTestResult
  TestDatasourceResultStatus: StreamAnalyticsTestResultStatus

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag

directive:
- from: definitions.json
  where: $.definitions
  transform: >
    $.Error.properties.error['x-ms-client-flatten'] = true;
    $.Error['x-ms-client-name'] = 'StreamAnalyticsError';
    $.ErrorDetails['x-ms-client-name'] = 'StreamAnalyticsErrorDetails';
- from: inputs.json
  where: $.definitions
  transform: >
    $.ResourceTestStatus.properties.error['x-ms-client-flatten'] = true;
- from: subscriptions.json
  where: $.definitions
  transform: >
    $.TestQuery.properties.diagnostics['x-ms-client-flatten'] = true;
# Manual fix the Identity model to match the common ManagedServiceIdentity
- from: streamingjobs.json
  where: $.definitions.Identity
  transform: >
    $.properties.principalId['readOnly'] = true;
    $.properties.tenantId['readOnly'] = true;
    delete $.properties.userAssignedIdentities;
    $.properties.type = {
          "type": "string",
          "description": "The identity type.",
          "enum": [
            "SystemAssigned",
            "UserAssigned",
            "SystemAssigned,UserAssigned"
          ],
          "x-ms-enum": {
            "name": "IdentityType",
            "modelAsString": true
          }
        };

```
