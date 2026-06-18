// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shim does not need public docs.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityConnectorApplicationResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SecurityApplicationData Data => throw new System.NotSupportedException("This API is no longer supported by the service.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SecurityConnectorApplicationResource> Update(WaitUntil waitUntil, SecurityApplicationData data, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SecurityConnectorApplicationResource>> UpdateAsync(WaitUntil waitUntil, SecurityApplicationData data, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");
    }
}
