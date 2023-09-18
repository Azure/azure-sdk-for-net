// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class LoggingPolicy : PipelinePolicy
{
    private bool _enabled;

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="isLoggingEnabled"></param>
    public LoggingPolicy(bool isLoggingEnabled = true)
    {
        _enabled = isLoggingEnabled;
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="pipeline"></param>
    /// <exception cref="NotImplementedException"></exception>
    public override void Process(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="pipeline"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override ValueTask ProcessAsync(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline)
    {
        throw new NotImplementedException();
    }
}