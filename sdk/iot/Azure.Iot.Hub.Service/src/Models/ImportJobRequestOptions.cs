// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.Hub.Service.Models
{
    public class ImportJobRequestOptions : JobRequestOptions
    {
        /// <summary>
        /// The name of the blob that will be created in the provided blob container. If not provided by the user, it will default to "devices.txt".
        /// </summary>
        /// <remarks>
        /// In the case of export, the blob will contain the export devices registry information for the IoT Hub. In the case of import, the blob will contain the status of importing devices.
        /// </remarks>
        public string OutputBlobName { get; set; }

        /// <summary>
        /// The name of the blob that will be used to read from in the provided blob container. If not provided by the user, it will default to "devices.txt".
        /// </summary>
        /// <remarks>
        /// In the case of export, the blob will contain the export devices registry information for the IoT Hub. In the case of import, the blob will contain the status of importing devices.
        /// </remarks>
        public string InputBloblName { get; set; }
    }
}
