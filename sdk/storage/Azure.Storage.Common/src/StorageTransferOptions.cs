// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage
{
    /// <summary>
    /// <see cref="StorageTransferOptions"/> is used to provide options for parallel transfers.
    /// </summary>
    public struct StorageTransferOptions : IEquatable<StorageTransferOptions>
    {
        /// <summary>
        /// The maximum length of an transfer in bytes. This property is a backwards-compatible
        /// facade for <see cref="MaximumTransferSize"/>, which supports long values. Use
        /// <see cref="MaximumTransferSize"/> for full access of supported values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? MaximumTransferLength
        {
            get => (int?)MaximumTransferSize;
            set => MaximumTransferSize = value;
        }

        /// <summary>
        /// The maximum length of an transfer in bytes.
        /// </summary>
        public long? MaximumTransferSize { get; set; }

        /// <summary>
        /// The maximum number of workers that may be used in a parallel transfer.
        /// </summary>
        public int? MaximumConcurrency { get; set; }

        /// <summary>
        /// The size of the first range request in bytes. Blobs smaller than this limit will
        /// be downloaded in a single request. Blobs larger than this limit will continue being
        /// downloaded in chunks of size <see cref="MaximumTransferSize"/>. This property is a
        /// backwards-compatible facade for <see cref="MaximumTransferSize"/>, which supports
        /// long values. Use <see cref="InitialTransferSize"/> for full access of supported values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? InitialTransferLength
        {
            get => (int?)InitialTransferSize;
            set => InitialTransferSize = value;
        }

        /// <summary>
        /// The size of the first range request in bytes. Blobs smaller than this limit will
        /// be downloaded in a single request. Blobs larger than this limit will continue being
        /// downloaded in chunks of size <see cref="MaximumTransferSize"/>.
        /// </summary>
        public long? InitialTransferSize { get; set; }

        /// <summary>
        /// Check if two ParallelTransferOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
            => obj is StorageTransferOptions other
            && Equals(other)
            ;

        /// <summary>
        /// Get a hash code for the ParallelTransferOptions.
        /// </summary>
        /// <returns>Hash code for the ParallelTransferOptions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
            => MaximumTransferSize.GetHashCode()
            ^ MaximumConcurrency.GetHashCode()
            ^ InitialTransferSize.GetHashCode()
            ;

        /// <summary>
        /// Check if two ParallelTransferOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(StorageTransferOptions left, StorageTransferOptions right) => left.Equals(right);

        /// <summary>
        /// Check if two ParallelTransferOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(StorageTransferOptions left, StorageTransferOptions right) => !(left == right);

        /// <summary>
        /// Check if two ParallelTransferOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(StorageTransferOptions obj)
            => MaximumTransferSize == obj.MaximumTransferSize
            && MaximumConcurrency == obj.MaximumConcurrency
            && InitialTransferSize == obj.InitialTransferSize
            ;
    }
}
