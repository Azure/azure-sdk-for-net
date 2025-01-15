// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Moq;
namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests.Utility;

[TestFixture]
public class ReporterUtilsTests
{
    private static string GetToken(Dictionary<string, object> claims, DateTime? expires = null)
    {
        var tokenHandler = new JsonWebTokenHandler();
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Claims = claims,
            Expires = expires ?? DateTime.UtcNow.AddMinutes(10),
        });
        return token!;
    }

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

    [Test]
    public void ParseWorkspaceIdFromAccessToken_CustomToken_ReturnsTokenDetails()
    {
        var reporterUtils = new ReporterUtils();
        var accessToken = GetToken(new Dictionary<string, object>
        {
            { "aid", "custom_aid" },
            { "oid", "custom_oid" },
            { "id", "custom_id" },
            { "name", "custom_username" },
        });

        TokenDetails result = reporterUtils.ParseWorkspaceIdFromAccessToken(null, accessToken);

        Assert.AreEqual("custom_aid", result.aid);
        Assert.AreEqual("custom_oid", result.oid);
        Assert.AreEqual("custom_id", result.id);
        Assert.AreEqual("custom_username", result.userName);
    }

    [Test]
    public void ParseWorkspaceIdFromAccessToken_EntraToken_ReturnsTokenDetails()
    {
        var reporterUtils = new ReporterUtils();
        var jsonWebTokenHandler = new JsonWebTokenHandler();
        var accessToken = GetToken(new Dictionary<string, object>
        {
            { "oid", "entra_oid" },
            { "name", "entra_username" },
        });

        TokenDetails result = reporterUtils.ParseWorkspaceIdFromAccessToken(jsonWebTokenHandler, accessToken);

        Assert.AreEqual("entra_oid", result.oid);
        Assert.AreEqual(string.Empty, result.id);
        Assert.AreEqual("entra_username", result.userName);
    }

    [Test]
    public void ParseWorkspaceIdFromAccessToken_NullToken_ThrowsArgumentNullException()
    {
        var reporterUtils = new ReporterUtils();
        var jsonWebTokenHandler = new JsonWebTokenHandler();
        string? accessToken = null;

        Assert.Throws<ArgumentNullException>(() => reporterUtils.ParseWorkspaceIdFromAccessToken(jsonWebTokenHandler, accessToken));
    }

    [Test]
    public void ParseWorkspaceIdFromAccessToken_EmptyToken_ThrowsArgumentNullException()
    {
        var reporterUtils = new ReporterUtils();
        var jsonWebTokenHandler = new JsonWebTokenHandler();
        string accessToken = string.Empty;

        Assert.Throws<ArgumentNullException>(() => reporterUtils.ParseWorkspaceIdFromAccessToken(jsonWebTokenHandler, accessToken));
    }
    [Test]
    public void GetRunId_DefaultProvider_ReturnsNewGuid()
    {
        var cIInfo = new CIInfo { Provider = CIConstants.s_dEFAULT };
        var result = ReporterUtils.GetRunId(cIInfo);
        Assert.IsNotNull(result);
        Assert.IsTrue(Guid.TryParse(result, out _));
    }

    [Test]
    public void GetRunId_NonDefaultProvider_ReturnsSha1Hash()
    {
        var cIInfo = new CIInfo { Provider = "NonDefaultProvider", Repo = "Repo", RunId = "RunId", RunAttempt = 1 };
        var expectedRunIdBeforeHash = $"{cIInfo.Provider}-{cIInfo.Repo}-{cIInfo.RunId}-{cIInfo.RunAttempt}";
        var result = ReporterUtils.GetRunId(cIInfo);
        Assert.IsNotNull(result);
        Assert.AreEqual(40, result.Length);
        Assert.AreEqual(ReporterUtils.CalculateSha1Hash(expectedRunIdBeforeHash), result);
    }

    [Test]
    public void GetRunName_GitHubActionsPullRequest_ReturnsExpectedValue()
    {
        var ciInfo = new CIInfo { Provider = CIConstants.s_gITHUB_ACTIONS };
        Environment.SetEnvironmentVariable("GITHUB_EVENT_NAME", "pull_request");
        Environment.SetEnvironmentVariable("GITHUB_REF_NAME", "543/refs/merge");
        Environment.SetEnvironmentVariable("GITHUB_REPOSITORY", "owner/repo");

        var result = ReporterUtils.GetRunName(ciInfo);

        var expected = "PR# 543 on Repo: owner/repo (owner/repo/pull/543)";
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void TruncateData_ValueExceedsMaxLength_ReturnsTruncatedString()
    {
        string value = "This is a very long string that exceeds the maximum length.";
        int maxLength = 20;

        var result = ReporterUtils.TruncateData(value, maxLength);

        Assert.AreEqual("This is a very long ", result);
    }

    [Test]
    public void TruncateData_ValueWithinMaxLength_ReturnsOriginalString()
    {
        string value = "Short string";
        int maxLength = 20;

        var result = ReporterUtils.TruncateData(value, maxLength);

        Assert.AreEqual(value, result);
    }
}
