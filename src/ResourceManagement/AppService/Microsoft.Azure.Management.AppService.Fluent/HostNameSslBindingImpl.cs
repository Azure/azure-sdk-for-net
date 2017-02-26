// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using AppServiceCertificateOrder.Definition;
    using HostNameSslBinding.UpdateDefinition;
    using KeyVault.Fluent;
    using Resource.Fluent.Core;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using WebAppBase.Update;

    /// <summary>
    /// Implementation for HostNameSslBinding and its create and update interfaces.
    /// </summary>
    /// <typeparam name="Fluent">The fluent interface of the parent web app.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uSG9zdE5hbWVTc2xCaW5kaW5nSW1wbA==
    internal partial class HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> :
        IndexableWrapper<HostNameSslState>,
        IHostNameSslBinding,
        HostNameSslBinding.Definition.IDefinition<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>,
        IUpdateDefinition<WebAppBase.Update.IUpdate<FluentT>>
        where FluentImplT : WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>, FluentT
        where FluentT : class, IWebAppBase
        where DefAfterRegionT : class
        where DefAfterGroupT : class
        where UpdateT : class, IUpdate<FluentT>
    {
        private Func<Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate>> newCertificate;
        private IWithKeyVault certificateInDefinition;
        private FluentImplT parent;

        ///GENMHASH:A1F44CA6A666B87D4C3A3AF168E6B317:B3CDCCA65868AC18E4EC708E7218B458
        private HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithCertificateThumbprint(string thumbprint)
        {
            Inner.Thumbprint = thumbprint;
            return this;
        }

        ///GENMHASH:8F04665E49050E6C5BD8AE7B8E51D285:415AB6515F3750504B0F67632D677FD0
        public string Thumbprint()
        {
            return Inner.Thumbprint;
        }

        ///GENMHASH:7AF6E6BC1C5E421D399FD118151312D5:0A554F8B4AFC72FB22898249230C6EEE
        private string GetCertificateUniqueName(string thumbprint, Region region)
        {
            return string.Format("{0}##{1}#", thumbprint, region.Name);
        }

        ///GENMHASH:B90198DC89E5EAAFA864E1D246D6806C:4AD5178A115C8AF028528ABF531FF276
        private string GetCertificateThumbprint(string pfxPath, string password)
        {
            X509Certificate2Collection collection = new X509Certificate2Collection();
            collection.Import(pfxPath, password, X509KeyStorageFlags.PersistKeySet);

            foreach (var cert in collection)
            {
                return cert.Thumbprint;
            }
            throw new KeyNotFoundException("Private key not found in the pfx file");
        }

        ///GENMHASH:0B0AB38F6DD8B1FEB79C787CAA88F145:906C0B4A59497294B730FFF3475D49DA
        internal Func<Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate>> NewCertificateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (newCertificate == null)
            {
                return null;
            }

            return async () =>
            {
                var cert = await newCertificate();
                WithCertificateThumbprint(cert.Thumbprint);
                return cert;
            };
        }

        ///GENMHASH:397BA2D4B1869790A42A872F48941722:F892BABC215BB276FE708A01DFCE9DA8
        public string VirtualIP()
        {
            return Inner.VirtualIP;
        }

        ///GENMHASH:1CBA63C4D54835D9C11EFE4E0444EE09:353CE8610C345C1C601531BF2C13A9A5
        public HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithExistingAppServiceCertificateOrder(IAppServiceCertificateOrder certificateOrder)
        {
            newCertificate = async () => await parent.Manager.AppServiceCertificates
                .Define(GetCertificateUniqueName(certificateOrder.SignedCertificate.Thumbprint, parent.Region))
                .WithRegion(parent.Region)
                .WithExistingResourceGroup(parent.ResourceGroupName)
                .WithExistingCertificateOrder(certificateOrder)
                .CreateAsync();
            return this;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public IWebAppBase Parent
        {
            get
            {
                return parent;
            }
        }

        ///GENMHASH:B8A050E8A75C218A628FE17D20A72D91:BCDDFE46A85ECD6829F8CF639BD96E8F
        public HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithPfxCertificateToUpload(string pfxPath, string password)
        {
            var thumbprint = GetCertificateThumbprint(pfxPath, password);
            newCertificate = async () => await parent.Manager.AppServiceCertificates
                .Define(GetCertificateUniqueName(thumbprint, parent.Region))
                .WithRegion(parent.Region)
                .WithExistingResourceGroup(parent.ResourceGroupName)
                .WithPfxFile(pfxPath)
                .WithPfxPassword(password)
                .CreateAsync();

            return this;
        }

        ///GENMHASH:040FCD0915B61247DC4493834E39F655:A419F25EF828A0B88F2F3CAA051C4F14
        internal HostNameSslBindingImpl(HostNameSslState inner, FluentImplT parent)
                    : base(inner)
        {
            this.parent = parent;
        }

        ///GENMHASH:FECDA6325A56C366902AD25EE3271FA5:27D3A54723DD08767C3E53EDE9EA8C5E
        public HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithNewStandardSslCertificateOrder(string certificateOrderName)
        {
            this.certificateInDefinition = parent.Manager.AppServiceCertificateOrders.Define(certificateOrderName)
                .WithExistingResourceGroup(parent.ResourceGroupName)
                .WithHostName(Name())
                .WithStandardSku()
                .WithWebAppVerification(parent);
            return this;
        }

        ///GENMHASH:D8FD0D5A66A07D0FFBFEE9F7927105AB:284A8B86661672D728E63DE7FD5744B2
        public HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> ForHostname(string hostname)
        {
            Inner.Name = hostname;

            return this;
        }

        ///GENMHASH:3ADCAA931B83CC8C43D568C38C044646:28A9D87D2294D65F59DDB8E411F07C49
        public HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithNewKeyVault(string vaultName)
        {
            this.newCertificate = async () =>
            {
                var appServiceCertificateOrder = await certificateInDefinition
                    .WithNewKeyVault(vaultName, parent.Region)
                    .CreateAsync();
                return await parent.Manager.AppServiceCertificates.Define(appServiceCertificateOrder.Name)
                    .WithRegion(parent.RegionName)
                    .WithExistingResourceGroup(parent.ResourceGroupName)
                    .WithExistingCertificateOrder(appServiceCertificateOrder)
                    .CreateAsync();
            };

            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:681E8276D911828CC7E8D6E50D6254A2
        public FluentImplT Attach()
        {
            parent.WithNewHostNameSslBinding(this);
            return parent;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:0EDBC6F12844C2F2056BFF916F51853B
        public string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:D6E6B4575641C2C8BE88D60F458F6263:8756981E0162BBDC1278DBCA10007FF6
        public SslState SslState()
        {
            return Inner.SslState.GetValueOrDefault();
        }

        ///GENMHASH:BF9A77BB8ECC155B188086E8C0D49393:8EBA7D5F00B8349DEF70B3689B6F7595
        public HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithIpBasedSsl()
        {
            Inner.SslState = Models.SslState.IpBasedEnabled;

            return this;
        }

        ///GENMHASH:14288EE05A643ED3D2973C5B1849325A:6B20708315CEB0423077398E0C490AFB
        public HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithExistingKeyVault(IVault vault)
        {
            newCertificate = async () =>
            {
                var appServiceCertificateOrder = await certificateInDefinition
                    .WithExistingKeyVault(vault)
                    .CreateAsync();
                return await parent.Manager.AppServiceCertificates.Define(appServiceCertificateOrder.Name)
                    .WithRegion(parent.RegionName)
                    .WithExistingResourceGroup(parent.ResourceGroupName)
                    .WithExistingCertificateOrder(appServiceCertificateOrder)
                    .CreateAsync();
            };

            return this;
        }

        ///GENMHASH:31C074CC0AAF6D6D8A370A17CBC768E0:70994187CA24029C8B5118766FAC122E
        public HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithSniBasedSsl()
        {
            Inner.SslState = Models.SslState.SniEnabled;
            return this;
        }
    }
}
