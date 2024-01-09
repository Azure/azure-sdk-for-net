// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// ErrorBehavior controls the behavior of an operation when an unexpected response status code is received.
/// </summary>
[Flags]
public enum ResponseErrorOptions
{
    /// <summary>
    /// Indicates that an operation should throw an exception when the response indicates a failure.
    /// </summary>
    Default = 0,

    /// <summary>
    /// Indicates that an operation should not throw an exception when the response indicates a failure.
    /// Callers should check the Response.IsError property instead of catching exceptions.
    /// </summary>
    NoThrow = 1,
}
