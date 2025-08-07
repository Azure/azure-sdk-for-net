// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests
{
    [TestFixture]
    internal class PlaywrightReporterTests
    {
        [TearDown]
        public void TearDown()
        {
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, null);
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, null);
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, null);
            Environment.SetEnvironmentVariable(ReporterConstants.s_pLAYWRIGHT_SERVICE_REPORTING_URL, null);
        }

        private static string GetToken(Dictionary<string, object> claims, DateTime? expires = null)
        {
            var tokenHandler = new JsonWebTokenHandler();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Claims = claims,
                Expires = expires ?? DateTime.UtcNow.AddMinutes(10),
            });
            return token!;
        }

        [Test]
        public void PlaywrightReporter_Ctor_WithNulls()
        {
            var reporter = new PlaywrightReporter();
            Assert.NotNull(reporter._environment);
            Assert.NotNull(reporter._xmlRunSettings);
            Assert.NotNull(reporter._consoleWriter);
            Assert.NotNull(reporter._jsonWebTokenHandler);
            Assert.NotNull(reporter._logger);

            Assert.Null(reporter._parametersDictionary);
            Assert.Null(reporter._playwrightService);
            Assert.Null(reporter._testProcessor);
        }

        [Test]
        public void InitializePlaywrightReporter_InvalidRunSettings_PrintsMessageAndExits()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var environmentMock = new Mock<IEnvironment>();

            environmentMock.Setup(e => e.Exit(It.IsAny<int>())).Callback<int>(i => { });
            consoleWriterMock.Setup(c => c.WriteError(It.IsAny<string>())).Verifiable();

            var xmlSettings = @"
<RunSettings>
    <TestRunParameters>
        <Parameter name=""ServiceAuthType"" value=""No-auth"" />
    </TestRunParameters>
</RunSettings>
";
            var reporter = new PlaywrightReporter(logger: null, environment: environmentMock.Object, xmlRunSettings: null, consoleWriter: consoleWriterMock.Object, jsonWebTokenHandler: null);
            reporter.InitializePlaywrightReporter(xmlSettings);

            consoleWriterMock.Verify(c => c.WriteError(It.IsRegex("Failed to initialize PlaywrightServiceSettings")), Times.Once);
            environmentMock.Verify(e => e.Exit(1), Times.Once);
            Assert.Null(reporter._testProcessor);
        }

        [Test]
        public void InitializePlaywrightReporter_WithNoServiceUrl_PrintsMessageAndExits()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var environmentMock = new Mock<IEnvironment>();

            environmentMock.Setup(e => e.Exit(It.IsAny<int>())).Callback<int>(i => { });
            consoleWriterMock.Setup(c => c.WriteError(It.IsAny<string>())).Verifiable();

            var reporter = new PlaywrightReporter(logger: null, environment: environmentMock.Object, xmlRunSettings: null, consoleWriter: consoleWriterMock.Object, jsonWebTokenHandler: null);

            reporter.InitializePlaywrightReporter("");

            consoleWriterMock.Verify(c => c.WriteError(Constants.s_no_service_endpoint_error_message), Times.Once);
            environmentMock.Verify(e => e.Exit(1), Times.Once);
            Assert.Null(reporter._testProcessor);
        }

        [Test]
        public void InitializePlaywrightReporter_WithNoAccessToken_PrintsMessageAndExits()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var environmentMock = new Mock<IEnvironment>();

            environmentMock.Setup(e => e.Exit(It.IsAny<int>())).Callback<int>(i => { });
            environmentMock.Setup(e => e.GetEnvironmentVariable(ReporterConstants.s_pLAYWRIGHT_SERVICE_REPORTING_URL)).Returns("reporting-url");
            consoleWriterMock.Setup(c => c.WriteError(It.IsAny<string>())).Verifiable();

            var reporter = new PlaywrightReporter(logger: null, environment: environmentMock.Object, xmlRunSettings: null, consoleWriter: consoleWriterMock.Object, jsonWebTokenHandler: null);

            reporter.InitializePlaywrightReporter("");

            consoleWriterMock.Verify(c => c.WriteError(Constants.s_no_auth_error), Times.Once);
            environmentMock.Verify(e => e.Exit(1), Times.Once);
            Assert.Null(reporter._testProcessor);
        }

        [Test]
        public void InitializePlaywrightReporter_Default_SetsUpTestProcessor()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var environmentMock = new Mock<IEnvironment>();
            var accessToken = GetToken(new Dictionary<string, object> { { "aid", "account-id-guid" }, { "oid", "org-id" }, { "id", "uuid" }, { "name", "username" } });

            environmentMock.Setup(e => e.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId)).Returns("run-id");
            environmentMock.Setup(e => e.GetEnvironmentVariable(ReporterConstants.s_pLAYWRIGHT_SERVICE_REPORTING_URL)).Returns("https://eastus.reporting.api.playwright.microsoft.com");
            environmentMock.Setup(e => e.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken)).Returns(accessToken);

            var reporter = new PlaywrightReporter(logger: null, environment: environmentMock.Object, xmlRunSettings: null, consoleWriter: consoleWriterMock.Object, jsonWebTokenHandler: null);

            reporter.InitializePlaywrightReporter("");

            Assert.NotNull(reporter._testProcessor);
            Assert.Multiple(() =>
            {
                Assert.AreEqual("run-id", reporter._testProcessor!._cloudRunMetadata.RunId!);
                Assert.AreEqual("account-id-guid", reporter._testProcessor!._cloudRunMetadata.WorkspaceId!);
                Assert.AreEqual(new Uri("https://eastus.reporting.api.playwright.microsoft.com"), reporter._testProcessor!._cloudRunMetadata.BaseUri!);
                Assert.IsTrue(reporter._testProcessor!._cloudRunMetadata.EnableResultPublish);
                Assert.IsTrue(reporter._testProcessor!._cloudRunMetadata.EnableGithubSummary);
                Assert.NotNull(reporter._testProcessor!._cloudRunMetadata.TestRunStartTime);
                Assert.AreEqual(1, reporter._testProcessor!._cloudRunMetadata.NumberOfTestWorkers);
                Assert.AreEqual("account-id-guid", reporter._testProcessor!._cloudRunMetadata.AccessTokenDetails!.aid!);
                Assert.AreEqual("org-id", reporter._testProcessor!._cloudRunMetadata.AccessTokenDetails!.oid!);
                Assert.AreEqual("uuid", reporter._testProcessor!._cloudRunMetadata.AccessTokenDetails!.id!);
                Assert.AreEqual("username", reporter._testProcessor!._cloudRunMetadata.AccessTokenDetails!.userName!);
            });
        }

        [Test]
        public void InitializePlaywrightReporter_WithGHCI_UsesCIInfoToCreateRunIdAndPopulateTestProcessor()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var environmentMock = new Mock<IEnvironment>();
            var accessToken = GetToken(new Dictionary<string, object> { { "aid", "account-id-guid" }, { "oid", "org-id" }, { "id", "uuid" }, { "name", "username" } });

            environmentMock.Setup(e => e.GetEnvironmentVariable("GITHUB_ACTIONS")).Returns("true");
            environmentMock.Setup(e => e.GetEnvironmentVariable("GITHUB_RUN_ID")).Returns("run-id");
            environmentMock.Setup(e => e.GetEnvironmentVariable("GITHUB_REPOSITORY_ID")).Returns("repo-id");
            environmentMock.Setup(e => e.GetEnvironmentVariable("GITHUB_ACTOR")).Returns("actor");
            environmentMock.Setup(e => e.GetEnvironmentVariable("GITHUB_SHA")).Returns("commit-id");
            environmentMock.Setup(e => e.GetEnvironmentVariable("GITHUB_SERVER_URL")).Returns("https://github.com");
            environmentMock.Setup(e => e.GetEnvironmentVariable("GITHUB_REPOSITORY")).Returns("repo");
            environmentMock.Setup(e => e.GetEnvironmentVariable("GITHUB_RUN_ATTEMPT")).Returns("1");
            environmentMock.Setup(e => e.GetEnvironmentVariable("GITHUB_JOB")).Returns("job-id");
            environmentMock.Setup(e => e.GetEnvironmentVariable("GITHUB_REF_NAME")).Returns("branch-name");
            environmentMock.Setup(e => e.GetEnvironmentVariable(ReporterConstants.s_pLAYWRIGHT_SERVICE_REPORTING_URL)).Returns("https://eastus.reporting.api.playwright.microsoft.com");
            environmentMock.Setup(e => e.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken)).Returns(accessToken);

            var reporter = new PlaywrightReporter(logger: null, environment: environmentMock.Object, xmlRunSettings: null, consoleWriter: consoleWriterMock.Object, jsonWebTokenHandler: null);

            reporter.InitializePlaywrightReporter("");

            Assert.NotNull(reporter._testProcessor);
            var runId = ReporterUtils.CalculateSha1Hash($"{CIConstants.s_gITHUB_ACTIONS}-repo-id-run-id-1");
            Assert.Multiple(() =>
            {
                Assert.AreEqual("run-id", reporter._testProcessor!._cIInfo.RunId);
                Assert.AreEqual("repo-id", reporter._testProcessor!._cIInfo.Repo);
                Assert.AreEqual("commit-id", reporter._testProcessor!._cIInfo.CommitId);
                Assert.AreEqual("actor", reporter._testProcessor!._cIInfo.Author);
                Assert.AreEqual("branch-name", reporter._testProcessor!._cIInfo.Branch);
                Assert.AreEqual(CIConstants.s_gITHUB_ACTIONS, reporter._testProcessor!._cIInfo.Provider);
                Assert.AreEqual("job-id", reporter._testProcessor!._cIInfo.JobId);
                Assert.AreEqual(1, reporter._testProcessor!._cIInfo.RunAttempt);
                Assert.AreEqual(reporter._testProcessor!._cIInfo.RevisionUrl, "https://github.com/repo/commit/commit-id");
            });
            environmentMock.Verify(e => e.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, runId), Times.Once);
        }

        [Test]
        public void InitializePlaywrightReporter_WithADOCI_UsesCIInfoToCreateRunIdAndPopulateTestProcessor()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var environmentMock = new Mock<IEnvironment>();
            var accessToken = GetToken(new Dictionary<string, object> { { "aid", "account-id-guid" }, { "oid", "org-id" }, { "id", "uuid" }, { "name", "username" } });

            environmentMock.Setup(e => e.GetEnvironmentVariable("AZURE_HTTP_USER_AGENT")).Returns("true");
            environmentMock.Setup(e => e.GetEnvironmentVariable("TF_BUILD")).Returns("true");
            environmentMock.Setup(e => e.GetEnvironmentVariable("BUILD_REPOSITORY_ID")).Returns("repo-id");
            environmentMock.Setup(e => e.GetEnvironmentVariable("BUILD_REQUESTEDFOR")).Returns("actor");
            environmentMock.Setup(e => e.GetEnvironmentVariable("BUILD_SOURCEVERSION")).Returns("commit-id");
            environmentMock.Setup(e => e.GetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI")).Returns("https://ado.com/");
            environmentMock.Setup(e => e.GetEnvironmentVariable("SYSTEM_TEAMPROJECT")).Returns("project");
            environmentMock.Setup(e => e.GetEnvironmentVariable("BUILD_REPOSITORY_NAME")).Returns("repo");
            environmentMock.Setup(e => e.GetEnvironmentVariable("RELEASE_ATTEMPTNUMBER")).Returns("1");
            environmentMock.Setup(e => e.GetEnvironmentVariable("BUILD_SOURCEBRANCH")).Returns("branch-name");
            environmentMock.Setup(e => e.GetEnvironmentVariable("RELEASE_DEFINITIONID")).Returns("definition-id");
            environmentMock.Setup(e => e.GetEnvironmentVariable("RELEASE_DEPLOYMENTID")).Returns("release-id");
            environmentMock.Setup(e => e.GetEnvironmentVariable(ReporterConstants.s_pLAYWRIGHT_SERVICE_REPORTING_URL)).Returns("https://eastus.reporting.api.playwright.microsoft.com");
            environmentMock.Setup(e => e.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken)).Returns(accessToken);

            var reporter = new PlaywrightReporter(logger: null, environment: environmentMock.Object, xmlRunSettings: null, consoleWriter: consoleWriterMock.Object, jsonWebTokenHandler: null);

            reporter.InitializePlaywrightReporter("");

            Assert.NotNull(reporter._testProcessor);
            var runId = ReporterUtils.CalculateSha1Hash($"{CIConstants.s_aZURE_DEVOPS}-repo-id-definition-id-release-id-1");
            Assert.Multiple(() =>
            {
                Assert.AreEqual("definition-id-release-id", reporter._testProcessor!._cIInfo.RunId);
                Assert.AreEqual("repo-id", reporter._testProcessor!._cIInfo.Repo);
                Assert.AreEqual("commit-id", reporter._testProcessor!._cIInfo.CommitId);
                Assert.AreEqual("actor", reporter._testProcessor!._cIInfo.Author);
                Assert.AreEqual("branch-name", reporter._testProcessor!._cIInfo.Branch);
                Assert.AreEqual(CIConstants.s_aZURE_DEVOPS, reporter._testProcessor!._cIInfo.Provider);
                Assert.AreEqual("release-id", reporter._testProcessor!._cIInfo.JobId);
                Assert.AreEqual(1, reporter._testProcessor!._cIInfo.RunAttempt);
                Assert.AreEqual(reporter._testProcessor!._cIInfo.RevisionUrl, "https://ado.com/project/_git/repo/commit/commit-id");
            });
            environmentMock.Verify(e => e.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, runId), Times.Once);
        }

        [Test]
        public void InitializePlaywrightReporter_ParseRunSettings_SetupTestProcessor()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var accessToken = GetToken(new Dictionary<string, object> { { "aid", "eastus_e3d6f8f5-8c4e-4f74-a6f6-6b6d423d6d42" }, { "oid", "org-id" }, { "id", "uuid" }, { "name", "username" } });

            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, "wss://eastus.api.playwright.microsoft.com/accounts/eastus_e3d6f8f5-8c4e-4f74-a6f6-6b6d423d6d42/browsers");
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, accessToken);

            var reporter = new PlaywrightReporter(logger: null, environment: null, xmlRunSettings: null, consoleWriter: consoleWriterMock.Object, jsonWebTokenHandler: null);
            var xmlSettings = @"
<RunSettings>
    <TestRunParameters>
        <Parameter name=""ServiceAuthType"" value=""AccessToken"" />
        <Parameter name=""EnableGitHubSummary"" value=""false"" />
        <Parameter name=""EnableResultPublish"" value=""false"" />
        <Parameter name=""RunId"" value=""Sample-Run-Id"" />
    </TestRunParameters>
    <NUnit>
        <NumberOfTestWorkers>3</NumberOfTestWorkers>
    </NUnit>
</RunSettings>
";
            reporter.InitializePlaywrightReporter(xmlSettings);

            Assert.NotNull(reporter._testProcessor);
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Sample-Run-Id", reporter._testProcessor!._cloudRunMetadata.RunId!);
                Assert.AreEqual(new Uri("https://eastus.reporting.api.playwright.microsoft.com"), reporter._testProcessor!._cloudRunMetadata.BaseUri!);
                Assert.IsFalse(reporter._testProcessor!._cloudRunMetadata.EnableResultPublish);
                Assert.IsFalse(reporter._testProcessor!._cloudRunMetadata.EnableGithubSummary);
                Assert.AreEqual(3, reporter._testProcessor!._cloudRunMetadata.NumberOfTestWorkers);
                Assert.AreEqual(ServiceAuthType.AccessToken, reporter._playwrightService!.ServiceAuth);
            });
        }
    }
}
