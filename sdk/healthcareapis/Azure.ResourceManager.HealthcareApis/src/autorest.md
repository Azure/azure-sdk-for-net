# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HealthcareApis
namespace: Azure.ResourceManager.HealthcareApis
require: https://github.com/Azure/azure-rest-api-specs/blob/aa8a23b8f92477d0fdce7af6ccffee1c604b3c56/specification/healthcareapis/resource-manager/readme.md
tag: package-2022-06
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

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthcareApis/services/{resourceName}/privateLinkResources/{groupName}: HealthcareApisServicePrivateLinkResource
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthcareApis/workspaces/{workspaceName}/privateLinkResources/{groupName}: HealthcareApisWorkspacePrivateLinkResource
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthcareApis/services/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}: HealthcareApisServicePrivateEndpointConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthcareApis/workspaces/{workspaceName}/privateEndpointConnections/{privateEndpointConnectionName}: HealthcareApisWorkspacePrivateEndpointConnection

rename-mapping:
  ServicesDescription: HealthcareApisService
  Workspace: HealthcareApisWorkspace
  PrivateEndpointConnectionDescription: HealthcareApisPrivateEndpointConnection

mgmt-debug:
  show-serialized-names: true

directive:
# here we override the put body parameter of the private endpoint connection APIs with the PrivateEndpointConnection defined in this RP, because the previous value (from common-types) is exactly the same as this one
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthcareApis/services/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}"].put.parameters
    transform: >
      $[5].schema["$ref"] = "#/definitions/PrivateEndpointConnectionDescription";
# override all the occurrence of this type
  - from: swagger-document
    where: $.definitions.ServicesProperties.properties.privateEndpointConnections.items["$ref"]
    transform: return "#/definitions/PrivateEndpointConnectionDescription"
  - from: swagger-document
    where: $.definitions.Workspace.properties.properties.properties.privateEndpointConnections.items["$ref"]
    transform: return "#/definitions/PrivateEndpointConnectionDescription"
  - from: swagger-document
    where: $.definitions.DicomServiceProperties.properties.privateEndpointConnections.items["$ref"]
    transform: return "#/definitions/PrivateEndpointConnectionDescription"
  - from: swagger-document
    where: $.definitions.FhirServiceProperties.properties.privateEndpointConnections.items["$ref"]
    transform: return "#/definitions/PrivateEndpointConnectionDescription"
# rename the original PrivateEndpointConnection to avoid duplicate schema. This type should never be generated.
  - from: swagger-document
    where: $.definitions.PrivateEndpointConnection
    transform: $["x-ms-client-name"] = "DummyPrivateEndpointConnection"
```
