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
    }
}
