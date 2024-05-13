// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class ClientPage<T> : ResultCollection<T>
{
    // This one only has a constructor that takes a response, because we only
    // have a ClientPage<T> if we have a response
    public ClientPage(PipelineResponse response) : base(response)
    {
    }

    public string? ContinuationToken;
}
#pragma warning restore CS1591 // public XML comments
