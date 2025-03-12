// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

internal class McpClient
{
    private ClientPipeline _pipeline = ClientPipeline.Create();
    private Func<SseEvent, Task> _processEvent;
    private string _serverEndpoint;
    private string _messageEndpoint;
    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private int _nextId = 0;
    private readonly MessageRouter _messageRouter = new MessageRouter();
    private Timer _pingTimer;

    // Message router that handles correlation between requests and responses
    private class MessageRouter
    {
        // Dictionary to store message handlers and completion actions by ID
        private readonly ConcurrentDictionary<int, Func<SseEvent, Task>> _handlers = new();

        // Register a handler with optional completion action
        public void RegisterHandler(int id, Func<SseEvent, Task> handler)
        {
            if (!_handlers.TryAdd(id, handler))
            {
                throw new InvalidOperationException($"Handler for message ID {id} already registered");
            }
        }

        // Route a message to its registered handler
        public async Task RouteMessageAsync(SseEvent sseEvent)
        {
            if (sseEvent.Event != "message" || string.IsNullOrEmpty(sseEvent.Data))
            {
                return;
            }

            // Extract ID from the message payload
            int id = ExtractId(sseEvent.Data);
            if (id == -1)
            {
                return;
            }

            // Try to get and remove the handler
            if (_handlers.TryRemove(id, out var handler))
            {
                try
                {
                    // Execute handler
                    await handler(sseEvent).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in message handler for ID {id}: {ex.Message}");
                }
            }
        }
    }

    public McpClient(string serverEndpoint)
    {
        _pipeline = ClientPipeline.Create();
        _serverEndpoint = serverEndpoint;
        _processEvent = OnProcessEvent;
        _messageEndpoint = string.Empty;

        _pingTimer = new Timer(async _ =>
        {
            try
            {
                await PingAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ping failed: {ex.Message}");
            }
        }, null, Timeout.Infinite, Timeout.Infinite); // Initialize in stopped state
    }

    // Get a new ID for requests
    private int GetNextId()
    {
        return Interlocked.Increment(ref _nextId);
    }

    public void Start()
    {
        StartSseSession(_pipeline, _serverEndpoint);
        // return new McpSession(endpoint, _pipeline);
        StartPing();
    }

    public void Close()
    {
        _cancellationTokenSource.Cancel();
        StopPing();
    }

    // Updated OnProcessEvent to use the message router
    private async Task OnProcessEvent(SseEvent sseEvent)
    {
        switch (sseEvent.Event)
        {
            case "endpoint":
                var serverUri = new Uri(_serverEndpoint);
                // Extract the full url except for the path
                var endpoint = serverUri.GetLeftPart(UriPartial.Authority);
                _messageEndpoint = $"{endpoint}{sseEvent.Data}";

                // Now that we have the message endpoint, call Initialize
                await Initialize().ConfigureAwait(false);
                break;

            case "message":
                // Route message events to registered handlers
                await _messageRouter.RouteMessageAsync(sseEvent).ConfigureAwait(false);
                break;

            default:
                Console.WriteLine($"Unknown event: {sseEvent.Event}");
                break;
        }
    }

    private void StartPing()
    {
        _pingTimer.Change(
            TimeSpan.FromSeconds(20), // Initial delay
            TimeSpan.FromSeconds(20));  // Recurring interval
    }

    private void StopPing()
    {
        _pingTimer.Change(Timeout.Infinite, Timeout.Infinite);
    }

    // Modified to return both endpoint and subscription
    private void StartSseSession(ClientPipeline client, string serverEndpoint)
    {
        PipelineMessage handshakeMessage = CreateHandshakeMessage(client, serverEndpoint);

        try
        {
            client.Send(handshakeMessage);

            var response = handshakeMessage.Response;
            Console.WriteLine($"GetEndpoint response status: {response!.Status}");

            if (response.IsError)
            {
                handshakeMessage.Dispose();
                throw new Exception($"Error initializing SSE connection: {response.Status}");
            }

            // Process the SSE stream
            ProcessSseStream(
                response.ContentStream!,
                _processEvent,
                CancellationToken.None
            );
        }
        catch
        {
            handshakeMessage.Dispose();
            throw;
        }
    }

    public static int ExtractId(string jsonPayload)
    {
        if (string.IsNullOrEmpty(jsonPayload))
        {
            throw new ArgumentException("JSON payload cannot be null or empty", nameof(jsonPayload));
        }

        byte[] bytes = Encoding.UTF8.GetBytes(jsonPayload);
        var reader = new Utf8JsonReader(bytes);

        try
        {
            // Look for the top-level "id" property
            while (reader.Read())
            {
                // We only care about property names at the top level
                if (reader.TokenType == JsonTokenType.PropertyName &&
                    reader.GetString() == "id" &&
                    reader.CurrentDepth == 1)
                {
                    // Move to the value
                    reader.Read();

                    // Handle number or string format
                    if (reader.TokenType == JsonTokenType.Number)
                    {
                        if (reader.TryGetInt32(out int id))
                        {
                            return id;
                        }
                    }

                    // Found "id" but it's not a valid integer
                    return -1;
                }
            }

            // No "id" property found
            return -1;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error parsing JSON: {ex.Message}");
            return -1;
        }
    }

    private PipelineMessage CreateHandshakeMessage(ClientPipeline client, string serverEndpoint)
    {
        // Don't use using statement here - we'll manage lifetime through the subscription
        PipelineMessage handshakeMessage = client.CreateMessage();
        PipelineRequest handshakeRequest = handshakeMessage.Request;
        handshakeRequest.Uri = new Uri(serverEndpoint);
        handshakeRequest.Method = "GET";
        handshakeRequest.Headers.Add("Accept", "text/event-stream");
        handshakeMessage.BufferResponse = false;
        return handshakeMessage;
    }

    // Updated Initialize method that takes a completion action
    public async Task Initialize()
    {
        var id = GetNextId();
        // Keep your existing JSON format
        string json = $$"""
        {
          "jsonrpc": "2.0",
          "id": {{id}},
          "method": "initialize",
          "params": {
            "protocolVersion": "2024-11-05",
            "capabilities": {
              "roots": {
                "listChanged": true
              },
              "sampling": {}
            },
            "clientInfo": {
              "name": "ExampleClient",
              "version": "1.0.0"
            }
          }
        }
        """;

        // Register a handler that will:
        // 1. Process the response
        // 2. Execute the completion action (which calls InitComplete)
        _messageRouter.RegisterHandler(
            id,
            evt => InitComplete()
        );

        await SendAsync(json).ConfigureAwait(false);
    }

    // InitComplete remains unchanged
    public async Task InitComplete()
    {
        string initialized = $$"""
        {
            "jsonrpc": "2.0",
            "method": "notifications/initialized"
        }
        """;

        await SendAsync(initialized).ConfigureAwait(false);
    }

    public async Task SendAsync(string json)
    {
        Console.WriteLine($"sending:\n {json}\n");
        using PipelineMessage message = _pipeline.CreateMessage();
        using PipelineRequest request = message.Request;
        request.Uri = new Uri(_messageEndpoint);
        request.Method = "POST";
        request.Headers.Add("Content-Type", "application/json");
        request.Headers.Add("Accept", "text/event-stream");
        message.BufferResponse = false;

        var jsonBytes = BinaryData.FromString(json);
        request.Content = BinaryContent.Create(jsonBytes);
        await _pipeline.SendAsync(message).ConfigureAwait(false);
        var response = message.Response;
        Console.WriteLine(response!.Status);
    }

    // SSE stream processor
    internal static void ProcessSseStream(
        Stream stream,
        Func<SseEvent, Task> onEvent,
        CancellationToken cancellationToken = default)
    {
        var streamReader = new StreamReader(stream);
        var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        // Start async processing
        _ = Task.Run(async () =>
        {
            try
            {
                string eventName = "";
                StringBuilder dataBuilder = new StringBuilder();

                while (!cancellationSource.Token.IsCancellationRequested)
                {
                    string line = await streamReader.ReadLineAsync().ConfigureAwait(false);
                    if (line == null)
                    {
                        await Task.Delay(1000).ConfigureAwait(false);
                        continue;
                    }
                    ;

                    // Parse SSE format
                    if (line.StartsWith("event:"))
                    {
                        eventName = line.Substring(6).Trim();
                    }
                    else if (line.StartsWith("data:"))
                    {
                        dataBuilder.AppendLine(line.Substring(5).Trim());
                    }
                    else if (string.IsNullOrEmpty(line) && dataBuilder.Length > 0)
                    {
                        // End of event
                        var sseEvent = new SseEvent(eventName, dataBuilder.ToString().TrimEnd());
                        Console.WriteLine(sseEvent);
                        await onEvent(sseEvent).ConfigureAwait(false);

                        // Reset for next event
                        eventName = "";
                        dataBuilder.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing SSE: {ex.Message}");
            }
        }, cancellationSource.Token);
    }

    public class SseEvent
    {
        public string Event { get; set; }
        public string Data { get; set; }

        public SseEvent(string eventName, string data)
        {
            Event = eventName;
            Data = data;
        }

        public override string ToString()
        {
            return $"====== SSE Event =====\nEvent: {Event}, Data: {Data}\n======================\n";
        }
    }

    // Example of using the system for ListTools
    public async Task<BinaryData> ListTools()
    {
        var id = GetNextId();
        var completionSource = new TaskCompletionSource<BinaryData>(TaskCreationOptions.RunContinuationsAsynchronously);

        string json = $$"""
        {
          "jsonrpc" : "2.0",
          "id" : {{id}},
          "method" : "tools/list"
        }
        """;

        _messageRouter.RegisterHandler(id, (sseEvent) =>
        {
            // Parse just the tools array from the response
            // and set the result in the completion source
            try
            {
                using JsonDocument doc = JsonDocument.Parse(sseEvent.Data);
                var toolsArray = doc.RootElement
                    .GetProperty("result")
                    .GetProperty("tools");

                var toolsJson = toolsArray.GetRawText();
                completionSource.SetResult(BinaryData.FromString(toolsJson));
            }
            catch (Exception ex)
            {
                completionSource.SetException(ex);
            }
            return Task.CompletedTask;
        });

        await SendAsync(json).ConfigureAwait(false);
        return await completionSource.Task.ConfigureAwait(false);
    }

    public async Task PingAsync()
    {
        var id = GetNextId();

        string json = $$"""
        {
          "jsonrpc" : "2.0",
          "id" : {{id}},
          "method" : "ping"
        }
        """;

        await SendAsync(json).ConfigureAwait(false);
    }
}
