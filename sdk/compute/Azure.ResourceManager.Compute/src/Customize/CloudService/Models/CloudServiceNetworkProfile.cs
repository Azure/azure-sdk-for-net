// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceNetworkProfile : IJsonModel<CloudServiceNetworkProfile>, IPersistableModel<CloudServiceNetworkProfile>
    {
        /// <summary> Initializes a new instance of CloudServiceNetworkProfile. </summary>
        public CloudServiceNetworkProfile()
        {
        }

        /// <summary> The load balancer configurations. </summary>
        public IList<CloudServiceLoadBalancerConfiguration> LoadBalancerConfigurations { get; set; }

        /// <summary> The swappable cloud service ID. </summary>
        public ResourceIdentifier SwappableCloudServiceId { get; set; }

        /// <summary> The slot type. </summary>
        public CloudServiceSlotType? SlotType { get; set; }

        CloudServiceNetworkProfile IJsonModel<CloudServiceNetworkProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<CloudServiceNetworkProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceNetworkProfile IPersistableModel<CloudServiceNetworkProfile>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<CloudServiceNetworkProfile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<CloudServiceNetworkProfile>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
