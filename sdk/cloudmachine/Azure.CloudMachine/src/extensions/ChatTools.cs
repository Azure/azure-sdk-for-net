// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using OpenAI.Chat;

namespace Azure.CloudMachine.OpenAI;

/// <summary> The service client for the OpenAI Chat Completions endpoint. </summary>
public class ChatTools
{
    private static readonly BinaryData s_noparams = BinaryData.FromString("""{ "type" : "object", "properties" : {} }""");

    private readonly Dictionary<string, MethodInfo> _methods = new Dictionary<string, MethodInfo>();
    private readonly List<ChatTool> _definitions = new List<ChatTool>();

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatTools"/> class.
    /// </summary>
    /// <param name="tools"></param>
    public ChatTools(params Type[] tools)
    {
        foreach (var functionHolder in tools)
            Add(functionHolder);
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
        foreach (var tool in tools.Definitions)
        {
            options.Tools.Add(tool);
        }
        return options;
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
        var chatTool = ChatTool.CreateFunctionTool(name, GetMethodInfoToDescription(function), ParametersToJson(function.GetParameters()));
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
        MethodInfo method = _methods[name];
        object result = method.Invoke(null, arguments);
        return result.ToString();
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
            var json = document.RootElement;
            foreach (JsonProperty argument in json.EnumerateObject())
            {
                var value = argument.Value;
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
        var result = Call(name, arguments.ToArray());
        return result;
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
            ChatToolCall functionToolCall = toolCall as ChatToolCall;
            var result = Call(functionToolCall);
            messages.Add(new ToolChatMessage(toolCall.Id, result));
        }
        return messages;
    }

    /// <summary>
    /// Gets the description of a <see cref="MethodInfo"/>.
    /// </summary>
    /// <param name="function"></param>
    /// <returns></returns>
    protected virtual string GetMethodInfoToDescription(MethodInfo function)
    {
        var description = function.Name;
        var attribute = function.GetCustomAttribute<DescriptionAttribute>();
        if (attribute != null)
        {
            description = attribute.Description;
        }
        return description;
    }

    /// <summary>
    /// Gets the description of a <see cref="ParameterInfo"/>.
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    protected virtual string GetParameterInfoToDescription(ParameterInfo parameter)
    {
        var description = parameter.Name;
        var attribute = parameter.GetCustomAttribute<DescriptionAttribute>();
        if (attribute != null)
        {
            description = attribute.Description;
        }
        return description;
    }

    /// <summary>
    /// Gets the name of a <see cref="MethodInfo"/>.
    /// </summary>
    /// <param name="function"></param>
    /// <returns></returns>
    protected virtual string GetMethodInfoToName(MethodInfo function)
    {
        var sb = new StringBuilder();
        sb.Append(function.Name);
        foreach (var parameter in function.GetParameters())
        {
            sb.Append($"_{ClrToJsonTypeUtf16(parameter.ParameterType)}");
        }
        return sb.ToString();
    }

    /// <summary>
    /// Converts a CLR type to a JSON Utf8 type.
    /// </summary>
    /// <param name="clrType"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    protected ReadOnlySpan<byte> ClrToJsonTypeUtf8(Type clrType)
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

    /// <summary>
    /// Converts a CLR type to a JSON Utf16 type.
    /// </summary>
    /// <param name="clrType"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    protected string ClrToJsonTypeUtf16(Type clrType)
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

    private BinaryData ParametersToJson(ParameterInfo[] parameters)
    {
        if (parameters.Length == 0)
            return s_noparams;

        var required = new List<string>();
        MemoryStream stream = new MemoryStream();
        var writer = new Utf8JsonWriter(stream);
        writer.WriteStartObject();
        writer.WriteString("type"u8, "object"u8);
        writer.WriteStartObject("properties"u8);
        foreach (ParameterInfo parameter in parameters)
        {
            writer.WriteStartObject(parameter.Name!);
            writer.WriteString("type"u8, ClrToJsonTypeUtf8(parameter.ParameterType));
            writer.WriteString("description"u8, GetParameterInfoToDescription(parameter));
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
