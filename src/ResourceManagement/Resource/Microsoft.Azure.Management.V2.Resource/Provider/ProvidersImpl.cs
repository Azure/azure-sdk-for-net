using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource
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

        public PagedList<IProvider> List()
        {
            PagedList<ProviderInner> innerList = new PagedList<ProviderInner>(client.List(), (string nextLink) =>
            {
                return client.ListNext(nextLink);
            });
            return new PagedList<IProvider>(new WrappedPage<ProviderInner, IProvider>(innerList.CurrentPage, WrapModel), (string nextLink) =>
            {
                innerList.LoadNextPage();
                return new WrappedPage<ProviderInner, IProvider>(innerList.CurrentPage, WrapModel);
            });
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
