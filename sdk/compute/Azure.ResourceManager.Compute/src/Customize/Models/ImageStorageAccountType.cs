// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public readonly partial struct ImageStorageAccountType
    {
        private const string StandardSsdLrsValue = "StandardSSD_LRS";

        /// <summary> StandardSSD_LRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ImageStorageAccountType StandardSsdLrs { get; } = new ImageStorageAccountType(StandardSsdLrsValue);
    }
}
