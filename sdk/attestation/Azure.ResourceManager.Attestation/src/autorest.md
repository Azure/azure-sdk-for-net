# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Attestation
namespace: Azure.ResourceManager.Attestation
require: https://github.com/Azure/azure-rest-api-specs/blob/efa49a123da7ce3ffe093a13832258305f529711/specification/attestation/resource-manager/Microsoft.Attestation/Attestation/readme.md
# tag: package-2021-06-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

no-property-type-replacement: PrivateEndpoint
format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

acronym-mapping:
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

rename-mapping:
  PrivateEndpoint.id: stringId
  JsonWebKey: AttestationPolicyJsonWebKey
  PublicNetworkAccessType: AttestationProviderPublicNetworkAccessType
  AttestationServicePatchSpecificParams: AttestationServicePatchProperties

override-operation-name:
  AttestationProviders_GetDefaultByLocation: GetDefaultAttestationProviderByLocation
  AttestationProviders_ListDefault: GetDefaultAttestationProviders


directive:
  - from: attestation.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Attestation/attestationProviders/{providerName}/privateEndpointConnections/{privateEndpointConnectionName}'].delete
    transform: >
      $['responses'] = {
          "200": {
            "description": "OK -- Delete the private endpoint connection successfully."
          },
          "202": {
            "description": "OK -- Delete the private endpoint connection successfully."
          },
          "204": {
            "description": "No Content -- The private endpoint connection does not exist."
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "#/definitions/CloudError"
            }
          }
        }
    reason: response status 202 missing
```
