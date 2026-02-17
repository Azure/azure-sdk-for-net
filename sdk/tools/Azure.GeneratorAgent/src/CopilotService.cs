// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using GitHub.Copilot.SDK;
using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent;

/// <summary>
/// Service for interacting with GitHub Copilot SDK for Azure SDK migration tasks.
/// </summary>
public class CopilotService : IAsyncDisposable
{
    private const string CopilotModel = "claude-sonnet-4-20241022";
    private const string CopilotLogLevel = "warning";
    private static readonly List<string> AvailableTools = ["view", "grep", "glob"];
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(2);

    private readonly ILogger<CopilotService> _logger;
    private CopilotClient? _client;
    private CopilotSession? _session;
    private readonly object _lockObject = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="CopilotService"/> class.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    public CopilotService(ILogger<CopilotService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets whether Copilot is fully available for use (both client and session ready).
    /// </summary>
    public bool IsCopilotAvailable => _client != null && _session != null;

    /// <summary>
    /// Initializes the Copilot client and creates a session in one operation.
    /// </summary>
    /// <param name="projectPath">The path to the project directory.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task that represents the asynchronous initialization operation.</returns>
    /// <exception cref="ArgumentException">Thrown when projectPath is null or empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown when initialization fails.</exception>
    public async Task InitializeCopilotAsync(string projectPath, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(projectPath))
        {
            var message = "Project path is required for Copilot initialization";
            _logger.LogError(message);
            throw new ArgumentException(message, nameof(projectPath));
        }

        lock (_lockObject)
        {
            if (_client != null && _session != null)
            {
                _logger.LogDebug("Copilot already initialized, skipping");
                return;
            }
        }

        try
        {
            _logger.LogDebug("Initializing Copilot client with project path: {ProjectPath}", projectPath);

            // Initialize client
            _client = new CopilotClient(new CopilotClientOptions
            {
                Cwd = projectPath,
                AutoStart = true,
                LogLevel = CopilotLogLevel
            });

            await _client.StartAsync().ConfigureAwait(false);
            _logger.LogDebug("Copilot client initialized successfully");

            // Create session
            _session = await _client.CreateSessionAsync(new SessionConfig
            {
                Model = CopilotModel,
                SystemMessage = new SystemMessageConfig
                {
                    Mode = SystemMessageMode.Append,
                    Content = CopilotPrompts.BuildMigrationSystemMessage(projectPath)
                },
                AvailableTools = AvailableTools,
                InfiniteSessions = new InfiniteSessionConfig { Enabled = false },
                Streaming = true
            }).ConfigureAwait(false);

            _logger.LogInformation("Copilot service initialized successfully with model: {Model}", CopilotModel);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            _logger.LogInformation("Copilot initialization was cancelled by user");
            _client = null;
            _session = null;
            throw;
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("Copilot initialization timed out");
            _client = null;
            _session = null;
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to initialize Copilot client and session with project path: {ProjectPath}", projectPath);
            _client = null;
            _session = null;
            throw new InvalidOperationException($"Failed to initialize Copilot service: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Gets the Typespec specification path for a service in azure-rest-api-specs repository using Copilot.
    /// </summary>
    /// <param name="projectPath">The path to the project directory.</param>
    /// <param name="repoName">Repository name to find the service path for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Specification path starting with 'specification/' if found, null otherwise.</returns>
    /// <exception cref="InvalidOperationException">Thrown when Copilot is not initialized.</exception>
    public async Task<string?> GetTypeSpecSpecificationPath(string projectPath, string repoName, CancellationToken cancellationToken = default)
    {
        if (!IsCopilotAvailable)
        {
            var message = "Copilot client and session must be initialized before getting specification path";
            _logger.LogError(message);
            throw new InvalidOperationException(message);
        }

        if (string.IsNullOrEmpty(repoName))
        {
            _logger.LogWarning("Repository name is null or empty, cannot determine specification path");
            return null;
        }

        _logger.LogDebug("Requesting specification path for repository: {RepoName}", repoName);

        var prompt = CopilotPrompts.TypespecPathAnalysisPrompt(projectPath, repoName);
        var result = await SendPromptAndGetResponseAsync(prompt, cancellationToken).ConfigureAwait(false);

        if (!string.IsNullOrEmpty(result))
        {
            _logger.LogInformation("Copilot determined specification path for {RepoName}: {Path}", repoName, result);
        }
        else
        {
            _logger.LogWarning("Copilot could not determine specification path for repository: {RepoName}", repoName);
        }

        return result;
    }

    /// <summary>
    /// Sends a prompt to Copilot and waits for the complete response.
    /// </summary>
    /// <param name="prompt">The prompt to send.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The response from Copilot, or null if no response received.</returns>
    private async Task<string?> SendPromptAndGetResponseAsync(string prompt, CancellationToken cancellationToken)
    {
        var responseBuilder = new System.Text.StringBuilder();
        var completionTcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        // Subscribe to events for this request only
        using var subscription = _session!.On(evt =>
        {
            try
            {
                switch (evt)
                {
                    case AssistantMessageEvent assistantMsg:
                        responseBuilder.Append(assistantMsg.Data.Content);
                        _logger.LogTrace("Received assistant message content: {ContentLength} characters", assistantMsg.Data.Content.Length);
                        break;
                    case SessionErrorEvent errorEvt:
                        _logger.LogError("Copilot session error: {Error}", errorEvt.Data.Message);
                        completionTcs.TrySetException(new InvalidOperationException($"Copilot session error: {errorEvt.Data.Message}"));
                        break;
                    case SessionIdleEvent:
                        _logger.LogTrace("Copilot session became idle, completing response");
                        completionTcs.TrySetResult();
                        break;
                    case ToolExecutionStartEvent:
                        _logger.LogTrace("Copilot tool execution started");
                        break;
                    case ToolExecutionCompleteEvent:
                        _logger.LogTrace("Copilot tool execution completed");
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error handling Copilot session event of type: {EventType}", evt.GetType().Name);
            }
        });

        try
        {
            _logger.LogDebug("Sending prompt to Copilot: {PromptLength} characters", prompt.Length);
            var messageId = await _session.SendAsync(new MessageOptions { Prompt = prompt }).ConfigureAwait(false);
            _logger.LogDebug("Sent message to Copilot with ID: {MessageId}", messageId);

            using var timeoutCts = new CancellationTokenSource(DefaultTimeout);
            using var combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            await completionTcs.Task.WaitAsync(combinedCts.Token).ConfigureAwait(false);

            var response = responseBuilder.ToString().Trim();
            if (string.IsNullOrWhiteSpace(response))
            {
                _logger.LogWarning("Copilot returned empty or whitespace-only response");
                return null;
            }

            _logger.LogDebug("Received response from Copilot: {ResponseLength} characters", response.Length);
            return response;
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            _logger.LogInformation("Copilot prompt was cancelled by user");
            return null;
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("Copilot prompt timed out after {Timeout}", DefaultTimeout);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get response from Copilot for prompt (length: {PromptLength})", prompt.Length);
            return null;
        }
    }

    /// <summary>
    /// Disposes of the Copilot client and session resources.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        try
        {
            if (_session != null)
            {
                _logger.LogInformation("Disposing Copilot session");
                await _session.DisposeAsync().ConfigureAwait(false);
                _session = null;
            }

            if (_client != null)
            {
                _logger.LogInformation("Stopping and disposing Copilot client");
                await _client.StopAsync().ConfigureAwait(false);
                await _client.DisposeAsync().ConfigureAwait(false);
                _client = null;
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error occurred while disposing Copilot service resources");
        }
    }
}
