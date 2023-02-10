# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ProviderHub
namespace: Azure.ResourceManager.ProviderHub
require: https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/providerhub/resource-manager/readme.md
tag: package-2021-09-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mappting:
  Origin: OperationOriginType

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
  /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/resourcetypeRegistrations/{resourceType}/skus/{sku}: ResourceTypeSku
  /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/resourcetypeRegistrations/{resourceType}/resourcetypeRegistrations/{nestedResourceTypeFirst}/skus/{sku}: NestedResourceTypeFirstSku
  /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/resourcetypeRegistrations/{resourceType}/resourcetypeRegistrations/{nestedResourceTypeFirst}/resourcetypeRegistrations/{nestedResourceTypeSecond}/skus/{sku}: NestedResourceTypeSecondSku
  /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/resourcetypeRegistrations/{resourceType}/resourcetypeRegistrations/{nestedResourceTypeFirst}/resourcetypeRegistrations/{nestedResourceTypeSecond}/resourcetypeRegistrations/{nestedResourceTypeThird}/skus/{sku}: NestedResourceTypeThirdSku

directive:
  # The operation methods here is no defined correctly, removed
  - from: providerhub.json
    where: $.paths
    transform: >
      delete $['/providers/Microsoft.ProviderHub/operations'];
      delete $['/subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/operations/default'];
  # It generates a new model if the property is `allOf`, that will cause dup model error.
  # So the normal solution is changing all `allOf` property to direct.
  - from: providerhub.json
    where: $.definitions
    transform: >
      delete $.CustomRollout.properties.properties['allOf'];
      $.CustomRollout.properties.properties['$ref'] = '#/definitions/CustomRolloutProperties';
      delete $.ProviderRegistration.properties.properties['allOf'];
      $.ProviderRegistration.properties.properties['$ref'] = '#/definitions/ProviderRegistrationProperties';
      delete $.ResourceTypeRegistration.properties.properties['allOf'];
      $.ResourceTypeRegistration.properties.properties['$ref'] = '#/definitions/ResourceTypeRegistrationProperties';
      delete $.DefaultRollout.properties.properties['allOf'];
      $.DefaultRollout.properties.properties['$ref'] = '#/definitions/DefaultRolloutProperties';
      delete $.NotificationRegistration.properties.properties['allOf'];
      $.NotificationRegistration.properties.properties['$ref'] = '#/definitions/NotificationRegistrationProperties';
      $.ResourceTypeSku["x-ms-client-name"] = "ResourceTypeSkuInfo";

```