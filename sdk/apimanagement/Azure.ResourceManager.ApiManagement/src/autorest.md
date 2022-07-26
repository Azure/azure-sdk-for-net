# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ApiManagement
namespace: Azure.ResourceManager.ApiManagement
require: https://github.com/Azure/azure-rest-api-specs/blob/b9b91929c304f8fb44002267b6c98d9fb9dde014/specification/apimanagement/resource-manager/readme.md
tag: package-2021-08
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
skip-serialization-format-xml: true

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.ApiManagement/locations/{location}/deletedservices/{serviceName}

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
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'ApiVersionSetId': 'arm-id'
  'SourceApiId': 'arm-id'
  'PrivateIPAddresses': 'ip-address'
  'PublicIPAddresses': 'ip-address'

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

prepend-rp-prefix:
- ResourceSkuCapacity
- ResourceSkuCapacityScaleType

rename-mapping:
  OpenidConnectProviderContract: ApiManagementOpenIdConnectProvider
  OpenidConnectProviderUpdateContract: OpenIdConnectProviderUpdateContract
  VirtualNetworkConfiguration.vnetid: VnetId
  AccessInformationContract: TenantAccessInfo
  AccessInformationContract.properties.enabled: IsEnabled
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
  DeployConfigurationParameters: ConfigurationDeployContent
  ApiVersionSetContract: ApiVersionSet
  AuthorizationServerContract:  ApiManagementAuthorizationServer
  BackendContract: ApiManagementBackend
  CacheContract: ApiManagementCache
  CertificateContract: ApiManagementCertificate
  CertificateContract.properties.expirationDate: ExpiresOn
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
  PortalDelegationSettings.properties.subscriptions: IsSubscriptions
  PortalDelegationSettings.properties.userRegistration: IsUserRegistration
  PortalRevisionContract: ApiManagementPortalRevision
  PortalSettingsContract: PortalSettingsContractData
  PortalSigninSettings: ApiManagementPortalSignInSettings
  PortalSigninSettings.properties.enabled: IsEnabled
  PortalSignupSettings: ApiManagementPortalSignUpSettings
  PortalSignupSettings.properties.enabled: IsEnabled
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
  SubscriptionContract.properties.expirationDate: ExpiresOn
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
  CertificateInformation.expiry: ExpiresOn
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
  SubscriptionUpdateParameters.properties.expirationDate: ExpiresOn
  SettingsTypeName: SettingsType
  TagResourceContract: TagResourceContractDetails
  TagResourceContractProperties: AssociatedTagProperties
  ApiTagResourceContractProperties: AssociatedApiProperties
  OperationTagResourceContractProperties: AssociatedOperationProperties
  ProductTagResourceContractProperties: AssociatedProductProperties
  UserTokenParameters.properties.expiry: ExpiresOn
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
  - from: apimdeployment.json
    where: $.definitions
    transform: >
      $.Operation['x-ms-client-name'] = 'RestApiOperation';
      $.VirtualNetworkConfiguration.properties.vnetid['format'] = 'uuid';
      $.VirtualNetworkConfiguration.properties.subnetResourceId['x-ms-format'] = 'arm-id';
      $.HostnameConfiguration.properties.encodedCertificate["x-nullable"] = true;
      $.HostnameConfiguration.properties.keyVaultId["x-nullable"] = true;
      $.HostnameConfiguration.properties.certificatePassword["x-nullable"] = true;
      $.HostnameConfiguration.properties.certificate["x-nullable"] = true;
      $.HostnameConfiguration.properties.identityClientId["x-nullable"] = true;
      $.HostnameConfiguration.properties.certificateStatus["x-nullable"] = true;
      $.ApiManagementServiceBaseProperties.properties.privateIPAddresses["x-nullable"] = true;
      $.ApiManagementServiceBaseProperties.properties.additionalLocations["x-nullable"] = true;
      $.ApiManagementServiceBaseProperties.properties.virtualNetworkConfiguration["x-nullable"] = true;
      $.ApiManagementServiceBaseProperties.properties.certificates["x-nullable"] = true;
      $.ApiManagementServiceBaseProperties.properties.publicIpAddressId["x-nullable"] = true;
      $.ApiManagementServiceBaseProperties.properties.privateEndpointConnections["x-nullable"] = true;
      $.ApiVersionConstraint.properties.minApiVersion["x-nullable"] = true;
      # $.ApiManagementServiceResource.properties.identity["x-nullable"] = true;
      # $.ApiManagementServiceUpdateParameters.properties.identity["x-nullable"] = true;
  - from: apimanagement.json
    where: $.parameters
    transform: >
      $.OpenIdConnectIdParameter['x-ms-client-name'] = 'OpenId';

```
