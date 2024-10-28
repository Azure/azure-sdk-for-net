// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ClientModel.Primitives.TwoWayClient;

/// <summary>
/// This is the equivalent of RequestOptions for HTTP requests
/// </summary>
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class TwoWayMessageOptions
{
    // TODO: freezing
    // TODO: Error options?
    // TODO: Policies for the two-way pipeline?
    // TODO: method to apply options to ClientMessage?

    public CancellationToken CancellationToken { get; set; }

    public bool? IsLastFragment {  get; set; }

    // TODO: content type?
    // Other message-specific metadata (on RequestOptions we have AddHeader)
}
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
