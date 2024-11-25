// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests;

public class PlaywrightServiceTestEnvironment : TestEnvironment
{
    public string Region => GetRecordedVariable("PLAYWRIGHTTESTING_LOCATION");
    public string DashboardEndpoint => GetRecordedVariable("DASHBOARD_ENDPOINT");
};
