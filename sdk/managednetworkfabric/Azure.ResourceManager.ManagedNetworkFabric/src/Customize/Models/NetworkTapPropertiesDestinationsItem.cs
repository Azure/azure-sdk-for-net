// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The NetworkTapPropertiesDestinationsItem. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future version. Use NetworkTapDestinationProperties instead.")]
    public partial class NetworkTapPropertiesDestinationsItem : NetworkTapDestinationProperties, IJsonModel<NetworkTapPropertiesDestinationsItem>, IPersistableModel<NetworkTapPropertiesDestinationsItem>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkTapPropertiesDestinationsItem"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkTapPropertiesDestinationsItem() : this(default, default, default)
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkTapPropertiesDestinationsItem"/>. </summary>
        /// <param name="name"> Destination name. </param>
        /// <param name="destinationType"> Type of destination. Input can be IsolationDomain or Direct. </param>
        /// <param name="destinationId"> The destination Id. ARM Resource ID of either NNI or Internal Networks. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkTapPropertiesDestinationsItem(string name, NetworkTapDestinationType? destinationType, ResourceIdentifier destinationId) : base(name, destinationType, destinationId, default, default, additionalBinaryDataProperties: null)
        {
        }

        internal NetworkTapPropertiesDestinationsItem(string name, NetworkTapDestinationType? destinationType, ResourceIdentifier destinationId, IsolationDomainProperties isolationDomainProperties, ResourceIdentifier destinationTapRuleId, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(name, destinationType, destinationId, isolationDomainProperties, destinationTapRuleId, additionalBinaryDataProperties)
        {
        }

        void IJsonModel<NetworkTapPropertiesDestinationsItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<NetworkTapDestinationProperties>)this).Write(writer, options);

        NetworkTapPropertiesDestinationsItem IJsonModel<NetworkTapPropertiesDestinationsItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => FromDestinationProperties(((IJsonModel<NetworkTapDestinationProperties>)this).Create(ref reader, options));

        BinaryData IPersistableModel<NetworkTapPropertiesDestinationsItem>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<NetworkTapDestinationProperties>)this).Write(options);

        NetworkTapPropertiesDestinationsItem IPersistableModel<NetworkTapPropertiesDestinationsItem>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromDestinationProperties(((IPersistableModel<NetworkTapDestinationProperties>)this).Create(data, options));

        string IPersistableModel<NetworkTapPropertiesDestinationsItem>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<NetworkTapDestinationProperties>)this).GetFormatFromOptions(options);

        internal static NetworkTapPropertiesDestinationsItem FromDestinationProperties(NetworkTapDestinationProperties value)
            => value is null ? null : value as NetworkTapPropertiesDestinationsItem ?? new NetworkTapPropertiesDestinationsItem(
                value.Name,
                value.DestinationType,
                value.DestinationId,
                value.IsolationDomainProperties,
                value.DestinationTapRuleId,
                additionalBinaryDataProperties: null);
    }
}
