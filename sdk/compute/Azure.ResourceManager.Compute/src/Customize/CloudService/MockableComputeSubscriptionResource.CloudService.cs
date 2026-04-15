// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Mocking
{
    public partial class MockableComputeSubscriptionResource : ArmResource
    {
        private const string CloudServiceNotSupported = "CloudService operations are no longer supported.";

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual CloudServiceOSFamilyCollection GetCloudServiceOSFamilies(AzureLocation location)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual Response<CloudServiceOSFamilyResource> GetCloudServiceOSFamily(AzureLocation location, string osFamilyName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual Task<Response<CloudServiceOSFamilyResource>> GetCloudServiceOSFamilyAsync(AzureLocation location, string osFamilyName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual CloudServiceOSVersionCollection GetCloudServiceOSVersions(AzureLocation location)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual Response<CloudServiceOSVersionResource> GetCloudServiceOSVersion(AzureLocation location, string osVersionName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual Task<Response<CloudServiceOSVersionResource>> GetCloudServiceOSVersionAsync(AzureLocation location, string osVersionName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual Pageable<CloudServiceResource> GetCloudServices(CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual AsyncPageable<CloudServiceResource> GetCloudServicesAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);
    }
}
