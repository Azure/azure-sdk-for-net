// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System.Threading;
using Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition;
using Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    internal class StorageAccountImpl :
        GroupableResource<
            IStorageAccount,
            StorageAccountInner,
            StorageAccountImpl,
            IStorageManager,
            IWithGroup,
            IWithCreate,
            IWithCreate,
            IUpdate>,
        IStorageAccount,
        IDefinition,
        StorageAccount.Update.IUpdate
    {
        private string name;
        private StorageAccountCreateParametersInner createParameters;
        private StorageAccountUpdateParametersInner updateParameters;
        private IList<StorageAccountKey> cachedAccountKeys;

        private IStorageAccountsOperations client;


        internal StorageAccountImpl(string name,
            Management.Storage.Fluent.Models.StorageAccountInner innerObject,
            IStorageAccountsOperations client,
            IStorageManager manager) : base(name, innerObject, manager)
        {
            this.name = name;
            createParameters = new StorageAccountCreateParametersInner();
            updateParameters = new StorageAccountUpdateParametersInner();
            this.client = client;
        }

        #region Getters

        public AccessTier AccessTier
        {
            get
            {
                return Inner.AccessTier.HasValue ? 
                    Inner.AccessTier.Value :
                    default(AccessTier);
            }
        }

        public AccountStatuses AccountStatuses
        {
            get
            {
                return new AccountStatuses(Inner.StatusOfPrimary, Inner.StatusOfSecondary);
            }
        }

        public DateTime CreationTime
        {
            get
            {
                return Inner.CreationTime.HasValue ? 
                    Inner.CreationTime.Value :
                    default(DateTime);
            }
        }

        public CustomDomain CustomDomain
        {
            get
            {
                return Inner.CustomDomain;
            }
        }

        public Encryption Encryption
        {
            get
            {
                return Inner.Encryption;
            }
        }

        public PublicEndpoints EndPoints
        {
            get
            {
                return new PublicEndpoints(Inner.PrimaryEndpoints, Inner.SecondaryEndpoints);
            }
        }

        public Kind Kind
        {
            get
            {
                return Inner.Kind.HasValue ? 
                    Inner.Kind.Value :
                    default(Kind);
            }
        }

        public DateTime LastGeoFailoverTime
        {
            get
            {
                return Inner.LastGeoFailoverTime.HasValue ? 
                    Inner.LastGeoFailoverTime.Value : 
                    default(DateTime);
            }
        }

        public ProvisioningState ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState.HasValue ? 
                    Inner.ProvisioningState.Value : 
                    default(ProvisioningState);
            }
        }

        public Sku Sku
        {
            get
            {
                return Inner.Sku;
            }
        }

        public IList<StorageAccountKey> GetKeys()
        {
            if (cachedAccountKeys == null)
            {
                cachedAccountKeys = RefreshKeys();
            }
            return cachedAccountKeys;
        }

        #endregion

        #region Fluent setters 

        #region Definition setters

        public IWithCreate WithSku(SkuName skuName)
        {
            createParameters.Sku = new Sku()
            {
                Name = skuName
            };
            return this;
        }

        public IWithCreate WithAccessTier(AccessTier accessTier)
        {
            createParameters.AccessTier = accessTier;
            return this;
        }

        public IWithCreateAndAccessTier WithBlobStorageAccountKind()
        {
            createParameters.Kind = Management.Storage.Fluent.Models.Kind.BlobStorage;
            return this;
        }

        public IWithCreate WithGeneralPurposeAccountKind()
        {
            createParameters.Kind = Management.Storage.Fluent.Models.Kind.Storage;
            return this;
        }


        public IWithCreate WithCustomDomain(string name)
        {
            createParameters.CustomDomain = new CustomDomain(name);
            return this;
        }

        public IWithCreate WithCustomDomain(CustomDomain customDomain)
        {
            createParameters.CustomDomain = customDomain;
            return this;
        }

        public IWithCreate WithCustomDomain(string name, bool useSubDomain)
        {
            return WithCustomDomain(new CustomDomain()
            {
                Name = name,
                UseSubDomain = useSubDomain
            });
        }

        public IWithCreate WithEncryption(Encryption encryption)
        {
            createParameters.Encryption = encryption;
            return this;
        }


        #endregion

        #region Update setters

        IUpdate IWithAccessTier.WithAccessTier(AccessTier accessTier)
        {
            if (Inner.Kind != Management.Storage.Fluent.Models.Kind.BlobStorage)
            {
                throw new ArgumentException("Access tier cannot be changed for general purpose storage accounts");
            }
            updateParameters.AccessTier = accessTier;
            return this;
        }

        IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(string name)
        {
            updateParameters.CustomDomain = new CustomDomain(name);
            return this;
        }

        IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(CustomDomain customDomain)
        {
            updateParameters.CustomDomain = customDomain;
            return this;
        }

        IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(string name, bool useSubDomain)
        {
            updateParameters.CustomDomain = new CustomDomain()
            {
                Name = name,
                UseSubDomain = useSubDomain
            };
            return this;
        }

        IUpdate StorageAccount.Update.IWithCustomDomain.WithoutCustomDomain()
        {
            updateParameters.CustomDomain = new CustomDomain
            {
                Name = ""
            };
            return this;
        }

        IUpdate StorageAccount.Update.IWithSku.WithSku(SkuName skuName)
        {
            updateParameters.Sku = new Sku()
            {
                Name = skuName
            };
            return this;
        }

        IUpdate StorageAccount.Update.IWithEncryption.WithEncryption(Encryption encryption)
        {
            updateParameters.Encryption = encryption;
            return this;
        }

        #endregion

        #endregion

        #region Actions 

        public IList<StorageAccountKey> RefreshKeys()
        {
            var storageAccountListKeysResultInner = client.ListKeys(ResourceGroupName, Name);
            cachedAccountKeys = storageAccountListKeysResultInner.Keys;
            return cachedAccountKeys;
        }

        public IList<StorageAccountKey> RegenerateKey(string keyName)
        {
            var storageAccountListKeysResultInner = client.RegenerateKey(ResourceGroupName, Name, keyName);
            cachedAccountKeys = storageAccountListKeysResultInner.Keys;
            return cachedAccountKeys;
        }

        #endregion

        #region Implementation of IRefreshable interface

        public override IStorageAccount Refresh()
        {
            var response = client.GetProperties(ResourceGroupName, Name);
            SetInner(response);
            return this;
        }

        #endregion

        #region Implementation of IUpdatable interface

        public override IUpdate Update()
        {
            updateParameters = new StorageAccountUpdateParametersInner();
            return this;
        }

        #endregion


        #region Implementation of IResourceCreator interface

        public override async Task<IStorageAccount> CreateResourceAsync(CancellationToken cancellationToken)
        {
            if (this.newGroup != null)
            {
                IResource rg = this.CreatedResource(newGroup.Key);
            }

            createParameters.Location = RegionName;
            createParameters.Tags = Inner.Tags;
            var response = await client.CreateAsync(ResourceGroupName, this.name, createParameters, cancellationToken);
            SetInner(response);
            return this;
        }

        public override async Task<IStorageAccount> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            // overriding the base.ApplyAsync here since the parameter for update is different from the one for create.
            var response = await client.UpdateAsync(ResourceGroupName, this.name, updateParameters, cancellationToken);
            SetInner(response);
            return this;
        }

        #endregion
    }
}
