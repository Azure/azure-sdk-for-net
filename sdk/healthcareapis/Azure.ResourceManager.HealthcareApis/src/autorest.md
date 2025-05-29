# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HealthcareApis
namespace: Azure.ResourceManager.HealthcareApis
require: https://github.com/Azure/azure-rest-api-specs/blob/2d701c73fb5ee44f95b97b6c3eaf8c4aeb051e73/specification/healthcareapis/resource-manager/readme.md
#tag: package-2024-03-31
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

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

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthcareApis/services/{resourceName}/privateLinkResources/{groupName}: HealthcareApisServicePrivateLinkResource
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthcareApis/workspaces/{workspaceName}/privateLinkResources/{groupName}: HealthcareApisWorkspacePrivateLinkResource
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthcareApis/services/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}: HealthcareApisServicePrivateEndpointConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthcareApis/workspaces/{workspaceName}/privateEndpointConnections/{privateEndpointConnectionName}: HealthcareApisWorkspacePrivateEndpointConnection

override-operation-name:
  Services_CheckNameAvailability: CheckHealthcareApisNameAvailability

prepend-rp-prefix:
- ProvisioningState

rename-mapping:
  ServicesDescription: HealthcareApisService
  ServicesProperties: HealthcareApisServiceProperties
  ServiceEventState: FhirServiceEventState
  Workspace: HealthcareApisWorkspace
  WorkspaceProperties: HealthcareApisWorkspaceProperties
  PrivateEndpointConnectionDescription: HealthcareApisPrivateEndpointConnection
  CorsConfiguration: DicomServiceCorsConfiguration
  PublicNetworkAccess: HealthcareApisPublicNetworkAccess
  ResourceVersionPolicyConfiguration: FhirServiceResourceVersionPolicyConfiguration
  PrivateLinkResourceDescription: HealthcareApisPrivateLinkResource
  IotConnector: HealthcareApisIotConnector
  IotEventHubIngestionEndpointConfiguration: HealthcareApisIotConnectorEventHubIngestionConfiguration
  IotFhirDestination: HealthcareApisIotFhirDestination
  IotIdentityResolutionType: HealthcareApisIotIdentityResolutionType
  IotMappingProperties: HealthcareApisIotMappingProperties
  CheckNameAvailabilityParameters: HealthcareApisNameAvailabilityContent
  CheckNameAvailabilityParameters.type: ResourceType|resource-type
  ServicesNameAvailabilityInfo: HealthcareApisNameAvailabilityResult
  ServicesNameAvailabilityInfo.nameAvailable: IsNameAvailable
  ServiceNameUnavailabilityReason: HealthcareApisNameUnavailableReason
  ResourceTags: HealthcareApisResourceTags
  ServiceAccessPolicyEntry: HealthcareApisServiceAccessPolicyEntry
  ServiceAcrConfigurationInfo: HealthcareApisServiceAcrConfiguration
  ServiceAuthenticationConfigurationInfo: HealthcareApisServiceAuthenticationConfiguration
  ServiceCorsConfigurationInfo: HealthcareApisServiceCorsConfiguration
  ServiceCosmosDbConfigurationInfo: HealthcareApisServiceCosmosDbConfiguration
  ServiceImportConfigurationInfo: HealthcareApisServiceImportConfiguration
  ServiceOciArtifactEntry: HealthcareApisServiceOciArtifactEntry
  FhirServiceAuthenticationConfiguration.smartProxyEnabled: IsSmartProxyEnabled
  FhirServiceImportConfiguration.enabled: IsEnabled
  FhirServiceImportConfiguration.initialImportMode: IsInitialImportMode
  ServiceAuthenticationConfigurationInfo.smartProxyEnabled: IsSmartProxyEnabled
  ServiceImportConfigurationInfo.enabled: IsEnabled
  ServiceImportConfigurationInfo.initialImportMode: IsInitialImportMode
  IotFhirDestination.properties.fhirServiceResourceId: -|arm-id
  ServiceCosmosDbConfigurationInfo.crossTenantCmkApplicationId: -|uuid
  ImplementationGuidesConfiguration.usCoreMissingData: IsUsCoreMissingDataEnabled
  DicomService.properties.enableDataPartitions: IsDataPartitionsEnabled
  StorageConfiguration: HealthcareApisServiceStorageConfiguration
  StorageConfiguration.storageResourceId: -|arm-id

directive:
# remove LRO related operations
  - remove-operation: OperationResults_Get
# here we override the put body parameter of the private endpoint connection APIs with the PrivateEndpointConnection defined in this RP, because the previous value (from common-types) is exactly the same as this one
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthcareApis/services/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}"].put.parameters
    transform: >
      $[5].schema["$ref"] = "#/definitions/PrivateEndpointConnectionDescription";
# override all the occurrences of this type
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
# if a type with the name `DummyPrivateEndpointConnection` is generated after an update, there must be more occurrences of the usage of this type in other places of this swagger, please add them to the above list
  - from: swagger-document
    where: $.definitions.PrivateEndpointConnection
    transform: $["x-ms-client-name"] = "DummyPrivateEndpointConnection"
  - from: swagger-document
    where: $.definitions.PrivateLinkResource
    transform: $["x-ms-client-name"] = "DummyPrivateLinkResource"
```
