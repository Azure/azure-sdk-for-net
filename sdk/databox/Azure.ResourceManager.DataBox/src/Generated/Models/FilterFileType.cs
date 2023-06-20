// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.DataBox.Models
{
    /// <summary> Type of the filter file. </summary>
    public enum FilterFileType
    {
        /// <summary> Filter file is of the type AzureBlob. </summary>
        AzureBlob,
        /// <summary> Filter file is of the type AzureFiles. </summary>
        AzureFile
    }
}
