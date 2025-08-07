// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Files.Shares
{
    internal class ShareClientConfiguration : StorageClientConfiguration
    {
        public ShareClientOptions ClientOptions { get; internal set; }

        public TransferValidationOptions TransferValidation { get; internal set; }

        public ShareAudience Audience { get; internal set; }

        /// <summary>
        /// Create a <see cref="ShareClientConfiguration"/> with shared key authentication.
        /// </summary>
        public ShareClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions clientOptions)
            : this(pipeline, sharedKeyCredential, default, default, clientDiagnostics, clientOptions)
        {
        }

        /// <summary>
        /// Create a <see cref="ShareClientConfiguration"/> with SAS authentication.
        /// </summary>
        public ShareClientConfiguration(
            HttpPipeline pipeline,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions clientOptions)
            : this(pipeline, default, sasCredential, default, clientDiagnostics, clientOptions)
        {
        }

        /// <summary>
        /// Create a <see cref="ShareClientConfiguration"/> with token authentication.
        /// </summary>
        public ShareClientConfiguration(
            HttpPipeline pipeline,
            TokenCredential tokenCredential,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions clientOptions)
            : this(pipeline, default, default, tokenCredential, clientDiagnostics, clientOptions)
        {
        }

        /// <summary>
        /// Create a <see cref="ShareClientConfiguration"/> without authentication,
        /// or with SAS that was provided as part of the URL.
        /// </summary>
        public ShareClientConfiguration(
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions clientOptions)
            : this(pipeline, default, default, default, clientDiagnostics, clientOptions)
        {
        }

        /// <summary>
        /// For internal Client Constructors that accept multiple types of authentication.
        /// </summary>
        internal ShareClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential,
            ClientDiagnostics clientDiagnostics,
            ShareClientOptions clientOptions)
            : base(pipeline, sharedKeyCredential, sasCredential, tokenCredential, clientDiagnostics)
        {
            ClientOptions = clientOptions;
            TransferValidation = clientOptions.TransferValidation;
        }
    }
}
