// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{
    using Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition;
    using Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Storage;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using V2.Resource.Core;

    /// <summary>
    /// Implementation for BatchAccount and its parent interfaces.
    /// </summary>
    internal partial class BatchAccountImpl :
        GroupableResource<
            IBatchAccount,
            BatchAccountInner,
            Rest.Azure.Resource,
            BatchAccountImpl,
            BatchManager,
            IWithGroup,
            IWithCreateAndApplication,
            IWithCreate,
            IUpdate>,
        IBatchAccount,
        IDefinition,
        IUpdate
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

        public Management.Batch.Models.ProvisioningState? ProvisioningState
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

        public BatchAccountKeys GetKeys()
        {
            BatchAccountKeysInner keys = innerCollection.GetKeys(ResourceGroupName, Name);
            return new BatchAccountKeys(keys.Primary, keys.Secondary);
        }

        public BatchAccountKeys RegenerateKeys(AccountKeyType keyType)
        {
            BatchAccountKeysInner keys = innerCollection.RegenerateKey(ResourceGroupName, Name, keyType);
            return new BatchAccountKeys(keys.Primary, keys.Secondary);
        }

        public void SynchronizeAutoStorageKeys()
        {
            innerCollection.SynchronizeAutoStorageKeys(ResourceGroupName, Name);
        }

        public IDictionary<string, IApplication> Applications()
        {
            return applicationsImpl.AsMap();
        }

        public BatchAccountImpl WithExistingStorageAccount(IStorageAccount storageAccount)
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

            V2.Storage.StorageAccount.Definition.IWithCreate definitionAfterGroup;

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

        public ApplicationImpl DefineNewApplication(string applicationId)
        {
            return applicationsImpl.Define(applicationId);
        }

        public ApplicationImpl UpdateApplication(string applicationId)
        {
            return applicationsImpl.Update(applicationId);
        }

        public IUpdate WithoutApplication(string applicationId)
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

        public BatchAccountImpl WithApplication(ApplicationImpl application)
        {
            applicationsImpl.AddApplication(application);
            return this;
        }
    }
}