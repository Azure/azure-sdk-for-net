// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests;

public class TestUtils
{
    public static string GetPlaywrightServiceAPIEndpoint(string workspaceId, string region)
    {
        return $"https://{region}.api.playwright.microsoft.com/accounts/{workspaceId}/browsers";
    }

    public static string GetWorkspaceIdFromDashboardEndpoint(string dashboardEndpoint)
    {
        var parts = dashboardEndpoint.Split('/');
        return parts.Last();
    }
}
