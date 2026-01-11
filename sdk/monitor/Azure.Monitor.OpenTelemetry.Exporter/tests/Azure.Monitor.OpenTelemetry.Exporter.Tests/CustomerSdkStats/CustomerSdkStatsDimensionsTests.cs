// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CustomerSdkStats;

public class CustomerSdkStatsDimensionsTests
{
    [Fact]
    public void GetBaseTags_IncludesAllRequiredDimensions()
    {
        // Act
        var tags = CustomerSdkStatsDimensions.GetBaseTags("DEPENDENCY");

        // Assert
        Assert.Contains(tags, tag => tag.Key == "language");
        Assert.Contains(tags, tag => tag.Key == "version");
        Assert.Contains(tags, tag => tag.Key == "computeType");
        Assert.Contains(tags, tag => tag.Key == "telemetry_type" && tag.Value?.Equals("DEPENDENCY") == true);
    }

    [Theory]
    [InlineData("REQUEST", "200")]
    [InlineData("DEPENDENCY", "404")]
    [InlineData("EXCEPTION", "500")]
    public void GetDroppedTags_IncludesDropCodeAndReason(string telemetryType, string dropCode)
    {
        // Act
        var tags = CustomerSdkStatsDimensions.GetDroppedTags(telemetryType, dropCode, "Test reason");

        // Assert
        Assert.Contains(tags, tag => tag.Key == "telemetry_type" && tag.Value?.Equals(telemetryType) == true);
        Assert.Contains(tags, tag => tag.Key == "drop.code" && tag.Value?.Equals(dropCode) == true);
        Assert.Contains(tags, tag => tag.Key == "drop.reason" && tag.Value?.Equals("Test reason") == true);
    }

    [Theory]
    [InlineData("REQUEST", "429")]
    [InlineData("DEPENDENCY", "503")]
    public void GetRetryTags_IncludesRetryCodeAndReason(string telemetryType, string retryCode)
    {
        // Act
        var tags = CustomerSdkStatsDimensions.GetRetryTags(telemetryType, retryCode, "Test retry");

        // Assert
        Assert.Contains(tags, tag => tag.Key == "telemetry_type" && tag.Value?.Equals(telemetryType) == true);
        Assert.Contains(tags, tag => tag.Key == "retry.code" && tag.Value?.Equals(retryCode) == true);
        Assert.Contains(tags, tag => tag.Key == "retry.reason" && tag.Value?.Equals("Test retry") == true);
    }

    [Fact]
    public void GetDroppedTags_WithoutReason_DoesNotIncludeReasonTag()
    {
        // Act
        var tags = CustomerSdkStatsDimensions.GetDroppedTags("REQUEST", "200");

        // Assert
        Assert.DoesNotContain(tags, tag => tag.Key == "drop.reason");
    }

    [Fact]
    public void GetRetryTags_WithoutReason_DoesNotIncludeReasonTag()
    {
        // Act
        var tags = CustomerSdkStatsDimensions.GetRetryTags("REQUEST", "429");

        // Assert
        Assert.DoesNotContain(tags, tag => tag.Key == "retry.reason");
    }
}
