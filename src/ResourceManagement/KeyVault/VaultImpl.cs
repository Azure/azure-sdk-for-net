// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent
{

    using Vault.Definition;
    using System.Collections.Generic;
    using Models;
    using Vault.Update;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Linq;
    using ResourceManager.Fluent;
    using Graph.RBAC.Fluent;
    using System;

    /// <summary>
    /// Implementation for Vault and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmtleXZhdWx0LmltcGxlbWVudGF0aW9uLlZhdWx0SW1wbA==
    internal partial class VaultImpl  :
        GroupableResource<IVault, 
            VaultInner,
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
        private IGraphRbacManager graphRbacManager;
        private IList<AccessPolicyImpl> accessPolicies;
        ///GENMHASH:E75D6B887F703BA75910BF996B59E45B:30C9A572991D1AB6921DBD5E8344AFAF
        internal VaultImpl (string name, VaultInner innerObject, IKeyVaultManager manager, IGraphRbacManager graphRbacManager)
            : base(name, innerObject, manager)
        {
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

        ///GENMHASH:FAAD3C3E07174E29B21DE058D968BBF7:A534A23FE2D228AC3080C1CF07E66439
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

        ///GENMHASH:DA183CCEBC00D21096D59D1B439F4E2F:FFCFE20B73A713E38ACED4776AC46C2C
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

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:DCCE63C0590230B4CFE00D1B7646DFE9
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

        ///GENMHASH:A4B5C79524255870A60CFDA07E865BBC:A881A75678053A99DDDBBD7F4D918F27
        public IList<IAccessPolicy> AccessPolicies
        {
            get
            {
                return accessPolicies.Select(ap => (IAccessPolicy)ap).ToList();
            }
        }

        ///GENMHASH:032C9B05DA12329F399E00C8E7D622BA:AEBBF9B6E0BE19BD64777AE3BCBA4694
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

        ///GENMHASH:760F392B9819F999D811AA3DF8CD6995:D72546C4354BCCA735CC554047B889E0
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

        ///GENMHASH:FB8FAE6C8DE1A864EF1BD60C4764B792:D453188CD9BA7FAB6F7075EADC992BFC
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

        ///GENMHASH:577E5E9CE0B513EB5189E6F44BB732C7:3949CE4CBC4994E8C88DF2E4815A8696
        public VaultImpl WithEmptyAccessPolicy ()
        {
            this.accessPolicies = new List<AccessPolicyImpl>();
            return this;
        }

        ///GENMHASH:BF5C974C7992D71D59A8BE2B5FFA9735:2CCFBF766FF017AFE0634B508567A0A7
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

        ///GENMHASH:95F821073A967350F605DCFDEE9C4F36:0AA6BCED9B5EF30513E45E352F8ADD43
        public VaultImpl WithAccessPolicy (IAccessPolicy accessPolicy)
        {
            accessPolicies.Add((AccessPolicyImpl) accessPolicy);
            return this;
        }

        ///GENMHASH:BCF2D31DA6ACC2C1FE7BDC9DC74816C3:7CE2DCE276A093BBCE8B68236538DCEE
        public AccessPolicyImpl DefineAccessPolicy ()
        {
            return new AccessPolicyImpl(new AccessPolicyEntry(), this);
        }

        ///GENMHASH:3AEEB786F759E7AE4D1CDECFE914787F:6AD9D0D3F38CAC761595B7A99B53F17A
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

        ///GENMHASH:E1C93AA0BBBD8356E9DB1218E7724613:EA22EAA4A75A2D4E53AFD4BF45481AC9
        public VaultImpl WithDeploymentEnabled ()
        {
            Inner.Properties.EnabledForDeployment = true;
            return this;
        }

        ///GENMHASH:22BA5A0B770282F6544D8D60FF1EB6B3:EA29FD68A346F94BA2C4B60B1973D9AA
        public VaultImpl WithDiskEncryptionEnabled ()
        {
            Inner.Properties.EnabledForDiskEncryption = true;
            return this;
        }

        ///GENMHASH:526C0B06DCB31F150274918FFB1642E2:8DB41F0F2AE630487FE7D9F880CE9C9D
        public VaultImpl WithTemplateDeploymentEnabled ()
        {
            Inner.Properties.EnabledForTemplateDeployment = true;
            return this;
        }

        ///GENMHASH:5BB8550126BE75DAD0B2AB7A5CDB59B2:3A0134537AEECA49CA9AC2C85D82FFA9
        public VaultImpl WithDeploymentDisabled ()
        {
            Inner.Properties.EnabledForDeployment = false;
            return this;
        }

        ///GENMHASH:7D19CF226982E29D18B8EBD4F54DC892:63C66769BC07A9D01F3B3AEAD827B8B2
        public VaultImpl WithDiskEncryptionDisabled ()
        {
            Inner.Properties.EnabledForDiskEncryption = false;
            return this;
        }

        ///GENMHASH:70F27F86F71ADC791D3B0F3867F86DED:E7AF7B9719E4E19ED550AE466CC34876
        public VaultImpl WithTemplateDeploymentDisabled ()
        {
            Inner.Properties.EnabledForTemplateDeployment = false;
            return this;
        }

        ///GENMHASH:B5E3D903BDA1F2A62441339A3042D8F4:E59E1393C8B2F3C07E87C9F34E983726
        public VaultImpl WithSku (SkuName skuName)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new VaultProperties();
            }
            Inner.Properties.Sku = new Sku(skuName);
            return this;
        }

        ///GENMHASH:1BFD0AD1E7180AAE5C7C7706268179BD:654FAB1549649BDDA9AAC1BB3468DBFB
        private async Task PopulateAccessPolicies(CancellationToken cancellationToken = default(CancellationToken))
        {
            var tasks = new List<Task>();
            foreach (var accessPolicy in accessPolicies)
            {
                if (accessPolicy.ObjectId == null || accessPolicy.ObjectId == Guid.Empty.ToString()) 
                {
                    if (accessPolicy.UserPrincipalName != null)
                    {
                        tasks.Add(graphRbacManager.Users.GetByNameAsync(accessPolicy.UserPrincipalName, cancellationToken)
                            .ContinueWith(
                                user => accessPolicy.ForObjectId(Guid.Parse(user.Result.Id)),
                                cancellationToken,
                                TaskContinuationOptions.ExecuteSynchronously,
                                TaskScheduler.Default));
                    }
                    else if (accessPolicy.ServicePrincipalName != null)
                    {
                        tasks.Add(graphRbacManager.ServicePrincipals.GetByNameAsync(accessPolicy.ServicePrincipalName, cancellationToken)
                            .ContinueWith(
                                servicePrincipal => accessPolicy.ForObjectId(Guid.Parse(servicePrincipal.Result.Id)),
                                cancellationToken,
                                TaskContinuationOptions.ExecuteSynchronously,
                                TaskScheduler.Default));
                    }
                    else
                    {
                        throw new ArgumentException("Access policy must specify Object ID");
                    }
                }
            }

            await Task.WhenAll(tasks);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:6825C2C979F565D012F22FFCBBFAB9ED
        public async override Task<IVault> CreateResourceAsync (CancellationToken cancellationToken = default(CancellationToken))
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
            var inner = await Manager.Inner.Vaults.CreateOrUpdateAsync(ResourceGroupName, Name, parameters, cancellationToken);
            SetInner(inner);
            return this;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:CC9FF17BB935059EB35312593856BE61
        protected override async Task<VaultInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.Vaults.GetAsync(ResourceGroupName, Name, cancellationToken);
        }
    }
}
