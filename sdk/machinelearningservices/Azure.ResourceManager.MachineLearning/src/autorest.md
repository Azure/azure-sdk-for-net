# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: MachineLearning
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0bff4d0f259847b1fc97a4ca8f98b8c40d672ba5/specification/machinelearningservices/resource-manager/readme.md
tag: package-2022-02-01-preview
modelerfour:
  lenient-model-deduplication: true
output-folder: $(this-folder)/Generated
clear-output-folder: true
namespace: Azure.ResourceManager.MachineLearning
skip-csproj: true

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
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
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
  AKS: Aks

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
      $.PrivateEndpointConnection.properties.location["x-ms-format"] = "azure-location";
      $.Workspace.properties.location["x-ms-format"] = "azure-location";
      $.WorkspaceProperties.properties.tenantId["format"] = "uuid";
      $.ComputeResource["x-ms-client-name"] = "MachineLearningCompute";
      $.AKS["x-ms-client-name"] = "AksCompute";
  - from: mfe.json
    where: $.definitions
    transform: >
      $.CodeContainerResource["x-ms-client-name"] = "CodeContainer";
      $.BatchDeploymentTrackedResource["x-ms-client-name"] = "BatchDeployment";
      $.BatchEndpointTrackedResource["x-ms-client-name"] = "BatchEndpoint";
      $.CodeVersionResource["x-ms-client-name"] = "CodeVersion";
      $.ComponentContainerResource["x-ms-client-name"] = "ComponentContainer";
      $.ComponentVersionResource["x-ms-client-name"] = "ComponentVersion";
      $.DataContainerResource["x-ms-client-name"] = "DataContainer";
      $.DatastoreResource["x-ms-client-name"] = "Datastore";
      $.DataVersionBaseResource["x-ms-client-name"] = "DataVersionBase";
      $.DataVersionBase["x-ms-client-name"] = "DataVersionBaseProperties";
```
