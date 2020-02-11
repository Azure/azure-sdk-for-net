// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Blobs.Specialized
{
    internal static class BlobClientOptionsExtensions
    {
        public static BlobClientOptions WithPolicy(
           this BlobClientOptions options,
           HttpPipelinePolicy policy,
           HttpPipelinePosition position = HttpPipelinePosition.PerCall)
        {
            options ??= new BlobClientOptions();
            options.AddPolicy(policy, position);
            return options;
        }
    }
}
