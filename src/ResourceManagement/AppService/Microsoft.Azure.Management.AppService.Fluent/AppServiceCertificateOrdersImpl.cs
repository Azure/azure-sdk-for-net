// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for AppServicePlans.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZUNlcnRpZmljYXRlT3JkZXJzSW1wbA==
    internal partial class AppServiceCertificateOrdersImpl :
        GroupableResources<
            IAppServiceCertificateOrder,
            AppServiceCertificateOrderImpl,
            AppServiceCertificateOrderInner,
            AppServiceCertificateOrdersOperations,
            AppServiceManager>,
        IAppServiceCertificateOrders
    {
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public AppServiceCertificateOrderImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:D505D44BBE5A66C92A4176DBA1DD5891:68BABEE90E833AD1BFA7F46A8C19127A
        public override async Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder> GetByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var appServiceCertificateOrderInner = await InnerCollection.GetAsync(resourceGroupName, name);

            return WrapModel(appServiceCertificateOrderInner);
        }

        ///GENMHASH:FCA66BA6767E2497E23A1AF83D62F9F0:0FCD47CBCD9128C3D4A03458C5796741
        internal AppServiceCertificateOrdersImpl(AppServiceCertificateOrdersOperations innerCollection, AppServiceManager manager)
            : base(innerCollection, manager)
        {
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3
        public PagedList<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder> ListByGroup(string resourceGroupName)
        {
            return WrapList(new PagedList<AppServiceCertificateOrderInner>(InnerCollection.ListByResourceGroup(resourceGroupName),
                nextLink => InnerCollection.ListByResourceGroupNext(nextLink)));
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:60ECC4D32A4130D4A0971FBE7432E886
        public override async Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await InnerCollection.DeleteCertificateOrderAsync(groupName, name);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:0AA8888F1EA6DA91AC72678639578389
        protected override AppServiceCertificateOrderImpl WrapModel(string name)
        {
            return new AppServiceCertificateOrderImpl(name, new AppServiceCertificateOrderInner(), InnerCollection, Manager);
        }

        ///GENMHASH:B36EBFDFA77033C03C4B7C1A493B9315:7827EBFF4491A5043A5099AE2A01FBDF
        protected override IAppServiceCertificateOrder WrapModel(AppServiceCertificateOrderInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new AppServiceCertificateOrderImpl(inner.Name, inner, InnerCollection, Manager);
        }
    }
}