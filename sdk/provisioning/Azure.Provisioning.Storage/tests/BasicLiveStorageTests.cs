// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Storage.Tests;

public class BasicLiveStorageTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateDefaultStorage()
    {
        await using Trycep test = BasicStorageTests.CreateDefaultStorageTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [LiveOnly]
    public async Task CreateSimpleStorageBlobs()
    {
        await using Trycep test = BasicStorageTests.CreateSimpleStorageBlobsTest();
        await test.SetupLiveCalls(this)
            .Lint(ignore: ["no-unnecessary-dependson"])
            .ValidateAsync();
    }

    [Test]
    [LiveOnly]
    public async Task AddStorageRole()
    {
        await using Trycep test = BasicStorageTests.CreateAddStorageRoleTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [LiveOnly]
    public async Task AddStorageRoleWithExplicitPrincipal()
    {
        await using Trycep test = BasicStorageTests.CreateAddStorageRoleWithExplicitPrincipalTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [LiveOnly]
    public async Task GetEndpoint()
    {
        await using Trycep test = BasicStorageTests.CreateGetEndpointTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [LiveOnly]
    public async Task SimpleConnString()
    {
        await using Trycep test = BasicStorageTests.CreateSimpleConnStringTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-account-create/main.bicep")]
    [LiveOnly]
    public async Task CreateStandardStorageAccount()
    {
        await using Trycep test = BasicStorageTests.CreateStandardStorageAccountTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-blob-container/main.bicep")]
    [LiveOnly]
    public async Task CreateStorageAccountAndContainer()
    {
        await using Trycep test = BasicStorageTests.CreateStorageAccountAndContainerTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-account-service-encryption-create/main.bicep")]
    [LiveOnly]
    public async Task CreateStorageAccountWithServiceEncryption()
    {
        await using Trycep test = BasicStorageTests.CreateStorageAccountWithServiceEncryptionTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-account-create/main.bicep")]
    [LiveOnly]
    public async Task CreateFileShare()
    {
        await using Trycep test = BasicStorageTests.CreateFileShareTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
