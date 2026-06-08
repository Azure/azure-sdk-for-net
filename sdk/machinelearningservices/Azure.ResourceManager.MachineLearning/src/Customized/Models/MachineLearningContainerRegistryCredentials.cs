// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserve the legacy factory overload parameter type during TypeSpec migration.
    public partial class MachineLearningContainerRegistryCredentials : RegistryListCredentialsResult, IJsonModel<MachineLearningContainerRegistryCredentials>
    {
        internal MachineLearningContainerRegistryCredentials(AzureLocation? location, string username, IEnumerable<MachineLearningPasswordDetail> passwords)
            : base(location?.ToString(), passwords is null ? null : new List<MachineLearningPasswordDetail>(passwords), username, additionalBinaryDataProperties: null)
        {
        }

        /// <summary> The location of the workspace ACR. </summary>
        [WirePath("location")]
        public new AzureLocation? Location => base.Location is null ? null : new AzureLocation(base.Location);

        /// <summary> Gets the passwords. </summary>
        [WirePath("passwords")]
        public new IReadOnlyList<MachineLearningPasswordDetail> Passwords => base.Passwords is null ? null : new List<MachineLearningPasswordDetail>(base.Passwords);

        internal static MachineLearningContainerRegistryCredentials DeserializeMachineLearningContainerRegistryCredentials(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string location = default;
            IList<MachineLearningPasswordDetail> passwords = default;
            string username = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("location"u8))
                {
                    location = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("passwords"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }

                    List<MachineLearningPasswordDetail> array = new List<MachineLearningPasswordDetail>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(MachineLearningPasswordDetail.DeserializeMachineLearningPasswordDetail(item, options));
                    }
                    passwords = array;
                    continue;
                }
                if (prop.NameEquals("username"u8))
                {
                    username = prop.Value.GetString();
                }
            }

            return new MachineLearningContainerRegistryCredentials(location is null ? null : new AzureLocation(location), username, passwords ?? new ChangeTrackingList<MachineLearningPasswordDetail>());
        }

        void IJsonModel<MachineLearningContainerRegistryCredentials>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<RegistryListCredentialsResult>)this).Write(writer, options);
        }

        MachineLearningContainerRegistryCredentials IJsonModel<MachineLearningContainerRegistryCredentials>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningContainerRegistryCredentials(document.RootElement, options);
        }

        BinaryData IPersistableModel<MachineLearningContainerRegistryCredentials>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<RegistryListCredentialsResult>)this).Write(options);
        }

        MachineLearningContainerRegistryCredentials IPersistableModel<MachineLearningContainerRegistryCredentials>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningContainerRegistryCredentials>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeMachineLearningContainerRegistryCredentials(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningContainerRegistryCredentials)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningContainerRegistryCredentials>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
