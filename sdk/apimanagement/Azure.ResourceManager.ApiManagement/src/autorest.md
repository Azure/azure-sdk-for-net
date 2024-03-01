# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ApiManagement
namespace: Azure.ResourceManager.ApiManagement
require: https://github.com/Azure/azure-rest-api-specs/blob/2f28b5026a4b44adefd0237087acb0c48cfe31a6/specification/apimanagement/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
skip-serialization-format-xml: true
# mgmt-debug:
#   show-serialized-names: true

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.ApiManagement/locations/{location}/deletedservices/{serviceName}

request-path-is-non-resource:
# The Id of content type does not meet the criteria of ResourceIdentifier (E.g. /contentTypes/page)
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/contentTypes/{contentTypeId}
# The Id of content item does not meet the criteria of ResourceIdentifier (E.g. /contentTypes/page/contentItems/4e3cf6a5-574a-ba08-1f23-2e7a38faa6d8)
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/contentTypes/{contentTypeId}/contentItems/{contentItemId}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/diagnostics/{diagnosticId}: ApiDiagnostic
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues/{issueId}: ApiIssue
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/policies/{policyId}: ApiPolicy
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/tags/{tagId}: ApiTag
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operations/{operationId}/policies/{policyId}: ApiOperationPolicy
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operations/{operationId}/tags/{tagId}: ApiOperationTag
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/diagnostics/{diagnosticId}: ApiManagementDiagnostic
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/issues/{issueId}: ApiManagementIssue
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/policies/{policyId}: ApiManagementPolicy
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/subscriptions/{sid}: ApiManagementSubscription
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tags/{tagId}: ApiManagementTag
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/users/{userId}: ApiManagementUser
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/policies/{policyId}: ApiManagementProductPolicy
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/tags/{tagId}: ApiManagementProductTag
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/users/{userId}/subscriptions/{sid}: ApiManagementUserSubscription

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  'locationName': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'ApiVersionSetId': 'arm-id'
  'SourceApiId': 'arm-id'
  'PrivateIPAddresses': 'ip-address'
  'PublicIPAddresses': 'ip-address'

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
  Url: Uri
  Etag: ETag|etag

override-operation-name:
  NetworkStatus_ListByLocation: GetNetworkStatusByLocation
  TenantAccessGit_RegeneratePrimaryKey: RegeneratePrimaryKeyForGit
  TenantAccessGit_RegenerateSecondaryKey: RegenerateSecondaryKeyForGit
  ApiProduct_ListByApis: GetApiProducts
  ApiManagementServiceSkus_ListAvailableServiceSkus: GetAvailableApiManagementServiceSkus
  NetworkStatus_ListByService: GetNetworkStatuses
  OutboundNetworkDependenciesEndpoints_ListByService: GetOutboundNetworkDependenciesEndpoints
  PolicyDescription_ListByService: GetPolicyDescriptions
  PortalSettings_ListByService: GetPortalSettings
  QuotaByCounterKeys_ListByService: GetQuotaByCounterKeys
  Region_ListByService: GetRegions
  TenantConfiguration_GetSyncState: GetTenantConfigurationSyncState
  TagResource_ListByService: GetTagResources
  GatewayApi_GetEntityTag: GetGatewayApiEntityTag
  GroupUser_CheckEntityExists: CheckGroupUserEntityExists
  NotificationRecipientEmail_CheckEntityExists: CheckNotificationRecipientEmailEntityExists
  NotificationRecipientUser_CheckEntityExists: CheckNotificationRecipientUserEntityExists
  ProductApi_CheckEntityExists: CheckProductApiEntityExists
  ProductGroup_CheckEntityExists: CheckProductGroupEntityExists
  ApiManagementService_CheckNameAvailability: CheckApiManagementServiceNameAvailability
  ApiManagementService_GetDomainOwnershipIdentifier: GetApiManagementServiceDomainOwnershipIdentifier
  ContentType_ListByService: GetContentTypes
  ContentItem_ListByService: GetContentItems
  ContentItem_GetEntityTag: GetContentItemEntityTag
  ProductSubscriptions_List: GetAllProductSubscriptionData # temporary - to be removed once the polymorphic resource change is merged.

prepend-rp-prefix:
- ResourceSkuCapacity
- ResourceSkuCapacityScaleType

rename-mapping:
  GatewayHostnameConfigurationContract.properties.negotiateClientCertificate: IsClientCertificateRequired
  SubscriptionsDelegationSettingsProperties.enabled: IsSubscriptionDelegationEnabled
  RegistrationDelegationSettingsProperties.enabled: IsUserRegistrationDelegationEnabled
  DiagnosticContract.properties.logClientIp: IsLogClientIPEnabled
  BackendTlsProperties.validateCertificateChain: ShouldValidateCertificateChain
  BackendTlsProperties.validateCertificateName: ShouldValidateCertificateName
  HostnameConfiguration.defaultSslBinding: IsDefaultSslBindingEnabled
  HostnameConfiguration.negotiateClientCertificate: IsClientCertificateNegotiationEnabled
  PortalSettingsContract.properties.enabled: IsRedirectEnabled
  TermsOfServiceProperties.enabled: IsDisplayEnabled
  TermsOfServiceProperties.consentRequired: IsConsentRequired
  AccessInformationCreateParameters.properties.enabled: IsDirectAccessEnabled
  TenantConfigurationSyncStateContract.properties.isExport: IsExported
  AccessInformationSecretsContract.enabled: IsDirectAccessEnabled
  AccessInformationUpdateParameters.properties.enabled: IsDirectAccessEnabled
  PortalSigninSettings.properties.enabled: IsRedirectEnabled
  PortalSignupSettings.properties.enabled: IsSignUpDeveloperPortalEnabled
  AccessInformationContract.properties.enabled: IsDirectAccessEnabled
  BackendContract.properties.resourceId: ResourceUri|uri
  BackendUpdateParameters.properties.resourceId: ResourceUri|uri
  RequestReportRecordContract.subscriptionId: SubscriptionResourceId|arm-id
  RequestReportRecordContract.method: -|request-method
  RequestReportRecordContract.ipAddress: -|ip-address
  ReportRecordContract.subscriptionId: SubscriptionResourceId|arm-id
  SubscriptionsDelegationSettingsProperties: SubscriptionDelegationSettingProperties
  RegistrationDelegationSettingsProperties: RegistrationDelegationSettingProperties
  OpenidConnectProviderContract: ApiManagementOpenIdConnectProvider
  OpenidConnectProviderUpdateContract: OpenIdConnectProviderUpdateContract
  VirtualNetworkConfiguration.vnetid: VnetId
  AccessInformationContract: TenantAccessInfo
  AccessInformationContract.properties.id: AccessInfoType
  AccessIdName: AccessName
  AccessIdName.access: TenantAccess
  AccessIdName.gitAccess: TenantGitAccess
  ApiContract: Api
  ApiCollection: ApiListResult
  NetworkStatusContractByLocation: NetworkStatusContractWithLocation
  ApiManagementServiceResource: ApiManagementService
  ApiReleaseContract: ApiRelease
  OperationContract: ApiOperation
  SchemaContract: ApiSchema
  TagDescriptionContract: ApiTagDescription
  ApiManagementServiceBackupRestoreParameters: ApiManagementServiceBackupRestoreContent
  OperationResultContract: GitOperationResultContractData
  ConfigurationIdName: ConfigurationName
  SaveConfigurationParameter: ConfigurationSaveContent
  SaveConfigurationParameter.properties.force: ForceUpdate
  DeployConfigurationParameters: ConfigurationDeployContent
  DeployConfigurationParameters.properties.force: ForceDelete
  ApiVersionSetContract: ApiVersionSet
  AuthorizationServerContract:  ApiManagementAuthorizationServer
  BackendContract: ApiManagementBackend
  CacheContract: ApiManagementCache
  CertificateContract: ApiManagementCertificate
  CertificateContract.properties.expirationDate: ExpireOn
  CertificateContract.properties.keyVault: KeyVaultDetails
  CertificateCreateOrUpdateParameters.properties.keyVault: KeyVaultDetails
  ContentTypeContract: ApiManagementContentType
  ContentTypeContract.properties.id: ContentTypeIdentifier
  ContentTypeContract.properties.name: ContentTypeName
  EmailTemplateContract: ApiManagementEmailTemplate
  GatewayContract: ApiManagementGateway
  GlobalSchemaContract: ApiManagementGlobalSchema
  GroupContract: ApiManagementGroup
  GroupContract.properties.type: GroupType
  GroupContract.properties.builtIn: IsBuiltIn
  IdentityProviderContract: ApiManagementIdentityProvider
  IdentityProviderContract.properties.type: IdentityProviderType
  LoggerContract: ApiManagementLogger
  NamedValueContract: ApiManagementNamedValue
  NamedValueContract.properties.keyVault: KeyVaultDetails
  NotificationContract: ApiManagementNotification
  PolicyDescriptionContract: PolicyDescriptionContractData
  PortalDelegationSettings: ApiManagementPortalDelegationSettings
  PortalRevisionContract: ApiManagementPortalRevision
  PortalSettingsContract: PortalSettingsContractData
  PortalSigninSettings: ApiManagementPortalSignInSettings
  PortalSignupSettings: ApiManagementPortalSignUpSettings
  ProductContract: ApiManagementProduct
  TenantSettingsContract: ApiManagementTenantSettings
  ConnectivityCheckResponse: ConnectivityCheckResult
  QuotaCounterValueUpdateContract: QuotaCounterValueUpdateContent
  ContentItemContract: ApiManagementContentItem
  DeletedServiceContract: ApiManagementDeletedService
  DeletedServiceContract.properties.deletionDate: DeletedOn
  EmailTemplateUpdateParameters: ApiManagementEmailTemplateCreateOrUpdateContent
  GatewayCertificateAuthorityContract: ApiManagementGatewayCertificateAuthority
  GatewayHostnameConfigurationContract: ApiManagementGatewayHostnameConfiguration
  IssueAttachmentContract: ApiIssueAttachment
  IssueCommentContract: ApiIssueComment
  ProductState: ApiManagementProductState
  UserState: ApiManagementUserState
  TagCreateUpdateParameters: ApiManagementTagCreateOrUpdateContent
  SubscriptionContract.properties.expirationDate: ExpireOn
  SubscriptionContract.properties.notificationDate: NotifiesOn
  UserContract.properties.registrationDate: RegistriesOn
  AccessInformationSecretsContract: TenantAccessInfoSecretsDetails
  AccessInformationSecretsContract.id: AccessInfoType
  ApiManagementServiceCheckNameAvailabilityParameters: ApiManagementServiceNameAvailabilityContent
  ApiManagementServiceNameAvailabilityResult.nameAvailable: IsNameAvailable
  NameAvailabilityReason: ApiManagementServiceNameUnavailableReason
  ApiType.websocket: WebSocket
  ApiType.graphql: GraphQL
  ProvisioningState: AssociationEntityProvisioningState
  AuthenticationSettingsContract.openid: OpenId
  CertificateInformation.expiry: ExpireOn
  Confirmation: ConfirmationEmailType
  Confirmation.signup: SignUp
  ConnectivityCheckProtocol.TCP: Tcp
  ConnectivityStatusContract.lastUpdated: LastUpdatedOn
  ConnectivityStatusContract.lastStatusChange: lastStatusChangedOn
  ContentFormat.openapi: OpenApi
  ContentFormat.openapi+json: OpenApiJson
  ContentFormat.openapi-link: OpenApiLink
  ContentFormat.openapi+json-link: OpenApiJsonLink
  ContentFormat.graphql-link: GraphQLLink
  ConnectivityCheckRequestProtocolConfigurationHttpConfiguration: ConnectivityCheckRequestHttpConfiguration
  Method: HttpMethodConfiguration
  Method.GET: Get
  HttpHeader: HttpHeaderConfiguration
  NotificationName.BCC: Bcc
  OpenIdAuthenticationSettingsContract.openidProviderId: OpenIdProviderId
  OperationResultContract.properties.id: OperationResultIdentifier
  OperationResultContract.properties.started: StartedOn
  OperationResultContract.properties.updated: UpdatedOn
  PolicyContentFormat.rawxml: RawXml
  PolicyContentFormat.rawxml-link: RawXmlLink
  PolicyIdName: PolicyName
  ProductEntityBaseParameters: ProductEntityBaseProperties
  SubscriptionUpdateParameters.properties.expirationDate: ExpireOn
  SettingsTypeName: SettingsType
  TagResourceContract: TagResourceContractDetails
  TagResourceContractProperties: AssociatedTagProperties
  ApiTagResourceContractProperties: AssociatedApiProperties
  OperationTagResourceContractProperties: AssociatedOperationProperties
  ProductTagResourceContractProperties: AssociatedProductProperties
  UserTokenParameters.properties.expiry: ExpireOn
  AuthorizationMethod.GET: Get
  AuthorizationMethod.PUT: Put
  GroupContractProperties.builtIn: IsBuiltIn
  GroupType: ApiManagementGroupType
  AccessType: StorageAccountAccessType
  GatewayKeyRegenerationRequestContract: GatewayKeyRegenerateContent
  KeyType: TokenGenerationUsedKeyType
  Verbosity: TraceVerbosityLevel
  State: IssueState
  Severity: IssueSeverity
  Origin: IssueOrigin
  Protocol: ApiOperationInvokableProtocol
  PolicyExportFormat.rawxml: RawXml
  ResourceSkuResult: AvailableApiManagementServiceSkuResult
  SkuType: ApiManagementServiceSkuType
  PrivateLinkResource: ApiManagementPrivateLinkResource
  HostnameConfiguration.keyVaultId: keyVaultSecretUri
  ParameterContract.required: IsRequired
  SchemaType: ApiSchemaType
  ApiRevisionContract.privateUrl: privateUrlString

directive:
  - remove-operation: 'ApiManagementOperations_List'
  - from: definitions.json
    where: $.definitions
    transform: >
      $.AuthorizationServerContractBaseProperties.properties.bearerTokenSendingMethods.items['x-ms-enum']['name'] = 'BearerTokenSendingMethod';
      $.AuthorizationServerContractBaseProperties.properties.clientAuthenticationMethod['x-ms-client-name'] = 'ClientAuthenticationMethods';
      $.BearerTokenSendingMethodsContract['x-ms-enum']['name'] = 'BearerTokenSendingMethod';
      $.ApiEntityBaseContract.properties.subscriptionRequired['x-ms-client-name'] = 'IsSubscriptionRequired';
      $.CacheContractProperties.properties.resourceId['x-ms-client-name'] = 'resourceUri';
      $.CacheUpdateProperties.properties.resourceId['x-ms-client-name'] = 'resourceUri';
      $.IdentityProviderBaseParameters.properties.type['x-ms-client-name'] = 'IdentityProviderType';
      $.IdentityProviderBaseParameters.properties.signinTenant['x-ms-client-name'] = 'SignInTenant';
      $.IdentityProviderBaseParameters.properties.signupPolicyName['x-ms-client-name'] = 'SignUpPolicyName';
      $.IdentityProviderBaseParameters.properties.signinPolicyName['x-ms-client-name'] = 'SignInPolicyName';
      $.IssueContractBaseProperties.properties.apiId['x-ms-format'] = 'arm-id';
      $.IssueContractProperties.properties.userId['x-ms-format'] = 'arm-id';
      $.LoggerContractProperties.properties.resourceId['x-ms-format'] = 'arm-id';
      $.NamedValueEntityBaseParameters.properties.secret['x-ms-client-name'] = 'IsSecret';
      $.ProductEntityBaseParameters.properties.subscriptionRequired['x-ms-client-name'] = 'IsSubscriptionRequired';
      $.ProductEntityBaseParameters.properties.approvalRequired['x-ms-client-name'] = 'IsApprovalRequired';
      $.ApiVersionSetContractDetails.properties.versioningScheme['x-ms-enum'] = {
          "name": "versioningScheme",
          "modelAsString": true
        }
      $.ConnectivityHop.properties.address['x-ms-format'] = 'ip-address';
      $.ConnectivityHop.properties.resourceId['x-ms-format'] = 'arm-id';
      $.RemotePrivateEndpointConnectionWrapper.properties.id['x-ms-format'] = 'arm-id';
      $.RemotePrivateEndpointConnectionWrapper.properties.type['x-ms-format'] = 'resource-type';
      $.ApiReleaseContractProperties.properties.apiId['x-ms-format'] = 'arm-id';
      $.GatewayKeyRegenerationRequestContract.properties.keyType['x-ms-enum']['name'] = 'GatewayRegenerateKeyType';
      for (var key in $) {
          if (key.endsWith('Collection')) {
              for (var property in $[key].properties) {
                  if (property === 'value' && $[key].properties[property].type === 'array') {
                      $[key]['x-ms-client-name'] = key.replace('Collection', 'ListResult');
                  }
              }
          }
        }
      $.IssueCommentContractProperties.properties.userId['x-ms-format'] = 'arm-id';
      $.AuthorizationServerContractBaseProperties.properties.supportState['x-ms-client-name'] = 'DoesSupportState';
      $.DeletedServiceContractProperties.properties.serviceId['x-ms-format'] = 'arm-id';
      $.PortalSettingsContractProperties.properties.subscriptions['x-ms-client-name'] = 'IsSubscriptions';
      $.PortalSettingsContractProperties.properties.userRegistration['x-ms-client-name'] = 'IsUserRegistration';
      $.PrivateEndpointConnectionRequest.properties.id['x-ms-format'] = 'arm-id';
  - from: apimskus.json
    where: $.definitions
    transform: >
      $.ApiManagementSku.properties.locations.items['x-ms-format'] = 'azure-location';
  - from: apimdeployment.json
    where: $.definitions
    transform: >
      delete $.Operation;
      delete $.OperationListResult;
      $.VirtualNetworkConfiguration.properties.vnetid['format'] = 'uuid';
      $.VirtualNetworkConfiguration.properties.subnetResourceId['x-ms-format'] = 'arm-id';
      $.ResourceSkuResult.properties.resourceType['x-ms-format'] = 'resource-type';
      $.ApiManagementServiceBaseProperties.properties.publicIpAddressId['x-ms-format'] = 'arm-id';
      $.AdditionalLocation.properties.publicIpAddressId['x-ms-format'] = 'arm-id';
  - from: apimanagement.json
    where: $.parameters
    transform: >
      $.OpenIdConnectIdParameter['x-ms-client-name'] = 'OpenId';
      $.IfMatchOptionalParameter['x-ms-format'] = 'etag';
      $.IfMatchRequiredParameter['x-ms-format'] = 'etag';
  - from: apimgroups.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/groups/{groupId}/users'].get.responses['200'].schema = {
          "x-ms-client-name": "ApiManagementGroupUserListResult",
          "type": "object",
          "properties": {
              "value": {
                  "type": "array",
                  "items": {
                      "x-ms-client-name": "ApiManagementGroupUserData",
                      "type": "object",
                      "allOf": [
                          {
                              "$ref": "./definitions.json#/definitions/UserContract"
                          }
                      ]
                  },
                  "description": "Page values."
              },
              "count": {
                  "type": "integer",
                  "format": "int64",
                  "description": "Total record count number across all pages."
              },
              "nextLink": {
                  "type": "string",
                  "description": "Next page link if any."
              }
          },
          "description": "Paged Group Users list representation."
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/groups/{groupId}/users/{userId}'].put.responses['200'].schema = {
          "x-ms-client-name": "ApiManagementGroupUserData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "./definitions.json#/definitions/UserContract"
              }
          ]
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/groups/{groupId}/users/{userId}'].put.responses['201'].schema = {
          "x-ms-client-name": "ApiManagementGroupUserData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "./definitions.json#/definitions/UserContract"
              }
          ]
        }
    reason: Modify the original swagger since the id in the real response is slightly different from the ApiManagementUserResource.
  - from: apimgateways.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/apis'].get.responses['200'].schema = {
          "x-ms-client-name": "ApiManagementGatewayApiListResult",
          "type": "object",
          "properties": {
              "value": {
                  "type": "array",
                  "items": {
                      "x-ms-client-name": "GatewayApiData",
                      "type": "object",
                      "allOf": [
                          {
                              "$ref": "./definitions.json#/definitions/ApiContract"
                          }
                      ]
                  },
                  "description": "Page values.",
                  "readOnly": true
              },
              "count": {
                  "type": "integer",
                  "format": "int64",
                  "description": "Total record count number across all pages."
              },
              "nextLink": {
                  "type": "string",
                  "description": "Next page link if any.",
                  "readOnly": true
              }
          },
          "description": "Paged API list representation."
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/apis/{apiId}'].put.responses['200'].schema = {
          "x-ms-client-name": "GatewayApiData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "./definitions.json#/definitions/ApiContract"
              }
          ]
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/apis/{apiId}'].put.responses['201'].schema = {
          "x-ms-client-name": "GatewayApiData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "./definitions.json#/definitions/ApiContract"
              }
          ]
        }
    reason: Modify the original swagger since the id in the real response is slightly different from the ApiResource.
  - from: apimproducts.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/apis'].get.responses['200'].schema = {
          "x-ms-client-name": "ApiManagementProductApiListResult",
          "type": "object",
          "properties": {
              "value": {
                  "type": "array",
                  "items": {
                      "x-ms-client-name": "ProductApiData",
                      "type": "object",
                      "allOf": [
                          {
                              "$ref": "./definitions.json#/definitions/ApiContract"
                          }
                      ]
                  },
                  "description": "Page values.",
                  "readOnly": true
              },
              "count": {
                  "type": "integer",
                  "format": "int64",
                  "description": "Total record count number across all pages."
              },
              "nextLink": {
                  "type": "string",
                  "description": "Next page link if any.",
                  "readOnly": true
              }
          },
          "description": "Paged API list representation."
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/apis/{apiId}'].put.responses['200'].schema = {
          "x-ms-client-name": "ProductApiData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "./definitions.json#/definitions/ApiContract"
              }
          ]
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/apis/{apiId}'].put.responses['201'].schema = {
          "x-ms-client-name": "ProductApiData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "./definitions.json#/definitions/ApiContract"
              }
          ]
        }
    reason: Modify the original swagger since the id in the real response is slightly different from the ApiResource.
  - from: apimproducts.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/groups'].get.responses['200'].schema = {
          "x-ms-client-name": "ApiManagementProductGroupListResult",
          "type": "object",
          "properties": {
              "value": {
                  "type": "array",
                  "items": {
                      "x-ms-client-name": "ProductGroupData",
                      "type": "object",
                      "allOf": [
                          {
                              "$ref": "./definitions.json#/definitions/GroupContract"
                          }
                      ]
                  },
                  "description": "Page values.",
                  "readOnly": true
              },
              "count": {
                  "type": "integer",
                  "format": "int64",
                  "description": "Total record count number across all pages."
              },
              "nextLink": {
                  "type": "string",
                  "description": "Next page link if any."
              }
          },
          "description": "Paged Group list representation."
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/groups/{groupId}'].put.responses['200'].schema = {
          "x-ms-client-name": "ProductGroupData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "./definitions.json#/definitions/GroupContract"
              }
          ]
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/groups/{groupId}'].put.responses['201'].schema = {
          "x-ms-client-name": "ProductGroupData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "./definitions.json#/definitions/GroupContract"
              }
          ]
        }
    reason: Modify the original swagger since the id in the real response is slightly different from the ApiManagementGroupResource.
  - from: swagger-document
    where: $..[?(@.name=='$orderby')]
    transform: $['x-ms-client-name'] = 'orderBy'

```
