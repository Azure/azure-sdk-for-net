// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Communication.Tests;

public class BasicLiveCommunicationTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateCommunicationServices()
    {
        await using Trycep test = BasicCommunicationTests.CreateCommunicationServicesTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
