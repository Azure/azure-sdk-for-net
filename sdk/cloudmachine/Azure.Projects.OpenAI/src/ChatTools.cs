// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenAI.Chat;

namespace Azure.Projects.OpenAI;

/// <summary> The service client for the OpenAI Chat Completions endpoint. </summary>
public class ChatTools
{
    private static readonly BinaryData s_noparams = BinaryData.FromString("""{ "type" : "object", "properties" : {} }""");

    private readonly Dictionary<string, MethodInfo> _methods = [];
    private readonly Dictionary<string, Func<string, BinaryData, Task<BinaryData>>> _mcpMethods = [];
    private readonly List<ChatTool> _definitions = [];

    private List<McpClient> _mcpClients = [];
    private Dictionary<string, McpClient> _mcpClientsByEndpoint = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatTools"/> class.
    /// </summary>
    /// <param name="tools"></param>
    public ChatTools(params Type[] tools)
    {
        foreach (Type functionHolder in tools)
            Add(functionHolder);
    }

    /// <summary>
    /// Adds a new MCP Server connection to be used for function calls.
    /// </summary>
    /// <param name="serverEndpoint">The Uri of the MCP Server.</param>
    public async Task AddMcpServerAsync(Uri serverEndpoint)
    {
        var client = new McpClient(serverEndpoint);
        _mcpClientsByEndpoint[serverEndpoint.AbsoluteUri] = client;
        await client.StartAsync().ConfigureAwait(false);
        BinaryData tools = await client.ListToolsAsync().ConfigureAwait(false);
        Add(tools, client);
        _mcpClients.Add(client);
    }

    /// <summary>
    /// Gets the tool definitions.
    /// </summary>
    public IList<ChatTool> Definitions => _definitions;

    /// <summary>
    /// Implicitly converts a <see cref="ChatTools"/> to <see cref="ChatCompletionOptions"/>.
    /// </summary>
    /// <param name="tools"></param>
    public static implicit operator ChatCompletionOptions(ChatTools tools)
    {
        ChatCompletionOptions options = new();
        foreach (ChatTool tool in tools.Definitions)
        {
            options.Tools.Add(tool);
        }
        return options;
    }

    /// <summary>
    /// Adds tool definitions from a JSON array in BinaryData format.
    /// </summary>
    /// <param name="toolDefinitions">BinaryData containing a JSON array of tool definitions</param>
    /// <param name="client">The McpClient.</param>
    /// <exception cref="ArgumentNullException">Thrown when toolDefinitions is null</exception>
    /// <exception cref="JsonException">Thrown when JSON parsing fails</exception>
    internal void Add(BinaryData toolDefinitions, McpClient client)
    {
        using var document = JsonDocument.Parse(toolDefinitions);
        if (!document.RootElement.TryGetProperty("tools", out JsonElement toolsElement))
        {
            throw new JsonException("The JSON document must contain a 'tools' array.");
        }

        var tools = toolsElement.EnumerateArray();
        // the replacement is to deal with OpenAI's tool name regex validation.
        var serverKey = client.ServerEndpoint.AbsoluteUri.Replace('/', '_').Replace(':', '_');

        foreach (var tool in tools)
        {
            var name = $"{serverKey}__.__{tool.GetProperty("name").GetString()!}";
            var description = tool.GetProperty("description").GetString()!;
            var inputSchema = tool.GetProperty("inputSchema").GetRawText();

            var chatTool = ChatTool.CreateFunctionTool(
                name,
                description,
                BinaryData.FromString(inputSchema));

            _definitions.Add(chatTool);

            _mcpMethods[name] = client.CallToolAsync;
        }
    }

    /// <summary>
    /// Adds a set of functions to the chat functions.
    /// </summary>
    /// <param name="functions"></param>
    public void Add(Type functions)
    {
        foreach (MethodInfo function in functions.GetMethods(BindingFlags.Public | BindingFlags.Static))
        {
            Add(function);
        }
    }

    /// <summary>
    /// Adds a <see cref="MethodInfo"/> to the chat functions.
    /// </summary>
    /// <param name="function"></param>
    public void Add(MethodInfo function)
    {
        var name = function.Name;
        var chatTool = ChatTool.CreateFunctionTool(name, MethodInfoToDescription(function), ChatTools.ParametersToJson(function.GetParameters()));
        _definitions.Add(chatTool);
        _methods[name] = function;
    }

    /// <summary>
    /// Calls a function by name with the specified arguments.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="arguments"></param>
    /// <returns></returns>
    public string Call(string name, object[] arguments)
    {
        if (!_methods.TryGetValue(name, out MethodInfo? method))
            return $"I don't have a tool called {name}";

        object? result = method.Invoke(null, arguments);
        return result!.ToString()!;
    }

    /// <summary>
    /// Calls a specific <see cref="ChatToolCall"/>.
    /// </summary>
    /// <param name="call"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public string Call(ChatToolCall call)
    {
        var arguments = new List<object>();
        if (call.FunctionArguments != null)
        {
            var document = JsonDocument.Parse(call.FunctionArguments);
            JsonElement json = document.RootElement;
            foreach (JsonProperty argument in json.EnumerateObject())
            {
                JsonElement value = argument.Value;
                switch (value.ValueKind)
                {
                    case JsonValueKind.String:
                        arguments.Add(value.GetString()!);
                        break;
                    case JsonValueKind.Number:
                        arguments.Add(value.GetDouble());
                        break;
                    case JsonValueKind.True:
                        arguments.Add(true);
                        break;
                    case JsonValueKind.False:
                        arguments.Add(false);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        var name = call.FunctionName;
        var result = Call(name, [.. arguments]);
        return result;
    }

    private async Task<string> CallMcp(ChatToolCall call)
    {
        if (_mcpMethods.TryGetValue(call.FunctionName, out Func<string, BinaryData, Task<BinaryData>>? method))
        {
            #if !NETSTANDARD2_0
                        var actualFunctionName = call.FunctionName.Split("__.__", 2)[1];
            #else
                        var separator = "__.__";
                        var index = call.FunctionName.IndexOf(separator);
                        var actualFunctionName = call.FunctionName.Substring(index + separator.Length);
            #endif
            var result = await method(actualFunctionName, call.FunctionArguments).ConfigureAwait(false);
            return result.ToString();
        }
        else
        {
            throw new NotImplementedException($"MCP tool {call.FunctionName} not found.");
        }
    }

    /// <summary>
    /// Calls all the specified <see cref="ChatToolCall"/>s.
    /// </summary>
    /// <param name="toolCalls"></param>
    /// <returns></returns>
    public IEnumerable<ToolChatMessage> CallAll(IEnumerable<ChatToolCall> toolCalls)
    {
        var messages = new List<ToolChatMessage>();
        foreach (ChatToolCall toolCall in toolCalls)
        {
            var result = Call(toolCall);
            messages.Add(new ToolChatMessage(toolCall.Id, result));
        }
        return messages;
    }

    /// <summary>
    /// Calls all the specified <see cref="ChatToolCall"/>s.
    /// </summary>
    /// <param name="toolCalls"></param>
    /// <returns></returns>
    public async Task<ToolCallResult> CallAllWithErrors(IEnumerable<ChatToolCall> toolCalls)
    {
        List<string>? failed = null;
        bool isMcpTool = false;
        var messages = new List<ToolChatMessage>();
        foreach (ChatToolCall toolCall in toolCalls)
        {
            if (!_methods.ContainsKey(toolCall.FunctionName))
            {
                if (_mcpMethods.ContainsKey(toolCall.FunctionName))
                {
                    isMcpTool = true;
                }
                else
                {
                    failed ??= new List<string>();
                    failed.Add(toolCall.FunctionName);
                    continue;
                }
            }

            var result = isMcpTool ? await CallMcp(toolCall).ConfigureAwait(false) : Call(toolCall);
            messages.Add(new ToolChatMessage(toolCall.Id, result));
        }
        return new(messages, failed);
    }

    /// <summary>
    /// Converts the <see cref="ChatTools"/> to a <see cref="ChatCompletionOptions"/>.
    /// </summary>
    /// <returns></returns>
    public ChatCompletionOptions ToOptions()
    {
        ChatCompletionOptions options = new();
        foreach (ChatTool tool in _definitions)
        {
            options.Tools.Add(tool);
        }
        return options;
    }

    private static string MethodInfoToDescription(MethodInfo function)
    {
        var description = function.Name;
        DescriptionAttribute? attribute = function.GetCustomAttribute<DescriptionAttribute>();
        if (attribute != null)
        {
            description = attribute.Description;
        }
        return description;
    }

    private static string? ParameterInfoToDescription(ParameterInfo parameter)
    {
        string? description = parameter.Name;
        DescriptionAttribute? attribute = parameter.GetCustomAttribute<DescriptionAttribute>();
        if (attribute != null)
        {
            description = attribute.Description;
        }
        return description;
    }

    private static string GetMethodInfoToName(MethodInfo function)
    {
        var sb = new StringBuilder();
        sb.Append(function.Name);
        foreach (ParameterInfo parameter in function.GetParameters())
        {
            sb.Append($"_{ChatTools.ClrToJsonTypeUtf16(parameter.ParameterType)}");
        }
        return sb.ToString();
    }

    private static ReadOnlySpan<byte> ClrToJsonTypeUtf8(Type clrType)
    {
        if (clrType == typeof(double))
            return "number"u8;
        if (clrType == typeof(string))
            return "string"u8;
        if (clrType == typeof(bool))
            return "bool"u8;
        else
            throw new NotImplementedException();
    }

    private static string ClrToJsonTypeUtf16(Type clrType)
    {
        if (clrType == typeof(double))
            return "number";
        if (clrType == typeof(string))
            return "string";
        if (clrType == typeof(bool))
            return "bool";
        else
            throw new NotImplementedException();
    }

    private static BinaryData ParametersToJson(ParameterInfo[] parameters)
    {
        if (parameters.Length == 0)
            return s_noparams;

        var required = new List<string>();
        MemoryStream stream = new();
        var writer = new Utf8JsonWriter(stream);
        writer.WriteStartObject();
        writer.WriteString("type"u8, "object"u8);
        writer.WriteStartObject("properties"u8);
        foreach (ParameterInfo parameter in parameters)
        {
            writer.WriteStartObject(parameter.Name!);
            writer.WriteString("type"u8, ChatTools.ClrToJsonTypeUtf8(parameter.ParameterType));
            writer.WriteString("description"u8, ChatTools.ParameterInfoToDescription(parameter));
            writer.WriteEndObject();
            if (!parameter.IsOptional || (parameter.HasDefaultValue && parameter.DefaultValue is not null))
                required.Add(parameter.Name!);
        }
        writer.WriteEndObject(); // properties
        writer.WriteStartArray("required");
        foreach (string requiredParameter in required)
        {
            writer.WriteStringValue(requiredParameter);
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Flush();
        stream.Position = 0;
        return BinaryData.FromStream(stream);
    }
}
