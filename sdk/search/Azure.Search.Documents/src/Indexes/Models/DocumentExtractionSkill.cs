// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class DocumentExtractionSkill
    {
        /// <summary> A dictionary of configurations for the skill. </summary>
        public IDictionary<string, object> Configuration { get; }

        /// <summary> The type of data to be extracted for the skill. Will be set to &apos;contentAndMetadata&apos; if not defined. </summary>
        [CodeGenMember("DataToExtract")]
        public BlobIndexerDataToExtract? DataToExtract { get; set; }

        /// <summary> The parsingMode for the skill. Will be set to &apos;default&apos; if not defined. </summary>
        [CodeGenMember("ParsingMode")]
        public BlobIndexerParsingMode? ParsingMode { get; set; }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static DocumentExtractionSkill DeserializeDocumentExtractionSkill(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string odataType = "#Microsoft.Skills.Util.DocumentExtractionSkill";
            string name = default;
            string description = default;
            string context = default;
            IList<InputFieldMappingEntry> inputs = default;
            IList<OutputFieldMappingEntry> outputs = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            BlobIndexerParsingMode? parsingMode = default;
            BlobIndexerDataToExtract? dataToExtract = default;
            IDictionary<string, object> configuration = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("@odata.type"u8))
                {
                    odataType = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("description"u8))
                {
                    description = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("context"u8))
                {
                    context = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("inputs"u8))
                {
                    List<InputFieldMappingEntry> array = new List<InputFieldMappingEntry>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(InputFieldMappingEntry.DeserializeInputFieldMappingEntry(item, options));
                    }
                    inputs = array;
                    continue;
                }
                if (prop.NameEquals("outputs"u8))
                {
                    List<OutputFieldMappingEntry> array = new List<OutputFieldMappingEntry>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(OutputFieldMappingEntry.DeserializeOutputFieldMappingEntry(item, options));
                    }
                    outputs = array;
                    continue;
                }
                if (prop.NameEquals("parsingMode"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        parsingMode = null;
                        continue;
                    }
                    parsingMode = new BlobIndexerParsingMode(prop.Value.ToString());
                    continue;
                }
                if (prop.NameEquals("dataToExtract"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        dataToExtract = null;
                        continue;
                    }
                    dataToExtract = new BlobIndexerDataToExtract(prop.Value.ToString());
                    continue;
                }
                if (prop.NameEquals("configuration"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(prop0.Name, prop0.Value.GetObject());
                        }
                    }
                    configuration = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new DocumentExtractionSkill(
                odataType,
                name,
                description,
                context,
                inputs,
                outputs,
                additionalBinaryDataProperties,
                parsingMode,
                dataToExtract,
                configuration ?? new ChangeTrackingDictionary<string, object>());
        }
    }
}
