// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    internal class BlobLeaseClientTryAcquireLeaseClassifier : ResponseClassificationHandler
    {
        public static bool IsLeaseAlreadyExistsResponse(Response response)
        {
            if (response.Headers.TryGetValue(Constants.HeaderNames.ErrorCode, out string errorCode))
            {
                if (errorCode == BlobErrorCode.LeaseAlreadyPresent)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool TryClassify(HttpMessage message, out bool isError)
        {
            if (IsLeaseAlreadyExistsResponse(message.Response))
            {
                isError = false;
                return true;
            }

            // no classification made
            isError = default;
            return false;
        }
    }
}
