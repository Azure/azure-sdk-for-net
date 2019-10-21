// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage
{
    /// <summary>
    /// Extension methods to make tests easier to author.
    /// </summary>
    public static partial class TestExtensions
    {
        private static Uri ToHttps(Uri uri)
        {
            RequestUriBuilder builder = new RequestUriBuilder();
            builder.Reset(uri);
            builder.Scheme = Constants.Blob.Https;
            builder.Port = Constants.Blob.HttpsPort;
            return builder.ToUri();
        }

        public static AppendBlobClient WithCustomerProvidedKey(
            this AppendBlobClient blob,
            CustomerProvidedKey customerProvidedKey) =>
            new AppendBlobClient(
                ToHttps(blob.Uri),
                blob.Pipeline,
                blob.ClientDiagnostics,
                customerProvidedKey);

        public static BlockBlobClient WithCustomerProvidedKey(
            this BlockBlobClient blob,
            CustomerProvidedKey customerProvidedKey) =>
            new BlockBlobClient(
                ToHttps(blob.Uri),
                blob.Pipeline,
                blob.ClientDiagnostics,
                customerProvidedKey);

        public static PageBlobClient WithCustomerProvidedKey(
            this PageBlobClient blob,
            CustomerProvidedKey customerProvidedKey) =>
            new PageBlobClient(
                ToHttps(blob.Uri),
                blob.Pipeline,
                blob.ClientDiagnostics,
                customerProvidedKey);
    }
}
