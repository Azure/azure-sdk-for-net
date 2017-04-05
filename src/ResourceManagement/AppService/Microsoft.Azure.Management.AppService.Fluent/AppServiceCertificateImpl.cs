// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using AppServiceCertificate.Definition;
    using Models;
    using ResourceManager.Fluent;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for AppServicePlan.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZUNlcnRpZmljYXRlSW1wbA==
    internal partial class AppServiceCertificateImpl :
        GroupableResource<
            IAppServiceCertificate,
            CertificateInner,
            AppServiceCertificateImpl,
            IAppServiceManager,
            IWithGroup,
            IWithCertificate,
            IWithCreate,
            IWithCreate>,
        IAppServiceCertificate,
        IDefinition
    {
        private string pfxFileUrl;
        private IAppServiceCertificateOrder certificateOrder;

        ///GENMHASH:FE752DDF44282A56AF34B30988879EA2:796AE580B30EF9EFB269764BDE769297
        public bool Valid()
        {
            return Inner.Valid.GetValueOrDefault();
        }

        ///GENMHASH:33ACB5F5716AE1E9ACE170EA372F5E74:7104B35B584CA7CA69B3635CA39E3D6F
        public byte[] PfxBlob()
        {
            return Inner.PfxBlob;
        }

        ///GENMHASH:66993FA323F1120EEA87A92DAC759CE2:04076664CA806EC34620BE36025013D3
        public DateTime ExpirationDate()
        {
            return Inner.ExpirationDate.GetValueOrDefault();
        }

        ///GENMHASH:CAA033773D5432C1A5FE6923C43922F2:BCF275EE65AC4947C78F0F7B514296B6
        public AppServiceCertificateImpl WithPfxFileFromUrl(string url)
        {
            this.pfxFileUrl = url;
            return this;
        }

        ///GENMHASH:7D4A70D4812365A34F85C2A5F6C031DB:F4E484108C088F35C74B08AFB7D9422C
        public string CertificateBlob()
        {
            return Inner.CerBlob;
        }

        ///GENMHASH:8F04665E49050E6C5BD8AE7B8E51D285:415AB6515F3750504B0F67632D677FD0
        public string Thumbprint()
        {
            return Inner.Thumbprint;
        }

        ///GENMHASH:F95B4E80896050A9F86E41E6D2114288:4BF9A6B8351EC58E9608C2F38FADFD12
        public string FriendlyName()
        {
            return Inner.FriendlyName;
        }

        ///GENMHASH:C543CA29E6566D54AAC91A932C2F270C:FE944934BAC3A1D9B16DDC1D992C6F36
        public DateTime IssueDate()
        {
            return Inner.IssueDate.GetValueOrDefault();
        }

        ///GENMHASH:935E8A144BD263041B17092AD69A49F8:5448176B508890855BDBD9190EE138FD
        public IList<string> HostNames()
        {
            return Inner.HostNames;
        }

        ///GENMHASH:E92DD2C5C752DBA63D9A9B417D2C0DF2:AFA4B6916582F02ADC9FC929B3B78C12
        public string SelfLink()
        {
            return Inner.SelfLink;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:D94AECC923C51EA4319E926F688C77A1
        public async override Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (pfxFileUrl != null)
            {
                using (var httpClient = new HttpClient())
                {
                    Inner.PfxBlob = await httpClient.GetByteArrayAsync(pfxFileUrl);
                }
            }
            if (certificateOrder != null)
            {
                var keyVaultBinding = await certificateOrder.GetKeyVaultBindingAsync();
                Inner.KeyVaultId = keyVaultBinding.KeyVaultId;
                Inner.KeyVaultSecretName = keyVaultBinding.KeyVaultSecretName;
            }
            SetInner(await Manager.Inner.Certificates.CreateOrUpdateAsync(ResourceGroupName, Name, Inner));
            return this;
        }

        ///GENMHASH:034EEEACD216C176420A4F07EA7B2431:C0DA0F79245486A0C66768FFF475B92C
        public HostingEnvironmentProfile HostingEnvironmentProfile()
        {
            return Inner.HostingEnvironmentProfile;
        }

        ///GENMHASH:A369C4EBDDE4CC27126D90BC7903E73F:BE8560F8BDBEA9D6C134211A6E9DA2EA
        public string Password()
        {
            return Inner.Password;
        }

        ///GENMHASH:20E6624DF2940853131BE739CF767D2C:1F2F5D302EABD98268BDBB13E01838EF
        public AppServiceCertificateImpl WithPfxByteArray(params byte[] pfxByteArray)
        {
            Inner.PfxBlob = pfxByteArray;
            return this;
        }

        ///GENMHASH:AC6417B918116F35EBE473B129196305:384E705246D7390325CE35ED8089B693
        public AppServiceCertificateImpl WithPfxFile(string path)
        {
            byte[] fileContent = File.ReadAllBytes(path);
            return WithPfxByteArray(fileContent);
        }

        ///GENMHASH:41B8D2ED29E80B92BB322B9C8B98A287:8A264E667F06CE3E13EBAC780725861E
        internal AppServiceCertificateImpl(string Name, CertificateInner innerObject, IAppServiceManager manager)
                    : base(Name, innerObject, manager)
        {
        }

        ///GENMHASH:2011D9A3168939FB5CC6C7A6E7141572:CEC8E083AF5149E6FBE98797F626ABD8
        public string SubjectName()
        {
            return Inner.SubjectName;
        }

        ///GENMHASH:1FEB53873B02953EA0CD266740DA9FCB:E017957F7666F01443438263FECCC29A
        public string Issuer()
        {
            return Inner.Issuer;
        }

        ///GENMHASH:EC496C544BFDFD841E4504B1598389A4:8165169EAF5199EC92534BD2D07086F8
        public AppServiceCertificateImpl WithExistingCertificateOrder(IAppServiceCertificateOrder certificateOrder)
        {
            this.certificateOrder = certificateOrder;
            return this;
        }

        ///GENMHASH:FB755F807F3E2AD363BCB2347438D24D:F3325F0F5DDDE33DBB503479EF6298CC
        public string PublicKeyHash()
        {
            return Inner.PublicKeyHash;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:24635E3B6AB96D3E6BFB9DA2AF7C6AB5
        protected override async Task<CertificateInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.Certificates.GetAsync(ResourceGroupName,
                Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:1CE69EE8CADD589DFF9EE88A8E75ED38:0AC8A05BCD3A6B7CBD7958C57BCC894F
        public string SiteName()
        {
            return Inner.SiteName;
        }

        ///GENMHASH:079EAB40DB57656F562BDBA357A86C43:0939FE62D67DBDA5E39668E3B91EFBC1
        public AppServiceCertificateImpl WithPfxPassword(string password)
        {
            Inner.Password = password;
            return this;
        }
    }
}
