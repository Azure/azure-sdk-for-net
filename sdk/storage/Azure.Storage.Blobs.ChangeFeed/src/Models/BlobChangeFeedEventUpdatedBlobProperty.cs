// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.ChangeFeed.Models
{
    /// <summary>
    /// A blob property that was updated.
    /// </summary>
    public class BlobChangeFeedEventUpdatedBlobProperty
    {
        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal BlobChangeFeedEventUpdatedBlobProperty() { }

        /// <summary>
        /// The name of the property that was updated.
        /// </summary>
        public string PropertyName { get; internal set; }

        /// <summary>
        /// The previous value of the property.
        /// </summary>
        public string PreviousValue { get; internal set; }

        /// <summary>
        /// The new value of the property.
        /// </summary>
        public string NewValue { get; internal set; }
    }
}
