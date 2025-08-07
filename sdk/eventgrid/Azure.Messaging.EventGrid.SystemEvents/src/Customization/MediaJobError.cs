// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Details of JobOutput errors. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MediaJobError
    {
        /// <summary> Initializes a new instance of <see cref="MediaJobError"/>. </summary>
        internal MediaJobError()
        {
            Details = new ChangeTrackingList<MediaJobErrorDetail>();
        }

        /// <summary> Initializes a new instance of <see cref="MediaJobError"/>. </summary>
        /// <param name="code"> Error code describing the error. </param>
        /// <param name="message"> A human-readable language-dependent representation of the error. </param>
        /// <param name="category"> Helps with categorization of errors. </param>
        /// <param name="retry"> Indicates that it may be possible to retry the Job. If retry is unsuccessful, please contact Azure support via Azure Portal. </param>
        /// <param name="details"> An array of details about specific errors that led to this reported error. </param>
        internal MediaJobError(MediaJobErrorCode? code, string message, MediaJobErrorCategory? category, MediaJobRetry? retry, IReadOnlyList<MediaJobErrorDetail> details)
        {
            Code = code;
            Message = message;
            Category = category;
            Retry = retry;
            Details = details;
        }

        /// <summary> Error code describing the error. </summary>
        public MediaJobErrorCode? Code { get; }
        /// <summary> A human-readable language-dependent representation of the error. </summary>
        public string Message { get; }
        /// <summary> Helps with categorization of errors. </summary>
        public MediaJobErrorCategory? Category { get; }
        /// <summary> Indicates that it may be possible to retry the Job. If retry is unsuccessful, please contact Azure support via Azure Portal. </summary>
        public MediaJobRetry? Retry { get; }
        /// <summary> An array of details about specific errors that led to this reported error. </summary>
        public IReadOnlyList<MediaJobErrorDetail> Details { get; }
    }
}
