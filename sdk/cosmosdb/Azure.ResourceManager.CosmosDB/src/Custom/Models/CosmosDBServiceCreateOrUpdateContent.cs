// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
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
    //
    // Setters guard against a null Properties holder rather than throwing the
    // less actionable NullReferenceException. ServiceType is additionally guarded
    // against a null assignment because it is the polymorphism discriminator on
    // the inner ServiceResourceCreateUpdateProperties model; silently coercing
    // null to the default enum value would corrupt the request body.
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
