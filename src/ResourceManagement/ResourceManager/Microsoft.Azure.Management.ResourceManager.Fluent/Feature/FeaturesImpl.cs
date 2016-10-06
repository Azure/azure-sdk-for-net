// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Feature;

namespace Microsoft.Azure.Management.Resource.Fluent
{
    internal class FeaturesImpl : IFeatures
    {
        private IFeaturesOperations client;

        internal FeaturesImpl(IFeaturesOperations client)
        {
            this.client = client;
        }

        public PagedList<IFeature> List()
        {
            PagedList<FeatureResultInner> innerList = new PagedList<FeatureResultInner>(client.ListAll(), (string nextLink) =>
            {
                return client.ListNext(nextLink);
            });
            return new PagedList<IFeature>(new WrappedPage<FeatureResultInner, IFeature>(innerList.CurrentPage, WrapModel), (string nextLink) =>
            {
                innerList.LoadNextPage();
                return new WrappedPage<FeatureResultInner, IFeature>(innerList.CurrentPage, WrapModel);
            });
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
