// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Compute.Batch
{
    public class ComputeNodeClient : SubClient
    {
        private ComputeNodeRest computeNodeRest;

        protected ComputeNodeClient() { }

        internal ComputeNodeClient(BatchServiceClient serviceClient)
        {
            computeNodeRest = serviceClient.batchRest.GetComputeNodeRestClient(serviceClient.BatchUrl.AbsoluteUri);
        }
    }
}
