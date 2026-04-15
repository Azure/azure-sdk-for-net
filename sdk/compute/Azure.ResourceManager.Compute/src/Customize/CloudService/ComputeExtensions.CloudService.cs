// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    public static partial class ComputeExtensions
    {
        private const string CloudServiceNotSupported = "CloudService operations are no longer supported.";

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceCollection GetCloudServices(this ResourceGroupResource resourceGroupResource)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static Response<CloudServiceResource> GetCloudService(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static Task<Response<CloudServiceResource>> GetCloudServiceAsync(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceResource GetCloudServiceResource(this ArmClient client, ResourceIdentifier id)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceRoleInstanceResource GetCloudServiceRoleInstanceResource(this ArmClient client, ResourceIdentifier id)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceRoleResource GetCloudServiceRoleResource(this ArmClient client, ResourceIdentifier id)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceOSFamilyResource GetCloudServiceOSFamilyResource(this ArmClient client, ResourceIdentifier id)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceOSVersionResource GetCloudServiceOSVersionResource(this ArmClient client, ResourceIdentifier id)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceOSFamilyCollection GetCloudServiceOSFamilies(this SubscriptionResource subscriptionResource, AzureLocation location)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static Response<CloudServiceOSFamilyResource> GetCloudServiceOSFamily(this SubscriptionResource subscriptionResource, AzureLocation location, string osFamilyName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static Task<Response<CloudServiceOSFamilyResource>> GetCloudServiceOSFamilyAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string osFamilyName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static CloudServiceOSVersionCollection GetCloudServiceOSVersions(this SubscriptionResource subscriptionResource, AzureLocation location)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static Response<CloudServiceOSVersionResource> GetCloudServiceOSVersion(this SubscriptionResource subscriptionResource, AzureLocation location, string osVersionName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static Task<Response<CloudServiceOSVersionResource>> GetCloudServiceOSVersionAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string osVersionName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static Pageable<CloudServiceResource> GetCloudServices(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public static AsyncPageable<CloudServiceResource> GetCloudServicesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);
    }
}
