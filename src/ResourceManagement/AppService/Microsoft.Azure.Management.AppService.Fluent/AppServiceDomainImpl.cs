// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using AppServiceDomain.Definition;
    using AppServiceDomain.Update;
    using Models;
    using Resource.Fluent;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for AppServiceDomain.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZURvbWFpbkltcGw=
    internal partial class AppServiceDomainImpl :
        GroupableResource<
            IAppServiceDomain,
            DomainInner,
            AppServiceDomainImpl,
            IAppServiceManager,
            IBlank,
            IWithRegistrantContact,
            IWithCreate,
            IUpdate>,
        IAppServiceDomain,
        IDefinition,
        IUpdate
    {
        private IDictionary<string, HostName> hostNameMap;
        private string clientIp = "127.0.0.1";

        ///GENMHASH:E3A506AB29CB79E19BE35E770B4C876E:E11180BB79B722174FB3D0453FCEA12B
        public DomainStatus RegistrationStatus()
        {
            return Inner.RegistrationStatus.GetValueOrDefault();
        }

        ///GENMHASH:CD48C699C847906F9DDB2B020855A2B4:7B32ADCF145314E68A75089E358F8048
        public IReadOnlyDictionary<string, HostName> ManagedHostNames()
        {
            if (hostNameMap == null)
            {
                return null;
            }

            return new ReadOnlyDictionary<string, HostName>(hostNameMap);
        }

        ///GENMHASH:B325C6EDB78E19FA38381AFEBE68C699:93880789C7D7BC998F830F0430AFDE23
        public AppServiceDomainImpl WithRegistrantContact(Contact contact)
        {
            Inner.ContactAdmin = contact;
            Inner.ContactBilling = contact;
            Inner.ContactRegistrant = contact;
            Inner.ContactTech = contact;
            return this;
        }

        ///GENMHASH:2EBE0E253F1D6DB178F3433FF5310EA8:62D7374C9C52BDCC93D26784CA76AFA8
        public IList<string> NameServers()
        {
            return Inner.NameServers;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:A096A9B6D504D2EF53E4C2B61224B4A4
        public override async Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            string[] domainParts = this.Name.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            string topLevel = domainParts[domainParts.Length - 1];
            // Step 1: Consent to agreements
            var agreements = await Manager.Inner.TopLevelDomains.ListAgreementsAsync(topLevel);
            var agreementKeys = agreements.Select(x => x.AgreementKey).ToList();
            // Step 2: Create domain
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://azure.com");
                var request = response.RequestMessage;
            }

            Inner.Consent = new DomainPurchaseConsent()
            {
                AgreedAt = new DateTime(),
                AgreedBy = clientIp,
                AgreementKeys = agreementKeys
            };

            SetInner(await Manager.Inner.Domains.CreateOrUpdateAsync(ResourceGroupName, Name, Inner));

            return this;
        }

        ///GENMHASH:AE0056570274B48455DD7ACC9F27A81F:3E3B7D06869575F5C78E35CCAC61756F
        public AppServiceDomainImpl WithAdminContact(Contact contact)
        {
            Inner.ContactAdmin = contact;
            return this;
        }

        ///GENMHASH:DAD6DB3EAC6CE818886AEBBFB00CE7A8:401E0ADD8B6219F6D6984409E5C6ED31
        public Contact BillingContact()
        {
            return Inner.ContactBilling;
        }

        ///GENMHASH:25ECBB91358E945934523C6618D3A175:9790BA604E44527A0ACFB87F8D1F3432
        public AppServiceDomainImpl WithBillingContact(Contact contact)
        {
            Inner.ContactBilling = contact;
            return this;
        }

        ///GENMHASH:86C009804770AC54F0EF700492B5521A:3F31672F95C70228EC68BAF9D885F605
        internal AppServiceDomainImpl(string name, DomainInner innerObject, IAppServiceManager manager)
            : base(name, innerObject, manager)
        {
            Inner.Location = "global";
            if (Inner.ManagedHostNames != null)
            {
                hostNameMap = Inner.ManagedHostNames.ToDictionary(h => h.Name);
            }
        }

        ///GENMHASH:B023ACEE2E8E886E8EC94C82F6C93544:19266588ED73C70479B22B9357256AED
        public bool ReadyForDnsRecordManagement()
        {
            return Inner.ReadyForDnsRecordManagement.GetValueOrDefault();
        }

        ///GENMHASH:CC6E0592F0BCD4CD83D832B40167E562:D41B9629ECB5CD8AE8852218E07D95CC
        public async Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken))
        {
            DomainOwnershipIdentifierInner identifierInner = new DomainOwnershipIdentifierInner()
            {
                Location = "global",
                OwnershipId = domainVerificationToken
            };
            await Manager.Inner.Domains.CreateOrUpdateOwnershipIdentifierAsync(ResourceGroupName, Name, certificateOrderName, identifierInner);
        }

        ///GENMHASH:EE3A4FAA12095D4EBD752C6D82325EDA:DD8B0DBE8A8402002F39ECC61A75D5BE
        public Contact RegistrantContact()
        {
            return Inner.ContactRegistrant;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:24635E3B6AB96D3E6BFB9DA2AF7C6AB5
        public override IAppServiceDomain Refresh()
        {
            this.SetInner(Manager.Inner.Domains.Get(ResourceGroupName, Name));
            return this;
        }

        ///GENMHASH:F68B7C06A96EFE50420CFD0AF40077FB:26EA9A37169A3648217216A1F31DE87A
        public Contact AdminContact()
        {
            return Inner.ContactAdmin;
        }

        ///GENMHASH:7EDAD5E463253CD91487112D769E5CEB:EDF3C8E01B8C87E9F1967C7BA6AA29AF
        public AppServiceDomainImpl WithDomainPrivacyEnabled(bool domainPrivacy)
        {
            Inner.Privacy = domainPrivacy;
            return this;
        }

        ///GENMHASH:7DBBDC25F58D466AD09403C212DD85DF:CECEB118A3DA0C515FB74BE0D6D9C14C
        public Contact TechContact()
        {
            return Inner.ContactTech;
        }

        ///GENMHASH:809F7C2A470541FEE2E6E71AB92C8FFC:88752E3558468515A86B34901E5EF9BF
        public DomainPurchaseConsent Consent()
        {
            return Inner.Consent;
        }

        ///GENMHASH:5995F84711525BE1DF7039D80FA0DB81:FD36CC16B0F887062F41FE2350D0730E
        public DateTime CreatedTime()
        {
            return Inner.CreatedTime.GetValueOrDefault();
        }

        ///GENMHASH:DBA6815EBA79F0E01B35956CD8DCD5A2:C1913678BBD6634C7B4E02B1C3F7F9BE
        public bool Privacy()
        {
            return Inner.Privacy.GetValueOrDefault();
        }

        ///GENMHASH:41623473E4BF423028E4B08F2C4942DB:917E448810EBA2D53E9DC69100F474BB
        public DateTime LastRenewedTime()
        {
            return Inner.LastRenewedTime.GetValueOrDefault();
        }

        ///GENMHASH:BA6FE1E2B7314E708853F2FBB27E3384:14CF3EB6F5E6911BFEE7C598E534E063
        public bool AutoRenew()
        {
            return Inner.AutoRenew.GetValueOrDefault();
        }

        ///GENMHASH:2ABF2C4DD400A4212AE592552C6810E4:D4B087937E8FB132F99CE79CA3F74A48
        public AppServiceDomainImpl WithAutoRenewEnabled(bool autoRenew)
        {
            Inner.AutoRenew = autoRenew;
            return this;
        }

        ///GENMHASH:EB8C33DACE377CBB07C354F38C5BEA32:391885361D8D6FDB8CD9E96400E16B73
        public void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
            VerifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken).Wait();
        }

        ///GENMHASH:5CD8F39F706EAB04A535707B7DF3A013:718ADC376CD7CA3987522D4C1A280D4D
        public AppServiceDomainImpl WithTechContact(Contact contact)
        {
            Inner.ContactTech = contact;
            return this;
        }

        ///GENMHASH:4832496C4642B084507B2963F8963228:8BAA92C0EB2A8A25AC36BC01E781F9F7
        public DateTime ExpirationTime()
        {
            return Inner.ExpirationTime.GetValueOrDefault();
        }

        ///GENMHASH:9E263F72C0A5B9EBC6A0238B83B03A67:7ECFE1750E97BCA44690E1A7698CEB5F
        public DomainContactImpl DefineRegistrantContact()
        {
            return new DomainContactImpl(new Contact(), this);
        }

        public IWithCreate WithClientIpAddress(string ipAddress)
        {
            clientIp = ipAddress;
            return this; 
        }
    }
}
