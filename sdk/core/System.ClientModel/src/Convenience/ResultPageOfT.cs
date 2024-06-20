// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel;

/// <summary>
/// Represents the subset (or page) of results contained in a single response
/// from a cloud service returning a collection of results sequentially over
/// one or more calls to the service (i.e. a paged collection).
/// </summary>
public class ResultPage<T> : ResultCollection<T>
{
    private readonly IEnumerable<T> _values;

    private ResultPage(IEnumerable<T> values, string? continuationToken, PipelineResponse response)
        : base(response)
    {
        _values = values;
        ContinuationToken = continuationToken;
    }

    /// <summary>
    /// Creates a new <see cref="ResultPage{T}"/>.
    /// </summary>
    /// <param name="values">The values contained in <paramref name="response"/>.
    /// </param>
    /// <param name="continuationToken">The token that can be used to request
    /// the next page of results from the service, or <c>null</c> if this page
    /// holds the final subset of values.</param>
    /// <param name="response">The <see cref="PipelineResponse"/> holding the
    /// collection values returned by the service.</param>
    /// <returns>An instance of <see cref="ResultPage{T}"/> holding the provided
    /// values.</returns>
    public static ResultPage<T> Create(IEnumerable<T> values, string? continuationToken, PipelineResponse response)
        => new(values, continuationToken, response);

    /// <summary>
    /// Gets the continuation token used to request the next
    /// <see cref="ResultPage{T}"/>.  May be <c>null</c> or empty when no values
    /// remain to be returned from the collection.
    /// </summary>
    public string? ContinuationToken { get; }

    /// <inheritdoc/>
    public override IEnumerator<T> GetEnumerator()
        => _values.GetEnumerator();
}
