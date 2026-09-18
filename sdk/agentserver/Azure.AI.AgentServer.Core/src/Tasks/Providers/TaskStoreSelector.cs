// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.Core.Tasks.Providers;

/// <summary>
/// Selects the task store implementation for the current environment: the
/// filesystem-backed <see cref="LocalTaskStore"/> for local development (when
/// <c>FOUNDRY_HOSTING_ENVIRONMENT</c> is absent/empty), or the hosted Foundry task
/// storage provider when running in a hosted environment. The local store is
/// behavior-compatible with the hosted service so the same code paths and tests
/// run without a live backend (FR-019a).
/// </summary>
internal static class TaskStoreSelector
{
    /// <summary>
    /// Creates the appropriate <see cref="ITaskStore"/> for the current environment.
    /// </summary>
    /// <param name="hostedFactory">
    /// A factory that builds the hosted store; invoked only when running hosted. When
    /// <see langword="null"/> in a hosted environment, an <see cref="InvalidOperationException"/>
    /// is thrown (the hosted provider is wired in by the registration extension).
    /// </param>
    /// <returns>The selected task store.</returns>
    public static ITaskStore Create(Func<ITaskStore>? hostedFactory = null)
    {
        if (FoundryEnvironment.IsHosted)
        {
            if (hostedFactory is null)
            {
                throw new InvalidOperationException(
                    "A hosted task store factory must be supplied when running in a Foundry hosting environment.");
            }

            return hostedFactory();
        }

        return new LocalTaskStore();
    }
}
