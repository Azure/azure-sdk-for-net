// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareCorsRule.
    /// </summary>
    [CodeGenModel("CorsRule")]
    public partial class ShareCorsRule
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ShareCorsRule() { }

        internal ShareCorsRule(
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
