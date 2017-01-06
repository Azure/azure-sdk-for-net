// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Azure.Tests.WebApp
{
    public class CertificateOrdersTests
    {
        private static string RG_NAME = "javacsmrg9b9912262";
        private static string CERTIFICATE_NAME = "graphdmcert7720";

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCRUDCertificateOrder()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var appServiceManager = TestHelper.CreateAppServiceManager();

                // CREATE
                var certificateOrder = appServiceManager.AppServiceCertificateOrders
                    .Define(CERTIFICATE_NAME)
                    .WithExistingResourceGroup(RG_NAME)
                    .WithHostName("graph-dm7720.com")
                    .WithStandardSku()
                    .WithDomainVerification(appServiceManager.AppServiceDomains.GetByGroup("javacsmrg9b9912262", "graph-dm7720.com"))
                    .WithNewKeyVault("graphvault", Region.US_WEST)
                    .WithValidYears(1)
                    .Create();
                Assert.NotNull(certificateOrder);
                // GET
                Assert.NotNull(appServiceManager.AppServiceCertificateOrders.GetByGroup(RG_NAME, CERTIFICATE_NAME));
                // LIST
                var certificateOrders = appServiceManager.AppServiceCertificateOrders.ListByGroup(RG_NAME);
                var found = false;
                foreach (var co in certificateOrders)
                {
                    if (CERTIFICATE_NAME.Equals(co.Name))
                    {
                        found = true;
                        break;
                    }
                }
                Assert.True(found);
                // UPDATE
            }
        }
    }
}