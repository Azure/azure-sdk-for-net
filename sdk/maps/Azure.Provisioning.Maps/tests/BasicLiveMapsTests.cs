// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Maps.Tests;

public class BasicLiveMapsTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.maps/2025-10-01-preview/accounts")]
    [LiveOnly]
    public async Task CreateMapsAccount()
    {
        await using Trycep test = BasicMapsTests.CreateMapsAccountTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
