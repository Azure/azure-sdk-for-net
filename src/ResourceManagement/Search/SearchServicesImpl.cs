// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Search.Fluent.Models;
    using Microsoft.Azure.Management.Search.Fluent.SearchService.Definition;
    using Microsoft.Rest;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SearchServices.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlYXJjaC5pbXBsZW1lbnRhdGlvbi5TZWFyY2hTZXJ2aWNlc0ltcGw=
    internal partial class SearchServicesImpl  :
        GroupableResources<Microsoft.Azure.Management.Search.Fluent.ISearchService,Microsoft.Azure.Management.Search.Fluent.SearchServiceImpl,Models.SearchServiceInner,Microsoft.Azure.Management.Search.Fluent.IServicesOperations,Microsoft.Azure.Management.Search.Fluent.ISearchManager>,
        ISearchServices
    {
        ///GENMHASH:42E0B61F5AA4A1130D7B90CCBAAE3A5D:4B8FED86339C1482A49BC13971213D69
        public async Task<Microsoft.Azure.Management.Search.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new CheckNameAvailabilityResultImpl(await this.Manager.Inner.Services.CheckNameAvailabilityAsync(name, cancellationToken: cancellationToken));
        }

        ///GENMHASH:E7DE218262282EFE488CF13C22FA8423:7E200CDD53729E8602DA31CDFDDF2D00
        public IQueryKey CreateQueryKey(string resourceGroupName, string searchServiceName, string name)
        {
            return new QueryKeyImpl(Extensions.Synchronize(() => this.Manager.Inner.QueryKeys.CreateAsync(resourceGroupName, searchServiceName, name)));
        }

        ///GENMHASH:B53AC706B26B156755A7FE389B3AC10A:92378743B59A5F7D5B69EC27F2F93024
        public IAdminKeys RegenerateAdminKeys(string resourceGroupName, string searchServiceName, AdminKeyKind keyKind)
        {
            return new AdminKeysImpl(Extensions.Synchronize(() => this.Manager.Inner.AdminKeys.RegenerateAsync(resourceGroupName, searchServiceName, keyKind)));
        }

        ///GENMHASH:18E13CA84739461859EA4DED98BCCC94:26B9F10B49CBB33A64470D6B7F0851CD
        public async Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> GetAdminKeysAsync(string resourceGroupName, string searchServiceName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new AdminKeysImpl(await this.Manager.Inner.AdminKeys.GetAsync(resourceGroupName, searchServiceName, cancellationToken: cancellationToken));
        }

        ///GENMHASH:E157E974C34E67511C566557BEE548F4:6DB25D592A69FECE4EAAFF953676230A
        public async Task DeleteQueryKeyAsync(string resourceGroupName, string searchServiceName, string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.QueryKeys.DeleteAsync(resourceGroupName, searchServiceName, key, cancellationToken: cancellationToken);
        }

        ///GENMHASH:155D023185BC78F1A188EB5CC0F84606:792CB5B7CC55B8EB8E793CBEC2F1E8CC
        public async Task<Microsoft.Azure.Management.Search.Fluent.IAdminKeys> RegenerateAdminKeysAsync(string resourceGroupName, string searchServiceName, AdminKeyKind keyKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new AdminKeysImpl(await this.Manager.Inner.AdminKeys.RegenerateAsync(resourceGroupName, searchServiceName, keyKind, cancellationToken: cancellationToken));
        }

        ///GENMHASH:7BEDA5F3DF50D9CEC52DEDE3753B52AA:A914A3CE34E56F776C4EE25EF1B3E54A
        public async Task<Microsoft.Azure.Management.Search.Fluent.IQueryKey> CreateQueryKeyAsync(string resourceGroupName, string searchServiceName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new QueryKeyImpl(await this.Manager.Inner.QueryKeys.CreateAsync(resourceGroupName, searchServiceName, name, cancellationToken: cancellationToken));
        }

        ///GENMHASH:353C852179465D01B35D24D9A22C3915:B1CDFE4766C956DE5D036433D281D267
        public async Task<IEnumerable<Microsoft.Azure.Management.Search.Fluent.IQueryKey>> ListQueryKeysAsync(string resourceGroupName, string searchServiceName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var queryKeyList = await this.Manager.Inner.QueryKeys.ListBySearchServiceAsync(resourceGroupName, searchServiceName, cancellationToken: cancellationToken);

            return queryKeyList.Select(inner => new QueryKeyImpl(inner));
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:16241A36EEDB3B0CB182EE4C541BAB15
        public IEnumerable<Microsoft.Azure.Management.Search.Fluent.ISearchService> List()
        {
            var resourceGroups = this.Manager.ResourceManager.ResourceGroups.List();
            foreach (var resourceGroup in resourceGroups)
            {
                var searchItems = this.ListByResourceGroup(resourceGroup.Name);
                foreach(var searchItem in searchItems)
                {
                    yield return searchItem;
                }
            }
        }

        ///GENMHASH:9C5B42FF47E71D8582BAB26BBDEC1E0B:2D75B9911838358EA9F5266CDD7D790B
        public async Task<IEnumerable<Microsoft.Azure.Management.Search.Fluent.ISearchService>> ListByResourceGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var searchServiceList = await this.Manager.Inner.Services.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken);
            return searchServiceList.Select( (inner) => WrapModel(inner));
        }

        ///GENMHASH:0FEF45F7011A46EAF6E2D15139AE631D:5FA89691046D722A91E5A39765826A5D
        protected async Task<Models.SearchServiceInner> GetInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Services.GetAsync(resourceGroupName, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:178BF162835B0E3978203EDEF988B6EB:1C716C257AE3169C0236A38330AB11A1
        public IEnumerable<Microsoft.Azure.Management.Search.Fluent.ISearchService> ListByResourceGroup(string groupName)
        {
            return Extensions.Synchronize(() => this.Manager.Inner.Services.ListByResourceGroupAsync(groupName)).Select((inner) => WrapModel(inner));
        }

        ///GENMHASH:F5650D7DFD745AFD96D1AEF0353D5D98:D5ACE23BB00AF032073CD4CE9E7D550D
        internal  SearchServicesImpl(ISearchManager searchServiceManager) : base(searchServiceManager.Inner.Services, searchServiceManager)
        {
        }

        ///GENMHASH:C4C74C5CA23BE3B4CAFEFD0EF23149A0:46199B320CF77BF7B0B5099E0636CD76
        public ICheckNameAvailabilityResult CheckNameAvailability(string name)
        {
            return new CheckNameAvailabilityResultImpl(Extensions.Synchronize(() => this.Manager.Inner.Services.CheckNameAvailabilityAsync(name)));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:96BE46FF9750704AF77EAD7AFE062B24
        public SearchServiceImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:379C3EFC5EC7483099CB5814DBA48B81
        protected async Task DeleteInnerAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.Services.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:A5F897AF9D5CE32F1C11DB034C224BBE:EECAC1840030A22136E9DE1FC01E7F91
        public void DeleteQueryKey(string resourceGroupName, string searchServiceName, string key)
        {
            Extensions.Synchronize(() => this.Manager.Inner.QueryKeys.DeleteAsync(resourceGroupName, searchServiceName, key));
        }

        ///GENMHASH:105AF1ABAC4FD8AB777EADE9E164FB05:07CF09DED75A7CE1C3C4E4DD730FFDC8
        public IAdminKeys GetAdminKeys(string resourceGroupName, string searchServiceName)
        {
            return new AdminKeysImpl(Extensions.Synchronize(() => this.Manager.Inner.AdminKeys.GetAsync(resourceGroupName, searchServiceName)));
        }

        ///GENMHASH:AF29CE8A45BF4D0D80B85F209E3F6C3F:BCF87312C92FD8ABD1A1106FC6174A8C
        public IReadOnlyList<Microsoft.Azure.Management.Search.Fluent.IQueryKey> ListQueryKeys(string resourceGroupName, string searchServiceName)
        {
            List<QueryKeyImpl> queryKeys = new List<QueryKeyImpl>();

            var queryKeyInners = Extensions.Synchronize(() => this.Manager.Inner.QueryKeys.ListBySearchServiceAsync(resourceGroupName, searchServiceName));
            if (queryKeyInners != null)
            {
                foreach (var queryKeyInner in queryKeyInners)
                {
                    queryKeys.Add(new QueryKeyImpl(queryKeyInner));
                }
            }

            return queryKeys.AsReadOnly();
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:73FF68C048CDD9FE260EEAEE47681D45
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<ISearchService>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ISearchService, Models.SearchServiceInner>.LoadPage(async (cancellation) =>
            {
                var resourceGroups = await this.Manager.ResourceManager.ResourceGroups.ListAsync(loadAllPages, cancellation);
                var searchService = await Task.WhenAll(resourceGroups.Select(async (rg) => await this.Manager.Inner.Services.ListByResourceGroupAsync(rg.Name, cancellationToken: cancellation)));
                return searchService.SelectMany(x => x);
            }, WrapModel, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:88327259C69D67D3446CF1C738F121BA
        protected override SearchServiceImpl WrapModel(string name)
        {
            SearchServiceInner inner = new SearchServiceInner();

            return new SearchServiceImpl(name, inner, base.Manager);
        }

        ///GENMHASH:DF8F69E48D50769CFB1B546639E88C5B:EC8681B176B6C89887B3230304D8FF5A
        protected override ISearchService WrapModel(SearchServiceInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new SearchServiceImpl(inner.Name, inner, this.Manager);
        }

        protected override async Task<SearchServiceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await this.Manager.Inner.Services.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.Manager.Inner.Services.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }

        async Task<IPagedCollection<ISearchService>> ISupportsListingByResourceGroup<ISearchService>.ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages, CancellationToken cancellationToken)
        {
            return await PagedCollection<ISearchService, Models.SearchServiceInner>.LoadPage(async (cancellation) =>
            {
                return await this.Manager.Inner.Services.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken);
            }, WrapModel, cancellationToken);
        }
    }
}