// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// The properties and content returned from downloading a storage resource
    /// </summary>
    public class ReadStreamStorageResourceResult
    {
        /// <summary>
        /// Content
        /// </summary>
        internal Stream Content { get; }

        /// <summary>
        /// Indicates the range of bytes returned if the client requested a subset of the storage resource by setting the Range request header.
        ///
        /// The format of the Content-Range is expected to comeback in the following format.
        /// [unit] [start]-[end]/[fileSize]
        /// (e.g. bytes 1024-3071/10240)
        ///
        /// The [end] value will be the inclusive last byte (e.g. header "bytes 0-7/8" is the entire 8-byte storage resource).
        /// </summary>
        internal string ContentRange { get; }

        /// <summary>
        /// Indicates that the service supports requests for partial storage resource content.
        /// </summary>
        internal string AcceptRanges { get; }

        /// <summary>
        /// If the storage resource has a MD5 hash, and if request contains range header (Range or x-ms-range), this response header is returned with the value of the whole storage resource's MD5 value. This value may or may not be equal to the value returned in Content-MD5 header, with the latter calculated from the requested range.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        internal byte[] RangeContentHash { get; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The properties for the storage resource
        /// </summary>
        internal StorageResourceProperties Properties { get; set; }

        internal ReadStreamStorageResourceResult() { }

        /// <summary>
        /// Constructor for ReadStreamStorageResourceInfo
        /// </summary>
        /// <param name="content"></param>
        /// <param name="contentRange"></param>
        /// <param name="acceptRanges"></param>
        /// <param name="rangeContentHash"></param>
        /// <param name="properties"></param>
        public ReadStreamStorageResourceResult(
            Stream content,
            string contentRange,
            string acceptRanges,
            byte[] rangeContentHash,
            StorageResourceProperties properties)
        {
            Content = content;
            ContentRange = contentRange;
            AcceptRanges = acceptRanges;
            RangeContentHash = rangeContentHash;
            Properties = properties;
        }

        /// <summary>
        /// Constructor for ReadStreamStorageResourceInfo
        /// </summary>
        /// <param name="content"></param>
        public ReadStreamStorageResourceResult(
            Stream content)
        {
            Content = content;
        }
    }
}
