// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;

namespace Azure.Developer.MicrosoftPlaywrightTesting.NUnit;

/// <summary>
/// NUnit setup fixture to initialize Playwright Service.
/// </summary>
[SetUpFixture]
public class PlaywrightServiceNUnit : PlaywrightService
{
    private static NUnitFrameworkLogger nunitFrameworkLogger { get; } = new();
    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceNUnit"/> class.
    /// </summary>
    /// <param name="credential">The azure token credential to use for authentication.</param>
    public PlaywrightServiceNUnit(TokenCredential? credential = null)
        : base(playwrightServiceOptions, credential: credential, frameworkLogger: nunitFrameworkLogger)
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="PlaywrightServiceOptions"/> based on the runsettings file.
    /// </summary>
    public static PlaywrightServiceOptions playwrightServiceOptions { get; } = new(
        os: GetOsPlatform(TestContext.Parameters.Get(RunSettingKey.Os)),
        runId: TestContext.Parameters.Get(RunSettingKey.RunId),
        exposeNetwork: TestContext.Parameters.Get(RunSettingKey.ExposeNetwork),
        serviceAuth: TestContext.Parameters.Get(RunSettingKey.ServiceAuthType),
        useCloudHostedBrowsers: TestContext.Parameters.Get(RunSettingKey.UseCloudHostedBrowsers),
        azureTokenCredentialType: TestContext.Parameters.Get(RunSettingKey.AzureTokenCredentialType),
        managedIdentityClientId: TestContext.Parameters.Get(RunSettingKey.ManagedIdentityClientId)
    );

    /// <summary>
    /// Setup the resources utilized by Playwright service.
    /// </summary>
    /// <returns></returns>
    [OneTimeSetUp]
    public async Task SetupAsync()
    {
        if (!UseCloudHostedBrowsers)
            return;
        nunitFrameworkLogger.Info("\nRunning tests using Microsoft Playwright Testing service.\n");

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
