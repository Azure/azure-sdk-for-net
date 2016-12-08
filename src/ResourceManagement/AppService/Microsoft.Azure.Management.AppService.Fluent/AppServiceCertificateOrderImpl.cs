// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServiceCertificateOrder.Definition;
    using AppServiceCertificateOrder.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// The implementation for AppServicePlan.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZUNlcnRpZmljYXRlT3JkZXJJbXBs
    internal partial class AppServiceCertificateOrderImpl  :
        GroupableResource<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder,Microsoft.Azure.Management.AppService.Fluent.Models.AppServiceCertificateOrderInner,Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrderImpl,Microsoft.Azure.Management.AppService.Fluent.Models.AppServiceManager>,
        IAppServiceCertificateOrder,
        IDefinition,
        IUpdate
    {
        final AppServiceCertificateOrdersInner client;
        private IWebAppBase<object> domainVerifyWebApp;
        private IAppServiceDomain domainVerifyDomain;
        private Observable<Microsoft.Azure.Management.Fluent.KeyVault.IVault> bindingVault;
        ///GENMHASH:614D2D9852F00FD5BFCAF60BA2A659B0:86E327FE34A305973AC1A32ECEC60D57
        public AppServiceCertificateOrderImpl WithDomainVerification(IAppServiceDomain domain)
        {
            //$ this.domainVerifyDomain = domain;
            //$ return this;

            return this;
        }

        ///GENMHASH:DF3D2D5058A900DD3618F549F0472A00:691932AACB2AD199524486E8BFB6D5D8
        public int KeySize()
        {
            //$ return Inner.KeySize();

            return 0;
        }

        ///GENMHASH:16ABBA273C3F791D052D0188B2107D3F:675930B8422D1B7EC65FC1D9BBC5D548
        public CertificateDetailsImpl Root()
        {
            //$ if (Inner.Root() == null) {
            //$ return null;
            //$ }
            //$ return new CertificateDetailsImpl(Inner.Root());

            return null;
        }

        ///GENMHASH:C70ACBF55B279BA26BBE5F77DDE46E40:9790D012FA64E47343F12DB13F0AA212
        public string SerialNumber()
        {
            //$ return null;

            return null;
        }

        ///GENMHASH:EBED0BAEEB9CC9BC93879B3D5FFD0E0C:46D041A38A4369ED8F41B9FE21E6FD13
        public AppServiceCertificateOrderImpl WithWildcardSku()
        {
            //$ Inner.WithProductType(CertificateProductType.STANDARD_DOMAIN_VALIDATED_WILD_CARD_SSL);
            //$ return this;

            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:88F80234ADBF5F0E8B64015C7A3EF8D0
        public async Task<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ AppServiceCertificateOrder self = this;
            //$ return client.CreateOrUpdateAsync(resourceGroupName(), name(), Inner)
            //$ .Map(innerToFluentMap(this))
            //$ .FlatMap(new Func1<AppServiceCertificateOrder, Observable<Void>>() {
            //$ @Override
            //$ public Observable<Void> call(AppServiceCertificateOrder certificateOrder) {
            //$ if (domainVerifyWebApp != null) {
            //$ return domainVerifyWebApp.VerifyDomainOwnershipAsync(name(), domainVerificationToken());
            //$ } else if (domainVerifyDomain != null) {
            //$ return domainVerifyDomain.VerifyDomainOwnershipAsync(name(), domainVerificationToken());
            //$ } else {
            //$ throw new IllegalArgumentException(
            //$ "Please specify a non-null web app or domain to verify the domain ownership "
            //$ + "for hostname " + distinguishedName());
            //$ }
            //$ }
            //$ })
            //$ .FlatMap(new Func1<Void, Observable<AppServiceCertificateKeyVaultBinding>>() {
            //$ @Override
            //$ public Observable<AppServiceCertificateKeyVaultBinding> call(Void aVoid) {
            //$ return bindingVault.FlatMap(new Func1<Vault, Observable<AppServiceCertificateKeyVaultBinding>>() {
            //$ @Override
            //$ public Observable<AppServiceCertificateKeyVaultBinding> call(Vault vault) {
            //$ return createKeyVaultBindingAsync(name(), vault);
            //$ }
            //$ });
            //$ }
            //$ })
            //$ .Map(new Func1<AppServiceCertificateKeyVaultBinding, AppServiceCertificateOrder>() {
            //$ @Override
            //$ public AppServiceCertificateOrder call(AppServiceCertificateKeyVaultBinding appServiceCertificateKeyVaultBinding) {
            //$ return self;
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:499D8F0148B4BCCD39D3D315006B873B:7BD59E082FC291DFA61838F7738DE972
        public string DomainVerificationToken()
        {
            //$ return Inner.DomainVerificationToken();

            return null;
        }

        ///GENMHASH:5DE7453277A4AF0C4B6125DBB0CE2C7C:2679171F2B11163B47E7F6C005E59EFB
        public CertificateProductType ProductType()
        {
            //$ return Inner.ProductType();

            return CertificateProductType.StandardDomainValidatedSsl;
        }

        ///GENMHASH:11AF5CEDE5EC5110A3D190463E690E16:0B6EB716D0098ABB085A80641A141FD0
        public AppServiceCertificateOrderImpl WithNewKeyVault(string vaultName, Region region)
        {
            //$ Observable<Indexable> resourceStream = myManager.KeyVaultManager().Vaults().Define(vaultName)
            //$ .WithRegion(region)
            //$ .WithExistingResourceGroup(resourceGroupName())
            //$ .DefineAccessPolicy()
            //$ .ForServicePrincipal("f3c21649-0979-4721-ac85-b0216b2cf413")
            //$ .AllowSecretPermissions(SecretPermissions.GET, SecretPermissions.SET, SecretPermissions.DELETE)
            //$ .Attach()
            //$ .DefineAccessPolicy()
            //$ .ForServicePrincipal("abfa0a7c-a6b6-4736-8310-5855508787cd")
            //$ .AllowSecretPermissions(SecretPermissions.GET)
            //$ .Attach()
            //$ .CreateAsync();
            //$ this.bindingVault = Utils.RootResource(resourceStream);
            //$ return this;

            return this;
        }

        ///GENMHASH:DA9AB2A1A8F9DE8FFE3FD3F6C1C8F073:0419F3D0B678E962DE6B096A8D7646DC
        public IAppServiceCertificateKeyVaultBinding CreateKeyVaultBinding(string certificateName, IVault vault)
        {
            //$ return createKeyVaultBindingAsync(certificateName, vault).ToBlocking().Single();

            return null;
        }

        ///GENMHASH:6B60EDADBCA134B9C9928244109B6E1B:5781A8E04FCEFEA9CF50B97FD61BE42B
        public async Task VerifyDomainOwnershipAsync(IAppServiceDomain domain, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return domain.VerifyDomainOwnershipAsync(name(), domainVerificationToken());

            return null;
        }

        ///GENMHASH:89B68C3393E544990D0BC1837B4C4C0E:B1CB960E9688630133BF735EE72C4279
        internal  AppServiceCertificateOrderImpl(string key, AppServiceCertificateOrderInner innerObject, AppServiceCertificateOrdersInner client, AppServiceManager manager)
        {
            //$ super(key, innerObject, manager);
            //$ this.client = client;
            //$ this.WithRegion("global").WithValidYears(1);
            //$ }

        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:24635E3B6AB96D3E6BFB9DA2AF7C6AB5
        public IAppServiceCertificateOrder Refresh()
        {
            //$ this.SetInner(client.Get(resourceGroupName(), name()));
            //$ return this;

            return null;
        }

        ///GENMHASH:9FDF35464E02B70B2EF312DAD321B8C2:9790D012FA64E47343F12DB13F0AA212
        public DateTime LastCertificateIssuanceTime()
        {
            //$ return null;

            return DateTime.Now;
        }

        ///GENMHASH:575807260557ED62F7AE130CBDC3F619:847ACFDD52BB5E87BABA56BD49D03F37
        public string DistinguishedName()
        {
            //$ return Inner.DistinguishedName();

            return null;
        }

        ///GENMHASH:359FB978D2F52E392FF6FE0BE3D1BF9B:013D8DD2D085E4A74D18D9EBEDB06FDC
        public AppServiceCertificateOrderImpl WithValidYears(int years)
        {
            //$ Inner.WithValidityInYears(years);
            //$ return this;

            return this;
        }

        ///GENMHASH:04406413E97C82F19F013C72D1DD2758:39E496E31AE9087192892138F0910259
        public async Task<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding> CreateKeyVaultBindingAsync(string certificateName, IVault vault, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ AppServiceCertificateInner certInner = new AppServiceCertificateInner();
            //$ certInner.WithLocation(vault.RegionName());
            //$ certInner.WithKeyVaultId(vault.Id());
            //$ certInner.WithKeyVaultSecretName(certificateName);
            //$ AppServiceCertificateOrderImpl self = this;
            //$ return client.CreateOrUpdateCertificateAsync(resourceGroupName(), name(), certificateName, certInner)
            //$ .Map(new Func1<AppServiceCertificateInner, AppServiceCertificateKeyVaultBinding>() {
            //$ @Override
            //$ public AppServiceCertificateKeyVaultBinding call(AppServiceCertificateInner appServiceCertificateInner) {
            //$ return new AppServiceCertificateKeyVaultBindingImpl(appServiceCertificateInner, self);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:79CAEF5E7E9A0A416A2264BF89017C66:D280C94728CB28932A694CCBE324641F
        public int ValidityInYears()
        {
            //$ return Inner.ValidityInYears();

            return 0;
        }

        ///GENMHASH:5ACBA6D500464D19A23A5A5A6A184B79:166E1A647988B47A41CA906503E86F29
        public AppServiceCertificateOrderImpl WithHostName(string hostName)
        {
            //$ Inner.WithDistinguishedName("CN=" + hostName);
            //$ return this;

            return this;
        }

        ///GENMHASH:0CD614E818D4086C936A0BF04B47C550:E31DD88A5AABE0E7EB1AA9BD08BE551A
        public async Task<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding> GetKeyVaultBindingAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ AppServiceCertificateOrderImpl self = this;
            //$ return client.ListCertificatesAsync(resourceGroupName(), name())
            //$ .Map(new Func1<Page<AppServiceCertificateInner>, AppServiceCertificateKeyVaultBinding>() {
            //$ @Override
            //$ public AppServiceCertificateKeyVaultBinding call(Page<AppServiceCertificateInner> appServiceCertificateInnerPage) {
            //$ // There can only be one binding associated with an order
            //$ if (appServiceCertificateInnerPage.GetItems() == null || appServiceCertificateInnerPage.GetItems().IsEmpty()) {
            //$ return null;
            //$ } else {
            //$ return new AppServiceCertificateKeyVaultBindingImpl(appServiceCertificateInnerPage.GetItems().Get(0), self);
            //$ }
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:10914683BF9EB7C5E03A949613F97A5D
        public CertificateOrderStatus Status()
        {
            //$ return Inner.Status();

            return CertificateOrderStatus.PENDINGISSUANCE;
        }

        ///GENMHASH:BA6FE1E2B7314E708853F2FBB27E3384:14CF3EB6F5E6911BFEE7C598E534E063
        public bool AutoRenew()
        {
            //$ return Utils.ToPrimitiveBoolean(Inner.AutoRenew());

            return false;
        }

        ///GENMHASH:6BDAA4A8036F1C03CAA8CE2EB2F9FBE3:FE2E769A2AEA3ACB1FD64758285EBC71
        public CertificateDetailsImpl Intermediate()
        {
            //$ if (Inner.Intermediate() == null) {
            //$ return null;
            //$ }
            //$ return new CertificateDetailsImpl(Inner.Intermediate());

            return null;
        }

        ///GENMHASH:90FC937E60E521C5C15FEEEA8CB6CCB8:C2904A9EF2F5A312DA01425F79F55AA4
        public CertificateDetailsImpl SignedCertificate()
        {
            //$ if (Inner.SignedCertificate() == null) {
            //$ return null;
            //$ }
            //$ return new CertificateDetailsImpl(Inner.SignedCertificate());

            return null;
        }

        ///GENMHASH:6AABC99EE2CD0FF3E4F20F76A87BFD92:BD8EDAEE21E0A80A3794CA1BF6C8293A
        public AppServiceCertificateOrderImpl WithWebAppVerification(IWebAppBase<object> webApp)
        {
            //$ this.domainVerifyWebApp = webApp;
            //$ return this;

            return this;
        }

        ///GENMHASH:C9197C0E18635D749174BA53AD8D40F2:B54E9750FAF97459979B2E19172576F0
        public string CertificateSigningRequest()
        {
            //$ return Inner.Csr();

            return null;
        }

        ///GENMHASH:DEB5B77F8D918439AB769AD1CC0E3B14:B93583F27CCE3FE1FF2B383D935B5560
        public IAppServiceCertificateKeyVaultBinding GetKeyVaultBinding()
        {
            //$ return getKeyVaultBindingAsync().ToBlocking().Single();

            return null;
        }

        ///GENMHASH:247F3F9D51B0218A2892B535E30EFFE4:88C1A66E95DDA5984E09A8B9C12ABB55
        public void VerifyDomainOwnership(IAppServiceDomain domain)
        {
            //$ verifyDomainOwnershipAsync(domain).ToBlocking().Subscribe();

        }

        ///GENMHASH:4832496C4642B084507B2963F8963228:9790D012FA64E47343F12DB13F0AA212
        public DateTime ExpirationTime()
        {
            //$ return null;

            return DateTime.Now;
        }

        ///GENMHASH:14288EE05A643ED3D2973C5B1849325A:47FC88953B7AB1BEA60CFF5682FEA186
        public AppServiceCertificateOrderImpl WithExistingKeyVault(IVault vault)
        {
            //$ this.bindingVault = Observable.Just(vault);
            //$ return this;

            return this;
        }

        ///GENMHASH:D24D0D518EC4AAB3671622B0122F4207:E7B715DDFC308583FA7F70CF382B22AE
        public AppServiceCertificateOrderImpl WithStandardSku()
        {
            //$ Inner.WithProductType(CertificateProductType.STANDARD_DOMAIN_VALIDATED_SSL);
            //$ return this;

            return this;
        }

        ///GENMHASH:85BC40F9FFD1DECA3EC69CA1F69B4E31:8FEEAC0295943BA15DA8EA437906D8CE
        public AppServiceCertificateOrderImpl WithAutoRenew(bool enabled)
        {
            //$ Inner.WithAutoRenew(enabled);
            //$ return this;

            return this;
        }
    }
}