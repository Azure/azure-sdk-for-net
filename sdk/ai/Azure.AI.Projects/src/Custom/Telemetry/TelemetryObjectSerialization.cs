// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.Projects;

// The set of helper classes to serialize the event object.

internal class EventContent
{
    public string type { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string content { get; set; }
    public EventContent(string content)
    {
        this.type = "text";
        this.content = content;
    }
}

internal class EventContentId
{
    public string content { get; set; }
    public string id { get; set; }
    public EventContentId(string content, string id)
    {
        this.content = content;
        this.id = id;
    }
}

internal class WorkflowEventContent
{
    public string type { get; set; }
    public string content { get; set; }
    public WorkflowEventContent(string content)
    {
        this.type = "workflow";
        this.content = content;
    }
}

[JsonSerializable(typeof(EventContentId))]
[JsonSerializable(typeof(EventContent))]
[JsonSerializable(typeof(EventContent[]))]
[JsonSerializable(typeof(WorkflowEventContent))]
[JsonSerializable(typeof(WorkflowEventContent[]))]
[JsonSerializable(typeof(Dictionary<string, string>))]
internal partial class EventsContext : JsonSerializerContext
{
    private JsonSerializerOptions _options;

    public new JsonSerializerOptions Options
    {
        get
        {
            JsonSerializerOptions options = _options;

            if (options is null)
            {
                options = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Allow non-ASCII characters
                    TypeInfoResolver = this
                };
                options.MakeReadOnly();
                _options = options;
            }

            return options;
        }
    }
}
