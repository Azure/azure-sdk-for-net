// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger;
using Microsoft.Extensions.Logging;

namespace Azure.Developer.MicrosoftPlaywrightTesting.NUnit;

/// <summary>
/// NUnit setup fixture to initialize Playwright Service.
/// </summary>
[SetUpFixture]
public class PlaywrightServiceNUnit : PlaywrightService
{
    private static NUnitLogger nunitLogger { get; } = new();
    private static readonly string? s_useCloudHostedBrowsers = TestContext.Parameters.Get(RunSettingKey.UseCloudHostedBrowsers.ToString());
    private static readonly string? s_serviceAuthType = TestContext.Parameters.Get(RunSettingKey.ServiceAuthType.ToString());
    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceNUnit"/> class.
    /// </summary>
    /// <param name="credential">The azure token credential to use for authentication.</param>
    public PlaywrightServiceNUnit(TokenCredential? credential = null)
        : base(credential, options)
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="PlaywrightServiceOptions"/> based on the runsettings file.
    /// </summary>
    public static PlaywrightServiceOptions options { get; } = new()
    {
        OS = GetOsPlatform(TestContext.Parameters.Get(RunSettingKey.OS.ToString())),
        RunId = TestContext.Parameters.Get(RunSettingKey.RunId.ToString()),
        ExposeNetwork = TestContext.Parameters.Get(RunSettingKey.ExposeNetwork.ToString()),
        ServiceAuth = string.IsNullOrEmpty(s_serviceAuthType) ? ServiceAuthType.EntraId : new ServiceAuthType(s_serviceAuthType!),
        UseCloudHostedBrowsers = !string.IsNullOrEmpty(s_useCloudHostedBrowsers) && bool.Parse(s_useCloudHostedBrowsers),
        TokenCredentialType = TestContext.Parameters.Get(RunSettingKey.AzureTokenCredentialType.ToString()),
        ManagedIdentityClientId = TestContext.Parameters.Get(RunSettingKey.ManagedIdentityClientId.ToString()),
        Logger = nunitLogger
    };

    /// <summary>
    /// Setup the resources utilized by Playwright service.
    /// </summary>
    /// <returns></returns>
    [OneTimeSetUp]
    public async Task SetupAsync()
    {
        if (!UseCloudHostedBrowsers)
            return;
        nunitLogger.LogInformation("\nRunning tests using Microsoft Playwright Testing service.\n");

        await InitializeAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Tear down resources utilized by Playwright service.
    /// </summary>
    [OneTimeTearDown]
    public void Teardown()
    {
        Cleanup();
    }

    private static OSPlatform? GetOsPlatform(string? os)
    {
        if (string.IsNullOrEmpty(os))
        {
            return null;
        }
        else if (os!.Equals("Windows", StringComparison.OrdinalIgnoreCase))
        {
            return OSPlatform.Windows;
        }
        else if (os.Equals("Linux", StringComparison.OrdinalIgnoreCase))
        {
            return OSPlatform.Linux;
        }
        return null;
    }
}
