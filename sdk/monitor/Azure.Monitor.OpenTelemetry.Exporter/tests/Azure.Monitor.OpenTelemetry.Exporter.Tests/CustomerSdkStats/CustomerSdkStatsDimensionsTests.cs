// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Xunit;
using TelemetryType = Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats.TelemetryType;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CustomerSdkStats;

public class CustomerSdkStatsDimensionsTests
{
    [Fact]
    public void GetBaseTags_IncludesAllRequiredDimensions()
    {
        // Act
        var tags = CustomerSdkStatsDimensions.GetBaseTags(TelemetryType.Dependency);

        // Assert
        Assert.Contains(tags, tag => tag.Key == "language");
        Assert.Contains(tags, tag => tag.Key == "version");
        Assert.Contains(tags, tag => tag.Key == "computeType");
        Assert.Contains(tags, tag => tag.Key == "telemetryType" && tag.Value?.Equals("DEPENDENCY") == true);
    }

    [Theory]
    [InlineData("Request", "200")]
    [InlineData("Dependency", "404")]
    [InlineData("Exception", "500")]
    public void GetDroppedTags_IncludesDropCodeAndReason(string telemetryTypeName, string dropCode)
    {
        // Act
        var telemetryType = (TelemetryType)Enum.Parse(typeof(TelemetryType), telemetryTypeName);
        var tags = CustomerSdkStatsDimensions.GetDroppedTags(telemetryType, dropCode, "Test reason");

        // Assert
        Assert.Contains(tags, tag => tag.Key == "telemetryType");
        Assert.Contains(tags, tag => tag.Key == "dropCode" && tag.Value?.Equals(dropCode) == true);
        Assert.Contains(tags, tag => tag.Key == "dropReason" && tag.Value?.Equals("Test reason") == true);
    }

    [Theory]
    [InlineData("Request", "429")]
    [InlineData("Dependency", "503")]
    public void GetRetryTags_IncludesRetryCodeAndReason(string telemetryTypeName, string retryCode)
    {
        // Act
        var telemetryType = (TelemetryType)Enum.Parse(typeof(TelemetryType), telemetryTypeName);
        var tags = CustomerSdkStatsDimensions.GetRetryTags(telemetryType, retryCode, "Test retry");

        // Assert
        Assert.Contains(tags, tag => tag.Key == "telemetryType");
        Assert.Contains(tags, tag => tag.Key == "retryCode" && tag.Value?.Equals(retryCode) == true);
        Assert.Contains(tags, tag => tag.Key == "retryReason" && tag.Value?.Equals("Test retry") == true);
    }

    [Fact]
    public void GetDroppedTags_WithoutReason_DoesNotIncludeReasonTag()
    {
        // Act
        var tags = CustomerSdkStatsDimensions.GetDroppedTags(TelemetryType.Request, "200");

        // Assert
        Assert.DoesNotContain(tags, tag => tag.Key == "dropReason");
    }

    [Fact]
    public void GetRetryTags_WithoutReason_DoesNotIncludeReasonTag()
    {
        // Act
        var tags = CustomerSdkStatsDimensions.GetRetryTags(TelemetryType.Request, "429");

        // Assert
        Assert.DoesNotContain(tags, tag => tag.Key == "retryReason");
    }
}
