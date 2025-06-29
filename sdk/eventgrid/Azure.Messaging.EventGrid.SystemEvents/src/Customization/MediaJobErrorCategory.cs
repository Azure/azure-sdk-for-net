// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary>
    /// Helps with categorization of errors. If you get an enum with a value of <see cref="int.MaxValue"/>, that means the service has returned a new category, and you
    /// should upgrade to the latest SDK.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MediaJobErrorCategory
    {
        /// <summary> The error is service related. </summary>
        Service,
        /// <summary> The error is download related. </summary>
        Download,
        /// <summary> The error is upload related. </summary>
        Upload,
        /// <summary> The error is configuration related. </summary>
        Configuration,
        /// <summary> The error is related to data in the input files. </summary>
        Content,
        /// <summary> The error is related to account information. </summary>
        Account
    }
}
