// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KeyVault.Tests;

public class BasicLiveKeyVaultTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.keyvault/key-vault-create/main.bicep")]
    [LiveOnly]
    public async Task CreateKeyVaultAndSecret()
    {
        await using Trycep test = BasicKeyVaultTests.CreateKeyVaultAndSecretTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
