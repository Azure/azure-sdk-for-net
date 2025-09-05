# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ComputeFleet
namespace: Azure.ResourceManager.ComputeFleet
require: https://github.com/Azure/azure-rest-api-specs/blob/ad73e424df6df56b4cd206fcba7149891b5b6660/specification/azurefleet/resource-manager/readme.md
#tag: package-preview-2024-05
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
    - Fleets_Update
    - Fleets_CreateOrUpdate
skip-csproj: true
modelerfour:
  flatten-payloads: false
  flatten-models: false
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
  Fleet: ComputeFleet
  FleetProperties: ComputeFleetProperties
  FleetProperties.timeCreated: CreatedOn
  AdditionalUnattendContent: WindowsSetupAdditionalInformation
  AdditionalUnattendContentComponentName: WindowsSetupAdditionalInformationComponentName
  AdditionalUnattendContentPassName: WindowsSetupAdditionalInformationPassName
  ApiErrorBase: ComputeFleetApiErrorInfo
  BaseVirtualMachineProfile: ComputeFleetVmProfile
  BaseVirtualMachineProfile.timeCreated: CreatedOn
  BootDiagnostics.enabled: IsEnabled
  DeleteOptions: ComputeFleetVmDeleteOptions
  DiskControllerTypes.NVMe: Nvme
  LinuxConfiguration.disablePasswordAuthentication: IsPasswordAuthenticationDisabled
  LinuxConfiguration.provisionVMAgent: IsVmAgentProvisioned
  LinuxConfiguration.enableVMAgentPlatformUpdates: IsVmAgentPlatformUpdatesEnabled
  LinuxVMGuestPatchAutomaticByPlatformSettings.bypassPlatformSafetyChecksOnUserSchedule: IsBypassPlatformSafetyChecksOnUserScheduleEnabled
  Mode: ProxyAgentExecuteMode
  OSImageNotificationProfile.enable: IsEnabled
  PatchSettings: ComputeFleetVmGuestPatchSettings
  PatchSettings.enableHotpatching: IsHotPatchingEnabled
  ProxyAgentSettings.enabled: IsEnabled
  SecurityEncryptionTypes.NonPersistedTPM: NonPersistedTpm
  SecurityProfile.encryptionAtHost: IsEncryptionAtHostEnabled
  SettingNames: AdditionalInformationSettingNames
  SpotPriorityProfile.maintain: IsMaintainEnabled
  StorageAccountTypes.Standard_LRS: StandardLrs
  StorageAccountTypes.Premium_LRS: PremiumLrs
  StorageAccountTypes.StandardSSD_LRS: StandardSsdLrd
  StorageAccountTypes.UltraSSD_LRS: UltraSsdLrs
  StorageAccountTypes.Premium_ZRS: PremiumZrs
  StorageAccountTypes.StandardSSD_ZRS: StandardSsdZrs
  TerminateNotificationProfile.enable: IsEnabled
  UefiSettings.secureBootEnabled: IsSecureBootEnabled
  UefiSettings.vTpmEnabled: IsVTpmEnabled
  VirtualMachineScaleSet: ComputeFleetVmss
  VirtualMachineScaleSetDataDisk: ComputeFleetVmssDataDisk
  VirtualMachineScaleSetDataDisk.writeAcceleratorEnabled: IsWriteAcceleratorEnabled
  VirtualMachineScaleSetDataDisk.diskIOPSReadWrite: DiskIopsReadWrite
  VirtualMachineScaleSetDataDisk.diskMBpsReadWrite: DiskMbpsReadWrite
  VirtualMachineScaleSetExtension: ComputeFleetVmssExtension
  VirtualMachineScaleSetExtension.type: ExtensionType
  VirtualMachineScaleSetExtensionProfile: ComputeFleetVmssExtensionProfile
  VirtualMachineScaleSetExtensionProperties: ComputeFleetVmssExtensionProperties
  VirtualMachineScaleSetExtensionProperties.type: ExtensionType
  VirtualMachineScaleSetExtensionProperties.autoUpgradeMinorVersion: ShouldAutoUpgradeMinorVersion
  VirtualMachineScaleSetExtensionProperties.enableAutomaticUpgrade: IsAutomaticUpgradeEnabled
  VirtualMachineScaleSetExtensionProperties.suppressFailures: IsSuppressFailuresEnabled
  VirtualMachineScaleSetHardwareProfile: ComputeFleetVmssHardwareProfile
  VirtualMachineScaleSetIPConfiguration: ComputeFleetVmssIPConfiguration
  VirtualMachineScaleSetIPConfigurationProperties: ComputeFleetVmssIPConfigurationProperties
  VirtualMachineScaleSetIPConfigurationProperties.primary: IsPrimary
  VirtualMachineScaleSetIpTag: ComputeFleetVmssIPTag
  VirtualMachineScaleSetManagedDiskParameters: ComputeFleetVmssManagedDisk
  VirtualMachineScaleSetNetworkConfiguration: ComputeFleetVmssNetworkConfiguration
  VirtualMachineScaleSetNetworkConfigurationDnsSettings: ComputeFleetVmssNetworkDnsSettings
  VirtualMachineScaleSetNetworkConfigurationProperties: ComputeFleetVmssNetworkConfigurationProperties
  VirtualMachineScaleSetNetworkConfigurationProperties.primary: IsPrimary
  VirtualMachineScaleSetNetworkConfigurationProperties.enableAcceleratedNetworking: IsAcceleratedNetworkingEnabled
  VirtualMachineScaleSetNetworkConfigurationProperties.disableTcpStateTracking: IsTcpStateTrackingDisabled
  VirtualMachineScaleSetNetworkConfigurationProperties.enableFpga: IsFpgaEnabled
  VirtualMachineScaleSetNetworkConfigurationProperties.enableIPForwarding: IsIPForwardingEnabled
  VirtualMachineScaleSetNetworkProfile: ComputeFleetVmssNetworkProfile
  VirtualMachineScaleSetOSDisk: ComputeFleetVmssOSDisk
  VirtualMachineScaleSetOSDisk.writeAcceleratorEnabled: IsWriteAcceleratorEnabled
  VirtualMachineScaleSetOSProfile: ComputeFleetVmssOSProfile
  VirtualMachineScaleSetOSProfile.allowExtensionOperations: AreExtensionOperationsAllowed
  VirtualMachineScaleSetOSProfile.requireGuestProvisionSignal: IsGuestProvisionSignalRequired
  VirtualMachineScaleSetPublicIPAddressConfiguration: ComputeFleetVmssPublicIPAddressConfiguration
  VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings: ComputeFleetVmssPublicIPAddressDnsSettings
  VirtualMachineScaleSetPublicIPAddressConfigurationProperties: ComputeFleetVmssPublicIPAddressConfigurationProperties
  VirtualMachineScaleSetStorageProfile: ComputeFleetVmssStorageProfile
  VMGalleryApplication.treatFailureAsDeploymentFailure: IsTreatFailureAsDeploymentFailureEnabled
  VMGalleryApplication.enableAutomaticUpgrade: IsAutomaticUpgradeEnabled
  WindowsConfiguration.provisionVMAgent: IsVmAgentProvisioned
  WindowsConfiguration.enableAutomaticUpdates: IsAutomaticUpdatesEnabled
  WindowsConfiguration.enableVMAgentPlatformUpdates: IsVmAgentPlatformUpdatesEnabled
  WindowsVMGuestPatchAutomaticByPlatformSettings.bypassPlatformSafetyChecksOnUserSchedule: IsBypassPlatformSafetyChecksOnUserScheduleEnabled

prepend-rp-prefix:
  - ApiError
  - ApplicationProfile
  - BootDiagnostics
  - CachingTypes
  - ComputeProfile
  - DiagnosticsProfile
  - DiffDiskOptions
  - DiffDiskPlacement
  - DiffDiskSettings
  - DiskControllerTypes
  - DiskCreateOptionTypes
  - DiskDeleteOptionTypes
  - DomainNameLabelScopeTypes
  - EncryptionIdentity
  - EvictionPolicy
  - ImageReference
  - InnerError
  - IPVersion
  - KeyVaultSecretReference
  - LinuxConfiguration
  - LinuxPatchAssessmentMode
  - LinuxPatchSettings
  - LinuxVMGuestPatchAutomaticByPlatformRebootSetting
  - LinuxVMGuestPatchAutomaticByPlatformSettings
  - LinuxVMGuestPatchMode
  - NetworkApiVersion
  - NetworkInterfaceAuxiliaryMode
  - NetworkInterfaceAuxiliarySku
  - OperatingSystemTypes
  - OSImageNotificationProfile
  - ProtocolTypes
  - ProvisioningState
  - ProxyAgentSettings
  - PublicIPAddressSku
  - PublicIPAddressSkuName
  - PublicIPAddressSkuTier
  - ScheduledEventsProfile
  - SecurityEncryptionTypes
  - SecurityPostureReference
  - SecurityProfile
  - SecurityTypes
  - SshConfiguration
  - SshPublicKey
  - StorageAccountTypes
  - TerminateNotificationProfile
  - UefiSettings
  - VaultCertificate
  - VaultSecretGroup
  - VirtualHardDisk
  - VMDiskSecurityProfile
  - VMGalleryApplication
  - VmSizeProfile
  - VMSizeProperties
  - WindowsConfiguration
  - WindowsPatchAssessmentMode
  - WindowsVMGuestPatchAutomaticByPlatformRebootSetting
  - WindowsVMGuestPatchAutomaticByPlatformSettings
  - WindowsVMGuestPatchMode
  - WinRMListener

```
