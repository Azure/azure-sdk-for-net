// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Encapsulates the data required to persist a newly created response.
/// Passed to <see cref="ResponsesProvider.CreateResponseAsync"/>.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="InputItems"/> and <see cref="HistoryItemIds"/> default to empty
/// collections when <c>null</c> is passed, so implementations can safely iterate
/// without null checks.
/// </para>
/// </remarks>
public sealed class CreateResponseRequest
{
    /// <summary>
    /// Initializes a new instance of <see cref="CreateResponseRequest"/>.
    /// </summary>
    /// <param name="response">The response snapshot to store. Must not be <c>null</c>.</param>
    /// <param name="inputItems">The resolved input items for this response, or <c>null</c> for empty.</param>
    /// <param name="historyItemIds">The resolved history item IDs, or <c>null</c> for empty.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="response"/> is <c>null</c>.</exception>
    public CreateResponseRequest(
        Models.ResponseObject response,
        IEnumerable<OutputItem>? inputItems,
        IEnumerable<string>? historyItemIds)
    {
        Response = response ?? throw new ArgumentNullException(nameof(response));
        InputItems = inputItems ?? Enumerable.Empty<OutputItem>();
        HistoryItemIds = historyItemIds ?? Enumerable.Empty<string>();
    }

    /// <summary>Gets the response snapshot to store.</summary>
    public Models.ResponseObject Response { get; }

    /// <summary>Gets the resolved input items for this response (empty if none).</summary>
    public IEnumerable<OutputItem> InputItems { get; }

    /// <summary>Gets the resolved history item IDs (empty if none).</summary>
    public IEnumerable<string> HistoryItemIds { get; }
}
