// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    // GA persisted "random" as an unknown function with FieldName and Boost.
    [CodeGenSuppress("DeserializeRandomScoringFunction", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class RandomScoringFunction
    {
        internal static RandomScoringFunction DeserializeRandomScoringFunction(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string type = "random";
            string fieldName = null;
            double boost = default;
            ScoringFunctionInterpolation? interpolation = null;
            RandomScoringParameters parameters = null;
            var additionalProperties = new Dictionary<string, BinaryData>();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                switch (property.Name)
                {
                    case "type":
                        type = property.Value.GetString();
                        break;
                    case "fieldName":
                        fieldName = property.Value.GetString();
                        break;
                    case "boost":
                        boost = property.Value.GetDouble();
                        break;
                    case "interpolation":
                        if (property.Value.ValueKind != JsonValueKind.Null)
                        {
                            interpolation = property.Value.GetString().ToScoringFunctionInterpolation();
                        }
                        break;
                    case "random":
                        if (property.Value.ValueKind != JsonValueKind.Null)
                        {
                            parameters = RandomScoringParameters.DeserializeRandomScoringParameters(property.Value, options);
                        }
                        break;
                    default:
                        if (options.Format != "W")
                        {
                            additionalProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                        }
                        break;
                }
            }

            return new RandomScoringFunction(interpolation, type, additionalProperties, parameters)
            {
                FieldName = fieldName,
                Boost = boost
            };
        }
    }
}
