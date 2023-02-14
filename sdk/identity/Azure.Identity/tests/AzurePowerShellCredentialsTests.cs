// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzurePowerShellCredentialsTests : CredentialTestBase<AzurePowerShellCredentialOptions>
    {
        private string tokenXML =
            "<Object Type=\"Microsoft.Azure.Commands.Profile.Models.PSAccessToken\"><Property Name=\"Token\" Type=\"System.String\">Kg==</Property><Property Name=\"ExpiresOn\" Type=\"System.DateTimeOffset\">5/11/2021 8:20:03 PM +00:00</Property><Property Name=\"TenantId\" Type=\"System.String\">72f988bf-86f1-41af-91ab-2d7cd011db47</Property><Property Name=\"UserId\" Type=\"System.String\">chriss@microsoft.com</Property><Property Name=\"Type\" Type=\"System.String\">Bearer</Property></Object>";

        public AzurePowerShellCredentialsTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var pwshOptions = new AzurePowerShellCredentialOptions
            {
                Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }
            };
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzurePowerShell(TimeSpan.FromSeconds(30));
            var testProcess = new TestProcess { Output = processOutput };
            return InstrumentClient(
                new AzurePowerShellCredential(pwshOptions, CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true)));
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            var pwshOptions = new AzurePowerShellCredentialOptions
            {
                AdditionallyAllowedTenantsCore = config.AdditionallyAllowedTenants,
                TenantId = config.TenantId,
            };
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzurePowerShell(TimeSpan.FromSeconds(30));
            var testProcess = new TestProcess { Output = processOutput };
            return InstrumentClient(
                new AzurePowerShellCredential(pwshOptions, CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true)));
        }

        [Test]
        public async Task AuthenticateWithAzurePowerShellCredential(
            [Values(null, TenantIdHint)] string tenantId,
            [Values(true)] bool allowMultiTenantAuthentication,
            [Values(null, TenantId)] string explicitTenantId)
        {
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            var options = new AzurePowerShellCredentialOptions { TenantId = explicitTenantId, AdditionallyAllowedTenants = { TenantIdHint } };
            string expectedTenantId = TenantIdResolver.Resolve(explicitTenantId, context, TenantIdResolver.AllTenants);
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzurePowerShell(TimeSpan.FromSeconds(30));

            var testProcess = new TestProcess { Output = processOutput };
            AzurePowerShellCredential credential = InstrumentClient(
                new AzurePowerShellCredential(options, CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true)));
            AccessToken actualToken = await credential.GetTokenAsync(context);

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.AreEqual(expectedExpiresOn, actualToken.ExpiresOn);

            var iStart = testProcess.StartInfo.Arguments.IndexOf("EncodedCommand");
            iStart = testProcess.StartInfo.Arguments.IndexOf('\"', iStart) + 1;
            var iEnd = testProcess.StartInfo.Arguments.IndexOf('\"', iStart);
            var commandString = testProcess.StartInfo.Arguments.Substring(iStart, iEnd - iStart);
            var b = Convert.FromBase64String(commandString);
            commandString = Encoding.Unicode.GetString(b);

            var expectTenantId = expectedTenantId != null;
            if (expectTenantId)
            {
                Assert.That(commandString, Does.Contain($"-TenantId {expectedTenantId}"));
            }
            else
            {
                Assert.That(commandString, Does.Not.Contain("-TenantId"));
            }
        }

        private static IEnumerable<object[]> ErrorScenarios()
        {
            yield return new object[] { "Run Connect-AzAccount to login", AzurePowerShellCredential.AzurePowerShellNotLogInError, typeof(CredentialUnavailableException) };
            yield return new object[] { "NoAzAccountModule", AzurePowerShellCredential.AzurePowerShellModuleNotInstalledError, typeof(CredentialUnavailableException) };
            yield return new object[] { "Get-AzAccessToken: Run Connect-AzAccount to login.", AzurePowerShellCredential.AzurePowerShellNotLogInError, typeof(CredentialUnavailableException) };
            yield return new object[] { "No accounts were found in the cache", AzurePowerShellCredential.AzurePowerShellNotLogInError, typeof(CredentialUnavailableException) };
            yield return new object[] { "cannot retrieve access token", AzurePowerShellCredential.AzurePowerShellNotLogInError, typeof(CredentialUnavailableException) };
            yield return new object[] {
                "AADSTS500011: The resource principal named <RESOURCE> was not found in the tenant named",
                AzurePowerShellCredential.AzurePowerShellFailedError +  " AADSTS500011: The resource principal named <RESOURCE> was not found in the tenant named",
                typeof(AuthenticationFailedException) };
        }

        [Test]
        [TestCaseSource(nameof(ErrorScenarios))]
        public void AuthenticateWithAzurePowerShellCredential_ErrorScenarios(string errorMessage, string expectedError, Type expectedException)
        {
            var testProcess = new TestProcess { Error = errorMessage };
            AzurePowerShellCredential credential = InstrumentClient(
                new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(), CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync(expectedException, async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedError, ex.Message);
        }

        /// <summary>
        /// Requires 2 TestProcess results falling back from pwsh to powershell on Windows
        /// </summary>
        private static IEnumerable<object[]> FallBackErrorScenarios()
        {
            yield return new object[] { "'pwsh' is not recognized", AzurePowerShellCredential.PowerShellNotInstalledError };
            yield return new object[] { "pwsh: command not found", AzurePowerShellCredential.PowerShellNotInstalledError };
            yield return new object[] { "pwsh: not found", AzurePowerShellCredential.PowerShellNotInstalledError };
        }

        [Test]
        [TestCaseSource(nameof(FallBackErrorScenarios))]
        public void AuthenticateWithAzurePowerShellCredential_FallBackErrorScenarios(string errorMessage, string expectedError)
        {
            // This will require two processes on Windows and one on other platforms
            // Purposefully stripping out the second process to ensure any attempt to fallback is caught on non-Windows
            TestProcess[] testProcesses = new TestProcess[] { new TestProcess { Error = errorMessage }, new TestProcess { Error = errorMessage } };
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                testProcesses = new TestProcess[] { testProcesses[0] };

            AzurePowerShellCredential credential = InstrumentClient(
                new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(), CredentialPipeline.GetInstance(null), new TestProcessService(testProcesses)));
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedError, ex.Message);
        }

        [Test]
        public async Task HandlesAlternateDateTimeFormats([Values("en-US", "nl-NL")] string culture)
        {
            CultureInfo curCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            try
            {
                var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzurePowerShell(TimeSpan.FromSeconds(30));
                TestContext.WriteLine(processOutput);
                var testProcess = new TestProcess { Output = processOutput, };
                AzurePowerShellCredential credential = InstrumentClient(
                    new AzurePowerShellCredential(
                        new AzurePowerShellCredentialOptions(),
                        CredentialPipeline.GetInstance(null),
                        new TestProcessService(testProcess, true)));
                await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));
            }
            finally
            {
                CultureInfo.CurrentCulture = new CultureInfo(curCulture.Name);
            }
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true)]
        public async Task FallsBackToLegacyPowershell()
        {
            bool fellBackToPowerShell = false;
            var testProcess = new TestProcess
            {
                Output = "'pwsh' is not recognized as an internal or external command,",
                ExceptionOnStartHandler = (p) =>
                {
                    if (p.StartInfo.Arguments.Contains("pwsh"))
                    {
                        p.Output = tokenXML;
                        fellBackToPowerShell = true;
                    }
                }
            };
            AzurePowerShellCredential credential = InstrumentClient(
                new AzurePowerShellCredential(
                    new AzurePowerShellCredentialOptions(),
                    CredentialPipeline.GetInstance(null),
                    new TestProcessService(testProcess, true)));
            await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));
            Assert.IsTrue(fellBackToPowerShell);
        }

        [Test]
        public void ConfigurePowershellProcessTimeout_ProcessTimeout()
        {
            var testProcess = new TestProcess { Timeout = 10000 };
            AzurePowerShellCredential credential = InstrumentClient(
                new AzurePowerShellCredential(
                    new AzurePowerShellCredentialOptions() { PowerShellProcessTimeout = TimeSpan.Zero },
                    CredentialPipeline.GetInstance(null),
                    new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(AzurePowerShellCredential.AzurePowerShellTimeoutError, ex.Message);
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true)]
        public void AuthenticateWithAzurePowerShellCredential_PowerShellNotInstalled(
            [Values("'powershell' is not recognized", "powershell: command not found", "powershell: not found")]
            string errorMessage)
        {
            var testProcess = new TestProcess { Error = errorMessage };
            AzurePowerShellCredential credential = InstrumentClient(
                new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(), CredentialPipeline.GetInstance(null), new TestProcessService(testProcess))
                {
                    UseLegacyPowerShell = true
                });
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(AzurePowerShellCredential.PowerShellNotInstalledError, ex.Message);
        }

        [Test]
        public void AuthenticateWithAzurePowerShellCredential_AzurePowerShellUnknownError()
        {
            string mockResult = "mock-result";
            var testProcess = new TestProcess { Error = mockResult };
            AzurePowerShellCredential credential = InstrumentClient(
                new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(), CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
        }

        [Test]
        public void AuthenticateWithAzurePowerShellCredential_CanceledByUser()
        {
            var cts = new CancellationTokenSource();
            var testProcess = new TestProcess { Timeout = 10000 };
            testProcess.Started += (o, e) => cts.Cancel();
            AzurePowerShellCredential credential = InstrumentClient(
                new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(), CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            Assert.CatchAsync<OperationCanceledException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), cts.Token));
        }
    }
}
