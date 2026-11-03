// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DataBox.Tests;

public class BasicLiveDataBoxTests(bool async)
    : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateDataBoxJob()
    {
        await using Trycep test = BasicDataBoxTests.CreateDataBoxJobTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
