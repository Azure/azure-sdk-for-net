// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // CosmosDBServiceCreateOrUpdateContent is generated as a wrapper around a
    // ServiceResourceCreateUpdateProperties envelope (Properties property). The
    // legacy SDK exposed InstanceSize, InstanceCount and ServiceType as top-level
    // read/write properties via x-ms-client-flatten. The MPG generator does not
    // flatten this envelope (the inner properties model is a discriminated base
    // with required ctor args, so @@flattenProperty / BuildSetterForSafeFlatten
    // cannot synthesize lazy-create setters). Re-emit the historical top-level
    // accessors as proxies onto Properties to preserve back-compat without a spec
    // change. The [WirePath] attributes mirror the wire-format paths the legacy
    // AutoRest SDK exposed on the flattened surface.
    public partial class CosmosDBServiceCreateOrUpdateContent
    {
        /// <summary> Instance type for the service. </summary>
        [WirePath("properties.instanceSize")]
        public CosmosDBServiceSize? InstanceSize
        {
            get
            {
                return this.Properties.InstanceSize;
            }
            set
            {
                this.Properties.InstanceSize = value;
            }
        }

        /// <summary> Instance count for the service. </summary>
        [WirePath("properties.instanceCount")]
        public int? InstanceCount
        {
            get
            {
                return this.Properties.InstanceCount;
            }
            set
            {
                this.Properties.InstanceCount = value;
            }
        }

        /// <summary> ServiceType for the service. </summary>
        [WirePath("properties.serviceType")]
        public CosmosDBServiceType? ServiceType
        {
            get
            {
                return this.Properties.ServiceType;
            }
            set
            {
                this.Properties.ServiceType = value.GetValueOrDefault();
            }
        }
    }
}
