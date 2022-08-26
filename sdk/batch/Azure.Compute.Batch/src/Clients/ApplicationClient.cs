// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Compute.Batch
{
    public class ApplicationClient : SubClient
    {
        private ApplicationRest applicationRest;

        protected ApplicationClient() { }

        internal ApplicationClient(BatchServiceClient serviceClient)
        {
            applicationRest = serviceClient.batchRest.GetApplicationRestClient(serviceClient.BatchUrl.AbsoluteUri);
        }
    }
}
