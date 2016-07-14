using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public abstract class GroupableResources<IFluentResourceT, FluentResourceT, InnerResourceT, InnerCollectionT, ManagerT> :
        CreatableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT>,
        ISupportsGettingById<IFluentResourceT>,
        ISupportsGettingByGroup<IFluentResourceT>
        where IFluentResourceT : IGroupableResource
        where FluentResourceT : IFluentResourceT
        where ManagerT : ManagerBase
    {
        protected GroupableResources(InnerCollectionT innerCollection, ManagerT manager)
        {
            InnerCollection = innerCollection;
            MyManager = manager;
        }

        protected InnerCollectionT InnerCollection { get; }

        protected ManagerT MyManager { get; }

        public abstract Task<IFluentResourceT> GetByGroup(string groupName, string name);

        public Task<IFluentResourceT> GetById(string id)
        {
            return GetByGroup(
                    ResourceUtils.GroupFromResourceId(id),
                    ResourceUtils.NameFromResourceId(id)
                );
        }
    }
}
