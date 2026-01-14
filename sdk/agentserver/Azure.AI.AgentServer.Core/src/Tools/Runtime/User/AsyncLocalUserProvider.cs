// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Runtime.User;

/// <summary>
/// User provider that retrieves user information from AsyncLocal storage.
/// This provides thread-safe, async-flow-aware access to user context.
/// </summary>
public class AsyncLocalUserProvider : IUserProvider
{
    private static readonly AsyncLocal<UserInfo?> _userInfo = new();

    /// <summary>
    /// Gets the current user information from AsyncLocal storage.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the user information, or null if no user context has been set.
    /// </returns>
    public Task<UserInfo?> GetUserAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_userInfo.Value);
    }

    /// <summary>
    /// Gets the current user information synchronously from AsyncLocal storage.
    /// </summary>
    public static UserInfo? Current => _userInfo.Value;

    /// <summary>
    /// Sets the user information in AsyncLocal storage for the current async flow.
    /// Returns a scope that restores the previous user when disposed.
    /// </summary>
    /// <param name="user">The user information to set, or null to clear the user context.</param>
    /// <returns>An IAsyncDisposable that restores the previous user when disposed.</returns>
    internal static IAsyncDisposable SetUser(UserInfo? user)
    {
        var previous = _userInfo.Value;
        _userInfo.Value = user;
        return new UserScope(previous);
    }

    private sealed class UserScope : IAsyncDisposable
    {
        private readonly UserInfo? _previousUser;

        public UserScope(UserInfo? previousUser)
        {
            _previousUser = previousUser;
        }

        public ValueTask DisposeAsync()
        {
            _userInfo.Value = _previousUser;
            return ValueTask.CompletedTask;
        }
    }
}
