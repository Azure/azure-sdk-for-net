// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    // ---------------------------------------------------------------------
    // Hand-authored back-compat ModelFactory shims for the deprecated
    // CloudService API surface. CloudService (classic) was removed from the
    // TypeSpec spec, so the generator does not emit factory methods for these
    // types. The types themselves are kept under src/Customize/CloudService/
    // as obsolete stubs that throw NotSupportedException for any runtime
    // operation; these factory methods follow the same pattern to preserve
    // API surface for back-compat without implying the operations still work.
    // ---------------------------------------------------------------------
    public static partial class ArmComputeModelFactory
    {
        private const string CloudServiceNotSupported = "CloudService operations are no longer supported.";

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceData CloudServiceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, IEnumerable<string> zones = null, Uri packageUri = null, string configuration = null, Uri configurationUri = null, bool? startCloudService = default, bool? allowModelOverride = default, CloudServiceUpgradeMode? upgradeMode = default, IEnumerable<CloudServiceRoleProfileProperties> roles = null, IEnumerable<CloudServiceVaultSecretGroup> osSecrets = null, CloudServiceNetworkProfile networkProfile = null, IEnumerable<CloudServiceExtension> extensions = null, string provisioningState = null, string uniqueId = null)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceOSFamilyData CloudServiceOSFamilyData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string resourceName = null, AzureLocation? location = default, string osFamilyName = null, string label = null, IEnumerable<OSVersionPropertiesBase> versions = null)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceOSVersionData CloudServiceOSVersionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, AzureLocation? location = default, string family = null, string familyLabel = null, string version = null, string label = null, bool? isDefault = default, bool? isActive = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceRoleData CloudServiceRoleData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, AzureLocation? location = default, CloudServiceRoleSku sku = null, string uniqueId = null)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceRoleInstanceData CloudServiceRoleInstanceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, AzureLocation? location = default, IReadOnlyDictionary<string, string> tags = null, InstanceSku sku = null, IEnumerable<WritableSubResource> networkInterfaces = null, RoleInstanceView instanceView = null)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceExtension CloudServiceExtension(string name = null, string publisher = null, string cloudServiceExtensionPropertiesType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default, BinaryData settings = null, BinaryData protectedSettings = null, CloudServiceVaultAndSecretReference protectedSettingsFromKeyVault = null, string forceUpdateTag = null, string provisioningState = null, IEnumerable<string> rolesAppliedTo = null)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceInstanceView CloudServiceInstanceView(IEnumerable<StatusCodeCount> roleInstanceStatusesSummary = null, string sdkVersion = null, IEnumerable<string> privateIds = null, IEnumerable<ResourceInstanceViewStatus> statuses = null)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static InstanceSku InstanceSku(string name = null, string tier = null)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static OSVersionPropertiesBase OSVersionPropertiesBase(string version = null, string label = null, bool? isDefault = default, bool? isActive = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static ResourceInstanceViewStatus ResourceInstanceViewStatus(string code = null, string displayStatus = null, string message = null, DateTimeOffset? time = default, ComputeStatusLevelType? level = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static RoleInstanceView RoleInstanceView(int? platformUpdateDomain = default, int? platformFaultDomain = default, string privateId = null, IEnumerable<ResourceInstanceViewStatus> statuses = null)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static StatusCodeCount StatusCodeCount(string code = null, int? count = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static UpdateDomainIdentifier UpdateDomainIdentifier(ResourceIdentifier id = null, string name = null)
            => throw new NotSupportedException(CloudServiceNotSupported);
    }
}
