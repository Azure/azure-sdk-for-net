// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.Core.Tasks.Providers;

/// <summary>
/// Selects the task store implementation for the current environment: the
/// filesystem-backed <see cref="LocalTaskStore"/> for local development, or the hosted
/// Foundry task storage provider only when running hosted <b>and</b> the hosted Task
/// Storage API is explicitly enabled via <c>FOUNDRY_TASK_API_ENABLED</c> (the API is not
/// yet GA, so it is opt-in — mirrors the Python SDK). When hosted but the flag is unset,
/// the local store is used. The local store is behavior-compatible with the hosted service
/// so the same code paths and tests run without a live backend (FR-019a).
/// </summary>
internal static class TaskStoreSelector
{
    /// <summary>
    /// Creates the appropriate <see cref="ITaskStore"/> for the current environment.
    /// </summary>
    /// <param name="hostedFactory">
    /// A factory that builds the hosted store; invoked only when running hosted with the hosted
    /// Task Storage API enabled. When <see langword="null"/> in that case, an
    /// <see cref="InvalidOperationException"/> is thrown (the hosted provider is wired in by the
    /// registration extension).
    /// </param>
    /// <returns>The selected task store.</returns>
    public static ITaskStore Create(Func<ITaskStore>? hostedFactory = null)
    {
        // Hosted Task Storage API is opt-in (not yet GA): only used when hosted AND
        // FOUNDRY_TASK_API_ENABLED is set. Otherwise fall back to the local file-backed store even
        // in a hosted environment, so recovery still runs against a usable store at startup.
        if (FoundryEnvironment.IsTaskApiEnabled)
        {
            if (hostedFactory is null)
            {
                throw new InvalidOperationException(
                    "A hosted task store factory must be supplied when the hosted Task Storage API is enabled.");
            }

            return hostedFactory();
        }

        return new LocalTaskStore();
    }
}
