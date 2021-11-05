// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal static class BlobServiceClientExtensions
    {
        public static bool IsDevelopmentStorageAccount(this BlobServiceClient blobServiceClient)
        {
            // see the section "Addressing local storage resources" in http://msdn.microsoft.com/en-us/library/windowsazure/hh403989.aspx
            return string.Equals(
                blobServiceClient.Uri.PathAndQuery.TrimStart('/'),
                blobServiceClient.AccountName,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
