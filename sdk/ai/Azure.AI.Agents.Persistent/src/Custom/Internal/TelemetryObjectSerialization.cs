// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.Agents.Persistent;

// The set of helper classes to serialize the event object.

internal class EventContent
{
    public string content { get; set; }
    public EventContent(string content) {  this.content = content; }
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

internal class BasicToolCallAttributes
{
    public string id { get; set; } = "";
    public string type { get; set; } = "";
    public BasicToolCallAttributes(string id, string type)
    {
        this.id = id;
        this.type = type;
    }
}

internal class FunctionCall
{
    public string name { get; set; }
    public Dictionary<string, string> arguments { get; set; }
    public FunctionCall(string name, Dictionary<string, string> arguments)
    {
        this.name = name;
        this.arguments = arguments;
    }
}

internal class FunctionToolCallEvent: BasicToolCallAttributes
{
    public FunctionCall function { get; set; }
    public FunctionToolCallEvent(string id, string type, FunctionCall function) : base(id, type)
    {
        this.function = function;
    }
}

//internal class CodeInterpreterOutputBase

internal class CodeInterpreterCallEvent : BasicToolCallAttributes
{
    public string input { get; set; }
    public IReadOnlyList<RunStepCodeInterpreterToolCallOutput> outputs { get; set; }
    public CodeInterpreterCallEvent(string id, string type, string input, IReadOnlyList<RunStepCodeInterpreterToolCallOutput> outputs) : base(id, type)
    {
        this.input = input;
        this.outputs = outputs;
    }
}

internal class BingGrounding : BasicToolCallAttributes
{
    public IReadOnlyDictionary<string, string> bing_grounding { get; set; }
    public BingGrounding(string id, string type, IReadOnlyDictionary<string, string> details) : base(id, type)
    {
        this.bing_grounding = details;
    }
}

internal class GenericToolCallEvent : BasicToolCallAttributes
{
    public IReadOnlyDictionary<string, string> details { get; set; }
    public GenericToolCallEvent(string id, string type, IReadOnlyDictionary<string, string> details) : base(id, type)
    {
        this.details = details;
    }
}

internal class ToolCallAttribute
{
    public List<JsonElement> tool_calls { get; set; }
    public ToolCallAttribute(List<JsonElement> tool_calls)
    {
        this.tool_calls = tool_calls;
    }
}

internal class ThreadMessageEventAttributes
{
    public string role { get; set; }

    public MessageIncompleteDetails incomplete_details { get; set; }
    public Dictionary<string, Dictionary<string, string>> content { get; set; }
    public IReadOnlyList<IReadOnlyDictionary<string, object>> attachments { get; set; }
    public ThreadMessageEventAttributes(
        string role,
        Dictionary<string, Dictionary<string, string>> content = null,
        IReadOnlyList<IReadOnlyDictionary<string, object>> attachments = null,
        MessageIncompleteDetails incompleteDetails = null
        )
    {
        this.content = content;
        this.attachments = attachments;
        this.incomplete_details = incompleteDetails;
        this.role = role;
    }
}

[JsonSerializable(typeof(EventContentId))]
[JsonSerializable(typeof(EventContentRole))]
[JsonSerializable(typeof(EventRole))]
[JsonSerializable(typeof(EventContent))]
[JsonSerializable(typeof(Dictionary<string, string>))]
[JsonSerializable(typeof(ToolCallAttribute))]
[JsonSerializable(typeof(ThreadMessageEventAttributes))]
// Specific tool call events
[JsonSerializable(typeof(BasicToolCallAttributes))]
[JsonSerializable(typeof(FunctionToolCallEvent))]
[JsonSerializable(typeof(CodeInterpreterCallEvent))]
[JsonSerializable(typeof(BingGrounding))]
[JsonSerializable(typeof(GenericToolCallEvent))]
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
