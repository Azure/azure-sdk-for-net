// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent;

public partial class MessageAttachment
{
    /// <summary> Initializes a new instance of the <see cref="MessageAttachment"/> class from a vector store data source. </summary>
    /// <param name="ds"> The vector store data source for the attachment. </param>
    /// <param name="tools"> The tools associated with this attachment. </param>
    public MessageAttachment(VectorStoreDataSource ds, List<ToolDefinition> tools)
    {
        FileId = null;
        DataSource = ds;
        Tools = serializeJson(tools);
        _additionalBinaryDataProperties = null;
    }

    /// <summary> Initializes a new instance of the <see cref="MessageAttachment"/> class from a file identifier. </summary>
    /// <param name="fileId"> The identifier of the file to attach. </param>
    /// <param name="tools"> The tools associated with this attachment. </param>
    public MessageAttachment(string fileId, List<ToolDefinition> tools)
    {
        FileId = fileId;
        DataSource = null;
        Tools = serializeJson(tools);
        _additionalBinaryDataProperties = null;
    }

    private static List<BinaryData> serializeJson<T>(List<T> definitions) where T : IJsonModel<T>
    {
        List<BinaryData> serializedDefinitions = new();
        foreach (IJsonModel<T> definition in definitions)
        {
            var stream = new MemoryStream();
            var writer = new Utf8JsonWriter(stream);
            definition.Write(writer, ModelReaderWriterOptions.Json);
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            serializedDefinitions.Add(new BinaryData(json));
        }
        return serializedDefinitions;
    }
}
