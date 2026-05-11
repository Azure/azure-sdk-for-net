// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Provides cancellation signalling for in-flight responses.
/// Extend this class to back cancellation with a custom signalling mechanism
/// (e.g., distributed pub/sub, Redis, message queue).
/// </summary>
/// <remarks>
/// <para>
/// When no custom implementation is registered, the SDK provides an
/// in-memory default that is automatically registered by
/// <c>AddResponsesServer()</c>.
/// </para>
/// </remarks>
public abstract class ResponsesCancellationSignalProvider
{
    /// <summary>
    /// Signals cancellation for an in-flight response.
    /// This method is fire-and-forget safe — it may return before the
    /// handler observes the cancellation.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ResourceNotFoundException">Thrown if the response does not exist.</exception>
    /// <exception cref="BadRequestException">Thrown if the response is already in a terminal state.</exception>
    public abstract Task CancelResponseAsync(
        string responseId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a <see cref="CancellationToken"/> that fires when
    /// <see cref="CancelResponseAsync"/> is called for the given response.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A cancellation token linked to the response's cancellation signal.</returns>
    public abstract Task<CancellationToken> GetResponseCancellationTokenAsync(
        string responseId,
        CancellationToken cancellationToken = default);
}
