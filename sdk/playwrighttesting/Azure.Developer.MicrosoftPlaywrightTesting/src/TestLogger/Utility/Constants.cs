// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;

internal static class Constants
{
    /// <summary>
    /// Property Id storing the ExecutionId.
    /// </summary>
    internal const string ExecutionIdPropertyIdentifier = "ExecutionId";

    /// <summary>
    /// Property Id storing the ParentExecutionId.
    /// </summary>
    internal const string ParentExecutionIdPropertyIdentifier = "ParentExecId";

    /// <summary>
    /// Property If storing the TestType.
    /// </summary>
    internal const string TestTypePropertyIdentifier = "TestType";

    internal const string SASUriSeparator = "?";

    internal const string PortalBaseUrl = "https://playwright.microsoft.com/workspaces/";

    internal const string ReportingRoute = "/runs/";

    internal const string ReportingAPIVersion_2024_04_30_preview = "2024-04-30-preview";

    internal const string ReportingAPIVersion_2024_05_20_preview = "2024-05-20-preview";

    internal const string PLAYWRIGHT_SERVICE_REPORTING_URL = "PLAYWRIGHT_SERVICE_REPORTING_URL";

    internal const string PLAYWRIGHT_SERVICE_WORKSPACE_ID = "PLAYWRIGHT_SERVICE_WORKSPACE_ID";

    internal const string PLAYWRIGHT_SERVICE_ACCESS_TOKEN = "PLAYWRIGHT_SERVICE_ACCESS_TOKEN";

    internal const string PLAYWRIGHT_SERVICE_DEBUG = "PLAYWRIGHT_SERVICE_DEBUG";

    internal const string PLAYWRIGHT_SERVICE_RUN_ID = "PLAYWRIGHT_SERVICE_RUN_ID";

    internal const string GITHUB_ACTIONS = "GitHub Actions";
    internal const string AZURE_DEVOPS = "Azure DevOps";
    internal const string DEFAULT = "Default";
}

internal enum TestErrorType
{
    Scalable
}

internal class TestResultError
{
    internal string? Key { get; set; } = string.Empty;
    internal string? Message { get; set; } = string.Empty;
    internal Regex Pattern { get; set; } = new Regex(string.Empty);
    internal TestErrorType Type { get; set; }
}

internal static class TestResultErrorConstants
{
    public static List<TestResultError> ErrorConstants = new()
    {
        new TestResultError
        {
            Key = "Unauthorized_Scalable",
            Message = "The authentication token provided is invalid. Please check the token and try again.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*401 Unauthorized)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "NoPermissionOnWorkspace_Scalable",
            Message = @"You do not have the required permissions to run tests. This could be because:

    a. You do not have the required roles on the workspace. Only Owner and Contributor roles can run tests. Contact the service administrator.
    b. The workspace you are trying to run the tests on is in a different Azure tenant than what you are signed into. Check the tenant id from Azure portal and login using the command 'az login --tenant <TENANT_ID>'.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*403 Forbidden)(?=[\s\S]*CheckAccess API call with non successful response)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "InvalidWorkspace_Scalable",
            Message = "The specified workspace does not exist. Please verify your workspace settings.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*403 Forbidden)(?=.*InvalidAccountOrSubscriptionState)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "AccessKeyBasedAuthNotSupported_Scalable",
            Message = "Authentication through service access token is disabled for this workspace. Please use Entra ID to authenticate.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*403 Forbidden)(?=.*AccessKeyBasedAuthNotSupported)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "ServiceUnavailable_Scalable",
            Message = "The service is currently unavailable. Please check the service status and try again.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*503 Service Unavailable)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "GatewayTimeout_Scalable",
            Message = "The request to the service timed out. Please try again later.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*504 Gateway Timeout)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "QuotaLimitError_Scalable",
            Message = "It is possible that the maximum number of concurrent sessions allowed for your workspace has been exceeded.",
            Pattern = new Regex(@"(Timeout .* exceeded)(?=[\s\S]*ws connecting)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "BrowserConnectionError_Scalable",
            Message = "The service is currently unavailable. Please try again after some time.",
            Pattern = new Regex(@"Target page, context or browser has been closed", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        }
    };
}
