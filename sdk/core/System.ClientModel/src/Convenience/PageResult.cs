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

    public PageResult GetNextResult()
    {
        if (!HasNext)
        {
            throw new InvalidOperationException("Cannot get next page result when 'HasNext' is false.");
        }

        return GetNextResultCore();
    }

    public async Task<PageResult> GetNextResultAsync()
    {
        if (!HasNext)
        {
            throw new InvalidOperationException("Cannot get next page result when 'HasNext' is false.");
        }

        return await GetNextResultAsyncCore().ConfigureAwait(false);
    }

    // Needed in order to be able to retrieve next page via protocol method
    // return value.
    protected abstract PageResult GetNextResultCore();
    protected abstract Task<PageResult> GetNextResultAsyncCore();
}

#pragma warning restore CS1591
