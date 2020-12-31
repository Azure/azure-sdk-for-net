// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.Hub.Service.Models
{
    /// <summary>
    /// Optional properties for export jobs.
    /// </summary>
    public class ExportJobRequestOptions : JobRequestOptions
    {
        /// <summary>
        /// The name of the blob that contains the export devices registry information for the IoT Hub. If not provided by the user, it will default to "devices.txt".
        /// </summary>
        public string OutputBlobName { get; set; }
    }
}
