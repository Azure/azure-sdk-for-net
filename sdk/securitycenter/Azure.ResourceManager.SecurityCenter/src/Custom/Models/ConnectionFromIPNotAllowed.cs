// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The TypeSpec leaf uses Legacy.hierarchyBuilding to share TimeWindow/Allowlist properties through a base model; generated leaf classes therefore get only internal deserialization constructors, not the previous GA public constructor. Keep that constructor and delegate serialization to the generated partial implementation.
    public partial class ConnectionFromIPNotAllowed : IPersistableModel<ConnectionFromIPNotAllowed>
    {
        /// <summary> Initializes a new instance of <see cref="ConnectionFromIPNotAllowed"/>. </summary>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        /// <param name="allowlistValues"> The values to allow. The format of the values depends on the rule type. </param>
        public ConnectionFromIPNotAllowed(bool isEnabled, IEnumerable<string> allowlistValues) : base(isEnabled, allowlistValues)
        {
            RuleType = "ConnectionFromIpNotAllowed";
        }

        ConnectionFromIPNotAllowed IJsonModel<ConnectionFromIPNotAllowed>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (ConnectionFromIPNotAllowed)JsonModelCreateCore(ref reader, options);

        void IJsonModel<ConnectionFromIPNotAllowed>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        ConnectionFromIPNotAllowed IPersistableModel<ConnectionFromIPNotAllowed>.Create(BinaryData data, ModelReaderWriterOptions options) => (ConnectionFromIPNotAllowed)PersistableModelCreateCore(data, options);

        string IPersistableModel<ConnectionFromIPNotAllowed>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<ConnectionFromIPNotAllowed>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    }
}
