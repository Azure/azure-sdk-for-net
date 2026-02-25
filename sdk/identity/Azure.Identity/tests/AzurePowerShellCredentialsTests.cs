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
    internal class AzurePowerShellCredentialsTests : CredentialTestBase<AzurePowerShellCredentialOptions>
    {
        private string tokenXML =
            @"<Object Type=""System.Management.Automation.PSCustomObject""><Property Name=""Token"" Type=""System.String"">Kg==</Property><Property Name=""ExpiresOn"" Type=""System.Int64"">1692035272</Property></Object>";

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
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                TenantId = config.TenantId,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
                AuthorityHost = config.AuthorityHost,
            };
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzurePowerShell(TimeSpan.FromSeconds(30));
            var testProcess = new TestProcess { Output = processOutput };
            return InstrumentClient(
                new AzurePowerShellCredential(pwshOptions, CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true)));
        }

        #region Virtual Factory Methods
        protected virtual TokenCredential CreateCredential(IProcessService processService, string tenantId = null, bool addTenantIdHint = false)
        {
            var options = new AzurePowerShellCredentialOptions { TenantId = tenantId };
            if (addTenantIdHint)
            {
                options.AdditionallyAllowedTenants.Add(TenantIdHint);
            }
            return InstrumentClient(new AzurePowerShellCredential(options, CredentialPipeline.GetInstance(null), processService));
        }

        protected virtual TokenCredential CreateCredentialWithTimeout(IProcessService processService, TimeSpan timeout, bool isChained = false)
        {
            var options = new AzurePowerShellCredentialOptions { ProcessTimeout = timeout, IsChainedCredential = isChained };
            return InstrumentClient(new AzurePowerShellCredential(options, CredentialPipeline.GetInstance(null), processService));
        }

        protected virtual TokenCredential CreateCredentialWithChainedOption(IProcessService processService, bool isChained)
        {
            var options = new AzurePowerShellCredentialOptions { IsChainedCredential = isChained };
            return InstrumentClient(new AzurePowerShellCredential(options, CredentialPipeline.GetInstance(null), processService));
        }

        protected virtual TokenCredential CreateBareCredential()
        {
            return InstrumentClient(new AzurePowerShellCredential());
        }

        protected virtual void CreateCredentialForTenantValidation(string tenantId)
        {
            new AzurePowerShellCredential(new AzurePowerShellCredentialOptions { TenantId = tenantId });
        }

        /// <summary>
        /// Returns the expected exception type for error scenarios.
        /// Base: AuthenticationFailedException when not chained, CredentialUnavailableException when chained.
        /// </summary>
        protected Type GetExpectedExceptionType(bool isChained)
            => isChained ? typeof(CredentialUnavailableException) : typeof(AuthenticationFailedException);

        protected virtual bool IsChainedCredentialSupported => true;
        #endregion

        [Test]
        public async Task AuthenticateWithAzurePowerShellCredential(
            [Values(null, TenantIdHint)] string tenantId,
            [Values(true)] bool allowMultiTenantAuthentication,
            [Values(null, TenantId)] string explicitTenantId)
        {
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            string expectedTenantId = TenantIdResolverBase.Default.Resolve(explicitTenantId, context, TenantIdResolverBase.AllTenants);
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzurePowerShell(TimeSpan.FromSeconds(30));

            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess, true), tenantId: explicitTenantId, addTenantIdHint: true);
            AccessToken actualToken = await credential.GetTokenAsync(context, default);

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
            yield return new object[] { null, "Run Connect-AzAccount to login", AzurePowerShellCredential.AzurePowerShellNotLogInError, true };
            yield return new object[] { null, "NoAzAccountModule", AzurePowerShellCredential.AzurePowerShellModuleNotInstalledError, true };
            yield return new object[] { null, "Get-AzAccessToken: Run Connect-AzAccount to login.", AzurePowerShellCredential.AzurePowerShellNotLogInError, true };
            yield return new object[] { null, "No accounts were found in the cache", AzurePowerShellCredential.AzurePowerShellNotLogInError, true };
            yield return new object[] { null, "cannot retrieve access token", AzurePowerShellCredential.AzurePowerShellNotLogInError, true };
            yield return new object[] { null, "Some random exception", AzurePowerShellCredential.AzurePowerShellFailedError + " Some random exception", false };
            yield return new object[] { GetExceptionAction(new AuthenticationFailedException("foo")), string.Empty, "foo", false };
            yield return new object[] { GetExceptionAction(new OperationCanceledException("foo")), string.Empty, "Azure PowerShell authentication timed out.", false };
            yield return new object[] {
                null,
                "AADSTS500011: The resource principal named <RESOURCE> was not found in the tenant named",
                AzurePowerShellCredential.AzurePowerShellFailedError +  " AADSTS500011: The resource principal named <RESOURCE> was not found in the tenant named",
                false };
        }

        private static IEnumerable<object[]> ErrorScenarios_IsChained()
        {
            yield return new object[] { null, "Run Connect-AzAccount to login", AzurePowerShellCredential.AzurePowerShellNotLogInError, true };
            yield return new object[] { null, "NoAzAccountModule", AzurePowerShellCredential.AzurePowerShellModuleNotInstalledError, true };
            yield return new object[] { null, "Get-AzAccessToken: Run Connect-AzAccount to login.", AzurePowerShellCredential.AzurePowerShellNotLogInError, true };
            yield return new object[] { null, "No accounts were found in the cache", AzurePowerShellCredential.AzurePowerShellNotLogInError, true };
            yield return new object[] { null, "cannot retrieve access token", AzurePowerShellCredential.AzurePowerShellNotLogInError, true };
            yield return new object[] { null, "Some random exception", AzurePowerShellCredential.AzurePowerShellFailedError + " Some random exception", true };
            yield return new object[] { GetExceptionAction(new AuthenticationFailedException("foo")), string.Empty, "foo", true };
            yield return new object[] { GetExceptionAction(new OperationCanceledException("foo")), string.Empty, "Azure PowerShell authentication timed out.", true };
            yield return new object[] {
                null,
                "AADSTS500011: The resource principal named <RESOURCE> was not found in the tenant named",
                AzurePowerShellCredential.AzurePowerShellFailedError +  " AADSTS500011: The resource principal named <RESOURCE> was not found in the tenant named",
                true };
        }

        [Test]
        [TestCaseSource(nameof(ErrorScenarios))]
        public void AuthenticateWithAzurePowerShellCredential_ErrorScenarios(Action<object> exceptionOnStartHandler, string errorMessage, string expectedError, bool isChained)
        {
            var testProcess = new TestProcess { Error = errorMessage, ExceptionOnStartHandler = exceptionOnStartHandler };
            var credential = CreateCredentialWithChainedOption(new TestProcessService(testProcess), false);
            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(isChained), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain(expectedError));
        }

        [Test]
        [TestCaseSource(nameof(ErrorScenarios_IsChained))]
        public void AuthenticateWithAzurePowerShellCredential_ErrorScenarios_IsChained(Action<object> exceptionOnStartHandler, string errorMessage, string expectedError, bool isChained)
        {
            if (!IsChainedCredentialSupported)
            {
                Assert.Ignore("ConfigurableCredential with CredentialSource does not support chained credential scenarios.");
            }
            var testProcess = new TestProcess { Error = errorMessage, ExceptionOnStartHandler = exceptionOnStartHandler };
            var credential = CreateCredentialWithChainedOption(new TestProcessService(testProcess), true);
            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(isChained), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain(expectedError));
        }

        /// <summary>
        /// Requires 2 TestProcess results falling back from pwsh to powershell on Windows
        /// </summary>
        private static IEnumerable<object[]> FallBackErrorScenarios()
        {
            yield return new object[] { "'pwsh' is not recognized", AzurePowerShellCredential.PowerShellNotInstalledError };
            yield return new object[] { "pwsh: command not found", AzurePowerShellCredential.PowerShellNotInstalledError };
            yield return new object[] { "pwsh: not found", AzurePowerShellCredential.PowerShellNotInstalledError };
            yield return new object[] { "foo bar", AzurePowerShellCredential.PowerShellNotInstalledError };
        }

        [Test]
        [TestCaseSource(nameof(FallBackErrorScenarios))]
        public void AuthenticateWithAzurePowerShellCredential_FallBackErrorScenarios(string errorMessage, string expectedError)
        {
            // This will require two processes on Windows and one on other platforms
            // Purposefully stripping out the second process to ensure any attempt to fallback is caught on non-Windows
            int exitCode = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 9009 : 127;

            TestProcess[] testProcesses = new TestProcess[] { new TestProcess { Error = errorMessage, CodeOnExit = exitCode }, new TestProcess { Error = errorMessage, CodeOnExit = exitCode } };
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                testProcesses = new TestProcess[] { testProcesses[0] };

            var credential = CreateCredential(new TestProcessService(testProcesses));
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain(expectedError));
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
                var credential = CreateCredential(new TestProcessService(testProcess, true));
                await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
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
            var credential = CreateCredential(new TestProcessService(testProcess, true));
            await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            Assert.IsTrue(fellBackToPowerShell);
        }

        [Test]
        public void ConfigurePowershellProcessTimeout_ProcessTimeout()
        {
            var testProcess = new TestProcess { Timeout = 10000 };
            var credential = CreateCredentialWithTimeout(new TestProcessService(testProcess), TimeSpan.Zero);
            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(false), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain(AzurePowerShellCredential.AzurePowerShellTimeoutError));
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
        public void AuthenticateWithAzurePowerShellCredential_AzurePowerShellUnknownError([Values(true, false)] bool isChainedCredential)
        {
            if (!IsChainedCredentialSupported && isChainedCredential)
            {
                Assert.Ignore("ConfigurableCredential with CredentialSource does not support chained credential scenarios.");
            }
            string mockResult = "mock-result";
            var testProcess = new TestProcess { Error = mockResult };
            var credential = CreateCredentialWithChainedOption(new TestProcessService(testProcess), isChainedCredential);

            Assert.ThrowsAsync(GetExpectedExceptionType(isChainedCredential), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
        }

        [Test]
        public void AzurePowerShellCredential_ClaimsChallenge_NoTenant_ThrowsWithGuidance()
        {
            var claims = "test-claims-challenge";
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzurePowerShell(TimeSpan.FromSeconds(30));
            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess, true));

            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(false), async () =>
                await credential.GetTokenAsync(new TokenRequestContext([Scope], claims: claims), default));

            Assert.That(ex.Message, Does.Contain("Azure PowerShell authentication requires multi-factor authentication or additional claims."));
            Assert.That(ex.Message, Does.Contain($"Connect-AzAccount -ClaimsChallenge '{claims}'"));
            Assert.That(ex.Message, Does.Not.Contain("-Tenant "));
        }

        [Test]
        public void AzurePowerShellCredential_ClaimsChallenge_WithTenant_ThrowsWithGuidance()
        {
            var claims = "test-claims-challenge";
            var tenant = TenantId;
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzurePowerShell(TimeSpan.FromSeconds(30));
            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess, true), tenantId: tenant);

            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(false), async () =>
                await credential.GetTokenAsync(new TokenRequestContext([Scope], claims: claims), default));

            Assert.That(ex.Message, Does.Contain($"Connect-AzAccount -Tenant {tenant} -ClaimsChallenge '{claims}'"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public async Task AzurePowerShellCredential_EmptyOrWhitespaceClaims_DoesNotTriggerGuidance(string claims)
        {
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzurePowerShell(TimeSpan.FromSeconds(30));
            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess, true));

            var token = await credential.GetTokenAsync(new TokenRequestContext(new[] { Scope }, claims: claims), default);
            Assert.AreEqual(expectedToken, token.Token);
            Assert.AreEqual(expectedExpiresOn, token.ExpiresOn);
        }

        [Test]
        public void AuthenticateWithAzurePowerShellCredential_CanceledByUser()
        {
            var cts = new CancellationTokenSource();
            var testProcess = new TestProcess { Timeout = 10000 };
            testProcess.Started += (o, e) => cts.Cancel();
            var credential = CreateCredential(new TestProcessService(testProcess));
            var ex = Assert.CatchAsync<Exception>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), cts.Token));
            Assert.That(ex.Message, Does.Contain("canceled").IgnoreCase);
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyCtorTenantIdValidation(char testChar)
        {
            string tenantId = Guid.NewGuid().ToString();

            for (int i = 0; i < tenantId.Length; i++)
            {
                StringBuilder tenantIdBuilder = new StringBuilder(tenantId);

                tenantIdBuilder.Insert(i, testChar);

                Assert.Throws<ArgumentException>(() => CreateCredentialForTenantValidation(tenantIdBuilder.ToString()), Validations.InvalidTenantIdErrorMessage);
            }
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyGetTokenTenantIdValidation(char testChar)
        {
            var credential = CreateBareCredential();

            string tenantId = Guid.NewGuid().ToString();

            for (int i = 0; i < tenantId.Length; i++)
            {
                StringBuilder tenantIdBuilder = new StringBuilder(tenantId);

                tenantIdBuilder.Insert(i, testChar);

                var tokenRequestContext = new TokenRequestContext(MockScopes.Default, tenantId: tenantIdBuilder.ToString());

                Assert.ThrowsAsync(GetExpectedExceptionType(false),
                    async () => await credential.GetTokenAsync(tokenRequestContext, default), Validations.InvalidTenantIdErrorMessage);
            }
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyGetTokenScopeValidation(char testChar)
        {
            var credential = CreateBareCredential();

            string scope = MockScopes.Default.ToString();

            for (int i = 0; i < scope.Length; i++)
            {
                StringBuilder scopeBuilder = new StringBuilder(scope);

                scopeBuilder.Insert(i, testChar);

                var tokenRequestContext = new TokenRequestContext(new string[] { scopeBuilder.ToString() });

                Assert.ThrowsAsync(GetExpectedExceptionType(false),
                    async () => await credential.GetTokenAsync(tokenRequestContext, default), ScopeUtilities.InvalidScopeMessage);
            }
        }

        [Test]
        public async Task AuthenticateWithAzurePowerShellCredential_HandlesSecureStringToken()
        {
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzurePowerShellSecureString(TimeSpan.FromSeconds(30));
            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess, true));

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.AreEqual(expectedExpiresOn, actualToken.ExpiresOn);

            // Verify PowerShell script checks for and handles Az.Accounts module version 5.0.0+
            var match = System.Text.RegularExpressions.Regex.Match(testProcess.StartInfo.Arguments, "EncodedCommand\\s*\"([^\"]+)\"");
            if (!match.Success)
            {
                throw new InvalidOperationException("Failed to extract the encoded command from the arguments.");
            }
            var commandString = match.Groups[1].Value;
            var b = Convert.FromBase64String(commandString);
            commandString = Encoding.Unicode.GetString(b);

            Assert.That(commandString, Does.Contain("if ($token.Token -is [System.Security.SecureString])"));
            Assert.That(commandString, Does.Contain("[System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($token.Token)"));
        }
    }
}
