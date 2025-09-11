// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.RecoveryServices.Models
{
    public static partial class ArmRecoveryServicesModelFactory
    {
        // Manually provided factory method because VaultPropertiesRedundancySettings has public constructor with settable properties
        /// <summary> Initializes a new instance of <see cref="Models.VaultPropertiesRedundancySettings"/>. </summary>
        /// <param name="standardTierStorageRedundancy"> The storage redundancy setting of a vault. </param>
        /// <param name="crossRegionRestore"> Flag to show if Cross Region Restore is enabled on the Vault or not. </param>
        /// <returns> A new <see cref="Models.VaultPropertiesRedundancySettings"/> instance for mocking. </returns>
        public static VaultPropertiesRedundancySettings VaultPropertiesRedundancySettings(StandardTierStorageRedundancy? standardTierStorageRedundancy = null, CrossRegionRestore? crossRegionRestore = null)
        {
            return new VaultPropertiesRedundancySettings(standardTierStorageRedundancy, crossRegionRestore, serializedAdditionalRawData: null);
        }
    }
}
