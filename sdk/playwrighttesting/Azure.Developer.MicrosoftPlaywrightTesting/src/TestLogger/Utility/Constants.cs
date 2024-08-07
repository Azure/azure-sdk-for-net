// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
