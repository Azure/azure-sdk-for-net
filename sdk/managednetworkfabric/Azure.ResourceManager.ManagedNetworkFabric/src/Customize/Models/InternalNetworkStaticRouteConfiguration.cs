// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.ManagedNetworkFabric;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shim for the TypeSpec migration. The service model now uses
    // StaticRouteConfiguration directly; keep the shipped derived type hidden for compatibility.
    /// <summary> Static Route Configuration properties. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future version. Use StaticRouteConfiguration instead.")]
    public partial class InternalNetworkStaticRouteConfiguration : StaticRouteConfiguration, IJsonModel<InternalNetworkStaticRouteConfiguration>, IPersistableModel<InternalNetworkStaticRouteConfiguration>
    {
        /// <summary> Initializes a new instance of <see cref="InternalNetworkStaticRouteConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InternalNetworkStaticRouteConfiguration()
        {
        }

        internal InternalNetworkStaticRouteConfiguration(BfdConfiguration bfdConfiguration, IList<StaticRouteProperties> iPv4Routes, IList<StaticRouteProperties> iPv6Routes, StaticRouteConfigurationExtension? extension, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(bfdConfiguration, iPv4Routes, iPv6Routes, extension, additionalBinaryDataProperties)
        {
        }

        void IJsonModel<InternalNetworkStaticRouteConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<StaticRouteConfiguration>)this).Write(writer, options);

        InternalNetworkStaticRouteConfiguration IJsonModel<InternalNetworkStaticRouteConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => FromStaticRouteConfiguration(((IJsonModel<StaticRouteConfiguration>)this).Create(ref reader, options));

        BinaryData IPersistableModel<InternalNetworkStaticRouteConfiguration>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<StaticRouteConfiguration>)this).Write(options);

        InternalNetworkStaticRouteConfiguration IPersistableModel<InternalNetworkStaticRouteConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromStaticRouteConfiguration(((IPersistableModel<StaticRouteConfiguration>)this).Create(data, options));

        string IPersistableModel<InternalNetworkStaticRouteConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<StaticRouteConfiguration>)this).GetFormatFromOptions(options);

        internal static InternalNetworkStaticRouteConfiguration FromStaticRouteConfiguration(StaticRouteConfiguration value)
            => value is null ? null : new InternalNetworkStaticRouteConfiguration(
                value.BfdConfiguration,
                value.IPv4Routes,
                value.IPv6Routes,
                value.Extension,
                additionalBinaryDataProperties: null);
    }
}
