// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Helps with categorization of errors. </summary>
    [CodeGenModel("MediaJobErrorCategory")]
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
        Content
    }
}
