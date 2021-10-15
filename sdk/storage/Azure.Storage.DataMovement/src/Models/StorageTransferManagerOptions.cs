// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Options for the <see cref="StorageTransferManager"/>.
    /// </summary>
    public class StorageTransferManagerOptions
    {
        /// <summary>
        /// Optional path to set for the Transfer State File.
        ///
        /// If this file is not set and a transfer is started using
        /// the transfer manager, we will default to storing the file in
        /// %USERPROFILE%\.azstoragedml directory on Windows OS
        /// and $HOME$\.azstoragedml directory on Mac and Linux based OS.
        /// </summary>
        public string TransferStateDirectoryPath { get; set; }

        /// <summary>
        /// Optional event handler
        /// </summary>
        public SyncAsyncEventHandler<DataMovementFailedEventArgs> JobFailedHandlers { get; internal set; }
    }
}
