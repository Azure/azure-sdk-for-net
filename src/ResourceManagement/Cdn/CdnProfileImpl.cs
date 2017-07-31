// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using CdnProfile.Update;
    using System.Collections.Generic;
    using ResourceManager.Fluent;
    using System.Threading;
    using CdnProfile.Definition;
    using Models;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

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

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:3054A3D10ED7865B89395E7C007419C9
        public string RegionName()
        {
            return Inner.Location;
        }

        ///GENMHASH:072D2613985B28B6432C9976B5006846:5819234A0966E38A17A96E3DEE76716A
        public void PurgeEndpointContent(string endpointName, ISet<string> contentPaths)
        {
            PurgeEndpointContentAsync(endpointName, contentPaths).Wait();
        }

        ///GENMHASH:0B8B56A49D49CB3A5F0D927E7BE72FB6:15D778FA14DCB4E885FC219DB1E89EB7
        public CustomDomainValidationResult ValidateEndpointCustomDomain(string endpointName, string hostName)
        {
            return Extensions.Synchronize(() => ValidateEndpointCustomDomainAsync(endpointName, hostName));
        }

        ///GENMHASH:3100428FE3EA33121B09FE78BAEAFA03:C9621675455EC620B9844FE8A5939DF2
        public void StopEndpoint(string endpointName)
        {
            StopEndpointAsync(endpointName).Wait();
        }

        ///GENMHASH:A6F1A684D1580F8D831B28AEE9FE6E4F:5BCF75C57020D959105ED65B1B4A0097
        public void LoadEndpointContent(string endpointName, ISet<string> contentPaths)
        {
            LoadEndpointContentAsync(endpointName, contentPaths).Wait();
        }

        ///GENMHASH:065B0985A869BCEF0E134ADF57B0D802:77FED30AD7A765EDE2CC5C5780186F69
        public void StartEndpoint(string endpointName)
        {
            StartEndpointAsync(endpointName).Wait();
        }

        ///GENMHASH:6E7FC7AC8D073A3C3B9DDD1D764ADF68:9685139DF186DEC19F0A0EDA4B91F24C
        public CdnProfileImpl WithStandardAkamaiSku()
        {
            Inner.Sku = new Sku(SkuName.StandardAkamai);
            return this;
        }

        ///GENMHASH:70DF47F31441CE46EC627207B2DE06E0:C8C6BDB115BB2358DEF4B1C799E01F42
        public async Task StartEndpointAsync(string endpointName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.StartAsync(ResourceGroupName, Name, endpointName, cancellationToken);
        }

        ///GENMHASH:0C4071C9FB9B1B9D467AC6C4D4BF2C8F:A9DD6B4B67E69C5141C1637E3D1687C9
        public CdnProfileImpl WithPremiumVerizonSku()
        {
            Inner.Sku = new Sku(SkuName.PremiumVerizon);
            return this;
        }

        ///GENMHASH:8B3976582303B73AC81C5220073E2D55:A4104491D327BA3667E857CA7A2EC15D
        public CheckNameAvailabilityResult CheckEndpointNameAvailability(string name)
        {
            return Manager.Profiles.CheckEndpointNameAvailability(name);
        }

        ///GENMHASH:64DEF1711FC41C47500E107416B7F805:77545E61909DDA4E2970CA68754B4441
        public async Task<CheckNameAvailabilityResult> CheckEndpointNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Profiles.CheckEndpointNameAvailabilityAsync(name, cancellationToken);
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

        ///GENMHASH:1D5C24C8FDD38263C467FE7510F78581:F289006A354128A889CBDDA7CC12862C
        public string GenerateSsoUri()
        {
            SsoUriInner ssoUri = Extensions.Synchronize(() => Manager.Inner.Profiles.GenerateSsoUriAsync(ResourceGroupName, Name));
            if (ssoUri != null)
            {
                return ssoUri.SsoUriValue;
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:5D11154E7DB964515AF726E248201566:B0BB53131B0D441DE268460DBA20D7F6
        public async Task<string> GenerateSsoUriAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SsoUriInner ssoUri = await Manager.Inner.Profiles.GenerateSsoUriAsync(ResourceGroupName, Name, cancellationToken);
            return ssoUri?.SsoUriValue;
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

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:3668B82086C37B508A9B15A557F5DDEE
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

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:9F5356730D39C0EBFAE4A3CBD203F3C5
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

        ///GENMHASH:89CD44AA5060CAB16CB0AF1FB046BC64:38BC374AC5D46ED852675FD772CAFDAD
        public IEnumerable<ResourceUsage> ListResourceUsage()
        {
            return Extensions.Synchronize(() => Manager.Inner.Profiles.ListResourceUsageAsync(ResourceGroupName, Name))
                .AsContinuousCollection(link => Extensions.Synchronize(() => Manager.Inner.Profiles.ListResourceUsageNextAsync(link)))
                .Select(inner => new ResourceUsage(inner));
        }

        ///GENMHASH:B28D1284FE563994BFA76F228D2B2A7F:E514E11A2681970AA9465DBE8004FA44
        public async Task LoadEndpointContentAsync(
            string endpointName, 
            ISet<string> contentPaths, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.LoadContentAsync(ResourceGroupName, Name, endpointName, contentPaths?.ToList(), cancellationToken);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:4D3293CE97505F5F3FEC6BC819A5D1A2
        protected override async Task<ProfileInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.Profiles.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:37D0B9659C11E9B4AA5E39DEE4B0AB7D:C83A09045ECA07DB3EC59281710F2DEA
        internal CdnProfileImpl WithEndpoint(CdnEndpointImpl endpoint)
        {
            endpointsImpl.AddEndpoint(endpoint);
            return this;
        }

        ///GENMHASH:0A12C6434C3DBD82C19A05E194B01AEA:47C499127E0A668B9483D4F7476DAC89
        public async Task StopEndpointAsync(string endpointName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.StopAsync(this.ResourceGroupName, this.Name, endpointName, cancellationToken);
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

        ///GENMHASH:4A77B038EBB7E9DE574EA985E8BA5BAA:962058C8B6B9E50D658B4196CD77F173
        public async Task<CustomDomainValidationResult> ValidateEndpointCustomDomainAsync(
            string endpointName, 
            string hostName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return new CustomDomainValidationResult(
                await Manager.Inner.Endpoints.ValidateCustomDomainAsync(ResourceGroupName, Name, endpointName, hostName, cancellationToken));
        }

        ///GENMHASH:BE0AA68DCF3FABA9207DD0D1087D157E:4432A0AE945945A7628130BCDDABF55E
        public async Task PurgeEndpointContentAsync(
            string endpointName, 
            ISet<string> contentPaths, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.PurgeContentAsync(ResourceGroupName, Name, endpointName, contentPaths?.ToList() ,cancellationToken);
        }		
    }
}
