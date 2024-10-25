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
    public CancellationToken CancellationToken { get; set; }
}
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
