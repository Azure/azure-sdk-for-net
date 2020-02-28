// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Internal.Avro;

#pragma warning disable AZC0005 // It's a proof of concept

namespace Azure.Storage.ChangeFeed
{
    /// <summary>
    /// Turn and face the strange.
    /// </summary>
    public static class ChangeFeedClient
    {
        /// <summary>
        /// Get the latest changes in an Azure Blob Storage account.
        /// </summary>
        /// <param name="blobServiceUri">Uri to the account.</param>
        /// <returns>Latest changes to the account.</returns>
        public static object GetChanges(Uri blobServiceUri) =>
            AvroParser.Parse(blobServiceUri);
    }
}
