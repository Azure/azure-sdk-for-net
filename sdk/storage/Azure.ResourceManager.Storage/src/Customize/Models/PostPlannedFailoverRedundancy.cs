// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct PostPlannedFailoverRedundancy
    {
        /// <summary> Standard_GRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostPlannedFailoverRedundancy StandardGrs => StandardGRS;

        /// <summary> Standard_GZRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostPlannedFailoverRedundancy StandardGzrs => StandardGZRS;

        /// <summary> Standard_RAGRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostPlannedFailoverRedundancy StandardRagrs => StandardRAGRS;

        /// <summary> Standard_RAGZRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostPlannedFailoverRedundancy StandardRagzrs => StandardRAGZRS;
    }
}
