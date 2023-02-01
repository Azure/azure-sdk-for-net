// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    internal class BlobBaseClientExistsClassifier : ResponseClassificationHandler
    {
        public static bool IsResourceNotFoundResponse(Response response)
        {
            if (response.Headers.TryGetValue(Constants.HeaderNames.ErrorCode, out string errorCode))
            {
                if (errorCode == BlobErrorCode.BlobNotFound || errorCode == BlobErrorCode.ContainerNotFound)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsUsesCustomerSpecifiedEncryptionResponse(Response response)
        {
            if (response.Headers.TryGetValue(Constants.HeaderNames.ErrorCode, out string errorCode))
            {
                if (errorCode == BlobErrorCode.BlobUsesCustomerSpecifiedEncryption)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool TryClassify(HttpMessage message, out bool isError)
        {
            if (IsResourceNotFoundResponse(message.Response) || IsUsesCustomerSpecifiedEncryptionResponse(message.Response))
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
