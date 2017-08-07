// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The implementation of StorageAccounts and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuaW1wbGVtZW50YXRpb24uU3RvcmFnZUFjY291bnRzSW1wbA==
    internal partial class StorageAccountsImpl : TopLevelModifiableResources<
                IStorageAccount,
                StorageAccountImpl,
                StorageAccountInner,
                IStorageAccountsOperations,
                IStorageManager>,
        IStorageAccounts
    {
        ///GENMHASH:CAF9C60CDF20574430EA950EFF44BAD7:203896CB3A94364B5BCBEC519D7570FE
        internal StorageAccountsImpl(IStorageManager storageManager) : base(storageManager.Inner.StorageAccounts, storageManager)
        { }

        ///GENMHASH:42E0B61F5AA4A1130D7B90CCBAAE3A5D:818AFE85371661E9A54D33FFEE903112
        public async Task<Microsoft.Azure.Management.Storage.Fluent.CheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new CheckNameAvailabilityResult(await Inner.CheckNameAvailabilityAsync(name, cancellationToken));
        }

        ///GENMHASH:C4C74C5CA23BE3B4CAFEFD0EF23149A0:B6DE3F3ADD30CF80937F7E47989E73C7
        public CheckNameAvailabilityResult CheckNameAvailability(string name)
        {
            return Extensions.Synchronize(() => CheckNameAvailabilityAsync(name));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AE7618DEFA52BF6B178D880C65E79670
        public StorageAccountImpl Define(string name)
        {
            return WrapModel(name)
                    .WithSku(SkuName.StandardGRS)
                   .WithGeneralPurposeAccountKind();
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
            // Note: Using GetPropertiesAsync instead of GetAsync to get extended information about the storage account.
            //
            return await Inner.GetPropertiesAsync(groupName, name, cancellationToken);
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:2A8077054DAAE50898DF5E1B9FCC9EE9
        protected override StorageAccountImpl WrapModel(string name)
        {
            return new StorageAccountImpl(name, new StorageAccountInner(), Manager);
        }

        ///GENMHASH:14BC53657DA284C1E6DC963C78A02447:55673621A81743078EBE1EB3331FB9AE
        protected override IStorageAccount WrapModel(StorageAccountInner storageAccountInner)
        {
            if (storageAccountInner == null)
            {
                return null;
            }
            return new StorageAccountImpl(storageAccountInner.Name, storageAccountInner, Manager);
        }
    }
}