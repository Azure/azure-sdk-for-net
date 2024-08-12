// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.MobileNetwork.Models
{
    public static partial class ArmMobileNetworkModelFactory
    {
        /// <summary> Initializes a new instance of MobileNetworkPacketCaptureData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> The provisioning state of the packet capture session resource. </param>
        /// <param name="status"> The status of the packet capture session. </param>
        /// <param name="reason"> The reason the current packet capture session state. </param>
        /// <param name="captureStartOn"> The start time of the packet capture session. </param>
        /// <param name="networkInterfaces"> List of network interfaces to capture on. </param>
        /// <param name="bytesToCapturePerPacket"> Number of bytes captured per packet, the remaining bytes are truncated. The default "0" means the entire packet is captured. </param>
        /// <param name="totalBytesPerSession"> Maximum size of the capture output. </param>
        /// <param name="timeLimitInSeconds"> Maximum duration of the capture session in seconds. </param>
        /// <returns> A new <see cref="MobileNetwork.MobileNetworkPacketCaptureData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MobileNetworkPacketCaptureData MobileNetworkPacketCaptureData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, MobileNetworkProvisioningState? provisioningState, MobileNetworkPacketCaptureStatus? status, string reason, DateTimeOffset? captureStartOn, IEnumerable<string> networkInterfaces, long? bytesToCapturePerPacket, long? totalBytesPerSession, int? timeLimitInSeconds)
            => MobileNetworkPacketCaptureData(id, name, resourceType, systemData, provisioningState, status, reason, captureStartOn, networkInterfaces, bytesToCapturePerPacket, totalBytesPerSession, timeLimitInSeconds, outputFiles: default);

        /// <summary> Initializes a new instance of PacketCoreControlPlaneData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="userAssignedIdentity"> The identity used to retrieve the ingress certificate from Azure key vault. </param>
        /// <param name="provisioningState"> The provisioning state of the packet core control plane resource. </param>
        /// <param name="installation"> The installation state of the packet core control plane resource. </param>
        /// <param name="sites"> Site(s) under which this packet core control plane should be deployed. The sites must be in the same location as the packet core control plane. </param>
        /// <param name="platform"> The platform where the packet core is deployed. </param>
        /// <param name="coreNetworkTechnology"> The core network technology generation (5G core or EPC / 4G core). </param>
        /// <param name="version"> The desired version of the packet core software. </param>
        /// <param name="installedVersion"> The currently installed version of the packet core software. </param>
        /// <param name="rollbackVersion"> The previous version of the packet core software that was deployed. Used when performing the rollback action. </param>
        /// <param name="controlPlaneAccessInterface"> The control plane interface on the access network. For 5G networks, this is the N2 interface. For 4G networks, this is the S1-MME interface. </param>
        /// <param name="sku"> The SKU defining the throughput and SIM allowances for this packet core control plane deployment. </param>
        /// <param name="ueMtu"> The MTU (in bytes) signaled to the UE. The same MTU is set on the user plane data links for all data networks. The MTU set on the user plane access link is calculated to be 60 bytes greater than this value to allow for GTP encapsulation. </param>
        /// <param name="localDiagnosticsAccess"> The kubernetes ingress configuration to control access to packet core diagnostics over local APIs. </param>
        /// <param name="diagnosticsUploadStorageAccountContainerUri"> Configuration for uploading packet core diagnostics. </param>
        /// <param name="interopSettings"> Settings to allow interoperability with third party components e.g. RANs and UEs. </param>
        /// <returns> A new <see cref="MobileNetwork.PacketCoreControlPlaneData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PacketCoreControlPlaneData PacketCoreControlPlaneData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, MobileNetworkManagedServiceIdentity userAssignedIdentity, MobileNetworkProvisioningState? provisioningState, MobileNetworkInstallation installation, IEnumerable<WritableSubResource> sites, MobileNetworkPlatformConfiguration platform, MobileNetworkCoreNetworkType? coreNetworkTechnology, string version, string installedVersion, string rollbackVersion, MobileNetworkInterfaceProperties controlPlaneAccessInterface, MobileNetworkBillingSku sku, int? ueMtu, MobileNetworkLocalDiagnosticsAccessConfiguration localDiagnosticsAccess, Uri diagnosticsUploadStorageAccountContainerUri, BinaryData interopSettings)
            => PacketCoreControlPlaneData(id, name, resourceType, systemData, tags, location, userAssignedIdentity, provisioningState, installation, sites, platform, coreNetworkTechnology, version, installedVersion, rollbackVersion, controlPlaneAccessInterface, controlPlaneAccessVirtualIPv4Addresses: default, sku, ueMtu, localDiagnosticsAccess, diagnosticsUploadStorageAccountContainerUri, eventHub: default, signaling: default, interopSettings);

        /// <summary> Initializes a new instance of PacketCoreDataPlaneData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="provisioningState"> The provisioning state of the packet core data plane resource. </param>
        /// <param name="userPlaneAccessInterface"> The user plane interface on the access network. For 5G networks, this is the N3 interface. For 4G networks, this is the S1-U interface. </param>
        /// <returns> A new <see cref="MobileNetwork.PacketCoreDataPlaneData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PacketCoreDataPlaneData PacketCoreDataPlaneData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, MobileNetworkProvisioningState? provisioningState, MobileNetworkInterfaceProperties userPlaneAccessInterface)
            => PacketCoreDataPlaneData(id, name, resourceType, systemData, tags, location, provisioningState, userPlaneAccessInterface, userPlaneAccessVirtualIPv4Addresses: default);

        /// <summary> Initializes a new instance of <see cref="MobileNetwork.PacketCoreControlPlaneData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="userAssignedIdentity"> The identity used to retrieve the ingress certificate from Azure key vault. </param>
        /// <param name="provisioningState"> The provisioning state of the packet core control plane resource. </param>
        /// <param name="installation"> The installation state of the packet core control plane resource. </param>
        /// <param name="sites"> Site(s) under which this packet core control plane should be deployed. The sites must be in the same location as the packet core control plane. </param>
        /// <param name="platform"> The platform where the packet core is deployed. </param>
        /// <param name="coreNetworkTechnology"> The core network technology generation (5G core or EPC / 4G core). </param>
        /// <param name="version"> The desired version of the packet core software. </param>
        /// <param name="installedVersion"> The currently installed version of the packet core software. </param>
        /// <param name="rollbackVersion"> The previous version of the packet core software that was deployed. Used when performing the rollback action. </param>
        /// <param name="controlPlaneAccessInterface"> The control plane interface on the access network. For 5G networks, this is the N2 interface. For 4G networks, this is the S1-MME interface. </param>
        /// <param name="controlPlaneAccessVirtualIPv4Addresses"> The virtual IP address(es) for the control plane on the access network in a High Availability (HA) system. In an HA deployment the access network router should be configured to anycast traffic for this address to the control plane access interfaces on the active and standby nodes. In non-HA system this list should be omitted or empty. </param>
        /// <param name="sku"> The SKU defining the throughput and SIM allowances for this packet core control plane deployment. </param>
        /// <param name="ueMtu"> The MTU (in bytes) signaled to the UE. The same MTU is set on the user plane data links for all data networks. The MTU set on the user plane access link is calculated to be 60 bytes greater than this value to allow for GTP encapsulation. </param>
        /// <param name="localDiagnosticsAccess"> The kubernetes ingress configuration to control access to packet core diagnostics over local APIs. </param>
        /// <param name="diagnosticsUploadStorageAccountContainerUri"> Configuration for uploading packet core diagnostics. </param>
        /// <param name="eventHub"> Configuration for sending packet core events to an Azure Event Hub. </param>
        /// <param name="nasRerouteMacroMmeGroupId"> Signaling configuration for the packet core. </param>
        /// <param name="interopSettings"> Settings to allow interoperability with third party components e.g. RANs and UEs. </param>
        /// <param name="homeNetworkPrivateKeysProvisioningState"> The provisioning state of the secret containing private keys and keyIds for SUPI concealment. </param>
        /// <returns> A new <see cref="MobileNetwork.PacketCoreControlPlaneData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PacketCoreControlPlaneData PacketCoreControlPlaneData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, MobileNetworkManagedServiceIdentity userAssignedIdentity = null, MobileNetworkProvisioningState? provisioningState = null, MobileNetworkInstallation installation = null, IEnumerable<WritableSubResource> sites = null, MobileNetworkPlatformConfiguration platform = null, MobileNetworkCoreNetworkType? coreNetworkTechnology = null, string version = null, string installedVersion = null, string rollbackVersion = null, MobileNetworkInterfaceProperties controlPlaneAccessInterface = null, IEnumerable<string> controlPlaneAccessVirtualIPv4Addresses = null, MobileNetworkBillingSku sku = default, int? ueMtu = null, MobileNetworkLocalDiagnosticsAccessConfiguration localDiagnosticsAccess = null, Uri diagnosticsUploadStorageAccountContainerUri = null, MobileNetworkEventHubConfiguration eventHub = null, int? nasRerouteMacroMmeGroupId = null, BinaryData interopSettings = null, HomeNetworkPrivateKeysProvisioningState? homeNetworkPrivateKeysProvisioningState = null)
            => PacketCoreControlPlaneData(id, name, resourceType, systemData, tags, location, userAssignedIdentity, provisioningState, installation, sites, platform, coreNetworkTechnology, version, installedVersion, rollbackVersion, controlPlaneAccessInterface, controlPlaneAccessVirtualIPv4Addresses, sku, ueMtu, localDiagnosticsAccess, diagnosticsUploadStorageAccountContainerUri, eventHub, new PacketCoreSignalingConfiguration { NasRerouteMacroMmeGroupId = nasRerouteMacroMmeGroupId }, interopSettings, homeNetworkPrivateKeysProvisioningState);

        /// <summary> Initializes a new instance of <see cref="MobileNetwork.PacketCoreControlPlaneData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="userAssignedIdentity"> The identity used to retrieve the ingress certificate from Azure key vault. </param>
        /// <param name="provisioningState"> The provisioning state of the packet core control plane resource. </param>
        /// <param name="installation"> The installation state of the packet core control plane resource. </param>
        /// <param name="sites"> Site(s) under which this packet core control plane should be deployed. The sites must be in the same location as the packet core control plane. </param>
        /// <param name="platform"> The platform where the packet core is deployed. </param>
        /// <param name="coreNetworkTechnology"> The core network technology generation (5G core or EPC / 4G core). </param>
        /// <param name="version"> The desired version of the packet core software. </param>
        /// <param name="installedVersion"> The currently installed version of the packet core software. </param>
        /// <param name="rollbackVersion"> The previous version of the packet core software that was deployed. Used when performing the rollback action. </param>
        /// <param name="controlPlaneAccessInterface"> The control plane interface on the access network. For 5G networks, this is the N2 interface. For 4G networks, this is the S1-MME interface. </param>
        /// <param name="controlPlaneAccessVirtualIPv4Addresses"> The virtual IP address(es) for the control plane on the access network in a High Availability (HA) system. In an HA deployment the access network router should be configured to anycast traffic for this address to the control plane access interfaces on the active and standby nodes. In non-HA system this list should be omitted or empty. </param>
        /// <param name="sku"> The SKU defining the throughput and SIM allowances for this packet core control plane deployment. </param>
        /// <param name="ueMtu"> The MTU (in bytes) signaled to the UE. The same MTU is set on the user plane data links for all data networks. The MTU set on the user plane access link is calculated to be 60 bytes greater than this value to allow for GTP encapsulation. </param>
        /// <param name="localDiagnosticsAccess"> The kubernetes ingress configuration to control access to packet core diagnostics over local APIs. </param>
        /// <param name="diagnosticsUploadStorageAccountContainerUri"> Configuration for uploading packet core diagnostics. </param>
        /// <param name="eventHub"> Configuration for sending packet core events to an Azure Event Hub. </param>
        /// <param name="nasRerouteMacroMmeGroupId"> Signaling configuration for the packet core. </param>
        /// <param name="interopSettings"> Settings to allow interoperability with third party components e.g. RANs and UEs. </param>
        /// <returns> A new <see cref="MobileNetwork.PacketCoreControlPlaneData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PacketCoreControlPlaneData PacketCoreControlPlaneData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, MobileNetworkManagedServiceIdentity userAssignedIdentity = null, MobileNetworkProvisioningState? provisioningState = null, MobileNetworkInstallation installation = null, IEnumerable<WritableSubResource> sites = null, MobileNetworkPlatformConfiguration platform = null, MobileNetworkCoreNetworkType? coreNetworkTechnology = null, string version = null, string installedVersion = null, string rollbackVersion = null, MobileNetworkInterfaceProperties controlPlaneAccessInterface = null, IEnumerable<string> controlPlaneAccessVirtualIPv4Addresses = null, MobileNetworkBillingSku sku = default, int? ueMtu = null, MobileNetworkLocalDiagnosticsAccessConfiguration localDiagnosticsAccess = null, Uri diagnosticsUploadStorageAccountContainerUri = null, MobileNetworkEventHubConfiguration eventHub = null, int? nasRerouteMacroMmeGroupId = null, BinaryData interopSettings = null)
            => PacketCoreControlPlaneData(id, name, resourceType, systemData, tags, location, userAssignedIdentity, provisioningState, installation, sites, platform, coreNetworkTechnology, version, installedVersion, rollbackVersion, controlPlaneAccessInterface, controlPlaneAccessVirtualIPv4Addresses, sku, ueMtu, localDiagnosticsAccess, diagnosticsUploadStorageAccountContainerUri, eventHub, new PacketCoreSignalingConfiguration { NasRerouteMacroMmeGroupId = nasRerouteMacroMmeGroupId }, interopSettings);
    }
}
