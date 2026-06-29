// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp.Mocking
{
    public partial class MockableNetAppResourceGroupResource
    {
        public virtual NetAppElasticAccountCollection GetNetAppElasticAccounts() => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Task<Response<NetAppElasticAccountResource>> GetNetAppElasticAccountAsync(string accountName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Response<NetAppElasticAccountResource> GetNetAppElasticAccount(string accountName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
    }
}
