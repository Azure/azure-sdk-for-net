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

    protected OperationResult(ClientPipeline pipeline) : base()
    {
        Pipeline = pipeline;
    }

    protected OperationResult(ClientPipeline pipeline, PipelineResponse response)
        : base(response)
    {
        Pipeline = pipeline;
    }

    protected ClientPipeline Pipeline { get; }

    // Note: Don't provide this on the base type per not being able to support
    // it from SSE, since the client isn't able to stop the stream, I don't think.
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
    public abstract Task WaitAsync(CancellationToken cancellationToken = default);
    public abstract void Wait(CancellationToken cancellationToken = default);

    // TODO: Consider providing an abstract UpdateStatus and UpdateStatusAsync
    // operation.  This would formalize the idea of having a stream of updates
    // as a universal OperationResult concept, and that they can be applied to
    // create public properties of the subtype such as Value and Status.

    //public abstract Task StartAsync();
    //public abstract void Start();
}
#pragma warning restore CS1591 // public XML comments
