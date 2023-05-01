// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement.Models
{
    internal class ResourceAuthScheme
    {
        public virtual StorageSharedKeyCredential SharedKeyCredential { get; private set; }

        public virtual TokenCredential OAuthTokenCredential { get; private set; }

        public virtual AzureSasCredential SasCredential { get; private set; }

        public ResourceAuthScheme(StorageSharedKeyCredential sharedKeyCredential)
        {
            SharedKeyCredential = sharedKeyCredential;
        }

        public ResourceAuthScheme(TokenCredential oAuthTokenCredential)
        {
            OAuthTokenCredential = oAuthTokenCredential;
        }

        public ResourceAuthScheme(AzureSasCredential sasCredential)
        {
            SasCredential = sasCredential;
        }
    }
}
