// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for AppServicePlans.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZUNlcnRpZmljYXRlc0ltcGw=
    internal partial class AppServiceCertificatesImpl :
        TopLevelModifiableResources<
            IAppServiceCertificate,
            AppServiceCertificateImpl,
            CertificateInner,
            ICertificatesOperations,
            IAppServiceManager>,
        IAppServiceCertificates
    {

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public AppServiceCertificateImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:A19C6C0AD2220AD90153C8EBDA3FD2D2:0FCD47CBCD9128C3D4A03458C5796741

        internal AppServiceCertificatesImpl(IAppServiceManager manager)
            : base(manager.Inner.Certificates, manager)
        {
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3

        protected async override Task<IPage<CertificateInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<CertificateInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        protected async override Task<IPage<CertificateInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken);
        }

        protected async override Task<IPage<CertificateInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:586E2B084878E8767487234B852D8D20

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:AB5235085FE852FA939C192DC80C9EEF

        protected async override Task<CertificateInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:52C1475082F350C9790152505F0F5545
        protected override AppServiceCertificateImpl WrapModel(string name)
        {
            return new AppServiceCertificateImpl(name, new CertificateInner(), Manager);
        }

        ///GENMHASH:446794D74A04366F0AA274DF90F28CE3:33B6A3A8A24D997474871BAB2A8C2B87
        protected override IAppServiceCertificate WrapModel(CertificateInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new AppServiceCertificateImpl(inner.Name, inner, Manager);
        }
    }
}
