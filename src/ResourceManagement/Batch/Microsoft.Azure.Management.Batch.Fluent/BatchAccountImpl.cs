// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Management.Batch.Fluent;
    using Management.Batch.Fluent.Models;
    using Resource.Fluent;
    using Resource.Fluent.Core.ResourceActions;
    using Storage.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Resource.Fluent.Core;

    /// <summary>
    /// Implementation for BatchAccount and its parent interfaces.
    /// </summary>
    public partial class BatchAccountImpl :
        GroupableResource<
            IBatchAccount,
            BatchAccountInner,
            BatchAccountImpl,
            BatchManager,
            BatchAccount.Definition.IWithGroup,
            BatchAccount.Definition.IWithCreateAndApplication,
            BatchAccount.Definition.IWithCreate,
            BatchAccount.Update.IUpdate>,
        IBatchAccount,
        BatchAccount.Definition.IDefinition,
        BatchAccount.Update.IUpdate
    {
        private IBatchAccountOperations innerCollection;
        private IStorageManager storageManager;
        private string creatableStorageAccountKey;
        private IStorageAccount existingStorageAccountToAssociate;
        private ApplicationsImpl applicationsImpl;

        internal BatchAccountImpl(string name,
                BatchAccountInner innerObject,
                IBatchAccountOperations innerCollection,
                BatchManager manager,
                IApplicationOperations applicationsClient,
                IApplicationPackageOperations applicationPackagesClient,
                IStorageManager storageManager)
            : base(name, innerObject, manager)
        {
            this.innerCollection = innerCollection;
            this.storageManager = storageManager;
            applicationsImpl = new ApplicationsImpl(applicationsClient, applicationPackagesClient, this);
        }

        public override IBatchAccount Refresh()
        {
            BatchAccountInner response = innerCollection.Get(ResourceGroupName, Name);

            SetInner(response);
            applicationsImpl.Refresh();

            return this;
        }

        public override async Task<IBatchAccount> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            HandleStorageSettings();
            var batchAccountCreateParametersInner = new BatchAccountCreateParametersInner();
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
            SetInner(batchAccountInner);
            await applicationsImpl.CommitAndGetAllAsync(cancellationToken);

            return this;
        }

        internal Management.Batch.Fluent.Models.ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState.GetValueOrDefault();
        }

        internal string AccountEndpoint()
        {
            return Inner.AccountEndpoint;
        }

        internal AutoStorageProperties AutoStorage()
        {
            return Inner.AutoStorage;
        }

        internal int CoreQuota()
        {
            return Inner.CoreQuota;
        }

        internal int PoolQuota()
        {
            return Inner.PoolQuota;
        }

        internal int ActiveJobAndJobScheduleQuota()
        {
            return Inner.ActiveJobAndJobScheduleQuota;
        }

        internal BatchAccountKeys GetKeys()
        {
            BatchAccountKeysInner keys = innerCollection.GetKeys(ResourceGroupName, Name);
            return new BatchAccountKeys(keys.Primary, keys.Secondary);
        }

        internal BatchAccountKeys RegenerateKeys(AccountKeyType keyType)
        {
            BatchAccountKeysInner keys = innerCollection.RegenerateKey(ResourceGroupName, Name, keyType);
            return new BatchAccountKeys(keys.Primary, keys.Secondary);
        }

        internal void SynchronizeAutoStorageKeys()
        {
            innerCollection.SynchronizeAutoStorageKeys(ResourceGroupName, Name);
        }

        internal IDictionary<string, IApplication> Applications()
        {
            return applicationsImpl.AsMap();
        }

        internal BatchAccountImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            existingStorageAccountToAssociate = storageAccount;
            creatableStorageAccountKey = null;

            return this;
        }

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

        internal BatchAccountImpl WithoutStorageAccount()
        {
            existingStorageAccountToAssociate = null;
            creatableStorageAccountKey = null;
            Inner.AutoStorage = null;

            return this;
        }

        internal ApplicationImpl DefineNewApplication(string applicationId)
        {
            return applicationsImpl.Define(applicationId);
        }

        internal ApplicationImpl UpdateApplication(string applicationId)
        {
            return applicationsImpl.Update(applicationId);
        }

        internal BatchAccountImpl WithoutApplication(string applicationId)
        {
            applicationsImpl.Remove(applicationId);
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
                return;
            }

            if (Inner.AutoStorage == null)
            {
                Inner.AutoStorage = new AutoStorageProperties();
            }

            Inner.AutoStorage.StorageAccountId = storageAccount.Id;
        }

        internal BatchAccountImpl WithApplication(ApplicationImpl application)
        {
            applicationsImpl.AddApplication(application);
            return this;
        }
    }
}