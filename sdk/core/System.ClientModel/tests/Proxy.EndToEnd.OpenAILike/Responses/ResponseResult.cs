// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAILike.Responses
{
    /// <summary>
    /// Mock response model. Like generated models, it reads its nested <see cref="ResponseTool"/> values with the
    /// <see cref="ModelReaderWriterOptions"/> it was given, so proxies carried by those options apply to each tool.
    /// </summary>
    public class ResponseResult : IJsonModel<ResponseResult>
    {
        internal ResponseResult(string? id, string? model, IList<ResponseTool> tools)
        {
            Id = id;
            Model = model;
            Tools = tools;
        }

        public string? Id { get; }

        public string? Model { get; }

        public IList<ResponseTool> Tools { get; }

        internal static ResponseResult DeserializeResponseResult(JsonElement element, ModelReaderWriterOptions? options = null)
        {
            options ??= ModelReaderWriterOptions.Json;
            string? id = null;
            string? model = null;
            var tools = new List<ResponseTool>();

            foreach (JsonProperty property in element.EnumerateObject())
            {
                switch (property.Name)
                {
                    case "id":
                        id = property.Value.GetString();
                        break;
                    case "model":
                        model = property.Value.GetString();
                        break;
                    case "tools":
                        foreach (JsonElement item in property.Value.EnumerateArray())
                        {
                            tools.Add(ModelReaderWriter.Read<ResponseTool>(
                                BinaryData.FromString(item.GetRawText()), options, ResponseToolsContext.Default)!);
                        }
                        break;
                }
            }

            return new ResponseResult(id, model, tools);
        }

        void IJsonModel<ResponseResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("id"u8, Id);
            writer.WriteString("model"u8, Model);
            writer.WritePropertyName("tools"u8);
            writer.WriteStartArray();
            foreach (ResponseTool tool in Tools)
            {
                writer.WriteRawValue(ModelReaderWriter.Write(tool, options, ResponseToolsContext.Default));
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        ResponseResult IJsonModel<ResponseResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeResponseResult(document.RootElement, options);
        }

        BinaryData IPersistableModel<ResponseResult>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(this, options, ResponseToolsContext.Default);

        ResponseResult IPersistableModel<ResponseResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeResponseResult(document.RootElement, options);
        }

        string IPersistableModel<ResponseResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
