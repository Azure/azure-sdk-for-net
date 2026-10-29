// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.SecretsStoreExtension.Tests;

public class BasicLiveSecretsStoreExtensionTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateSecretSync()
    {
        await using Trycep test = BasicSecretsStoreExtensionTests.CreateSecretSyncTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
