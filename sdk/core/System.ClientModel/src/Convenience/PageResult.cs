// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591
public abstract class PageResult : ClientResult
{
    protected PageResult(bool hasNext, PipelineResponse response) : base(response)
    {
        HasNext = hasNext;
    }

    public bool HasNext { get; }

    public PageResult GetNext()
    {
        if (!HasNext)
        {
            throw new InvalidOperationException("Cannot get next page when 'HasNext' is false.");
        }

        return GetNextCore();
    }

    public async Task<PageResult> GetNextAsync()
    {
        if (!HasNext)
        {
            throw new InvalidOperationException("Cannot get next page when 'HasNext' is false.");
        }

        return await GetNextAsyncCore().ConfigureAwait(false);
    }

    // Needed in order to be able to retrieve next page via protocol method
    // return value.
    protected abstract PageResult GetNextCore();
    protected abstract Task<PageResult> GetNextAsyncCore();
}

#pragma warning restore CS1591
