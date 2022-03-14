// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// This class allows the user to specify the source credentials for resuming a transfer job.
    /// See <see cref="ResumeTransferCredentials"/>.
    /// </summary>
    public class StorageTransferCredential
    {
        /// <summary>
        /// Connection String for Transfer.
        ///
        /// Will return null if another credential was set in the constructor.
        /// </summary>
        public string ConnectionString { get; internal set; }

        /// <summary>
        /// Shared Key Credential for Transfer.
        ///
        /// Will return null if another credential was set in the constructor.
        /// </summary>
        public StorageSharedKeyCredential SharedKeyCredential { get; internal set; }

        /// <summary>
        /// Sas Credential for Transfer.
        ///
        /// Will return null if another credential was set in the constructor.
        /// </summary>
        public AzureSasCredential SasCredential { get; internal set; }

        /// <summary>
        /// Token Credentials for Transfer.
        ///
        /// Will return null if another credential was set in the constructor.
        /// </summary>
        public TokenCredential TokenCredential { get; internal set; }

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        protected StorageTransferCredential()
        { }

        /// <summary>
        /// Constructor for <see cref="ResumeTransferCredentials"/> where the credential is a connection string.
        /// If the endpoint information in the connection string is different than the source endpoint in the
        /// transfer job attempted to resume, an exception will be thrown.
        /// </summary>
        /// <param name="connectionString"></param>
        public StorageTransferCredential(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Constructor for <see cref="ResumeTransferCredentials"/> where the source credential is a shared key credential.
        /// </summary>
        /// <param name="sharedKeyCredential"></param>
        public StorageTransferCredential(StorageSharedKeyCredential sharedKeyCredential)
        {
            SharedKeyCredential = sharedKeyCredential;
        }

        /// <summary>
        /// Constructor for <see cref="ResumeTransferCredentials"/> where the source credential is a token credential
        /// </summary>
        /// <param name="azureSasCredential"></param>
        public StorageTransferCredential(AzureSasCredential azureSasCredential)
        {
            SasCredential = azureSasCredential;
        }

        /// <summary>
        /// Constructor for <see cref="ResumeTransferCredentials"/> where the source credential is a token credential
        /// </summary>
        /// <param name="tokenCredential"></param>
        public StorageTransferCredential(TokenCredential tokenCredential)
        {
            TokenCredential = tokenCredential;
        }
    }
}
