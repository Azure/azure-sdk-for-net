// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DurableTask.Tests;

public class BasicLiveDurableTaskTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateDurableTaskScheduler()
    {
        await using Trycep test = BasicDurableTaskTests.CreateDurableTaskSchedulerTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
