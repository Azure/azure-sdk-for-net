// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Shared
{
    /// <summary>
    /// Parent class of the *ClientConfiguration classes.
    /// Contains common properties used to create clients.
    /// </summary>
    internal class StorageClientConfiguration
    {
        public virtual HttpPipeline Pipeline { get; private set; }

        public virtual StorageSharedKeyCredential SharedKeyCredential { get; private set; }

        public virtual TokenCredential TokenCredential { get; private set; }

        public virtual AzureSasCredential SasCredential { get; private set; }

        public virtual ClientDiagnostics ClientDiagnostics { get; private set; }

        /// <summary>
        /// Create a <see cref="StorageClientConfiguration"/> with shared key authentication.
        /// </summary>
        public StorageClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics)
            : this(pipeline, clientDiagnostics)
        {
            SharedKeyCredential = sharedKeyCredential;
        }

        /// <summary>
        /// Create a <see cref="StorageClientConfiguration"/> with SAS authentication.
        /// </summary>
        public StorageClientConfiguration(
            HttpPipeline pipeline,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics)
            : this (pipeline, clientDiagnostics)
        {
            SasCredential = sasCredential;
        }

        /// <summary>
        /// Create a <see cref="StorageClientConfiguration"/> with token authentication.
        /// </summary>
        public StorageClientConfiguration(
            HttpPipeline pipeline,
            TokenCredential tokenCredential,
            ClientDiagnostics clientDiagnostics)
            : this(pipeline, clientDiagnostics)
        {
            TokenCredential = tokenCredential;
        }

        /// <summary>
        /// Only use for creating a deep copy of a <see cref="StorageClientConfiguration"/>.
        /// </summary>
        internal StorageClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential,
            ClientDiagnostics clientDiagnostics)
        {
            Pipeline = pipeline;
            SharedKeyCredential = sharedKeyCredential;
            SasCredential = sasCredential;
            TokenCredential = tokenCredential;
            ClientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Create a <see cref="StorageClientConfiguration"/> without authentication,
        /// or with SAS that was provided as part of the URL.
        /// </summary>
        internal StorageClientConfiguration(
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics)
        {
            Pipeline = pipeline;
            ClientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        internal StorageClientConfiguration() { }
    }
}
