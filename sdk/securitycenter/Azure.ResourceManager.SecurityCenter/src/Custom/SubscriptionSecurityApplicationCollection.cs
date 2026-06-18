// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shim does not need public docs.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SubscriptionSecurityApplicationCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SubscriptionSecurityApplicationResource> CreateOrUpdate(WaitUntil waitUntil, string applicationId, SecurityApplicationData data, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SubscriptionSecurityApplicationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string applicationId, SecurityApplicationData data, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");
    }
}
