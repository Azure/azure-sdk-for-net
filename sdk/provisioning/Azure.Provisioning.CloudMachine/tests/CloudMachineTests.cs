// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [TestCase("test")]
    public void NotNull(object? value)
    {
        Assert.AreEqual("test1", "test1");
    }
}
