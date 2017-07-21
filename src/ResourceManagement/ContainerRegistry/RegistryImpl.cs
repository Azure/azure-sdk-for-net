// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System;
    using Models;
    using ResourceManager.Fluent.Core;
    using Storage.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for Registry and its create and update interfaces.
    /// </summary>
    public partial class RegistryImpl :
        GroupableResource<
            IRegistry,
            RegistryInner,
            RegistryImpl,
            IRegistryManager,
            IWithGroup,
            IWithStorageAccount,
            IWithCreate,
            IUpdate>,
        IRegistry,
        IDefinition,
        IUpdate
    {
        private RegistryCreateParametersInner createParameters;
        private RegistryUpdateParametersInner updateParameters;
        private IStorageManager storageManager;
        private IStorageAccount storageAccount;
        private string creatableStorageAccountKey;

        public RegistryListCredentials RegenerateCredential(PasswordName passwordName)
        {
            return Extensions.Synchronize(() => this.RegenerateCredentialAsync(passwordName));
        }

        public override IUpdate Update()
        {
             updateParameters = new RegistryUpdateParametersInner();
             return base.Update();
        }

        public string StorageAccountName()
        {
             if (this.Inner.StorageAccount == null) {
                 return null;
             }
             
             return this.Inner.StorageAccount.Name;
        }

        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials> ListCredentialsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
             return await this.Manager.Inner.Registries.ListCredentialsAsync(this.ResourceGroupName, this.Name);
        }

        public RegistryImpl WithNewStorageAccount(string storageAccountName)
        {
            Storage.Fluent.StorageAccount.Definition.IWithGroup definitionWithGroup = this.storageManager
                .StorageAccounts
                .Define(storageAccountName)
                .WithRegion(this.RegionName);
            Storage.Fluent.StorageAccount.Definition.IWithCreate definitionAfterGroup;
            if (this.newGroup != null)
            {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(this.newGroup);
            }
            else
            {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(this.ResourceGroupName);
            }


            return WithNewStorageAccount(definitionAfterGroup);
        }

        public RegistryImpl WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            // This method's effect is NOT additive.
            if (this.creatableStorageAccountKey == null)
            {
                this.creatableStorageAccountKey = creatable.Key;
                this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            }

            return this;
        }

        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials> RegenerateCredentialAsync(PasswordName passwordName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Registries.RegenerateCredentialAsync(this.ResourceGroupName, this.Name, passwordName);
        }

        public override async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            RegistryImpl self = this;
            if (IsInCreateMode)
            {
                var storageAccountParameters = await this.HandleStorageSettingsAsync(cancellationToken);
                createParameters.StorageAccount = storageAccountParameters;
                createParameters.Location = this.RegionName.ToLower();
                createParameters.Tags = this.Inner.Tags;
                var registryInner = await this.Manager.Inner.Registries.CreateAsync(this.ResourceGroupName, this.Name, createParameters);
                this.SetInner(registryInner);
            } else {
                updateParameters.Tags = this.Inner.Tags;
                var registryInner = await this.Manager.Inner.Registries.UpdateAsync(this.ResourceGroupName, this.Name, updateParameters);
                self.SetInner(registryInner);
            }

            return null;
        }

        public Models.Sku Sku()
        {
             return this.Inner.Sku;
        }

        public bool AdminUserEnabled()
        {
            if (this.Inner.AdminUserEnabled == null ||
                !this.Inner.AdminUserEnabled.HasValue)
            {
                return false;
            }

            return this.Inner.AdminUserEnabled.Value;
        }

        public DateTime CreationDate()
        {
            if (this.Inner.CreationDate == null ||
                !this.Inner.CreationDate.HasValue)
            {
                return DateTime.MinValue;
            }

            return this.Inner.CreationDate.Value;
        }

        public RegistryImpl WithRegistryNameAsAdminUser()
        {
            if (this.IsInCreateMode) {
                this.createParameters.AdminUserEnabled = true;
            } else {
                this.updateParameters.AdminUserEnabled = true;
            }

            return this;
        }

        internal RegistryImpl(string name, 
            RegistryInner innerObject, 
            IRegistryManager manager, 
            IStorageManager storageManager)
            : base(name, innerObject, manager)
        {
            this.createParameters = new RegistryCreateParametersInner();
            var sku = new Models.Sku();
            sku.Name = "Basic";
            this.createParameters.Sku = sku;
            this.storageManager = storageManager;
        }

        public RegistryListCredentials ListCredentials()
        {
            return Extensions.Synchronize(() => this.ListCredentialsAsync());
        }

        public RegistryImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
             this.storageAccount = storageAccount;
             return this;
        }

        protected override async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
             return await this.Manager.Inner.Registries.GetAsync(this.ResourceGroupName, this.Name);
        }

        private async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.StorageAccountParameters> HandleStorageSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if(this.creatableStorageAccountKey != null)
            {
                this.storageAccount = this.CreatedResource(this.creatableStorageAccountKey) as IStorageAccount;
            }

            IReadOnlyList<StorageAccountKey> keys = await storageAccount.GetKeysAsync();
            StorageAccountParameters storageAccountParameters = new StorageAccountParameters();
            storageAccountParameters.Name = storageAccount.Name;
            storageAccountParameters.AccessKey = keys[0].Value;
            return storageAccountParameters;
        }

        public RegistryImpl WithoutRegistryNameAsAdminUser()
        {
            if (this.IsInCreateMode) {
                this.createParameters.AdminUserEnabled = false;
            } else {
                this.updateParameters.AdminUserEnabled = false;
            }

            return this;
        }

        public string LoginServerUrl()
        {
            return this.Inner.LoginServer;
        }
    }
}