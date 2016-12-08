// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServiceCertificate.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Java.Io;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// The implementation for AppServicePlan.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZUNlcnRpZmljYXRlSW1wbA==
    internal partial class AppServiceCertificateImpl  :
        GroupableResource<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificate,Microsoft.Azure.Management.AppService.Fluent.Models.CertificateInner,Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateImpl,Microsoft.Azure.Management.AppService.Fluent.Models.AppServiceManager>,
        IAppServiceCertificate,
        IDefinition
    {
        private CertificatesInner client;
        private string pfxFileUrl;
        private IAppServiceCertificateOrder certificateOrder;
        ///GENMHASH:FE752DDF44282A56AF34B30988879EA2:796AE580B30EF9EFB269764BDE769297
        public bool Valid()
        {
            //$ return Inner.Valid();

            return false;
        }

        ///GENMHASH:33ACB5F5716AE1E9ACE170EA372F5E74:7104B35B584CA7CA69B3635CA39E3D6F
        public byte PfxBlob()
        {
            //$ return Inner.PfxBlob();

            return 0;
        }

        ///GENMHASH:66993FA323F1120EEA87A92DAC759CE2:04076664CA806EC34620BE36025013D3
        public DateTime ExpirationDate()
        {
            //$ return Inner.ExpirationDate();

            return DateTime.Now;
        }

        ///GENMHASH:CAA033773D5432C1A5FE6923C43922F2:BCF275EE65AC4947C78F0F7B514296B6
        public AppServiceCertificateImpl WithPfxFileFromUrl(string url)
        {
            //$ this.pfxFileUrl = url;
            //$ return this;

            return this;
        }

        ///GENMHASH:7D4A70D4812365A34F85C2A5F6C031DB:F4E484108C088F35C74B08AFB7D9422C
        public string CertificateBlob()
        {
            //$ return Inner.CerBlob();

            return null;
        }

        ///GENMHASH:8F04665E49050E6C5BD8AE7B8E51D285:415AB6515F3750504B0F67632D677FD0
        public string Thumbprint()
        {
            //$ return Inner.Thumbprint();

            return null;
        }

        ///GENMHASH:F95B4E80896050A9F86E41E6D2114288:4BF9A6B8351EC58E9608C2F38FADFD12
        public string FriendlyName()
        {
            //$ return Inner.FriendlyName();

            return null;
        }

        ///GENMHASH:C543CA29E6566D54AAC91A932C2F270C:FE944934BAC3A1D9B16DDC1D992C6F36
        public DateTime IssueDate()
        {
            //$ return Inner.IssueDate();

            return DateTime.Now;
        }

        ///GENMHASH:935E8A144BD263041B17092AD69A49F8:5448176B508890855BDBD9190EE138FD
        public IList<string> HostNames()
        {
            //$ return Collections.UnmodifiableList(Inner.HostNames());

            return null;
        }

        ///GENMHASH:E92DD2C5C752DBA63D9A9B417D2C0DF2:AFA4B6916582F02ADC9FC929B3B78C12
        public string SelfLink()
        {
            //$ return Inner.SelfLink();

            return null;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:D94AECC923C51EA4319E926F688C77A1
        public async Task<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificate> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ Observable<Void> pfxBytes = Observable.Just(null);
            //$ if (pfxFileUrl != null) {
            //$ pfxBytes = Utils.DownloadFileAsync(pfxFileUrl, myManager.RestClient().Retrofit())
            //$ .Map(new Func1<byte[], Void>() {
            //$ @Override
            //$ public Void call(byte[] bytes) {
            //$ Inner.WithPfxBlob(bytes);
            //$ return null;
            //$ }
            //$ });
            //$ }
            //$ Observable<Void> keyVaultBinding = Observable.Just(null);
            //$ if (certificateOrder != null) {
            //$ keyVaultBinding = certificateOrder.GetKeyVaultBindingAsync()
            //$ .Map(new Func1<AppServiceCertificateKeyVaultBinding, Void>() {
            //$ @Override
            //$ public Void call(AppServiceCertificateKeyVaultBinding keyVaultBinding) {
            //$ Inner.WithKeyVaultId(keyVaultBinding.KeyVaultId()).WithKeyVaultSecretName(keyVaultBinding.KeyVaultSecretName());
            //$ return null;
            //$ }
            //$ });
            //$ }
            //$ return pfxBytes.ConcatWith(keyVaultBinding).Last()
            //$ .FlatMap(new Func1<Void, Observable<CertificateInner>>() {
            //$ @Override
            //$ public Observable<CertificateInner> call(Void aVoid) {
            //$ return client.CreateOrUpdateAsync(resourceGroupName(), name(), Inner);
            //$ }
            //$ }).Map(innerToFluentMap(this));

            return null;
        }

        ///GENMHASH:034EEEACD216C176420A4F07EA7B2431:C0DA0F79245486A0C66768FFF475B92C
        public HostingEnvironmentProfile HostingEnvironmentProfile()
        {
            //$ return Inner.HostingEnvironmentProfile();

            return null;
        }

        ///GENMHASH:A369C4EBDDE4CC27126D90BC7903E73F:BE8560F8BDBEA9D6C134211A6E9DA2EA
        public string Password()
        {
            //$ return Inner.Password();

            return null;
        }

        ///GENMHASH:20E6624DF2940853131BE739CF767D2C:1F2F5D302EABD98268BDBB13E01838EF
        public AppServiceCertificateImpl WithPfxByteArray(params byte[] pfxByteArray)
        {
            //$ Inner.WithPfxBlob(pfxByteArray);
            //$ return this;

            return this;
        }

        ///GENMHASH:AC6417B918116F35EBE473B129196305:384E705246D7390325CE35ED8089B693
        public AppServiceCertificateImpl WithPfxFile(File file)
        {
            //$ try {
            //$ byte[] fileContent = Files.ReadAllBytes(file.ToPath());
            //$ return withPfxByteArray(fileContent);
            //$ } catch (IOException e) {
            //$ throw new RuntimeException(e);
            //$ }

            return this;
        }

        ///GENMHASH:41B8D2ED29E80B92BB322B9C8B98A287:8A264E667F06CE3E13EBAC780725861E
        internal  AppServiceCertificateImpl(string name, CertificateInner innerObject, CertificatesInner client, AppServiceManager manager)
        {
            //$ super(name, innerObject, manager);
            //$ this.client = client;
            //$ }

        }

        ///GENMHASH:2011D9A3168939FB5CC6C7A6E7141572:CEC8E083AF5149E6FBE98797F626ABD8
        public string SubjectName()
        {
            //$ return Inner.SubjectName();

            return null;
        }

        ///GENMHASH:1FEB53873B02953EA0CD266740DA9FCB:E017957F7666F01443438263FECCC29A
        public string Issuer()
        {
            //$ return Inner.Issuer();

            return null;
        }

        ///GENMHASH:EC496C544BFDFD841E4504B1598389A4:8165169EAF5199EC92534BD2D07086F8
        public AppServiceCertificateImpl WithExistingCertificateOrder(IAppServiceCertificateOrder certificateOrder)
        {
            //$ this.certificateOrder = certificateOrder;
            //$ return this;

            return this;
        }

        ///GENMHASH:FB755F807F3E2AD363BCB2347438D24D:F3325F0F5DDDE33DBB503479EF6298CC
        public string PublicKeyHash()
        {
            //$ return Inner.PublicKeyHash();

            return null;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:24635E3B6AB96D3E6BFB9DA2AF7C6AB5
        public IAppServiceCertificate Refresh()
        {
            //$ this.SetInner(client.Get(resourceGroupName(), name()));
            //$ return this;

            return null;
        }

        ///GENMHASH:1CE69EE8CADD589DFF9EE88A8E75ED38:0AC8A05BCD3A6B7CBD7958C57BCC894F
        public string SiteName()
        {
            //$ return Inner.SiteName();

            return null;
        }

        ///GENMHASH:079EAB40DB57656F562BDBA357A86C43:0939FE62D67DBDA5E39668E3B91EFBC1
        public AppServiceCertificateImpl WithPfxPassword(string password)
        {
            //$ Inner.WithPassword(password);
            //$ return this;

            return this;
        }
    }
}