// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Storage.Tests;

public class BasicLiveStorageTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    public async Task CreateDefaultStorage()
    {
        await using Trycep test = BasicStorageTests.CreateDefaultStorageTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }

    [Test]
    public async Task CreateSimpleStorageBlobs()
    {
        await using Trycep test = BasicStorageTests.CreateSimpleStorageBlobsTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }

    [Test]
    public async Task AddStorageRole()
    {
        await using Trycep test = BasicStorageTests.CreateAddStorageRoleTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }

    [Test]
    public async Task AddStorageRoleWithExplicitPrincipal()
    {
        await using Trycep test = BasicStorageTests.CreateAddStorageRoleWithExplicitPrincipalTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }

    [Test]
    public async Task GetEndpoint()
    {
        await using Trycep test = BasicStorageTests.CreateGetEndpointTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }

    [Test]
    public async Task SimpleConnString()
    {
        await using Trycep test = BasicStorageTests.CreateSimpleConnStringTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-account-create/main.bicep")]
    public async Task CreateStandardStorageAccount()
    {
        await using Trycep test = BasicStorageTests.CreateStandardStorageAccountTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-blob-container/main.bicep")]
    public async Task CreateStorageAccountAndContainer()
    {
        await using Trycep test = BasicStorageTests.CreateStorageAccountAndContainerTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-account-service-encryption-create/main.bicep")]
    public async Task CreateStorageAccountWithServiceEncryption()
    {
        await using Trycep test = BasicStorageTests.CreateStorageAccountWithServiceEncryptionTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-account-create/main.bicep")]
    public async Task CreateFileShare()
    {
        await using Trycep test = BasicStorageTests.CreateFileShareTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }
}
