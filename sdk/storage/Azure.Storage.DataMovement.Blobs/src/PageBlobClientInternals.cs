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
    internal class PageBlobClientInternals : PageBlobClient
    {
        public static PageBlobClient WithAdditionalPoliciesClient(
            PageBlobClient client,
            params HttpPipelineSynchronousPolicy[] policies)
            => PageBlobClient.WithAdditionalPolicies(client, policies);
    }
}
