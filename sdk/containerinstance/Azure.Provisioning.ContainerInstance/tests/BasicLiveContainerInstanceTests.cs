// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ContainerInstance.Tests;

public class BasicLiveContainerInstanceTests : ProvisioningTestBase
{
    public BasicLiveContainerInstanceTests(bool async)
        : base(async) { }

    [Test]
    [LiveOnly]
    public async Task CreateLinuxContainerGroup()
    {
        await using Trycep test = BasicContainerInstanceTests.CreateLinuxContainerGroupTest();
        await test.SetupLiveCalls(this).Lint().ValidateAsync();
    }
}
