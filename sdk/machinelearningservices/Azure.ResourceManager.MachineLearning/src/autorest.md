# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: MachineLearning
namespace: Azure.ResourceManager.MachineLearning
require: https://github.com/Azure/azure-rest-api-specs/blob/edb7904bfead536c7aa9716d44dba15bdabd0b00/specification/machinelearningservices/resource-manager/readme.md
tag: package-2024-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - Datastores_List
skip-csproj: true
modelerfour:
  flatten-payloads: false
deserialize-null-collection-as-null-value: true
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
  AKS: Aks
  USD: Usd
  PAT: Pat
  SAS: Sas
  LRS: Lrs
  AAD: Aad
  AML: Aml
  VCPU: VCpu|vCpu
  VCPUs: VCpus|vCpus

override-operation-name:
  Quotas_List: GetMachineLearningQuotas
  Quotas_Update: UpdateMachineLearningQuotas
  Usages_List: GetMachineLearningUsages
  VirtualMachineSizes_List: GetMachineLearningVmSizes

no-property-type-replacement:
- ResourceId
- VirtualMachineImage

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/codes/{name}: MachineLearningCodeContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/codes/{name}/versions/{version}: MachineLearningCodeVersion
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/components/{name}: MachineLearningComponentContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/components/{name}/versions/{version}: MachineLearningComponentVersion
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}: MachineLearningDataContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}/versions/{version}: MachineLearningDataVersion
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/environments/{name}: MachineLearningEnvironmentContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/environments/{name}/versions/{version}: MachineLearningEnvironmentVersion
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/models/{name}: MachineLearningModelContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/models/{name}/versions/{version}: MachineLearningModelVersion
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/registries/{registryName}/codes/{codeName}: MachineLearningRegistryCodeContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/registries/{registryName}/codes/{codeName}/versions/{version}: MachineLearningRegistryCodeVersion
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/registries/{registryName}/components/{componentName}: MachineLearninRegistryComponentContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/registries/{registryName}/components/{componentName}/versions/{version}: MachineLearninRegistryComponentVersion
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/registries/{registryName}/data/{name}: MachineLearningRegistryDataContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/registries/{registryName}/data/{name}/versions/{version}: MachineLearningRegistryDataVersion
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/registries/{registryName}/environments/{environmentName}: MachineLearningRegistryEnvironmentContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/registries/{registryName}/environments/{environmentName}/versions/{version}: MachineLearningRegistryEnvironmentVersion
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/registries/{registryName}/models/{modelName}: MachineLearningRegistryModelContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/registries/{registryName}/models/{modelName}/versions/{version}: MachineLearningRegistryModelVersion

prepend-rp-prefix:
  - Feature
  - FeatureProperties
  - Registry
  - Webhook
  - WebhookType
  - AllFeatures

rename-mapping:
  FeaturesetContainer: MachineLearningFeatureSetContainer
  FeaturesetContainerProperties: MachineLearningFeatureSetContainerProperties
  FeaturesetVersion: MachineLearningFeatureSetVersion
  FeaturesetVersionBackfillRequest: FeatureSetVersionBackfillContent
  FeaturesetVersionProperties: MachineLearningFeatureSetVersionProperties
  FeaturestoreEntityContainer: MachineLearningFeatureStoreEntityContainer
  FeaturestoreEntityContainerProperties: MachineLearningFeatureStoreEntityContainerProperties
  FeaturestoreEntityVersion: MachineLearningFeaturestoreEntityVersion
  FeaturestoreEntityVersionProperties: MachineLearningFeatureStoreEntityVersionProperties
  ComputeInstanceProperties.setupScripts: SetupScriptsSettings
  Workspace: MachineLearningWorkspace
  ComputeResource: MachineLearningCompute
  Compute: MachineLearningComputeProperties
  Compute.resourceId: -|arm-id
  ComputeInstance: MachineLearningComputeInstance
  ComputeInstanceProperties: MachineLearningComputeInstanceProperties
  AKS: MachineLearningAksCompute
  AKSSchemaProperties: MachineLearningAksComputeProperties
  Kubernetes: MachineLearningKubernetesCompute
  KubernetesProperties: MachineLearningKubernetesProperties
  VirtualMachine: MachineLearningVirtualMachineCompute
  VirtualMachineSchemaProperties: MachineLearningVirtualMachineProperties
  HDInsight: MachineLearningHDInsightCompute
  HDInsightProperties: MachineLearningHDInsightProperties
  DataFactory: MachineLearningDataFactoryCompute
  Databricks: MachineLearningDatabricksCompute
  DatabricksProperties: MachineLearningDatabricksProperties
  DataLakeAnalytics: MachineLearningDataLakeAnalytics
  DataLakeAnalyticsSchemaProperties: MachineLearningDataLakeAnalyticsProperties
  SynapseSpark: MachineLearningSynapseSpark
  SynapseSparkProperties: MachineLearningSynapseSparkProperties
  ProvisioningState: MachineLearningProvisioningState
  ListWorkspaceKeysResult: MachineLearningWorkspaceGetKeysResult
  RegistryListCredentialsResult: MachineLearningContainerRegistryCredentials
  Password: MachineLearningPasswordDetail
  BatchDeploymentTrackedResource: MachineLearningBatchDeployment
  BatchDeployment: MachineLearningBatchDeploymentProperties
  BatchEndpointTrackedResource: MachineLearningBatchEndpoint
  BatchEndpoint: MachineLearningBatchEndpointProperties
  AssetContainer: MachineLearningAssetContainer
  ResourceBase: MachineLearningResourceBase
  AssetBase: MachineLearningAssetBase
  JobBaseResource: MachineLearningJob
  JobBase: MachineLearningJobProperties
  CommandJob: MachineLearningCommandJob
  CodeContainerResource: MachineLearningCodeContainer
  CodeContainer: MachineLearningCodeContainerProperties
  CodeVersionResource: MachineLearningCodeVersion
  CodeVersion: MachineLearningCodeVersionProperties
  ComponentContainerResource: MachineLearningComponentContainer
  ComponentContainer: MachineLearningComponentContainerProperties
  DataVersionBaseResource: MachineLearningDataVersion
  DataVersionBase: MachineLearningDataVersionProperties
  EnvironmentContainerResource: MachineLearningEnvironmentContainer
  EnvironmentContainer: MachineLearningEnvironmentContainerProperties
  EnvironmentVersionResource: MachineLearningEnvironmentVersion
  EnvironmentVersion: MachineLearningEnvironmentVersionProperties
  ComponentVersionResource: MachineLearningComponentVersion
  ComponentVersion: MachineLearningComponentVersionProperties
  DataContainerResource: MachineLearningDataContainer
  DataContainer: MachineLearningDataContainerProperties
  DatastoreResource: MachineLearningDatastore
  Datastore: MachineLearningDatastoreProperties
  MLTableData: MachineLearningTable
  ResourceQuota: MachineLearningResourceQuota
  ModelContainerResource: MachineLearningModelContainer
  ModelContainer: MachineLearningModelContainerProperties
  ModelVersionResource: MachineLearningModelVersion
  ModelVersion: MachineLearningModelVersionProperties
  OnlineDeploymentTrackedResource: MachineLearningOnlineDeployment
  OnlineDeployment: MachineLearningOnlineDeploymentProperties
  OnlineEndpointTrackedResource: MachineLearningOnlineEndpoint
  OnlineEndpoint: MachineLearningOnlineEndpointProperties
  Schedule: MachineLearningSchedule
  ScheduleProperties: MachineLearningScheduleProperties
  VirtualMachineSize: MachineLearningVmSize
  WorkspaceConnectionPropertiesV2BasicResource: MachineLearningWorkspaceConnection
  WorkspaceConnectionPropertiesV2: MachineLearningWorkspaceConnectionProperties
  UpdateWorkspaceQuotas: MachineLearningWorkspaceQuotaUpdate
  QuotaUpdateParameters: MachineLearningQuotaUpdateContent
  EncryptionProperty: MachineLearningEncryptionSetting
  EncryptionStatus: MachineLearningEncryptionStatus
  EncryptionKeyVaultProperties: MachineLearningEncryptionKeyVaultProperties
  EncryptionKeyVaultProperties.keyVaultArmId: -|arm-id
  IdentityForCmk: MachineLearningCmkIdentity
  IdentityForCmk.userAssignedIdentity: -|arm-id
  NotebookResourceInfo: MachineLearningNotebookResourceInfo
  SharedPrivateLinkResource: MachineLearningSharedPrivateLinkResource
  SharedPrivateLinkResource.properties.privateLinkResourceId: -|arm-id
  Workspace.properties.storageHnsEnabled: IsStorageHnsEnabled
  Workspace.properties.v1LegacyMode: IsV1LegacyMode
  DiagnoseResponseResult: MachineLearningWorkspaceDiagnoseResult
  DiagnoseWorkspaceParameters: MachineLearningWorkspaceDiagnoseContent
  DiagnoseRequestProperties: MachineLearningWorkspaceDiagnoseProperties
  NotebookAccessTokenResult: MachineLearningWorkspaceNotebookAccessTokenResult
  ListNotebookKeysResult: MachineLearningWorkspaceGetNotebookKeysResult
  FqdnEndpoints: MachineLearningFqdnEndpoints
  FqdnEndpointsProperties: MachineLearningFqdnEndpointsProperties
  ListStorageAccountKeysResult: MachineLearningWorkspaceGetStorageAccountKeysResult
  AmlUserFeature: MachineLearningUserFeature
  DatastoreCredentials: MachineLearningDatastoreCredentials
  AccountKeyDatastoreCredentials: MachineLearningAccountKeyDatastoreCredentials
  CertificateDatastoreCredentials: MachineLearningCertificateDatastoreCredentials
  NoneDatastoreCredentials: MachineLearningNoneDatastoreCredentials
  SasDatastoreCredentials: MachineLearningSasDatastoreCredentials
  ServicePrincipalDatastoreCredentials: MachineLearningServicePrincipalDatastoreCredentials
  DatastoreSecrets: MachineLearningDatastoreSecrets
  CertificateDatastoreSecrets: MachineLearningCertificateDatastoreSecrets
  SasDatastoreSecrets: MachineLearningSasDatastoreSecrets
  ServicePrincipalDatastoreSecrets: MachineLearningServicePrincipalDatastoreSecrets
  AccountKeyDatastoreSecrets: MachineLearningAccountKeyDatastoreSecrets
  ComputeSecrets: MachineLearningComputeSecrets
  AksComputeSecrets: MachineLearningAksComputeSecrets
  DatabricksComputeSecrets: MachineLearningDatabricksComputeSecrets
  VirtualMachineSecrets: MachineLearningVirtualMachineSecrets
  AksNetworkingConfiguration: MachineLearningAksNetworkingConfiguration
  AksNetworkingConfiguration.subnetId: -|arm-id
  ClusterPurpose: MachineLearningClusterPurpose
  LoadBalancerType: MachineLearningLoadBalancerType
  SslConfiguration: MachineLearningSslConfiguration
  SystemService: MachineLearningComputeSystemService
  IdentityConfiguration: MachineLearningIdentityConfiguration
  ManagedIdentity: MachineLearningManagedIdentity
  ManagedIdentity.resourceId: -|arm-id
  UserIdentity: MachineLearningUserIdentity
  PartialMinimalTrackedResource: MachineLearningResourcePatch
  PartialMinimalTrackedResourceWithIdentity: MachineLearningResourcePatchWithIdentity
  PartialSku: MachineLearningSkuPatch
  ApplicationSharingPolicy: MachineLearningApplicationSharingPolicy
  AssetReferenceBase: MachineLearningAssetReferenceBase
  DataPathAssetReference: MachineLearningDataPathAssetReference
  IdAssetReference: MachineLearningIdAssetReference
  IdAssetReference.assetId: -|arm-id
  OutputPathAssetReference: MachineLearningOutputPathAssetReference
  AssignedUser: MachineLearningComputeInstanceAssignedUser
  AutoPauseProperties: MachineLearningAutoPauseProperties
  AutoPauseProperties.enabled: IsEnabled
  Autosave: MachineLearningComputeInstanceAutosave
  ComputeInstanceConnectivityEndpoints: MachineLearningComputeInstanceConnectivityEndpoints
  ComputeInstanceContainer: MachineLearningComputeInstanceContainer
  ComputeInstanceEnvironmentInfo: MachineLearningComputeInstanceEnvironmentInfo
  Network: MachineLearningNetwork
  ComputeInstanceCreatedBy: MachineLearningComputeInstanceCreatedBy
  ComputeInstanceAuthorizationType: MachineLearningComputeInstanceAuthorizationType
  ComputeInstanceApplication: MachineLearningComputeInstanceApplication
  ComputeInstanceDataDisk: MachineLearningComputeInstanceDataDisk
  ComputeInstanceDataMount: MachineLearningComputeInstanceDataMount
  MountAction: MachineLearningMountAction
  MountState: MachineLearningMountState
  SourceType: MachineLearningSourceType
  ComputeInstanceLastOperation: MachineLearningComputeInstanceLastOperation
  OperationName: MachineLearningOperationName
  OperationStatus: MachineLearningOperationStatus
  OperationTrigger: MachineLearningOperationTrigger
  ComputeInstanceSshSettings: MachineLearningComputeInstanceSshSettings
  SshPublicAccess: MachineLearningSshPublicAccess
  ComputeInstanceState: MachineLearningComputeInstanceState
  ComputePowerAction: MachineLearningComputePowerAction
  ComputeStartStopSchedule: MachineLearningComputeStartStopSchedule
  ComputeStartStopSchedule.recurrence: RecurrenceSchedule
  ComputeStartStopSchedule.cron: CronSchedule
  ProvisioningStatus: MachineLearningComputeProvisioningStatus
  ScheduleBase: MachineLearningScheduleBase
  ScheduleStatus: MachineLearningScheduleStatus
  ComputeTriggerType: MachineLearningTriggerType
  RecurrenceTrigger: MachineLearningRecurrenceTrigger
  ConnectionCategory: MachineLearningConnectionCategory
  ContainerType: MachineLearningContainerType
  DeploymentLogs: MachineLearningDeploymentLogs
  DeploymentLogsRequest: MachineLearningDeploymentLogsContent
  DiagnoseResponseResultValue: MachineLearningDiagnoseResultValue
  DiagnoseResult: MachineLearningDiagnoseResult
  DiagnoseResultLevel: MachineLearningDiagnoseResultLevel
  PartialManagedServiceIdentity: MachineLearningPartialManagedServiceIdentity
  AutoScaleProperties: MachineLearningAutoScaleProperties
  AutoScaleProperties.enabled: IsEnabled
  Seasonality: ForecastingSeasonality
  AzureBlobDatastore: MachineLearningAzureBlobDatastore
  AzureDataLakeGen1Datastore: MachineLearningAzureDataLakeGen1Datastore
  AzureDataLakeGen2Datastore: MachineLearningAzureDataLakeGen2Datastore
  AzureFileDatastore: MachineLearningAzureFileDatastore
  BatchLoggingLevel: MachineLearningBatchLoggingLevel
  BatchOutputAction: MachineLearningBatchOutputAction
  BatchRetrySettings: MachineLearningBatchRetrySettings
  BillingCurrency: MachineLearningBillingCurrency
  BuildContext: MachineLearningBuildContext
  EnvironmentType: MachineLearningEnvironmentType
  OperatingSystemType: MachineLearningOperatingSystemType
  InferenceContainerProperties: MachineLearningInferenceContainerProperties
  Caching: MachineLearningCachingType
  Classification: ClassificationTask
  CodeConfiguration: MachineLearningCodeConfiguration
  JobLimits: MachineLearningJobLimits
  SweepJobLimits: MachineLearningSweepJobLimits
  CommandJobLimits: MachineLearningCommandJobLimits
  ContainerResourceRequirements: MachineLearningContainerResourceRequirements
  ContainerResourceSettings: MachineLearningContainerResourceSettings
  TriggerBase: MachineLearningTriggerBase
  JobInput: MachineLearningJobInput
  CustomModelJobInput: MachineLearningCustomModelJobInput
  LiteralJobInput: MachineLearningLiteralJobInput
  MLFlowModelJobInput: MachineLearningFlowModelJobInput
  MLTableJobInput: MachineLearningTableJobInput
  TritonModelJobInput: MachineLearningTritonModelJobInput
  UriFileJobInput: MachineLearningUriFileJobInput
  UriFolderJobInput: MachineLearningUriFolderJobInput
  JobOutput: MachineLearningJobOutput
  CustomModelJobOutput: MachineLearningCustomModelJobOutput
  MLFlowModelJobOutput: MachineLearningFlowModelJobOutput
  MLTableJobOutput: MachineLearningTableJobOutput
  TritonModelJobOutput: MachineLearningTritonModelJobOutput
  UriFileJobOutput: MachineLearningUriFileJobOutput
  UriFolderJobOutput: MachineLearningUriFolderJobOutput
  DataType: MachineLearningDataType
  OnlineScaleSettings: MachineLearningOnlineScaleSettings
  DefaultScaleSettings: MachineLearningDefaultScaleSettings
  TargetUtilizationScaleSettings: MachineLearningTargetUtilizationScaleSettings
  DeploymentProvisioningState: MachineLearningDeploymentProvisioningState
  ResourceConfiguration: MachineLearningResourceConfiguration
  DeploymentResourceConfiguration: MachineLearningDeploymentResourceConfiguration
  JobResourceConfiguration: MachineLearningJobResourceConfiguration
  DistributionConfiguration: MachineLearningDistributionConfiguration
  Mpi: MpiDistributionConfiguration
  PyTorch: PyTorchDistributionConfiguration
  TensorFlow: TensorFlowDistributionConfiguration
  EarlyTerminationPolicy: MachineLearningEarlyTerminationPolicy
  EgressPublicNetworkAccessType: MachineLearningEgressPublicNetworkAccessType
  EndpointAuthKeys: MachineLearningEndpointAuthKeys
  EndpointAuthMode: MachineLearningEndpointAuthMode
  EndpointAuthToken: MachineLearningEndpointAuthToken
  EndpointComputeType: MachineLearningEndpointComputeType
  EndpointDeploymentPropertiesBase: MachineLearningEndpointDeploymentProperties
  EndpointPropertiesBase: MachineLearningEndpointProperties
  EndpointProvisioningState: MachineLearningEndpointProvisioningState
  EndpointScheduleAction: MachineLearningEndpointScheduleAction
  ErrorResponse: MachineLearningError
  EstimatedVMPrice: MachineLearningEstimatedVMPrice
  VMPriceOSType: MachineLearningVMPriceOSType
  VMTier: MachineLearningVmTier
  EstimatedVMPrices: MachineLearningEstimatedVMPrices
  UnitOfMeasure: MachineLearningUnitOfMeasure
  FeatureLags: MachineLearningFeatureLag
  FeaturizationMode: MachineLearningFeaturizationMode
  FeaturizationSettings: MachineLearningFeaturizationSettings
  FlavorData: MachineLearningFlavorData
  FqdnEndpoint: MachineLearningFqdnEndpoint
  FqdnEndpointDetail: MachineLearningFqdnEndpointDetail
  Goal: MachineLearningGoal
  InputDeliveryMode: MachineLearningInputDeliveryMode
  OutputDeliveryMode: MachineLearningOutputDeliveryMode
  InstanceTypeSchema: MachineLearningInstanceTypeSchema
  InstanceTypeSchemaResources: MachineLearningInstanceTypeSchemaResources
  ScheduleActionBase: MachineLearningScheduleAction
  JobScheduleAction: MachineLearningJobScheduleAction
  JobService: MachineLearningJobService
  JobStatus: MachineLearningJobStatus
  KeyType: MachineLearningKeyType
  KubernetesOnlineDeployment: MachineLearningKubernetesOnlineDeployment
  ListViewType: MachineLearningListViewType
  LogVerbosity: MachineLearningLogVerbosity
  ManagedIdentityAuthTypeWorkspaceConnectionProperties: MachineLearningManagedIdentityAuthTypeWorkspaceConnection
  WorkspaceConnectionManagedIdentity: MachineLearningWorkspaceConnectionManagedIdentity
  WorkspaceConnectionManagedIdentity.resourceId: -|arm-id
  NoneAuthTypeWorkspaceConnectionProperties: MachineLearningNoneAuthTypeWorkspaceConnection
  PATAuthTypeWorkspaceConnectionProperties: MachineLearningPATAuthTypeWorkspaceConnection
  SASAuthTypeWorkspaceConnectionProperties: MachineLearningSASAuthTypeWorkspaceConnection
  UsernamePasswordAuthTypeWorkspaceConnectionProperties: MachineLearningUsernamePasswordAuthTypeWorkspaceConnection
  ConnectionAuthType: MachineLearningConnectionAuthType
  ManagedOnlineDeployment: MachineLearningManagedOnlineDeployment
  ModelSize: MachineLearningModelSize
  NodeState: MachineLearningNodeState
  NodeStateCounts: MachineLearningNodeStateCounts
  NotebookPreparationError: MachineLearningNotebookPreparationError
  Objective: MachineLearningObjective
  OnlineRequestSettings: MachineLearningOnlineRequestSettings
  OrderString: MachineLearningOrderString
  OsType: MachineLearningOSType
  PipelineJob: MachineLearningPipelineJob
  ProbeSettings: MachineLearningProbeSettings
  PublicNetworkAccessType: MachineLearningPublicNetworkAccessType
  QuotaBaseProperties: MachineLearningQuotaProperties
  QuotaUnit: MachineLearningQuotaUnit
  RecurrenceFrequency: MachineLearningRecurrenceFrequency
  RecurrenceSchedule: MachineLearningRecurrenceSchedule
  WeekDay: MachineLearningDayOfWeek
  RegenerateEndpointKeysRequest: MachineLearningEndpointKeyRegenerateContent
  Regression: AutoMLVerticalRegression
  RegressionModels: AutoMLVerticalRegressionModel
  RegressionPrimaryMetrics: AutoMLVerticalRegressionPrimaryMetric
  RemoteLoginPortPublicAccess: MachineLearningRemoteLoginPortPublicAccess
  ResourceName: MachineLearningResourceName
  Route: MachineLearningInferenceContainerRoute
  ScaleSettings: AmlComputeScaleSettings
  ScheduleListViewType: MachineLearningScheduleListViewType
  ScheduleProvisioningState: MachineLearningScheduleProvisioningState
  ScheduleProvisioningStatus: MachineLearningScheduleProvisioningStatus
  ScriptReference: MachineLearningScriptReference
  ScriptsToExecute: MachineLearningScriptsToExecute
  ServiceDataAccessAuthIdentity: MachineLearningServiceDataAccessAuthIdentity
  ShortSeriesHandlingConfiguration: MachineLearningShortSeriesHandlingConfiguration
  SkuCapacity: MachineLearningSkuCapacity
  SkuScaleType: MachineLearningSkuScaleType
  SkuResource: MachineLearningSkuDetail
  SkuSetting: MachineLearningSkuSetting
  SslConfigStatus: MachineLearningSslConfigStatus
  StackEnsembleSettings: MachineLearningStackEnsembleSettings
  StackMetaLearnerType: MachineLearningStackMetaLearnerType
  Status: MachineLearningWorkspaceQuotaStatus
  StorageAccountType: MachineLearningStorageAccountType
  SweepJob: MachineLearningSweepJob
  TrainingSettings: MachineLearningTrainingSettings
  TrainingSettings.enableDnnTraining: IsDnnTrainingEnabled
  TrainingSettings.enableModelExplainability: IsModelExplainabilityEnabled
  TrainingSettings.enableOnnxCompatibleModels: IsOnnxCompatibleModelsEnabled
  TrainingSettings.enableStackEnsemble: IsStackEnsembleEnabled
  TrainingSettings.enableVoteEnsemble: IsVoteEnsembleEnabled
  UnderlyingResourceAction: MachineLearningUnderlyingResourceAction
  UriFileDataVersion: MachineLearningUriFileDataVersion
  UriFolderDataVersion: MachineLearningUriFolderDataVersion
  UsageName: MachineLearningUsageName
  UsageUnit: MachineLearningUsageUnit
  UserAccountCredentials: MachineLearningUserAccountCredentials
  UseStl: MachineLearningUseStl
  ValueFormat: MachineLearningValueFormat
  VirtualMachineSshCredentials: MachineLearningVmSshCredentials
  VmPriority: MachineLearningVmPriority
  WorkspaceConnectionUsernamePassword: MachineLearningWorkspaceConnectionUsernamePassword
  Workspace.properties.hbiWorkspace: IsHbiWorkspace
  Workspace.properties.publicNetworkAccess: PublicNetworkAccessType
  WorkspaceUpdateParameters.properties.publicNetworkAccess: PublicNetworkAccessType
  AllocationState: MachineLearningAllocationState
  ResourceId.id: -|arm-id
  JobBase.componentId: -|arm-id
  JobBase.computeId: -|arm-id
  CommandJob.environmentId: -|arm-id
  EndpointComputeType.AzureMLCompute: AmlCompute
  OutputPathAssetReference.jobId: -|arm-id
  PipelineJob.sourceJobId: -|arm-id
  VirtualMachineSize.premiumIO: IsPremiumIOSupported
  AmlComputeNodeInformation.privateIpAddress: -|ip-address
  AmlComputeNodeInformation.publicIpAddress: -|ip-address
  CommandJob.codeId: -|arm-id
  CodeConfiguration.codeId: -|arm-id
  HDInsightProperties.address: -|ip-address
  VirtualMachineSchemaProperties.address: -|ip-address
  TrialComponent: MachineLearningTrialComponent
  TrialComponent.codeId: -|arm-id
  TrialComponent.environmentId: -|arm-id
  Forecasting: MachineLearningForecasting
  EndpointAuthToken.expiryTimeUtc: ExpireOn|unixtime # this temporarily does not work
  EndpointAuthToken.refreshAfterTimeUtc: RefreshOn|unixtime # this temporarily does not work
  SystemCreatedAcrAccount.armResourceId: ArmResourceIdentifier|arm-id
  SystemCreatedStorageAccount.armResourceId: ArmResourceIdentifier|arm-id
  UserCreatedAcrAccount.armResourceId: ArmResourceIdentifier|arm-id
  UserCreatedStorageAccount.armResourceId: ArmResourceIdentifier|arm-id
  Cron: ComputeStartStopCronSchedule
  Recurrence: ComputeStartStopRecurrenceSchedule
  PrivateEndpointServiceConnectionStatus: MachineLearningPrivateEndpointServiceConnectionStatus
  ArmResourceId.resourceId: -|arm-id
  Workspace.properties.hubResourceId: -|arm-id
  OutboundRuleBasicResource: MachineLearningOutboundRuleBasic
  OutboundRule: MachineLearningOutboundRule
  BindOptions: MountBindOptions
  BindOptions.createHostPath: DoesCreateHostPath
  AcrDetails: RegistryAcrDetails
  AllNodes: JobAllNodes
  Nodes: JobNodes
  AssetProvisioningState: RegistryAssetProvisioningState
  BlobReferenceForConsumptionDto.storageAccountArmId: -|arm-id
  Collection: DataCollectionConfiguration
  Docker: DockerSetting
  Endpoint: ContainerEndpoint
  Protocol: ContainerCommunicationProtocol
  Image: ImageSetting
  ConnectionCategory.AzureSqlDb: AzureSqlDB
  ConnectionCategory.AzureMySqlDb: AzureMySqlDB
  ConnectionCategory.AzurePostgresDb: AzurePostgresDB
  PrivateEndpointResource: RegistryPrivateEndpoint
  PrivateEndpointResource.subnetArmId: -|arm-id
  PrivateEndpoint: PrivateEndpointBase
  PrivateEndpoint.id: -|arm-id
  QueueSettings: JobQueueSettings
  RegistryPrivateEndpointConnection.id: -|arm-id
  RuleAction: NetworkingRuleAction
  RuleCategory: OutboundRuleCategory
  RuleStatus: OutboundRuleStatus
  RuleType: OutboundRuleType
  ImageType.azureml: AzureML
  ServerlessComputeSettings.serverlessComputeNoPublicIP: HasNoPublicIP
  PrivateEndpointConnection.properties.privateEndpoint: SubResource
  MarketplacePlan: MachineLearningMarketplacePlan
  MarketplaceSubscription: MachineLearningMarketplaceSubscription
  MarketplaceSubscriptionProperties: MachineLearningMarketplaceSubscriptionProperties
  ComputeRecurrenceFrequency: MachineLearningComputeRecurrenceFrequency
  ComputeRecurrenceSchedule: MachineLearningComputeRecurrenceSchedule
  ComputeWeekDay: MachineLearningComputeWeekDay
  ConnectionGroup: WorkspaceConnectionGroup
  DestinationAsset: DestinationAssetContent
  GetBlobReferenceSASRequestDto: BlobReferenceSasContent
  GetBlobReferenceSASResponseDto: BlobReferenceSasResult
  ServerlessEndpoint: MachineLearningServerlessEndpoint

suppress-abstract-base-class:
- MachineLearningJobProperties
- MachineLearningDataVersionProperties
- MachineLearningDatastoreProperties
- MachineLearningOnlineDeploymentProperties

directive:
  - from: swagger-document
    where: $.definitions.EndpointAuthToken.properties
    transform: >
      $["expiryTimeUtc"].format = "unixtime";
      $["refreshAfterTimeUtc"].format = "unixtime";
  - from: swagger-document
    where: $.definitions.ComputeNodesInformation.properties
    transform: delete $.nextLink;
    reason: Duplicated "nextLink" property defined in schema 'AmlComputeNodesInformation' and 'ComputeNodesInformation'
  - from: swagger-document
    where: $.definitions.Compute.properties.provisioningErrors
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.subnet
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.errors
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.virtualMachineImage
    transform: $["x-nullable"] = true;
#BUG: Patch does not return scaledown time PATCH
  - from: swagger-document
    where: $.definitions.ScaleSettings.properties.nodeIdleTimeBeforeScaleDown
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.currentNodeCount
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.VirtualMachineSchema.properties.properties.properties.administratorAccount
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.targetNodeCount
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.nodeStateCounts
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.allocationState
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.EnvironmentContainerResource.properties.systemData
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.DatastoreProperties.properties.properties
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.ComputeInstance.allOf[?(@.type=="object")].properties.properties.properties.setupScripts
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlComputeProperties.properties.errors
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlComputeProperties.properties.virtualMachineImage
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.TableVerticalValidationDataSettings.properties.cvSplitColumnNames
    transform: $["x-nullable"] = true;
  - from: workspaceRP.json
    where: $.definitions
    transform: >
      $.PrivateLinkResourceProperties.properties.groupId.readOnly = true;
      $.PrivateLinkResourceProperties.properties.requiredMembers.readOnly = true;
  # quite a few x-ms-client-name extensions are defined in the swagger, we here erase them all to prevent some funny interactions between our own renaming configuration
  - from: mfe.json
    where: $.definitions
    transform: >
      $.CodeContainerResource["x-ms-client-name"] = undefined;
      $.CodeContainer["x-ms-client-name"] = undefined;
      $.BatchDeploymentTrackedResource["x-ms-client-name"] = undefined;
      $.BatchDeployment["x-ms-client-name"] = undefined;
      $.BatchEndpointTrackedResource["x-ms-client-name"] = undefined;
      $.BatchEndpoint["x-ms-client-name"] = undefined;
      $.CodeVersionResource["x-ms-client-name"] = undefined;
      $.CodeVersion["x-ms-client-name"] = undefined;
      $.ComponentContainerResource["x-ms-client-name"] = undefined;
      $.ComponentContainer["x-ms-client-name"] = undefined;
      $.ComponentVersionResource["x-ms-client-name"] = undefined;
      $.ComponentVersion["x-ms-client-name"] = undefined;
      $.DataContainerResource["x-ms-client-name"] = undefined;
      $.DataContainer["x-ms-client-name"] = undefined;
      $.DatastoreResource["x-ms-client-name"] = undefined;
      $.Datastore["x-ms-client-name"] = undefined;
      $.DataVersionBaseResource["x-ms-client-name"] = undefined;
      $.DataVersionBase["x-ms-client-name"] = undefined;
      $.EnvironmentContainerResource["x-ms-client-name"] = undefined;
      $.EnvironmentContainer["x-ms-client-name"] = undefined;
      $.EnvironmentVersionResource["x-ms-client-name"] = undefined;
      $.EnvironmentVersion["x-ms-client-name"] = undefined;
      $.JobBaseResource["x-ms-client-name"] = undefined;
      $.JobBase["x-ms-client-name"] = undefined;
      $.ModelContainerResource["x-ms-client-name"] = undefined;
      $.ModelContainer["x-ms-client-name"] = undefined;
      $.ModelVersionResource["x-ms-client-name"] = undefined;
      $.ModelVersion["x-ms-client-name"] = undefined;
      $.OnlineDeploymentTrackedResource["x-ms-client-name"] = undefined;
      $.OnlineDeployment["x-ms-client-name"] = undefined;
      $.OnlineEndpointTrackedResource["x-ms-client-name"] = undefined;
      $.OnlineEndpoint["x-ms-client-name"] = undefined;
```
