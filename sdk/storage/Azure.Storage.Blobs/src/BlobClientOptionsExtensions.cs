// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs
{
    internal static class BlobClientOptionsExtensions
    {
        internal static HttpPipelinePolicy AsPolicy(this TokenCredential credential, BlobClientOptions options)
        {
            if (options?.StorageAudience != null)
            {
                string scope;

                if (options.StorageAudience.Equals(StorageAudience.Storage))
                {
                    scope = Constants.StorageScope;
                }
                else if (options.StorageAudience.Equals(StorageAudience.DiskCompute))
                {
                    scope = Constants.DiskComputeScope;
                }
                else
                {
                    throw new ArgumentException($"Unknown StorageAudience value: {options.StorageAudience.ToString()}");
                }

                return new StorageBearerTokenChallengeAuthorizationPolicy(
                    credential ?? throw Errors.ArgumentNull(nameof(credential)),
                    scope,
                    options is ISupportsTenantIdChallenges { EnableTenantDiscovery: true });
            }
            else
            {
                return StorageClientOptions.AsPolicy(credential, options);
            }
        }
    }
}
