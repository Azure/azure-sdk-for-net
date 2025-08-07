// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenAI.Chat;
using OpenAI.Embeddings;

namespace Azure.Projects.AI;

/// <summary> The service client for the OpenAI Chat Completions endpoint. </summary>
public class ChatTools
{
    private static readonly BinaryData s_noparams = BinaryData.FromString("""{ "type" : "object", "properties" : {} }""");

    private readonly Dictionary<string, MethodInfo> _methods = [];
    private readonly Dictionary<string, Func<string, BinaryData, Task<BinaryData>>> _mcpMethods = [];
    private readonly List<ChatTool> _definitions = [];
    private readonly EmbeddingClient? _client;
    private readonly List<VectorbaseEntry> _entries = [];

    private List<McpClient> _mcpClients = [];
    private Dictionary<string, McpClient> _mcpClientsByEndpoint = [];
    private const string _mcpToolSeparator = "_._";

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatTools"/> class.
    /// </summary>
    public ChatTools(EmbeddingClient? embeddingClient = null)
    {
        _client = embeddingClient;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatTools"/> class.
    /// </summary>
    /// <param name="tools"></param>
    public ChatTools(params Type[] tools)
        => AddLocalTools(tools);

    /// <summary>
    /// Adds a new MCP Server connection to be used for function calls.
    /// </summary>
    /// <param name="tools"></param>
    public void AddLocalTools(params Type[] tools)
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
        await Add(tools, client).ConfigureAwait(false);
        _mcpClients.Add(client);
    }

    /// <summary>
    /// Gets the tool definitions.
    /// </summary>
    public IList<ChatTool> Definitions => _definitions;

    /// <summary>
    /// Determines if the tools can be filtered using the EmbeddingsClient.
    /// </summary>
    public bool CanFilterTools => _client != null;

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
    internal async Task Add(BinaryData toolDefinitions, McpClient client)
    {
        using var document = JsonDocument.Parse(toolDefinitions);
        if (!document.RootElement.TryGetProperty("tools", out JsonElement toolsElement))
        {
            throw new JsonException("The JSON document must contain a 'tools' array.");
        }

        var tools = toolsElement.EnumerateArray();
        // the replacement is to deal with OpenAI's tool name regex validation.
        var serverKey = client.ServerEndpoint.Host + client.ServerEndpoint.Port.ToString();

        List<ChatTool> ToolsToVectorize = new();

        foreach (var tool in tools)
        {
            var name = $"{serverKey}{_mcpToolSeparator}{tool.GetProperty("name").GetString()!}";
            var description = tool.GetProperty("description").GetString()!;
            var inputSchema = JsonSerializer.Serialize(
                JsonSerializer.Deserialize<JsonElement>(tool.GetProperty("inputSchema").GetRawText()),
                new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                });

            var chatTool = ChatTool.CreateFunctionTool(
                name,
                description,
                BinaryData.FromString(inputSchema));

            _definitions.Add(chatTool);
            ToolsToVectorize.Add(chatTool);

            _mcpMethods[name] = client.CallToolAsync;
        }

        await AddToolsToVectorBaseAsync(ToolsToVectorize).ConfigureAwait(false);
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
            var actualFunctionName = call.FunctionName.Split(_mcpToolSeparator, 2)[1];
#else
                        var index = call.FunctionName.IndexOf(_mcpToolSeparator);
                        var actualFunctionName = call.FunctionName.Substring(index + _mcpToolSeparator.Length);
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

    /// <summary>
    /// Converts the <see cref="ChatTools"/> to a <see cref="ChatCompletionOptions"/> using the current prompt to filter the related tools via embeddings.
    /// </summary>
    /// <param name="prompt">The prompt to use for filtering the related tools.</param>
    /// <param name="options">Optional options to refine how the related tools are found.</param>
    /// <returns></returns>
    public ChatCompletionOptions ToOptions(string prompt, ToolFindOptions? options = null)
    {
        if (!CanFilterTools)
        {
            return ToOptions();
        }

        ChatCompletionOptions completionOptions = new();
        var related = Find(prompt, options ?? new ToolFindOptions { MaxEntries = 5 });
        foreach (VectorbaseEntry entry in related)
        {
            ChatTool tool = ParseToolDefinition(entry.Data);
            completionOptions.Tools.Add(tool);
        }
        // TODO: Add this to logging when we have a logger.
        // Uncomment the following lines to see the related tools found.
        // Console.WriteLine($"Found {related.Count()} related tools for prompt '{prompt}'.");
        // foreach (ChatTool tool in completionOptions.Tools)
        // {
        //     Console.WriteLine($"\tTool: {tool.FunctionName}");
        // }
        return completionOptions;
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

    private static BinaryData SerializeChatTool(ChatTool tool)
    {
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });

        writer.WriteStartObject();

        writer.WriteString("name", tool.FunctionName);
        writer.WriteString("description", tool.FunctionDescription);

        // Write the inputSchema by parsing the existing BinaryData
        writer.WritePropertyName("inputSchema");
        using (var inputSchemaDoc = JsonDocument.Parse(tool.FunctionParameters))
        {
            inputSchemaDoc.RootElement.WriteTo(writer);
        }

        writer.WriteEndObject();
        writer.Flush();
        stream.Position = 0;

        return BinaryData.FromStream(stream);
    }

    private ChatTool ParseToolDefinition(BinaryData toolDefinition)
    {
        using var document = JsonDocument.Parse(toolDefinition);
        var root = document.RootElement;

        var name = root.GetProperty("name").GetString()!;
        var description = root.GetProperty("description").GetString()!;
        var inputSchema = BinaryData.FromString(root.GetProperty("inputSchema").GetRawText());

        return ChatTool.CreateFunctionTool(
            name,
            description,
            inputSchema);
    }

    private async Task AddToolsToVectorBaseAsync(List<ChatTool> tools)
    {
        if (!CanFilterTools)
            return;

        OpenAIEmbeddingCollection embeddings = await _client!.GenerateEmbeddingsAsync(tools.Select(t => t.FunctionDescription)).ConfigureAwait(false);

        Console.WriteLine($"Adding {embeddings.Count} tools to vectorbase.");

        foreach (OpenAIEmbedding embedding in embeddings)
        {
            ReadOnlyMemory<float> vector = embedding.ToFloats();
            ChatTool item = tools[embedding.Index];
            BinaryData toolDefinition = SerializeChatTool(item);
            _entries.Add(new VectorbaseEntry(vector, toolDefinition));
        }
    }

    internal IEnumerable<VectorbaseEntry> Find(string prompt, ToolFindOptions options)
    {
        ReadOnlyMemory<float> vector = GetEmbedding(prompt);
        lock (_entries)
        {
            var distances = new List<(float Distance, int Index)>(_entries.Count);
            for (int index = 0; index < _entries.Count; index++)
            {
                VectorbaseEntry entry = _entries[index];
                ReadOnlyMemory<float> dbVector = entry.Vector;
                float distance = 1.0f - EmbeddingsStore.CosineSimilarity(dbVector.Span, vector.Span);
                distances.Add((distance, index));
            }
            distances.Sort(((float D1, int I1) v1, (float D2, int I2) v2) => v1.D1.CompareTo(v2.D2));

            List<VectorbaseEntry> results = new(options.MaxEntries);
            int top = Math.Min(options.MaxEntries, distances.Count);
            for (int i = 0; i < top; i++)
            {
                float distance = distances[i].Distance;
                if (distance > options.Threshold)
                    break;
                int index = distances[i].Index;
                results.Add(_entries[index]);
            }
            return results;
        }
    }

    private ReadOnlyMemory<float> GetEmbedding(string fact)
    {
        OpenAIEmbedding embedding = _client!.GenerateEmbedding(fact);
        return embedding.ToFloats();
    }

    /// <summary>
    /// The options for finding entries in the vectorbase.
    /// </summary>
    public class ToolFindOptions
    {
        /// <summary>
        /// The maximum number of entries to return.
        /// </summary>
        public int MaxEntries { get; set; } = 3;

        /// <summary>
        /// The threshold for the cosine similarity.
        /// </summary>
        public float Threshold { get; set; } = 0.29f;
    }
}
