// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: Keeps public parameterless constructor and setter on TargetSkuName.
// Date properties (StartOn/EndOn) are now generated as DateTimeOffset? via @@alternateType.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> This defines the sku conversion status object for asynchronous sku conversions. </summary>
    public partial class StorageAccountSkuConversionStatus
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="StorageAccountSkuConversionStatus"/>. </summary>
        public StorageAccountSkuConversionStatus()
        {
        }

        /// <summary> This property indicates the current sku conversion status. </summary>
        [WirePath("skuConversionStatus")]
        public StorageAccountSkuConversionState? SkuConversionStatus { get; }

        /// <summary> This property represents the target sku name to which the account sku is being converted asynchronously. </summary>
        [WirePath("targetSkuName")]
        public StorageSkuName? TargetSkuName { get; set; }
    }
}
