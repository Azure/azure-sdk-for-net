// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.IO;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// The properties and content returned from downloading a storage resource
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class StorageResourceReadStreamResult
    {
        /// <summary>
        /// Content.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public readonly Stream Content;

        /// <summary>
        /// Length of the content.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public readonly long? ContentLength;

        /// <summary>
        /// Length of the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public readonly long? ResourceLength;

        /// <summary>
        /// The ETag of the result.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public readonly ETag? ETag;

        internal StorageResourceReadStreamResult() { }

        /// <summary>
        /// Constructor for StorageResourceReadStreamResult
        /// </summary>
        /// <param name="content"></param>
        /// <param name="range"></param>
        /// <param name="properties"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageResourceReadStreamResult(
            Stream content,
            HttpRange range,
            StorageResourceItemProperties properties)
        {
            Content = content;
            ContentLength = range != default ? range.Length : 0;
            ResourceLength = properties.ResourceLength;
            ETag = properties.ETag;
        }

        /// <summary>
        /// Constructor for ReadStreamStorageResourceInfo
        /// </summary>
        /// <param name="content"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal StorageResourceReadStreamResult(
            Stream content)
        {
            Content = content;
            ContentLength = content.Length;
            ResourceLength = content.Length;
        }
    }
}
