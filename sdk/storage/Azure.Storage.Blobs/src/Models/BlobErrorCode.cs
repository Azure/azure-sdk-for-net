// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Error codes returned by the service.
    /// </summary>
    [CodeGenModel("ErrorCode")]
    public partial struct BlobErrorCode
    {
        private const string SnaphotOperationRateExceededValue = "SnaphotOperationRateExceeded";
        private const string IncrementalCopyOfEralierVersionSnapshotNotAllowedValue = "IncrementalCopyOfEralierVersionSnapshotNotAllowed";

        /// <summary> SnaphotOperationRateExceeded. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobErrorCode SnaphotOperationRateExceeded { get; } = new BlobErrorCode(SnaphotOperationRateExceededValue);

        /// <summary> IncrementalCopyOfEralierVersionSnapshotNotAllowed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobErrorCode IncrementalCopyOfEralierVersionSnapshotNotAllowed { get; } = new BlobErrorCode(IncrementalCopyOfEralierVersionSnapshotNotAllowedValue);

        /// <summary> Overloading equality for BlobErrorCode==string </summary>
        public static bool operator ==(BlobErrorCode code, string value) => code.Equals(value);

        /// <summary> Overloading inequality for BlobErrorCode!=string </summary>
        public static bool operator !=(BlobErrorCode code, string value) => !(code == value);

        /// <summary> Overloading equality for string==BlobErrorCode </summary>
        public static bool operator ==(string value, BlobErrorCode code) => code.Equals(value);

        /// <summary> Overloading inequality for string!=BlobErrorCode </summary>
        public static bool operator !=(string value, BlobErrorCode code) => !(value == code);

        /// <summary> Implementing BlobErrorCode.Equals(string) </summary>
        public bool Equals(string value)
        {
            if (value == null)
                return false;
            return this.Equals(new BlobErrorCode(value));
        }
    }
}
