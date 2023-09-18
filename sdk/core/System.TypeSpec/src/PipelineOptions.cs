// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class PipelineOptions // base of ClientOptions and RequestContext
{
    internal List<(PipelinePolicy, PipelinePosition)> policies = new List<(PipelinePolicy, PipelinePosition)>();
    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="policy"></param>
    /// <param name="position"></param>
    public void AddPolicy(PipelinePolicy policy, PipelinePosition position)
    {
        policies.Add((policy, position));
    }

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
