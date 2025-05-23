# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: HybridNetwork
namespace: Azure.ResourceManager.HybridNetwork
require: https://github.com/Azure/azure-rest-api-specs/blob/eccca594dd50892ada8220fe7b1587c12cc5c871/specification/hybridnetwork/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
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

directive:
- from: publisher.json
  where: $.definitions.ArtifactStorePropertiesFormat.properties.storageResourceId
  transform: $["x-ms-format"] = "arm-id";
- from: common.json
  where: $.definitions.AzureStorageAccountCredential.properties.storageAccountId
  transform: $["x-ms-format"] = "arm-id";
- from: common.json
  where: $.definitions.SecretDeploymentResourceReference.properties.id
  transform: $["x-ms-format"] = "arm-id";
- from: common.json
  where: $.definitions.OpenDeploymentResourceReference.properties.id
  transform: $["x-ms-format"] = "arm-id";
- from: networkFunction.json
  where: $.definitions.NetworkFunctionPropertiesFormat.properties.nfviId
  transform: $["x-ms-format"] = "arm-id";

```
