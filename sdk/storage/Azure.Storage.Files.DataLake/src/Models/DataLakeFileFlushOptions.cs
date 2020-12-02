// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// TODO
    /// </summary>
    public class DataLakeFileFlushOptions
    {
        /// <summary>
        /// If "true", uncommitted data is retained after the flush operation completes; otherwise, the uncommitted data is deleted
        /// after the flush operation. The default is false. Data at offsets less than the specified position are written to the
        /// file when flush succeeds, but this optional parameter allows data after the flush position to be retained for a future
        /// flush operation.
        /// </summary>
        public bool? RetainUncommittedData { get; set; }

        /// <summary>
        /// Azure Storage Events allow applications to receive notifications when files change. When Azure Storage Events are enabled,
        /// a file changed event is raised. This event has a property indicating whether this is the final change to distinguish the
        /// difference between an intermediate flush to a file stream and the final close of a file stream. The close query parameter
        /// is valid only when the action is "flush" and change notifications are enabled. If the value of close is "true" and the
        /// flush operation completes successfully, the service raises a file change notification with a property indicating that
        /// this is the final update (the file stream has been closed). If "false" a change notification is raised indicating the
        /// file has changed. The default is false. This query parameter is set to true by the Hadoop ABFS driver to indicate that
        /// the file stream has been closed."
        /// </summary>
        public bool? Close { get; set; }

        /// <summary>
        /// Optional standard HTTP header properties that can be set for the file.
        /// </summary>
        public PathHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the flush of this file.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional.  If true, the lease will be released.  Conditions.LeaseId must be provided.
        /// </summary>
        public bool? ReleaseLease { get; set; }
    }
}
