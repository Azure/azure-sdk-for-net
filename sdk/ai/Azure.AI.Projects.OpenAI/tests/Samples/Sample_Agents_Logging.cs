// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

#region Snippet:Sample_LoggingPolicy_AgentsLogging
public class LoggingPolicy : PipelinePolicy
{
    private static void ProcessMessage(PipelineMessage message)
    {
        if (message.Request is not null && message.Response is null)
        {
            Console.WriteLine($"{message?.Request?.Method} URI: {message?.Request?.Uri}");
            Console.WriteLine($"--- New request ---");
            IEnumerable<string> headerPairs = message?.Request?.Headers?.Select(header => $"\n    {header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
            string headers = string.Join("", headerPairs);
            Console.WriteLine($"Request headers:{headers}");
            if (message.Request?.Content != null)
            {
                string contentType = "Unknown Content Type";
                if (message.Request.Headers?.TryGetValue("Content-Type", out contentType) == true
                    && contentType == "application/json")
                {
                    using MemoryStream stream = new();
                    message.Request.Content.WriteTo(stream, default);
                    stream.Position = 0;
                    using StreamReader reader = new(stream);
                    string requestDump = reader.ReadToEnd();
                    stream.Position = 0;
                    requestDump = Regex.Replace(requestDump, @"""data"":[\\w\\r\\n]*""[^""]*""", @"""data"":""...""");
                    // Make sure JSON string is properly formatted.
                    JsonSerializerOptions jsonOptions = new()
                    {
                        WriteIndented = true,
                    };
                    JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(requestDump);
                    Console.WriteLine("--- Begin request content ---");
                    Console.WriteLine(JsonSerializer.Serialize(jsonElement, jsonOptions));
                    Console.WriteLine("--- End request content ---");
                }
                else
                {
                    string length = message.Request.Content.TryComputeLength(out long numberLength)
                        ? $"{numberLength} bytes"
                        : "unknown length";
                    Console.WriteLine($"<< Non-JSON content: {contentType} >> {length}");
                }
            }
        }
        if (message.Response != null)
        {
            IEnumerable<string> headerPairs = message?.Response?.Headers?.Select(header => $"\n    {header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
            string headers = string.Join("", headerPairs);
            Console.WriteLine($"Response headers:{headers}");
            if (message.BufferResponse)
            {
                message.Response.BufferContent();
                Console.WriteLine("--- Begin response content ---");
                Console.WriteLine(message.Response.Content?.ToString());
                Console.WriteLine("--- End of response content ---");
            }
            else
            {
                Console.WriteLine("--- Response (unbuffered, content not rendered) ---");
            }
        }
    }

    public LoggingPolicy(){}

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        ProcessMessage(message); // for request
        ProcessNext(message, pipeline, currentIndex);
        ProcessMessage(message); // for response
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        ProcessMessage(message); // for request
        await ProcessNextAsync(message, pipeline, currentIndex);
        ProcessMessage(message); // for response
    }
}
#endregion

public class SampleAgentsLogging : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task RunAPromptAgentNoConversationAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateClient_AgentsLogging
#if SNIPPET
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'MODEL_DEPLOYMENT_NAME'");
#else
        string RAW_PROJECT_ENDPOINT = TestEnvironment.PROJECT_ENDPOINT;
        string MODEL_DEPLOYMENT = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClientOptions options = new();
        options.AddPolicy(new LoggingPolicy(), PipelinePosition.PerCall);
        AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential(), options: options);
        #endregion
        #region Snippet:Sample_CreateAgent_AgentsLogging_Async
        PromptAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
        {
            Instructions = "You are a physics teacher with a sense of humor.",
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        #endregion
        #region Snippet:Sample_CreateResponseBasic_AgentsLogging_Async
        var agentReference = new AgentReference(name: agentVersion.Name);
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentReference);
        CreateResponseOptions responseOptions = new([ResponseItem.CreateUserMessageItem("Write the proof of the intermediate value theorem.")]);
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:CleanUp_AgentsLogging_Async
        await projectClient.Agents.DeleteAgentAsync(agentName: "myAgent");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void RunAPromptAgentNoConversation()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("Missing environment variable 'PROJECT_ENDPOINT'");
        string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME")
            ?? throw new InvalidOperationException("Missing environment variable 'MODEL_DEPLOYMENT_NAME'");
#else
        string RAW_PROJECT_ENDPOINT = TestEnvironment.PROJECT_ENDPOINT;
        string MODEL_DEPLOYMENT = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClientOptions options = new();
        options.AddPolicy(new LoggingPolicy(), PipelinePosition.PerCall);
        AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential(), options: options);
        #region Snippet:Sample_CreateAgent_AgentsLogging_Sync
        PromptAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
        {
            Instructions = "You are a physics teacher with a sense of humor.",
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        #endregion
        #region Snippet:Sample_CreateResponseBasic_AgentsLogging_Sync
        var agentReference = new AgentReference(name: agentVersion.Name);
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentReference);
        CreateResponseOptions responseOptions = new([ResponseItem.CreateUserMessageItem("Write the proof of the intermediate value theorem.")]);
        ResponseResult response = responseClient.CreateResponse(responseOptions);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:CleanUp_AgentsLogging_Sync
        projectClient.Agents.DeleteAgent(agentName: "myAgent");
        #endregion
    }

    public SampleAgentsLogging(bool isAsync) : base(isAsync)
    { }
}
