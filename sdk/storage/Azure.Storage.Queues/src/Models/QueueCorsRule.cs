// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueCorsRule.
    /// </summary>
    [CodeGenModel("CorsRule")]
    public partial class QueueCorsRule
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public QueueCorsRule() { }

        internal QueueCorsRule(
            string allowedOrigins,
            string allowedMethods,
            string allowedHeaders,
            string exposedHeaders,
            int maxAgeInSeconds)
        {
            AllowedOrigins = allowedOrigins;
            AllowedMethods = allowedMethods;
            AllowedHeaders = allowedHeaders;
            ExposedHeaders = exposedHeaders;
            MaxAgeInSeconds = maxAgeInSeconds;
        }
    }
}
