// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

/// <summary>
/// Process-wide test-host settings applied before any fixture creates an
/// ASP.NET Core builder.
/// </summary>
[SetUpFixture]
public sealed class TestAssemblySetup
{
    private const string ReloadConfigEnvironmentVariable = "DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE";
    private string? _previousReloadConfigValue;

    [OneTimeSetUp]
    public void DisableConfigurationFileWatchers()
    {
        _previousReloadConfigValue = Environment.GetEnvironmentVariable(ReloadConfigEnvironmentVariable);
        Environment.SetEnvironmentVariable(ReloadConfigEnvironmentVariable, "false");
    }

    [OneTimeTearDown]
    public void RestoreConfigurationFileWatchers()
    {
        Environment.SetEnvironmentVariable(ReloadConfigEnvironmentVariable, _previousReloadConfigValue);
    }
}
