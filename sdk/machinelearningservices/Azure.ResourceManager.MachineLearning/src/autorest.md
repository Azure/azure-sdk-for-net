# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: MachineLearning
namespace: Azure.ResourceManager.MachineLearning
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0bff4d0f259847b1fc97a4ca8f98b8c40d672ba5/specification/machinelearningservices/resource-manager/readme.md
tag: package-2022-02-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
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
  AKS: Aks
  USD: Usd

no-property-type-replacement: 
- ResourceId
- VirtualMachineImage
directive:
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
    where: $.definitions.DataSettings.properties.trainingData
    transform: $["x-ms-client-name"] = "trainingDataSettings";
  - from: swagger-document
    where: $.definitions.ComputeInstanceProperties.properties.setupScripts
    transform: $["x-ms-client-name"] = "setupScriptsSettings";
  - from: swagger-document
    where: $.definitions.AmlComputeProperties.properties.errors
    transform: $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlComputeProperties.properties.virtualMachineImage
    transform: $["x-nullable"] = true;       
  - from: swagger-document
    where: $.definitions.TableVerticalValidationDataSettings.properties.cvSplitColumnNames
    transform: $["x-nullable"] = true;
  - from: machineLearningServices.json
    where: $.definitions
    transform: >
      $.Workspace["x-ms-client-name"] = "MachineLearningWorkspace";
      $.ComputeResource["x-ms-client-name"] = "MachineLearningCompute";
      $.Compute.properties.resourceId["x-ms-format"] = "arm-id";
      $.AKS["x-ms-client-name"] = "AksCompute";
      $.Kubernetes["x-ms-client-name"] = "KubernetesCompute";
      $.VirtualMachine["x-ms-client-name"] = "VirtualMachineCompute";
      $.HDInsight["x-ms-client-name"] = "HDInsightCompute";
      $.DataFactory["x-ms-client-name"] = "DataFactoryCompute";
      $.Databricks["x-ms-client-name"] = "DatabricksCompute";
      $.DataLakeAnalytics["x-ms-client-name"] = "DataLakeAnalyticsCompute";
      $.SynapseSpark["x-ms-client-name"] = "SynapseSparkCompute";
      $.Password["x-ms-client-name"] = "PasswordDetail";
  - from: mfe.json
    where: $.definitions
    transform: >
      $.CodeContainerResource["x-ms-client-name"] = "CodeContainer";
      $.CodeContainer["x-ms-client-name"] = "CodeContainerProperties";
      $.BatchDeploymentTrackedResource["x-ms-client-name"] = "BatchDeployment";
      $.BatchDeployment["x-ms-client-name"] = "BatchDeploymentProperties";
      $.BatchEndpointTrackedResource["x-ms-client-name"] = "BatchEndpoint";
      $.BatchEndpoint["x-ms-client-name"] = "BatchEndpointProperties";
      $.CodeVersionResource["x-ms-client-name"] = "CodeVersion";
      $.CodeVersion["x-ms-client-name"] = "CodeVersionProperties";
      $.ComponentContainerResource["x-ms-client-name"] = "ComponentContainer";
      $.ComponentContainer["x-ms-client-name"] = "ComponentContainerProperties";
      $.ComponentVersionResource["x-ms-client-name"] = "ComponentVersion";
      $.ComponentVersion["x-ms-client-name"] = "ComponentVersionProperties";
      $.DataContainerResource["x-ms-client-name"] = "DataContainer";
      $.DataContainer["x-ms-client-name"] = "DataContainerProperties";
      $.DatastoreResource["x-ms-client-name"] = "Datastore";
      $.Datastore["x-ms-client-name"] = "DatastoreProperties";
      $.DataVersionBaseResource["x-ms-client-name"] = "DataVersion";
      $.DataVersionBase["x-ms-client-name"] = "DataVersionProperties";
      $.EnvironmentContainerResource["x-ms-client-name"] = "EnvironmentContainer";
      $.EnvironmentContainer["x-ms-client-name"] = "EnvironmentContainerProperties";
      $.EnvironmentVersionResource["x-ms-client-name"] = "EnvironmentVersion";
      $.EnvironmentVersion["x-ms-client-name"] = "EnvironmentVersionProperties";
      $.JobBaseResource["x-ms-client-name"] = "MachineLearningJob";
      $.JobBase["x-ms-client-name"] = "MachineLearningJobProperties";
      $.ModelContainerResource["x-ms-client-name"] = "ModelContainer";
      $.ModelContainer["x-ms-client-name"] = "ModelContainerProperties";
      $.ModelVersionResource["x-ms-client-name"] = "ModelVersion";
      $.ModelVersion["x-ms-client-name"] = "ModelVersionProperties";
      $.OnlineDeploymentTrackedResource["x-ms-client-name"] = "OnlineDeployment";
      $.OnlineDeployment["x-ms-client-name"] = "OnlineDeploymentProperties";
      $.OnlineEndpointTrackedResource["x-ms-client-name"] = "OnlineEndpoint";
      $.OnlineEndpoint["x-ms-client-name"] = "OnlineEndpointProperties";
```
