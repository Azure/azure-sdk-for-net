# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: HybridNetwork
namespace: Azure.ResourceManager.HybridNetwork
require: D:/Azure/azure-rest-api-specs-pr/specification/hybridnetwork/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

mgmt-debug:
 show-serialized-names: true

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
  HelmInstallOptions: HelmInstallConfig
  HelmUpgradeOptions: HelmUpgradeConfig
  HelmMappingRuleProfileOptions: HelmMappingRuleProfileConfig
  Resources: ComponentKubernetesResources
  Status: ComponentStatus
  DaemonSet: KubernetesDaemonSet
  DaemonSet.desired: DesiredNumberOfPods
  DaemonSet.ready: ReadyNumberOfPods
  DaemonSet.current: CurrentNumberOfPods
  DaemonSet.upToDate: UpToDateNumberOfPods
  DaemonSet.available: AvailableNumberOfPods
  Deployment: KubernetesDeployment
  Deployment.desired: DesiredNumberOfPods
  Deployment.ready: ReadyNumberOfPods
  Deployment.current: CurrentNumberOfPods
  Deployment.upToDate: UpToDateNumberOfPods
  Deployment.available: AvailableNumberOfPods
  Pod: KubernetesPod
  Pod.desired: DesiredNumberOfContainers
  Pod.ready: ReadyNumberOfContainers
  ReplicaSet: KubernetesReplicaSet
  ReplicaSet.desired: DesiredNumberOfPods
  ReplicaSet.ready: ReadyNumberOfPods
  ReplicaSet.current: CurrentNumberOfPods
  StatefulSet: KubernetesStatefulSet
  StatefulSet.desired: DesiredNumberOfPods
  StatefulSet.ready: ReadyNumberOfPods
  ArtifactStorePropertiesFormat.storageResourceId: -|arm-id
  AzureStorageAccountCredential.storageAccountId: -|arm-id
  SecretDeploymentResourceReference.id: -|arm-id
  OpenDeploymentResourceReference.id: -|arm-id
  NetworkFunctionPropertiesFormat.nfviId: -|arm-id
  CancelInformation: CancelSiteNetworkServiceInformation
  LongRunningOperation: CancelSiteNetworkServiceLongRunningOperationType

directive:
# operation removal - should be temporary
# pageable lro
  - remove-operation: ArtifactStores_ListNetworkFabricControllerPrivateEndPoints
  - remove-operation: ArtifactStores_ListPrivateEndPoints
  - from: openapi.json
    where: $.definitions
    transform: >
      $.SecretDeploymentResourceReference.properties.id['format'] = undefined;
```
