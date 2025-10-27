// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Dns;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Dns.Tests;

public class BasicTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    public void GetStarted()
    {
        Assert.Inconclusive("Implement me!");
    }
}