// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// ClientErrorBehaviors controls the behavior of a service method when an unexpected
/// response status code is received.
/// </summary>
[Flags]
public enum ClientErrorBehaviors
{
    /// <summary>
    /// The client will throw an exception from a service method if the service
    /// returns an error response.
    /// </summary>
    Default = 0,

    /// <summary>
    /// The client will not throw an exception from a service method if the service
    /// returns an error response. Callers of the service method must check the
    /// Response.IsError property before accessing the response content.
    /// </summary>
    NoThrow = 1,
}
