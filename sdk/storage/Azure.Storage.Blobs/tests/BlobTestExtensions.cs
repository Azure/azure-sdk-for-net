﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage
{
    /// <summary>
    /// Extension methods to make tests easier to author.
    /// </summary>
    public static partial class BlobTestExtensions
    {
        private static Uri ToHttps(Uri uri)
        {
            RequestUriBuilder builder = new RequestUriBuilder();
            builder.Reset(uri);
            builder.Scheme = Constants.Https;
            builder.Port = Constants.Blob.HttpsPort;
            return builder.ToUri();
        }

        private static BlobClientConfiguration BuildClientConfigurationWithEncryptionScope(
            BlobClientConfiguration clientConfiguration,
            string encryptionScope)
            => new BlobClientConfiguration(
                pipeline: clientConfiguration.Pipeline,
                sharedKeyCredential: clientConfiguration.SharedKeyCredential,
                clientDiagnostics: clientConfiguration.ClientDiagnostics,
                version: clientConfiguration.Version,
                customerProvidedKey: null,
                encryptionScope: encryptionScope);

        private static BlobClientConfiguration BuildClientConfigurationWithCpk(
            BlobClientConfiguration clientConfiguration,
            CustomerProvidedKey customerProvidedKey)
            => new BlobClientConfiguration(
                pipeline: clientConfiguration.Pipeline,
                sharedKeyCredential: clientConfiguration.SharedKeyCredential,
                clientDiagnostics: clientConfiguration.ClientDiagnostics,
                version: clientConfiguration.Version,
                customerProvidedKey: customerProvidedKey,
                encryptionScope: null);

        /// <summary>
        /// Convert a base RequestConditions to BlobRequestConditions.
        /// </summary>
        /// <param name="conditions">The <see cref="RequestConditions"/>.</param>
        /// <returns>The <see cref="BlobRequestConditions"/>.</returns>
        public static BlobRequestConditions ToBlobRequestConditions(this RequestConditions conditions) =>
            conditions == null ?
                null :
                new BlobRequestConditions
                {
                    IfMatch = conditions.IfMatch,
                    IfNoneMatch = conditions.IfNoneMatch,
                    IfModifiedSince = conditions.IfModifiedSince,
                    IfUnmodifiedSince = conditions.IfUnmodifiedSince
                };
    }
}
