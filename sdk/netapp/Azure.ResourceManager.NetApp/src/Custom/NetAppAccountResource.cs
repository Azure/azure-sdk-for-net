// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.NetApp;
using Azure.ResourceManager.NetApp.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppAccountResource: ArmResource
    {
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppVault> GetVaultsAsync(CancellationToken cancellationToken = default)
        {
            throw null;
        }

        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppVault> GetVaults(CancellationToken cancellationToken = default)
        {
            throw null;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
