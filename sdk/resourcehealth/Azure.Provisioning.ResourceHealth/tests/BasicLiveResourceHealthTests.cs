// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ResourceHealth.Tests;

public class BasicLiveResourceHealthTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.resourcehealth/2025-05-01/events")]
    [LiveOnly]
    public async Task ReferenceResourceHealthEvent()
    {
        await using Trycep test = BasicResourceHealthTests.CreateResourceHealthEventTest();
        test.SetupLiveCalls(this)
            .Lint();
    }
}
