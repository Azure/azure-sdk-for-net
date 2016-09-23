// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.V2.Batch
{
    using Management.Batch;
    using Management.Batch.Models;
    using Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition;
    using Microsoft.Azure.Management.V2.Batch.BatchAccount.Update;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Storage;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for BatchAccount and its parent interfaces.
    /// </summary>
    public partial class BatchAccountImpl :
        GroupableResource<
            IBatchAccount,
            AccountResourceInner,
            Rest.Azure.Resource,
            BatchAccountImpl,
            IBatchManager,
            BatchAccount.Definition.IWithGroup,
            BatchAccount.Definition.IWithCreate,
            BatchAccount.Definition.IWithCreate,
            IUpdate>,
        IBatchAccount,
        IDefinition,
        IUpdate
    {
        private IAccountOperations innerCollection;
        private IStorageManager storageManager;
        private string creatableStorageAccountKey;
        private IStorageAccount existingStorageAccountToAssociate;
        private BatchAccountKeys cachedKeys;

        internal BatchAccountImpl(string name, AccountResourceInner innerObject, IAccountOperations innerCollection, BatchManager manager, IStorageManager storageManager)
            : base(name, innerObject, manager)
        {
            this.innerCollection = innerCollection;
            this.storageManager = storageManager;
        }

        public override async Task<IBatchAccount> Refresh()
        {
            var response = await innerCollection.GetAsync(ResourceGroupName, Name);
            SetInner(response);

            return this;
        }

        public async override Task<IBatchAccount> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            HandleStorageSettings();
            BatchAccountCreateParametersInner batchAccountCreateParametersInner = new BatchAccountCreateParametersInner();
            if (Inner.AutoStorage != null)
            {
                batchAccountCreateParametersInner.AutoStorage = new AutoStorageBaseProperties();
                batchAccountCreateParametersInner.AutoStorage.StorageAccountId = Inner.AutoStorage.StorageAccountId;
            }
            else
            {
                batchAccountCreateParametersInner.AutoStorage = null;
            }

            batchAccountCreateParametersInner.Location = Inner.Location;
            batchAccountCreateParametersInner.Tags = Inner.Tags;

            var batchAccountInner = await innerCollection.CreateAsync(ResourceGroupName, Name, batchAccountCreateParametersInner, cancellationToken);

            creatableStorageAccountKey = null;
            existingStorageAccountToAssociate = null;
            SetInner(batchAccountInner);

            return this;
        }

        public async Task<IBatchAccount> ApplyUpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // TODO - ans - remove call to createResourceAsync and uncomment code below, after PATCH start sending the nulls.
            return await CreateResourceAsync(cancellationToken);
            /*
            final  BatchAccountImpl self = this;
            handleStorageSettings();
            BatchAccountUpdateParametersInner batchAccountUpdateParametersInner = new BatchAccountUpdateParametersInner();
            if (self.inner().autoStorage() != null) {
            batchAccountUpdateParametersInner.AutoStorage(new AutoStorageBaseProperties());
            batchAccountUpdateParametersInner.autoStorage().StorageAccountId(self.inner().autoStorage().storageAccountId());
            } else {
            batchAccountUpdateParametersInner.AutoStorage(null);
            }

            batchAccountUpdateParametersInner.Tags(self.inner().getTags());

            return self.innerCollection.updateAsync(self.resourceGroupName(), self.name(), batchAccountUpdateParametersInner)
            .map(new Func1<ServiceResponse<AccountResourceInner>, BatchAccount>() {
            @Override
            public BatchAccount call(ServiceResponse<AccountResourceInner> accountResourceInner) {
            setInner(accountResourceInner.getBody());
            return self;
            }
            });
            */
        }

        public AccountProvisioningState? ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        public string AccountEndpoint
        {
            get
            {
                return Inner.AccountEndpoint;
            }
        }

        public AutoStorageProperties AutoStorage
        {
            get
            {
                return Inner.AutoStorage;
            }
        }

        public int? CoreQuota
        {
            get
            {
                return Inner.CoreQuota;
            }
        }

        public int? PoolQuota
        {
            get
            {
                return Inner.PoolQuota;
            }
        }

        public int? ActiveJobAndJobScheduleQuota
        {
            get
            {
                return Inner.ActiveJobAndJobScheduleQuota;
            }
        }

        public BatchAccountKeys Keys()
        {
            if (cachedKeys == null)
            {
                cachedKeys = RefreshKeys();
            }

            return cachedKeys;
        }

        public BatchAccountKeys RefreshKeys()
        {
            BatchAccountListKeyResultInner keys = innerCollection.ListKeys(ResourceGroupName, Name);
            cachedKeys = new BatchAccountKeys(keys.Primary, keys.Secondary);

            return cachedKeys;
        }

        public BatchAccountKeys RegenerateKeys(AccountKeyType keyType)
        {
            BatchAccountRegenerateKeyResultInner keys = innerCollection.RegenerateKey(ResourceGroupName, Name, keyType);
            cachedKeys = new BatchAccountKeys(keys.Primary, keys.Secondary);

            return cachedKeys;
        }

        public void SynchronizeAutoStorageKeys()
        {
            innerCollection.SynchronizeAutoStorageKeys(ResourceGroupName, Name);
        }

        public BatchAccountImpl WithStorageAccount(IStorageAccount storageAccount)
        {
            existingStorageAccountToAssociate = storageAccount;
            creatableStorageAccountKey = null;
            return this;
        }

        public BatchAccountImpl WithNewStorageAccount(ICreatable<IStorageAccount> creatable)
        {
            // This method's effect is NOT additive.
            if (creatableStorageAccountKey == null)
            {
                creatableStorageAccountKey = creatable.Key;
                AddCreatableDependency(creatable as IResourceCreator<IResource>);
            }
            existingStorageAccountToAssociate = null;
            return this;
        }

        public BatchAccountImpl WithNewStorageAccount(string storageAccountName)
        {
            var definitionWithGroup = storageManager.
                StorageAccounts.
                Define(storageAccountName).
                WithRegion(RegionName);

            Storage.StorageAccount.Definition.IWithCreate definitionAfterGroup;

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

        public BatchAccountImpl WithoutStorageAccount()
        {
            existingStorageAccountToAssociate = null;
            creatableStorageAccountKey = null;
            Inner.AutoStorage = null;

            return this;
        }

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
                Inner.AutoStorage = null;
                return;
            }

            if (Inner.AutoStorage == null)
            {
                Inner.AutoStorage = new AutoStorageProperties();
            }

            Inner.AutoStorage.StorageAccountId = storageAccount.Id;
        }
    }
}