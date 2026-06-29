// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public partial class NetAppActiveDirectoryConfigCollection : ArmCollection, IEnumerable<NetAppActiveDirectoryConfigResource>, IAsyncEnumerable<NetAppActiveDirectoryConfigResource>
    {
        protected NetAppActiveDirectoryConfigCollection()
        {
        }

        internal NetAppActiveDirectoryConfigCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            ValidateResourceId(id);
        }

        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
            {
                throw new ArgumentException($"Invalid resource type {id.ResourceType} expected {ResourceGroupResource.ResourceType}", nameof(id));
            }
        }

        public virtual Task<ArmOperation<NetAppActiveDirectoryConfigResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string activeDirectoryConfigName, NetAppActiveDirectoryConfigData data, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual ArmOperation<NetAppActiveDirectoryConfigResource> CreateOrUpdate(WaitUntil waitUntil, string activeDirectoryConfigName, NetAppActiveDirectoryConfigData data, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Task<Response<NetAppActiveDirectoryConfigResource>> GetAsync(string activeDirectoryConfigName, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Response<NetAppActiveDirectoryConfigResource> Get(string activeDirectoryConfigName, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual AsyncPageable<NetAppActiveDirectoryConfigResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Pageable<NetAppActiveDirectoryConfigResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Task<Response<bool>> ExistsAsync(string activeDirectoryConfigName, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Response<bool> Exists(string activeDirectoryConfigName, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Task<NullableResponse<NetAppActiveDirectoryConfigResource>> GetIfExistsAsync(string activeDirectoryConfigName, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual NullableResponse<NetAppActiveDirectoryConfigResource> GetIfExists(string activeDirectoryConfigName, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public IEnumerator<NetAppActiveDirectoryConfigResource> GetEnumerator() => throw new NotSupportedException();

        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();

        public IAsyncEnumerator<NetAppActiveDirectoryConfigResource> GetAsyncEnumerator(CancellationToken cancellationToken = default) => throw new NotSupportedException();
    }
}
