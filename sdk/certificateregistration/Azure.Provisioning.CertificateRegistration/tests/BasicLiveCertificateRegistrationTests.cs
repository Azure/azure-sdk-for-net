// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.CertificateRegistration.Tests;

public class BasicLiveCertificateRegistrationTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/tree/master/quickstarts/microsoft.web/app-service-certificate-standard")]
    [LiveOnly]
    public async Task CreateAppServiceCertificateOrder()
    {
        await using Trycep test = BasicCertificateRegistrationTests.CreateAppServiceCertificateOrderTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
