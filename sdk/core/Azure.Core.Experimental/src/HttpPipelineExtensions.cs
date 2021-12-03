// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;

namespace Azure.Core.Experimental
{
    /// <summary>
    /// </summary>
    public static class HttpPipelineExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static HttpMessage CreateMessage(this HttpPipeline pipeline, RequestOptions options)
        {
            return pipeline.CreateMessage(options);
        }
    }
}
