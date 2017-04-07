// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using DomainContact.Definition;
    using Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for DomainContact and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uRG9tYWluQ29udGFjdEltcGw=
    internal partial class DomainContactImpl :
        ChildResource<
            Contact,
            AppServiceDomainImpl,
            IAppServiceDomain>,
        IDomainContact,
        IDefinition<AppServiceDomain.Definition.IWithCreate>
    {

        ///GENMHASH:E2556AE34728DF24E72DF3C66A32C04C:E02667C88CE448AD1B7486F41880FAD2
        public string Phone()
        {
            return Inner.Phone;
        }

        ///GENMHASH:5BE3BE3B9D2A467C243AE11550C12648:FAA682AFBE97FA2BE57C6D3557F69E63
        public DomainContactImpl WithAddressLine2(string addressLine2)
        {
            Inner.AddressMailing.Address2 = addressLine2;

            return this;
        }

        ///GENMHASH:A2410FFAF22DDB24E8AAB7622E498164:3400BF47ADE77DCA1540472C1E1BB0BB

        public DomainContactImpl WithCountry(CountryISOCode country)
        {
            Inner.AddressMailing.Country = country.ToString();
            return this;
        }

        ///GENMHASH:5AF341C74E751D877DBC907DEE9FB6E5:6A84F8A90B33BCB8847B00822EDA5BA4
        public DomainContactImpl WithOrganization(string organization)
        {
            Inner.Organization = organization;

            return this;
        }

        ///GENMHASH:A2B17F44695823C1E3903551BA5C3CC9:A4F741631338083BF074F4CD72F5D842
        public DomainContactImpl WithPhoneNumber(string phoneNumber)
        {
            Inner.Phone = Inner.Phone + phoneNumber;

            return this;
        }

        ///GENMHASH:70CB9F0E151C963A75B5B96AFAE39B5F:01AC40DD6D12F2BD8D9C6B009BD03E3D
        public DomainContactImpl WithFaxNumber(string faxNumber)
        {
            Inner.Fax = faxNumber;

            return this;
        }

        ///GENMHASH:C557F4B5F2F592A2575899457D05F7D0:D0CE837A862AA4246E3579FD07D708BC
        public DomainContactImpl WithFirstName(string firstName)
        {
            Inner.NameFirst = firstName;
            return this;
        }

        ///GENMHASH:15E687D044E3578EDE1C3EDAF5244812:29DF22F2F09A0951595F1DAE2AF3C19E
        public Contact Build()
        {
            return Inner;
        }

        ///GENMHASH:58653FBF67614C576CE8A40349D4391E:807726497D1D2FB284D366BCAA405157
        public string Organization()
        {
            return Inner.Organization;
        }

        ///GENMHASH:10AAFDEA834D7BD2EA3B68A73335B477:366B2C949553B6A2C6731EF8381D3242
        public DomainContactImpl WithPostalCode(string postalCode)
        {
            Inner.AddressMailing.PostalCode = postalCode;

            return this;
        }

        ///GENMHASH:79B40BC8608C55BE421D10368B0976C1:911F023FD93228E0A2290FC557D6B492
        public DomainContactImpl WithCity(string city)
        {
            Inner.AddressMailing.City = city;

            return this;
        }

        ///GENMHASH:7889548B9BAFFCA4BCE9611AB7537D7E:FD47C7BDBB4D6196F44827FDCA25F936
        public DomainContactImpl WithStateOrProvince(string stateOrProvince)
        {
            Inner.AddressMailing.State = stateOrProvince;

            return this;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:A79CB48AB5861773F4793C7D7EF8C441
        public override string Name()
        {
            return FirstName() + " " + LastName();
        }

        ///GENMHASH:4B771256FCDA8C3E76180E4C619BD572:8FDF79DE1C72832B4A51E71DB3D083BB
        public DomainContactImpl WithPhoneCountryCode(CountryPhoneCode code)
        {
            Inner.Phone = code.ToString() + ".";
            return this;
        }

        ///GENMHASH:6524D52403C5BD043D37DA4F0F15961B:DAAC4D48C45F13A8F56E05F5BCE05D55
        public DomainContactImpl WithMiddleName(string middleName)
        {
            Inner.NameMiddle = middleName;

            return this;
        }

        ///GENMHASH:458F4F987FCBAFE5716EE7374C366155:6EE77FC50D0AAD5B152A749B13000F94
        public string FirstName()
        {
            return Inner.NameFirst;
        }

        ///GENMHASH:F57DD2745A5BE1562BD704BD6244DE40:40B7B8F35DA0A767AC5D1BF3A4BC9043
        public DomainContactImpl WithAddressLine1(string addressLine1)
        {
            Inner.AddressMailing.Address1 = addressLine1;

            return this;
        }

        ///GENMHASH:4C1FE94578249288401AEF665B9A6B79:63415628FC3106DEBD2FBF03F6812C22
        public string JobTitle()
        {
            return Inner.JobTitle;
        }

        ///GENMHASH:FBB5E19397E005A263CCB7B92FE16836:1170338745AFF2459B4248550000A443
        public string MiddleName()
        {
            return Inner.NameMiddle;
        }

        ///GENMHASH:FF915D526676F34B9CC7211AFDA78829:FA4C77EBC4E16B02F0C3A4722B561FD6
        public string LastName()
        {
            return Inner.NameLast;
        }

        ///GENMHASH:50591C7F6252A1445FC4B92D0BD8C1DB:0A534888A362870E8BBC5F4473288885
        public string Fax()
        {
            return Inner.Fax;
        }

        ///GENMHASH:6DAC3A6EC77FDDC480D92892F75ED7FF:8BEA331AA61779B67660BFA12D5B156E
        public DomainContactImpl WithLastName(string lastName)
        {
            Inner.NameLast = lastName;

            return this;
        }

        ///GENMHASH:BA08D4ECCA23A1332D830139773A4847:5DE786329D0DC185B623E3756721A7E0
        public string Email()
        {
            return Inner.Email;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:2E510BC4B07F06766285184B2CE52CBD
        public AppServiceDomainImpl Attach()
        {
            return Parent.WithRegistrantContact(Inner);
        }

        ///GENMHASH:9CE8C2CD9B4FF3636CD0315913CD5E9D:6D36ED09C8BB920F037A495457DB8D82
        public DomainContactImpl WithEmail(string email)
        {
            Inner.Email = email;

            return this;
        }

        ///GENMHASH:26A6AFA5B1D9D9F42E7BEACA61D8B1F9:465961ED63835C1034CC59EDAE98F26D
        internal DomainContactImpl(Contact inner, AppServiceDomainImpl parent)
            : base(inner, parent)
        {
            Inner.AddressMailing = new Address();
        }

        ///GENMHASH:2906E727CDB637085F78C05D843A1698:61E41A6FC294B4011521327802E48CFB
        public DomainContactImpl WithJobTitle(string jobTitle)
        {
            Inner.JobTitle = jobTitle;

            return this;
        }

        ///GENMHASH:6DBB14E9DDBDE750FBDE3D15FEE78A8D:FB1A3542F4340E4A9531CA04949358CA
        public Address AddressMailing()
        {
            return Inner.AddressMailing;
        }
    }
}
