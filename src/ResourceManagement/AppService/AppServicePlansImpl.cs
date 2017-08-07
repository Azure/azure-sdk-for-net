// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for AppServicePlans.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZVBsYW5zSW1wbA==
    internal partial class AppServicePlansImpl :
        TopLevelModifiableResources<
            IAppServicePlan,
            AppServicePlanImpl,
            AppServicePlanInner,
            IAppServicePlansOperations,
            IAppServiceManager>,
        IAppServicePlans
    {

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:938AF55195C22DFA74E6820E73D5DEE3

        public new async Task<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceId = ResourceId.FromString(id);
            return WrapModel(await Inner.GetAsync(resourceId.ResourceGroupName, resourceId.Name, cancellationToken));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public AppServicePlanImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3

        public IEnumerable<IAppServicePlan> ListByGroup(string resourceGroupName)
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListByResourceGroupAsync(resourceGroupName))
                                 .AsContinuousCollection(link => Extensions.Synchronize(() => Inner.ListByResourceGroupNextAsync(link))));
        }
        protected async override Task<IPage<AppServicePlanInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<AppServicePlanInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        protected async override Task<IPage<AppServicePlanInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken: cancellationToken);
        }

        protected async override Task<IPage<AppServicePlanInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:586E2B084878E8767487234B852D8D20
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:AB5235085FE852FA939C192DC80C9EEF
        protected async override Task<AppServicePlanInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:15CD9415526D1B733D90CDDE7ECDE8B9
        protected override AppServicePlanImpl WrapModel(string name)
        {
            return new AppServicePlanImpl(name, new AppServicePlanInner(), Manager);
        }

        ///GENMHASH:1421F11CFE57BDF3BEA54271EBAF3758:E10F86D38EF3746AE39B86EEC91CC962
        protected override IAppServicePlan WrapModel(AppServicePlanInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new AppServicePlanImpl(inner.Name, inner, Manager);
        }

        ///GENMHASH:13EDEABEC8823ED4BDC78DA4C9882000:0FCD47CBCD9128C3D4A03458C5796741
        internal AppServicePlansImpl(IAppServiceManager manager)
            : base(manager.Inner.AppServicePlans, manager)
        {
        }

    }
}
