// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System.Threading;
using Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition;
using Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

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
        IUpdate
    {
        private string name;
        private StorageAccountCreateParametersInner createParameters;
        private StorageAccountUpdateParametersInner updateParameters;
        private IReadOnlyList<StorageAccountKey> cachedAccountKeys;

        internal StorageAccountImpl(string name, StorageAccountInner innerObject, IStorageManager manager)
            : base(name, innerObject, manager)
        {
            this.name = name;
            createParameters = new StorageAccountCreateParametersInner();
            updateParameters = new StorageAccountUpdateParametersInner();
        }

        #region Accessors
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
        #endregion


        #region Actions

        public IReadOnlyList<StorageAccountKey> GetKeys()
        {
            return Extensions.Synchronize(() => GetKeysAsync());
        }

        public async Task<IReadOnlyList<StorageAccountKey>> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (cachedAccountKeys == null)
            {
                cachedAccountKeys = await RefreshKeysAsync(cancellationToken);
            }
            return cachedAccountKeys;
        }

        public async Task<IReadOnlyList<StorageAccountKey>> RefreshKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var storageAccountListKeysResultInner = await Manager.Inner.StorageAccounts.ListKeysAsync(
                ResourceGroupName,
                Name,
                cancellationToken);
            var list = new List<StorageAccountKey>();
            list.AddRange(storageAccountListKeysResultInner.Keys);
            cachedAccountKeys = list;
            return cachedAccountKeys;
        }

        public IReadOnlyList<StorageAccountKey> RegenerateKey(string keyName)
        {
            return Extensions.Synchronize(() => RegenerateKeyAsync(keyName));
        }

        public async Task<IReadOnlyList<StorageAccountKey>> RegenerateKeyAsync(string keyName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var storageAccountListKeysResultInner = await Manager.Inner.StorageAccounts.RegenerateKeyAsync(
                ResourceGroupName,
                Name,
                keyName,
                cancellationToken);
            var list = new List<StorageAccountKey>();
            list.AddRange(storageAccountListKeysResultInner.Keys);
            cachedAccountKeys = list;
            return list;
        }

        protected override async Task<StorageAccountInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.StorageAccounts.GetPropertiesAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        public override IUpdate Update()
        {
            updateParameters = new StorageAccountUpdateParametersInner();
            return this;
        }

        public async override Task<IStorageAccount> CreateResourceAsync(CancellationToken cancellationToken)
        {
            if (this.newGroup != null)
            {
                var rg = this.CreatedResource(newGroup.Key);
            }

            createParameters.Location = RegionName;
            createParameters.Tags = Inner.Tags;
            var response = await Manager.Inner.StorageAccounts.CreateAsync(ResourceGroupName, this.name, createParameters, cancellationToken);
            SetInner(response);
            return this;
        }

        public async override Task<IStorageAccount> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            // overriding the base.ApplyAsync here since the parameter for update is different from the one for create.
            updateParameters.Tags = Inner.Tags;
            var response = await Manager.Inner.StorageAccounts.UpdateAsync(ResourceGroupName, this.name, updateParameters, cancellationToken);
            SetInner(response);
            return this;
        }

        #endregion


        #region Withers

        #region WithSku
        internal StorageAccountImpl WithSku(SkuName skuName)
        {
            var sku = new Sku()
            {
                Name = skuName
            };
            if (IsInCreateMode)
            {
                createParameters.Sku = sku;
            }
            else
            {
                updateParameters.Sku = sku;
            }
            return this;
        }

        IWithCreate StorageAccount.Definition.IWithSku.WithSku(SkuName skuName)
        {
            return WithSku(skuName);
        }

        IUpdate StorageAccount.Update.IWithSku.WithSku(SkuName skuName)
        {
            return WithSku(skuName);
        }
        #endregion

        #region WithAccountKind
        internal StorageAccountImpl WithBlobStorageAccountKind()
        {
            if (IsInCreateMode)
            {
                createParameters.Kind = Kind.Storage;
            }
            return this;
        }

        internal StorageAccountImpl WithGeneralPurposeAccountKind()
        {
            if (IsInCreateMode)
            {
                createParameters.Kind = Kind.Storage;
            }
            return this;
        }

        IWithCreateAndAccessTier StorageAccount.Definition.IWithBlobStorageAccountKind.WithBlobStorageAccountKind()
        {
            return WithBlobStorageAccountKind();
        }

        IWithCreate StorageAccount.Definition.IWithGeneralPurposeAccountKind.WithGeneralPurposeAccountKind()
        {
            return WithGeneralPurposeAccountKind();
        }

        #endregion

        #region WithAccessTier
        internal StorageAccountImpl WithAccessTier(AccessTier accessTier)
        {
            if (IsInCreateMode)
            {
                createParameters.AccessTier = accessTier;
            }
            else
            {
                updateParameters.AccessTier = accessTier;
            }
            return this;
        }

        IWithCreate StorageAccount.Definition.IWithCreateAndAccessTier.WithAccessTier(AccessTier accessTier)
        {
            return WithAccessTier(accessTier);
        }

        IUpdate StorageAccount.Update.IWithAccessTier.WithAccessTier(AccessTier accessTier)
        {
            return WithAccessTier(accessTier);
        }
        #endregion

        #region WithCustomDomain
        internal StorageAccountImpl WithCustomDomain(string name)
        {
            if (IsInCreateMode)
            {
                createParameters.CustomDomain = new CustomDomain(name);
            }
            else
            {
                updateParameters.CustomDomain = new CustomDomain(name);
            }
            return this;
        }

        IWithCreate StorageAccount.Definition.IWithCustomDomain.WithCustomDomain(string name)
        {
            return WithCustomDomain(name);
        }

        IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(string name)
        {
            return WithCustomDomain(name);
        }

        internal StorageAccountImpl WithCustomDomain(CustomDomain customDomain)
        {
            if (IsInCreateMode)
            {
                createParameters.CustomDomain = customDomain;
            }
            else
            {
                updateParameters.CustomDomain = customDomain;
            }
            return this;
        }

        IWithCreate StorageAccount.Definition.IWithCustomDomain.WithCustomDomain(CustomDomain customDomain)
        {
            return WithCustomDomain(customDomain);
        }

        IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(CustomDomain customDomain)
        {
            return WithCustomDomain(customDomain);
        }

        internal StorageAccountImpl WithCustomDomain(string name, bool useSubDomain)
        {
            return WithCustomDomain(new CustomDomain()
            {
                Name = name,
                UseSubDomain = useSubDomain
            });
        }

        IWithCreate StorageAccount.Definition.IWithCustomDomain.WithCustomDomain(string name, bool useSubDomain)
        {
            return WithCustomDomain(name, useSubDomain);
        }

        IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(string name, bool useSubDomain)
        {
            return WithCustomDomain(name, useSubDomain);
        }
        #endregion

        #region WithEncryption
        internal StorageAccountImpl WithEncryption(Encryption encryption)
        {
            if (IsInCreateMode)
            {
                createParameters.Encryption = encryption;
            }
            else
            {
                updateParameters.Encryption = encryption;
            }
            return this;
        }

        IUpdate StorageAccount.Update.IWithEncryptionBeta.WithEncryption(Encryption encryption)
        {
            return WithEncryption(encryption);
        }

        IWithCreate StorageAccount.Definition.IWithEncryptionBeta.WithEncryption(Encryption encryption)
        {
            return WithEncryption(encryption);
        }
        #endregion

        #endregion
    }
}
