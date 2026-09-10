// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DomainRegistration.Tests;

public class BasicDomainRegistrationTests
{
    internal static Trycep CreateAppServiceDomainTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:DomainRegistrationBasic
                Infrastructure infra = new();

                RegistrationContactInfo CreateContact() =>
                  new()
                  {
                      AddressMailing = new RegistrationAddressInfo
                      {
                          Address1 = "1 Microsoft Way",
                          City = "Redmond",
                          Country = "US",
                          PostalCode = "98052",
                          State = "WA",
                      },
                      Email = "admin@example.com",
                      NameFirst = "Azure",
                      NameLast = "SDK",
                      Phone = "+1.4255550100",
                  };

                AppServiceDomain domain =
                    new(nameof(domain), AppServiceDomain.ResourceVersions.V2024_11_01)
                    {
                        Name = "example.com",
                        ContactAdmin = CreateContact(),
                        ContactBilling = CreateContact(),
                        ContactRegistrant = CreateContact(),
                        ContactTech = CreateContact(),
                        Consent = new DomainPurchaseConsent
                        {
                            AgreementKeys = { "agreement-key" },
                            AgreedBy = "192.0.2.1",
                            AgreedOn = DateTimeOffset.Parse("2026-01-01T00:00:00Z"),
                        },
                        IsAutoRenew = true,
                        IsDomainPrivacyEnabled = true,
                    };
                infra.Add(domain);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateAppServiceDomain()
    {
        await using Trycep test = CreateAppServiceDomainTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource domain 'Microsoft.DomainRegistration/domains@2024-11-01' = {
              name: 'example.com'
              location: location
              properties: {
                autoRenew: true
                consent: {
                  agreedAt: '2026-01-01T00:00:00.0000000Z'
                  agreedBy: '192.0.2.1'
                  agreementKeys: [
                    'agreement-key'
                  ]
                }
                contactAdmin: {
                  addressMailing: {
                    address1: '1 Microsoft Way'
                    city: 'Redmond'
                    country: 'US'
                    postalCode: '98052'
                    state: 'WA'
                  }
                  email: 'admin@example.com'
                  nameFirst: 'Azure'
                  nameLast: 'SDK'
                  phone: '+1.4255550100'
                }
                contactBilling: {
                  addressMailing: {
                    address1: '1 Microsoft Way'
                    city: 'Redmond'
                    country: 'US'
                    postalCode: '98052'
                    state: 'WA'
                  }
                  email: 'admin@example.com'
                  nameFirst: 'Azure'
                  nameLast: 'SDK'
                  phone: '+1.4255550100'
                }
                contactRegistrant: {
                  addressMailing: {
                    address1: '1 Microsoft Way'
                    city: 'Redmond'
                    country: 'US'
                    postalCode: '98052'
                    state: 'WA'
                  }
                  email: 'admin@example.com'
                  nameFirst: 'Azure'
                  nameLast: 'SDK'
                  phone: '+1.4255550100'
                }
                contactTech: {
                  addressMailing: {
                    address1: '1 Microsoft Way'
                    city: 'Redmond'
                    country: 'US'
                    postalCode: '98052'
                    state: 'WA'
                  }
                  email: 'admin@example.com'
                  nameFirst: 'Azure'
                  nameLast: 'SDK'
                  phone: '+1.4255550100'
                }
                privacy: true
              }
            }
            """);
    }
}
