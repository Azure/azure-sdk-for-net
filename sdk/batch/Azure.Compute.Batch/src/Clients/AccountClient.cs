// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Compute.Batch.Models;
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

        [ForwardsClientCalls]
        public virtual Pageable<ImageInformation> GetSupportedImages(AccountListSupportedImagesOptions options = null)
        {
            Pageable<BinaryData> binaryResult = accountRest.GetSupportedImages(options?.Filter, options?.MaxResults, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate);
            return HandleList(binaryResult, ImageInformation.DeserializeImageInformation);
        }

        [ForwardsClientCalls]
        public virtual AsyncPageable<ImageInformation> GetSupportedImagesAsync(AccountListSupportedImagesOptions options = null)
        {
            AsyncPageable<BinaryData> binaryResult = accountRest.GetSupportedImagesAsync(options?.Filter, options?.MaxResults, options?.Timeout, options?.ClientRequestId, options?.ReturnClientRequestId, options?.OcpDate);
            return HandleListAsync(binaryResult, ImageInformation.DeserializeImageInformation);
        }
    }
}
