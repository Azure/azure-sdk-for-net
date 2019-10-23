// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    /// <summary>
    /// Represents a position of the policy in the pipeline.
    /// </summary>
    public enum HttpPipelinePosition
    {
        /// <summary>
        /// The policy would be invoked once per pipeline invocation (service call).
        /// </summary>
        PerCall,
        /// <summary>
        /// The policy would be invoked every time request is retried.
        /// </summary>
        PerRetry
    }
}
