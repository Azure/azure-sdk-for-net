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
    public partial class CloudServiceLoadBalancerConfiguration : IJsonModel<CloudServiceLoadBalancerConfiguration>, IPersistableModel<CloudServiceLoadBalancerConfiguration>
    {
        /// <summary> Initializes a new instance of CloudServiceLoadBalancerConfiguration. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="frontendIPConfigurations"> The frontend IP configurations. </param>
        public CloudServiceLoadBalancerConfiguration(string name, IEnumerable<LoadBalancerFrontendIPConfiguration> frontendIPConfigurations)
        {
            Name = name;
            FrontendIPConfigurations = frontendIPConfigurations != null ? new List<LoadBalancerFrontendIPConfiguration>(frontendIPConfigurations) : new List<LoadBalancerFrontendIPConfiguration>();
        }

        /// <summary> The resource ID. </summary>
        public ResourceIdentifier Id { get; set; }

        /// <summary> The name. </summary>
        public string Name { get; set; }

        /// <summary> The frontend IP configurations. </summary>
        public IList<LoadBalancerFrontendIPConfiguration> FrontendIPConfigurations { get; }

        CloudServiceLoadBalancerConfiguration IJsonModel<CloudServiceLoadBalancerConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<CloudServiceLoadBalancerConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceLoadBalancerConfiguration IPersistableModel<CloudServiceLoadBalancerConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<CloudServiceLoadBalancerConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<CloudServiceLoadBalancerConfiguration>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
