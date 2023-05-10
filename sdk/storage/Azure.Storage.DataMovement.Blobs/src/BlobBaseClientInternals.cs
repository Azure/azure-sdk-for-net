// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobBaseClientInternals : BlobBaseClient
    {
        public static new TokenCredential GetTokenCredential(BlobBaseClient client)
            => BlobBaseClient.GetTokenCredential(client);

        // TODO: add back in when AzureSasCredential supports generating SAS's
        //public static new AzureSasCredential GetSasCredential(BlobBaseClient client)
        //=> BlobBaseClient.GetSasCredential(client);
    }
}
