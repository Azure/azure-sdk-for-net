// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Controller the data moving from Blobs to destination
    /// </summary>
    public class BlobDataController : DataController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BlobDataController()
        { }

        /// <summary>
        /// Intiate transfer
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public DataTransfer StartTransfer(StorageResource From, StorageResource To)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Intiate transfer
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public DataTransfer StartTransfer(StorageResourceContainer From, StorageResourceContainer To)
        {
            throw new NotImplementedException();
        }

        private DataTransfer transferViaUri(StorageResource from, StorageResource to)
        {
            throw new NotImplementedException();
        }

        private DataTransfer transferViaStream(StorageResource from, StorageResource to)
        {
            throw new NotImplementedException();
        }
    }
}
