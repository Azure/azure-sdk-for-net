// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives.TwoWayClient;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class WebSocketClientMessage : TwoWayPipelineClientMessage
{
    // TODO: should this be on the base type?
    public bool? IsLastFragment { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
