// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenSuppress("JsonModelWriteCore", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    public partial class ScoringFunction
    {
        /// <summary> Gets or sets the name of the field used as input to the scoring function. </summary>
        public virtual string FieldName { get; set; }

        /// <summary> Gets or sets a multiplier for the raw score. </summary>
        public virtual double Boost { get; set; }

        /// <summary> Initializes a scoring function for a field. </summary>
        /// <param name="fieldName"> The input field name. </param>
        /// <param name="boost"> The score multiplier. </param>
        /// <param name="type"> The scoring function type. </param>
        public ScoringFunction(string fieldName, double boost, string type) : this(fieldName, boost)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        internal ScoringFunction(
            string fieldName,
            double boost,
            ScoringFunctionInterpolation? interpolation,
            string type,
            IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : this(interpolation, type, additionalBinaryDataProperties)
        {
            FieldName = fieldName;
            Boost = boost;
        }

        /// <summary> Writes the common scoring function properties. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The serialization options. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? "J" : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ScoringFunction)} does not support writing '{format}' format.");
            }
            // Concrete classic functions write these properties themselves; random scoring must omit them.
            if (GetType() == typeof(ScoringFunction) || this is UnknownScoringFunction)
            {
                writer.WriteString("fieldName", FieldName);
                writer.WriteNumber("boost", Boost);
            }
            if (Interpolation.HasValue)
            {
                writer.WriteString("interpolation", Interpolation.Value.ToSerialString());
            }
            writer.WriteString("type", Type);
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
                    using JsonDocument document = JsonDocument.Parse(item.Value);
                    document.RootElement.WriteTo(writer);
                }
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ScoringFunction"/> class.
        /// </summary>
        /// <param name="fieldName">The name of the field used as input to the scoring function.</param>
        /// <param name="boost">A multiplier for the raw score. Must be a positive number not equal to 1.0.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        private protected ScoringFunction(string fieldName, double boost)
        {
            FieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
            Boost = boost;
        }
    }
}
