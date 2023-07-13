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

        public StorageClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics)
            : this(pipeline, clientDiagnostics, sharedKeyCredential, null, null)
        {
            SharedKeyCredential = sharedKeyCredential;
        }

        public StorageClientConfiguration(
            HttpPipeline pipeline,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics)
            : this (pipeline, clientDiagnostics, null, sasCredential, null)
        {
        }

        public StorageClientConfiguration(
            HttpPipeline pipeline,
            TokenCredential tokenCredential,
            ClientDiagnostics clientDiagnostics)
            : this (pipeline, clientDiagnostics, null, null, tokenCredential)
        {
        }

        protected StorageClientConfiguration(
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential)
        {
            Pipeline = pipeline;
            ClientDiagnostics = clientDiagnostics;
            SharedKeyCredential = sharedKeyCredential;
            SasCredential = sasCredential;
            TokenCredential = tokenCredential;
        }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        protected StorageClientConfiguration() { }
    }
}
