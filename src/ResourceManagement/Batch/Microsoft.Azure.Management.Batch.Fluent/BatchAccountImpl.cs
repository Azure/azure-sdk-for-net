// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Models;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core.ResourceActions;
    using Storage.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ResourceManager.Fluent.Core;
    using System;

    /// <summary>
    /// Implementation for BatchAccount and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoLmltcGxlbWVudGF0aW9uLkJhdGNoQWNjb3VudEltcGw=
    internal partial class BatchAccountImpl :
        GroupableResource<
            IBatchAccount,
            BatchAccountInner,
            BatchAccountImpl,
            IBatchManager,
            BatchAccount.Definition.IWithGroup,
            BatchAccount.Definition.IWithCreateAndApplication,
            BatchAccount.Definition.IWithCreate,
            BatchAccount.Update.IUpdate>,
        IBatchAccount,
        BatchAccount.Definition.IDefinition,
        BatchAccount.Update.IUpdate
    {
        private IStorageManager storageManager;
        private string creatableStorageAccountKey;
        private IStorageAccount existingStorageAccountToAssociate;
        private ApplicationsImpl applicationsImpl;

        ///GENMHASH:4A1C1CE1A5FD21C2D77E9D249E53B0FC:2CAC092B38BC608EA9EE02AF770A8C0D
        internal BatchAccountImpl(
            string name,
            BatchAccountInner innerObject,
            IBatchManager manager,
            IStorageManager storageManager)
            : base(name, innerObject, manager)
        {
            this.storageManager = storageManager;
            applicationsImpl = new ApplicationsImpl(this);
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:7CF0E4D2E689061F164F4E8CBEEE0032
        public override async Task<IBatchAccount> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await GetInnerAsync(cancellationToken);

            SetInner(inner);
            applicationsImpl.Refresh();

            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:8F640179247B56242D756EB9A20DC705
        public async override Task<IBatchAccount> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            HandleStorageSettings();
            var batchAccountCreateParametersInner = new BatchAccountCreateParametersInner();
            if (Inner.AutoStorage != null)
            {
                batchAccountCreateParametersInner.AutoStorage = new AutoStorageBaseProperties
                                                                {
                                                                    StorageAccountId = Inner.AutoStorage.StorageAccountId
                                                                };
            }
            else
            {
                batchAccountCreateParametersInner.AutoStorage = null;
            }

            batchAccountCreateParametersInner.Location = Inner.Location;
            batchAccountCreateParametersInner.Tags = Inner.Tags;

            var batchAccountInner = await Manager.Inner.BatchAccount.CreateAsync(
                ResourceGroupName, 
                Name, 
                batchAccountCreateParametersInner, 
                cancellationToken);
            creatableStorageAccountKey = null;
            SetInner(batchAccountInner);
            await applicationsImpl.CommitAndGetAllAsync(cancellationToken);
            return this;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        internal Management.Batch.Fluent.Models.ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState.GetValueOrDefault();
        }

        ///GENMHASH:3FCA66079CE54B6624051AEEEA92C0A8:CD2239198F90BF2EF64E021F6D70308F
        internal string AccountEndpoint()
        {
            return Inner.AccountEndpoint;
        }

        ///GENMHASH:CDDA70CBBBCD12B0E5E922B6DE5C4E73:D188D673E338A86FF211CD3448D22B56
        internal AutoStorageProperties AutoStorage()
        {
            return Inner.AutoStorage;
        }

        ///GENMHASH:B9408D6B67E96EFD3D03881CF8649A9C:954939482CB158B1E2B509B48B09585C
        internal int CoreQuota()
        {
            return Inner.CoreQuota;
        }

        ///GENMHASH:7909615C516BD4E70FB021746FE02F60:CF51957E04C09A383C5B34AB6DFDC9EB
        internal int PoolQuota()
        {
            return Inner.PoolQuota;
        }

        ///GENMHASH:016AA742D37BA9FE61D68507B4F6B530:31B3ECE969CEF408EACD27E4747DBA41
        internal int ActiveJobAndJobScheduleQuota()
        {
            return Inner.ActiveJobAndJobScheduleQuota;
        }

        ///GENMHASH:E4DFA7EA15F8324FB60C810D0C96D2FF:2C24EC1143CD8F8542845A9D3A0F116A
        internal async Task<BatchAccountKeys> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            BatchAccountKeysInner keys = await Manager.Inner.BatchAccount.GetKeysAsync(ResourceGroupName, Name, cancellationToken);
            return new BatchAccountKeys(keys.Primary, keys.Secondary);
        }

        ///GENMHASH:837770291CB03D6C2AB9BDA889A5B07D:916D2188C6A5919A33DB6C700CE38C2A
        internal async Task<BatchAccountKeys> RegenerateKeysAsync(AccountKeyType keyType, CancellationToken cancellationToken = default(CancellationToken))
        {
            BatchAccountKeysInner keys = await Manager.Inner.BatchAccount.RegenerateKeyAsync(ResourceGroupName, Name, keyType, cancellationToken);
            return new BatchAccountKeys(keys.Primary, keys.Secondary);
        }

        ///GENMHASH:F464067830773D729F2254E152F52E95:21A9F1295EB43C714008C5226DECA98E
        internal async Task SynchronizeAutoStorageKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.BatchAccount.SynchronizeAutoStorageKeysAsync(ResourceGroupName, Name, cancellationToken);
        }

        ///GENMHASH:672E69F72385496EBDF873EB27A7AA15:C0743C8E69844064A4120ADE2213CA5B
        internal IDictionary<string, IApplication> Applications()
        {
            return applicationsImpl.AsMap();
        }

        ///GENMHASH:8CB9B7EEE4A4226A6F5BBB2958CC5E81:86F388ADD8163A5736375494E42FD140
        internal BatchAccountImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            existingStorageAccountToAssociate = storageAccount;
            creatableStorageAccountKey = null;

            return this;
        }

        ///GENMHASH:2DC51FEC3C45675856B4AC1D97BECBFD:7DBF1A9A29FD54AF8FCA5A4E2F414F87
        internal BatchAccountImpl WithNewStorageAccount(ICreatable<IStorageAccount> creatable)
        {
            // This method's effect is NOT additive.
            if (creatableStorageAccountKey == null)
            {
                creatableStorageAccountKey = creatable.Key;
                AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            }
            existingStorageAccountToAssociate = null;

            return this;
        }

        ///GENMHASH:5880487AA9218E8DF536932A49A0ACDD:FB1BAD32BA28A79F5AF97AFA7ED0EE6E
        internal BatchAccountImpl WithNewStorageAccount(string storageAccountName)
        {
            var definitionWithGroup = storageManager.
                StorageAccounts.
                Define(storageAccountName).
                WithRegion(RegionName);

            Storage.Fluent.StorageAccount.Definition.IWithCreate definitionAfterGroup;

            if (newGroup != null)
            {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(newGroup);
            }
            else
            {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(ResourceGroupName);
            }
            return WithNewStorageAccount(definitionAfterGroup);
        }

        ///GENMHASH:15D36ECAB00E9FCCF84FA127687D0CE2:A6E982618362E7F801925E23A6B4B4C2
        internal BatchAccountImpl WithoutStorageAccount()
        {
            existingStorageAccountToAssociate = null;
            creatableStorageAccountKey = null;
            Inner.AutoStorage = null;

            return this;
        }

        ///GENMHASH:37FFE6BCAA81A22948354048E4226C80:39897EDD4A6BF2A85F51AA6E4ACCEFCF
        internal ApplicationImpl DefineNewApplication(string applicationId)
        {
            return applicationsImpl.Define(applicationId);
        }

        ///GENMHASH:AA28D9B344860923503977841560DF90:ECF6C949F03691F2AE2B18AA1E90F53D
        internal ApplicationImpl UpdateApplication(string applicationId)
        {
            return applicationsImpl.Update(applicationId);
        }

        ///GENMHASH:0BB4AB6DEA8235ECDBD2F532E365AC87:533E5AAA5CEA9D252A01CBDB74B3516C
        internal BatchAccountImpl WithoutApplication(string applicationId)
        {
            applicationsImpl.Remove(applicationId);
            return this;
        }

        ///GENMHASH:C15DF8874364A70E09E929DF4B25106C:344A96E970807288B64F734F13C74B04
        private void HandleStorageSettings()
        {
            IStorageAccount storageAccount;

            if (!string.IsNullOrWhiteSpace(creatableStorageAccountKey))
            {
                storageAccount = (IStorageAccount)CreatedResource(creatableStorageAccountKey);
            }
            else if (existingStorageAccountToAssociate != null)
            {
                storageAccount = existingStorageAccountToAssociate;
            }
            else
            {
                return;
            }

            if (Inner.AutoStorage == null)
            {
                Inner.AutoStorage = new AutoStorageProperties();
            }

            Inner.AutoStorage.StorageAccountId = storageAccount.Id;
        }

        ///GENMHASH:901BF64732D40F1AFA2D615FD2C9EC6C:88A053E647AE5BA086B9195689F16CA9
        internal BatchAccountImpl WithApplication(ApplicationImpl application)
        {
            applicationsImpl.AddApplication(application);
            return this;
        }

        protected override async Task<BatchAccountInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.BatchAccount.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }
    }
}
