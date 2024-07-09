// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        //RehydrationToken = rehydrationToken;
    }

    // Note: Don't provide this on the base type per not being able to support
    // it from SSE, since the client isn't able to stop the stream, I don't think.
    //public ContinuationToken RehydrationToken { get; protected set; }

    // Note: OAI LROs can stop before completing, and user needs to resume them somehow.
    public bool HasCompleted { get; protected set; }

    // Idea to provide these on the base type is to support having a collection
    // of heterogenous operations and wait for all of them to complete in a
    // Task.WaitAll type API, without having to manually check HasCompleted on
    // each.  It would require subtype constructors to take any relevant
    // information about polling intervals, cancellation tokens, etc, or just
    // say if you want to configure that you need to call the subtype directly.
    public abstract Task WaitForCompletionAsync();
    public abstract void WaitForCompletion();
}
#pragma warning restore CS1591 // public XML comments
