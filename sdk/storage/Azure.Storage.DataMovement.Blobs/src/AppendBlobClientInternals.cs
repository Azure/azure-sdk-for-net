// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class AppendBlobClientInternals : AppendBlobClient
    {
        public static AppendBlobClient WithAdditionalPoliciesClient(
            AppendBlobClient client,
            params HttpPipelineSynchronousPolicy[] policies)
            => AppendBlobClient.WithAdditionalPolicies(client, policies);
    }
}
