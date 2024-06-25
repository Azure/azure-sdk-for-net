// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class ResultValueOperation : ClientResult
{
    protected ResultValueOperation(BinaryData rehydrationToken, PipelineResponse response)
        : base(response)
    {
        RehydrationToken = rehydrationToken;
    }

    public BinaryData RehydrationToken { get; protected set; }
    public bool HasCompleted {  get; protected set; }
}
#pragma warning restore CS1591 // public XML comments
