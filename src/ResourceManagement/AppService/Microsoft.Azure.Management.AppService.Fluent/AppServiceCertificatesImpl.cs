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

<<<<<<<<<<<<<<<<<<<<<<<<<<<DELETED>>>>>>>>>>>>>>>>>>>>>>>>>>>
        internal AppServiceCertificatesImpl(IAppServiceManager manager)
            : base(manager.Inner.Certificates, manager)
        {
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3

<<<<<<<<<<<<<<<<<<<<<<<<<<<DELETED>>>>>>>>>>>>>>>>>>>>>>>>>>>
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

<<<<<<<<<<<<<<<<<<<<<<<<<<<DELETED>>>>>>>>>>>>>>>>>>>>>>>>>>>
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:AB5235085FE852FA939C192DC80C9EEF

<<<<<<<<<<<<<<<<<<<<<<<<<<<DELETED>>>>>>>>>>>>>>>>>>>>>>>>>>>
        protected async override Task<CertificateInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:52C1475082F350C9790152505F0F5545
        protected override AppServiceCertificateImpl WrapModel(string name)
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return new AppServiceCertificateImpl(name, new CertificateInner(), this.Manager());

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            return new AppServiceCertificateImpl(name, new CertificateInner(), Manager);
        }

        ///GENMHASH:446794D74A04366F0AA274DF90F28CE3:33B6A3A8A24D997474871BAB2A8C2B87
        protected override IAppServiceCertificate WrapModel(CertificateInner inner)
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ if (inner == null) {
            //$ return null;
            //$ }
            //$ return new AppServiceCertificateImpl(inner.Name(), inner, this.Manager());

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            if (inner == null)
            {
                return null;
            }
            return new AppServiceCertificateImpl(inner.Name, inner, Manager);
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:178BF162835B0E3978203EDEF988B6EB:232B9D8FCE564A66D25FFE38BCCECFC0
        public IEnumerable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate> ListByResourceGroup(string resourceGroupName)
        {
            //$ return wrapList(this.Inner().ListByResourceGroup(resourceGroupName));

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:9C5B42FF47E71D8582BAB26BBDEC1E0B:9790D012FA64E47343F12DB13F0AA212
        public async Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate> ListByResourceGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return null;

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:EA4B02CA898A5A5DDF8E0F36CECB5389
        public IEnumerable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate> List()
        {
            //$ return wrapList(inner().List());

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:0984AC2110E1EAA73B752279C293E987
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IAppServiceCertificate>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapPageAsync(inner().ListAsync());

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:0FEF45F7011A46EAF6E2D15139AE631D:4586493CAFC2FA1C61CC1139EB82A1CF
        protected async Task<Models.CertificateInner> GetInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner().GetAsync(resourceGroupName, name);

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:C45759A1E65AB470361E7D0D8B97E767
        protected async Task DeleteInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner().DeleteAsync(resourceGroupName, name).ToCompletable();

            return null;
        }

    }
}
