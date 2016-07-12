using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using Microsoft.Azure.Management.V2.Resource.GroupableResource;
using Microsoft.Azure.Management.Storage;

namespace Microsoft.Azure.Management.V2.Storage
{
    internal class StorageAccountImpl :
        GroupableResourceImpl<IStorageAccount, Management.Storage.Models.StorageAccount, StorageAccountImpl, StorageManager>,
        IStorageAccount,
        StorageAccount.Definition.IDefinition,
        StorageAccount.Update.IUpdate
    {
        private string name;
        private StorageAccountCreateParameters createParameters;
        private StorageAccountUpdateParameters updateParameters;

        private IStorageAccountsOperations client;


        internal StorageAccountImpl(string name,
            Management.Storage.Models.StorageAccount innerObject,
            IStorageAccountsOperations client,
            StorageManager manager) : base(name, innerObject, manager)
        {
            this.name = name;
            createParameters = new StorageAccountCreateParameters();
            updateParameters = new StorageAccountUpdateParameters();
            this.client = client;
        }

        #region Getters

        public AccessTier? AccessTier
        {
            get
            {
                return Inner.AccessTier;
            }
        }

        public AccountStatuses AccountStatuses
        {
            get
            {
                return new AccountStatuses(Inner.StatusOfPrimary, Inner.StatusOfSecondary);
            }
        }

        public DateTime? CreationTime
        {
            get
            {
                return Inner.CreationTime;
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

        public Kind? Kind
        {
            get
            {
                return Inner.Kind;
            }
        }

        public DateTime? LastGeoFailoverTime
        {
            get
            {
                return Inner.LastGeoFailoverTime;
            }
        }

        public ProvisioningState? ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
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

        #region Fluent setters 

        #region Definition setters

        public new StorageAccount.Definition.IWithGroup WithRegion(string regionName)
        {
            base.WithRegion(regionName);
            return this;
        }

        public new StorageAccount.Definition.IWithGroup WithNewResourceGroup()
        {
            base.WithNewResourceGroup();
            return this;
        }

        public new StorageAccount.Definition.IWithGroup WithNewResourceGroup(ICreatable<IResourceGroup> creatable)
        {
            base.WithNewResourceGroup(creatable);
            return this;
        }

        public new StorageAccount.Definition.IWithGroup WithNewResourceGroup(string name)
        {
            base.WithNewResourceGroup(name);
            return this;
        }

        public new StorageAccount.Definition.IWithGroup WithExistingResourceGroup(IResourceGroup resourceGroup)
        {
            base.WithExistingResourceGroup(resourceGroup);
            return this;
        }

        public new StorageAccount.Definition.IWithGroup WithExistingResourceGroup(string groupName)
        {
            base.WithExistingResourceGroup(groupName);
            return this;
        }

        public StorageAccount.Definition.IWithCreate WithSku(SkuName skuName)
        {
            createParameters.Sku = new Sku()
            {
                Name = skuName
            };
            return this;
        }

        public StorageAccount.Definition.IWithCreate WithAccessTier(AccessTier accessTier)
        {
            createParameters.AccessTier = accessTier;
            return this;
        }

        public StorageAccount.Definition.IWithCreateAndAccessTier WithBlobStorageAccountKind()
        {
            createParameters.Kind = Management.Storage.Models.Kind.BlobStorage;
            return this;
        }

        public StorageAccount.Definition.IWithCreate WithCustomDomain(string name)
        {
            createParameters.CustomDomain = new CustomDomain(name);
            return this;
        }

        public StorageAccount.Definition.IWithCreate WithCustomDomain(CustomDomain customDomain)
        {
            createParameters.CustomDomain = customDomain;
            return this;
        }

        public StorageAccount.Definition.IWithCreate WithCustomDomain(string name, bool useSubDomain)
        {
            return WithCustomDomain(new CustomDomain()
            {
                Name = name,
                UseSubDomain = useSubDomain
            });
        }

        public StorageAccount.Definition.IWithCreate WithEncryption(Encryption encryption)
        {
            createParameters.Encryption = encryption;
            return this;
        }

        public StorageAccount.Definition.IWithCreate WithGeneralPurposeAccountKind()
        {
            createParameters.Kind = Management.Storage.Models.Kind.Storage;
            return this;
        }

        StorageAccount.Definition.IWithCreate Resource.Definition.IWithTags<StorageAccount.Definition.IWithCreate>.WithTags(IDictionary<string, string> tags)
        {
            base.WithTags(tags);
            return this;
        }

        StorageAccount.Definition.IWithCreate Resource.Definition.IWithTags<StorageAccount.Definition.IWithCreate>.WithTag(string key, string value)
        {
            base.WithTag(key, value);
            return this;
        }

        #endregion


        #region Update setters 

        StorageAccount.Update.IUpdate StorageAccount.Update.IWithAccessTier.WithAccessTier(AccessTier accessTier)
        {
            if (Inner.Kind != Management.Storage.Models.Kind.BlobStorage)
            {
                throw new ArgumentException("Access tier cannot be changed for general purpose storage accounts");
            }
            updateParameters.AccessTier = accessTier;
            return this;
        }

        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(string name)
        {
            updateParameters.CustomDomain = new CustomDomain(name);
            return this;
        }

        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(CustomDomain customDomain)
        {
            updateParameters.CustomDomain = customDomain;
            return this;
        }

        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(string name, bool useSubDomain)
        {
            updateParameters.CustomDomain = new CustomDomain()
            {
                Name = name,
                UseSubDomain = useSubDomain
            };
            return this;
        }

        StorageAccount.Update.IUpdate StorageAccount.Update.IWithSku.WithSku(SkuName skuName)
        {
            updateParameters.Sku = new Sku()
            {
                Name = skuName
            };
            return this;
        }

        public StorageAccount.Update.IUpdate withoutTag(string key)
        {
            base.WithoutTag(key);
            return this;
        }

        StorageAccount.Update.IUpdate Resource.Update.IWithTags<StorageAccount.Update.IUpdate>.WithTag(string key, string value)
        {
            base.WithTag(key, value);
            return this;
        }

        StorageAccount.Update.IUpdate Resource.Update.IWithTags<StorageAccount.Update.IUpdate>.WithTags(IDictionary<string, string> tags)
        {
            base.WithTags(tags);
            return this;
        }

        #endregion

        #endregion

        public override Task<IStorageAccount> Refresh()
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Update.IUpdate Update()
        {
            return this;
        }

        public Task<IStorageAccount> ApplyAsync()
        {
            throw new NotImplementedException();
        }

        public async new Task<IStorageAccount> CreateAsync()
        {
            return await base.CreateAsync();
        }

        protected override async Task CreateResourceAsync()
        {
            createParameters.Location = RegionName;
            createParameters.Tags = Inner.Tags;
            var response = await client.CreateWithHttpMessagesAsync(ResourceGroupName, Name, createParameters);
            SetInner(response.Body);
        }
    }
}
