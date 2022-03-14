// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// This class allows the user to specify the credentials for resuming a transfer job. (e.g. StorageTransferManager.Resume(..))
    /// </summary>
    public class ResumeTransferCredentials
    {
        private StorageTransferCredential _sourceTransferCredential;
        private StorageTransferCredential _destinationTransferCredential;

        /// <summary>
        /// The transfer credentials for the source.
        /// </summary>
        public StorageTransferCredential SourceTransferCredential => _sourceTransferCredential;

        /// <summary>
        /// The transfer credentials for the destination.
        /// </summary>
        public StorageTransferCredential DestinationTransferCredential => _destinationTransferCredential;

        /// <summary>
        /// Contructor for mocking
        /// </summary>
        protected ResumeTransferCredentials() { }

        /// <summary>
        /// Constructor for <see cref="ResumeTransferCredentials"/> to specify the source and/or destination
        /// credentials to resume a transfer.
        /// </summary>
        /// <param name="sourceTransferCredential"></param>
        /// <param name="destinationTransferCredential"></param>
        public ResumeTransferCredentials(StorageTransferCredential sourceTransferCredential, StorageTransferCredential destinationTransferCredential)
        {
            _sourceTransferCredential = sourceTransferCredential;
            _destinationTransferCredential = destinationTransferCredential;
        }
    }
}
