// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Back-compat: 1.4.0 GA exposed InstanceSize/InstanceCount/ServiceType as top-level
    // { get; set; } via x-ms-client-flatten. MPG cannot auto-flatten because the inner
    // ServiceResourceCreateUpdateProperties is `@discriminator("serviceType")` (a polymorphic
    // abstract base with required ctor args), so the setter cannot lazy-construct a Properties
    // instance for the user — there is no concrete derived type to instantiate without already
    // knowing the desired serviceType. The caller therefore must assign `Properties` (a typed
    // derived class, e.g. DataTransferServiceResourceCreateUpdateProperties) before using these
    // proxies; the null guard surfaces this requirement via InvalidOperationException, and the
    // ServiceType setter additionally rejects null to protect the discriminator on the wire.
    public partial class CosmosDBServiceCreateOrUpdateContent
    {
        private const string PropertiesNotInitializedMessage =
            "Properties has not been initialized; assign a ServiceResourceCreateUpdateProperties (or one of its derived types) before setting flattened accessors.";

        /// <summary> Instance type for the service. </summary>
        [WirePath("properties.instanceSize")]
        public CosmosDBServiceSize? InstanceSize
        {
            get
            {
                return this.Properties?.InstanceSize;
            }
            set
            {
                if (this.Properties == null)
                {
                    throw new InvalidOperationException(PropertiesNotInitializedMessage);
                }
                this.Properties.InstanceSize = value;
            }
        }

        /// <summary> Instance count for the service. </summary>
        [WirePath("properties.instanceCount")]
        public int? InstanceCount
        {
            get
            {
                return this.Properties?.InstanceCount;
            }
            set
            {
                if (this.Properties == null)
                {
                    throw new InvalidOperationException(PropertiesNotInitializedMessage);
                }
                this.Properties.InstanceCount = value;
            }
        }

        /// <summary> ServiceType for the service. </summary>
        [WirePath("properties.serviceType")]
        public CosmosDBServiceType? ServiceType
        {
            get
            {
                return this.Properties?.ServiceType;
            }
            set
            {
                if (this.Properties == null)
                {
                    throw new InvalidOperationException(PropertiesNotInitializedMessage);
                }
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "ServiceType is the polymorphism discriminator on ServiceResourceCreateUpdateProperties and cannot be set to null.");
                }
                this.Properties.ServiceType = value.Value;
            }
        }
    }
}
