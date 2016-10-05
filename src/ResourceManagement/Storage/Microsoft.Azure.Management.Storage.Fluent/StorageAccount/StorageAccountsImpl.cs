// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Storage
{
    internal class StorageAccountsImpl :
        GroupableResources<
                IStorageAccount,
                StorageAccountImpl,
                StorageAccountInner,
                IStorageAccountsOperations,
                IStorageManager>,
        IStorageAccounts
    {
        internal StorageAccountsImpl(IStorageAccountsOperations innerCollection, IStorageManager manager) : base(innerCollection, manager)
        { }

        #region Actions

        public CheckNameAvailabilityResult CheckNameAvailability(string name)
        {
            return new CheckNameAvailabilityResult(InnerCollection.CheckNameAvailability(name));
        }

        #endregion Actions

        #region Implementation of ISupportsCreating interface

        public StorageAccount.Definition.IBlank Define(string name)
        {
            StorageAccountImpl wrapped = WrapModel(name);
            wrapped.WithSku(SkuName.StandardGRS)
                   .WithGeneralPurposeAccountKind();
            return wrapped;
        }

        #endregion Implementation of ISupportsCreating interface

        #region Implementation of ISupportsListing interface

        public PagedList<IStorageAccount> List()
        {
            IEnumerable<StorageAccountInner> storageAccounts = InnerCollection.List();
            var pagedList = new PagedList<StorageAccountInner>(storageAccounts);
            return WrapList(pagedList);
        }

        #endregion Implementation of ISupportsListing interface

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

        #endregion Implementation of ISupportsListingByGroup interface

        #region Implementation of ISupportsGettingByGroup::GetByGroupAsync and override GroupableResources::GetByGroupAsync

        public override async Task<IStorageAccount> GetByGroupAsync(string groupName, string name)
        {
            var storageAccount = await InnerCollection.GetPropertiesAsync(groupName, name);
            return WrapModel(storageAccount);
        }

        #endregion Implementation of ISupportsGettingByGroup::GetByGroupAsync and override GroupableResources::GetByGroupAsync

        #region Implementation of ISupportsDeleting interface

        public void Delete(string id)
        {
            DeleteAsync(id).Wait();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        #endregion Implementation of ISupportsDeleting interface

        #region Implementation of ISupportsDeletingByGroup interface

        public void Delete(string resourceGroupName, string name)
        {
            DeleteAsync(resourceGroupName, name).Wait();
        }

        public Task DeleteAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(resourceGroupName, name, cancellationToken);
        }

        #endregion Implementation of ISupportsDeletingByGroup interface

        #region Implementation of CreatableWrappers::WrapModel abstract method

        protected override IStorageAccount WrapModel(StorageAccountInner inner)
        {
            return new StorageAccountImpl(inner.Name,
                inner,
                InnerCollection,
                Manager);
        }

        #endregion Implementation of CreatableWrappers::WrapModel abstract method

        #region Implementation of ReadableWrappers::WrapModel abstract method

        protected override StorageAccountImpl WrapModel(string name)
        {
            Management.Storage.Models.StorageAccountInner innerObject = new StorageAccountInner();
            return new StorageAccountImpl(name,
                innerObject,
                InnerCollection,
                Manager
            );
        }

        #endregion Implementation of ReadableWrappers::WrapModel abstract method
    }
}