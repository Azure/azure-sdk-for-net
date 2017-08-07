// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class ProvidersImpl : IProviders
    {
        private IProvidersOperations client;

        internal ProvidersImpl(IProvidersOperations client)
        {
            this.client = client;
        }

        public IProvider GetByName(string resourceProviderNamespace)
        {
            return new ProviderImpl(Extensions.Synchronize(() => client.GetAsync(resourceProviderNamespace)));
        }

        public async Task<IProvider> GetByNameAsync(string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken))
        {
            ProviderInner inner = await client.GetAsync(resourceProviderNamespace, cancellationToken: cancellationToken);
            return new ProviderImpl(inner);
        }

        public IEnumerable<IProvider> List()
        {
            return Extensions.Synchronize(() => client.ListAsync())
                         .AsContinuousCollection(link => Extensions.Synchronize(() => client.ListNextAsync(link)))
                         .Select(inner => WrapModel(inner));
        }

        public async Task<IPagedCollection<IProvider>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IProvider, ProviderInner>.LoadPage(
                async (cancellation) => await client.ListAsync(cancellationToken: cancellation),
                client.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        public IProvider Register(string resourceProviderNamespace)
        {
            return WrapModel(Extensions.Synchronize(() => client.RegisterAsync(resourceProviderNamespace)));
        }

        public async Task<IProvider> RegisterAsync(string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await client.RegisterAsync(resourceProviderNamespace, cancellationToken));
        }

        public IProvider Unregister(string resourceProviderNamespace)
        {
            return Extensions.Synchronize(() => UnregisterAsync(resourceProviderNamespace));
        }

        public async Task<IProvider> UnregisterAsync(string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await client.UnregisterAsync(resourceProviderNamespace, cancellationToken));
        }

        private IProvider WrapModel(ProviderInner innerModel)
        {
            return new ProviderImpl(innerModel);
        }
    }
}
