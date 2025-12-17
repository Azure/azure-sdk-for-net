// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HardwareSecurityModules.Models
{
    public static partial class ArmHardwareSecurityModulesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="HardwareSecurityModules.DedicatedHsmData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> SKU details. </param>
        /// <param name="zones"> The availability zones. </param>
        /// <param name="properties"> Properties of the dedicated HSM. </param>
        /// <returns> A new <see cref="HardwareSecurityModules.DedicatedHsmData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DedicatedHsmData DedicatedHsmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, DedicatedHsmSkuName? skuName, IEnumerable<string> zones = null, DedicatedHsmProperties properties = null)
            => DedicatedHsmData(id, name, resourceType, systemData, tags, location, properties, skuName, zones);
    }
}
