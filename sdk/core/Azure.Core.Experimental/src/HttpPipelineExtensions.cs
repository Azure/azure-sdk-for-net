// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Extensions to HttpPipeline to support RequestOptions.
    /// </summary>
    public static class HttpPipelineExtensions
    {
        /// <summary>
        /// Creates a new <see cref="HttpMessage"/> instance.
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="options">The message options.</param>
        /// <returns>The message.</returns>
        public static HttpMessage CreateMessage(this HttpPipeline pipeline, RequestOptions? options)
        {
            // TODO: This method will be added as a method on HttpPipeline directly
            // when RequestOptions moves to core. At that time, we expect RequestContext
            // to inherit from RequestOptions, so copying RequestOptions to
            // RequestContext can be removed.

            if (options == null)
            {
                return pipeline.CreateMessage();
            }

            RequestContext context = new RequestContext();

            context.ErrorOptions = options.ErrorOptions;

            if (options.Policies != null)
            {
                foreach (var policy in options.Policies)
                {
                    context.AddPolicy(policy.Policy, policy.Position);
                }
            }

            return pipeline.CreateMessage(context);
        }
    }
}
