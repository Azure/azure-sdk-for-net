// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityCenterLocationResource
    {
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation ascLocation) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityCenterLocationResource
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesByRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterAllowedConnection> GetAllowedConnectionsByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecuritySolutionsReferenceData> GetAllSecuritySolutionsReferenceDataByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource> GetTopologiesByHomeRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityCenterLocationResource
    {
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroup(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAdaptiveApplicationControlGroupAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupCollection GetAdaptiveApplicationControlGroups() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
