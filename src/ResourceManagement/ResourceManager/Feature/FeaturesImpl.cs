// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
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
            return Extensions.Synchronize(() => client.ListAllAsync())
                         .AsContinuousCollection(link => Extensions.Synchronize(() => client.ListNextAsync(link)))
                         .Select(inner => WrapModel(inner));
        }

        public async Task<IPagedCollection<IFeature>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IFeature, FeatureResultInner>.LoadPage(
                async(cancellation) => await client.ListAllAsync(cancellation),
                client.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        public IFeature Register(string resourceProviderNamespace, string featureName)
        {
            return Extensions.Synchronize(() =>  RegisterAsync(resourceProviderNamespace, featureName));
        }

        public async Task<IFeature> RegisterAsync(
            string resourceProviderNamespace, 
            string featureName, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await client.RegisterAsync(resourceProviderNamespace, featureName, cancellationToken));
        }

        private IFeature WrapModel(FeatureResultInner innerModel)
        {
            return new FeatureImpl(innerModel);
        }
    }
}
