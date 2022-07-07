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
 
list-exception:
- /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.StreamAnalytics/streamingjobs/{jobName}/transformations/{transformationName}

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
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
  Etag: ETag

directive:
- from: definitions.json
  where: $.definitions
  transform: >
    $.Error.properties.error['x-ms-client-flatten'] = true;
    $.Error['x-ms-client-name'] = 'StreamAnalyticsError';
    $.ErrorDetails['x-ms-client-name'] = 'StreamAnalyticsErrorDetails';
- from: clusters.json
  where: $.definitions
  transform: >
    $.Cluster['x-ms-client-name'] = 'StreamAnalyticsCluster';
    $.Cluster['x-ms-client-name'] = 'StreamAnalyticsCluster';
- from: functions.json
  where: $.definitions
  transform: >
    $.Function['x-ms-client-name'] = 'StreamingJobFunction';
    $.SubResource['x-ms-client-name'] = 'StreamAnalyticsSubResource';
    $.UpdateMode['x-ms-client-name'] = 'FunctionUpdateMode';
    $.UdfType['x-ms-client-name'] = 'FunctionUdfType';
- from: inputs.json
  where: $.definitions
  transform: >
    $.Input['x-ms-client-name'] = 'StreamingJobInput';
    $.Encoding['x-ms-enum']['name'] = 'StreamEncoding';
    $.SubResource['x-ms-client-name'] = 'StreamAnalyticsSubResource';
    $.ResourceTestStatus.properties.error['x-ms-client-flatten'] = true;
- from: outputs.json
  where: $.definitions
  transform: >
    $.Output['x-ms-client-name'] = 'StreamingJobOutput';
    $.SubResource['x-ms-client-name'] = 'StreamAnalyticsSubResource';
- from: privateEndpoints.json
  where: $.definitions
  transform: >
    $.PrivateEndpoint['x-ms-client-name'] = 'StreamAnalyticsPrivateEndpoint';
- from: transformations.json
  where: $.definitions
  transform: >
    $.Transformation['x-ms-client-name'] = 'StreamingJobTransformation';
    $.SubResource['x-ms-client-name'] = 'StreamAnalyticsSubResource';
- from: streamingjobs.json
  where: $.definitions
  transform: >
    $.External['x-ms-client-name'] = 'ExternalStorageAccount';
    $.Identity['x-ms-client-name'] = 'ManagedIdentity';
- from: subscriptions.json
  where: $.definitions
  transform: >
    $.SubResource['x-ms-client-name'] = 'StreamAnalyticsSubResource';
    $.TestInput['x-ms-client-name'] = 'TestInputContent';
    $.TestOutput['x-ms-client-name'] = 'TestOutputContent';
    $.TestQuery['x-ms-client-name'] = 'TestQueryContent';
```