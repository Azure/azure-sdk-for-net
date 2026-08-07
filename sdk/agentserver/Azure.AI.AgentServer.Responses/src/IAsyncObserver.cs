// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Provides a mechanism for receiving push-based asynchronous notifications.
/// </summary>
/// <typeparam name="T">The type of the elements received by the observer.</typeparam>
/// <remarks>
/// This interface provides an async-native observer pattern where all notification
/// methods return <see cref="ValueTask"/>. Subscription cancellation is handled
/// via <see cref="IAsyncDisposable"/> rather than <see cref="CancellationToken"/>.
/// </remarks>
[SuppressMessage("Usage", "AZC0112", Justification = "Observer pattern uses IAsyncDisposable for cancellation, not CancellationToken. Adding CancellationToken would break the established async observer contract.")]
public interface IAsyncObserver<in T>
{
    /// <summary>
    /// Provides the observer with new data.
    /// </summary>
    /// <param name="value">The current notification information.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask OnNextAsync(T value);

    /// <summary>
    /// Notifies the observer that the provider has experienced an error condition.
    /// </summary>
    /// <param name="error">An object that provides additional information about the error.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask OnErrorAsync(Exception error);

    /// <summary>
    /// Notifies the observer that the provider has finished sending push-based notifications.
    /// </summary>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask OnCompletedAsync();
}
