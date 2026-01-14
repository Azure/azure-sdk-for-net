// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Runtime.User;

/// <summary>
/// Provides user information for tool invocations and request processing.
/// </summary>
public interface IUserProvider
{
    /// <summary>
    /// Gets the current user information for the active request context.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the user information, or null if no user context is available.
    /// </returns>
    Task<UserInfo?> GetUserAsync(CancellationToken cancellationToken = default);
}
