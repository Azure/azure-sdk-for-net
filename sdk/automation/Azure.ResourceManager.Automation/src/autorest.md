# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Automation
namespace: Azure.ResourceManager.Automation
require: https://github.com/Azure/azure-rest-api-specs/blob/d1b0569d8adbd342a1111d6a69764d099f5f717c/specification/automation/resource-manager/readme.md
tag: package-2022-02-22
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  DscConfigurationAssociationProperty.name: ConfigurationName
  NodeCountProperties.count: NameCount

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
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

request-path-to-parent:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/jobs: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/jobs/{jobName}
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurations:  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurations/{softwareUpdateConfigurationName}
override-operation-name:
  Job_ListByAutomationAccount: GetAll
operation-positions:
  Job_ListByAutomationAccount: collection
  SoftwareUpdateConfigurations_List: collection

directive:
  - from: softwareUpdateConfigurationMachineRun.json
    where: $.definitions
    transform: >
        $.updateConfigurationMachineRunProperties.properties.configuredDuration['format'] = 'duration';
  - from: softwareUpdateConfigurationRun.json
    where: $.definitions
    transform: >
        $.softwareUpdateConfigurationRunProperties.properties.configuredDuration['format'] = 'duration';
  - from: dscConfiguration.json
    where: $
    transform: >
        $.consumes =  [ "application/json" ];
        $.produces =  [ "application/json" ];
  - from: softwareUpdateConfiguration.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurations'].get
    transform: >
      $['x-ms-pageable'] = {
        'nextLinkName': null
      };
```