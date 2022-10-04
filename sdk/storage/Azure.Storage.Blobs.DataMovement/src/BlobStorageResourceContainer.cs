// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Blob Container Resource (no directories because of the flat namespace)
    /// </summary>
    internal class BlobStorageResourceContainer : StorageResourceContainer
    {
        private BlobContainerClient blobContainerClient;
        private List<string> _directoryPrefix;
        private string _originalPrefix;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="blobContainerClient"></param>
        /// <param name="directoryPrefix"></param>
        public BlobStorageResourceContainer(BlobContainerClient blobContainerClient, string directoryPrefix)
        {
            this.blobContainerClient = blobContainerClient;
            _originalPrefix = directoryPrefix;
            _directoryPrefix = directoryPrefix.Split('/').ToList();
        }

        /// <summary>
        /// returns path split up
        /// </summary>
        /// <returns></returns>
        public override List<string> GetPath()
        {
            return _directoryPrefix;
        }

        /// <summary>
        /// returns path split up
        /// </summary>
        /// <returns></returns>
        public string GetFullPath()
        {
            return _originalPrefix;
        }

        /// <summary>
        /// Creates new blob client based on the parent container client
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public override StorageResource GetStorageResource(List<string> path)
        {
            return new BlobStorageResource(blobContainerClient.GetBlobClient(string.Join("/", path)));
        }

        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override StorageResourceContainer GetStorageResourceContainer(List<string> path)
        {
            throw new NotSupportedException("No virtual directories supported in flat namespace");
        }
    }
}
