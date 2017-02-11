﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Azure.Tests.WebApp
{
    public class DomainsTests
    {
        private static readonly string GroupName = "javacsmrg9b9912262";
        private static readonly string DomainName = "graph-dm7720.com";

        [Fact(Skip = "Test requires javacsmrg9b9912262 RG to be configured manually")]
        public void CanCRUDDomain()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var appServiceManager = TestHelper.CreateAppServiceManager();

                // CREATE
                var domain = appServiceManager.AppServiceDomains.Define(DomainName)
                    .WithExistingResourceGroup(GroupName)
                    .DefineRegistrantContact()
                        .WithFirstName("Jianghao")
                        .WithLastName("Lu")
                        .WithEmail("jianghlu@microsoft.Com")
                        .WithAddressLine1("1 Microsoft Way")
                        .WithCity("Seattle")
                        .WithStateOrProvince("WA")
                        .WithCountry(CountryISOCode.UnitedStates)
                        .WithPostalCode("98101")
                        .WithPhoneCountryCode(CountryPhoneCode.UnitedStates)
                        .WithPhoneNumber("4258828080")
                        .Attach()
                    .WithDomainPrivacyEnabled(true)
                    .WithAutoRenewEnabled(true)
                    .Create();
                //        Domain domain = appServiceManager.Domains().GetByGroup(RG_NAME, DOMAIN_NAME);
                Assert.NotNull(domain);
                domain.Update()
                    .WithAutoRenewEnabled(false)
                    .Apply();
            }
        }
    }
}