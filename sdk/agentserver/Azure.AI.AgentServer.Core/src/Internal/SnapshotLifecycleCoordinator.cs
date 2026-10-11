// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Internal;

internal enum AfterRestoreResult
{
    Success,
    SessionMismatch,
}

internal sealed class SnapshotLifecycleCoordinator
{
    private const string SessionIdEnvironmentVariable = "FOUNDRY_AGENT_SESSION_ID";

    private readonly IAgentSnapshotLifecycle _lifecycle;
    private readonly IHostApplicationLifetime _applicationLifetime;
    private readonly ILogger<SnapshotLifecycleCoordinator> _logger;
    private readonly SemaphoreSlim _gate = new(1, 1);
    private readonly Dictionary<string, string?> _capturedEnvironmentValues = new(EnvironmentVariableNames.Comparer);
    private readonly HashSet<string> _completedRestoreIds = new(StringComparer.Ordinal);
    private HashSet<string> _appliedEnvironmentVariables = new(EnvironmentVariableNames.Comparer);
    private bool _beforeSnapshotCompleted;
    private bool _environmentBaselineCaptured;
    private string? _sessionId;

    public SnapshotLifecycleCoordinator(
        IAgentSnapshotLifecycle lifecycle,
        IHostApplicationLifetime applicationLifetime,
        ILogger<SnapshotLifecycleCoordinator> logger)
    {
        _lifecycle = lifecycle;
        _applicationLifetime = applicationLifetime;
        _logger = logger;
    }

    public async Task BeforeSnapshotAsync()
    {
        var cancellationToken = _applicationLifetime.ApplicationStopping;
        await _gate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_beforeSnapshotCompleted)
            {
                return;
            }

            await _lifecycle.BeforeSnapshotAsync(cancellationToken).ConfigureAwait(false);
            _beforeSnapshotCompleted = true;
        }
        catch (Exception exception) when (exception is not OperationCanceledException)
        {
            _logger.LogError(exception, "The before-snapshot lifecycle hook failed.");
            throw;
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task<AfterRestoreResult> AfterRestoreAsync(AgentRestoreContext context)
    {
        var cancellationToken = _applicationLifetime.ApplicationStopping;
        await _gate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_sessionId is not null)
            {
                if (!string.Equals(_sessionId, context.SessionId, StringComparison.Ordinal))
                {
                    return AfterRestoreResult.SessionMismatch;
                }

                if (_completedRestoreIds.Contains(context.RestoreId))
                {
                    return AfterRestoreResult.Success;
                }
            }

            CaptureEnvironmentBaseline();
            ApplyEnvironmentOverrides(context.SessionId, context.SessionEnvironmentOverrides);
            _sessionId ??= context.SessionId;

            var currentRequestContext = FoundryAgentRequestContext.Current;
            var previousRequestContext = FoundryAgentRequestContext.Exchange(new FoundryAgentRequestContext
            {
                CallId = currentRequestContext.CallId,
                UserId = currentRequestContext.UserId,
                SessionId = context.SessionId,
            });
            try
            {
                await _lifecycle.AfterRestoreAsync(context, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                FoundryAgentRequestContext.Exchange(previousRequestContext);
            }

            _completedRestoreIds.Add(context.RestoreId);
            return AfterRestoreResult.Success;
        }
        catch (Exception exception) when (exception is not OperationCanceledException)
        {
            _logger.LogError(exception, "The after-restore lifecycle hook failed.");
            throw;
        }
        finally
        {
            _gate.Release();
        }
    }

    private void CaptureEnvironmentBaseline()
    {
        if (_environmentBaselineCaptured)
        {
            return;
        }

        foreach (DictionaryEntry variable in Environment.GetEnvironmentVariables())
        {
            _capturedEnvironmentValues.Add((string)variable.Key, (string?)variable.Value);
        }

        _environmentBaselineCaptured = true;
    }

    private void ApplyEnvironmentOverrides(
        string sessionId,
        IReadOnlyDictionary<string, string> overrides)
    {
        var effectiveOverrides = new Dictionary<string, string>(
            overrides,
            EnvironmentVariableNames.Comparer)
        {
            [SessionIdEnvironmentVariable] = sessionId,
        };

        var updatedVariables = new HashSet<string>(
            _appliedEnvironmentVariables,
            EnvironmentVariableNames.Comparer);
        updatedVariables.UnionWith(effectiveOverrides.Keys);

        var previousValues = new Dictionary<string, string?>(
            updatedVariables.Count,
            EnvironmentVariableNames.Comparer);
        try
        {
            foreach (var variable in updatedVariables)
            {
                var previousValue = Environment.GetEnvironmentVariable(variable);
                previousValues.Add(variable, previousValue);

                var value = effectiveOverrides.TryGetValue(variable, out var overrideValue)
                    ? overrideValue
                    : _capturedEnvironmentValues.GetValueOrDefault(variable);
                if (value == string.Empty && Environment.Version.Major < 9)
                {
                    throw new InvalidOperationException(
                        "The current .NET runtime cannot preserve an empty process environment value.");
                }

                Environment.SetEnvironmentVariable(variable, value);
            }

            FoundryEnvironment.Reload();
            _appliedEnvironmentVariables = new HashSet<string>(
                effectiveOverrides.Keys,
                EnvironmentVariableNames.Comparer);
        }
        catch
        {
            foreach (var pair in previousValues)
            {
                Environment.SetEnvironmentVariable(pair.Key, pair.Value);
            }

            FoundryEnvironment.Reload();
            throw;
        }
    }
}
