// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update;
    using System.Collections.Generic;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for IStorageAccount.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuaW1wbGVtZW50YXRpb24uU3RvcmFnZUFjY291bnRJbXBs
    internal partial class StorageAccountImpl  :
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
        private StorageAccountCreateParametersInner createParameters;
        private StorageAccountUpdateParametersInner updateParameters;

        ///GENMHASH:9EC86FDAF9C3238B45EB0EE4355F4919:01A8E19E4477D51C1F8BB7C63F151C69
        internal StorageAccountImpl(string name, StorageAccountInner innerModel, IStorageManager storageManager) : base(name, innerModel, storageManager)
        {
            createParameters = new StorageAccountCreateParametersInner();
        }

        ///GENMHASH:314904A5E85B219428D83117662B69FD:F7D362F18E06781D864DECF6CC7D3C61
        public AccountStatuses AccountStatuses()
        {
            return new AccountStatuses(Inner.StatusOfPrimary, Inner.StatusOfSecondary);
        }

        public Sku Sku()
        {
            return Inner.Sku;
        }

        ///GENMHASH:C4C0D4751CA4E1904C31CE6DF0B02AC3:B5986EB96489F714DC052E1136F06A45
        public Kind Kind()
        {
            // TODO: In the next major version upgrade of SDK change return type to nullable
            //       returning the default enum value when server returns null is not expected
            return Inner.Kind.HasValue ? Inner.Kind.Value : default(Kind);
        }

        ///GENMHASH:BCE4AA46C905DCE36E6D5BDD93BA93B0:1B56C35879CE652985BD4F328B841261
        public DateTime CreationTime()
        {
            return Inner.CreationTime.HasValue ? Inner.CreationTime.Value : default(DateTime);
        }

        ///GENMHASH:13C190C95339C5E47A33E6FC4C200B03:5E23174652AE3CE52750F1DC01FB1134
        public CustomDomain CustomDomain()
        {
            return Inner.CustomDomain;
        }

        ///GENMHASH:D0AE63FDB5966BAADB801257491052D1:E5706C7734A0BD35091288A8B0D51407
        public DateTime LastGeoFailoverTime()
        {
            return Inner.LastGeoFailoverTime.HasValue ? Inner.LastGeoFailoverTime.Value : default(DateTime);
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public ProvisioningState ProvisioningState()
        {
            // TODO: In the next major version upgrade of SDK change return type to nullable
            //       returning the default enum value when server returns null is not expected
            return Inner.ProvisioningState.HasValue ? Inner.ProvisioningState.Value : default(ProvisioningState);
        }

        ///GENMHASH:55B42F94DE82BCEA956E2090896DCEA5:93EB9B10265EA252D67B32BBB824A1F6
        public PublicEndpoints EndPoints()
        {
            return new PublicEndpoints(Inner.PrimaryEndpoints, Inner.SecondaryEndpoints);
        }

        ///GENMHASH:C7B3D3963622074C2FD00EB9A2E0FE72:84CE69ECBC3078017A0DFFC90EF4E3D9
        public Encryption Encryption()
        {
            return Inner.Encryption;
        }

        ///GENMHASH:E3CB6E557BDC02538C5A6963772F3FEF:349706F064F75B85DB63EF492656563E
        public StorageAccountEncryptionKeySource EncryptionKeySource()
        {
            if (this.Inner.Encryption == null || Microsoft.Azure.Management.Storage.Fluent.Models.Encryption.KeySource == null) {
                return null;
            }
            return StorageAccountEncryptionKeySource.Parse(Microsoft.Azure.Management.Storage.Fluent.Models.Encryption.KeySource);
        }

        ///GENMHASH:26FB96D5CAED2DAC6A25B7684BA6EA62:EA8D98221847758B674F32A5F6BA8D4E
        public IReadOnlyDictionary<StorageService, IStorageAccountEncryptionStatus> EncryptionStatuses()
        {
            var statuses = new Dictionary<StorageService, IStorageAccountEncryptionStatus>();
            if (this.Inner.Encryption != null && this.Inner.Encryption.Services != null)
            {
                // Status of blob service
                //
                // Status for other service needs to be added as storage starts supporting it
                statuses.Add(StorageService.Blob, new BlobServiceEncryptionStatusImpl(this.Inner.Encryption.Services));
            }
            else
            {
                statuses.Add(StorageService.Blob, new BlobServiceEncryptionStatusImpl(new EncryptionServices()));
            }
            return statuses;
        }

        ///GENMHASH:F740873A801629829EA1C3C98F4FDDC4:ACAFFE3955CCFBD0C2BC6D268AECA2BA
        public AccessTier AccessTier()
        {
            // TODO: In the next major version upgrade of SDK change return type to nullable
            //       returning the default enum value when server returns null is not expected
            return Inner.AccessTier.HasValue ? Inner.AccessTier.Value : default(AccessTier);
        }

        ///GENMHASH:E4DFA7EA15F8324FB60C810D0C96D2FF:1BCD5CF569F11AB6F798D4F3A5BFC786
        public IReadOnlyList<Models.StorageAccountKey> GetKeys()
        {
            return Extensions.Synchronize(() => GetKeysAsync());
        }

        ///GENMHASH:2751D8683222AD34691166D915065302:626481EC1E21C06AD0B6BDD35321AA29
        public async Task<System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var keysResultInner = await this.Manager.Inner.StorageAccounts.ListKeysAsync(this.ResourceGroupName, this.Name, cancellationToken);
            var keys = new List<StorageAccountKey>();
            keys.AddRange(keysResultInner.Keys);
            return keys;
        }

        ///GENMHASH:FE5C90217FF36474FA8DE7E91403E40F:8A9D1B7CB45D0ABAC76D65E99FADA580
        public IReadOnlyList<Models.StorageAccountKey> RegenerateKey(string keyName)
        {
            return Extensions.Synchronize(() => RegenerateKeyAsync(keyName));
        }

        ///GENMHASH:AC9981EE195A3F3ECFFF4F080A6FEAAD:0AE932BB7FDBF07328B9F81662B43B8C
        public async Task<System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>> RegenerateKeyAsync(string keyName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var regeneratedKeysResultInner = await Manager.Inner.StorageAccounts.RegenerateKeyAsync(this.ResourceGroupName, this.Name, keyName, cancellationToken);
            var regeneratedKeys = new List<StorageAccountKey>();
            regeneratedKeys.AddRange(regeneratedKeysResultInner.Keys);
            return regeneratedKeys;
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:F43E8F467DCA84E8666ED727725A26A8
        public async override Task<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await GetInnerAsync(cancellationToken);
            this.SetInner(inner);
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:59D34F73D07BE052EC4D175FC76C75FF
        protected override Task<Models.StorageAccountInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Note: Using GetPropertiesAsync instead of GetAsync to get extended information about the storage account.
            //
            return this.Manager.Inner.StorageAccounts.GetPropertiesAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }


        ///GENMHASH:B5E3D903BDA1F2A62441339A3042D8F4:ACEB925626760D001C056B5F56BA838D
        public StorageAccountImpl WithSku(SkuName skuName)
        {
            if (IsInCreateMode)
            {
                createParameters.Sku = new Sku
                {
                    Name = skuName
                };
            }
            else
            {
                updateParameters.Sku = new Sku
                {
                    Name = skuName
                };
            }
            return this;
        }

        ///GENMHASH:04DD7C0A29E2A433420E3CC1BCC83642:AE8E0FE7D34A8D01F4AED46E07861F2F
        public StorageAccountImpl WithBlobStorageAccountKind()
        {
            createParameters.Kind = Models.Kind.BlobStorage;
            // It is required to set AccessTier for BlobStorage kind, default it to Hot (as portal does)
            createParameters.AccessTier = Models.AccessTier.Hot;
            return this;
        }

        ///GENMHASH:A3DE4AE524C4F886153A43EE5DD7157A:ECF5D7B6B3EF47B86D11FDF931EFFD89
        public StorageAccountImpl WithGeneralPurposeAccountKind()
        {
            createParameters.Kind = Models.Kind.Storage;
            return this;
        }


        ///GENMHASH:E682EADDA53D09A6C953C211B424E76E:899F60366D3E50D4BBC789B5F2D80AA6
        public StorageAccountImpl WithEncryption(Encryption encryption)
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

        ///GENMHASH:56847EFF91F827802715E0B549682639:0E687FFBFFC0F8425CBCFEB059830CD5
        public StorageAccountImpl WithEncryption()
        {
            Encryption encryption;
            if (this.Inner.Encryption != null)
            {
                encryption = this.Inner.Encryption;
            }
            else
            {
                encryption = new Encryption();
            }
            if (encryption.Services == null)
            {
                encryption.Services = new EncryptionServices();
            }
            //if (Encryption.KeySource == null) // Unlike Java this is static in the generated code with value set to "Microsoft.Storage"
            //{
            //    encryption.KeySource = "Microsoft.Storage";
            //}

            // Enable encryption for blob service
            //
            if (encryption.Services.Blob == null)
            {
                encryption.Services.Blob = new EncryptionService();
            }
            encryption.Services.Blob.Enabled = true;
            // Code for enabling encryption for other service will be added as storage start supporting them.
            //
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


        ///GENMHASH:7A1BAFE758BD50E4AF6B50ADFDAD2EF5:360F4E1935623C8F70405940705BA359
        public StorageAccountImpl WithoutEncryption()
        {
            if (this.Inner.Encryption == null
                || this.Inner.Encryption.Services == null)
            {
                return this;
            }
            Encryption encryption = this.Inner.Encryption;
            // Disable encryption for blob service
            //
            if (encryption.Services.Blob == null)
            {
                return this;
            }
            encryption.Services.Blob.Enabled = false;
            // Code for disabling encryption for other service will be added as storage start supporting them.
           //
           updateParameters.Encryption = encryption;
            return this;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:D26CBA1CFC05445E2A90F41690FC5CB3
        public override IUpdate Update()
        {
            updateParameters = new StorageAccountUpdateParametersInner();
            return this;
        }

        ///GENMHASH:C6CC40946571810DF92A3D04D369CBCD:391ADF63D3B3B254E14435035F093D3D
        public StorageAccountImpl WithCustomDomain(CustomDomain customDomain)
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


        ///GENMHASH:870B1F6CF318C295B15B16948090E5A0:8CB56B0910716CE2C6BEC9D228235089
        public StorageAccountImpl WithCustomDomain(string name)
        {
            return WithCustomDomain(new CustomDomain() { Name = name });
        }

        ///GENMHASH:FFCBE36D39C79DC1A7BAEB75300E5C0B:7D6B565DFE17585F8E3B4BB3D13BDD7A
        public StorageAccountImpl WithCustomDomain(string name, bool useSubDomain)
        {
            return WithCustomDomain(new CustomDomain() { Name = name, UseSubDomain = useSubDomain });
        }

        ///GENMHASH:F3C7D5F595E480B52B33BC7ACD704928:6B5BD9106155829D3669430155DCDD3B
        public StorageAccountImpl WithAccessTier(AccessTier accessTier)
        {
            if (IsInCreateMode)
            {
                createParameters.AccessTier = accessTier;
            }
            else
            {
                if (this.Inner.Kind != Models.Kind.BlobStorage)
                {
                    throw new NotSupportedException($"Access tier can changed only for blob storage account type 'BlobStorage', the account type of this account is '{this.Inner.Kind}'");
                }
                updateParameters.AccessTier = accessTier;
            }
            return this;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:173D84E645D15368413A8D483FE286BF
        private async Task<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            updateParameters.Tags = this.Inner.Tags;
            var response = await Manager.Inner.StorageAccounts.UpdateAsync(this.ResourceGroupName, this.Name, updateParameters, cancellationToken);
            SetInner(response);
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:8F7656658E1EF4B6E2C2F36AD013828C
        public async override Task<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode)
            {
                createParameters.Location = this.RegionName;
                createParameters.Tags = Inner.Tags;
                await Manager.Inner.StorageAccounts.CreateAsync(ResourceGroupName, this.Name, createParameters, cancellationToken);
            }
             else
            {
                await UpdateResourceAsync(cancellationToken);
            }
            // Note: Using GetPropertiesAsync instead of GetAsync to get extended information about the storage account.
            //
            var response = await Manager.Inner.StorageAccounts.GetPropertiesAsync(this.ResourceGroupName, this.Name, cancellationToken);
            SetInner(response);
            return this;
        }
    }
}