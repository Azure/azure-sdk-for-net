// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Storage.Fluent
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
        internal StorageAccountsImpl(IStorageManager manager) : base(manager.Inner.StorageAccounts, manager)
        { }
        
        public CheckNameAvailabilityResult CheckNameAvailability(string name)
        {
            return new CheckNameAvailabilityResult(Inner.CheckNameAvailability(name));
        }
        
        public StorageAccount.Definition.IBlank Define(string name)
        {
            StorageAccountImpl wrapped = WrapModel(name);
            wrapped.WithSku(SkuName.StandardGRS)
                   .WithGeneralPurposeAccountKind();
            return wrapped;
        }
        
        public IEnumerable<IStorageAccount> List()
        {
            return WrapList(Inner.List());
        }
        
        public IEnumerable<IStorageAccount> ListByGroup(string groupName)
        {
            return WrapList(Inner.ListByResourceGroup(groupName));
        }

        public Task<IEnumerable<IStorageAccount>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }
        
        public async override Task<IStorageAccount> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var storageAccount = await Inner.GetPropertiesAsync(groupName, name, cancellationToken);
            return WrapModel(storageAccount);
        }
        
        public async override Task DeleteByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(resourceGroupName, name, cancellationToken);
        }
        
        protected override IStorageAccount WrapModel(StorageAccountInner inner)
        {
            return new StorageAccountImpl(inner.Name, inner, Manager);
        }
        
        protected override StorageAccountImpl WrapModel(string name)
        {
            Management.Storage.Fluent.Models.StorageAccountInner innerObject = new StorageAccountInner();
            return new StorageAccountImpl(name, innerObject, Manager
            );
        }
    }
}