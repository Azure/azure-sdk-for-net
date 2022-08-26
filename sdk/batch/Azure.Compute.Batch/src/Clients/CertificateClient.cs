// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Compute.Batch
{
    public class CertificateClient : SubClient
    {
        private CertificateRest certificateRest;

        protected CertificateClient() { }

        internal CertificateClient(BatchServiceClient serviceClient)
        {
            certificateRest = serviceClient.batchRest.GetCertificateRestClient(serviceClient.BatchUrl.AbsoluteUri);
        }
    }
}
