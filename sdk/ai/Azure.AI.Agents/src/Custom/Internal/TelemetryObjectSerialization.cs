// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Azure.AI.Agents;

// The set of helper classes to serialize the event object.

internal class EventContent
{
    public string content { get; set; }
    public EventContent(string content) { this.content = content; }
}

internal class EventRole
{
    public string role { get; set; }
    public EventRole(string role) { this.role = role; }
}

internal class EventContentRole
{
    public string content { get; set; }
    public string role { get; set; }
    public EventContentRole(string content, string role)
    {
        this.content = content;
        this.role = role;
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

[JsonSerializable(typeof(EventContentId))]
[JsonSerializable(typeof(EventContentRole))]
[JsonSerializable(typeof(EventRole))]
[JsonSerializable(typeof(EventContent))]
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
