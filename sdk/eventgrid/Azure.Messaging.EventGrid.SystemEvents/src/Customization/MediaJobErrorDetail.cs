// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Details of JobOutput errors. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MediaJobErrorDetail
    {
        /// <summary> Initializes a new instance of <see cref="MediaJobErrorDetail"/>. </summary>
        internal MediaJobErrorDetail()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MediaJobErrorDetail"/>. </summary>
        /// <param name="code"> Code describing the error detail. </param>
        /// <param name="message"> A human-readable representation of the error. </param>
        internal MediaJobErrorDetail(string code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary> Code describing the error detail. </summary>
        public string Code { get; }
        /// <summary> A human-readable representation of the error. </summary>
        public string Message { get; }
    }
}
