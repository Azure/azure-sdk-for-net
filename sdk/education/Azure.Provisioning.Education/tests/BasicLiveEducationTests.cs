// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Education.Tests;

public class BasicLiveEducationTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateEducationLab()
    {
        await using Trycep test = BasicEducationTests.CreateEducationLabTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
