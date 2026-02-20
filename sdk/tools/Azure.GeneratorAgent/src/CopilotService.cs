// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using GitHub.Copilot.SDK;
using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent;

/// <summary>
/// Service for interacting with GitHub Copilot SDK for Azure SDK migration tasks.
/// Use <see cref="CreateAsync"/> to create a fully initialized instance.
/// </summary>
public sealed class CopilotService : IAsyncDisposable
{
    private readonly ILogger<CopilotService> _logger;
    private readonly AppSettings _settings;
    private readonly CopilotClient _client;
    private readonly CopilotSession _session;
    private bool _isDisposed;

    /// <summary>
    /// Private constructor — use <see cref="CreateAsync"/> instead.
    /// </summary>
    private CopilotService(ILogger<CopilotService> logger, AppSettings settings, CopilotClient client, CopilotSession session)
    {
        _logger = logger;
        _settings = settings;
        _client = client;
        _session = session;
    }

    /// <summary>
    /// Creates a fully initialized <see cref="CopilotService"/> with an active client and session.
    /// </summary>
    public static async Task<CopilotService> CreateAsync(
        string projectPath,
        ILogger<CopilotService> logger,
        AppSettings settings,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(settings);

        if (string.IsNullOrWhiteSpace(projectPath))
        {
            throw new ArgumentException("Project path is required for Copilot initialization", nameof(projectPath));
        }

        CopilotClient? client = null;
        CopilotSession? session = null;

        try
        {
            logger.LogDebug("Initializing Copilot client with project path: {ProjectPath}", projectPath);

            client = new CopilotClient(new CopilotClientOptions
            {
                Cwd = projectPath,
                AutoStart = true,
                LogLevel = settings.LogLevel
            });

            await client.StartAsync().ConfigureAwait(false);
            session = await client.CreateSessionAsync(new SessionConfig
            {
                Model = settings.Model,
                SystemMessage = new SystemMessageConfig
                {
                    Mode = SystemMessageMode.Append,
                    Content = CopilotPrompts.BuildMigrationSystemMessage(projectPath)
                },
                AvailableTools = ["view", "edit", "create", "grep", "glob", "terminal"],
                InfiniteSessions = new InfiniteSessionConfig { Enabled = false },
                Streaming = true
            }).ConfigureAwait(false);

            logger.LogInformation("Copilot service created successfully with model: {Model}", settings.Model);

            return new CopilotService(logger, settings, client, session);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to initialize Copilot service with project path: {ProjectPath}", projectPath);

            try
            {
                if (session != null)
                {
                    await session.DisposeAsync().ConfigureAwait(false);
                }

                if (client != null)
                {
                    await client.StopAsync().ConfigureAwait(false);
                    await client.DisposeAsync().ConfigureAwait(false);
                }
            }
            catch (Exception cleanupEx)
            {
                logger.LogWarning(cleanupEx, "Error during cleanup after failed initialization");
            }

            throw new InvalidOperationException($"Failed to initialize Copilot service: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Uses Copilot to find and update the correct TypeSpec path in tsp-location.yaml.
    /// </summary>
    public async Task UpdateTspLocationFileAsync(string projectPath, string repoName, CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

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

    private async Task<string?> SendPromptAndGetResponseAsync(string prompt, CancellationToken cancellationToken)
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

        var responseBuilder = new StringBuilder();
        var completionTcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        using var subscription = _session.On(evt =>
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

    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        if (_isDisposed)
        {
            return;
        }

        _isDisposed = true;

        try
        {
            await _session.DisposeAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error disposing Copilot session");
        }

        try
        {
            await _client.StopAsync().ConfigureAwait(false);
            await _client.DisposeAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error disposing Copilot client");
        }
    }
}
