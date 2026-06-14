// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shims do not need public docs.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SubscriptionSecurityApplicationCollection
    {
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<SubscriptionSecurityApplicationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string applicationId, SecurityApplicationData data, CancellationToken cancellationToken = default(CancellationToken))
            => CreateOrUpdateAsync(waitUntil, applicationId, (SecurityConnectorApplicationData)data, cancellationToken);

        [ForwardsClientCalls]
        public virtual ArmOperation<SubscriptionSecurityApplicationResource> CreateOrUpdate(WaitUntil waitUntil, string applicationId, SecurityApplicationData data, CancellationToken cancellationToken = default(CancellationToken))
            => CreateOrUpdate(waitUntil, applicationId, (SecurityConnectorApplicationData)data, cancellationToken);
    }
}
