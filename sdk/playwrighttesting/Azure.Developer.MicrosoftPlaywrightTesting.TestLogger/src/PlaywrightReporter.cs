// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Collections.Generic;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Processor;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger;

[FriendlyName("microsoft-playwright-testing")]
[ExtensionUri("logger://MicrosoftPlaywrightTesting/Logger/v1")]
internal class PlaywrightReporter : ITestLoggerWithParameters
{
    private Dictionary<string, string?>? _parametersDictionary;
    private PlaywrightService? _playwrightService;
    private readonly ILogger _logger;
    private TestProcessor? _testProcessor;

    public PlaywrightReporter() : this(null) { } // no-op
    public PlaywrightReporter(ILogger? logger)
    {
        _logger = logger ?? new Logger();
    }

    public void Initialize(TestLoggerEvents events, Dictionary<string, string?> parameters)
    {
        ValidateArg.NotNull(events, nameof(events));
        _parametersDictionary = parameters;
        Initialize(events, _parametersDictionary[DefaultLoggerParameterNames.TestRunDirectory]!);
    }
    public void Initialize(TestLoggerEvents events, string testResultsDirPath)
    {
        ValidateArg.NotNull(events, nameof(events));
        ValidateArg.NotNullOrEmpty(testResultsDirPath, nameof(testResultsDirPath));

        // Register for the events.
        events.TestResult += TestResultHandler; // each test run end
        events.TestRunComplete += TestRunCompleteHandler; // test suite end
        events.TestRunStart += TestRunStartHandler; // test suite start
    }

    #region Event Handlers
    internal void TestRunStartHandler(object? sender, TestRunStartEventArgs e)
    {
        InitializePlaywrightReporter(e.TestRunCriteria.TestRunSettings!);
        _testProcessor?.TestRunStartHandler(sender, e);
    }

    internal void TestResultHandler(object? sender, TestResultEventArgs e)
    {
        _testProcessor?.TestCaseResultHandler(sender, e);
    }

    internal void TestRunCompleteHandler(object? sender, TestRunCompleteEventArgs e)
    {
        _testProcessor?.TestRunCompleteHandler(sender, e);
        _playwrightService?.Cleanup();
    }
    #endregion

    private void InitializePlaywrightReporter(string xmlSettings)
    {
        Dictionary<string, object> runParameters = XmlRunSettingsUtilities.GetTestRunParameters(xmlSettings);
        runParameters.TryGetValue(RunSettingKey.RunId, out var runId);
        // If run id is not provided and not set via env, try fetching it from CI info.
        CIInfo cIInfo = CiInfoProvider.GetCIInfo();
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId)))
        {
            if (string.IsNullOrEmpty(runId?.ToString()))
                Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, ReporterUtils.GetRunId(cIInfo));
            else
                Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, runId!.ToString());
        }
        else
        {
            PlaywrightService.GetDefaultRunId(); // will not set run id if already present in the environment variable
        }

        runParameters.TryGetValue(RunSettingKey.ServiceAuthType, out var serviceAuth);
        runParameters.TryGetValue(RunSettingKey.AzureTokenCredentialType, out var azureTokenCredential);
        runParameters.TryGetValue(RunSettingKey.ManagedIdentityClientId, out var managedIdentityClientId);
        runParameters.TryGetValue(RunSettingKey.EnableGitHubSummary, out var enableGithubSummary);
        runParameters.TryGetValue(RunSettingKey.EnableResultPublish, out var enableResultPublish);
        string? enableGithubSummaryString = enableGithubSummary?.ToString();
        string? enableResultPublishString = enableResultPublish?.ToString();

        bool _enableGitHubSummary = string.IsNullOrEmpty(enableGithubSummaryString) || bool.Parse(enableGithubSummaryString!);
        bool _enableResultPublish = string.IsNullOrEmpty(enableResultPublishString) || bool.Parse(enableResultPublishString!);

        PlaywrightServiceOptions? playwrightServiceSettings = null;
        try
        {
            playwrightServiceSettings = new(runId: runId?.ToString(), serviceAuth: serviceAuth?.ToString(), azureTokenCredentialType: azureTokenCredential?.ToString(), managedIdentityClientId: managedIdentityClientId?.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Failed to initialize PlaywrightServiceSettings: " + ex);
            Environment.Exit(1);
        }

        // setup entra rotation handlers
        _playwrightService = new PlaywrightService(null, playwrightServiceSettings!.RunId, null, playwrightServiceSettings.ServiceAuth, null, playwrightServiceSettings.AzureTokenCredential);
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        _playwrightService.InitializeAsync().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.

        var cloudRunId = Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId);
        string baseUrl = Environment.GetEnvironmentVariable(ReporterConstants.s_pLAYWRIGHT_SERVICE_REPORTING_URL);
        string accessToken = Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken);
        if (string.IsNullOrEmpty(baseUrl))
        {
            Console.Error.WriteLine(Constants.s_no_service_endpoint_error_message);
            Environment.Exit(1);
        }
        if (string.IsNullOrEmpty(accessToken))
        {
            Console.Error.WriteLine(Constants.s_no_auth_error);
            Environment.Exit(1);
        }

        var baseUri = new Uri(baseUrl);
        var reporterUtils = new ReporterUtils();
        TokenDetails tokenDetails = reporterUtils.ParseWorkspaceIdFromAccessToken(jsonWebTokenHandler: null, accessToken: accessToken);
        var workspaceId = tokenDetails.aid;

        var cloudRunMetadata = new CloudRunMetadata
        {
            RunId = cloudRunId,
            WorkspaceId = workspaceId,
            BaseUri = baseUri,
            EnableResultPublish = _enableResultPublish,
            EnableGithubSummary = _enableGitHubSummary,
            TestRunStartTime = DateTime.UtcNow,
            AccessTokenDetails = tokenDetails,
        };

        _testProcessor = new TestProcessor(cloudRunMetadata, cIInfo);
        _logger.Info("Playwright Service Reporter Initialized");
    }
}
