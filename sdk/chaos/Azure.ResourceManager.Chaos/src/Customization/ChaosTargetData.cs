// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Chaos.Models;

namespace Azure.ResourceManager.Chaos
{
    public partial class ChaosTargetData
    {
        /// <summary> Initializes a new instance of <see cref="ChaosTargetData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Location of the target resource. </param>
        /// <param name="properties"> The properties of the target resource. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor no longer works in all API versions.", false)]
        internal ChaosTargetData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, AzureLocation? location, IDictionary<string, BinaryData> properties, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Location = location;
            Properties = properties;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
    }
}
