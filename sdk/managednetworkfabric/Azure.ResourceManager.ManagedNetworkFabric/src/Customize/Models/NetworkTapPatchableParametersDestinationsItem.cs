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
    /// <summary> The NetworkTapPatchableParametersDestinationsItem. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future version. Use NetworkTapDestinationProperties instead.")]
    public partial class NetworkTapPatchableParametersDestinationsItem : NetworkTapDestinationProperties, IJsonModel<NetworkTapPatchableParametersDestinationsItem>, IPersistableModel<NetworkTapPatchableParametersDestinationsItem>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkTapPatchableParametersDestinationsItem"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkTapPatchableParametersDestinationsItem() : this(default, default, default)
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkTapPatchableParametersDestinationsItem"/>. </summary>
        /// <param name="name"> Destination name. </param>
        /// <param name="destinationType"> Type of destination. Input can be IsolationDomain or Direct. </param>
        /// <param name="destinationId"> The destination Id. ARM Resource ID of either NNI or Internal Networks. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkTapPatchableParametersDestinationsItem(string name, NetworkTapDestinationType? destinationType, ResourceIdentifier destinationId) : base(name, destinationType, destinationId, default, default, additionalBinaryDataProperties: null)
        {
        }

        internal NetworkTapPatchableParametersDestinationsItem(string name, NetworkTapDestinationType? destinationType, ResourceIdentifier destinationId, IsolationDomainProperties isolationDomainProperties, ResourceIdentifier destinationTapRuleId, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(name, destinationType, destinationId, isolationDomainProperties, destinationTapRuleId, additionalBinaryDataProperties)
        {
        }

        void IJsonModel<NetworkTapPatchableParametersDestinationsItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<NetworkTapDestinationProperties>)this).Write(writer, options);

        NetworkTapPatchableParametersDestinationsItem IJsonModel<NetworkTapPatchableParametersDestinationsItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => FromDestinationProperties(((IJsonModel<NetworkTapDestinationProperties>)this).Create(ref reader, options));

        BinaryData IPersistableModel<NetworkTapPatchableParametersDestinationsItem>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<NetworkTapDestinationProperties>)this).Write(options);

        NetworkTapPatchableParametersDestinationsItem IPersistableModel<NetworkTapPatchableParametersDestinationsItem>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromDestinationProperties(((IPersistableModel<NetworkTapDestinationProperties>)this).Create(data, options));

        string IPersistableModel<NetworkTapPatchableParametersDestinationsItem>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<NetworkTapDestinationProperties>)this).GetFormatFromOptions(options);

        internal static NetworkTapPatchableParametersDestinationsItem FromDestinationProperties(NetworkTapDestinationProperties value)
            => value is null ? null : value as NetworkTapPatchableParametersDestinationsItem ?? new NetworkTapPatchableParametersDestinationsItem(
                value.Name,
                value.DestinationType,
                value.DestinationId,
                value.IsolationDomainProperties,
                value.DestinationTapRuleId,
                additionalBinaryDataProperties: null);
    }
}
