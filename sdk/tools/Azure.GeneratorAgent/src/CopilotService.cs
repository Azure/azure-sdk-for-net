// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using GitHub.Copilot.SDK;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent;

/// <summary>
/// Service for interacting with GitHub Copilot SDK for Azure SDK migration tasks.
/// </summary>
public class CopilotService : IAsyncDisposable
{
    private readonly ILogger<CopilotService> _logger;
    private readonly AppSettings _settings;
    private CopilotClient? _client;
    private CopilotSession? _session;
    private bool _isInitialized;
    private bool _isDisposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="CopilotService"/> class.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    /// <param name="settings">Copilot configuration settings.</param>
    public CopilotService(ILogger<CopilotService> logger, AppSettings settings)
    {
        _logger = logger;
        _settings = settings;
    }

    /// <summary>
    /// Gets whether Copilot is fully available for use (both client and session ready).
    /// </summary>
    public bool IsCopilotAvailable => _isInitialized && !_isDisposed;

    /// <summary>
    /// Initializes the Copilot client and creates a session in one operation.
    /// </summary>
    /// <param name="projectPath">The path to the project directory.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task that represents the asynchronous initialization operation.</returns>
    /// <exception cref="ArgumentException">Thrown when projectPath is null or empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown when initialization fails.</exception>
    /// <exception cref="ObjectDisposedException">Thrown when the service has been disposed.</exception>
    public async Task InitializeCopilotAsync(string projectPath, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(projectPath))
        {
            var message = "Project path is required for Copilot initialization";
            _logger.LogError(message);
            throw new ArgumentException(message, nameof(projectPath));
        }

        ObjectDisposedException.ThrowIf(_isDisposed, this);

        if (_isInitialized)
        {
            _logger.LogDebug("Copilot already initialized, skipping");
            return;
        }

        try
        {
            _logger.LogDebug("Initializing Copilot client with project path: {ProjectPath}", projectPath);

            // Initialize client
            _client = new CopilotClient(new CopilotClientOptions
            {
                Cwd = projectPath,
                AutoStart = true,
                LogLevel = _settings.LogLevel
            });

            await _client.StartAsync().ConfigureAwait(false);
            _logger.LogDebug("Copilot client initialized successfully");

            // Create session
            _session = await _client.CreateSessionAsync(new SessionConfig
            {
                Model = _settings.Model,
                SystemMessage = new SystemMessageConfig
                {
                    Mode = SystemMessageMode.Append,
                    Content = CopilotPrompts.BuildMigrationSystemMessage(projectPath)
                },
                AvailableTools = ["view", "edit", "create", "grep", "glob", "terminal"],
                InfiniteSessions = new InfiniteSessionConfig { Enabled = false },
                Streaming = true
            }).ConfigureAwait(false);

            _isInitialized = true;
            _logger.LogInformation("Copilot service initialized successfully with model: {Model}", _settings.Model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to initialize Copilot client and session with project path: {ProjectPath}", projectPath);
            await CleanupResourcesAsync().ConfigureAwait(false);
            throw new InvalidOperationException($"Failed to initialize Copilot service: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Updates the tsp-location.yaml file with the correct Typespec specification path using Copilot analysis.
    /// </summary>
    /// <param name="projectPath">The path to the project directory.</param>
    /// <param name="repoName">Repository name to find the service path for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <exception cref="InvalidOperationException">Thrown when Copilot is not initialized.</exception>
    /// <exception cref="ObjectDisposedException">Thrown when the service has been disposed.</exception>
    public async Task UpdateTspLocationFileAsync(string projectPath, string repoName, CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

        if (!_isInitialized)
        {
            var message = "Copilot client and session must be initialized before getting specification path";
            _logger.LogError(message);
            throw new InvalidOperationException(message);
        }

        if (string.IsNullOrEmpty(repoName))
        {
            _logger.LogWarning("Repository name is null or empty, cannot update tsp-location.yaml");
            return;
        }

        _logger.LogDebug("Requesting Copilot to update tsp-location.yaml for repository: {RepoName}", repoName);

        var prompt = CopilotPrompts.TypespecPathAnalysisPrompt(projectPath, repoName);
        var result = await SendPromptAndGetResponseAsync(prompt, cancellationToken).ConfigureAwait(false);

        _logger.LogDebug("Copilot has been asked to update tsp-location.yaml: {Response}", result);
    }

    /// <summary>
    /// Sends a prompt to Copilot and waits for the complete response.
    /// </summary>
    /// <param name="prompt">The prompt to send.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The response from Copilot, or null if no response received.</returns>
    private async Task<string?> SendPromptAndGetResponseAsync(string prompt, CancellationToken cancellationToken)
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

        var session = _session;
        if (session == null)
        {
            throw new InvalidOperationException("Session is not initialized");
        }
        var responseBuilder = new StringBuilder();
        var completionTcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        // Subscribe to events for this request only
        using var subscription = session.On(evt =>
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
            var messageId = await session.SendAsync(new MessageOptions { Prompt = prompt }).ConfigureAwait(false);
            _logger.LogDebug("Sent message to Copilot with ID: {MessageId}", messageId);

            var timeout = _settings.DefaultTimeout;
            using var timeoutCts = new CancellationTokenSource(timeout);
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
            _logger.LogWarning("Copilot prompt timed out after {Timeout}", _settings.DefaultTimeout);
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
        if (_isDisposed)
        {
            return;
        }

        _isDisposed = true;
        await CleanupResourcesAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Helper method to clean up resources during initialization failures or disposal.
    /// </summary>
    private async Task CleanupResourcesAsync()
    {
        var session = _session;
        var client = _client;

        // Clear state first
        _session = null;
        _client = null;
        _isInitialized = false;

        try
        {
            if (session != null)
            {
                _logger.LogInformation("Disposing Copilot session");
                await session.DisposeAsync().ConfigureAwait(false);
            }

            if (client != null)
            {
                _logger.LogInformation("Stopping and disposing Copilot client");
                await client.StopAsync().ConfigureAwait(false);
                await client.DisposeAsync().ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error occurred while cleaning up Copilot resources");
        }
    }
}
