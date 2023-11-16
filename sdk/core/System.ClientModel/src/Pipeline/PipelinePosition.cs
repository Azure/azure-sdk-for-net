// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents a position of the policy in the pipeline.
/// </summary>
public enum PipelinePosition
{
    /// <summary>
    /// The policy would be invoked once per pipeline invocation (service call).
    /// </summary>
    PerCall,
    /// <summary>
    /// The policy would be invoked every time request is retried.
    /// </summary>
    PerRetry,
    /// <summary>
    /// The policy would be invoked before the request is sent by the transport.
    /// </summary>
    BeforeTransport,
}
