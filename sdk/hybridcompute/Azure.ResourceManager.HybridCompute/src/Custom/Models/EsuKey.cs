// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.HybridCompute;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Backward-compat justification: the GA ESU key payload accepted licenseStatus values encoded as either numbers or strings.
    public partial class EsuKey
    {
        /// <summary> Initializes a new instance of <see cref="EsuKey"/>. </summary>
        /// <param name="sku"> SKU number. </param>
        /// <param name="licenseStatus"> The current status of the license profile key. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        public EsuKey(string sku, int? licenseStatus, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Sku = sku;
            LicenseStatus = licenseStatus;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The current status of the license profile key. </summary>
        [WirePath("licenseStatus")]
        public int? LicenseStatus { get; }
    }
}
