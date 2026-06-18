// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    // The latest TypeSpec removed this legacy resource or operation path, so the generator cannot emit the previous GA management-plane method; keep a hidden shim for ApiCompat and throw because the service path is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the MockableSecurityCenterArmClient class.
    /// </summary>
    public partial class MockableSecurityCenterArmClient
    {
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveApplicationControlGroupResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource GetAdaptiveApplicationControlGroupResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAdaptiveNetworkHardeningResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource GetAdaptiveNetworkHardeningResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomAssessmentAutomationResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource GetCustomAssessmentAutomationResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the GetCustomEntityStoreAssignmentResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource GetCustomEntityStoreAssignmentResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityCloudConnectorResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource GetSecurityCloudConnectorResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSoftwareInventoryResource operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="id">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource GetSoftwareInventoryResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
