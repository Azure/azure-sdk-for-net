// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct DirectoryServiceOption
    {
        /// <summary> AADDS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DirectoryServiceOption Aadds => AADDS;

        /// <summary> AADKERB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DirectoryServiceOption Aadkerb => AADKERB;
    }
}
