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

        public virtual TokenCredential OAuthTokenCredential { get; private set; }

        public virtual AzureSasCredential SasCredential { get; private set; }

        public virtual ClientDiagnostics ClientDiagnostics { get; private set; }

        public StorageClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics)
            : this(pipeline, clientDiagnostics)
        {
            SharedKeyCredential = sharedKeyCredential;
        }

        public StorageClientConfiguration(
            HttpPipeline pipeline,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics)
            : this (pipeline, clientDiagnostics)
        {
            SasCredential = sasCredential;
        }

        public StorageClientConfiguration(
            HttpPipeline pipeline,
            TokenCredential tokenCredential,
            ClientDiagnostics clientDiagnostics)
            : this(pipeline, clientDiagnostics)
        {
            OAuthTokenCredential = tokenCredential;
        }

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
            OAuthTokenCredential = tokenCredential;
            ClientDiagnostics = clientDiagnostics;
        }

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
