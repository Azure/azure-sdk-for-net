// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Compute.Batch
{
    public class ComputeNodeExtensionClient : SubClient
    {
        private ComputeNodeExtensionRest computeNodeExtensionRest;

        protected ComputeNodeExtensionClient() { }

        internal ComputeNodeExtensionClient(BatchServiceClient serviceClient)
        {
            computeNodeExtensionRest = serviceClient.batchRest.GetComputeNodeExtensionRestClient(serviceClient.BatchUrl.AbsoluteUri);
        }
    }
}
