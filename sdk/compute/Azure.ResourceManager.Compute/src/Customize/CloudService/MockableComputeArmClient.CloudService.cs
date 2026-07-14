// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Mocking
{
    public partial class MockableComputeArmClient : ArmResource
    {
        private const string CloudServiceNotSupported = "CloudService operations are no longer supported.";

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual CloudServiceResource GetCloudServiceResource(ResourceIdentifier id)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual CloudServiceRoleInstanceResource GetCloudServiceRoleInstanceResource(ResourceIdentifier id)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual CloudServiceRoleResource GetCloudServiceRoleResource(ResourceIdentifier id)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual CloudServiceOSFamilyResource GetCloudServiceOSFamilyResource(ResourceIdentifier id)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual CloudServiceOSVersionResource GetCloudServiceOSVersionResource(ResourceIdentifier id)
            => throw new NotSupportedException(CloudServiceNotSupported);
    }
}
