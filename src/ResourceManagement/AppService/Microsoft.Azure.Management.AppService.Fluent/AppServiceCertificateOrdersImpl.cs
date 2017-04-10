// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for AppServicePlans.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZUNlcnRpZmljYXRlT3JkZXJzSW1wbA==
    internal partial class AppServiceCertificateOrdersImpl :
        TopLevelModifiableResources<
            IAppServiceCertificateOrder,
            AppServiceCertificateOrderImpl,
            AppServiceCertificateOrderInner,
            IAppServiceCertificateOrdersOperations,
            IAppServiceManager>,
        IAppServiceCertificateOrders
    {

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public AppServiceCertificateOrderImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:D505D44BBE5A66C92A4176DBA1DD5891:68BABEE90E833AD1BFA7F46A8C19127A

        protected async override Task<AppServiceCertificateOrderInner> GetInnerByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(resourceGroupName, name, cancellationToken);
        }

        ///GENMHASH:FCA66BA6767E2497E23A1AF83D62F9F0:0FCD47CBCD9128C3D4A03458C5796741

        internal AppServiceCertificateOrdersImpl(IAppServiceManager manager)
            : base(manager.Inner.AppServiceCertificateOrders, manager)
        {
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3

        protected async override Task<IPage<AppServiceCertificateOrderInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<AppServiceCertificateOrderInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        protected async override Task<IPage<AppServiceCertificateOrderInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken);
        }

        protected async override Task<IPage<AppServiceCertificateOrderInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:60ECC4D32A4130D4A0971FBE7432E886

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:EE24F36A6CF82761683067786087715B
        protected override AppServiceCertificateOrderImpl WrapModel(string name)
        {
            return new AppServiceCertificateOrderImpl(name, new AppServiceCertificateOrderInner(), Manager);
        }

        ///GENMHASH:B36EBFDFA77033C03C4B7C1A493B9315:46D76E17F9A4F69705A0F739D280D6F9
        protected override IAppServiceCertificateOrder WrapModel(AppServiceCertificateOrderInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new AppServiceCertificateOrderImpl(inner.Name, inner, Manager);
        }

    }
}
