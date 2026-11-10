// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.StorageActions.Tests;

public class BasicLiveStorageActionsTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateStorageTask()
    {
        await using Trycep test = BasicStorageActionsTests.CreateStorageTaskTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
