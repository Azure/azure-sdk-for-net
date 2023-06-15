// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.DataBox.Models
{
    /// <summary> Type of the transfer. </summary>
    public enum DataBoxJobTransferType
    {
        /// <summary> Import data to azure. </summary>
        ImportToAzure,
        /// <summary> Export data from azure. </summary>
        ExportFromAzure
    }
}
