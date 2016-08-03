using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;

namespace Microsoft.Azure.Management.V2.Storage
{
    internal class StorageAccountsImpl :
        GroupableResources<
                IStorageAccount,
                StorageAccountImpl,
                Management.Storage.Models.StorageAccountInner,
                IStorageAccountsOperations,
                IStorageManager>,
        IStorageAccounts
    {
        PagedList<IStorageAccount> ISupportsListing<IStorageAccount>.List()
        {
            throw new NotImplementedException();
        }

        internal StorageAccountsImpl(IStorageAccountsOperations innerCollection, IStorageManager manager) : base(innerCollection, manager)
        {}

        #region Implementation of ISupportsCreating interface

        public StorageAccount.Definition.IBlank Define(string name)
        {
            StorageAccountImpl wrapped = WrapModel(name);
            wrapped.WithSku(SkuName.StandardGRS)
                   .WithGeneralPurposeAccountKind();
            return wrapped;
        }

        #endregion

        #region Implementation of ISupportsListing interface

        public PagedList<IStorageAccount> List()
        {
            IEnumerable<Management.Storage.Models.StorageAccountInner> storageAccounts = InnerCollection.List();
            var pagedList = new PagedList<Management.Storage.Models.StorageAccountInner>(storageAccounts);
            return WrapList(pagedList);
        }

        #endregion

        #region Implementation of ISupportsListingByGroup interface

        public PagedList<IStorageAccount> ListByGroup(string groupName)
        {
            IEnumerable<Management.Storage.Models.StorageAccountInner> storageAccounts = InnerCollection.ListByResourceGroup(groupName);
            var pagedList = new PagedList<Management.Storage.Models.StorageAccountInner>(storageAccounts);
            return WrapList(pagedList);
        }

        #endregion

        #region Implementation of ISupportsGettingByGroup::GetByGroupAsync and override GroupableResources::GetByGroupAsync

        public override async Task<IStorageAccount> GetByGroupAsync(string groupName, string name)
        {
           var storageAccount = await InnerCollection.GetPropertiesAsync(groupName, name);
            return WrapModel(storageAccount);
        }

        #endregion

        #region Implementation of ISupportsDeleting interface

        public Task DeleteAsync(string id)
        {
            return DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string id)
        {
            DeleteAsync(id).Wait();
        }

        #endregion

        #region Implementation of ISupportsDeletingByGroup interface

        public Task DeleteAsync(string resourceGroupName, string name)
        {
            return InnerCollection.DeleteAsync(resourceGroupName, name);
        }

        public void Delete(string resourceGroupName, string name)
        {
            DeleteAsync(resourceGroupName, name).Wait();
        }

        #endregion

        #region Implementation of CreatableWrappers::WrapModel abstract method

        protected override IStorageAccount WrapModel(Management.Storage.Models.StorageAccountInner inner)
        {
            return new StorageAccountImpl(inner.Name,
                inner,
                InnerCollection,
                MyManager);
        }

        #endregion

        #region Implementation of ReadableWrappers::WrapModel abstract method

        protected override StorageAccountImpl WrapModel(string name)
        {
            Management.Storage.Models.StorageAccountInner innerObject = new Management.Storage.Models.StorageAccountInner();
            return new StorageAccountImpl(name,
                innerObject,
                InnerCollection,
                MyManager
            );
        }

        public Task<PagedList<IStorageAccount>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
