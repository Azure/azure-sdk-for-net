// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using AppServiceCertificateOrder.Definition;
    using AppServiceCertificateOrder.Update;
    using KeyVault.Fluent.Models;
    using Models;
    using KeyVault.Fluent;
    using Resource.Fluent;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for AppServicePlan.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZUNlcnRpZmljYXRlT3JkZXJJbXBs
    internal partial class AppServiceCertificateOrderImpl :
        GroupableResource<
            IAppServiceCertificateOrder,
            AppServiceCertificateOrderInner,
            AppServiceCertificateOrderImpl,
            IAppServiceManager,
            IBlank,
            IWithHostName,
            IWithCreate,
            IUpdate>,
        IAppServiceCertificateOrder,
        IDefinition,
        IUpdate
    {
        private IWebAppBase domainVerifyWebApp;
        private IAppServiceDomain domainVerifyDomain;
        private Func<Task<IVault>> bindingVault;

        ///GENMHASH:614D2D9852F00FD5BFCAF60BA2A659B0:86E327FE34A305973AC1A32ECEC60D57
        public AppServiceCertificateOrderImpl WithDomainVerification(IAppServiceDomain domain)
        {
            this.domainVerifyDomain = domain;
            return this;
        }

        ///GENMHASH:DF3D2D5058A900DD3618F549F0472A00:A4AC31C0727B9093054BE7E3EACA2528
        public int KeySize()
        {
            return Inner.KeySize.GetValueOrDefault();
        }

        ///GENMHASH:16ABBA273C3F791D052D0188B2107D3F:675930B8422D1B7EC65FC1D9BBC5D548
        public CertificateDetailsImpl Root()
        {
            if (Inner.Root == null)
            {
                return null;
            }
            return new CertificateDetailsImpl(Inner.Root);
        }

        ///GENMHASH:C70ACBF55B279BA26BBE5F77DDE46E40:5464228A4B2A39EBA61B99F7033FBFCB
        public string SerialNumber()
        {
            return Inner.SerialNumber;
        }

        ///GENMHASH:EBED0BAEEB9CC9BC93879B3D5FFD0E0C:46D041A38A4369ED8F41B9FE21E6FD13
        public AppServiceCertificateOrderImpl WithWildcardSku()
        {
            Inner.ProductType = CertificateProductType.StandardDomainValidatedWildCardSsl;
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:88F80234ADBF5F0E8B64015C7A3EF8D0
        public override async Task<IAppServiceCertificateOrder> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var certificateOrder = await Manager.Inner.AppServiceCertificateOrders.CreateOrUpdateAsync(ResourceGroupName, Name, Inner);
            Task verifyDomainOwnerShip = null;
            if (domainVerifyWebApp != null)
            {
                verifyDomainOwnerShip = domainVerifyWebApp.VerifyDomainOwnershipAsync(Name, certificateOrder.DomainVerificationToken);
            }
            else if (domainVerifyDomain != null)
            {
                verifyDomainOwnerShip = domainVerifyDomain.VerifyDomainOwnershipAsync(Name, certificateOrder.DomainVerificationToken);
            }
            else
            {
                throw new ArgumentException(
                $"Please specify a non-null web app or domain to verify the domain ownership for hostname {DistinguishedName()}");
            }
            await verifyDomainOwnerShip;
            var appServiceCertificateKeyVaultBinding = await CreateKeyVaultBindingAsync(Name, await bindingVault());

            return this;
        }

        ///GENMHASH:499D8F0148B4BCCD39D3D315006B873B:7BD59E082FC291DFA61838F7738DE972
        public string DomainVerificationToken()
        {
            return Inner.DomainVerificationToken;
        }

        ///GENMHASH:5DE7453277A4AF0C4B6125DBB0CE2C7C:2679171F2B11163B47E7F6C005E59EFB
        public CertificateProductType ProductType()
        {
            return Inner.ProductType.GetValueOrDefault();
        }

        ///GENMHASH:11AF5CEDE5EC5110A3D190463E690E16:0B6EB716D0098ABB085A80641A141FD0
        public AppServiceCertificateOrderImpl WithNewKeyVault(string vaultName, Microsoft.Azure.Management.Resource.Fluent.Core.Region region)
        {
            this.bindingVault = async() =>
                await Manager.KeyVaultManager.Vaults.Define(vaultName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(ResourceGroupName)
                    .DefineAccessPolicy()
                        .ForServicePrincipal("f3c21649-0979-4721-ac85-b0216b2cf413")
                        .AllowSecretPermissions(SecretPermissions.Get, SecretPermissions.Set, SecretPermissions.Delete)
                        .Attach()
                    .DefineAccessPolicy()
                        .ForServicePrincipal("abfa0a7c-a6b6-4736-8310-5855508787cd")
                        .AllowSecretPermissions(SecretPermissions.Get)
                        .Attach()
                    .CreateAsync();
            return this;
        }

        ///GENMHASH:DA9AB2A1A8F9DE8FFE3FD3F6C1C8F073:0419F3D0B678E962DE6B096A8D7646DC
        public IAppServiceCertificateKeyVaultBinding CreateKeyVaultBinding(string certificateName, IVault vault)
        {
            return CreateKeyVaultBinding(certificateName, vault);
        }

        ///GENMHASH:6B60EDADBCA134B9C9928244109B6E1B:5781A8E04FCEFEA9CF50B97FD61BE42B
        public async Task VerifyDomainOwnershipAsync(IAppServiceDomain domain, CancellationToken cancellationToken = default(CancellationToken))
        {
            await domain.VerifyDomainOwnershipAsync(Name, DomainVerificationToken());
        }

        ///GENMHASH:89B68C3393E544990D0BC1837B4C4C0E:B1CB960E9688630133BF735EE72C4279
        internal AppServiceCertificateOrderImpl(
            string key,
            AppServiceCertificateOrderInner innerObject,
            IAppServiceManager manager)
                    : base(key, innerObject, manager)
        {
            WithRegion("global");
            WithValidYears(1);
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:24635E3B6AB96D3E6BFB9DA2AF7C6AB5
        public override IAppServiceCertificateOrder Refresh()
        {
            this.SetInner(Manager.Inner.AppServiceCertificateOrders.Get(ResourceGroupName, Name));
            return this;
        }

        ///GENMHASH:9FDF35464E02B70B2EF312DAD321B8C2:82C57278EF9D50148F4779BC9B9CEDCF
        public DateTime? LastCertificateIssuanceTime()
        {
            return Inner.LastCertificateIssuanceTime;
        }

        ///GENMHASH:575807260557ED62F7AE130CBDC3F619:847ACFDD52BB5E87BABA56BD49D03F37
        public string DistinguishedName()
        {
            return Inner.DistinguishedName;
        }

        ///GENMHASH:359FB978D2F52E392FF6FE0BE3D1BF9B:013D8DD2D085E4A74D18D9EBEDB06FDC
        public AppServiceCertificateOrderImpl WithValidYears(int years)
        {
            Inner.ValidityInYears = years;

            return this;
        }

        ///GENMHASH:04406413E97C82F19F013C72D1DD2758:39E496E31AE9087192892138F0910259
        public async Task<IAppServiceCertificateKeyVaultBinding> CreateKeyVaultBindingAsync(string certificateName, IVault vault, CancellationToken cancellationToken = default(CancellationToken))
        {
            AppServiceCertificateInner certInner = new AppServiceCertificateInner();

            certInner.Location = vault.RegionName;
            certInner.KeyVaultId = vault.Id;
            certInner.KeyVaultSecretName = certificateName;

            var appServiceCertificateInner = await Manager.Inner.AppServiceCertificateOrders.CreateOrUpdateCertificateAsync(
                ResourceGroupName, Name, certificateName, certInner);
            return new AppServiceCertificateKeyVaultBindingImpl(appServiceCertificateInner, this);
        }

        ///GENMHASH:79CAEF5E7E9A0A416A2264BF89017C66:8AAFE9E6FE59125D49687296E88D04A7
        public int ValidityInYears()
        {
            return Inner.ValidityInYears.GetValueOrDefault();
        }

        ///GENMHASH:5ACBA6D500464D19A23A5A5A6A184B79:166E1A647988B47A41CA906503E86F29
        public AppServiceCertificateOrderImpl WithHostName(string hostName)
        {
            Inner.DistinguishedName = "CN=" + hostName;
            return this;
        }

        ///GENMHASH:0CD614E818D4086C936A0BF04B47C550:E31DD88A5AABE0E7EB1AA9BD08BE551A
        public async Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding> GetKeyVaultBindingAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var appServiceCertificateInnerPage = await Manager.Inner.AppServiceCertificateOrders.ListCertificatesAsync(ResourceGroupName, Name);

            // There can only be one binding associated with an order
            if (appServiceCertificateInnerPage == null || !appServiceCertificateInnerPage.Any())
            {
                return null;
            }

            return new AppServiceCertificateKeyVaultBindingImpl(appServiceCertificateInnerPage.FirstOrDefault(), this);
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:10914683BF9EB7C5E03A949613F97A5D
        public CertificateOrderStatus Status()
        {
            return Inner.Status.GetValueOrDefault();
        }

        ///GENMHASH:BA6FE1E2B7314E708853F2FBB27E3384:14CF3EB6F5E6911BFEE7C598E534E063
        public bool AutoRenew()
        {
            return Inner.AutoRenew.GetValueOrDefault();
        }

        ///GENMHASH:6BDAA4A8036F1C03CAA8CE2EB2F9FBE3:FE2E769A2AEA3ACB1FD64758285EBC71
        public CertificateDetailsImpl Intermediate()
        {
            if (Inner.Intermediate == null)
            {
                return null;
            }
            return new CertificateDetailsImpl(Inner.Intermediate);
        }

        ///GENMHASH:90FC937E60E521C5C15FEEEA8CB6CCB8:C2904A9EF2F5A312DA01425F79F55AA4
        public CertificateDetailsImpl SignedCertificate()
        {
            if (Inner.SignedCertificate == null)
            {
                return null;
            }
            return new CertificateDetailsImpl(Inner.SignedCertificate);
        }

        ///GENMHASH:998ED679562660847C6B644CE156D46C:BD8EDAEE21E0A80A3794CA1BF6C8293A
        public AppServiceCertificateOrderImpl WithWebAppVerification(IWebAppBase webApp)
        {
            this.domainVerifyWebApp = webApp;
            return this;
        }

        ///GENMHASH:C9197C0E18635D749174BA53AD8D40F2:B54E9750FAF97459979B2E19172576F0
        public string CertificateSigningRequest()
        {
            return Inner.Csr;
        }

        ///GENMHASH:DEB5B77F8D918439AB769AD1CC0E3B14:B93583F27CCE3FE1FF2B383D935B5560
        public IAppServiceCertificateKeyVaultBinding GetKeyVaultBinding()
        {
            return GetKeyVaultBinding();
        }

        ///GENMHASH:247F3F9D51B0218A2892B535E30EFFE4:88C1A66E95DDA5984E09A8B9C12ABB55
        public void VerifyDomainOwnership(IAppServiceDomain domain)
        {
            VerifyDomainOwnership(domain);
        }

        ///GENMHASH:4832496C4642B084507B2963F8963228:8BAA92C0EB2A8A25AC36BC01E781F9F7
        public DateTime? ExpirationTime()
        {
            return Inner.ExpirationTime;
        }

        ///GENMHASH:14288EE05A643ED3D2973C5B1849325A:47FC88953B7AB1BEA60CFF5682FEA186
        public AppServiceCertificateOrderImpl WithExistingKeyVault(IVault vault)
        {
            this.bindingVault = null;

            return this;
        }

        ///GENMHASH:D24D0D518EC4AAB3671622B0122F4207:E7B715DDFC308583FA7F70CF382B22AE
        public AppServiceCertificateOrderImpl WithStandardSku()
        {
            Inner.ProductType = CertificateProductType.StandardDomainValidatedSsl;
            return this;
        }

        ///GENMHASH:85BC40F9FFD1DECA3EC69CA1F69B4E31:8FEEAC0295943BA15DA8EA437906D8CE
        public AppServiceCertificateOrderImpl WithAutoRenew(bool enabled)
        {
            Inner.AutoRenew = enabled;
            return this;
        }
    }
}
