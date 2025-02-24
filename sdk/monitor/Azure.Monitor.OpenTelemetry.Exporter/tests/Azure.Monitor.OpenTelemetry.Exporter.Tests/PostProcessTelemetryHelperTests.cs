// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Moq;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests;

public class PostProcessTelemetryHelperTests
{
    [Fact]
    public void InvokePostProcess()
    {
        var longKey = new string('k', SchemaConstants.KVP_MaxKeyLength + 1);
        var longValue = new string('v', SchemaConstants.KVP_MaxValueLength + 1);

        var tags = new Dictionary<string, string>();
        var item = new Mock<ITelemetryItem>();
        item.Setup(i => i.Tags).Returns(tags);
        PostProcessTelemetryHelper.InvokePostProcess(item.Object,
            i =>
            {
                i.Tags.Add("key", "value");
                i.Tags.Add(longKey, "value");
                i.Tags.Add("key2", longValue);
                i.Tags.Add($"{longKey}2", longValue);
            });
        Assert.Single(tags);
        Assert.Contains(tags, kvp => kvp is { Key: "key", Value: "value" });
    }

    [Fact]
    public void InvokePostProcessNull()
    {
        var item = new Mock<ITelemetryItem>();
        PostProcessTelemetryHelper.InvokePostProcess(item.Object, null);
    }

    [Fact]
    public void InvokePostProcessException()
    {
        var item = new Mock<ITelemetryItem>();
        PostProcessTelemetryHelper.InvokePostProcess(item.Object,
            i => throw new System.Exception());
    }
}
