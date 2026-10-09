// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.CertificateRegistration.Tests;

public class BasicCertificateRegistrationTests
{
    internal static Trycep CreateAppServiceCertificateOrderTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:CertificateRegistrationBasic
                Infrastructure infra = new();

                AppServiceCertificateOrder order =
                    new(nameof(order), AppServiceCertificateOrder.ResourceVersions.V2024_11_01)
                    {
                        Location = new AzureLocation("global"),
                        DistinguishedName = "CN=example.com",
                        ValidityInYears = 1,
                        KeySize = 2048,
                        CertificateProductType = CertificateProductType.StandardDomainValidatedSsl,
                        IsAutoRenew = true,
                    };
                infra.Add(order);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/tree/master/quickstarts/microsoft.web/app-service-certificate-standard")]
    public async Task CreateAppServiceCertificateOrder()
    {
        await using Trycep test = CreateAppServiceCertificateOrderTest();
        test.Compare(
            """
            resource order 'Microsoft.CertificateRegistration/certificateOrders@2024-11-01' = {
              name: take('order${uniqueString(resourceGroup().id)}', 24)
              location: 'global'
              properties: {
                autoRenew: true
                distinguishedName: 'CN=example.com'
                keySize: 2048
                productType: 'StandardDomainValidatedSsl'
                validityInYears: 1
              }
            }
            """);
    }
}
