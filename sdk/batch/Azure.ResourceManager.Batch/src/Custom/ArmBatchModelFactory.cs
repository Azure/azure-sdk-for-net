// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // Type or member is obsolete

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

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
            // Call the new generated overload using taskSchedulingPolicy to disambiguate
            return BatchAccountPoolData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                identity: identity,
                displayName: displayName,
                lastModifiedOn: lastModifiedOn,
                createdOn: createdOn,
                provisioningState: provisioningState,
                provisioningStateTransitOn: provisioningStateTransitOn,
                allocationState: allocationState,
                allocationStateTransitionOn: allocationStateTransitionOn,
                vmSize: vmSize,
                deploymentVmConfiguration: deploymentVmConfiguration,
                currentDedicatedNodes: currentDedicatedNodes,
                currentLowPriorityNodes: currentLowPriorityNodes,
                scaleSettings: scaleSettings,
                autoScaleRun: autoScaleRun,
                interNodeCommunication: interNodeCommunication,
                networkConfiguration: networkConfiguration,
                taskSlotsPerNode: taskSlotsPerNode,
                taskSchedulingPolicy: null,
                userAccounts: userAccounts,
                metadata: metadata,
                startTask: startTask,
                applicationPackages: applicationPackages,
                resizeOperationStatus: resizeOperationStatus,
                mountConfiguration: mountConfiguration,
                etag: etag
            );
        }

        /// <summary> Initializes a new instance of <see cref="Batch.BatchAccountPoolData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchAccountPoolData BatchAccountPoolData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ManagedServiceIdentity identity = null, string displayName = null, DateTimeOffset? lastModifiedOn = default, DateTimeOffset? createdOn = default, BatchAccountPoolProvisioningState? provisioningState = default, DateTimeOffset? provisioningStateTransitOn = default, BatchAccountPoolAllocationState? allocationState = default, DateTimeOffset? allocationStateTransitionOn = default, string vmSize = null, BatchVmConfiguration deploymentVmConfiguration = null, int? currentDedicatedNodes = default, int? currentLowPriorityNodes = default, BatchAccountPoolScaleSettings scaleSettings = null, BatchAccountPoolAutoScaleRun autoScaleRun = null, InterNodeCommunicationState? interNodeCommunication = default, BatchNetworkConfiguration networkConfiguration = null, int? taskSlotsPerNode = default, BatchNodeFillType? taskSchedulingNodeFillType = default, IEnumerable<BatchUserAccount> userAccounts = null, IEnumerable<BatchAccountPoolMetadataItem> metadata = null, BatchAccountPoolStartTask startTask = null, IEnumerable<BatchCertificateReference> certificates = null, IEnumerable<BatchApplicationPackageReference> applicationPackages = null, IEnumerable<string> applicationLicenses = null, BatchResizeOperationStatus resizeOperationStatus = null, IEnumerable<BatchMountConfiguration> mountConfiguration = null, NodeCommunicationMode? targetNodeCommunicationMode = default, NodeCommunicationMode? currentNodeCommunicationMode = default, UpgradePolicy upgradePolicy = null, IDictionary<string, string> resourceTags = null, ETag? etag = default, IDictionary<string, string> tags = null)
        {
            // Call the new generated overload using taskSchedulingPolicy to disambiguate
            return BatchAccountPoolData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                identity: identity,
                etag: etag,
                tags: tags,
                displayName: displayName,
                lastModifiedOn: lastModifiedOn,
                createdOn: createdOn,
                provisioningState: provisioningState,
                provisioningStateTransitOn: provisioningStateTransitOn,
                allocationState: allocationState,
                allocationStateTransitionOn: allocationStateTransitionOn,
                vmSize: vmSize,
                deploymentVmConfiguration: deploymentVmConfiguration,
                currentDedicatedNodes: currentDedicatedNodes,
                currentLowPriorityNodes: currentLowPriorityNodes,
                scaleSettings: scaleSettings,
                autoScaleRun: autoScaleRun,
                interNodeCommunication: interNodeCommunication,
                networkConfiguration: networkConfiguration,
                taskSlotsPerNode: taskSlotsPerNode,
                taskSchedulingPolicy: null,
                userAccounts: userAccounts,
                metadata: metadata,
                startTask: startTask,
                applicationPackages: applicationPackages,
                resizeOperationStatus: resizeOperationStatus,
                mountConfiguration: mountConfiguration,
                upgradePolicy: upgradePolicy
            );
        }

        /// <summary> Initializes a new instance of <see cref="Batch.BatchAccountCertificateData"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchAccountCertificateData BatchAccountCertificateData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string thumbprintAlgorithm = null, string thumbprintString = null, BatchAccountCertificateFormat? format = default, BatchAccountCertificateProvisioningState? provisioningState = default, DateTimeOffset? provisioningStateTransitOn = default, BatchAccountCertificateProvisioningState? previousProvisioningState = default, DateTimeOffset? previousProvisioningStateTransitOn = default, string publicData = null, ResponseError deleteCertificateError = null, ETag? etag = default, IDictionary<string, string> tags = null)
        {
            return new BatchAccountCertificateData();
        }

        /// <summary> Initializes a new instance of <see cref="Models.BatchAccountCertificateCreateOrUpdateContent"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchAccountCertificateCreateOrUpdateContent BatchAccountCertificateCreateOrUpdateContent(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string thumbprintAlgorithm = null, string thumbprintString = null, BatchAccountCertificateFormat? format = default, BinaryData data = null, string password = null, ETag? etag = default, IDictionary<string, string> tags = null)
        {
            return new BatchAccountCertificateCreateOrUpdateContent();
        }

        /// <summary> Initializes a new instance of <see cref="Batch.BatchAccountDetectorData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchAccountDetectorData BatchAccountDetectorData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string value, ETag? etag, IDictionary<string, string> tags)
        {
            tags ??= new Dictionary<string, string>();
            return new BatchAccountDetectorData(id, name, resourceType, systemData, etag, tags, value, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Batch.BatchApplicationData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchApplicationData BatchApplicationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string displayName, bool? allowUpdates, string defaultVersion, ETag? etag, IDictionary<string, string> tags)
        {
            tags ??= new Dictionary<string, string>();
            return new BatchApplicationData(id, name, resourceType, systemData, etag, tags, displayName, allowUpdates, defaultVersion, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Batch.BatchApplicationPackageData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchApplicationPackageData BatchApplicationPackageData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, BatchApplicationPackageState? state, string format, Uri storageUri, DateTimeOffset? storageUriExpireOn, DateTimeOffset? lastActivatedOn, ETag? etag, IDictionary<string, string> tags)
        {
            tags ??= new Dictionary<string, string>();
            return new BatchApplicationPackageData(id, name, resourceType, systemData, etag, tags, state, format, storageUri, storageUriExpireOn, lastActivatedOn, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Batch.BatchPrivateEndpointConnectionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchPrivateEndpointConnectionData BatchPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, BatchPrivateEndpointConnectionProvisioningState? provisioningState, ResourceIdentifier privateEndpointId, IEnumerable<string> groupIds, BatchPrivateLinkServiceConnectionState connectionState, ETag? etag, IDictionary<string, string> tags)
        {
            tags ??= new Dictionary<string, string>();
            groupIds ??= new List<string>();
            return new BatchPrivateEndpointConnectionData(id, name, resourceType, systemData, etag, tags, provisioningState, privateEndpointId != null ? ResourceManagerModelFactory.SubResource(privateEndpointId) : null, groupIds?.ToList(), connectionState, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Batch.BatchPrivateLinkResourceData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchPrivateLinkResourceData BatchPrivateLinkResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string groupId, IEnumerable<string> requiredMembers, IEnumerable<string> requiredZoneNames, ETag? etag, IDictionary<string, string> tags)
        {
            tags ??= new Dictionary<string, string>();
            requiredMembers ??= new List<string>();
            requiredZoneNames ??= new List<string>();
            return new BatchPrivateLinkResourceData(id, name, resourceType, systemData, etag, tags, groupId, requiredMembers?.ToList(), requiredZoneNames?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.BatchResourceAssociation"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchResourceAssociation BatchResourceAssociation(string name, ResourceAssociationAccessMode? accessMode)
        {
            return new BatchResourceAssociation
            {
                Name = name,
                AccessMode = accessMode,
            };
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetworkSecurityPerimeter"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkSecurityPerimeter NetworkSecurityPerimeter(ResourceIdentifier id, Guid? perimeterGuid, AzureLocation? location)
        {
            return new NetworkSecurityPerimeter
            {
                Id = id,
                PerimeterGuid = perimeterGuid,
                Location = location,
            };
        }
    }
}
