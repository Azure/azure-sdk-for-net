// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.SelfHelp.Tests;

public class BasicLiveSelfHelpTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateDiagnostic()
    {
        await using Trycep test = BasicSelfHelpTests.CreateDiagnosticTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
