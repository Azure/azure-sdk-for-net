// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System.Collections.Generic;
using System.Linq;

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
            return new ProviderImpl(client.Get(resourceProviderNamespace));
        }

        public async Task<IProvider> GetByNameAsync(string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken))
        {
            ProviderInner inner = await client.GetAsync(resourceProviderNamespace, null, cancellationToken);
            return new ProviderImpl(inner);
        }

        public IEnumerable<IProvider> List()
        {
            return client.List()
                         .AsContinuousCollection(link => client.ListNext(link))
                         .Select(inner => WrapModel(inner));
        }

        public IProvider Register(string resourceProviderNamespace)
        {
            return WrapModel(client.Register(resourceProviderNamespace));
        }

        public IProvider Unregister(string resourceProviderNamespace)
        {
            return WrapModel(client.Unregister(resourceProviderNamespace));
        }

        private IProvider WrapModel(ProviderInner innerModel)
        {
            return new ProviderImpl(innerModel);
        }
    }
}
