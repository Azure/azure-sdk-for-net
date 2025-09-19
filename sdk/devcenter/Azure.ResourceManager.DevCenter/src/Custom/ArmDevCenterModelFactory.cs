// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DevCenter.Models
{
    public static partial class ArmDevCenterModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="DevCenter.DevCenterProjectEnvironmentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> Managed identity properties. </param>
        /// <param name="deploymentTargetId"> Id of a subscription that the environment type will be mapped to. The environment's resources will be deployed into this subscription. </param>
        /// <param name="status"> Defines whether this Environment Type can be used in this Project. </param>
        /// <param name="roles"> The role definition assigned to the environment creator on backing resources. </param>
        /// <param name="userRoleAssignments"> Role Assignments created on environment backing resources. This is a mapping from a user object ID to an object of role definition IDs. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        /// <returns> A new <see cref="DevCenter.DevCenterProjectEnvironmentData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DevCenterProjectEnvironmentData DevCenterProjectEnvironmentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity = null, ResourceIdentifier deploymentTargetId = null, EnvironmentTypeEnableStatus? status = null, IDictionary<string, DevCenterEnvironmentRole> roles = null, IDictionary<string, DevCenterUserRoleAssignments> userRoleAssignments = null, DevCenterProvisioningState? provisioningState = null)
        {
            return DevCenterProjectEnvironmentData(id, name, resourceType, systemData, tags, location, identity, deploymentTargetId, default, status, roles, userRoleAssignments, provisioningState, default);
        }

        /// <summary> Initializes a new instance of <see cref="DevCenter.AllowedEnvironmentTypeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        /// <returns> A new <see cref="DevCenter.AllowedEnvironmentTypeData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AllowedEnvironmentTypeData AllowedEnvironmentTypeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DevCenterProvisioningState? provisioningState)
        {
            return AllowedEnvironmentTypeData(id, name, resourceType, systemData, provisioningState, default);
        }

        /// <summary> Initializes a new instance of <see cref="DevCenter.DevBoxDefinitionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="imageReference"> Image reference information. </param>
        /// <param name="sku"> The SKU for Dev Boxes created using this definition. </param>
        /// <param name="osStorageType"> The storage type used for the Operating System disk of Dev Boxes created using this definition. </param>
        /// <param name="hibernateSupport"> Indicates whether Dev Boxes created with this definition are capable of hibernation. Not all images are capable of supporting hibernation. To find out more see https://aka.ms/devbox/hibernate. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        /// <param name="imageValidationStatus"> Validation status of the configured image. </param>
        /// <param name="imageValidationErrorDetails"> Details for image validator error. Populated when the image validation is not successful. </param>
        /// <param name="activeImageReference"> Image reference information for the currently active image (only populated during updates). </param>
        /// <returns> A new <see cref="DevCenter.DevBoxDefinitionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DevBoxDefinitionData DevBoxDefinitionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, DevCenterImageReference imageReference = null, DevCenterSku sku = null, string osStorageType = null, DevCenterHibernateSupport? hibernateSupport = null, DevCenterProvisioningState? provisioningState = null, ImageValidationStatus? imageValidationStatus = null, ImageValidationErrorDetails imageValidationErrorDetails = null, DevCenterImageReference activeImageReference = null)
        {
            return DevBoxDefinitionData(id, name, resourceType, systemData, tags, location, imageReference, sku, osStorageType, hibernateSupport, provisioningState, imageValidationStatus, imageValidationErrorDetails, default, activeImageReference);
        }

        /// <summary> Initializes a new instance of <see cref="DevCenter.DevCenterCatalogData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="gitHub"> Properties for a GitHub catalog type. </param>
        /// <param name="adoGit"> Properties for an Azure DevOps catalog type. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        /// <param name="syncState"> The synchronization state of the catalog. </param>
        /// <param name="lastSyncOn"> When the catalog was last synced. </param>
        /// <returns> A new <see cref="DevCenter.DevCenterCatalogData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DevCenterCatalogData DevCenterCatalogData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DevCenterGitCatalog gitHub, DevCenterGitCatalog adoGit, DevCenterProvisioningState? provisioningState, DevCenterCatalogSyncState? syncState, DateTimeOffset? lastSyncOn)
        {
            return DevCenterCatalogData(id, name, resourceType, systemData, gitHub, adoGit, syncType: default, tags: default, provisioningState, syncState, lastSyncStats: default, connectionState: default, lastConnectionOn: default, lastSyncOn);
        }

        /// <summary> Initializes a new instance of <see cref="DevCenter.DevCenterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> Managed identity properties. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        /// <param name="devCenterUri"> The URI of the Dev Center. </param>
        /// <returns> A new <see cref="DevCenter.DevCenterData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DevCenterData DevCenterData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity = null, DevCenterProvisioningState? provisioningState = null, Uri devCenterUri = null)
        {
            return DevCenterData(id, name, resourceType, systemData, tags, location, identity, customerManagedKeyEncryption: default, displayName: default, catalogItemSyncEnableStatus: default, microsoftHostedNetworkEnableStatus: default, devBoxProvisioningInstallAzureMonitorAgentEnableStatus: default, provisioningState, devCenterUri);
        }

        /// <summary> Initializes a new instance of <see cref="DevCenter.DevCenterEnvironmentTypeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        /// <returns> A new <see cref="DevCenter.DevCenterEnvironmentTypeData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DevCenterEnvironmentTypeData DevCenterEnvironmentTypeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, DevCenterProvisioningState? provisioningState)
        {
            return DevCenterEnvironmentTypeData(id, name, resourceType, systemData, tags, displayName: default, provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DevCenterOperationStatus"/>. </summary>
        /// <param name="id"> Fully qualified ID for the async operation. </param>
        /// <param name="name"> Name of the async operation. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentComplete"> Percent of the operation that is complete. </param>
        /// <param name="startOn"> The start time of the operation. </param>
        /// <param name="endOn"> The end time of the operation. </param>
        /// <param name="operations"> The operations list. </param>
        /// <param name="error"> If present, details of the operation error. </param>
        /// <param name="resourceId"> The id of the resource. </param>
        /// <param name="properties"> Custom operation properties, populated only for a successful operation. </param>
        /// <returns> A new <see cref="Models.DevCenterOperationStatus"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DevCenterOperationStatus DevCenterOperationStatus(ResourceIdentifier id, string name, string status, float? percentComplete = null, DateTimeOffset? startOn = null, DateTimeOffset? endOn = null, IEnumerable<OperationStatusResult> operations = null, ResponseError error = null, ResourceIdentifier resourceId = null, BinaryData properties = null)
        {
            return DevCenterOperationStatus(id, name, status, percentComplete, startOn, endOn, operations, error, properties, resourceId);
        }

        /// <summary> Initializes a new instance of <see cref="DevCenter.DevCenterPoolData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="devBoxDefinitionName"> Name of a Dev Box definition in parent Project of this Pool. </param>
        /// <param name="networkConnectionName"> Name of a Network Connection in parent Project of this Pool. </param>
        /// <param name="licenseType"> Specifies the license type indicating the caller has already acquired licenses for the Dev Boxes that will be created. </param>
        /// <param name="localAdministrator"> Indicates whether owners of Dev Boxes in this pool are added as local administrators on the Dev Box. </param>
        /// <param name="stopOnDisconnect"> Stop on disconnect configuration settings for Dev Boxes created in this pool. </param>
        /// <param name="healthStatus"> Overall health status of the Pool. Indicates whether or not the Pool is available to create Dev Boxes. </param>
        /// <param name="healthStatusDetails"> Details on the Pool health status to help diagnose issues. This is only populated when the pool status indicates the pool is in a non-healthy state. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        /// <returns> A new <see cref="DevCenter.DevCenterPoolData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DevCenterPoolData DevCenterPoolData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string devBoxDefinitionName = null, string networkConnectionName = null, DevCenterLicenseType? licenseType = null, LocalAdminStatus? localAdministrator = null, StopOnDisconnectConfiguration stopOnDisconnect = null, DevCenterHealthStatus? healthStatus = null, IEnumerable<DevCenterHealthStatusDetail> healthStatusDetails = null, DevCenterProvisioningState? provisioningState = null)
        {
            return DevCenterPoolData(id, name, resourceType, systemData, tags, location, devBoxDefinitionType: default, devBoxDefinitionName, devBoxDefinition: default, networkConnectionName, licenseType, localAdministrator, stopOnDisconnect, stopOnNoConnect: default, singleSignOnStatus: default, displayName: default, virtualNetworkType: default, managedVirtualNetworkRegions: default, activeHoursConfiguration: default, devBoxTunnelEnableStatus: default, healthStatus, healthStatusDetails, devBoxCount: default, provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="DevCenter.DevCenterProjectData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="devCenterId"> Resource Id of an associated DevCenter. </param>
        /// <param name="description"> Description of the project. </param>
        /// <param name="maxDevBoxesPerUser"> When specified, limits the maximum number of Dev Boxes a single user can create across all pools in the project. This will have no effect on existing Dev Boxes when reduced. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        /// <param name="devCenterUri"> The URI of the Dev Center resource this project is associated with. </param>
        /// <returns> A new <see cref="DevCenter.DevCenterProjectData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DevCenterProjectData DevCenterProjectData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ResourceIdentifier devCenterId = null, string description = null, int? maxDevBoxesPerUser = null, DevCenterProvisioningState? provisioningState = null, Uri devCenterUri = null)
        {
            return DevCenterProjectData(id, name, resourceType, systemData, tags, location, identity: default, devCenterId, description, maxDevBoxesPerUser, displayName: default, catalogItemSyncTypes: default, customizationSettings: default, devBoxAutoDeleteSettings: default, azureAiServicesMode: default, serverlessGpuSessionsSettings: default, workspaceStorageMode: default, provisioningState, devCenterUri);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DevCenterUsage"/>. </summary>
        /// <param name="currentValue"> The current usage. </param>
        /// <param name="limit"> The limit integer. </param>
        /// <param name="unit"> The unit details. </param>
        /// <param name="name"> The name. </param>
        /// <returns> A new <see cref="Models.DevCenterUsage"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DevCenterUsage DevCenterUsage(long? currentValue, long? limit, DevCenterUsageUnit? unit, DevCenterUsageName name)
        {
            return DevCenterUsage(currentValue, limit, unit, name, id: default);
        }
    }
}
