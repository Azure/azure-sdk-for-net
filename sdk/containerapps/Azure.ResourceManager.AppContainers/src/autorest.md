# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: AppContainers
namespace: Azure.ResourceManager.AppContainers
require: https://github.com/Azure/azure-rest-api-specs/blob/24b224b17e698746d3c34e32f84dab7de5e4f2a8/specification/app/resource-manager/readme.md
#tag: package-2025-01-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
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
  Github: GitHub
  LTS: Lts

rename-mapping:
  ContainerAppProbeHttpGet: ContainerAppHttpRequestInfo
  ContainerAppProbeTcpSocket: ContainerAppTcpSocketRequestInfo
  AuthConfig: ContainerAppAuthConfig
  Certificate: ContainerAppCertificate
  DaprComponent: ContainerAppDaprComponent
  ConnectedEnvironment: ContainerAppConnectedEnvironment
  ManagedEnvironment: ContainerAppManagedEnvironment
  ConnectedEnvironmentStorage: ContainerAppConnectedEnvironmentStorage
  ManagedEnvironmentStorage: ContainerAppManagedEnvironmentStorage
  Diagnostics: ContainerAppDiagnostic
  SourceControl: ContainerAppSourceControl
  AccessMode: ContainerAppAccessMode
  Action: ContainerAppIPRuleAction
  ActiveRevisionsMode: ContainerAppActiveRevisionsMode
  AllowedPrincipals: ContainerAppAllowedPrincipals
  IdentityProviders: ContainerAppIdentityProvidersConfiguration
  AzureActiveDirectory: ContainerAppAzureActiveDirectoryConfiguration
  Facebook: ContainerAppFacebookConfiguration
  GitHub: ContainerAppGitHubConfiguration
  Google: ContainerAppGoogleConfiguration
  Twitter: ContainerAppTwitterConfiguration
  Apple: ContainerAppAppleConfiguration
  AzureStaticWebApps: ContainerAppAzureStaticWebAppsConfiguration
  CustomOpenIdConnectProvider: ContainerAppCustomOpenIdConnectProviderConfiguration
  AppleRegistration: ContainerAppAppleRegistrationConfiguration
  AvailableWorkloadProfileProperties: ContainerAppAvailableWorkloadProfileProperties
  Applicability: ContainerAppAvailableWorkloadProfileApplicability
  AuthPlatform: ContainerAppAuthPlatform
  AvailableWorkloadProfile: ContainerAppAvailableWorkloadProfile
  AzureActiveDirectoryLogin: ContainerAppAzureActiveDirectoryLoginConfiguration
  AzureActiveDirectoryRegistration: ContainerAppAzureActiveDirectoryRegistrationConfiguration
  AzureActiveDirectoryValidation: ContainerAppAzureActiveDirectoryValidationConfiguration
  AzureCredentials: ContainerAppCredentials
  AzureFileProperties: ContainerAppAzureFileProperties
  NfsAzureFileProperties: ContainerAppNfsAzureFileProperties
  BaseContainer: ContainerAppBaseContainer
  BillingMeter: ContainerAppBillingMeter
  BillingMeterProperties: ContainerAppBillingMeterProperties
  BindingType: ContainerAppCustomDomainBindingType
  Category: ContainerAppBillingMeterCategory
  CertificatePatch: ContainerAppCertificatePatch
  CertificateProperties: ContainerAppCertificateProperties
  CertificateProvisioningState: ContainerAppCertificateProvisioningState
  AppLogsConfiguration: ContainerAppLogsConfiguration
  AppProtocol: ContainerAppProtocol
  AppRegistration: ContainerAppRegistration
  CheckNameAvailabilityReason: ContainerAppNameUnavailableReason
  CheckNameAvailabilityRequest: ContainerAppNameAvailabilityContent
  CheckNameAvailabilityResponse: ContainerAppNameAvailabilityResult
  OpenIdConnectClientCredential: ContainerAppOpenIdConnectClientCredential
  ClientCredentialMethod: ContainerAppOpenIdConnectClientCredentialMethod
  ClientRegistration: ContainerAppClientRegistration
  ConnectedEnvironmentProvisioningState: ContainerAppConnectedEnvironmentProvisioningState
  ContainerResources: AppContainerResources
  CookieExpiration: ContainerAppCookieExpiration
  CookieExpirationConvention: ContainerAppCookieExpirationConvention
  CorsPolicy: ContainerAppCorsPolicy
  CustomDomain: ContainerAppCustomDomain
  CustomDomainConfiguration: ContainerAppCustomDomainConfiguration
  CustomHostnameAnalysisResult: ContainerAppCustomHostnameAnalysisResult
  CustomHostnameAnalysisResultCustomDomainVerificationFailureInfo: ContainerAppCustomDomainVerificationFailureInfo
  CustomHostnameAnalysisResultCustomDomainVerificationFailureInfoDetailsItem: ContainerAppCustomDomainVerificationFailureInfoDetailsItem
  CustomScaleRule: ContainerAppCustomScaleRule
  DaprMetadata: ContainerAppDaprMetadata
  DaprSecret: ContainerAppDaprSecret
  DefaultAuthorizationPolicy: ContainerAppDefaultAuthorizationPolicy
  DiagnosticDataProviderMetadata: ContainerAppDiagnosticDataProviderMetadata
  DiagnosticDataProviderMetadataPropertyBagItem: ContainerAppDiagnosticDataProviderMetadataPropertyBagItem
  DiagnosticDataTableResponseColumn: ContainerAppDiagnosticDataColumn
  DiagnosticDataTableResponseObject: ContainerAppDiagnosticDataTableResult
  DiagnosticRendering: ContainerAppDiagnosticRendering
  DiagnosticsDataApiResponse: ContainerAppDiagnosticsDataApiResult
  DiagnosticsDefinition: ContainerAppDiagnosticsMetadata
  DiagnosticsProperties: ContainerAppDiagnosticsProperties
  DiagnosticsStatus: ContainerAppDiagnosticsStatus
  DiagnosticSupportTopic: ContainerAppDiagnosticSupportTopic
  DnsVerificationTestResult: ContainerAppDnsVerificationTestResult
  EnvironmentAuthToken: ContainerAppEnvironmentAuthToken
  EnvironmentProvisioningState: ContainerAppEnvironmentProvisioningState
  EnvironmentVar: ContainerAppEnvironmentVariable
  ExtendedLocation: ContainerAppExtendedLocation
  ExtendedLocationTypes: ContainerAppExtendedLocationType
  ForwardProxy: ContainerAppForwardProxy
  ForwardProxyConvention: ContainerAppForwardProxyConvention
  GithubActionConfiguration: ContainerAppGitHubActionConfiguration
  GlobalValidation: ContainerAppGlobalValidation
  HttpScaleRule: ContainerAppHttpScaleRule
  HttpSettings: ContainerAppHttpSettings
  IngressClientCertificateMode: ContainerAppIngressClientCertificateMode
  IngressTransportMethod: ContainerAppIngressTransportMethod
  InitContainer: ContainerAppInitContainer
  IpSecurityRestrictionRule: ContainerAppIPSecurityRestrictionRule
  JwtClaimChecks: ContainerAppJwtClaimChecks
  LogAnalyticsConfiguration: ContainerAppLogAnalyticsConfiguration
  Login: ContainerAppLogin
  Nonce: ContainerAppLoginNonce
  LogLevel: ContainerAppDaprLogLevel
  ManagedEnvironmentOutboundSettings: ContainerAppManagedEnvironmentOutboundSettings
  ManagedEnvironmentOutBoundType: ContainerAppManagedEnvironmentOutBoundType
  OpenIdConnectConfig: ContainerAppOpenIdConnectConfig
  OpenIdConnectLogin: ContainerAppOpenIdConnectLogin
  OpenIdConnectRegistration: ContainerAppOpenIdConnectRegistration
  QueueScaleRule: ContainerAppQueueScaleRule
  RegistryCredentials: ContainerAppRegistryCredentials
  RegistryInfo: ContainerAppRegistryInfo
  ReplicaContainer: ContainerAppReplicaContainer
  RevisionHealthState: ContainerAppRevisionHealthState
  RevisionProvisioningState: ContainerAppRevisionProvisioningState
  SourceControlOperationState: ContainerAppSourceControlOperationState
  StorageType: ContainerAppStorageType
  TcpScaleRule: ContainerAppTcpScaleRule
  TrafficWeight: ContainerAppRevisionTrafficWeight
  TwitterRegistration: ContainerAppTwitterRegistration
  UnauthenticatedClientActionV2: ContainerAppUnauthenticatedClientActionV2
  VnetConfiguration: ContainerAppVnetConfiguration
  WorkloadProfile: ContainerAppWorkloadProfile
  WorkloadProfileStates: ContainerAppWorkloadProfileState
  WorkloadProfileStatesProperties: ContainerAppWorkloadProfileStateProperties
  Revision: ContainerAppRevision
  Replica: ContainerAppReplica
  Configuration: ContainerAppConfiguration
  Dapr: ContainerAppDaprConfiguration
  Dapr.enableApiLogging: IsApiLoggingEnabled
  Ingress: ContainerAppIngressConfiguration
  Container: ContainerAppContainer
  Scale: ContainerAppScale
  ScaleRule: ContainerAppScaleRule
  ScaleRuleAuth: ContainerAppScaleRuleAuth
  Secret: ContainerAppWritableSecret
  Template: ContainerAppTemplate
  Volume: ContainerAppVolume
  VolumeMount: ContainerAppVolumeMount
  ContainerApp.properties.environmentId: -|arm-id
  ContainerApp.properties.managedEnvironmentId: -|arm-id
  Revision.properties.active: IsActive
  ManagedEnvironment.properties.zoneRedundant: IsZoneRedundant
  AvailableWorkloadProfileProperties.memoryGiB: MemoryInGiB
  AzureActiveDirectoryLogin.disableWWWAuthenticate: IsWwwAuthenticationDisabled
  CertificateProperties.valid: IsValid
  CheckNameAvailabilityRequest.type: ResourceType|resource-type
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  ContainerAppAuthToken.properties.expires: ExpireOn
  EnvironmentAuthToken.properties.expires: ExpireOn
  CustomDomain.certificateId: -|arm-id
  ManagedEnvironmentOutboundSettings.virtualNetworkApplianceIp: -|ip-address
  ConnectedEnvironment.properties.staticIp: -|ip-address
  ManagedEnvironment.properties.staticIp: -|ip-address
  ReplicaContainer.ready: IsReady
  ReplicaContainer.started: IsStarted
  TrafficWeight.latestRevision: IsLatestRevision
  VnetConfiguration.infrastructureSubnetId: -|arm-id
  VnetConfiguration.internal: IsInternal
  ContainerApp.properties.eventStreamEndpoint: -|uri
  ContainerApp.properties.outboundIpAddresses: OutboundIPAddressList|ip-address
  ContainerAppProbe.type: ProbeType
  Type: ContainerAppProbeType
  Scheme: ContainerAppHttpScheme
  ContainerAppProbeHttpGetHttpHeadersItem: ContainerAppHttpHeaderInfo
  RegistryInfo.registryUrl: RegistryServer
  WorkloadProfile.maximumCount: MaximumNodeCount
  WorkloadProfile.minimumCount: MinimumNodeCount
  BillingMeterProperties.category: WorkloadProfileCategory
  TriggerType: ContainerAppJobTriggerType
  JobTemplate: ContainerAppJobTemplate
  JobProvisioningState: ContainerAppJobProvisioningState
  JobPatchPropertiesProperties: ContainerAppJobPatchProperties
  JobExecution: ContainerAppJobExecution
  JobExecutionBase: ContainerAppJobExecutionBase
  JobExecutionTemplate: ContainerAppJobExecutionTemplate
  JobConfiguration: ContainerAppJobConfiguration
  Job: ContainerAppJob
  JobsCollection: ContainerAppJobsCollection
  ManagedCertificate: ContainerAppManagedCertificate
  Mtls.enabled: IsMtlsEnabled
  ServiceBind: ContainerAppServiceBind
  JobScale: ContainerAppJobScale
  JobScale.pollingInterval: PollingIntervalInSeconds
  JobScaleRule: ContainerAppJobScaleRule
  JobConfigurationEventTriggerConfig: EventTriggerConfiguration
  TokenStore: ContainerAppTokenStore
  Usage: ContainerAppUsage
  UsageName: ContainerAppUsageName
  UsageUnit: ContainerAppUsageUnit
  DaprSubscriptionBulkSubscribeOptions: DaprSubscriptionBulkSubscribeConfig
  ScaleConfiguration: SessionPoolScaleConfiguration
  ManagedIdentitySetting: SessionPoolManagedIdentitySetting
  LifecycleType: SessionPoolLifecycleType
  LifecycleConfiguration: SessionPoolLifecycleConfiguration
  IdentitySettingsLifeCycle: ContainerAppIdentitySettingsLifeCycle 
  IdentitySettings: ContainerAppIdentitySettings
  CertificateKeyVaultProperties: ContainerAppCertificateKeyVaultProperties

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}/certificates/{certificateName}: ContainerAppConnectedEnvironmentCertificate
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}/daprComponents/{componentName}: ContainerAppConnectedEnvironmentDaprComponent
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/certificates/{certificateName}: ContainerAppManagedEnvironmentCertificate
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}: ContainerAppManagedEnvironment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/daprComponents/{componentName}: ContainerAppManagedEnvironmentDaprComponent
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/detectors/{detectorName}: ContainerAppManagedEnvironmentDetector
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/detectorProperties/rootApi: ContainerAppManagedEnvironmentDetectorResourceProperty
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/jobs/{jobName}: ContainerAppJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/jobs/{jobName}/detectors/{detectorName}: ContainerAppJobDetector
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/jobs/{jobName}/detectorProperties/{apiName}: ContainerAppJobDetectorProperty

override-operation-name:
    Namespaces_CheckNameAvailability: CheckContainerAppNameAvailability

# mgmt-debug:
#    show-serialized-names: true

directive:
  - from: swagger-document
    where: $.definitions..enabled
    transform: >
      if ($['type'] === 'boolean')
        $['x-ms-client-name'] = 'IsEnabled'
  # Change type to ResourceIdentifier
  - from: CommonDefinitions.json
    where: $.definitions.ServiceBind.properties.serviceId
    transform: $['x-ms-format'] = 'arm-id'
```
