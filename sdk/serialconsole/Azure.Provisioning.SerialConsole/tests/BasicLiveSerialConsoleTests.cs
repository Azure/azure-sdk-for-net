// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.SerialConsole.Tests;

public class BasicLiveSerialConsoleTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateSerialPort()
    {
        await using Trycep test = BasicSerialConsoleTests.CreateSerialPortTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
