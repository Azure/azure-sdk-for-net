/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.KeyVault
{

    using Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.KeyVault.Models;
    using Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Models;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Linq;
    using Microsoft.Azure.Management.V2.Resource;
    using Management.KeyVault;
    using Graph.RBAC;
    using System;

    /// <summary>
    /// Implementation for Vault and its parent interfaces.
    /// </summary>
    public partial class VaultImpl  :
        GroupableResource<IVault, 
            VaultInner,
            Rest.Azure.Resource,
            VaultImpl,
            IKeyVaultManager,
            IWithGroup,
            Vault.Definition.IWithAccessPolicy,
            IWithCreate,
            IUpdate>,
        IVault,
        IDefinition,
        IUpdate
    {
        private IVaultsOperations client;
        private IGraphRbacManager graphRbacManager;
        private IList<AccessPolicyImpl> accessPolicies;
        internal VaultImpl (string name, VaultInner innerObject, IVaultsOperations client, IKeyVaultManager manager, IGraphRbacManager graphRbacManager)
            : base(name, innerObject, manager)
        {
            this.client = client;
            this.graphRbacManager = graphRbacManager;
            this.accessPolicies = new List<AccessPolicyImpl>();
            if (innerObject != null && innerObject.Properties != null && innerObject.Properties.AccessPolicies != null)
            {
                foreach (var entry in innerObject.Properties.AccessPolicies)
                {
                    this.accessPolicies.Add(new AccessPolicyImpl(entry, this));
                }
            }
        }

        public string VaultUri
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.VaultUri;
            }
        }

        public string TenantId
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                if (Inner.Properties.TenantId == null)
                {
                    return null;
                }
                return Inner.Properties.TenantId.ToString();
            }
        }
        public Sku Sku
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Sku;
            }
        }
        public IList<IAccessPolicy> AccessPolicies ()
        {
            return accessPolicies.Select(ap => (IAccessPolicy)ap).ToList();
        }

        public bool EnabledForDeployment
        {
            get
            {
                if (Inner.Properties == null || Inner.Properties.EnabledForDeployment == null)
                {
                    return false;
                }
                return Inner.Properties.EnabledForDeployment.Value;
            }
        }
        public bool EnabledForDiskEncryption
        {
            get
            {
                if (Inner.Properties == null || Inner.Properties.EnabledForDiskEncryption == null)
                {
                    return false;
                }
                return Inner.Properties.EnabledForDiskEncryption.Value;
            }
        }
        public bool EnabledForTemplateDeployment
        {
            get
            {
                if (Inner.Properties == null || Inner.Properties.EnabledForTemplateDeployment == null)
                {
                    return false;
                }
                return Inner.Properties.EnabledForTemplateDeployment.Value;
            }
        }
        public VaultImpl WithEmptyAccessPolicy ()
        {
            this.accessPolicies = new List<AccessPolicyImpl>();
            return this;
        }

        public VaultImpl WithoutAccessPolicy (string objectId)
        {
            foreach (var entry in this.accessPolicies)
            {
                if (entry.ObjectId == objectId)
                {
                    accessPolicies.Remove(entry);
                    break;
                }
            }
            return this;
        }

        public VaultImpl WithAccessPolicy (IAccessPolicy accessPolicy)
        {
            accessPolicies.Add((AccessPolicyImpl) accessPolicy);
            return this;
        }

        public AccessPolicyImpl DefineAccessPolicy ()
        {
            return new AccessPolicyImpl(new AccessPolicyEntry(), this);
        }

        public AccessPolicyImpl UpdateAccessPolicy (string objectId)
        {
            foreach (var entry in this.accessPolicies)
            {
                if (entry.ObjectId == objectId)
                {
                    return entry;
                }
            }
            throw new KeyNotFoundException(string.Format("Identity {0} not found in the access policies.", objectId));
        }

        public VaultImpl WithDeploymentEnabled ()
        {
            Inner.Properties.EnabledForDeployment = true;
            return this;
        }

        public VaultImpl WithDiskEncryptionEnabled ()
        {
            Inner.Properties.EnabledForDiskEncryption = true;
            return this;
        }

        public VaultImpl WithTemplateDeploymentEnabled ()
        {
            Inner.Properties.EnabledForTemplateDeployment = true;
            return this;
        }

        public VaultImpl WithDeploymentDisabled ()
        {
            Inner.Properties.EnabledForDeployment = false;
            return this;
        }

        public VaultImpl WithDiskEncryptionDisabled ()
        {
            Inner.Properties.EnabledForDiskEncryption = false;
            return this;
        }

        public VaultImpl WithTemplateDeploymentDisabled ()
        {
            Inner.Properties.EnabledForTemplateDeployment = false;
            return this;
        }

        public VaultImpl WithSku (SkuName skuName)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new VaultProperties();
            }
            Inner.Properties.Sku = new Sku(skuName);
            return this;
        }

        private async Task PopulateAccessPolicies (CancellationToken cancellationToken = default(CancellationToken))
        {
            var tasks = new List<Task>();
            foreach (var accessPolicy in accessPolicies)
            {
                if (accessPolicy.ObjectId == null) 
                {
                    if (accessPolicy.UserPrincipalName != null)
                    {
                        tasks.Add(graphRbacManager.Users.GetByUserPrincipalNameAsync(accessPolicy.UserPrincipalName, cancellationToken)
                            .ContinueWith(user => accessPolicy.ForObjectId(Guid.Parse(user.Result.ObjectId))));
                    }
                    else if (accessPolicy.ServicePrincipalName != null)
                    {
                        tasks.Add(graphRbacManager.ServicePrincipals.GetByServicePrincipalNameAsync(accessPolicy.ServicePrincipalName, cancellationToken)
                            .ContinueWith(servicePrincipal => accessPolicy.ForObjectId(Guid.Parse(servicePrincipal.Result.ObjectId))));
                    }
                    else
                    {
                        throw new ArgumentException("Access policy must specify Object ID");
                    }
                }
            }

            await Task.WhenAll(tasks);
        }

        public override async Task<IVault> CreateResourceAsync (CancellationToken cancellationToken = default(CancellationToken))
        {
            await PopulateAccessPolicies(cancellationToken);
            VaultCreateOrUpdateParametersInner parameters = new VaultCreateOrUpdateParametersInner()
            {
                Location = RegionName,
                Properties = Inner.Properties,
                Tags = Inner.Tags
            };
            parameters.Properties.AccessPolicies = new List<AccessPolicyEntry>();
            foreach (var accessPolicy in accessPolicies)
            {
                parameters.Properties.AccessPolicies.Add(accessPolicy.Inner);
            }
            var inner = await client.CreateOrUpdateAsync(ResourceGroupName, Name, parameters);
            SetInner(inner);
            return this;
        }

        public override async Task<IVault> Refresh ()
        {
            var inner = await client.GetAsync(ResourceGroupName, Name);
            SetInner(inner);
            return this;
        }
    }
}