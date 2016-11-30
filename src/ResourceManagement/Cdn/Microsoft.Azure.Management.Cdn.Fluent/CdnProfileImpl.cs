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
    public partial class CdnProfileImpl  :
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
        public string RegionName()
        {
            //$ return this.Inner.Location();

            return null;
        }

        public CdnProfileImpl WithStandardAkamaiSku()
        {
            //$ this.Inner
            //$ .WithSku(new Sku()
            //$ .WithName(SkuName.STANDARD_AKAMAI));
            //$ return this;

            return this;
        }

        public void StartEndpoint(string endpointName)
        {
            //$ this.endpointsClient.Start(this.ResourceGroupName(), this.Name(), endpointName);

        }

        public CdnProfileImpl WithPremiumVerizonSku()
        {
            //$ this.Inner
            //$ .WithSku(new Sku()
            //$ .WithName(SkuName.PREMIUM_VERIZON));
            //$ return this;

            return this;
        }

        public CheckNameAvailabilityResult CheckEndpointNameAvailability(string name)
        {
            //$ return this.MyManager.Profiles().CheckEndpointNameAvailability(name);

            return null;
        }

        public bool IsPremiumVerizon()
        {
            //$ if (this.Sku() != null
            //$ && this.Sku().Name() != null
            //$ && this.Sku().Name().Equals(SkuName.PREMIUM_VERIZON)) {
            //$ return true;
            //$ }
            //$ return false;

            return false;
        }

        public string GenerateSsoUri()
        {
            //$ SsoUriInner ssoUri = this.innerCollection.GenerateSsoUri(
            //$ this.ResourceGroupName(),
            //$ this.Name());
            //$ if (ssoUri != null) {
            //$ return ssoUri.SsoUriValue();
            //$ }
            //$ return null;

            return null;
        }

        internal CdnProfileImpl(string name, ProfileInner innerModel, IProfilesOperations innerCollection, IEndpointsOperations endpointsClient, IOriginsOperations originsClient, ICustomDomainsOperations customDomainsClient, CdnManager cdnManager)
        {
            //$ {
            //$ super(name, innerModel, cdnManager);
            //$ this.innerCollection = innerCollection;
            //$ this.endpointsClient = endpointsClient;
            //$ this.originsClient = originsClient;
            //$ this.customDomainsClient = customDomainsClient;
            //$ this.endpointsImpl = new CdnEndpointsImpl(this.endpointsClient,
            //$ this.originsClient,
            //$ this.customDomainsClient,
            //$ this);
            //$ }

        }

        public string ResourceState()
        {
            //$ return this.Inner.ResourceState().ToString();

            return null;
        }

        public CdnEndpointImpl UpdateEndpoint(string name)
        {
            //$ return this.endpointsImpl.UpdateEndpoint(name);

            return null;
        }

        public Sku Sku()
        {
            //$ return this.Inner.Sku();

            return null;
        }

        public async Task<ICdnProfile> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ CdnProfileImpl self = this;
            //$ 
            //$ return self.EndpointsImpl.CommitAndGetAllAsync()
            //$ .FlatMap(new Func1<List<CdnEndpointImpl>, Observable<? extends CdnProfile>>() {
            //$ public Observable<? extends CdnProfile> call(List<CdnEndpointImpl> endpoints) {
            //$ return innerCollection.UpdateAsync(resourceGroupName(), name(), Inner.GetTags())
            //$ .Map(new Func1<ProfileInner, CdnProfile>() {
            //$ @Override
            //$ public CdnProfile call(ProfileInner profileInner) {
            //$ self.SetInner(profileInner);
            //$ return self;
            //$ }
            //$ });
            //$ }
            //$ });

            return null;
        }

        public CdnEndpointImpl DefineNewEndpoint()
        {
            //$ return this.endpointsImpl.DefineNewEndpoint();

            return null;
        }

        public CdnEndpointImpl DefineNewEndpoint(string name)
        {
            //$ return this.endpointsImpl.DefineNewEndpoint(name);

            return null;
        }

        public CdnEndpointImpl DefineNewEndpoint(string name, string endpointOriginHostname)
        {
            //$ return this.endpointsImpl.DefineNewEndpoint(name, endpointOriginHostname);

            return null;
        }

        public async Task<ICdnProfile> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ CdnProfileImpl self = this;
            //$ return innerCollection.CreateAsync(resourceGroupName(), name(), Inner)
            //$ .Map(new Func1<ProfileInner, CdnProfile>() {
            //$ @Override
            //$ public CdnProfile call(ProfileInner profileInner) {
            //$ self.SetInner(profileInner);
            //$ return self;
            //$ }
            //$ }).FlatMap(new Func1<CdnProfile, Observable<? extends CdnProfile>>() {
            //$ @Override
            //$ public Observable<? extends CdnProfile> call(CdnProfile profile) {
            //$ return self.EndpointsImpl.CommitAndGetAllAsync()
            //$ .Map(new Func1<List<CdnEndpointImpl>, CdnProfile>() {
            //$ @Override
            //$ public CdnProfile call(List<CdnEndpointImpl> endpoints) {
            //$ return self;
            //$ }
            //$ });
            //$ }
            //$ });

            return null;
        }

        public CdnEndpointImpl UpdatePremiumEndpoint(string name)
        {
            //$ return this.endpointsImpl.UpdateEndpoint(name);

            return null;
        }

        public CdnEndpointImpl DefineNewPremiumEndpoint()
        {
            //$ return this.endpointsImpl.DefineNewEndpoint();

            return null;
        }

        public CdnEndpointImpl DefineNewPremiumEndpoint(string name)
        {
            //$ return this.DefineNewEndpoint(name);

            return null;
        }

        public CdnEndpointImpl DefineNewPremiumEndpoint(string name, string endpointOriginHostname)
        {
            //$ return this.DefineNewEndpoint(name, endpointOriginHostname);

            return null;
        }

        public IReadOnlyDictionary<string,ICdnEndpoint> Endpoints()
        {
            //$ return this.endpointsImpl.EndpointsAsMap();

            return null;
        }

        public IUpdate WithoutEndpoint(string name)
        {
            //$ this.endpointsImpl.Remove(name);
            //$ return this;

            return null;
        }

        public void LoadEndpointContent(string endpointName, IList<string> contentPaths)
        {
            //$ this.endpointsClient.LoadContent(this.ResourceGroupName(), this.Name(), endpointName, contentPaths);

        }

        public CdnProfileImpl Refresh()
        {
            //$ ProfileInner cdnProfileInner =
            //$ this.innerCollection.Get(this.ResourceGroupName(), this.Name());
            //$ this.SetInner(cdnProfileInner);
            //$ return this;

            return this;
        }

        internal CdnProfileImpl WithEndpoint(CdnEndpointImpl endpoint)
        {
            //$ this.endpointsImpl.AddEndpoint(endpoint);
            //$ return this;
            //$ }

            return this;
        }

        public void StopEndpoint(string endpointName)
        {
            //$ this.endpointsClient.Stop(this.ResourceGroupName(), this.Name(), endpointName);

        }

        public CdnProfileImpl WithStandardVerizonSku()
        {
            //$ this.Inner
            //$ .WithSku(new Sku()
            //$ .WithName(SkuName.STANDARD_VERIZON));
            //$ return this;

            return this;
        }

        public CdnProfileImpl WithNewEndpoint(string endpointOriginHostname)
        {
            //$ CdnEndpointImpl endpoint = this.endpointsImpl.DefineNewEndpointWithOriginHostname(endpointOriginHostname);
            //$ this.endpointsImpl.AddEndpoint(endpoint);
            //$ return this;

            return this;
        }

        public CdnProfileImpl WithNewPremiumEndpoint(string endpointOriginHostname)
        {
            //$ return this.WithNewEndpoint(endpointOriginHostname);

            return this;
        }

        public CustomDomainValidationResult ValidateEndpointCustomDomain(string endpointName, string hostName)
        {
            //$ return new CustomDomainValidationResult(
            //$ this.endpointsClient.ValidateCustomDomain(
            //$ this.ResourceGroupName(),
            //$ this.Name(),
            //$ endpointName,
            //$ hostName));

            return null;
        }

        public void PurgeEndpointContent(string endpointName, IList<string> contentPaths)
        {
            //$ this.endpointsClient.PurgeContent(this.ResourceGroupName(), this.Name(), endpointName, contentPaths);

        }
    }
}