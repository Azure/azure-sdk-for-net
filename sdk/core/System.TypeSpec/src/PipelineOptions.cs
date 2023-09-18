// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class PipelineOptions // base of ClientOptions and RequestContext
{
    /// <summary>
    /// TBD.
    /// </summary>
    public CancellationToken CancellationToken { get; set; }

    /// <summary>
    /// TBD.
    /// </summary>
    public PipelinePolicy? RetryPolicy { get; set; }

    /// <summary>
    /// TBD.
    /// </summary>
    public PipelinePolicy? LoggingPolicy { get; set; }
}
