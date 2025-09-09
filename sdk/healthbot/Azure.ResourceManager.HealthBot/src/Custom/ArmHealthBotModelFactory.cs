// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HealthBot.Models
{
    // Add custom overloads to the model factory for HealthBotData due to the properties order changes in TypeSpec
    public static partial class ArmHealthBotModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="HealthBot.HealthBotData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> SKU of the Azure Health Bot. </param>
        /// <param name="identity"> The identity of the Azure Health Bot. </param>
        /// <param name="properties"> The set of properties specific to Azure Health Bot resource. </param>
        /// <returns> A new <see cref="HealthBot.HealthBotData"/> instance for mocking. </returns>
        public static HealthBotData HealthBotData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, HealthBotSkuName? skuName = null, ManagedServiceIdentity identity = null, HealthBotProperties properties = null)
            => HealthBotData(id, name, resourceType, systemData, tags, location, properties, skuName, identity);
    }
}
