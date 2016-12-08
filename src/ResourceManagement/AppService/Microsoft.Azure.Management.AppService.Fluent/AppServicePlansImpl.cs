// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent;

    /// <summary>
    /// The implementation for AppServicePlans.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZVBsYW5zSW1wbA==
    internal partial class AppServicePlansImpl  :
        GroupableResources<Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan,Microsoft.Azure.Management.Appservice.Fluent.AppServicePlanImpl,Microsoft.Azure.Management.AppService.Fluent.Models.AppServicePlanInner,Microsoft.Azure.Management.AppService.Fluent.Models.AppServicePlansInner,Microsoft.Azure.Management.AppService.Fluent.Models.AppServiceManager>,
        IAppServicePlans
    {
        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:938AF55195C22DFA74E6820E73D5DEE3
        public async Task<Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return innerCollection.GetAsync(
            //$ ResourceUtils.GroupFromResourceId(id),
            //$ ResourceUtils.NameFromResourceId(id))
            //$ .Map(new Func1<AppServicePlanInner, AppServicePlan>() {
            //$ @Override
            //$ public AppServicePlan call(AppServicePlanInner appServicePlanInner) {
            //$ return wrapModel(appServicePlanInner);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public AppServicePlanImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3
        public PagedList<Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan> ListByGroup(string resourceGroupName)
        {
            //$ return wrapList(innerCollection.ListByResourceGroup(resourceGroupName));

            return null;
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:586E2B084878E8767487234B852D8D20
        public async Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return innerCollection.DeleteAsync(groupName, name)
            //$ .Map(new Func1<Object, Void>() {
            //$ @Override
            //$ public Void call(Object o) {
            //$ return null;
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:AB5235085FE852FA939C192DC80C9EEF
        public async Task<IAppServicePlan> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapModel(innerCollection.Get(groupName, name));

            return null;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:C35C270B3C2E9692DFA4DB35882E6EF7
        protected AppServicePlanImpl WrapModel(string name)
        {
            //$ return new AppServicePlanImpl(name, new AppServicePlanInner(), innerCollection, myManager);

            return null;
        }

        ///GENMHASH:1421F11CFE57BDF3BEA54271EBAF3758:8BBC6CEF06D15B4BC058A7C4E216A1A2
        protected AppServicePlanImpl WrapModel(AppServicePlanInner inner)
        {
            //$ if (inner == null) {
            //$ return null;
            //$ }
            //$ return new AppServicePlanImpl(inner.Name(), inner, innerCollection, myManager);

            return null;
        }

        ///GENMHASH:13EDEABEC8823ED4BDC78DA4C9882000:0FCD47CBCD9128C3D4A03458C5796741
        internal  AppServicePlansImpl(AppServicePlansInner innerCollection, AppServiceManager manager)
        {
            //$ super(innerCollection, manager);
            //$ }

        }
    }
}