// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.ConfidentialLedger.Certificate
{
    /// <summary> Identity information for a Confidential Ledger instance. </summary>
    public partial class LedgerIdentityInformation : IJsonModel<LedgerIdentityInformation>
    {
        private readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="LedgerIdentityInformation"/> for deserialization. </summary>
        internal LedgerIdentityInformation()
        {
        }

        internal LedgerIdentityInformation(string ledgerId, string ledgerTlsCertificate, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            LedgerId = ledgerId;
            LedgerTlsCertificate = ledgerTlsCertificate;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Id for the ledger. </summary>
        public string LedgerId { get; }

        /// <summary> PEM-encoded certificate used for TLS by the Confidential Ledger. </summary>
        public string LedgerTlsCertificate { get; }

        /// <param name="response"> The <see cref="Response"/> to deserialize the <see cref="LedgerIdentityInformation"/> from. </param>
        public static explicit operator LedgerIdentityInformation(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeLedgerIdentityInformation(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        void IJsonModel<LedgerIdentityInformation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = GetFormat(options);
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LedgerIdentityInformation)} does not support writing '{format}' format.");
            }
            if (LedgerId != null)
            {
                writer.WritePropertyName("ledgerId"u8);
                writer.WriteStringValue(LedgerId);
            }
            if (LedgerTlsCertificate != null)
            {
                writer.WritePropertyName("ledgerTlsCertificate"u8);
                writer.WriteStringValue(LedgerTlsCertificate);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        LedgerIdentityInformation IJsonModel<LedgerIdentityInformation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual LedgerIdentityInformation JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = GetFormat(options);
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LedgerIdentityInformation)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLedgerIdentityInformation(document.RootElement, options);
        }

        BinaryData IPersistableModel<LedgerIdentityInformation>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = GetFormat(options);
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureSecurityConfidentialLedgerContext.Default),
                _ => throw new FormatException($"The model {nameof(LedgerIdentityInformation)} does not support writing '{options.Format}' format."),
            };
        }

        LedgerIdentityInformation IPersistableModel<LedgerIdentityInformation>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual LedgerIdentityInformation PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = GetFormat(options);
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LedgerIdentityInformation)} does not support reading '{options.Format}' format.");
            }
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeLedgerIdentityInformation(document.RootElement, options);
        }

        string IPersistableModel<LedgerIdentityInformation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private string GetFormat(ModelReaderWriterOptions options) =>
            options.Format == "W" ? ((IPersistableModel<LedgerIdentityInformation>)this).GetFormatFromOptions(options) : options.Format;

        internal static LedgerIdentityInformation DeserializeLedgerIdentityInformation(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string ledgerId = default;
            string ledgerTlsCertificate = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("ledgerId"u8))
                {
                    ledgerId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("ledgerTlsCertificate"u8))
                {
                    ledgerTlsCertificate = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, prop.Value.GetUtf8Bytes());
                }
            }
            return new LedgerIdentityInformation(ledgerId, ledgerTlsCertificate, additionalBinaryDataProperties);
        }
    }
}
