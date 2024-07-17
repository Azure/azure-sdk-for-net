// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments
public abstract class OperationResult : ClientResult
{
    // TODO: Should it take pipeline response or delay the first call?
    // Note: for streaming operations, we want to defer retrieving the response
    // stream until the operation is started, so that the streaming convenience
    // return types don't have to implement IDiposable. Given this, provide
    // both constructors.

    protected OperationResult() : base()
    {
    }

    protected OperationResult(PipelineResponse response)
        : base(response)
    {
    }

    // Note: this is nullable because streaming LROs must read the stream to
    // obtain the values (ids) needed to create the token.  This can't be done
    // e.g. in the case of a protocol method return type, and must be done after
    // a user begins reading the stream in convenience LRO types.
    // Note: if we make it abstract, then an implementation that doesn't support
    // rehydration doesn't need a backing field for it.
    public abstract ContinuationToken? RehydrationToken { get; protected set; }

    // Note: Don't provide this on the base type per not being able to support
    // it from SSE, since the client isn't able to stop the stream, I don't think.
    // Note: adding this back since current plan is for OAI streaming types to
    // inherit from polling LRO types - we will prevent rehydration of the
    // streaming LRO types by not providing a method on the client that takes
    // a rehydration token.
    // Open question: can we make this work for protocol methods?
    // Note: in OAI, we don't get the run ID until we read the first message off
    // the SSE stream.  So, let's not add it here - clients can generate it.
    //public ContinuationToken RehydrationToken { get; protected set; }

    // Note: OAI LROs can stop before completing, and user needs to resume them somehow.
    public abstract bool IsCompleted { get; protected set; }

    // Idea to make this abstract so that streaming implementations can decide
    // whether to query data in the reponse or keep a boolean backing field.
    // Issue: the stream being empty doesn't always indicate the operation has
    // completed.
    //public abstract bool IsCompleted { get; protected set; }

    // Idea to provide these on the base type is to support having a collection
    // of heterogenous operations and wait for all of them to complete in a
    // Task.WaitAll type API, without having to manually check HasCompleted on
    // each.  It would require subtype constructors to take any relevant
    // information about polling intervals, cancellation tokens, etc, or just
    // say if you want to configure that you need to call the subtype directly.

    // TODO: use Core methods/Template pattern instead?
    public abstract Task WaitAsync(CancellationToken cancellationToken = default);
    public abstract void Wait(CancellationToken cancellationToken = default);

    // Returns false if operation has completed, or if continuing to poll for updates
    // would cause an infinite loop.  "CanContinue"/"Has more updates" -> can MoveNext
    // in the conceptual update stream.

    //// TODO: Can we make this less desireable to call?
    //// One idea is to actually expose an API to get the update enumerator.
    //public abstract Task<bool> UpdateAsync(CancellationToken cancellationToken = default);
    //public abstract bool Update(CancellationToken cancellationToken = default);

    // TODO: Consider providing an abstract UpdateStatus and UpdateStatusAsync
    // operation.  This would formalize the idea of having a stream of updates
    // as a universal OperationResult concept, and that they can be applied to
    // create public properties of the subtype such as Value and Status.

    //public abstract Task StartAsync();
    //public abstract void Start();
}
#pragma warning restore CS1591 // public XML comments
