// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Utility;

/// <summary>
/// Represents a collection of values returned from an Azure cloud service operation.
/// </summary>
/// <typeparam name="TItem">The type of items in the collection.</typeparam>
/// <typeparam name="TContinuation">Type of the continuation token.</typeparam>
internal class AzureCollectionResult<TItem, TContinuation> : CollectionResult<TItem> where TContinuation : ContinuationToken
{
    private readonly ClientPipeline _pipeline;
    private readonly Func<TContinuation?, PipelineMessage> _createRequest;
    private readonly Func<ClientResult, TContinuation?> _getContinuationToken;
    private readonly Func<ClientResult, IEnumerable<TItem>> _getValues;
    private readonly CancellationToken _cancellation;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="pipeline">The client pipeline to use to send requests.</param>
    /// <param name="createRequest">The function used to create the request to get a page of results. The continuation token
    /// may be set to null to get the first page. After that it will be set to a value used to get the next page of results.</param>
    /// <param name="getContinuationToken">The function used to create a continuation token from a page of results.</param>
    /// <param name="getValues">The function used to extract results from a page.</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">If any of the required arguments are null.</exception>
    public AzureCollectionResult(
        ClientPipeline pipeline,
        Func<TContinuation?, PipelineMessage> createRequest,
        Func<ClientResult, TContinuation?> getContinuationToken,
        Func<ClientResult, IEnumerable<TItem>> getValues,
        CancellationToken cancellationToken)
    {
        _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
        _createRequest = createRequest ?? throw new ArgumentNullException(nameof(_createRequest));
        _getContinuationToken = getContinuationToken ?? throw new ArgumentNullException(nameof(_getContinuationToken));
        _getValues = getValues ?? throw new ArgumentNullException(nameof(_getContinuationToken));
        _cancellation = cancellationToken;
    }

    /// <inheritdoc />
    public override ContinuationToken? GetContinuationToken(ClientResult page) => _getContinuationToken(page);

    /// <inheritdoc />
    public override IEnumerable<ClientResult> GetRawPages()
    {
        TContinuation? continuation = null;

        do
        {
            ClientResult page = SendRequest(continuation);
            continuation = _getContinuationToken(page);

            yield return page;
        }
        while (continuation != null);
    }

    /// <inheritdoc />
    protected override IEnumerable<TItem> GetValuesFromPage(ClientResult page) => _getValues(page);

    /// <summary>
    /// Sends a request to get the first page of results (<paramref name="continuationToken"/> is null),
    /// or the next page of results (<paramref name="continuationToken"/> has a non-null value).
    /// </summary>
    /// <param name="continuationToken">The continuation token to use. Will be null when retrieving the first page of results.</param>
    /// <returns>The result containing the page of results.</returns>
    protected virtual ClientResult SendRequest(TContinuation? continuationToken)
    {
        using PipelineMessage message = _createRequest(continuationToken);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, _cancellation.ToRequestOptions()));
    }
}
