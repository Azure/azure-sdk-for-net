// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        internal object GetCredential()
        {
            if (_sharedKeyCredential != null) return _sharedKeyCredential;
            if (_azureSasCredential != null) return _azureSasCredential;
            if ( _tokenCredential != null) return _tokenCredential;
            return default;
        }
    }
}
