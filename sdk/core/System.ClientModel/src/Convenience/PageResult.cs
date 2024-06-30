// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591
public abstract class PageResult : ClientResult
{
    protected PageResult(
        ContinuationToken pageToken,
        ContinuationToken? nextPageToken, PipelineResponse response) : base(response)
    {
        PageToken = pageToken;
        NextPageToken = nextPageToken;
    }

    // The token used to retrieve this page -- can uniquely request
    // the page AND uniquely rehydrate a page collection that this is
    // a page in (first, page 5, whatever).
    // i.e. it completely describes a collection where this is a page
    // in it.
    // This is useful because I can cache this and retrive both the
    // full collection this page is in and/or the current page.
    public ContinuationToken PageToken { get; }

    // If this is null, the current page is the last page in a collection.
    public ContinuationToken? NextPageToken { get; }

    public PageResult GetNextResult()
    {
        if (NextPageToken is null)
        {
            throw new InvalidOperationException("Cannot get next page result when NextPageToken is null.");
        }

        return GetNextResultCore();
    }

    public async Task<PageResult> GetNextResultAsync()
    {
        if (NextPageToken is null)
        {
            throw new InvalidOperationException("Cannot get next page result when NextPageToken is null.");
        }

        return await GetNextResultAsyncCore().ConfigureAwait(false);
    }

    // Needed in order to be able to retrieve next page via protocol method
    // return value.
    protected abstract PageResult GetNextResultCore();
    protected abstract Task<PageResult> GetNextResultAsyncCore();
}

#pragma warning restore CS1591
