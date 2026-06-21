// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.Optimization.Configuration.Samples;

/// <summary>
/// Foundry Responses-protocol handler. Receives <see cref="CreateResponse"/>
/// requests, extracts the message history, hands it to the singleton
/// Microsoft Agent Framework <see cref="AIAgent"/>, and streams the agent's
/// text reply back as a <see cref="TextResponse"/>.
/// </summary>
internal class TravelHandler : ResponseHandler
{
    private readonly AIAgent _agent;
    private readonly OptimizationOptions? _config;

    public TravelHandler(AIAgent agent, OptimizationOptions? config = null)
    {
        _agent = agent;
        _config = config;
    }

    public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        LogConfig(context.ResponseId);

        return new TextResponse(context, request, async ct =>
        {
            try
            {
                List<ChatMessage> messages = ExtractMessages(request);
                if (messages.Count == 0)
                {
                    return "[ERROR] Request did not contain any input messages.";
                }

                AgentSession session = await _agent.CreateSessionAsync(ct).ConfigureAwait(false);
                AgentResponse run = await _agent.RunAsync(messages, session, options: null, cancellationToken: ct).ConfigureAwait(false);

                string text = run.Text;
                Console.WriteLine(
                    $"[Request {context.ResponseId}] MAF run ok — model={_config?.Model ?? "default"}, "
                    + $"messages={messages.Count}, replyLen={text.Length}");
                return text;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(
                    $"[Request {context.ResponseId}] MAF run failed: "
                    + $"{ex.GetType().FullName}: {ex.Message}\n{ex.StackTrace}");
                return $"[LLM ERROR] {ex.GetType().FullName}: {ex.Message}\n\n"
                    + $"Endpoint: {ResolveOpenAIEndpointForDiag()}\n"
                    + $"Model: {_config?.Model ?? "(default)"}";
            }
        });
    }

    private static string ResolveOpenAIEndpointForDiag() =>
        Environment.GetEnvironmentVariable("AZURE_AI_OPENAI_ENDPOINT")
        ?? Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT")
        ?? Environment.GetEnvironmentVariable("AZURE_AI_PROJECT_ENDPOINT")
        ?? "(none)";

    private static List<ChatMessage> ExtractMessages(CreateResponse request)
    {
        var messages = new List<ChatMessage>();
        if (request.Input is null)
        {
            return messages;
        }

        using var doc = JsonDocument.Parse(request.Input);

        if (doc.RootElement.ValueKind == JsonValueKind.String)
        {
            string? text = doc.RootElement.GetString();
            if (!string.IsNullOrEmpty(text))
            {
                messages.Add(new ChatMessage(ChatRole.User, text));
            }
            return messages;
        }

        if (doc.RootElement.ValueKind != JsonValueKind.Array)
        {
            return messages;
        }

        foreach (var item in doc.RootElement.EnumerateArray())
        {
            if (!item.TryGetProperty("role", out var roleProp))
            {
                continue;
            }
            if (!item.TryGetProperty("content", out var contentProp))
            {
                continue;
            }

            string? text = contentProp.ValueKind switch
            {
                JsonValueKind.String => contentProp.GetString(),
                JsonValueKind.Array => ExtractContentText(contentProp),
                _ => null,
            };
            if (string.IsNullOrEmpty(text))
            {
                continue;
            }

            ChatRole role = roleProp.GetString() switch
            {
                "assistant" => ChatRole.Assistant,
                "system" or "developer" => ChatRole.System,
                _ => ChatRole.User,
            };
            messages.Add(new ChatMessage(role, text));
        }

        return messages;
    }

    private static string ExtractContentText(JsonElement content)
    {
        var parts = new List<string>();
        foreach (var part in content.EnumerateArray())
        {
            if (part.TryGetProperty("text", out var t) && t.ValueKind == JsonValueKind.String)
            {
                parts.Add(t.GetString() ?? string.Empty);
            }
        }
        return string.Join(" ", parts);
    }

    private void LogConfig(string responseId)
    {
        Console.WriteLine($"[Request {responseId}] ── Optimization Config ──────────────────────");
        if (_config is null)
        {
            Console.WriteLine("[Request] No optimization config loaded — using defaults.");
            Console.WriteLine("[Request] ────────────────────────────────────────────");
            return;
        }
        Console.WriteLine($"[Request] Source:       {_config.Source}");
        Console.WriteLine($"[Request] Model:        {_config.Model ?? "(not set)"}");
        Console.WriteLine($"[Request] Temperature:  {_config.Temperature?.ToString() ?? "(not set)"}");
        Console.WriteLine($"[Request] CandidateId:  {_config.CandidateId ?? "(none)"}");
        Console.WriteLine($"[Request] HasSkills:    {_config.HasSkills}");
        Console.WriteLine($"[Request] Skills:       {_config.Skills.Count}");
        foreach (var skill in _config.Skills)
        {
            Console.WriteLine($"[Request]   • {skill.Name}: {skill.Description}");
        }
        Console.WriteLine($"[Request] Tools:        {_config.ToolDefinitions.Count}");
        foreach (var tool in _config.ToolDefinitions)
        {
            Console.WriteLine($"[Request]   🔧 {tool.Name}: {(string.IsNullOrEmpty(tool.Description) ? "(no desc)" : tool.Description)}");
        }
        Console.WriteLine($"[Request] SkillsDir:    {_config.SkillsDirectory ?? "(none)"}");
        Console.WriteLine($"[Request] ────────────────────────────────────────────");
    }
}
