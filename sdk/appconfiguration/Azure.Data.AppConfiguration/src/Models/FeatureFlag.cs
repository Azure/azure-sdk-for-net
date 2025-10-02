// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Renamed.
    // - Renamed properties.
    // - Apply custom serialization for ETag property.
    /// <summary>
    /// A setting, defined by a unique combination of a key and label.
    /// </summary>
    [CodeGenSerialization(nameof(ETag), SerializationValueHook = nameof(SerializationEtag), DeserializationValueHook = nameof(DeserializeEtag))]
    public partial class FeatureFlag
    {
        /// <summary>
        /// An ETag indicating the state of a configuration setting within a configuration store.
        /// </summary>
        [CodeGenMember("Etag")]
        public ETag ETag { get; internal set; }

        private void SerializationEtag(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => writer.WriteString("etag", ETag.ToString());

        private static void DeserializeEtag(JsonProperty property, ref ETag val)
            => val = new ETag(property.Value.GetString());
    }
}
