// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// The properties and content returned from downloading a storage resource
    /// </summary>
    public class StorageResourceReadStreamResult
    {
        /// <summary>
        /// Content
        /// </summary>
        public readonly Stream Content;

        /// <summary>
        /// Indicates the range of bytes returned if the client requested a subset of the storage resource by setting the Range request header.
        /// </summary>
        public readonly HttpRange Range;

        /// <summary>
        /// The properties for the storage resource
        /// </summary>
        internal StorageResourceItemProperties Properties { get; set; }

        internal StorageResourceReadStreamResult() { }

        /// <summary>
        /// Constructor for ReadStreamStorageResourceInfo
        /// </summary>
        /// <param name="content"></param>
        /// <param name="range"></param>
        /// <param name="properties"></param>
        public StorageResourceReadStreamResult(
            Stream content,
            HttpRange range,
            StorageResourceItemProperties properties)
        {
            Content = content;
            Range = range;
            Properties = properties;
        }

        /// <summary>
        /// Constructor for ReadStreamStorageResourceInfo
        /// </summary>
        /// <param name="content"></param>
        internal StorageResourceReadStreamResult(
            Stream content)
        {
            Content = content;
        }
    }
}
