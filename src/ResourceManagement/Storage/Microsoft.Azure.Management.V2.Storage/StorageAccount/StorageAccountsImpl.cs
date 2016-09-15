using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Resource.Core;

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
        internal StorageAccountsImpl(IStorageAccountsOperations innerCollection, IStorageManager manager) : base(innerCollection, manager)
        {}

        #region Actions

        public CheckNameAvailabilityResult CheckNameAvailability(string name)
        {
            return new CheckNameAvailabilityResult(InnerCollection.CheckNameAvailability(name));
        }

        #endregion


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
            IEnumerable<StorageAccountInner> storageAccounts = InnerCollection.List();
            var pagedList = new PagedList<StorageAccountInner>(storageAccounts);
            return WrapList(pagedList);
        }

        #endregion

        #region Implementation of ISupportsListingByGroup interface

        public PagedList<IStorageAccount> ListByGroup(string groupName)
        {
            IEnumerable<StorageAccountInner> storageAccounts = InnerCollection.ListByResourceGroup(groupName);
            var pagedList = new PagedList<StorageAccountInner>(storageAccounts);
            return WrapList(pagedList);
        }

        public Task<PagedList<IStorageAccount>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
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

        public void Delete(string id)
        {
            DeleteAsync(id).Wait();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        #endregion

        #region Implementation of ISupportsDeletingByGroup interface

        public void Delete(string resourceGroupName, string name)
        {
            DeleteAsync(resourceGroupName, name).Wait();
        }

        public Task DeleteAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(resourceGroupName, name, cancellationToken);
        }

        #endregion

        #region Implementation of CreatableWrappers::WrapModel abstract method

        protected override IStorageAccount WrapModel(StorageAccountInner inner)
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
            Management.Storage.Models.StorageAccountInner innerObject = new StorageAccountInner();
            return new StorageAccountImpl(name,
                innerObject,
                InnerCollection,
                MyManager
            );
        }

        #endregion
    }
}
