# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DeploymentManager
namespace: Azure.ResourceManager.DeploymentManager
require: https://github.com/Azure/azure-rest-api-specs/blob/2f28b5026a4b44adefd0237087acb0c48cfe31a6/specification/deploymentmanager/resource-manager/readme.md
tag: package-2019-11-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

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
  - from: deploymentmanager.json
    where: $.definitions
    transform: >
      $.tempRolloutProperties = {
          'description': 'All properties for a rollout.',
          'allOf': [
            {
              '$ref': '#/definitions/RolloutRequestProperties'
            },
            {
              '$ref': '#/definitions/RolloutProperties'
            }
          ]
        };
  - from: deploymentmanager.json
    where: $.definitions
    transform: >
      delete $.ArtifactSource.properties.properties['allOf'];
      $.ArtifactSource.properties.properties['$ref'] = '#/definitions/ArtifactSourceProperties';
      delete $.Rollout.properties.properties['allOf'];
      $.Rollout.properties.properties['$ref'] = '#/definitions/tempRolloutProperties';
      $.HealthCheckStepAttributes.properties.waitDuration['format'] = 'duration';
      $.HealthCheckStepAttributes.properties.maxElasticDuration['format'] = 'duration'; 
      $.HealthCheckStepAttributes.properties.healthyStateDuration['format'] = 'duration';
      $.WaitStepAttributes.properties.duration['format'] = 'duration';
  - from: deploymentmanager.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeploymentManager/rollouts/{rolloutName}']
    transform: >
      $.put.responses['201']['schema']['$ref'] = '#/definitions/Rollout';

```