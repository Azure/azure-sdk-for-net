// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments
public abstract class OperationResult : ClientResult
{
    // TODO: Should it take pipeline response or delay the first call?
    protected OperationResult(ContinuationToken rehydrationToken, PipelineResponse response)
        : base(response)
    {
        RehydrationToken = rehydrationToken;
    }

    public ContinuationToken RehydrationToken { get; protected set; }
    public bool HasCompleted {  get; protected set; }
}
#pragma warning restore CS1591 // public XML comments
