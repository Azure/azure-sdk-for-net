// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountNameAvailabilityResult
    {
        /// <summary> Backward-compatible alias for NameAvailable. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("nameAvailable")]
        public bool? IsNameAvailable => NameAvailable;
    }
}
