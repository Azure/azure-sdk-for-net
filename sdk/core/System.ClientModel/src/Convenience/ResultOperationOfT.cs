// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class ResultOperation<T> : ResultOperation
{
    protected ResultOperation(string id, PipelineResponse response) : base(id, response)
    {
    }

    public T? Value { get; protected set; }

    public abstract Task<ClientResult<T>> WaitForCompletionAsync();

    public abstract ClientResult<T> WaitForCompletion();

    public abstract Task<ClientResult<T>> WaitForCompletionAsync(TimeSpan pollingInterval);

    public abstract ClientResult<T> WaitForCompletion(TimeSpan pollingInterval);
}
#pragma warning restore CS1591 // public XML comments
