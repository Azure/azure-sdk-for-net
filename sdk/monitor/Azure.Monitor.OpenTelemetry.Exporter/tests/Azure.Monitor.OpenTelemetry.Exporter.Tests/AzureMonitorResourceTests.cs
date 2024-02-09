// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Resources;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests;

public class AzureMonitorResourceTests
{
    [Fact]
    public void CopyUserDefinedAttributes()
    {
        var resource = ResourceBuilder.CreateDefault()
            .AddAttributes(
                new[]
                {
                    new KeyValuePair<string, object>(
                        "key1",
                        "value1"),
                    new KeyValuePair<string, object>(
                        "key2",
                        "value2"),
                })
            .AddService("my-service").Build();

        var properties = new Dictionary<string, string>();

        var azureMonitorResource = resource.CreateAzureMonitorResource()!;
        azureMonitorResource.CopyUserDefinedAttributes(properties);

        Assert.Equal(
            "my-service",
            properties["service.name"]);

        Assert.Equal(
            "value1",
            properties["key1"]);

        Assert.Equal(
            "value2",
            properties["key2"]);
    }

    [Fact]
    public void CopyUserDefinedAttributesWithDuplicateKeysExceedingMaxLengthSkipped()
    {
        const string longKey =
            "key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1key1";

        var resource = ResourceBuilder.CreateDefault()
            .AddAttributes(
                new[]
                {
                    new KeyValuePair<string, object>(
                        longKey,
                        "value1"),
                    new KeyValuePair<string, object>(
                        "key2",
                        "value2")
                })
            .AddService("my-service").Build();

        var properties = new Dictionary<string, string>();

        var azureMonitorResource = resource.CreateAzureMonitorResource()!;
        azureMonitorResource.CopyUserDefinedAttributes(properties);

        Assert.False(properties.ContainsKey(longKey));

        Assert.Equal(
            "my-service",
            properties["service.name"]);

        Assert.Equal(
            "value2",
            properties["key2"]);
    }

    [Fact]
    public void CopyToUserDefinedAttributesWithDuplicateKeysFirstOneWins()
    {
        var resource = ResourceBuilder.CreateDefault()
            .AddAttributes(
                new[]
                {
                    new KeyValuePair<string, object>(
                        "key1",
                        "value1"),
                    new KeyValuePair<string, object>(
                        "key1",
                        "value2"),
                    new KeyValuePair<string, object>(
                        "key2",
                        "value3"),
                })
            .AddService("my-service").Build();

        var properties = new Dictionary<string, string>();

        var azureMonitorResource = resource.CreateAzureMonitorResource()!;
        azureMonitorResource.CopyUserDefinedAttributes(properties);

        Assert.Equal(
            "my-service",
            properties["service.name"]);

        Assert.Equal(
            "value1",
            properties["key1"]);

        Assert.Equal(
            "value3",
            properties["key2"]);
    }
}
