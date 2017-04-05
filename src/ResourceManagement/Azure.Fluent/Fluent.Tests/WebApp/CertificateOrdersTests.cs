// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Azure.Tests.WebApp
{
    public class CertificateOrdersTests
    {
        private static string GroupName = "javacsmrg9b9912262";
        private static string CertificateName = "graphdmcert7720";

        [Fact(Skip = "Test requires javacsmrg9b9912262 RG to be configured manually")]
        public void CanCRUDCertificateOrder()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var appServiceManager = TestHelper.CreateAppServiceManager();

                // CREATE
                var certificateOrder = appServiceManager.AppServiceCertificateOrders
                    .Define(CertificateName)
                    .WithExistingResourceGroup(GroupName)
                    .WithHostName("graph-dm7720.com")
                    .WithStandardSku()
                    .WithDomainVerification(appServiceManager.AppServiceDomains.GetByResourceGroup("javacsmrg9b9912262", "graph-dm7720.com"))
                    .WithNewKeyVault("graphvault", Region.USWest)
                    .WithValidYears(1)
                    .Create();
                Assert.NotNull(certificateOrder);
                // GET
                Assert.NotNull(appServiceManager.AppServiceCertificateOrders.GetByResourceGroup(GroupName, CertificateName));
                // LIST
                var certificateOrders = appServiceManager.AppServiceCertificateOrders.ListByResourceGroup(GroupName);
                var found = false;
                foreach (var co in certificateOrders)
                {
                    if (CertificateName.Equals(co.Name))
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