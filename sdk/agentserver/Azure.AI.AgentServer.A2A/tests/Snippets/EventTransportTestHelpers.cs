// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using global::A2A;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using NUnit.Framework;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.ReadMeSnippets;

namespace Azure.AI.AgentServer.A2A.Tests.Snippets;

public class EventTransportTestHelpers
{
    #region A2A_EventTransport_Handler
    public class StreamingAgent : IAgentHandler
    {
        public async Task ExecuteAsync(
            global::A2A.RequestContext context,
            AgentEventQueue eventQueue,
            CancellationToken cancellationToken)
        {
            var task = new TaskUpdater(eventQueue, context.TaskId, context.ContextId);
            await task.SubmitAsync(cancellationToken: cancellationToken);
            await task.StartWorkAsync(cancellationToken: cancellationToken);

            string[] lines = $"Echo: {context.UserText}".Split('\n');
            string artifactId = Guid.NewGuid().ToString("N");
            for (int index = 0; index < lines.Length; index++)
            {
                if (index > 0)
                {
                    // Simulate incremental work; real agents emit output as it becomes available.
                    await Task.Delay(TimeSpan.FromMilliseconds(250), cancellationToken);
                }

                string text = lines[index] + (index < lines.Length - 1 ? "\n" : string.Empty);
                await task.AddArtifactAsync(
                    [Part.FromText(text)],
                    artifactId: artifactId,
                    append: index > 0,
                    lastChunk: index == lines.Length - 1,
                    cancellationToken: cancellationToken);
            }

            await task.CompleteAsync(cancellationToken: cancellationToken);
        }
    }
    #endregion

    [Test]
    [Explicit("Starts a server; the handler is exercised by SampleEndToEndTests.")]
    public void StartServer()
    {
        #region A2A_EventTransport_Start
        var card = CreateCard();
        card.Capabilities.Streaming = true;
        A2AAgentServer.Run<StreamingAgent>(card);
        #endregion
    }

    #region A2A_EventTransport_ReadEvents
    public static async IAsyncEnumerable<JsonElement> ReadEventsAsync(
        HttpClient client,
        string requestJson,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "/a2a")
        {
            Content = new StringContent(requestJson, Encoding.UTF8, "application/json"),
        };
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
        using var response = await client.SendAsync(
            request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        response.EnsureSuccessStatusCode();
        if (response.Content.Headers.ContentType?.MediaType != "text/event-stream")
        {
            throw new InvalidDataException("Expected content type text/event-stream.");
        }

        using var reader = new StreamReader(await response.Content.ReadAsStreamAsync(cancellationToken));
        var data = new List<string>();
        while (await reader.ReadLineAsync(cancellationToken) is { } line)
        {
            if (line.StartsWith("data:", StringComparison.Ordinal))
            {
                data.Add(line[5..].TrimStart(' '));
            }
            else if (line.Length == 0 && data.Count > 0)
            {
                using var json = JsonDocument.Parse(string.Join("\n", data));
                data.Clear();
                if (json.RootElement.TryGetProperty("error", out var error))
                {
                    throw new InvalidDataException(error.GetRawText());
                }

                yield return json.RootElement.GetProperty("result").Clone();
            }
        }

        if (data.Count > 0)
        {
            throw new InvalidDataException("The stream ended before an event separator.");
        }
    }
    #endregion

    [Test]
    [Explicit("Requires a running sample server.")]
    public async Task ReadReplyAsync()
    {
        #region A2A_EventTransport_Client
        using var client = new HttpClient { BaseAddress = new Uri("http://localhost:8088") };
        const string requestJson = """
            {"jsonrpc":"2.0","id":"stream-1","method":"SendStreamingMessage",
             "params":{"message":{"messageId":"m1","role":"ROLE_USER",
             "parts":[{"text":"first\nsecond\nthird"}]}}}
            """;
        var output = new StringBuilder();
        bool completed = false;
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        await foreach (var result in ReadEventsAsync(client, requestJson, timeout.Token))
        {
            if (result.TryGetProperty("artifactUpdate", out var update))
            {
                foreach (var part in update.GetProperty("artifact").GetProperty("parts").EnumerateArray())
                {
                    string text = part.GetProperty("text").GetString()!;
                    output.Append(text);
                    Console.Write(text);
                }
            }
            else if (result.TryGetProperty("statusUpdate", out var status))
            {
                completed = status.GetProperty("status").GetProperty("state").GetString() == "TASK_STATE_COMPLETED";
            }
        }

        if (!completed || output.ToString() != "Echo: first\nsecond\nthird")
        {
            throw new InvalidDataException("The stream did not produce the expected completed response.");
        }
        #endregion
    }
}
