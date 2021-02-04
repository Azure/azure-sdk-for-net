// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        public virtual ClientDiagnostics ClientDiagnostics { get; private set; }

        public StorageClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics)
        {
            Pipeline = pipeline;
            SharedKeyCredential = sharedKeyCredential;
            ClientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        internal StorageClientConfiguration() { }
    }
}
