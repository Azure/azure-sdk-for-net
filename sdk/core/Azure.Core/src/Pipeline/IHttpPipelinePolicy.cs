// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core;
using System;

namespace Azure.Core.Pipeline;

/// <summary>
/// TBD.
/// </summary>
public interface IHttpPipelinePolicy
{
    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="pipeline"></param>
    /// <returns></returns>
    public abstract ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="pipeline"></param>
    public abstract void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);
}
