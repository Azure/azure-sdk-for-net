// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Compute.Batch
{
    public class FileClient : SubClient
    {
        private FileRest fileRest;

        protected FileClient() { }

        internal FileClient(BatchServiceClient serviceClient)
        {
            fileRest = serviceClient.batchRest.GetFileRestClient(serviceClient.BatchUrl.AbsoluteUri);
        }
    }
}
