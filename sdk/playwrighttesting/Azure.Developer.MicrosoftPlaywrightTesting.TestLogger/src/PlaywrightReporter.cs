// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System;
using System.Collections.Generic;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Processor;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger;

[FriendlyName("microsoft-playwright-testing")]
[ExtensionUri("logger://MicrosoftPlaywrightTesting/Logger/v1")]
internal class PlaywrightReporter : ITestLoggerWithParameters
{
    internal Dictionary<string, string?>? _parametersDictionary;
    internal PlaywrightService? _playwrightService;
    internal TestProcessor? _testProcessor;
    internal readonly ILogger _logger;
    internal IEnvironment _environment;
    internal IXmlRunSettings _xmlRunSettings;
    internal IConsoleWriter _consoleWriter;
    internal JsonWebTokenHandler _jsonWebTokenHandler;

    public PlaywrightReporter() : this(null, null, null, null, null) { } // no-op
    public PlaywrightReporter(ILogger? logger, IEnvironment? environment, IXmlRunSettings? xmlRunSettings, IConsoleWriter? consoleWriter, JsonWebTokenHandler? jsonWebTokenHandler)
    {
        _logger = logger ?? new Logger();
        _environment = environment ?? new EnvironmentHandler();
        _xmlRunSettings = xmlRunSettings ?? new XmlRunSettings();
        _consoleWriter = consoleWriter ?? new ConsoleWriter();
        _jsonWebTokenHandler = jsonWebTokenHandler ?? new JsonWebTokenHandler();
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

    internal void InitializePlaywrightReporter(string xmlSettings)
    {
        Dictionary<string, object> runParameters = _xmlRunSettings.GetTestRunParameters(xmlSettings);
        Dictionary<string, object> nunitParameters = _xmlRunSettings.GetNUnitParameters(xmlSettings);
        runParameters.TryGetValue(RunSettingKey.RunId, out var runId);
        // If run id is not provided and not set via env, try fetching it from CI info.
        CIInfo cIInfo = CiInfoProvider.GetCIInfo(_environment);
        if (string.IsNullOrEmpty(_environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId)))
        {
            if (string.IsNullOrEmpty(runId?.ToString()))
                _environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, ReporterUtils.GetRunId(cIInfo));
            else
                _environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, runId!.ToString()!); // runId is checked above
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
        runParameters.TryGetValue(RunSettingKey.Os, out var osType);
        runParameters.TryGetValue(RunSettingKey.ExposeNetwork, out var exposeNetwork);
        nunitParameters.TryGetValue(RunSettingKey.NumberOfTestWorkers, out var numberOfTestWorkers);
        runParameters.TryGetValue(RunSettingKey.RunName, out var runName);

        string? enableGithubSummaryString = enableGithubSummary?.ToString();
        string? enableResultPublishString = enableResultPublish?.ToString();

        bool _enableGitHubSummary = string.IsNullOrEmpty(enableGithubSummaryString) || bool.Parse(enableGithubSummaryString!);
        bool _enableResultPublish = string.IsNullOrEmpty(enableResultPublishString) || bool.Parse(enableResultPublishString!);

        PlaywrightServiceOptions? playwrightServiceSettings;
        try
        {
            playwrightServiceSettings = new(runId: runId?.ToString(), serviceAuth: serviceAuth?.ToString(), azureTokenCredentialType: azureTokenCredential?.ToString(), managedIdentityClientId: managedIdentityClientId?.ToString(), os: PlaywrightService.GetOSPlatform(osType?.ToString()), exposeNetwork: exposeNetwork?.ToString());
        }
        catch (Exception ex)
        {
            _consoleWriter.WriteError("Failed to initialize PlaywrightServiceSettings: " + ex);
            _environment.Exit(1);
            return;
        }
        // setup entra rotation handlers
        IFrameworkLogger frameworkLogger = new VSTestFrameworkLogger(_logger);
        try
        {
            _playwrightService = new PlaywrightService(null, playwrightServiceSettings!.RunId, null, playwrightServiceSettings.ServiceAuth, null, entraLifecycle: null, jsonWebTokenHandler: _jsonWebTokenHandler, credential: playwrightServiceSettings.AzureTokenCredential, frameworkLogger: frameworkLogger);
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            _playwrightService.InitializeAsync().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }
        catch (Exception ex)
        {
            // We have checks for access token and base url in the next block, so we can ignore the exception here.
            _logger.Error("Failed to initialize PlaywrightService: " + ex);
        }

        var cloudRunId = _environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId);
        string? baseUrl = _environment.GetEnvironmentVariable(ReporterConstants.s_pLAYWRIGHT_SERVICE_REPORTING_URL);
        string? accessToken = _environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken);
        if (string.IsNullOrEmpty(baseUrl))
        {
            _consoleWriter.WriteError(Constants.s_no_service_endpoint_error_message);
            _environment.Exit(1);
            return;
        }
        if (string.IsNullOrEmpty(accessToken))
        {
            _consoleWriter.WriteError(Constants.s_no_auth_error);
            _environment.Exit(1);
            return;
        }
        if (cloudRunId?.Length > 200)
        {
            _consoleWriter.WriteError(Constants.s_playwright_service_runId_length_exceeded_error_message);
            _environment.Exit(1);
            return;
        }
        var baseUri = new Uri(baseUrl);
        var reporterUtils = new ReporterUtils();
        TokenDetails tokenDetails = reporterUtils.ParseWorkspaceIdFromAccessToken(jsonWebTokenHandler: _jsonWebTokenHandler, accessToken: accessToken);
        var workspaceId = tokenDetails.aid;
        var runNameString = runName?.ToString();
        if (runNameString?.Length > 200)
        {
            runNameString = runNameString.Substring(0, 200);
            _consoleWriter.WriteLine(Constants.s_playwright_service_runName_truncated_warning);
        }
        var cloudRunMetadata = new CloudRunMetadata
        {
            RunId = cloudRunId,
            RunName = runNameString,
            WorkspaceId = workspaceId,
            BaseUri = baseUri,
            EnableResultPublish = _enableResultPublish,
            EnableGithubSummary = _enableGitHubSummary,
            TestRunStartTime = DateTime.UtcNow,
            AccessTokenDetails = tokenDetails,
            NumberOfTestWorkers = numberOfTestWorkers != null ? Convert.ToInt32(numberOfTestWorkers) : 1
        };

        _testProcessor = new TestProcessor(cloudRunMetadata, cIInfo);
        _logger.Info("Playwright Service Reporter Initialized");
    }
}
