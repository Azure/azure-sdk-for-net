// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents the subset (or page) of values contained in a single response
/// from a cloud service returning a collection of values sequentially over
/// one or more calls to the service (i.e. a paged collection).
/// </summary>
public class PageResult<T> : ClientResult
{
    private PageResult(IReadOnlyList<T> values, string? continuationToken, PipelineResponse response)
        : base(response)
    {
        Values = values;
        ContinuationToken = continuationToken;
    }

    /// <summary>
    /// Creates a new <see cref="PageResult{T}"/>.
    /// </summary>
    /// <param name="values">The values contained in <paramref name="response"/>.
    /// </param>
    /// <param name="continuationToken">The token that can be used to request
    /// the next page of results from the service, or <c>null</c> if this page
    /// holds the final subset of values.</param>
    /// <param name="response">The <see cref="PipelineResponse"/> holding the
    /// collection values returned by the service.</param>
    /// <returns>An instance of <see cref="PageResult{T}"/> holding the provided
    /// values.</returns>
    public static PageResult<T> Create(IReadOnlyList<T> values, string? continuationToken, PipelineResponse response)
        => new(values, continuationToken, response);

    /// <summary>
    /// Gets the values in this <see cref="PageResult{T}"/>.
    /// </summary>
    public IReadOnlyList<T> Values { get; }

    /// <summary>
    /// Gets the continuation token used to request the next
    /// <see cref="PageResult{T}"/>.  May be <c>null</c> or empty when no values
    /// remain to be returned from the collection.
    /// </summary>
    public string? ContinuationToken { get; }
}
