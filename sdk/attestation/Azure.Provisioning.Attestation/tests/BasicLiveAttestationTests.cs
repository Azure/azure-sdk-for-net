// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Attestation.Tests;

public class BasicLiveAttestationTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description(
        "Azure Quickstart Template: https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.attestation/attestation-provider-create/main.bicep; " +
        "Microsoft Learn quickstart: https://learn.microsoft.com/azure/attestation/quickstart-template")]
    [LiveOnly]
    public async Task CreateAttestationProvider()
    {
        await using Trycep test = BasicAttestationTests.CreateAttestationProviderTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
