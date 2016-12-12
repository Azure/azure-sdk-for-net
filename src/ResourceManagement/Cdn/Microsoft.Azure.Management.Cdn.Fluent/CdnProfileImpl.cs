// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using CdnProfile.Update;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent;
    using System.Threading;
    using CdnProfile.Definition;
    using Microsoft.Azure.Management.Cdn.Fluent.Models;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for CdnProfile.
    /// </summary>
    internal partial class CdnProfileImpl  :
        GroupableResource<
            ICdnProfile,
            ProfileInner,
            CdnProfileImpl,
            ICdnManager,
            IWithGroup,
            IWithSku,
            IWithCreate,
            IUpdate>,
        ICdnProfile,
        IDefinition,
        IUpdate
    {
        private IEndpointsOperations endpointsClient;
        private IOriginsOperations originsClient;
        private ICustomDomainsOperations customDomainsClient;
        private IProfilesOperations innerCollection;
        private CdnEndpointsImpl endpointsImpl;

        public string ResourceState
        {
            get
            {
                return this.Inner.ResourceState;
            }
        }

        public Sku Sku
        {
            get
            {
                return this.Inner.Sku;
            }
        }

        public CdnProfileImpl WithStandardAkamaiSku()
        {
            this.Inner.Sku = new Sku(SkuName.StandardAkamai);
            return this;
        }
        
        public CdnProfileImpl WithPremiumVerizonSku()
        {
            this.Inner.Sku = new Sku(SkuName.PremiumVerizon);
            return this;
        }

        public CdnProfileImpl WithStandardVerizonSku()
        {
            this.Inner.Sku = new Sku(SkuName.StandardVerizon);
            return this;
        }

        public CheckNameAvailabilityResult CheckEndpointNameAvailability(string name)
        {
            return this.Manager.Profiles.CheckEndpointNameAvailability(name);
        }

        public bool IsPremiumVerizon()
        {
            if (this.Sku != null && this.Sku.Name != null && 
                this.Sku.Name.Equals(SkuName.PremiumVerizon, System.StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public string GenerateSsoUri()
        {
            SsoUriInner ssoUri = this.innerCollection.GenerateSsoUri(
                this.ResourceGroupName,
                this.Name);

            if (ssoUri != null)
            {
                return ssoUri.SsoUriValue;
            }
            return null;
        }

        internal CdnProfileImpl(
            string name, 
            ProfileInner innerModel, 
            IProfilesOperations innerCollection, 
            IEndpointsOperations endpointsClient, 
            IOriginsOperations originsClient, 
            ICustomDomainsOperations customDomainsClient, 
            CdnManager cdnManager)
            : base(name, innerModel, cdnManager)
        {
            this.innerCollection = innerCollection;
            this.endpointsClient = endpointsClient;
            this.originsClient = originsClient;
            this.customDomainsClient = customDomainsClient;
            this.endpointsImpl = new CdnEndpointsImpl(
                this.endpointsClient,
                this.originsClient,
                this.customDomainsClient,
                this);
        }
        
        public CdnEndpointImpl UpdateEndpoint(string name)
        {
            return this.endpointsImpl.UpdateEndpoint(name);
        }
        
        public async Task<ICdnProfile> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await endpointsImpl.CommitAndGetAllAsync(cancellationToken);
            ProfileInner profileInner = await innerCollection.UpdateAsync(ResourceGroupName, Name, Inner.Tags, cancellationToken);
            this.SetInner(profileInner);
            return this;
        }
        
        public async override Task<ICdnProfile> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode)
            {
                ProfileInner profileInner = await innerCollection.CreateAsync(ResourceGroupName, Name, Inner, cancellationToken);
                this.SetInner(profileInner);
                await endpointsImpl.CommitAndGetAllAsync(cancellationToken);
                return this;
            }
            else
            {
                return await this.UpdateResourceAsync(cancellationToken);
            }
        }

        public CdnEndpointImpl DefineNewEndpoint()
        {
            return this.endpointsImpl.DefineNewEndpoint();
        }

        public CdnEndpointImpl DefineNewEndpoint(string name)
        {
            return this.endpointsImpl.DefineNewEndpoint(name);
        }

        public CdnEndpointImpl DefineNewEndpoint(string name, string endpointOriginHostname)
        {
            return this.endpointsImpl.DefineNewEndpoint(name, endpointOriginHostname);
        }

        public CdnEndpointImpl UpdatePremiumEndpoint(string name)
        {
            return this.endpointsImpl.UpdateEndpoint(name);
        }

        public CdnEndpointImpl DefineNewPremiumEndpoint()
        {
            return this.endpointsImpl.DefineNewEndpoint();
        }

        public CdnEndpointImpl DefineNewPremiumEndpoint(string name)
        {
            return this.DefineNewEndpoint(name);
        }

        public CdnEndpointImpl DefineNewPremiumEndpoint(string name, string endpointOriginHostname)
        {
            return this.DefineNewEndpoint(name, endpointOriginHostname);
        }

        public IReadOnlyDictionary<string,ICdnEndpoint> Endpoints()
        {
            return this.endpointsImpl.EndpointsAsMap();
        }

        public IUpdate WithoutEndpoint(string name)
        {
            this.endpointsImpl.Remove(name);
            return this;
        }
        
        public override ICdnProfile Refresh()
        {
            ProfileInner cdnProfileInner =
                this.innerCollection.Get(this.ResourceGroupName, this.Name);
            this.SetInner(cdnProfileInner);
            return this;
        }

        internal CdnProfileImpl WithEndpoint(CdnEndpointImpl endpoint)
        {
            this.endpointsImpl.AddEndpoint(endpoint);
            return this;
        }

        public void StartEndpoint(string endpointName)
        {
            this.endpointsClient.Start(this.ResourceGroupName, this.Name, endpointName);
        }

        public void StopEndpoint(string endpointName)
        {
            this.endpointsClient.Stop(this.ResourceGroupName, this.Name, endpointName);
        }
        
        public void PurgeEndpointContent(string endpointName, IList<string> contentPaths)
        {
            this.endpointsClient.PurgeContent(
                this.ResourceGroupName, 
                this.Name, 
                endpointName, 
                contentPaths);
        }

        public void LoadEndpointContent(string endpointName, IList<string> contentPaths)
        {
            this.endpointsClient.LoadContent(
                this.ResourceGroupName,
                this.Name,
                endpointName,
                contentPaths);
        }

        public CdnProfileImpl WithNewEndpoint(string endpointOriginHostname)
        {
            CdnEndpointImpl endpoint = this.endpointsImpl.DefineNewEndpointWithOriginHostname(endpointOriginHostname);
            this.endpointsImpl.AddEndpoint(endpoint);
            return this;
        }

        public CdnProfileImpl WithNewPremiumEndpoint(string endpointOriginHostname)
        {
            return this.WithNewEndpoint(endpointOriginHostname);
        }

        public CustomDomainValidationResult ValidateEndpointCustomDomain(string endpointName, string hostName)
        {
            return new CustomDomainValidationResult(
                this.endpointsClient.ValidateCustomDomain(
                    this.ResourceGroupName,
                    this.Name,
                    endpointName,
                    hostName));
        }
    }
}