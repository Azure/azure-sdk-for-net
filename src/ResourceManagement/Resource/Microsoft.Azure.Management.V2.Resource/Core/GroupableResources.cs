using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public abstract class GroupableResources<IFluentResourceT, FluentResourceT, InnerResourceT, InnerCollectionT, ManagerT> :
        CreatableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT>,
        ISupportsGettingByGroup<IFluentResourceT>,
        ISupportsGettingById<IFluentResourceT>
        where IFluentResourceT : IGroupableResource
        where FluentResourceT : IFluentResourceT
        where ManagerT : IManagerBase
    {
        protected GroupableResources(InnerCollectionT innerCollection, ManagerT manager)
        {
            InnerCollection = innerCollection;
            MyManager = manager;
        }

        protected InnerCollectionT InnerCollection { get; }

        protected ManagerT MyManager { get; }

        #region Implementation of ISupportsGettingByGroup interface

        public abstract Task<IFluentResourceT> GetByGroupAsync(string groupName, string name);

        public IFluentResourceT GetByGroup(string groupName, string name)
        {
            return GetByGroupAsync(groupName, name).Result;
        }

        #endregion

        #region Implementation of ISupportsGettingById interface

        public async Task<IFluentResourceT> GetByIdAsync(string id)
        {
            return await GetByGroupAsync(
                    ResourceUtils.GroupFromResourceId(id),
                    ResourceUtils.NameFromResourceId(id)
                );
        }

        public IFluentResourceT GetById(string id)
        {
            return GetByIdAsync(id).Result;
        }

        public Task<IFluentResourceT> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IFluentResourceT> GetByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
