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

    // Needed in order to be able to retrieve next page via protocol method
    // return value.
    public abstract PageResult GetNext();
    public abstract Task<PageResult> GetNextAsync();
}

#pragma warning restore CS1591
