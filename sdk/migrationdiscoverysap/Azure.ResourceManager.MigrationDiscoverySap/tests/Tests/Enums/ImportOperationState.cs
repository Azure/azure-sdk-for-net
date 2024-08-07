// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Azure.ResourceManager.MigrationDiscoverySap.Tests.Tests.Enums
{
    /// <summary>
    /// ARM acceptable operation states.
    /// <see href="https://github.com/Microsoft/api-guidelines/blob/vNext/Guidelines.md#1325----operation-resource"/>.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImportOperationState
    {
        /// <summary>
        /// Accepted operation state.
        /// </summary>
        Accepted,

        /// <summary>
        /// Awaiting File operation state.
        /// </summary>
        AwaitingFile,

        /// <summary>
        /// Processing File operation state.
        /// </summary>
        ProcessingFile,

        /// <summary>
        /// Succeeded operation state.
        /// </summary>
        Succeeded,

        /// <summary>
        /// Uploading Error Excel operation state.
        /// </summary>
        UploadingErrorExcel,

        /// <summary>
        /// Partially Succeeded operation state.
        /// </summary>
        PartiallySucceeded,

        /// <summary>
        /// Failed operation state.
        /// </summary>
        Failed,

        /// <summary>
        /// Cancelled operation state.
        /// </summary>
        Canceled
    }
}
