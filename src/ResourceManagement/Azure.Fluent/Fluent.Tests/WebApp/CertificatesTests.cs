// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using Xunit;

namespace Azure.Tests.WebApp
{
    public class CertificatesTests
    {
        private static readonly string RG_NAME = "javacsmrg319";
        private static readonly string CERTIFICATE_NAME = "javagoodcert319";

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCRDCertificate()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var keyVaultManager = TestHelper.CreateKeyVaultManager();
                var appServiceManager = TestHelper.CreateAppServiceManager();

                var vault = keyVaultManager.Vaults.GetByGroup(RG_NAME, "bananagraphwebapp319com");
                var certificate = appServiceManager.AppServiceCertificates.Define("bananacert")
                    .WithRegion(Region.US_WEST)
                    .WithExistingResourceGroup(RG_NAME)
                    .WithExistingCertificateOrder(appServiceManager.AppServiceCertificateOrders.GetByGroup(RG_NAME, "graphwebapp319"))
                    .Create();
                Assert.NotNull(certificate);

                // CREATE
                certificate = appServiceManager.AppServiceCertificates.Define(CERTIFICATE_NAME)
                    .WithRegion(Region.US_EAST)
                    .WithExistingResourceGroup(RG_NAME)
                    .WithPfxFile("/Users/jianghlu/Documents/code/certs/myserver.Pfx")
                    .WithPfxPassword("StrongPass!123")
                    .Create();
                Assert.NotNull(certificate);
            }
        }
    }
}