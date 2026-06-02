// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Back-compat flat shims: 1.4.0 GA exposed InstanceSize/InstanceCount/ServiceType
    // as top-level get/set on the wrapper. This wrapper does not carry
    // @@usage(input|output) (it isn't safe-flatten-promoted), so the generator emits
    // get-only proxies; re-expose them with setters that write through to Properties.
    /// <summary> Parameters for Create or Update request for ServiceResource. </summary>
    public partial class CosmosDBServiceCreateOrUpdateContent
    {
        /// <summary> Instance type for the service. </summary>
        [WirePath("properties.instanceSize")]
        public CosmosDBServiceSize? InstanceSize
        {
            get => Properties?.InstanceSize;
            set => Properties.InstanceSize = value;
        }

        /// <summary> Instance count for the service. </summary>
        [WirePath("properties.instanceCount")]
        public int? InstanceCount
        {
            get => Properties?.InstanceCount;
            set => Properties.InstanceCount = value;
        }

        /// <summary> ServiceType for the service. </summary>
        [WirePath("properties.serviceType")]
        public CosmosDBServiceType? ServiceType
        {
            get => Properties?.ServiceType;
            set
            {
                Properties.ServiceType = value.GetValueOrDefault();
            }
        }
    }
}
