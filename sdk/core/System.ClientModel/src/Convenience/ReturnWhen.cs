// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

/// <summary>
/// Indicates whether a client method that starts a long-running operation
/// should return after the operation has started or after the service has
/// completed processing of the operation.
/// </summary>
public enum ReturnWhen
{
    /// <summary>
    /// Indicates the client method should wait to return until the service has
    /// completed processing of the operation.
    /// </summary>
    /// <remarks>When <see cref="Completed"/> is passed to a client method that
    /// creates an <see cref="OperationResult"/>, the returned operation type's
    /// <see cref="OperationResult.IsCompleted"/> property is <c>true</c>.  If
    /// the operation computed a value and completed successfully, its
    /// <c>Value</c> property will contain the result.</remarks>
    Completed,

    /// <summary>
    /// Indicates the client method should return after the service has responded
    /// to the request to start the operation.
    /// </summary>
    /// <remarks>When <see cref="Started"/> is passed to a client method that
    /// creates an <see cref="OperationResult"/>, the caller must use
    /// <see cref="OperationResult.WaitForCompletion"/> or other method to wait
    /// for the operation to complete before being able to obtain the result of
    /// the service operation.</remarks>
    Started
}
