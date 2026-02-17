// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Blobs
{
    [CodeGenType("BlobsClientBuilderExtensions")]
    internal static partial class BlobsClientBuilderExtensionsInternal
    {
        /// <summary> Registers a <see cref="BlobClient"/> client with the specified <see cref="IAzureClientBuilder{TClient,TOptions}"/>. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="blobUri"></param>
        /// <param name="credential"></param>
        public static IAzureClientBuilder<BlobClient, BlobClientOptions> AddBlobClient<TBuilder>(this TBuilder builder, Uri blobUri, StorageSharedKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<BlobClient, BlobClientOptions>(options => new BlobClient(blobUri, credential, options));
        }

        /// <summary> Registers a <see cref="BlobClient"/> client with the specified <see cref="IAzureClientBuilder{TClient,TOptions}"/>. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="blobUri"></param>
        public static IAzureClientBuilder<BlobClient, BlobClientOptions> AddBlobClient<TBuilder>(this TBuilder builder, Uri blobUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<BlobClient, BlobClientOptions>((options, credential) => new BlobClient(blobUri, credential, options));
        }
    }
}
