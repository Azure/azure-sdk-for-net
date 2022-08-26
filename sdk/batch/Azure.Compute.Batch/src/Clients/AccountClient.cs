// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Compute.Batch
{
    public class AccountClient : SubClient
    {
        private AccountRest accountRest;

        protected AccountClient() { }

        internal AccountClient(BatchServiceClient serviceClient)
        {
            accountRest = serviceClient.batchRest.GetAccountRestClient(serviceClient.BatchUrl.AbsoluteUri);
        }
    }
}
