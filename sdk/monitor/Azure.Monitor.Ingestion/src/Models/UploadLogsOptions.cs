// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;

namespace Azure.Monitor.Ingestion
{
    /// <summary>
    /// The options model to configure the request to upload logs to Azure Monitor.
    /// </summary>
    public class UploadLogsOptions
    {
        /// <summary>
        /// The serializer to use to convert the log objects to JSON.
        /// <remarks> Default Serializer is System.Text.Json. </remarks>
        /// </summary>
        public ObjectSerializer Serializer { get; set; }

        /// <summary>
        /// The max concurrent requests to send to the Azure Monitor service when uploading logs.
        /// <remarks> In the Upload method, this parameter is not used as the batches are uploaded in sequence. </remarks>
        /// </summary>
        public int MaxConcurrency { get; set; }
    }
}
