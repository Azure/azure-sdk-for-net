# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DeploymentManager
namespace: Azure.ResourceManager.DeploymentManager
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/2f28b5026a4b44adefd0237087acb0c48cfe31a6/specification/deploymentmanager/resource-manager/readme.md
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
  # It generates a new model if the property is `allOf`, that will cause dup model error.
  # So the normal solution is changing all `allOf` property to direct `ref`, but `ref` doesn't support multiple target,
  # to solve this problem here defines a temporary model `tempRolloutProperties` as a workaround.
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
  # Fix durations
  - from: deploymentmanager.json
    where: $.definitions
    transform: >
      $.HealthCheckStepAttributes.properties.waitDuration['format'] = 'duration';
      $.HealthCheckStepAttributes.properties.maxElasticDuration['format'] = 'duration';
      $.HealthCheckStepAttributes.properties.healthyStateDuration['format'] = 'duration';
      $.WaitStepAttributes.properties.duration['format'] = 'duration';
  # `Rollout` is a superset of `RolloutRequest`, if not change this then the tag operations code can't pass compile
  - from: deploymentmanager.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeploymentManager/rollouts/{rolloutName}']
    transform: >
      $.put.responses['201']['schema']['$ref'] = '#/definitions/Rollout';

```
