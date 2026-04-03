// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat ModelFactory: the generated ModelFactory was excluded from compilation (generator bug)
// and this custom implementation provides stub factory methods for the old API surface (ApiCompat MembersMustExist).

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmContainerInstanceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.CachedImages"/>. </summary>
        /// <param name="osType"> The OS type of the cached image. </param>
        /// <param name="image"> The cached image name. </param>
        /// <returns> A new <see cref="Models.CachedImages"/> instance for mocking. </returns>
        public static CachedImages CachedImages(string osType = null, string image = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerAttachResult"/>. </summary>
        /// <param name="webSocketUri"> The uri for the output stream from the attach. </param>
        /// <param name="password"> The password to the output stream from the attach. </param>
        /// <returns> A new <see cref="Models.ContainerAttachResult"/> instance for mocking. </returns>
        public static ContainerAttachResult ContainerAttachResult(Uri webSocketUri = null, string password = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerCapabilities"/>. </summary>
        /// <param name="resourceType"> The resource type name. </param>
        /// <param name="osType"> The OS type. </param>
        /// <param name="location"> The resource location. </param>
        /// <param name="ipAddressType"> The ip address type. </param>
        /// <param name="gpu"> The GPU sku. </param>
        /// <param name="capabilities"> The supported capabilities. </param>
        /// <returns> A new <see cref="Models.ContainerCapabilities"/> instance for mocking. </returns>
        public static ContainerCapabilities ContainerCapabilities(string resourceType = null, string osType = null, AzureLocation? location = default(AzureLocation?), string ipAddressType = null, string gpu = null, ContainerSupportedCapabilities capabilities = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerEvent"/>. </summary>
        /// <param name="count"> The count of the event. </param>
        /// <param name="firstTimestamp"> The date-time of the earliest logged event. </param>
        /// <param name="lastTimestamp"> The date-time of the latest logged event. </param>
        /// <param name="name"> The event name. </param>
        /// <param name="message"> The event message. </param>
        /// <param name="eventType"> The event type. </param>
        /// <returns> A new <see cref="Models.ContainerEvent"/> instance for mocking. </returns>
        public static ContainerEvent ContainerEvent(int? count = default(int?), DateTimeOffset? firstTimestamp = default(DateTimeOffset?), DateTimeOffset? lastTimestamp = default(DateTimeOffset?), string name = null, string message = null, string eventType = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerExecResult"/>. </summary>
        /// <param name="webSocketUri"> The uri for the output stream from the exec. </param>
        /// <param name="password"> The password to the output stream from the exec. </param>
        /// <returns> A new <see cref="Models.ContainerExecResult"/> instance for mocking. </returns>
        public static ContainerExecResult ContainerExecResult(Uri webSocketUri = null, string password = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="ContainerInstance.ContainerGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> The identity of the container group, if configured. </param>
        /// <param name="containerGroupProvisioningState"> The provisioning state of the container group. </param>
        /// <param name="secretReferences"> The secret references. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="imageRegistryCredentials"> The image registry credentials. </param>
        /// <param name="restartPolicy"> Restart policy for all containers within the container group. </param>
        /// <param name="ipAddress"> The IP address type of the container group. </param>
        /// <param name="containerGroupOSType"> The operating system type required by the containers. </param>
        /// <param name="volumes"> The list of volumes. </param>
        /// <param name="instanceView"> The instance view of the container group. </param>
        /// <param name="diagnosticsLogAnalytics"> Container group log analytics information. </param>
        /// <param name="subnetIds"> The subnet resource IDs for a container group. </param>
        /// <param name="dnsConfig"> The DNS config information. </param>
        /// <param name="sku"> The SKU for a container group. </param>
        /// <param name="encryptionProperties"> The encryption properties for a container group. </param>
        /// <param name="initContainers"> The init containers for a container group. </param>
        /// <param name="extensions"> extensions used by virtual kubelet. </param>
        /// <param name="confidentialComputeCcePolicy"> The properties for confidential container group. </param>
        /// <param name="priority"> The priority of the container group. </param>
        /// <param name="identityAcls"> The access control levels of the identities. </param>
        /// <param name="containerGroupProfile"> The reference container group profile properties. </param>
        /// <param name="standbyPoolProfile"> The reference standby pool profile properties. </param>
        /// <param name="isCreatedFromStandbyPool"> The flag to determine whether the container group is created from standby pool. </param>
        /// <param name="zones"> The zones for the container group. </param>
        /// <returns> A new <see cref="ContainerInstance.ContainerGroupData"/> instance for mocking. </returns>
        public static ContainerGroupData ContainerGroupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ManagedServiceIdentity identity = null, ContainerGroupProvisioningState? containerGroupProvisioningState = default(ContainerGroupProvisioningState?), IEnumerable<ContainerGroupSecretReference> secretReferences = null, IEnumerable<ContainerInstanceContainer> containers = null, IEnumerable<ContainerGroupImageRegistryCredential> imageRegistryCredentials = null, ContainerGroupRestartPolicy? restartPolicy = default(ContainerGroupRestartPolicy?), ContainerGroupIPAddress ipAddress = null, ContainerInstanceOperatingSystemType? containerGroupOSType = default(ContainerInstanceOperatingSystemType?), IEnumerable<ContainerVolume> volumes = null, ContainerGroupInstanceView instanceView = null, ContainerGroupLogAnalytics diagnosticsLogAnalytics = null, IEnumerable<ContainerGroupSubnetId> subnetIds = null, ContainerGroupDnsConfiguration dnsConfig = null, ContainerGroupSku? sku = default(ContainerGroupSku?), ContainerGroupEncryptionProperties encryptionProperties = null, IEnumerable<InitContainerDefinitionContent> initContainers = null, IEnumerable<DeploymentExtensionSpec> extensions = null, string confidentialComputeCcePolicy = null, ContainerGroupPriority? priority = default(ContainerGroupPriority?), ContainerGroupIdentityAccessControlLevels identityAcls = null, ContainerGroupProfileReferenceDefinition containerGroupProfile = null, StandbyPoolProfileDefinition standbyPoolProfile = null, bool? isCreatedFromStandbyPool = default(bool?), IEnumerable<string> zones = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="ContainerInstance.ContainerGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="zones"> The zones for the container group. </param>
        /// <param name="identity"> The identity of the container group, if configured. </param>
        /// <param name="provisioningState"> The provisioning state of the container group. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="imageRegistryCredentials"> The image registry credentials. </param>
        /// <param name="restartPolicy"> Restart policy for all containers within the container group. </param>
        /// <param name="ipAddress"> The IP address type of the container group. </param>
        /// <param name="osType"> The operating system type required by the containers. </param>
        /// <param name="volumes"> The list of volumes. </param>
        /// <param name="instanceView"> The instance view of the container group. </param>
        /// <param name="diagnosticsLogAnalytics"> Container group log analytics information. </param>
        /// <param name="subnetIds"> The subnet resource IDs for a container group. </param>
        /// <param name="dnsConfig"> The DNS config information. </param>
        /// <param name="sku"> The SKU for a container group. </param>
        /// <param name="encryptionProperties"> The encryption properties for a container group. </param>
        /// <param name="initContainers"> The init containers for a container group. </param>
        /// <param name="extensions"> extensions used by virtual kubelet. </param>
        /// <param name="confidentialComputeCcePolicy"> The properties for confidential container group. </param>
        /// <param name="priority"> The priority of the container group. </param>
        /// <returns> A new <see cref="ContainerInstance.ContainerGroupData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerGroupData ContainerGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> zones, ManagedServiceIdentity identity, string provisioningState, IEnumerable<ContainerInstanceContainer> containers, IEnumerable<ContainerGroupImageRegistryCredential> imageRegistryCredentials, ContainerGroupRestartPolicy? restartPolicy, ContainerGroupIPAddress ipAddress, ContainerInstanceOperatingSystemType osType, IEnumerable<ContainerVolume> volumes, ContainerGroupInstanceView instanceView, ContainerGroupLogAnalytics diagnosticsLogAnalytics, IEnumerable<ContainerGroupSubnetId> subnetIds, ContainerGroupDnsConfiguration dnsConfig, ContainerGroupSku? sku, ContainerGroupEncryptionProperties encryptionProperties, IEnumerable<InitContainerDefinitionContent> initContainers, IEnumerable<DeploymentExtensionSpec> extensions, string confidentialComputeCcePolicy, ContainerGroupPriority? priority)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerGroupInstanceView"/>. </summary>
        /// <param name="events"> The events of this container group. </param>
        /// <param name="state"> The state of the container group. </param>
        /// <returns> A new <see cref="Models.ContainerGroupInstanceView"/> instance for mocking. </returns>
        public static ContainerGroupInstanceView ContainerGroupInstanceView(IEnumerable<ContainerEvent> events = null, string state = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerGroupIPAddress"/>. </summary>
        /// <param name="ports"> The list of ports exposed on the container group. </param>
        /// <param name="addressType"> Specifies if the IP is exposed to the public internet or private VNET. </param>
        /// <param name="ip"> The IP exposed to the public internet. </param>
        /// <param name="dnsNameLabel"> The Dns name label for the IP. </param>
        /// <param name="autoGeneratedDomainNameLabelScope"> The value representing the security enum. </param>
        /// <param name="fqdn"> The FQDN for the IP. </param>
        /// <returns> A new <see cref="Models.ContainerGroupIPAddress"/> instance for mocking. </returns>
        public static ContainerGroupIPAddress ContainerGroupIPAddress(IEnumerable<ContainerGroupPort> ports = null, ContainerGroupIPAddressType addressType = default(ContainerGroupIPAddressType), IPAddress ip = null, string dnsNameLabel = null, DnsNameLabelReusePolicy? autoGeneratedDomainNameLabelScope = default(DnsNameLabelReusePolicy?), string fqdn = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerGroupPatch"/>. </summary>
        /// <param name="id"> The resource id. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The resource tags. </param>
        /// <param name="location"> The resource location. </param>
        /// <param name="zones"> The zones for the container group. </param>
        /// <returns> A new <see cref="Models.ContainerGroupPatch"/> instance for mocking. </returns>
        public static ContainerGroupPatch ContainerGroupPatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), IEnumerable<string> zones = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="ContainerInstance.ContainerGroupProfileData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The SKU for a container group. </param>
        /// <param name="encryptionProperties"> The encryption properties for a container group. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="initContainers"> The init containers for a container group. </param>
        /// <param name="extensions"> extensions used by virtual kubelet. </param>
        /// <param name="imageRegistryCredentials"> The image registry credentials. </param>
        /// <param name="restartPolicy"> Restart policy for all containers within the container group. </param>
        /// <param name="shutdownGracePeriod"> Shutdown grace period for containers. </param>
        /// <param name="ipAddress"> The IP address type of the container group. </param>
        /// <param name="timeToLive"> Post completion time to live for containers. </param>
        /// <param name="osType"> The operating system type required by the containers. </param>
        /// <param name="volumes"> The list of volumes. </param>
        /// <param name="diagnosticsLogAnalytics"> Container group log analytics information. </param>
        /// <param name="priority"> The priority of the container group. </param>
        /// <param name="confidentialComputeCcePolicy"> The properties for confidential container group. </param>
        /// <param name="securityContext"> The container security properties. </param>
        /// <param name="revision"> Container group profile current revision number. </param>
        /// <param name="registeredRevisions"> Registered revisions. </param>
        /// <param name="useKrypton"> Gets or sets Krypton use property. </param>
        /// <param name="zones"> The zones for the container group. </param>
        /// <returns> A new <see cref="ContainerInstance.ContainerGroupProfileData"/> instance for mocking. </returns>
        public static ContainerGroupProfileData ContainerGroupProfileData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ContainerGroupSku? sku = default(ContainerGroupSku?), ContainerGroupEncryptionProperties encryptionProperties = null, IEnumerable<ContainerInstanceContainer> containers = null, IEnumerable<InitContainerDefinitionContent> initContainers = null, IEnumerable<DeploymentExtensionSpec> extensions = null, IEnumerable<ContainerGroupImageRegistryCredential> imageRegistryCredentials = null, ContainerGroupRestartPolicy? restartPolicy = default(ContainerGroupRestartPolicy?), DateTimeOffset? shutdownGracePeriod = default(DateTimeOffset?), ContainerGroupIPAddress ipAddress = null, DateTimeOffset? timeToLive = default(DateTimeOffset?), ContainerInstanceOperatingSystemType? osType = default(ContainerInstanceOperatingSystemType?), IEnumerable<ContainerVolume> volumes = null, ContainerGroupLogAnalytics diagnosticsLogAnalytics = null, ContainerGroupPriority? priority = default(ContainerGroupPriority?), string confidentialComputeCcePolicy = null, ContainerSecurityContextDefinition securityContext = null, int? revision = default(int?), IEnumerable<int> registeredRevisions = null, bool? useKrypton = default(bool?), IEnumerable<string> zones = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerInstanceContainer"/>. </summary>
        /// <param name="name"> The user-provided name of the container instance. </param>
        /// <param name="image"> The name of the image used to create the container instance. </param>
        /// <param name="command"> The commands to execute within the container instance in exec form. </param>
        /// <param name="ports"> The exposed ports on the container instance. </param>
        /// <param name="environmentVariables"> The environment variables to set in the container instance. </param>
        /// <param name="instanceView"> The instance view of the container instance. </param>
        /// <param name="resources"> The resource requirements of the container instance. </param>
        /// <param name="volumeMounts"> The volume mounts available to the container instance. </param>
        /// <param name="livenessProbe"> The liveness probe. </param>
        /// <param name="readinessProbe"> The readiness probe. </param>
        /// <param name="securityContext"> The container security properties. </param>
        /// <returns> A new <see cref="Models.ContainerInstanceContainer"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerInstanceContainer ContainerInstanceContainer(string name, string image, IEnumerable<string> command, IEnumerable<ContainerPort> ports, IEnumerable<ContainerEnvironmentVariable> environmentVariables, ContainerInstanceView instanceView, ContainerResourceRequirements resources, IEnumerable<ContainerVolumeMount> volumeMounts, ContainerProbe livenessProbe, ContainerProbe readinessProbe, ContainerSecurityContextDefinition securityContext)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerInstanceContainer"/>. </summary>
        /// <param name="name"> The user-provided name of the container instance. </param>
        /// <param name="image"> The name of the image used to create the container instance. </param>
        /// <param name="command"> The commands to execute within the container instance in exec form. </param>
        /// <param name="ports"> The exposed ports on the container instance. </param>
        /// <param name="environmentVariables"> The environment variables to set in the container instance. </param>
        /// <param name="instanceView"> The instance view of the container instance. </param>
        /// <param name="resources"> The resource requirements of the container instance. </param>
        /// <param name="volumeMounts"> The volume mounts available to the container instance. </param>
        /// <param name="livenessProbe"> The liveness probe. </param>
        /// <param name="readinessProbe"> The readiness probe. </param>
        /// <param name="securityContext"> The container security properties. </param>
        /// <param name="configMapKeyValuePairs"> The config map key value pairs to set in the container instance. </param>
        /// <returns> A new <see cref="Models.ContainerInstanceContainer"/> instance for mocking. </returns>
        public static ContainerInstanceContainer ContainerInstanceContainer(string name = null, string image = null, IEnumerable<string> command = null, IEnumerable<ContainerPort> ports = null, IEnumerable<ContainerEnvironmentVariable> environmentVariables = null, ContainerInstanceView instanceView = null, ContainerResourceRequirements resources = null, IEnumerable<ContainerVolumeMount> volumeMounts = null, ContainerProbe livenessProbe = null, ContainerProbe readinessProbe = null, ContainerSecurityContextDefinition securityContext = null, IDictionary<string, string> configMapKeyValuePairs = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerInstanceUsage"/>. </summary>
        /// <param name="id"> The resource usage id. </param>
        /// <param name="unit"> The unit of the resource usage. </param>
        /// <param name="currentValue"> The current usage of the resource. </param>
        /// <param name="limit"> The maximum permitted usage of the resource. </param>
        /// <param name="name"> The name object of the resource. </param>
        /// <returns> A new <see cref="Models.ContainerInstanceUsage"/> instance for mocking. </returns>
        public static ContainerInstanceUsage ContainerInstanceUsage(string id = null, string unit = null, int? currentValue = default(int?), int? limit = default(int?), ContainerInstanceUsageName name = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerInstanceUsageName"/>. </summary>
        /// <param name="value"> The name of the resource. </param>
        /// <param name="localizedValue"> The localized name of the resource. </param>
        /// <returns> A new <see cref="Models.ContainerInstanceUsageName"/> instance for mocking. </returns>
        public static ContainerInstanceUsageName ContainerInstanceUsageName(string value = null, string localizedValue = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerInstanceView"/>. </summary>
        /// <param name="restartCount"> The number of times that the container instance has been restarted. </param>
        /// <param name="currentState"> Current container instance state. </param>
        /// <param name="previousState"> Previous container instance state. </param>
        /// <param name="events"> The events of the container instance. </param>
        /// <returns> A new <see cref="Models.ContainerInstanceView"/> instance for mocking. </returns>
        public static ContainerInstanceView ContainerInstanceView(int? restartCount = default(int?), ContainerState currentState = null, ContainerState previousState = null, IEnumerable<ContainerEvent> events = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerLogs"/>. </summary>
        /// <param name="content"> The content of the log. </param>
        /// <returns> A new <see cref="Models.ContainerLogs"/> instance for mocking. </returns>
        public static ContainerLogs ContainerLogs(string content = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerState"/>. </summary>
        /// <param name="state"> The state of the container instance. </param>
        /// <param name="startOn"> The date-time when the container instance state started. </param>
        /// <param name="exitCode"> The container instance exit codes correspond to those from the `docker run` command. </param>
        /// <param name="finishOn"> The date-time when the container instance state finished. </param>
        /// <param name="detailStatus"> The human-readable status of the container instance state. </param>
        /// <returns> A new <see cref="Models.ContainerState"/> instance for mocking. </returns>
        public static ContainerState ContainerState(string state = null, DateTimeOffset? startOn = default(DateTimeOffset?), int? exitCode = default(int?), DateTimeOffset? finishOn = default(DateTimeOffset?), string detailStatus = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerSupportedCapabilities"/>. </summary>
        /// <param name="maxMemoryInGB"> The maximum allowed memory request in GB. </param>
        /// <param name="maxCpu"> The maximum allowed CPU request in cores. </param>
        /// <param name="maxGpuCount"> The maximum allowed GPU count. </param>
        /// <returns> A new <see cref="Models.ContainerSupportedCapabilities"/> instance for mocking. </returns>
        public static ContainerSupportedCapabilities ContainerSupportedCapabilities(float? maxMemoryInGB = default(float?), float? maxCpu = default(float?), float? maxGpuCount = default(float?))
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.InitContainerDefinitionContent"/>. </summary>
        /// <param name="name"> The name for the init container. </param>
        /// <param name="image"> The image of the init container. </param>
        /// <param name="command"> The command to execute within the init container in exec form. </param>
        /// <param name="environmentVariables"> The environment variables to set in the init container. </param>
        /// <param name="instanceView"> The instance view of the init container. </param>
        /// <param name="volumeMounts"> The volume mounts available to the init container. </param>
        /// <param name="securityContext"> The container security properties. </param>
        /// <returns> A new <see cref="Models.InitContainerDefinitionContent"/> instance for mocking. </returns>
        public static InitContainerDefinitionContent InitContainerDefinitionContent(string name = null, string image = null, IEnumerable<string> command = null, IEnumerable<ContainerEnvironmentVariable> environmentVariables = null, InitContainerPropertiesDefinitionInstanceView instanceView = null, IEnumerable<ContainerVolumeMount> volumeMounts = null, ContainerSecurityContextDefinition securityContext = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.InitContainerPropertiesDefinitionInstanceView"/>. </summary>
        /// <param name="restartCount"> The number of times that the init container has been restarted. </param>
        /// <param name="currentState"> The current state of the init container. </param>
        /// <param name="previousState"> The previous state of the init container. </param>
        /// <param name="events"> The events of the init container. </param>
        /// <returns> A new <see cref="Models.InitContainerPropertiesDefinitionInstanceView"/> instance for mocking. </returns>
        public static InitContainerPropertiesDefinitionInstanceView InitContainerPropertiesDefinitionInstanceView(int? restartCount = default(int?), ContainerState currentState = null, ContainerState previousState = null, IEnumerable<ContainerEvent> events = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="ContainerInstance.NGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> The identity of the NGroup, if configured. </param>
        /// <param name="elasticProfile"> The elastic profile. </param>
        /// <param name="placementFaultDomainCount"> The number of fault domains. </param>
        /// <param name="containerGroupProfiles"> The Container Group Profiles. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="updateProfile"> The update profile. </param>
        /// <param name="zones"> The availability zones. </param>
        /// <returns> A new <see cref="ContainerInstance.NGroupData"/> instance for mocking. </returns>
        public static NGroupData NGroupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ManagedServiceIdentity identity = null, ContainerGroupElasticProfile elasticProfile = null, int? placementFaultDomainCount = default(int?), IEnumerable<ContainerGroupProfileStub> containerGroupProfiles = null, NGroupProvisioningState? provisioningState = default(NGroupProvisioningState?), NGroupUpdateProfile updateProfile = null, IEnumerable<string> zones = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.NGroupPatch"/>. </summary>
        /// <param name="systemData"> Metadata pertaining to creation and last modification. </param>
        /// <param name="identity"> The identity of the NGroup, if configured. </param>
        /// <param name="tags"> The resource tags. </param>
        /// <param name="zones"> The zones for the NGroup. </param>
        /// <param name="elasticProfile"> The elastic profile. </param>
        /// <param name="placementFaultDomainCount"> The number of fault domains. </param>
        /// <param name="containerGroupProfiles"> The Container Group Profiles. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="updateProfile"> The update profile. </param>
        /// <returns> A new <see cref="Models.NGroupPatch"/> instance for mocking. </returns>
        public static NGroupPatch NGroupPatch(SystemData systemData = null, ManagedServiceIdentity identity = null, IDictionary<string, string> tags = null, IEnumerable<string> zones = null, ContainerGroupElasticProfile elasticProfile = null, int? placementFaultDomainCount = default(int?), IEnumerable<ContainerGroupProfileStub> containerGroupProfiles = null, NGroupProvisioningState? provisioningState = default(NGroupProvisioningState?), NGroupUpdateProfile updateProfile = null)
        {
            throw null;
        }
    }
}
