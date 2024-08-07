// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.Developer.MicrosoftPlaywrightTesting;

namespace Azure.Developer.MicrosoftPlaywrightTesting.NUnit;

/// <summary>
/// NUnit setup fixture to initialize Playwright Service.
/// </summary>
[SetUpFixture]
public class PlaywrightServiceNUnit : PlaywrightService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceNUnit"/> class.
    /// </summary>
    /// <param name="tokenCredential">The azure token credential to use for authentication.</param>
    public PlaywrightServiceNUnit(TokenCredential? tokenCredential = null)
        : base(playwrightServiceSettings, tokenCredential: tokenCredential)
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="PlaywrightServiceSettings"/> based on the runsettings file.
    /// </summary>
    public static PlaywrightServiceSettings playwrightServiceSettings = new(
        os: TestContext.Parameters.Get(RunSettingKey.OS),
        runId: TestContext.Parameters.Get(RunSettingKey.RUN_ID),
        exposeNetwork: TestContext.Parameters.Get(RunSettingKey.EXPOSE_NETWORK),
        defaultAuth: TestContext.Parameters.Get(RunSettingKey.DEFAULT_AUTH),
        useCloudHostedBrowsers: TestContext.Parameters.Get(RunSettingKey.USE_CLOUD_HOSTED_BROWSERS),
        azureTokenCredentialType: TestContext.Parameters.Get(RunSettingKey.AZURE_TOKEN_CREDENTIAL_TYPE),
        managedIdentityClientId: TestContext.Parameters.Get(RunSettingKey.MANAGED_IDENTITY_CLIENT_ID)
    );

    /// <summary>
    /// Setup the resources utilized by Playwright service.
    /// </summary>
    /// <returns></returns>
    [OneTimeSetUp]
    public async Task SetupAsync()
    {
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
}
