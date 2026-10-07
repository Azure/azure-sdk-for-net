// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.MachineLearning.Tests;

public class BasicLiveMachineLearningTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateWorkspace()
    {
        await using Trycep test = BasicMachineLearningTests.CreateWorkspaceTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
