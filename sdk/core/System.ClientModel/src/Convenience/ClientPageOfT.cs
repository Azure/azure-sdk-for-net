// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents the subset (or page) of values contained in a single response
/// from a cloud service returning a collection of values sequentially over
/// one or more calls to the service (i.e. a paged collection).
/// </summary>
public class ClientPage<T> : ClientResult
{
    /// <summary>
    /// TBD.
    /// </summary>
    public const string DefaultFirstPageToken = "";

    private ClientPage(IReadOnlyList<T> values,
        PipelineResponse response,
        string pageToken,
        string? nextPageToken,
        string? previousPageToken)
        : base(response)
    {
        Values = values;
        PageToken = pageToken;
        NextPageToken = nextPageToken;
        PreviousPageToken = previousPageToken;
    }

    /// <summary>
    /// Creates a new <see cref="ClientPage{T}"/>.
    /// </summary>
    /// <param name="values">The values contained in <paramref name="response"/>.
    /// </param>
    /// <param name="pageToken">The token that was used to request the current
    /// page of values.</param>
    /// <param name="nextPageToken">A token that can be used to request
    /// the next page of results from the service, or <c>null</c> if this page
    /// holds the final subset of values.</param>
    /// <param name="previousPageToken">A token that can be used to request
    /// the previous page of results from the service, or <c>null</c> if this page
    /// holds the final subset of values. May also be left unspecified if the
    /// service does not provide such a token.</param>
    /// <param name="response">The <see cref="PipelineResponse"/> holding the
    /// collection values returned by the service.</param>
    /// <returns>An instance of <see cref="ClientPage{T}"/> holding the provided
    /// values.</returns>
    public static ClientPage<T> Create(IReadOnlyList<T> values,
        PipelineResponse response,
        string pageToken,
        string? nextPageToken,
        string? previousPageToken = default)
        => new(values, response, pageToken, nextPageToken, previousPageToken);

    /// <summary>
    /// Gets the values in this <see cref="ClientPage{T}"/>.
    /// </summary>
    public IReadOnlyList<T> Values { get; }

    /// <summary>
    /// Gets a token that can be used to request the next page of results from
    /// a <see cref="PageableResult{T}"/>, <see cref="AsyncPageableResult{T}"/>,
    /// or a client method that returns one of these types.
    /// May be <c>null</c> or empty when no values remain to be returned from
    /// the collection.
    /// </summary>
    public string? NextPageToken { get; }

    /// <summary>
    /// TBD.
    /// </summary>
    public string PageToken { get; }

    /// <summary>
    /// Gets a token that can be used to request the previous page of results
    /// from a <see cref="PageableResult{T}"/>,
    /// <see cref="AsyncPageableResult{T}"/>, or a client method that returns
    /// one of these types.
    /// May be <c>null</c> when no page preceeds the current page, or when no
    /// token is available for the previous page.
    /// </summary>
    public string? PreviousPageToken { get; }
}
