// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;
namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ReporterUtilsTests
{
    [Test]
    public void IsTimeGreaterThanCurrentPlus10Minutes_ValidFutureSasUri_ReturnsTrue()
    {
        var reporterUtils = new ReporterUtils();
        string sasUri = "https://example.com/sas?se=" + DateTime.UtcNow.AddMinutes(15).ToString("o"); // 15 minutes in the future
        bool result = reporterUtils.IsTimeGreaterThanCurrentPlus10Minutes(sasUri);
        Assert.IsTrue(result);
    }

    [Test]
    public void IsTimeGreaterThanCurrentPlus10Minutes_ExpiredSasUri_ReturnsFalse()
    {
        var reporterUtils = new ReporterUtils();
        string sasUri = "https://example.com/sas?se=" + DateTime.UtcNow.AddMinutes(-5).ToString("o"); // 5 minutes in the past
        bool result = reporterUtils.IsTimeGreaterThanCurrentPlus10Minutes(sasUri);
        Assert.IsFalse(result);
    }

    [Test]
    public void IsTimeGreaterThanCurrentPlus10Minutes_InvalidSasUri_ReturnsFalse()
    {
        var reporterUtils = new ReporterUtils();
        string sasUri = "not_a_valid_sas_uri"; // Invalid SAS URI
        bool result = reporterUtils.IsTimeGreaterThanCurrentPlus10Minutes(sasUri);
        Assert.IsFalse(result);
    }
}
