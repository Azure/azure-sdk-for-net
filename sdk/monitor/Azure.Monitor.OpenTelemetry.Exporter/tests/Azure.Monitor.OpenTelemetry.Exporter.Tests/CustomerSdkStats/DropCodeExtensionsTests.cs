// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CustomerSdkStats;

public class DropCodeExtensionsTests
{
    [Theory]
    [InlineData((int)DropCode.ClientException, "CLIENT_EXCEPTION")]
    [InlineData((int)DropCode.ClientReadonly, "CLIENT_READONLY")]
    [InlineData((int)DropCode.ClientPersistenceIssue, "CLIENT_PERSISTENCE_CAPACITY")]
    [InlineData((int)DropCode.ClientStorageDisabled, "CLIENT_STORAGE_DISABLED")]
    [InlineData((int)DropCode.BackOffEnabled, "CLIENT_EXCEPTION")]
    public void ToDimensionString_ReturnsSpecCompliantValue(int dropCode, string expected)
    {
        Assert.Equal(expected, ((DropCode)dropCode).ToDimensionString());
    }
}
