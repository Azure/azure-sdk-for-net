// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Back-compat: 1.4.0 GA exposed InstanceSize/InstanceCount/ServiceType as top-level
    // { get; set; } via x-ms-client-flatten. MPG cannot synthesize lazy-create setters
    // because the inner ServiceResourceCreateUpdateProperties is `@discriminator("serviceType")`
    // (an abstract polymorphic base) — BuildSetterForSafeFlatten has no concrete derived
    // type to instantiate without already knowing the desired serviceType. We considered
    // @@usage(input|output) on the inner model in client.tsp but verified empirically that
    // it does not change implicit-flatten emission for TrackedResource + OmitProperties
    // wrappers. The caller must assign `Properties` (a typed derived class, e.g.
    // DataTransferServiceResourceCreateUpdateProperties) before using these proxies;
    // each setter delegates straight to Properties and lets a natural NullReferenceException
    // surface if Properties hasn't been assigned yet. ServiceType additionally rejects null
    // because the inner discriminator field is non-nullable.
    // TODO: revisit when https://github.com/Azure/azure-sdk-for-net/issues/59498 is fixed.
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
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "ServiceType is the polymorphism discriminator on ServiceResourceCreateUpdateProperties and cannot be set to null.");
                }
                Properties.ServiceType = value.Value;
            }
        }
    }
}
