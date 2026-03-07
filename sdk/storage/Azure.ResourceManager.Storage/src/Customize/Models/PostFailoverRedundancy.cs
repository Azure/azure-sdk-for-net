// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct PostFailoverRedundancy
    {
        /// <summary> Standard_LRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostFailoverRedundancy StandardLrs => StandardLRS;

        /// <summary> Standard_ZRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostFailoverRedundancy StandardZrs => StandardZRS;
    }
}
