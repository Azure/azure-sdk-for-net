// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using static Azure.Core.Pipeline.TaskExtensions;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmBatchModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Batch.BatchAccountPoolData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="identity"> The type of identity used for the Batch Pool. Current supported identity types: UserAssigned, None. </param>
        /// <param name="displayName"> The display name need not be unique and can contain any Unicode characters up to a maximum length of 1024. </param>
        /// <param name="lastModifiedOn"> This is the last time at which the pool level data, such as the targetDedicatedNodes or autoScaleSettings, changed. It does not factor in node-level changes such as a compute node changing state. </param>
        /// <param name="createdOn"> The creation time of the pool. </param>
        /// <param name="provisioningState"> The current state of the pool. </param>
        /// <param name="provisioningStateTransitOn"> The time at which the pool entered its current state. </param>
        /// <param name="allocationState"> Whether the pool is resizing. </param>
        /// <param name="allocationStateTransitionOn"> The time at which the pool entered its current allocation state. </param>
        /// <param name="vmSize"> For information about available sizes of virtual machines for Cloud Services pools (pools created with cloudServiceConfiguration), see Sizes for Cloud Services (https://azure.microsoft.com/documentation/articles/cloud-services-sizes-specs/). Batch supports all Cloud Services VM sizes except ExtraSmall. For information about available VM sizes for pools using images from the Virtual Machines Marketplace (pools created with virtualMachineConfiguration) see Sizes for Virtual Machines (Linux) (https://azure.microsoft.com/documentation/articles/virtual-machines-linux-sizes/) or Sizes for Virtual Machines (Windows) (https://azure.microsoft.com/documentation/articles/virtual-machines-windows-sizes/). Batch supports all Azure VM sizes except STANDARD_A0 and those with premium storage (STANDARD_GS, STANDARD_DS, and STANDARD_DSV2 series). </param>
        /// <param name="deploymentConfiguration"> Deployment configuration properties. </param>
        /// <param name="currentDedicatedNodes"> The number of dedicated compute nodes currently in the pool. </param>
        /// <param name="currentLowPriorityNodes"> The number of Spot/low-priority compute nodes currently in the pool. </param>
        /// <param name="scaleSettings"> Defines the desired size of the pool. This can either be 'fixedScale' where the requested targetDedicatedNodes is specified, or 'autoScale' which defines a formula which is periodically reevaluated. If this property is not specified, the pool will have a fixed scale with 0 targetDedicatedNodes. </param>
        /// <param name="autoScaleRun"> This property is set only if the pool automatically scales, i.e. autoScaleSettings are used. </param>
        /// <param name="interNodeCommunication"> This imposes restrictions on which nodes can be assigned to the pool. Enabling this value can reduce the chance of the requested number of nodes to be allocated in the pool. If not specified, this value defaults to 'Disabled'. </param>
        /// <param name="networkConfiguration"> The network configuration for a pool. </param>
        /// <param name="taskSlotsPerNode"> The default value is 1. The maximum value is the smaller of 4 times the number of cores of the vmSize of the pool or 256. </param>
        /// <param name="taskSchedulingNodeFillType"> If not specified, the default is spread. </param>
        /// <param name="userAccounts"> The list of user accounts to be created on each node in the pool. </param>
        /// <param name="metadata"> The Batch service does not assign any meaning to metadata; it is solely for the use of user code. </param>
        /// <param name="startTask"> In an PATCH (update) operation, this property can be set to an empty object to remove the start task from the pool. </param>
        /// <param name="certificates">
        /// For Windows compute nodes, the Batch service installs the certificates to the specified certificate store and location. For Linux compute nodes, the certificates are stored in a directory inside the task working directory and an environment variable AZ_BATCH_CERTIFICATES_DIR is supplied to the task to query for this location. For certificates with visibility of 'remoteUser', a 'certs' directory is created in the user's home directory (e.g., /home/{user-name}/certs) and certificates are placed in that directory.
        ///
        /// Warning: This property is deprecated and will be removed after February, 2024. Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.
        /// </param>
        /// <param name="applicationPackages"> Changes to application package references affect all new compute nodes joining the pool, but do not affect compute nodes that are already in the pool until they are rebooted or reimaged. There is a maximum of 10 application package references on any given pool. </param>
        /// <param name="applicationLicenses"> The list of application licenses must be a subset of available Batch service application licenses. If a license is requested which is not supported, pool creation will fail. </param>
        /// <param name="resizeOperationStatus"> Describes either the current operation (if the pool AllocationState is Resizing) or the previously completed operation (if the AllocationState is Steady). </param>
        /// <param name="mountConfiguration"> This supports Azure Files, NFS, CIFS/SMB, and Blobfuse. </param>
        /// <param name="targetNodeCommunicationMode"> If omitted, the default value is Default. </param>
        /// <param name="currentNodeCommunicationMode"> Determines how a pool communicates with the Batch service. </param>
        /// <param name="etag"> The ETag of the resource, used for concurrency statements. </param>
        /// <returns> A new <see cref="Batch.BatchAccountPoolData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchAccountPoolData BatchAccountPoolData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ManagedServiceIdentity identity, string displayName, DateTimeOffset? lastModifiedOn, DateTimeOffset? createdOn, BatchAccountPoolProvisioningState? provisioningState, DateTimeOffset? provisioningStateTransitOn, BatchAccountPoolAllocationState? allocationState, DateTimeOffset? allocationStateTransitionOn, string vmSize, BatchDeploymentConfiguration deploymentConfiguration, int? currentDedicatedNodes, int? currentLowPriorityNodes, BatchAccountPoolScaleSettings scaleSettings, BatchAccountPoolAutoScaleRun autoScaleRun, InterNodeCommunicationState? interNodeCommunication, BatchNetworkConfiguration networkConfiguration, int? taskSlotsPerNode, BatchNodeFillType? taskSchedulingNodeFillType, IEnumerable<BatchUserAccount> userAccounts, IEnumerable<BatchAccountPoolMetadataItem> metadata, BatchAccountPoolStartTask startTask, IEnumerable<BatchCertificateReference> certificates, IEnumerable<BatchApplicationPackageReference> applicationPackages, IEnumerable<string> applicationLicenses, BatchResizeOperationStatus resizeOperationStatus, IEnumerable<BatchMountConfiguration> mountConfiguration, NodeCommunicationMode? targetNodeCommunicationMode, NodeCommunicationMode? currentNodeCommunicationMode, ETag? etag)
        {
            BatchVmConfiguration deploymentVmConfiguration = deploymentConfiguration == null ? null : deploymentConfiguration.VmConfiguration;
            return BatchAccountPoolData(id, name, resourceType, systemData, identity, etag, default, displayName, lastModifiedOn, createdOn, provisioningState, provisioningStateTransitOn, allocationState, allocationStateTransitionOn, vmSize, deploymentVmConfiguration, currentDedicatedNodes, currentLowPriorityNodes, scaleSettings, autoScaleRun, interNodeCommunication, networkConfiguration, taskSlotsPerNode, taskSchedulingNodeFillType, userAccounts, metadata, startTask, certificates, applicationPackages, applicationLicenses, resizeOperationStatus, mountConfiguration, targetNodeCommunicationMode, currentNodeCommunicationMode, default, default);
        }

        /// <summary> Initializes a new instance of <see cref="Batch.BatchAccountCertificateData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="thumbprintAlgorithm"> This must match the first portion of the certificate name. Currently required to be 'SHA1'. </param>
        /// <param name="thumbprintString"> This must match the thumbprint from the name. </param>
        /// <param name="format"> The format of the certificate - either Pfx or Cer. If omitted, the default is Pfx. </param>
        /// <param name="provisioningState"></param>
        /// <param name="provisioningStateTransitOn"> The time at which the certificate entered its current state. </param>
        /// <param name="previousProvisioningState"> The previous provisioned state of the resource. </param>
        /// <param name="previousProvisioningStateTransitOn"> The time at which the certificate entered its previous state. </param>
        /// <param name="publicData"> The public key of the certificate. </param>
        /// <param name="deleteCertificateError"> This is only returned when the certificate provisioningState is 'Failed'. </param>
        /// <param name="etag"> The ETag of the resource, used for concurrency statements. </param>
        /// <param name="tags"> The tags of the resource. </param>
        /// <returns> A new <see cref="Batch.BatchAccountCertificateData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchAccountCertificateData BatchAccountCertificateData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string thumbprintAlgorithm, string thumbprintString = null, BatchAccountCertificateFormat? format = null, BatchAccountCertificateProvisioningState? provisioningState = null, DateTimeOffset? provisioningStateTransitOn = null, BatchAccountCertificateProvisioningState? previousProvisioningState = null, DateTimeOffset? previousProvisioningStateTransitOn = null, string publicData = null, ResponseError deleteCertificateError = null, ETag? etag = null, IDictionary<string, string> tags = null)
            => BatchAccountCertificateData(id, name, resourceType, systemData, etag, tags, thumbprintAlgorithm, thumbprintString, format, provisioningState, provisioningStateTransitOn, previousProvisioningState, previousProvisioningStateTransitOn, publicData, deleteCertificateError);

        /// <summary> Initializes a new instance of <see cref="Batch.BatchAccountDetectorData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="value"> A base64 encoded string that represents the content of a detector. </param>
        /// <param name="etag"> The ETag of the resource, used for concurrency statements. </param>
        /// <param name="tags"> The tags of the resource. </param>
        /// <returns> A new <see cref="Batch.BatchAccountDetectorData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchAccountDetectorData BatchAccountDetectorData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string value, ETag? etag = null, IDictionary<string, string> tags = null)
            => BatchAccountDetectorData(id, name, resourceType, systemData, etag, tags, value);

        /// <summary> Initializes a new instance of <see cref="Batch.BatchAccountPoolData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="identity"> The type of identity used for the Batch Pool. Current supported identity types: UserAssigned, None. </param>
        /// <param name="displayName"> The display name need not be unique and can contain any Unicode characters up to a maximum length of 1024. </param>
        /// <param name="lastModifiedOn"> This is the last time at which the pool level data, such as the targetDedicatedNodes or autoScaleSettings, changed. It does not factor in node-level changes such as a compute node changing state. </param>
        /// <param name="createdOn"> The creation time of the pool. </param>
        /// <param name="provisioningState"> The current state of the pool. </param>
        /// <param name="provisioningStateTransitOn"> The time at which the pool entered its current state. </param>
        /// <param name="allocationState"> Whether the pool is resizing. </param>
        /// <param name="allocationStateTransitionOn"> The time at which the pool entered its current allocation state. </param>
        /// <param name="vmSize"> For information about available VM sizes, see Sizes for Virtual Machines (Linux) (https://azure.microsoft.com/documentation/articles/virtual-machines-linux-sizes/) or Sizes for Virtual Machines (Windows) (https://azure.microsoft.com/documentation/articles/virtual-machines-windows-sizes/). Batch supports all Azure VM sizes except STANDARD_A0 and those with premium storage (STANDARD_GS, STANDARD_DS, and STANDARD_DSV2 series). </param>
        /// <param name="deploymentVmConfiguration"> Deployment configuration properties. </param>
        /// <param name="currentDedicatedNodes"> The number of dedicated compute nodes currently in the pool. </param>
        /// <param name="currentLowPriorityNodes"> The number of Spot/low-priority compute nodes currently in the pool. </param>
        /// <param name="scaleSettings"> Defines the desired size of the pool. This can either be 'fixedScale' where the requested targetDedicatedNodes is specified, or 'autoScale' which defines a formula which is periodically reevaluated. If this property is not specified, the pool will have a fixed scale with 0 targetDedicatedNodes. </param>
        /// <param name="autoScaleRun"> This property is set only if the pool automatically scales, i.e. autoScaleSettings are used. </param>
        /// <param name="interNodeCommunication"> This imposes restrictions on which nodes can be assigned to the pool. Enabling this value can reduce the chance of the requested number of nodes to be allocated in the pool. If not specified, this value defaults to 'Disabled'. </param>
        /// <param name="networkConfiguration"> The network configuration for a pool. </param>
        /// <param name="taskSlotsPerNode"> The default value is 1. The maximum value is the smaller of 4 times the number of cores of the vmSize of the pool or 256. </param>
        /// <param name="taskSchedulingNodeFillType"> If not specified, the default is spread. </param>
        /// <param name="userAccounts"> The list of user accounts to be created on each node in the pool. </param>
        /// <param name="metadata"> The Batch service does not assign any meaning to metadata; it is solely for the use of user code. </param>
        /// <param name="startTask"> In an PATCH (update) operation, this property can be set to an empty object to remove the start task from the pool. </param>
        /// <param name="certificates">
        /// For Windows compute nodes, the Batch service installs the certificates to the specified certificate store and location. For Linux compute nodes, the certificates are stored in a directory inside the task working directory and an environment variable AZ_BATCH_CERTIFICATES_DIR is supplied to the task to query for this location. For certificates with visibility of 'remoteUser', a 'certs' directory is created in the user's home directory (e.g., /home/{user-name}/certs) and certificates are placed in that directory.
        ///
        /// Warning: This property is deprecated and will be removed after February, 2024. Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.
        /// </param>
        /// <param name="applicationPackages"> Changes to application package references affect all new compute nodes joining the pool, but do not affect compute nodes that are already in the pool until they are rebooted or reimaged. There is a maximum of 10 application package references on any given pool. </param>
        /// <param name="applicationLicenses"> The list of application licenses must be a subset of available Batch service application licenses. If a license is requested which is not supported, pool creation will fail. </param>
        /// <param name="resizeOperationStatus"> Describes either the current operation (if the pool AllocationState is Resizing) or the previously completed operation (if the AllocationState is Steady). </param>
        /// <param name="mountConfiguration"> This supports Azure Files, NFS, CIFS/SMB, and Blobfuse. </param>
        /// <param name="targetNodeCommunicationMode"> If omitted, the default value is Default. </param>
        /// <param name="currentNodeCommunicationMode"> Determines how a pool communicates with the Batch service. </param>
        /// <param name="upgradePolicy"> Describes an upgrade policy - automatic, manual, or rolling. </param>
        /// <param name="resourceTags"> The user-defined tags to be associated with the Azure Batch Pool. When specified, these tags are propagated to the backing Azure resources associated with the pool. This property can only be specified when the Batch account was created with the poolAllocationMode property set to 'UserSubscription'. </param>
        /// <param name="etag"> The ETag of the resource, used for concurrency statements. </param>
        /// <param name="tags"> The tags of the resource. </param>
        /// <returns> A new <see cref="Batch.BatchAccountPoolData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchAccountPoolData BatchAccountPoolData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ManagedServiceIdentity identity, string displayName, DateTimeOffset? lastModifiedOn = null, DateTimeOffset? createdOn = null, BatchAccountPoolProvisioningState? provisioningState = null, DateTimeOffset? provisioningStateTransitOn = null, BatchAccountPoolAllocationState? allocationState = null, DateTimeOffset? allocationStateTransitionOn = null, string vmSize = null, BatchVmConfiguration deploymentVmConfiguration = null, int? currentDedicatedNodes = null, int? currentLowPriorityNodes = null, BatchAccountPoolScaleSettings scaleSettings = null, BatchAccountPoolAutoScaleRun autoScaleRun = null, InterNodeCommunicationState? interNodeCommunication = null, BatchNetworkConfiguration networkConfiguration = null, int? taskSlotsPerNode = null, BatchNodeFillType? taskSchedulingNodeFillType = null, IEnumerable<BatchUserAccount> userAccounts = null, IEnumerable<BatchAccountPoolMetadataItem> metadata = null, BatchAccountPoolStartTask startTask = null, IEnumerable<BatchCertificateReference> certificates = null, IEnumerable<BatchApplicationPackageReference> applicationPackages = null, IEnumerable<string> applicationLicenses = null, BatchResizeOperationStatus resizeOperationStatus = null, IEnumerable<BatchMountConfiguration> mountConfiguration = null, NodeCommunicationMode? targetNodeCommunicationMode = null, NodeCommunicationMode? currentNodeCommunicationMode = null, UpgradePolicy upgradePolicy = null, IDictionary<string, string> resourceTags = null, ETag? etag = null, IDictionary<string, string> tags = null)
            => BatchAccountPoolData(id, name, resourceType, systemData, identity, etag, tags, displayName, lastModifiedOn, createdOn, provisioningState, provisioningStateTransitOn, allocationState, allocationStateTransitionOn, vmSize, deploymentVmConfiguration, currentDedicatedNodes, currentLowPriorityNodes, scaleSettings, autoScaleRun, interNodeCommunication, networkConfiguration, taskSlotsPerNode, taskSchedulingNodeFillType, userAccounts, metadata, startTask, certificates, applicationPackages, applicationLicenses, resizeOperationStatus, mountConfiguration, targetNodeCommunicationMode, currentNodeCommunicationMode, upgradePolicy, resourceTags);

        /// <summary> Initializes a new instance of <see cref="Batch.BatchApplicationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="displayName"> The display name for the application. </param>
        /// <param name="allowUpdates"> A value indicating whether packages within the application may be overwritten using the same version string. </param>
        /// <param name="defaultVersion"> The package to use if a client requests the application but does not specify a version. This property can only be set to the name of an existing package. </param>
        /// <param name="etag"> The ETag of the resource, used for concurrency statements. </param>
        /// <param name="tags"> The tags of the resource. </param>
        /// <returns> A new <see cref="Batch.BatchApplicationData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchApplicationData BatchApplicationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string displayName, bool? allowUpdates = null, string defaultVersion = null, ETag? etag = null, IDictionary<string, string> tags = null)
            => BatchApplicationData(id, name, resourceType, systemData, etag, tags, displayName, allowUpdates, defaultVersion);

        /// <summary> Initializes a new instance of <see cref="Batch.BatchApplicationPackageData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="state"> The current state of the application package. </param>
        /// <param name="format"> The format of the application package, if the package is active. </param>
        /// <param name="storageUri"> The URL for the application package in Azure Storage. </param>
        /// <param name="storageUriExpireOn"> The UTC time at which the Azure Storage URL will expire. </param>
        /// <param name="lastActivatedOn"> The time at which the package was last activated, if the package is active. </param>
        /// <param name="etag"> The ETag of the resource, used for concurrency statements. </param>
        /// <param name="tags"> The tags of the resource. </param>
        /// <returns> A new <see cref="Batch.BatchApplicationPackageData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchApplicationPackageData BatchApplicationPackageData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, BatchApplicationPackageState? state, string format = null, Uri storageUri = null, DateTimeOffset? storageUriExpireOn = null, DateTimeOffset? lastActivatedOn = null, ETag? etag = null, IDictionary<string, string> tags = null)
            => BatchApplicationPackageData(id, name, resourceType, systemData, etag, tags, state, format, storageUri, storageUriExpireOn, lastActivatedOn);

        /// <summary> Initializes a new instance of <see cref="Batch.BatchPrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> The provisioning state of the private endpoint connection. </param>
        /// <param name="privateEndpointId"> The private endpoint of the private endpoint connection. </param>
        /// <param name="groupIds"> The value has one and only one group id. </param>
        /// <param name="connectionState"> The private link service connection state of the private endpoint connection. </param>
        /// <param name="etag"> The ETag of the resource, used for concurrency statements. </param>
        /// <param name="tags"> The tags of the resource. </param>
        /// <returns> A new <see cref="Batch.BatchPrivateEndpointConnectionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchPrivateEndpointConnectionData BatchPrivateEndpointConnectionData(ResourceIdentifier id , string name, ResourceType resourceType, SystemData systemData, BatchPrivateEndpointConnectionProvisioningState? provisioningState, ResourceIdentifier privateEndpointId = null, IEnumerable<string> groupIds = null, BatchPrivateLinkServiceConnectionState connectionState = null, ETag? etag = null, IDictionary<string, string> tags = null)
            => BatchPrivateEndpointConnectionData(id, name, resourceType, systemData, etag, tags, provisioningState, privateEndpointId, groupIds, connectionState);

        /// <summary> Initializes a new instance of <see cref="Batch.BatchPrivateLinkResourceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="groupId"> The group id is used to establish the private link connection. </param>
        /// <param name="requiredMembers"> The list of required members that are used to establish the private link connection. </param>
        /// <param name="requiredZoneNames"> The list of required zone names for the private DNS resource name. </param>
        /// <param name="etag"> The ETag of the resource, used for concurrency statements. </param>
        /// <param name="tags"> The tags of the resource. </param>
        /// <returns> A new <see cref="Batch.BatchPrivateLinkResourceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchPrivateLinkResourceData BatchPrivateLinkResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string groupId, IEnumerable<string> requiredMembers = null, IEnumerable<string> requiredZoneNames = null, ETag? etag = null, IDictionary<string, string> tags = null)
            => BatchPrivateLinkResourceData(id, name, resourceType, systemData, etag, tags, groupId, requiredMembers, requiredZoneNames);

        /// <summary> Initializes a new instance of <see cref="Models.BatchResourceAssociation"/>. </summary>
        /// <param name="name"> Name of the resource association. </param>
        /// <param name="accessMode"> Access mode of the resource association. </param>
        /// <returns> A new <see cref="Models.BatchResourceAssociation"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchResourceAssociation BatchResourceAssociation(string name = null, ResourceAssociationAccessMode? accessMode = null)
        {
            return new BatchResourceAssociation(name, accessMode, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetworkSecurityPerimeter"/>. </summary>
        /// <param name="id"> Fully qualified Azure resource ID of the NSP resource. </param>
        /// <param name="perimeterGuid"> Universal unique ID (UUID) of the network security perimeter. </param>
        /// <param name="location"> Location of the network security perimeter. </param>
        /// <returns> A new <see cref="Models.NetworkSecurityPerimeter"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkSecurityPerimeter NetworkSecurityPerimeter(ResourceIdentifier id = null, Guid? perimeterGuid = null, AzureLocation? location = null)
        {
            return new NetworkSecurityPerimeter(id, perimeterGuid, location, serializedAdditionalRawData: null);
        }
    }
}
