// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Mocking
{
    public partial class MockableComputeResourceGroupResource : ArmResource
    {
        private const string CloudServiceNotSupported = "CloudService operations are no longer supported.";

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual CloudServiceCollection GetCloudServices()
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual Response<CloudServiceResource> GetCloudService(string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);

        /// <summary> Not supported. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceNotSupported)]
        public virtual Task<Response<CloudServiceResource>> GetCloudServiceAsync(string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceNotSupported);
    }
}
