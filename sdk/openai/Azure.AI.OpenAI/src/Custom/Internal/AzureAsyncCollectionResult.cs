// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Utility;

/// <summary>
/// Represents a collection of values returned from an asynchronous Azure cloud service operation.
/// </summary>
/// <typeparam name="TItem">The type of items in the collection.</typeparam>
/// <typeparam name="TContinuation">Type of the continuation token.</typeparam>
internal class AzureAsyncCollectionResult<TItem, TContinuation> : AsyncCollectionResult<TItem> where TContinuation : ContinuationToken
{
    private readonly ClientPipeline _pipeline;
    private readonly RequestOptions _options;
    private readonly Func<TContinuation?, PipelineMessage> _createRequest;
    private readonly Func<ClientResult, TContinuation?> _getContinuationToken;
    private readonly Func<ClientResult, IEnumerable<TItem>> _getValues;
    private readonly CancellationToken _cancellation;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="pipeline">The client pipeline to use to send requests.</param>
    /// <param name="options">The request options to use.</param>
    /// <param name="createRequest">The function used to create the request to get a page of results. The continuation token
    /// may be set to null to get the first page. After that it will be set to a value used to get the next page of results.</param>
    /// <param name="getContinuationToken">The function used to create a continuation token from a page of results.</param>
    /// <param name="getValues">The function used to extract results from a page.</param>
    /// <param name="cancellation">The cancellation token to use.</param>
    /// <exception cref="ArgumentNullException">If any of the required arguments are null.</exception>
    public AzureAsyncCollectionResult(
        ClientPipeline pipeline,
        RequestOptions options,
        Func<TContinuation?, PipelineMessage> createRequest,
        Func<ClientResult, TContinuation?> getContinuationToken,
        Func<ClientResult, IEnumerable<TItem>> getValues,
        CancellationToken cancellation)
    {
        _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
        _options = options ?? new();
        _getContinuationToken = getContinuationToken ?? throw new ArgumentNullException(nameof(_getContinuationToken));
        _createRequest = createRequest ?? throw new ArgumentNullException(nameof(_createRequest));
        _getValues = getValues ?? throw new ArgumentNullException(nameof(_getContinuationToken));
        _cancellation = cancellation;
    }

    /// <inheritdoc />
    public override ContinuationToken? GetContinuationToken(ClientResult page) => _getContinuationToken(page);

    /// <inheritdoc />
    public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        TContinuation? continuation = null;
        do
        {
            ClientResult page = await SendRequestAsync(continuation).ConfigureAwait(false);
            continuation = _getContinuationToken(page);

            yield return page;
        } while (continuation != null);
    }

    /// <inheritdoc />
    protected override IAsyncEnumerable<TItem> GetValuesFromPageAsync(ClientResult page)
        => _getValues(page).ToAsyncEnumerable(_cancellation);

    /// <summary>
    /// Sends a request to get the first page of results (<paramref name="continuationToken"/> is null),
    /// or the next page of results (<paramref name="continuationToken"/> has a non-null value).
    /// </summary>
    /// <param name="continuationToken">The continuation token to use. Will be null when retrieving the first page of results.</param>
    /// <returns>The result containing the page of results.</returns>
    protected virtual async Task<ClientResult> SendRequestAsync(TContinuation? continuationToken)
    {
        using PipelineMessage message = _createRequest(continuationToken);
        PipelineResponse response = await _pipeline.ProcessMessageAsync(message, _options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }
}
