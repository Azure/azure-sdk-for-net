// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Internal Resource Authentication Scheme for a <see cref="StorageResource"/>.
    ///
    /// This is specifically used for <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>
    /// and <see cref="StorageResource.CopyFromUriAsync(StorageResource, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/> when using the
    /// <see cref="StorageResourceCopyFromUriOptions.SourceAuthentication"/>. It's also used on the source copy source when a <see cref="AzureSasCredential"/> is used on the Uri.
    /// </summary>
    internal class ResourceAuthScheme
    {
        public virtual TokenCredential TokenCredential { get; private set; }

        public virtual AzureSasCredential SasCredential { get; private set; }

        public ResourceAuthScheme(TokenCredential tokenCredential)
        {
            TokenCredential = tokenCredential;
        }

        public ResourceAuthScheme(AzureSasCredential sasCredential)
        {
            SasCredential = sasCredential;
        }
    }
}
