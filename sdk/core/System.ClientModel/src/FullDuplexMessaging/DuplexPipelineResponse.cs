﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Text;

// TODO: Do the message types need to be different?
// If the sendable message and the recievable message could be the same message
// type, policy.Process changes to policy.ProcessSend and policy.ProcessReceive

namespace System.ClientModel.Primitives.FullDuplexMessaging;

/// <summary>
/// Data to send via full-duplex pipeline.
/// In WebSockets, a message can be sent across one or more frames.
/// The BCL type has opted not to use the word "frame" in their naming.
/// Client data and service data feels like it reflects the general-
/// purpose concept of either a message or a frame.
///
/// We use the name `Response` to indicate it is service data being
/// received over the full-duplex connection, and to align with SCM
/// naming of an incoming message received by the client.
/// </summary>

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class DuplexPipelineResponse
{
    protected DuplexPipelineResponse() { }

    private ArrayBackedPropertyBag<ulong, object>? _propertyBag;
    private ArrayBackedPropertyBag<ulong, object> PropertyBag => _propertyBag ??= new();

    // TODO: Do we need to support the WS text/binary switch here?
    public BinaryData? Content { get; set; }

    // TODO: would it make sense to have CancellationToken on this message at all?
    // TODO: what governs cancellation when a response is received?

    public void SetProperty(Type key, object? value) =>
        PropertyBag.Set((ulong)key.TypeHandle.Value, value);

    public bool TryGetProperty(Type key, out object? value) =>
        PropertyBag.TryGetValue((ulong)key.TypeHandle.Value, out value);
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
