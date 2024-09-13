// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel;

internal class PageResult<T> : ClientResult
{
    private PageResult(IReadOnlyList<T> values,
        ContinuationToken pageToken,
        ContinuationToken? nextPageToken,
        PipelineResponse response) : base(response)
    {
        Argument.AssertNotNull(values, nameof(values));
        Argument.AssertNotNull(pageToken, nameof(pageToken));

        Values = values;
        PageToken = pageToken;
        NextPageToken = nextPageToken;
    }

    /// <summary>
    /// Gets the values in this <see cref="PageResult{T}"/>.
    /// </summary>
    public IReadOnlyList<T> Values { get; }

    /// <summary>
    /// Gets a token that can be passed to a client method to obtain a page
    /// collection that begins with this page of values.
    /// </summary>
    /// <remarks><seealso cref="ContinuationToken"/> for more details.</remarks>
    public ContinuationToken PageToken { get; }

    /// <summary>
    /// Gets a token that can be passed to a client method to obtain a page
    /// collection that begins with the page of values after this page. If
    /// <see cref="NextPageToken"/> is null, the current page is the last page
    /// in the page collection.
    /// </summary>
    /// <remarks><seealso cref="ContinuationToken"/> for more details.</remarks>
    public ContinuationToken? NextPageToken { get; }

    /// <summary>
    /// Create a <see cref="PageResult{T}"/> from the provided parameters.
    /// </summary>
    /// <param name="values">The values in the <see cref="PageResult{T}"/>.
    /// </param>
    /// <param name="pageToken">A token that can be used to request a collection
    /// beginning with this page of values.</param>
    /// <param name="nextPageToken">A token that can be used to request a
    /// collection beginning with the next page of values.</param>
    /// <param name="response">The response that returned the values in the
    /// page.</param>
    /// <returns>A <see cref="PageResult{T}"/> holding the provided values.
    /// </returns>
    public static PageResult<T> Create(IReadOnlyList<T> values, ContinuationToken pageToken, ContinuationToken? nextPageToken, PipelineResponse response)
        => new(values, pageToken, nextPageToken, response);
}
