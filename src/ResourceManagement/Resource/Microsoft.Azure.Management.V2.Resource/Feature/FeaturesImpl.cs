using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Feature;

namespace Microsoft.Azure.Management.V2.Resource
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
