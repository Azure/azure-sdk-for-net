// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Feature;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class FeaturesImpl : IFeatures
    {
        private IFeaturesOperations client;

        internal FeaturesImpl(IFeaturesOperations client)
        {
            this.client = client;
        }

        public IEnumerable<IFeature> List()
        {
            return client.ListAll()
                         .AsContinuousCollection(link => client.ListNext(link))
                         .Select(inner => WrapModel(inner));
        }

        public async Task<IPagedCollection<IFeature>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IFeature, FeatureResultInner>.LoadPage(
                async(cancellation) => await client.ListAllAsync(cancellation),
                client.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        public IInResourceProvider ResourceProvider(string resourceProviderName)
        {
            return null;
        }

        private IFeature WrapModel(FeatureResultInner innerModel)
        {
            return new FeatureImpl(innerModel);
        }
    }
}
