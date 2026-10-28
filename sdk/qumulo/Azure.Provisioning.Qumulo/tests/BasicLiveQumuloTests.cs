// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Qumulo.Tests;

public class BasicLiveQumuloTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateFileSystem()
    {
        await using Trycep test = BasicQumuloTests.CreateFileSystemTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
