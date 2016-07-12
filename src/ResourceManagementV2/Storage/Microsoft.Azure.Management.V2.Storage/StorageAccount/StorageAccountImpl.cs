using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Storage
{
    public class StorageAccountImpl :
        IStorageAccount,
        StorageAccount.Definition.IDefinition,
        StorageAccount.Update.IUpdate
    {
        public string Key
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public AccessTier accessTier()
        {
            throw new NotImplementedException();
        }

        public AccountStatus accountStatuses()
        {
            throw new NotImplementedException();
        }

        public Task<IStorageAccount> ApplyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IStorageAccount> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public DateTime creationTime()
        {
            throw new NotImplementedException();
        }

        public CustomDomain customDomain()
        {
            throw new NotImplementedException();
        }

        public Encryption encryption()
        {
            throw new NotImplementedException();
        }

        public PublicEndpoints endPoints()
        {
            throw new NotImplementedException();
        }

        public Kind kind()
        {
            throw new NotImplementedException();
        }

        public DateTime lastGeoFailoverTime()
        {
            throw new NotImplementedException();
        }

        public ProvisioningState provisioningState()
        {
            throw new NotImplementedException();
        }

        public Sku sku()
        {
            throw new NotImplementedException();
        }

        #region Fluent setters 

        #region Definition setters

        public StorageAccount.Definition.IWithGroup withRegion(string regionName)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithGroup WithNewResourceGroup()
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithGroup WithNewResourceGroup(ICreatable<IResourceGroup> creatable)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithGroup WithNewResourceGroup(string name)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithGroup WithExistingResourceGroup(IResourceGroup resourceGroup)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithGroup WithExistingResourceGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithCreate WithSku(SkuName skuName)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithCreate WithAccessTier(AccessTier accessTier)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithCreateAndAccessTier withBlobStorageAccountKind()
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithCreate withCustomDomain(string name)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithCreate withCustomDomain(CustomDomain customDomain)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithCreate withCustomDomain(string name, bool useSubDomain)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithCreate WithEncryption(Encryption encryption)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Definition.IWithCreate WithGeneralPurposeAccountKind()
        {
            throw new NotImplementedException();
        }

        StorageAccount.Definition.IWithCreate Resource.Definition.IWithTags<StorageAccount.Definition.IWithCreate>.withTags(IDictionary<string, string> tags)
        {
            throw new NotImplementedException();
        }

        StorageAccount.Definition.IWithCreate Resource.Definition.IWithTags<StorageAccount.Definition.IWithCreate>.withTag(string key, string value)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Update setters 

        StorageAccount.Update.IUpdate StorageAccount.Update.IWithAccessTier.WithAccessTier(AccessTier accessTier)
        {
            throw new NotImplementedException();
        }

        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.withCustomDomain(string name)
        {
            throw new NotImplementedException();
        }

        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.withCustomDomain(CustomDomain customDomain)
        {
            throw new NotImplementedException();
        }

        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.withCustomDomain(string name, bool useSubDomain)
        {
            throw new NotImplementedException();
        }

        StorageAccount.Update.IUpdate StorageAccount.Update.IWithSku.WithSku(SkuName skuName)
        {
            throw new NotImplementedException();
        }

        public StorageAccount.Update.IUpdate withoutTag(string key)
        {
            throw new NotImplementedException();
        }

        StorageAccount.Update.IUpdate Resource.Update.IWithTags<StorageAccount.Update.IUpdate>.withTag(string key, string value)
        {
            throw new NotImplementedException();
        }

        StorageAccount.Update.IUpdate Resource.Update.IWithTags<StorageAccount.Update.IUpdate>.withTags(IDictionary<string, string> tags)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
