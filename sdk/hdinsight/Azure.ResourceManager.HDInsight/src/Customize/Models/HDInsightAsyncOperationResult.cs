// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;

namespace Azure.ResourceManager.HDInsight.Models
{
    // This model was removed during TypeSpec migration because the async operation status
    // endpoints were suppressed via @@scope(..., "!csharp") to eliminate phantom sub-resources.
    // It is re-added here as custom code for backward compatibility.
    /// <summary> The azure async operation response. </summary>
    public partial class HDInsightAsyncOperationResult : IJsonModel<HDInsightAsyncOperationResult>, IPersistableModel<HDInsightAsyncOperationResult>
    {
        /// <summary> Initializes a new instance of <see cref="HDInsightAsyncOperationResult"/>. </summary>
        internal HDInsightAsyncOperationResult()
        {
        }

        /// <summary> Initializes a new instance of <see cref="HDInsightAsyncOperationResult"/>. </summary>
        /// <param name="status"> The async operation state. </param>
        /// <param name="error"> The operation error information. </param>
        internal HDInsightAsyncOperationResult(HDInsightAsyncOperationState? status, ResponseError error)
        {
            Status = status;
            Error = error;
        }

        /// <summary> The async operation state. </summary>
        public HDInsightAsyncOperationState? Status { get; }
        /// <summary> The operation error information. </summary>
        public ResponseError Error { get; }

        internal static HDInsightAsyncOperationResult FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeHDInsightAsyncOperationResult(document.RootElement);
        }

        internal static HDInsightAsyncOperationResult DeserializeHDInsightAsyncOperationResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            HDInsightAsyncOperationState? status = default;
            ResponseError errorInfo = default;

            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("status"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new HDInsightAsyncOperationState(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("error"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    errorInfo = ModelReaderWriter.Read<ResponseError>(
                        new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())),
                        ModelSerializationExtensions.WireOptions,
                        AzureResourceManagerHDInsightContext.Default);
                    continue;
                }
            }

            return new HDInsightAsyncOperationResult(status, errorInfo);
        }

        void IJsonModel<HDInsightAsyncOperationResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<HDInsightAsyncOperationResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HDInsightAsyncOperationResult)} does not support writing '{format}' format.");
            }

            if (Status.HasValue)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (Error != null)
            {
                writer.WritePropertyName("error"u8);
                ((IJsonModel<ResponseError>)Error).Write(writer, options);
            }
        }

        HDInsightAsyncOperationResult IJsonModel<HDInsightAsyncOperationResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return JsonModelCreateCore(ref reader, options);
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual HDInsightAsyncOperationResult JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HDInsightAsyncOperationResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HDInsightAsyncOperationResult)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeHDInsightAsyncOperationResult(document.RootElement);
        }

        BinaryData IPersistableModel<HDInsightAsyncOperationResult>.Write(ModelReaderWriterOptions options)
        {
            return PersistableModelWriteCore(options);
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HDInsightAsyncOperationResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerHDInsightContext.Default);
                default:
                    throw new FormatException($"The model {nameof(HDInsightAsyncOperationResult)} does not support writing '{options.Format}' format.");
            }
        }

        HDInsightAsyncOperationResult IPersistableModel<HDInsightAsyncOperationResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            return PersistableModelCreateCore(data, options);
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual HDInsightAsyncOperationResult PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HDInsightAsyncOperationResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeHDInsightAsyncOperationResult(document.RootElement);
                    }
                default:
                    throw new FormatException($"The model {nameof(HDInsightAsyncOperationResult)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<HDInsightAsyncOperationResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
