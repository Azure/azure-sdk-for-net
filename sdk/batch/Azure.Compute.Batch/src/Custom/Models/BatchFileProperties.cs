// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// Collection of header values that describe Batch File properties
    /// </summary>
    public partial class BatchFileProperties
    {
        internal BatchFileProperties(bool batchFileIsDirectory, string batchFileMode, string batchFileUrl, DateTime creationTime)
        {
            IsDirectory = batchFileIsDirectory;
            Mode = batchFileMode;
            FileUrl = batchFileUrl;
            CreationTime = creationTime;
        }

        /// <summary> Whether the object represents a directory. </summary>
        public bool IsDirectory { get; }

        /// <summary> The file mode attribute in octal format. </summary>
        public string Mode { get; }

        /// <summary> The URL of the file. </summary>
        public string FileUrl { get; }

        /// <summary> The file creation time. </summary>
        public DateTime CreationTime { get; }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static BatchFileProperties FromResponse(Response response)
        {
            string isDirectoryStr = "";
            bool isDirectory = false;
            string mode = "";
            string fileUrl = "";
            string creationTimeStr = "";

            response.Headers.TryGetValue("ocp-creation-time", out creationTimeStr);
            response.Headers.TryGetValue("ocp-batch-file-isdirectory", out isDirectoryStr);
            response.Headers.TryGetValue("ocp-batch-file-url", out fileUrl);
            response.Headers.TryGetValue("ocp-batch-file-mode", out mode);

            Boolean.TryParse(isDirectoryStr, out isDirectory);
            DateTime creationTime = DateTime.Parse(creationTimeStr, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

            return new BatchFileProperties(isDirectory, mode, fileUrl, creationTime);
        }
    }
}
