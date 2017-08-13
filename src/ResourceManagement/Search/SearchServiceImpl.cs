// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Search.Fluent.Models;
    using Microsoft.Azure.Management.Search.Fluent.SearchService.Definition;
    using Microsoft.Azure.Management.Search.Fluent.SearchService.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for Foo and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlYXJjaC5pbXBsZW1lbnRhdGlvbi5TZWFyY2hTZXJ2aWNlSW1wbA==
    internal partial class SearchServiceImpl  :
        GroupableResource<
            Microsoft.Azure.Management.Search.Fluent.ISearchService,
            Models.SearchServiceInner,
            Microsoft.Azure.Management.Search.Fluent.SearchServiceImpl,
            Microsoft.Azure.Management.Search.Fluent.ISearchManager,
            IWithGroup,
            IWithSku,
            IWithCreate,
            IUpdate>,
        ISearchService,
        IDefinition,
        IUpdate
    {
        ///GENMHASH:F2682A0FD6F28C64C4F1A86A781ABCEB:F9DDE4A1DA68C0102C47A6C6A2ED3820
        internal SearchServiceImpl(string name, SearchServiceInner innerModel, ISearchManager networkManager) :
            base(name, innerModel, networkManager)
        {
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:6C0F073CD3F6612454E461FCB2750A2B
        public Sku Sku()
        {
            return this.Inner.Sku;
        }

        ///GENMHASH:8C6C4556491F3E812E6E37044E777581:E5DF6DA95310CB0564EFBB2A4F516B04
        public HostingMode HostingMode()
        {
            if (this.Inner.HostingMode.HasValue)
            {
                return this.Inner.HostingMode.Value;
            }

            return Microsoft.Azure.Management.Search.Fluent.Models.HostingMode.Default;

        }

        ///GENMHASH:F685E9B4F8D4F14A6A742C39FE8B24E9:F3CFD6DEBAB4C46FAA93101059E43BE5
        public int PartitionCount()
        {
            if (this.Inner.PartitionCount.HasValue)
            {
                return this.Inner.PartitionCount.Value;
            }

            return 0;
        }

        ///GENMHASH:FFA80D899BCDE3E1514D4AAC3286F037:718ED803B27BD37F0D39B290F194F904
        public int ReplicaCount()
        {
            if (this.Inner.ReplicaCount.HasValue)
            {
                return this.Inner.ReplicaCount.Value;
            }

            return 0;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:CCCDC1E75483620F7C2758E3603D5A99
        public ProvisioningState ProvisioningState()
        {
            if (this.Inner.ProvisioningState.HasValue)
            {
                return this.Inner.ProvisioningState.Value;
            }

            return Models.ProvisioningState.Provisioning;
        }

        ///GENMHASH:0F6B7E0425A2DF3ABB70CE2ECC285132:158518EC05B6D176607835321CFDFD64
        public string StatusDetails()
        {
            return this.Inner.StatusDetails;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:D4FD6E91B3A8D80EF363FBBDCAFDD7C0
        public SearchServiceStatus Status()
        {
            if (this.Inner.Status.HasValue) {
                return this.Inner.Status.Value;
            }
            return SearchServiceStatus.Provisioning;
        }

        ///GENMHASH:FA57EF51D40283CC94BB7B6C4365AE07:4A9D25CE788FF7A3AE0C626358FBF79B
        public IAdminKeys GetAdminKeys()
        {
            return new AdminKeysImpl(Extensions.Synchronize(() => this.Manager.Inner.AdminKeys.GetAsync(this.ResourceGroupName, this.Name)));
        }

        ///GENMHASH:1BC6D5F265F3C32166DAEF04C8CF2C5F:FAB6E0B529548B70452AF83292E7CA38
        public async Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> GetAdminKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var adminKeysInner = await this.Manager.Inner.AdminKeys.GetAsync(this.ResourceGroupName, this.Name);

            return new AdminKeysImpl(adminKeysInner);
        }

        ///GENMHASH:9A1BAF4B55B6C6E919FD9546E00FBD58:34A7FCDE465704208C33E7FF3BE0AE5C
        public IAdminKeys RegenerateAdminKeys(AdminKeyKind keyKind)
        {
            return new AdminKeysImpl(Extensions.Synchronize(() => this.Manager.Inner.AdminKeys.RegenerateAsync(this.ResourceGroupName, this.Name, keyKind)));
        }

        ///GENMHASH:228D19CFE32F95F58B6A30660F9315FD:CCA4B133BFF259EEEF5962D1E1A0BDE3
        public async Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> RegenerateAdminKeysAsync(AdminKeyKind keyKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            var adminKeysInner = await this.Manager.Inner.AdminKeys.RegenerateAsync(this.ResourceGroupName, this.Name, keyKind);

            return new AdminKeysImpl(adminKeysInner);
        }

        ///GENMHASH:BFCEBCFCA4A7A301C248E807E397B865:8B4CCB2CC011F00EEBF2800A84FF88ED
        public IQueryKey CreateQueryKey(string name)
        {
            return new QueryKeyImpl(Extensions.Synchronize(() => this.Manager.Inner.QueryKeys.CreateAsync(this.ResourceGroupName, this.Name, name)));
        }

        ///GENMHASH:7680DB5F34D39F5CF330CC24E6649F21:9D167B3BB48AF6094ED01878A892D752
        public async Task<Microsoft.Azure.Management.Search.Fluent.IQueryKey> CreateQueryKeyAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.QueryKeys.CreateAsync(this.ResourceGroupName, this.Name, name);

            return new QueryKeyImpl(inner);
        }

        ///GENMHASH:D555A7773E06AE00E1EC9A726CE81C16:3A3B4410D5A527E6B14B3275C7D7F2DF
        public void DeleteQueryKey(string key)
        {
            Extensions.Synchronize(() => this.Manager.Inner.QueryKeys.DeleteAsync(this.ResourceGroupName, this.Name, key));
        }

        ///GENMHASH:E850F7304F44C200E85091E4C1C7F8FF:F44E7840A0F5A6E0F0351CAD6DF613AE
        public async Task DeleteQueryKeyAsync(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.QueryKeys.DeleteAsync(this.ResourceGroupName, this.Name, key);
        }

        ///GENMHASH:1E8280BE0E8DF55E1EE12D94D5B5D2F8:E54790FA9C6D2390DB0C866CB91039BE
        public IReadOnlyList<Microsoft.Azure.Management.Search.Fluent.IQueryKey> ListQueryKeys()
        {
            List<QueryKeyImpl> queryKeys = new List<QueryKeyImpl>();

            var queryKeyInners = Extensions.Synchronize(() => this.Manager.Inner.QueryKeys.ListBySearchServiceAsync(this.ResourceGroupName, this.Name));
            if (queryKeyInners != null)
            {
                foreach (var queryKeyInner in queryKeyInners)
                {
                    queryKeys.Add(new QueryKeyImpl(queryKeyInner));
                }
            }

            return queryKeys.AsReadOnly();
        }

        ///GENMHASH:8B825E9C0D6D7F660542284CD46B32D6:FE7E5A2834675AB5588AC651A127BDEE
        public async Task<IEnumerable<Microsoft.Azure.Management.Search.Fluent.IQueryKey>> ListQueryKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var queryKeyList = await this.Manager.Inner.QueryKeys.ListBySearchServiceAsync(this.ResourceGroupName, this.Name, cancellationToken: cancellationToken);

            return queryKeyList.Select(inner => new QueryKeyImpl(inner));
        }


        public async override Task<ISearchService> CreateResourceAsync(CancellationToken cancellationToken)
        {
            var inner = await this.Manager.Inner.Services.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner, cancellationToken: cancellationToken);
            SetInner(inner);

            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:793DCACDAC480F71BBBB78272564E1F2
        protected override async Task<Models.SearchServiceInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Services.GetAsync(this.ResourceGroupName, this.Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:4884876671AF0E98273703F5FEAB903C
        protected async Task<Models.SearchServiceInner> CreateInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Services.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner, cancellationToken: cancellationToken);
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:397376085A4AA13229E1F81DA88C08D6
        public override async Task<Microsoft.Azure.Management.Search.Fluent.ISearchService> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await GetInnerAsync(cancellationToken);
            SetInner(inner);

            return this;
        }


        ///GENMHASH:BFF45BC391E5CDAFEBC876B36BD8488F:4D9AAD25C10BAC2CEE634A1422220CC7
        public SearchServiceImpl WithFreeSku()
        {
            this.Inner.Sku = new Sku(SkuName.Free);

            return this;
        }

        ///GENMHASH:8D7485C72B719CA5E190D69B6FF75F54:36922CBCD33556DD16150BAB53DD8A56
        public SearchServiceImpl WithBasicSku()
        {
            this.Inner.Sku = new Sku(SkuName.Basic);

            return this;
        }

        ///GENMHASH:D24D0D518EC4AAB3671622B0122F4207:568369437B3CD4EFBB73E19BD8746B81
        public SearchServiceImpl WithStandardSku()
        {
            this.Inner.Sku = new Sku(SkuName.Standard);

            return this;
        }

        ///GENMHASH:B5E3D903BDA1F2A62441339A3042D8F4:13AEEBBDA588648551180324A2475517
        public SearchServiceImpl WithSku(SkuName skuName)
        {
            this.Inner.Sku = new Sku(skuName);

            return this;
        }

        ///GENMHASH:6F79B92ABF8124AD7E3B378B6CB6A98C:DB251E891D88C5F3D7CD4B7EC6146257
        public SearchServiceImpl WithReplicaCount(int replicaCount)
        {
            this.Inner.ReplicaCount = replicaCount;

            return this;
        }

        ///GENMHASH:33D5FC2D81E535232233B86E2B6F558F:C5E34EC5574D78BDA8364712933FDC47
        public SearchServiceImpl WithPartitionCount(int partitionCount)
        {
            this.Inner.PartitionCount = partitionCount;

            return this;
        }
    }
}