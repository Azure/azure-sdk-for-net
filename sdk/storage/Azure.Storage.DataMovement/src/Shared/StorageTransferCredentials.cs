// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// storage transfer credentials
    /// </summary>
    public class StorageTransferCredentials
    {
        internal StorageSharedKeyCredential _sharedKeyCredential;
        internal AzureSasCredential _azureSasCredential;
        internal TokenCredential _tokenCredential;

        /// <summary>
        /// stub
        /// </summary>
        /// <param name="credential"></param>
        public StorageTransferCredentials(StorageSharedKeyCredential credential)
        {
            _sharedKeyCredential = credential;
            _azureSasCredential = default;
            _tokenCredential = default;
        }

        /// <summary>
        /// stub
        /// </summary>
        /// <param name="credential"></param>
        public StorageTransferCredentials(AzureSasCredential credential)
        {
            _sharedKeyCredential = default;
            _azureSasCredential = credential;
            _tokenCredential = default;
        }

        /// <summary>
        /// stub
        /// </summary>
        /// <param name="credential"></param>
        public StorageTransferCredentials(TokenCredential credential)
        {
            _sharedKeyCredential = default;
            _azureSasCredential = default;
            _tokenCredential = credential;
        }

        /// <summary>
        /// Returns the credential that was originally constructed with.
        /// </summary>
        /// <returns>
        /// The credential that the object was originally constructed with.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public (Type CredentialType, object Value) GetCredential()
        {
            if (_sharedKeyCredential != null) return (typeof(StorageSharedKeyCredential), _sharedKeyCredential);
            if (_azureSasCredential != null) return (typeof(AzureSasCredential), _azureSasCredential);
            if ( _tokenCredential != null) return (typeof(TokenCredential), _tokenCredential);
            return default;
        }
    }
}
