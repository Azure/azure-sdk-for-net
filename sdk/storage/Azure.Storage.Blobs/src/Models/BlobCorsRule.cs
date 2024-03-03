// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobCorsRule.
    /// </summary>
    [CodeGenModel("CorsRule")]
    public partial class BlobCorsRule
    {
        /// <summary>
        /// Creates a new BlobCorsRule instance.
        /// </summary>
        public BlobCorsRule() { }

        internal BlobCorsRule(
            string allowedOrigins,
            string allowedMethods,
            string allowedHeaders,
            string exposedHeaders,
            int maxAgeInSeconds)
        {
            if (allowedOrigins == null)
			{
				throw new ArgumentNullException(nameof(allowedOrigins));
			}
            if (allowedMethods == null)
			{
				throw new ArgumentNullException(nameof(allowedMethods));
			}
            if (allowedHeaders == null)
			{
				throw new ArgumentNullException(nameof(allowedHeaders));
			}
            if (exposedHeaders == null)
			{
				throw new ArgumentNullException(nameof(exposedHeaders));
			}

            AllowedOrigins = allowedOrigins;
            AllowedMethods = allowedMethods;
            AllowedHeaders = allowedHeaders;
            ExposedHeaders = exposedHeaders;
            MaxAgeInSeconds = maxAgeInSeconds;
        }
    }
}
