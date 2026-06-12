// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shims do not need public docs.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityContactCollection
    {
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<SecurityContactResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string securityContactName, SecurityContactData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, (SecurityContactName)securityContactName, data, cancellationToken);

        [ForwardsClientCalls]
        public virtual ArmOperation<SecurityContactResource> CreateOrUpdate(WaitUntil waitUntil, string securityContactName, SecurityContactData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, (SecurityContactName)securityContactName, data, cancellationToken);

        [ForwardsClientCalls]
        public virtual Task<Response<SecurityContactResource>> GetAsync(string securityContactName, CancellationToken cancellationToken = default)
            => GetAsync((SecurityContactName)securityContactName, cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<SecurityContactResource> Get(string securityContactName, CancellationToken cancellationToken = default)
            => Get((SecurityContactName)securityContactName, cancellationToken);

        [ForwardsClientCalls]
        public virtual Task<Response<bool>> ExistsAsync(string securityContactName, CancellationToken cancellationToken = default)
            => ExistsAsync((SecurityContactName)securityContactName, cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<bool> Exists(string securityContactName, CancellationToken cancellationToken = default)
            => Exists((SecurityContactName)securityContactName, cancellationToken);
    }
}
