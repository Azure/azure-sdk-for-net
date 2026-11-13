// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AgriculturePlatform.Tests;

public class BasicLiveAgriculturePlatformTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateAgricultureService()
    {
        await using Trycep test = BasicAgriculturePlatformTests.CreateAgricultureServiceTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
