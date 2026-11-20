// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Recommender.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.Recommender
{
    // TODO: Remove this workaround when https://github.com/Azure/azure-sdk-for-net/issues/64741 is fixed.
    [CodeGenSuppress("ComputeRecommenderDiagnosticSupportedResourceTypes")]
    [CodeGenSuppress("JsonModelWriteCore", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    public partial class ComputePlacementScoresData
    {
        private IList<string> _missingSupportedResourceTypes;

        /// <summary> Describes the supported resource types for placement scoring. </summary>
        public IList<string> ComputeRecommenderDiagnosticSupportedResourceTypes =>
            Properties?.ComputeRecommenderDiagnosticSupportedResourceTypes ?? (_missingSupportedResourceTypes ??= new ChangeTrackingList<string>());

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ComputePlacementScoresData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ComputePlacementScoresData)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            var properties = Properties;
            if (properties is null && _missingSupportedResourceTypes != null && Optional.IsCollectionDefined(_missingSupportedResourceTypes))
            {
                properties = new ComputeRecommenderPlacementScoresProperties(_missingSupportedResourceTypes, null);
            }
            if (Optional.IsDefined(properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(properties, options);
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
    }
}
