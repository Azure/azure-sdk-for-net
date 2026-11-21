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

#pragma warning disable AAAS002 // Internal orchestration of the experimental snapshot lifecycle contract.
internal sealed class SnapshotLifecycleCoordinator
{
    private const string SessionIdEnvironmentVariable = "FOUNDRY_AGENT_SESSION_ID";

    private readonly IAgentSnapshotLifecycle _lifecycle;
    private readonly IReadOnlyList<ISnapshotLifecycleParticipant> _participants;
    private readonly IHostApplicationLifetime _applicationLifetime;
    private readonly ILogger<SnapshotLifecycleCoordinator> _logger;
    private readonly SemaphoreSlim _gate = new(1, 1);
    private readonly Dictionary<string, string?> _capturedEnvironmentValues = new(EnvironmentVariableNames.Comparer);
    private readonly HashSet<string> _completedRestoreIds = new(StringComparer.Ordinal);
    private readonly HashSet<string> _callbackCompletedRestoreIds = new(StringComparer.Ordinal);
    private HashSet<string> _appliedEnvironmentVariables = new(EnvironmentVariableNames.Comparer);
    private bool _beforeSnapshotCompleted;
    private bool _environmentBaselineCaptured;
    private string? _sessionId;
    private EnvironmentRollback? _pendingEnvironmentRollback;
    private int _pendingPreparedParticipantCount;

    public SnapshotLifecycleCoordinator(
        IAgentSnapshotLifecycle lifecycle,
        IEnumerable<ISnapshotLifecycleParticipant> participants,
        IHostApplicationLifetime applicationLifetime,
        ILogger<SnapshotLifecycleCoordinator> logger)
    {
        _lifecycle = lifecycle;
        _participants = participants.ToArray();
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
#pragma warning restore AAAS002

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

                await CompletePendingRollbackAsync(context).ConfigureAwait(false);

                if (_completedRestoreIds.Contains(context.RestoreId))
                {
                    return AfterRestoreResult.Success;
                }
            }

            CaptureEnvironmentBaseline();
            bool transactionalRollback =
                _participants.Any(participant => participant.UsesTransactionalRestore);
            IReadOnlyDictionary<string, string?> prospectiveEnvironment =
                BuildProspectiveEnvironment(
                    context.SessionId,
                    context.SessionEnvironmentOverrides);
            int validatedParticipants = 0;
            try
            {
                foreach (ISnapshotLifecycleParticipant participant in _participants)
                {
                    await participant.ValidateAfterRestoreAsync(
                        context,
                        prospectiveEnvironment,
                        cancellationToken).ConfigureAwait(false);
                    validatedParticipants++;
                }
            }
            catch
            {
                await CancelValidatedParticipantsAsync(validatedParticipants)
                    .ConfigureAwait(false);
                throw;
            }

            EnvironmentRollback rollback;
            try
            {
                rollback = ApplyEnvironmentOverrides(
                    context.SessionId,
                    context.SessionEnvironmentOverrides);
            }
            catch
            {
                await CancelValidatedParticipantsAsync(validatedParticipants)
                    .ConfigureAwait(false);
                throw;
            }

            _pendingEnvironmentRollback = transactionalRollback
                ? rollback
                : null;
            _pendingPreparedParticipantCount = 0;
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
                int preparedParticipants = 0;
                try
                {
                    foreach (ISnapshotLifecycleParticipant participant in _participants)
                    {
                        await participant.PrepareAfterRestoreAsync(context, cancellationToken)
                            .ConfigureAwait(false);
                        preparedParticipants++;
                        _pendingPreparedParticipantCount = preparedParticipants;
                    }

                    if (!_callbackCompletedRestoreIds.Contains(context.RestoreId))
                    {
                        using IDisposable callbackScope = EnterCallbackScope();
                        await _lifecycle.AfterRestoreAsync(context, cancellationToken).ConfigureAwait(false);
                        _callbackCompletedRestoreIds.Add(context.RestoreId);
                    }

                    foreach (ISnapshotLifecycleParticipant participant in _participants)
                    {
                        await participant.CompleteAfterRestoreAsync(context, cancellationToken)
                            .ConfigureAwait(false);
                    }
                }
                catch
                {
                    if (transactionalRollback)
                    {
                        await CompletePendingRollbackAsync(context).ConfigureAwait(false);
                    }

                    throw;
                }
            }
            finally
            {
                FoundryAgentRequestContext.Exchange(previousRequestContext);
            }

            _completedRestoreIds.Add(context.RestoreId);
            _pendingEnvironmentRollback = null;
            _pendingPreparedParticipantCount = 0;
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

    private EnvironmentRollback ApplyEnvironmentOverrides(
        string sessionId,
        IReadOnlyDictionary<string, string> overrides)
    {
        Dictionary<string, string> effectiveOverrides =
            CreateEffectiveOverrides(sessionId, overrides);

        var updatedVariables = new HashSet<string>(
            _appliedEnvironmentVariables,
            EnvironmentVariableNames.Comparer);
        updatedVariables.UnionWith(effectiveOverrides.Keys);

        var previousValues = new Dictionary<string, string?>(
            updatedVariables.Count,
            EnvironmentVariableNames.Comparer);
        var previousAppliedVariables = _appliedEnvironmentVariables;
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
            return new EnvironmentRollback(previousValues, previousAppliedVariables);
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

    private IReadOnlyDictionary<string, string?> BuildProspectiveEnvironment(
        string sessionId,
        IReadOnlyDictionary<string, string> overrides)
    {
        var prospective = new Dictionary<string, string?>(
            EnvironmentVariableNames.Comparer);
        foreach (DictionaryEntry variable in Environment.GetEnvironmentVariables())
        {
            prospective.Add((string)variable.Key, (string?)variable.Value);
        }

        Dictionary<string, string> effectiveOverrides =
            CreateEffectiveOverrides(sessionId, overrides);
        var updatedVariables = new HashSet<string>(
            _appliedEnvironmentVariables,
            EnvironmentVariableNames.Comparer);
        updatedVariables.UnionWith(effectiveOverrides.Keys);
        foreach (string variable in updatedVariables)
        {
            prospective[variable] = effectiveOverrides.TryGetValue(
                variable,
                out string? overrideValue)
                    ? overrideValue
                    : _capturedEnvironmentValues.GetValueOrDefault(variable);
        }

        return prospective;
    }

    private static Dictionary<string, string> CreateEffectiveOverrides(
        string sessionId,
        IReadOnlyDictionary<string, string> overrides)
        => new(overrides, EnvironmentVariableNames.Comparer)
        {
            [SessionIdEnvironmentVariable] = sessionId,
        };

    private IDisposable EnterCallbackScope()
    {
        if (_participants.Count == 0)
        {
            return EmptyScope.Instance;
        }

        var scopes = new IDisposable[_participants.Count];
        for (int i = 0; i < _participants.Count; i++)
        {
            scopes[i] = _participants[i].EnterAfterRestoreCallbackScope();
        }

        return new CompositeScope(scopes);
    }

    private void RestoreEnvironment(EnvironmentRollback rollback)
    {
        foreach (KeyValuePair<string, string?> pair in rollback.Values)
        {
            Environment.SetEnvironmentVariable(pair.Key, pair.Value);
        }

        FoundryEnvironment.Reload();
        _appliedEnvironmentVariables = rollback.AppliedVariables;
    }

    private async Task CompletePendingRollbackAsync(
        AgentRestoreContext context)
    {
        EnvironmentRollback? rollback = _pendingEnvironmentRollback;
        if (rollback is null)
        {
            return;
        }

        for (int i = _pendingPreparedParticipantCount - 1; i >= 0; i--)
        {
            await _participants[i]
                .RollbackAfterRestoreAsync(context, CancellationToken.None)
                .ConfigureAwait(false);
        }

        RestoreEnvironment(rollback);
        _pendingEnvironmentRollback = null;
        _pendingPreparedParticipantCount = 0;
    }

    private async Task CancelValidatedParticipantsAsync(int validatedParticipants)
    {
        for (int i = validatedParticipants - 1; i >= 0; i--)
        {
            await _participants[i]
                .CancelAfterRestoreValidationAsync()
                .ConfigureAwait(false);
        }
    }

    private sealed record EnvironmentRollback(
        IReadOnlyDictionary<string, string?> Values,
        HashSet<string> AppliedVariables);

    private sealed class EmptyScope : IDisposable
    {
        public static EmptyScope Instance { get; } = new();

        public void Dispose()
        {
        }
    }

    private sealed class CompositeScope(IDisposable[] scopes) : IDisposable
    {
        public void Dispose()
        {
            for (int i = scopes.Length - 1; i >= 0; i--)
            {
                scopes[i].Dispose();
            }
        }
    }
}
