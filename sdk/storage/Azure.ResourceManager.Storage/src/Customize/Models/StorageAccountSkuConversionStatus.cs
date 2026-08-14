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

        // Prior GA had a public parameterless ctor; generated code only has an internal ctor.
        // Users create instances to set TargetSkuName for SKU conversion requests.
        /// <summary> Initializes a new instance of <see cref="StorageAccountSkuConversionStatus"/>. </summary>
        public StorageAccountSkuConversionStatus()
        {
        }

        /// <summary> This property indicates the current sku conversion status. </summary>
        [WirePath("skuConversionStatus")]
        public StorageAccountSkuConversionState? SkuConversionStatus { get; }

        // Prior GA had a setter; generated code is read-only. Users need the setter
        // to specify the target SKU when requesting an asynchronous SKU conversion.
        /// <summary> This property represents the target sku name to which the account sku is being converted asynchronously. </summary>
        [WirePath("targetSkuName")]
        public StorageSkuName? TargetSkuName { get; set; }
    }
}
