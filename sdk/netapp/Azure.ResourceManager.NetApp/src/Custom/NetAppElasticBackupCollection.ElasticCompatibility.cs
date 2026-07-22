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

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppElasticBackupCollection : ArmCollection, IEnumerable<NetAppElasticBackupResource>, IAsyncEnumerable<NetAppElasticBackupResource> { protected NetAppElasticBackupCollection() { } internal NetAppElasticBackupCollection(ArmClient client, ResourceIdentifier id) : base(client, id) { } public IEnumerator<NetAppElasticBackupResource> GetEnumerator() => throw new NotSupportedException(); IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException(); public IAsyncEnumerator<NetAppElasticBackupResource> GetAsyncEnumerator(CancellationToken cancellationToken = default) => throw new NotSupportedException(); }
}
