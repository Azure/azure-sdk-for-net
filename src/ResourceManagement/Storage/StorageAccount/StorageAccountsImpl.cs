// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    internal class StorageAccountsImpl :
        TopLevelModifiableResources<
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
            return CheckNameAvailabilityAsync(name).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task<CheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new CheckNameAvailabilityResult(await Inner.CheckNameAvailabilityAsync(name, cancellationToken));
        }

        public StorageAccount.Definition.IBlank Define(string name)
        {
            StorageAccountImpl wrapped = WrapModel(name);
            wrapped.WithSku(SkuName.StandardGRS)
                   .WithGeneralPurposeAccountKind();
            return wrapped;
        }

        protected async override Task<IPage<StorageAccountInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return ConvertToPage(await Inner.ListAsync(cancellationToken));
        }

        protected async override Task<IPage<StorageAccountInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<StorageAccountInner>>(null);
        }

        protected async override Task<IPage<StorageAccountInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return ConvertToPage(await Inner.ListByResourceGroupAsync(groupName, cancellationToken));
        }

        protected async override Task<IPage<StorageAccountInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<StorageAccountInner>>(null);
        }

        protected async override Task<StorageAccountInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetPropertiesAsync(groupName, name, cancellationToken);
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
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