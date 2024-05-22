// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class ClientOperation<T> : ClientOperation
{
    protected ClientOperation(string id) : base(id)
    {
    }

    public T? Value { get; protected set; }

    public abstract Task<ClientResult<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default);

    public abstract ClientResult<T> WaitForCompletion(CancellationToken cancellationToken = default);

    public abstract Task<ClientResult<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken);

    public abstract ClientResult<T> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken);
}
#pragma warning restore CS1591 // public XML comments
