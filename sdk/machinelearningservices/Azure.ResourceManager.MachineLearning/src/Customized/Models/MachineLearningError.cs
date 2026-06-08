// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Backward-compat type alias for ErrorResponse (ARM common type)
    // Only needed for the backward-compat model factory overload
    public class MachineLearningError : ErrorResponse, IJsonModel<MachineLearningError>
    {
        internal MachineLearningError() : base() { }

        internal MachineLearningError(ResponseError error) : base(error, additionalBinaryDataProperties: null) { }

        void IJsonModel<MachineLearningError>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<ErrorResponse>)this).Write(writer, options);
        }

        MachineLearningError IJsonModel<MachineLearningError>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningError(document.RootElement, options);
        }

        BinaryData IPersistableModel<MachineLearningError>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<ErrorResponse>)this).Write(options);
        }

        MachineLearningError IPersistableModel<MachineLearningError>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningError>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeMachineLearningError(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningError)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningError>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static MachineLearningError DeserializeMachineLearningError(JsonElement element, ModelReaderWriterOptions options)
        {
            ErrorResponse errorResponse = ErrorResponse.DeserializeErrorResponse(element, options);
            return errorResponse is null ? null : new MachineLearningError(errorResponse.Error);
        }
    }
}
