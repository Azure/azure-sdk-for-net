# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ApiManagement
namespace: Azure.ResourceManager.ApiManagement
require: https://github.com/Azure/azure-rest-api-specs/blob/87136914a4aea5bd9c9ac24f4b6974348d7560d9/specification/apimanagement/resource-manager/Microsoft.ApiManagement/ApiManagement/readme.md
# tag: package-preview-2025-03-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
    - ApiProduct_ListByApis
    - UserGroup_List
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
  prenamer: true
use-model-reader-writer: true
skip-serialization-format-xml: true
enable-bicep-serialization: true

# mgmt-debug:
#  show-serialized-names: true

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
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}: ApiManagementProduct
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/policyFragments/{id}: PolicyFragmentContract
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apiVersionSets/{versionSetId}: ApiVersionSet
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/schemas/{schemaId}: ApiSchema
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}: Api
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/releases/{releaseId}: ApiRelease
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operations/{operationId}: ApiOperation
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/notifications/{notificationName}: ApiManagementNotification
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/namedValues/{namedValueId}: ApiManagementNamedValue
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/groups/{groupId}: ApiManagementGroup
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/schemas/{schemaId}: ApiManagementGlobalSchema
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/backends/{backendId}: ApiManagementBackend
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/certificates/{certificateId}: ApiManagementCertificate
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/loggers/{loggerId}: ApiManagementLogger
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/gateways/{gatewayName}: ApiGateway
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/gateways/{gatewayName}/configConnections/{configConnectionName}: ApiGatewayConfigConnection

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
- AuthorizationType
- AuthorizationError
- NatGatewayState

rename-mapping:
  GatewayHostnameConfigurationContract.properties.negotiateClientCertificate: IsClientCertificateRequired
  SubscriptionsDelegationSettingsProperties.enabled: IsSubscriptionDelegationEnabled
  RegistrationDelegationSettingsProperties.enabled: IsUserRegistrationDelegationEnabled
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
  VirtualNetworkConfiguration.vnetid: VnetId|uuid
  AccessInformationContract: TenantAccessInfo
  AccessInformationContract.properties.id: AccessInfoType
  AccessIdName: AccessName
  AccessIdName.access: TenantAccess
  AccessIdName.gitAccess: TenantGitAccess
  ApiContract: Api
  NetworkStatusContractByLocation: NetworkStatusContractWithLocation
  ApiManagementServiceResource: ApiManagementService
  ApiReleaseContract: ApiRelease
  BackendUpdateParameters: ApiManagementBackendPatch
  CertificateCreateOrUpdateParameters: ApiManagementCertificateCreateOrUpdateContent
  LoggerUpdateContract: ApiManagementLoggerPatch
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
  AssociationContractPropertiesProvisioningState: AssociationEntityProvisioningState
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
  ApiContract.properties.termsOfServiceUrl: termsOfServiceLink
  ApiContract.properties.serviceUrl: serviceLink
  ApiUpdateContract: ApiPatch
  ApiUpdateContract.properties.termsOfServiceUrl: termsOfServiceLink
  ApiUpdateContract.properties.serviceUrl: serviceLink
  ApiCreateOrUpdateParameter: ApiCreateOrUpdateContent
  ApiCreateOrUpdateParameter.properties.termsOfServiceUrl: termsOfServiceLink
  ApiCreateOrUpdateParameter.properties.serviceUrl: serviceLink
  ApiEntityBaseContract.termsOfServiceUrl: termsOfServiceLink
  AuthorizationConfirmConsentCodeRequestContract: AuthorizationConfirmConsentCodeContent
  AuthorizationLoginRequestContract: AuthorizationLoginContent
  AuthorizationLoginResponseContract: AuthorizationLoginResult
  SubscriptionCreateParameters: ApiManagementSubscriptionCreateOrUpdateContent
  SubscriptionUpdateParameters: ApiManagementSubscriptionPatch
  ProductUpdateParameters: ApiManagementProductPatch
  NamedValueUpdateParameters: ApiManagementNamedValuePatch
  GroupCreateParameters: ApiManagementGroupCreateOrUpdateContent
  GroupCreateParameters.properties.type: ApiManagementGroupType
  GroupUpdateParameters: ApiManagementGroupPatch
  GroupUpdateParameters.properties.type: ApiManagementGroupType
  ApiVersionSetUpdateParameters: ApiVersionSetPatch
  OperationUpdateContract: ApiOperationPatch
  NamedValueCreateContract: ApiManagementNamedValueCreateOrUpdateContent
  ApiManagementGatewayConfigConnectionResource: ApiGatewayConfigConnection
  ApiManagementGatewayResource: ApiGateway
  ApiManagementWorkspaceLinksResource: ApiManagementWorkspaceLinks
  SoapApiType.grpc: Grpc
  AllPoliciesContract.properties.referencePolicyId: -|arm-id
  DiagnosticUpdateContract.properties.logClientIp: IsLogClientIPEnabled
  DiagnosticContract.properties.logClientIp: IsLogClientIPEnabled
  AuthorizationServerContract.properties.clientAuthenticationMethod: ClientAuthenticationMethods
  ApiEntityBaseContract.subscriptionRequired: IsSubscriptionRequired
  CacheContract.properties.resourceId: resourceUri
  CacheUpdateParameters.properties.resourceId: resourceUri
  IdentityProviderContract.properties.signinTenant: SignInTenant
  IdentityProviderContract.properties.signupPolicyName: SignUpPolicyName
  IdentityProviderContract.properties.signinPolicyName: SignInPolicyName
  IssueContract.properties.apiId: -|arm-id
  IssueContract.properties.userId: -|arm-id
  LoggerContract.properties.resourceId: -|arm-id
  NamedValueContract.properties.secret: IsSecret
  ProductEntityBaseParameters.subscriptionRequired: IsSubscriptionRequired
  ProductEntityBaseParameters.approvalRequired: IsApprovalRequired
  ConnectivityHop.address: -|ip-address
  ConnectivityHop.resourceId: -|arm-id
  RemotePrivateEndpointConnectionWrapper.id: -|arm-id
  RemotePrivateEndpointConnectionWrapper.type: -|resource-type
  ApiReleaseContract.properties.apiId: -|arm-id
  IssueCommentContract.properties.userId: -|arm-id
  AuthorizationServerContract.properties.supportState: DoesSupportState
  DeletedServiceContract.properties.serviceId: -|arm-id
  PortalSettingsContract.properties.subscriptions: IsSubscriptions
  PortalSettingsContract.properties.userRegistration: IsUserRegistration
  PrivateEndpointConnectionRequest.id: -|arm-id
  VirtualNetworkConfiguration.subnetResourceId: -|arm-id
  ApiManagementServiceResource.properties.publicIpAddressId: -|arm-id
  AdditionalLocation.publicIpAddressId: -|arm-id
  ApiContract.properties.subscriptionRequired: IsSubscriptionRequired
  ApiUpdateContract.properties.subscriptionRequired: IsSubscriptionRequired
  ApiCreateOrUpdateParameter.properties.subscriptionRequired: IsSubscriptionRequired
  NamedValueUpdateParameters.properties.secret: IsSecret
  ProductUpdateParameters.properties.subscriptionRequired: IsSubscriptionRequired
  ProductUpdateParameters.properties.approvalRequired: IsApprovalRequired
  NamedValueCreateContract.properties.secret: IsSecret
  IdentityProviderUpdateParameters.properties.signupPolicyName: SignUpPolicyName
  IdentityProviderUpdateParameters.properties.signinPolicyName: SignInPolicyName
  IdentityProviderUpdateParameters.properties.signinTenant: SignInTenant
  IdentityProviderUpdateParameters.properties.type: IdentityProviderType
  IdentityProviderCreateContract.properties.signupPolicyName: SignUpPolicyName
  IdentityProviderCreateContract.properties.signinPolicyName: SignInPolicyName
  IdentityProviderCreateContract.properties.signinTenant: SignInTenant
  IdentityProviderCreateContract.properties.type: IdentityProviderType
  AuthorizationServerUpdateContract.properties.supportState: DoesSupportState
  ProductContract.properties.subscriptionRequired: IsSubscriptionRequired
  ProductContract.properties.approvalRequired: IsApprovalRequired
  ResourceSkuResult.resourceType: -|resource-type
  AuthorizationServerUpdateContract.properties.clientAuthenticationMethod: ClientAuthenticationMethods

keep-plural-resource-data:
  - ApiManagementWorkspaceLinks

directive:
  - remove-operation: 'ApiManagementOperations_List'
  - remove-operation: 'OperationStatus_Get'
  - from: openapi.json
    where: $.definitions
    transform: >
      $.KeyType['x-ms-enum']['name'] = 'GatewayRegenerateKeyType';
      for (var key in $) {
          if (key.endsWith('Collection')) {
              for (var property in $[key].properties) {
                  if (property === 'value' && $[key].properties[property].type === 'array') {
                      $[key]['x-ms-client-name'] = key.replace('Collection', 'ListResult');
                  }
              }
          }
        }
  - from: openapi.json
    where: $.definitions
    transform: >
      delete $.Operation;
      delete $.OperationListResult;
  - from: openapi.json
    where: $
    transform: >
      for (var pathName in $.paths) {
          var path = $.paths[pathName];
          if (path.parameters) {
              for (var i = 0; i < path.parameters.length; i++) {
                  if (path.parameters[i].name === 'If-Match') {
                      path.parameters[i]['x-ms-format'] = 'etag';
                  }
              }
          }
          for (var methodName in path) {
              if (methodName === 'parameters') continue;
              var operation = path[methodName];
              if (operation.parameters) {
                  for (var i = 0; i < operation.parameters.length; i++) {
                      if (operation.parameters[i].name === 'If-Match') {
                          operation.parameters[i]['x-ms-format'] = 'etag';
                      }
                  }
              }
          }
      }
      for (var pathName in $.paths) {
          var path = $.paths[pathName];
          if (path.parameters) {
              for (var i = 0; i < path.parameters.length; i++) {
                  if (path.parameters[i].name === 'opid') {
                      path.parameters[i]['x-ms-client-name'] = 'OpenId';
                  }
              }
          }
          for (var methodName in path) {
              if (methodName === 'parameters') continue;
              var operation = path[methodName];
              if (operation.parameters) {
                  for (var i = 0; i < operation.parameters.length; i++) {
                      if (operation.parameters[i].name === 'opid') {
                          operation.parameters[i]['x-ms-client-name'] = 'OpenId';
                      }
                  }
              }
          }
      }
  - from: openapi.json
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
                              "$ref": "#/definitions/UserContract"
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
                  "$ref": "#/definitions/UserContract"
              }
          ]
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/groups/{groupId}/users/{userId}'].put.responses['201'].schema = {
          "x-ms-client-name": "ApiManagementGroupUserData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "#/definitions/UserContract"
              }
          ]
        }
    reason: Modify the original swagger since the id in the real response is slightly different from the ApiManagementUserResource.
  - from: openapi.json
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
                              "$ref": "#/definitions/ApiContract"
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
                  "$ref": "#/definitions/ApiContract"
              }
          ]
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/apis/{apiId}'].put.responses['201'].schema = {
          "x-ms-client-name": "GatewayApiData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "#/definitions/ApiContract"
              }
          ]
        }
    reason: Modify the original swagger since the id in the real response is slightly different from the ApiResource.
  - from: openapi.json
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
                              "$ref": "#/definitions/ApiContract"
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
                  "$ref": "#/definitions/ApiContract"
              }
          ]
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/apis/{apiId}'].put.responses['201'].schema = {
          "x-ms-client-name": "ProductApiData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "#/definitions/ApiContract"
              }
          ]
        }
    reason: Modify the original swagger since the id in the real response is slightly different from the ApiResource.
  - from: openapi.json
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
                              "$ref": "#/definitions/GroupContract"
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
                  "$ref": "#/definitions/GroupContract"
              }
          ]
        }
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/groups/{groupId}'].put.responses['201'].schema = {
          "x-ms-client-name": "ProductGroupData",
          "type": "object",
          "allOf": [
              {
                  "$ref": "#/definitions/GroupContract"
              }
          ]
        }
    # reason: Modify the original swagger since the id in the real response is slightly different from the ApiManagementGroupResource.
  - from: swagger-document
    where: $..[?(@.name=='$orderby')]
    transform: $['x-ms-client-name'] = 'orderBy'
  - from: openapi.json
    where: $.paths.['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/contentTypes/{contentTypeId}'].put
    transform: >
                $['parameters']=[
                      {
                          "name": "resourceGroupName",
                          "in": "path",
                          "description": "The name of the resource group. The name is case insensitive.",
                          "required": true,
                          "type": "string",
                          "minLength": 1,
                          "maxLength": 90,
                          "x-ms-parameter-location": "method"
                        },
                      {
                        "name": "serviceName",
                        "in": "path",
                        "description": "The name of the API Management service.",
                        "required": true,
                        "type": "string",
                        "minLength": 1,
                        "maxLength": 50,
                        "pattern": "^[a-zA-Z](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$"
                      },
                      {
                        "name": "contentTypeId",
                        "in": "path",
                        "description": "Content type identifier.",
                        "required": true,
                        "type": "string",
                        "minLength": 1,
                        "maxLength": 80
                      },
                      {
                        "name": "If-Match",
                        "in": "header",
                        "description": "ETag of the Entity. Not required when creating an entity, but required when updating an entity.",
                        "required": false,
                        "type": "string",
                        "x-ms-format": "etag"
                      },
                      {
                          "name": "api-version",
                          "in": "query",
                          "description": "The API version to use for this operation.",
                          "required": true,
                          "type": "string",
                          "minLength": 1
                        },
                      {
                          "name": "subscriptionId",
                          "in": "path",
                          "description": "The ID of the target subscription.",
                          "required": true,
                          "type": "string",
                          "minLength": 1
                        }
                ]
  - from: openapi.json
    where: $.paths.['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/contentTypes/{contentTypeId}/contentItems/{contentItemId}'].put
    transform: >
                $['parameters']=[
                      {
                          "name": "resourceGroupName",
                          "in": "path",
                          "description": "The name of the resource group. The name is case insensitive.",
                          "required": true,
                          "type": "string",
                          "minLength": 1,
                          "maxLength": 90,
                          "x-ms-parameter-location": "method"
                        },
                      {
                        "name": "serviceName",
                        "in": "path",
                        "description": "The name of the API Management service.",
                        "required": true,
                        "type": "string",
                        "minLength": 1,
                        "maxLength": 50,
                        "pattern": "^[a-zA-Z](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$"
                      },
                      {
                        "name": "contentTypeId",
                        "in": "path",
                        "description": "Content type identifier.",
                        "required": true,
                        "type": "string",
                        "minLength": 1,
                        "maxLength": 80
                      },
                      {
                        "name": "contentItemId",
                        "in": "path",
                        "description": "Content item identifier.",
                        "required": true,
                        "type": "string",
                        "minLength": 1,
                        "maxLength": 80
                      },
                      {
                        "name": "If-Match",
                        "in": "header",
                        "description": "ETag of the Entity. Not required when creating an entity, but required when updating an entity.",
                        "required": false,
                        "type": "string",
                        "x-ms-format": "etag"
                      },
                      {
                          "name": "api-version",
                          "in": "query",
                          "description": "The API version to use for this operation.",
                          "required": true,
                          "type": "string",
                          "minLength": 1
                        },
                      {
                          "name": "subscriptionId",
                          "in": "path",
                          "description": "The ID of the target subscription.",
                          "required": true,
                          "type": "string",
                          "minLength": 1
                        }
                ]
```
