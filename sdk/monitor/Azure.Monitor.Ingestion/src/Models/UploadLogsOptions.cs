// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core.Serialization;
using System.Text.Json;

namespace Azure.Monitor.Ingestion
{
    /// <summary>
    /// The options model to configure the request to upload logs to Azure Monitor.
    /// </summary>
    public class UploadLogsOptions
    {
        /// <summary>
        /// The serializer to use to convert the log objects to JSON.
        /// </summary>
        public ObjectSerializer ObjectSerializer { get; set; }

        /// <summary>
        /// The max concurrent requests to send to the Azure Monitor service when uploading logs.
        /// </summary>
        public int MaxConcurrency { get; set; }
    }
}
