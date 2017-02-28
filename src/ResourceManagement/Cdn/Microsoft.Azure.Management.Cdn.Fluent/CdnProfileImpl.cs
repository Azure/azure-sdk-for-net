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
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNkbi5pbXBsZW1lbnRhdGlvbi5DZG5Qcm9maWxlSW1wbA==
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
        private CdnEndpointsImpl endpointsImpl;

        ///GENMHASH:6E7FC7AC8D073A3C3B9DDD1D764ADF68:9685139DF186DEC19F0A0EDA4B91F24C
        public CdnProfileImpl WithStandardAkamaiSku()
        {
            Inner.Sku = new Sku(SkuName.StandardAkamai);
            return this;
        }

        ///GENMHASH:065B0985A869BCEF0E134ADF57B0D802:240A274244B1B50EF40AC7C739B1E9FF
        public void StartEndpoint(string endpointName)
        {
            Manager.Inner.Endpoints.Start(ResourceGroupName, Name, endpointName);
        }

        ///GENMHASH:0C4071C9FB9B1B9D467AC6C4D4BF2C8F:A9DD6B4B67E69C5141C1637E3D1687C9
        public CdnProfileImpl WithPremiumVerizonSku()
        {
            Inner.Sku = new Sku(SkuName.PremiumVerizon);
            return this;
        }

        ///GENMHASH:8B3976582303B73AC81C5220073E2D55:69E52DD352A82A03AAFE4D4C2DD8561B
        public CheckNameAvailabilityResult CheckEndpointNameAvailability(string name)
        {
            return Manager.Profiles.CheckEndpointNameAvailability(name);
        }

        ///GENMHASH:636F3D57A21F57280580F7C29A78FFAD:9DF5985197AB928F69A541F4FD70E843
        public bool IsPremiumVerizon()
        {
            if (Sku() != null && Sku().Name != null && 
                Sku().Name.Equals(SkuName.PremiumVerizon, System.StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        ///GENMHASH:1D5C24C8FDD38263C467FE7510F78581:E048FFEEE712FB796C54C50F28CCEB2A
        public string GenerateSsoUri()
        {
            SsoUriInner ssoUri = Manager.Inner.Profiles.GenerateSsoUri(ResourceGroupName, Name);
            if (ssoUri != null)
            {
                return ssoUri.SsoUriValue;
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:354CBBDA97F05BB45365CF6ACDACFE6A:8FB5265E82D3754CF30BC19DF6A29958
		internal  CdnProfileImpl(string name, ProfileInner innerModel, ICdnManager cdnManager)
            : base(name, innerModel, cdnManager)
        {
            endpointsImpl = new CdnEndpointsImpl(this);
        }

        ///GENMHASH:DEAE39A7D24B41C1AF6ABFA406FD058B:D168A69FDBBD9E3F4C438F385B147840
        public string ResourceState()
        {
			return Inner.ResourceState;
        }

        ///GENMHASH:1813B9F987B61B140F89FFDE640AC0CA:A6F445874DBD721BE222ABA208139C51
        public CdnEndpointImpl UpdateEndpoint(string name)
        {
            return this.endpointsImpl.UpdateEndpoint(name);
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:43E446F640DC3345BDBD9A3378F2018A
        public Sku Sku()
        {
			return Inner.Sku;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:9A2D97FEFEBDC31898D678B6141E3DC7
        public async Task<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await endpointsImpl.CommitAndGetAllAsync(cancellationToken);
            ProfileInner profileInner = await Manager.Inner.Profiles.UpdateAsync(ResourceGroupName, Name, Inner.Tags, cancellationToken);
            SetInner(profileInner);
            return this;
        }

        ///GENMHASH:CE727EB6CD3E52051798F68C984D8953:CF96437D34090B8504DE034FA55B0056
        public CdnEndpointImpl DefineNewEndpoint()
        {
            return this.endpointsImpl.DefineNewEndpoint();
        }

        ///GENMHASH:9754CC4582FF9A2DB0A7695F48B2CEF6:C0321AF0462F864D50D8BCC164CE22E5
        public CdnEndpointImpl DefineNewEndpoint(string name)
        {
            return this.endpointsImpl.DefineNewEndpoint(name);
        }

        ///GENMHASH:391E96CD689B8A8B7D37B118706D13A5:072B9169EDF91F1FD4FFACACF321FDCB
        public CdnEndpointImpl DefineNewEndpoint(string name, string endpointOriginHostname)
        {
            return this.endpointsImpl.DefineNewEndpoint(name, endpointOriginHostname);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:9AD2BD935C99676887AB71B491E35F6B
        public async override Task<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode)
            {
                ProfileInner profileInner = await Manager.Inner.Profiles.CreateAsync(ResourceGroupName, Name, Inner, cancellationToken);
                SetInner(profileInner);
                await endpointsImpl.CommitAndGetAllAsync(cancellationToken);
                return this;
            }
            else
            {
                return await UpdateResourceAsync(cancellationToken);
            }
        }

        ///GENMHASH:CED4C31F04DFF5EF81FCC871C6C7CF22:A6F445874DBD721BE222ABA208139C51
        public CdnEndpointImpl UpdatePremiumEndpoint(string name)
        {
            return endpointsImpl.UpdateEndpoint(name);
        }

        ///GENMHASH:BC3B022F2D314A290B55407D76224361:CF96437D34090B8504DE034FA55B0056
        public CdnEndpointImpl DefineNewPremiumEndpoint()
        {
            return endpointsImpl.DefineNewEndpoint();
        }

        ///GENMHASH:FA34CF7160AD7729636BCE15BED8638D:9D7B8A0D790CCE5F26C29A9160920F81
        public CdnEndpointImpl DefineNewPremiumEndpoint(string name)
        {
            return DefineNewEndpoint(name);
        }

        ///GENMHASH:46D791411DD6A20AA2489C65F0F00DA9:B6CADBAC2316DA81EAF011393A11FBC0
        public CdnEndpointImpl DefineNewPremiumEndpoint(string name, string endpointOriginHostname)
        {
            return DefineNewEndpoint(name, endpointOriginHostname);
        }

        ///GENMHASH:857966B02726928CA3D093D0F7C49139:1171147ED7EBE016D5632FA8DC5C7846
        public IReadOnlyDictionary<string,Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint> Endpoints()
        {
            return endpointsImpl.EndpointsAsMap();
        }

        ///GENMHASH:46B51A2A6E317FB877781A1B0B0CE163:15D25A4701DF3EF493AA498988C59982
        public IUpdate WithoutEndpoint(string name)
        {
            endpointsImpl.Remove(name);
            return this;
        }

        ///GENMHASH:84C320030DC557769AE852230C16E745:0450D3EE7EB5FBD3AA9977432B475274
        public void LoadEndpointContent(string endpointName, IList<string> contentPaths)
        {
            Manager.Inner.Endpoints.LoadContent(ResourceGroupName, Name, endpointName, contentPaths);
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:99295E9723E2B8FABFB8C4111423E7B2
        public override ICdnProfile Refresh()
        {
            ProfileInner cdnProfileInner = Manager.Inner.Profiles.Get(ResourceGroupName, Name);
            SetInner(cdnProfileInner);
            return this;
        }

        ///GENMHASH:37D0B9659C11E9B4AA5E39DEE4B0AB7D:C83A09045ECA07DB3EC59281710F2DEA
        internal CdnProfileImpl WithEndpoint(CdnEndpointImpl endpoint)
        {
            endpointsImpl.AddEndpoint(endpoint);
            return this;
        }

        ///GENMHASH:3100428FE3EA33121B09FE78BAEAFA03:F0478BED0750EBBA7D784E4831244725
        public void StopEndpoint(string endpointName)
        {
            Manager.Inner.Endpoints.Stop(this.ResourceGroupName, this.Name, endpointName);
        }

        ///GENMHASH:C6C1323E0A4FDE3D66F498AFAE74AAF7:F414D32545A9C48981123025A8BD63AA
        public CdnProfileImpl WithStandardVerizonSku()
        {
            Inner.Sku = new Sku(SkuName.StandardVerizon);
            return this;
        }

        ///GENMHASH:859E01CB1D8E4137DD26396CB298746E:C39A1AFF84D98022D4C43E7D60DACA36
        public CdnProfileImpl WithNewEndpoint(string endpointOriginHostname)
        {
            CdnEndpointImpl endpoint = endpointsImpl.DefineNewEndpointWithOriginHostname(endpointOriginHostname);
            endpointsImpl.AddEndpoint(endpoint);
            return this;
        }

        ///GENMHASH:7441BB87C3B54A163A737FFF3ECDA428:B3E0A4DCC238AD65810E5954EF6DEB7D
        public CdnProfileImpl WithNewPremiumEndpoint(string endpointOriginHostname)
        {
            return WithNewEndpoint(endpointOriginHostname);
        }

        ///GENMHASH:0B8B56A49D49CB3A5F0D927E7BE72FB6:7F4A6C2E5E29299025ECA372A28595FA
        public CustomDomainValidationResult ValidateEndpointCustomDomain(string endpointName, string hostName)
        {
            return new CustomDomainValidationResult(
                Manager.Inner.Endpoints.ValidateCustomDomain(ResourceGroupName, Name, endpointName, hostName));
        }

        ///GENMHASH:9CC05EB059EED242274D2BB7528C30E4:654DDC68AFFED4F57BCF13C5DD9C95AD
        public void PurgeEndpointContent(string endpointName, IList<string> contentPaths)
        {
            Manager.Inner.Endpoints.PurgeContent(ResourceGroupName, Name, endpointName, contentPaths);
        }		
    }
}
