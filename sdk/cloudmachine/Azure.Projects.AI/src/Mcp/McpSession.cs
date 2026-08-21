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

internal class McpSession : IDisposable
{
    private readonly Uri _serverEndpoint;
    private readonly ClientPipeline _pipeline;
    private readonly MessageRouter _messageRouter = new MessageRouter();
    private CancellationTokenSource _cancellationSource;
    private PipelineMessage? _activeHandshake;
    private string _messageEndpoint = string.Empty;
    private bool _isInitialized;
    private int _nextId = 0;
    private readonly SemaphoreSlim _initializationLock = new(1, 1);
    private TaskCompletionSource<string>? _endpointTcs;

    public McpSession(Uri serverEndpoint, ClientPipeline pipeline)
    {
        _serverEndpoint = serverEndpoint;
        _pipeline = pipeline;
        _cancellationSource = new CancellationTokenSource();
    }

    public async Task EnsureInitializedAsync()
    {
        DebugPrint("Ensuring session is initialized...");
        if (_isInitialized && _activeHandshake != null)
        {
            DebugPrint("Session is already initialized.");
            return;
        }

        await _initializationLock.WaitAsync().ConfigureAwait(false);
        try
        {
            if (_isInitialized && _activeHandshake != null)
            {
                DebugPrint("Session is already initialized.");
                return;
            }

            await InitializeSessionAsync().ConfigureAwait(false);
        }
        finally
        {
            _initializationLock.Release();
        }
    }

    public void Stop()
    {
        _cancellationSource.Cancel();
        DebugPrint("Stopping session...");
        CleanupCurrentSession();
        _isInitialized = false;
        _cancellationSource = new CancellationTokenSource();
        DebugPrint("Session stopped.");
    }

    private async Task InitializeSessionAsync()
    {
        DebugPrint("Initializing session...");
        CleanupCurrentSession();

        _activeHandshake = CreateHandshakeMessage();
        try
        {
            _pipeline.Send(_activeHandshake);
            var response = _activeHandshake.Response;

            if (response?.IsError == true)
            {
                throw new InvalidOperationException($"Failed to initialize SSE connection: {response.Status}");
            }

            StartSseProcessing(response!.ContentStream!);

            // Get the message endpoint from the server
            _messageEndpoint = await GetMessageEndpointAsync().ConfigureAwait(false);
            await SendInitializeAsync().ConfigureAwait(false);
            _isInitialized = true;
        }
        catch
        {
            CleanupCurrentSession();
            throw;
        }
    }

    private void StartSseProcessing(Stream responseStream)
    {
        var streamReader = new StreamReader(responseStream);
        _ = Task.Run(async () =>
        {
            try
            {
                await ProcessSseStreamAsync(streamReader).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DebugPrint($"SSE processing failed: {ex.Message}");
                _isInitialized = false;
            }
        }, _cancellationSource.Token);
    }

    private async Task ProcessSseStreamAsync(StreamReader streamReader)
    {
        string eventName = string.Empty;
        var dataBuilder = new StringBuilder();

        try
        {
            while (!_cancellationSource.Token.IsCancellationRequested)
            {
                DebugPrint("Reading line from SSE stream...");
#if !NETSTANDARD2_0
                string? line = await streamReader.ReadLineAsync(_cancellationSource.Token).ConfigureAwait(false);
#else
                string? line = await streamReader.ReadLineAsync().ConfigureAwait(false);
#endif
                if (line == null)
                {
                    throw new IOException("SSE stream closed unexpectedly");
                }

                DebugPrint($"Received line: '{line}'");

                if (line.StartsWith("event:", StringComparison.OrdinalIgnoreCase))
                {
                    eventName = line.AsSpan(6).Trim().ToString();
                }
                else if (line.StartsWith("data:"))
                {
#if !NETSTANDARD2_0
                    dataBuilder.Append(line.AsSpan(5));
#else
                    dataBuilder.Append(line.AsSpan(5).ToString());
#endif
                }
                else if (string.IsNullOrEmpty(line) && dataBuilder.Length > 0)
                {
                    var sseEvent = new SseEvent(eventName, dataBuilder.ToString().TrimEnd());
                    await ProcessEventAsync(sseEvent).ConfigureAwait(false);
                    eventName = string.Empty;
                    dataBuilder.Clear();
                }
            }
            DebugPrint("SSE stream processing stopped.");
        }
        catch (Exception ex)
        {
            DebugPrint($"Error processing SSE stream: {ex.Message}");
        }
        finally
        {
            CleanupCurrentSession();
        }
    }

    private async Task ProcessEventAsync(SseEvent sseEvent)
    {
        switch (sseEvent.Event)
        {
            case "endpoint":
                if (_endpointTcs != null)
                {
                    var serverUri = _serverEndpoint;
                    var endpoint = serverUri.GetLeftPart(UriPartial.Authority);
                    var messageEndpoint = $"{endpoint}{sseEvent.Data.Trim()}";
                    _endpointTcs.TrySetResult(messageEndpoint);
                }
                break;

            case "message":
            case "": // Handle empty event name as a message
                DebugPrint($"Received message: {sseEvent.Data}");
                await _messageRouter.RouteMessageAsync(sseEvent).ConfigureAwait(false);
                break;

            default:
                DebugPrint($"Unknown event: {sseEvent.Event}");
                break;
        }
    }

    private async Task<string> GetMessageEndpointAsync()
    {
        if (!string.IsNullOrEmpty(_messageEndpoint))
        {
            return _messageEndpoint;
        }

        _endpointTcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        using var registration = cts.Token.Register(() =>
            _endpointTcs.TrySetException(new TimeoutException("Timeout waiting for endpoint event")));

        try
        {
            return await _endpointTcs.Task.ConfigureAwait(false);
        }
        finally
        {
            _endpointTcs = null;
        }
    }

    private async Task SendInitializeAsync()
    {
        var id = GetNextId();
        var initializeTcs = new TaskCompletionSource<Task>(TaskCreationOptions.RunContinuationsAsynchronously);

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

        // Register handler for initialize response
        _messageRouter.RegisterHandler(id, async (sseEvent) =>
        {
            try
            {
                // Send initialized notification after receiving initialize response
                string initialized = $$"""
                    {
                        "jsonrpc": "2.0",
                        "method": "notifications/initialized"
                    }
                    """;

                await SendAsync(initialized).ConfigureAwait(false);
                initializeTcs.SetResult(Task.CompletedTask);
            }
            catch (Exception ex)
            {
                initializeTcs.SetException(ex);
            }
        });

        await SendAsync(json).ConfigureAwait(false);

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        using var registration = cts.Token.Register(() => initializeTcs.TrySetCanceled());

        await initializeTcs.Task.ConfigureAwait(false);
    }

    private PipelineMessage CreateHandshakeMessage()
    {
        var message = _pipeline.CreateMessage();
        var request = message.Request;
        request.Uri = _serverEndpoint;
        request.Method = "GET";
        request.Headers.Add("Accept", "text/event-stream");
        message.BufferResponse = false;
        return message;
    }

    private int GetNextId()
    {
        return Interlocked.Increment(ref _nextId);
    }

    public async Task<BinaryData> SendMethod(string methodName)
    {
        await EnsureInitializedAsync().ConfigureAwait(false);
        var id = GetNextId();
        var completionSource = new TaskCompletionSource<BinaryData>(TaskCreationOptions.RunContinuationsAsynchronously);
        string json = $$"""
        {
          "jsonrpc" : "2.0",
          "id" : {{id}},
          "method" : "{{methodName}}"
        }
        """;

        _messageRouter.RegisterHandler(id, (sseEvent) =>
        {
            try
            {
                using JsonDocument doc = JsonDocument.Parse(sseEvent.Data);
                var messageResult = doc.RootElement
                    .GetProperty("result");

                var resultJson = messageResult.GetRawText();
                completionSource.SetResult(BinaryData.FromString(resultJson));
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

    public async Task<BinaryData> CallTool(string toolName, BinaryData arguments)
    {
        await EnsureInitializedAsync().ConfigureAwait(false);
        var id = GetNextId();
        var completionSource = new TaskCompletionSource<BinaryData>(TaskCreationOptions.RunContinuationsAsynchronously);

        string json = $$"""
        {
          "jsonrpc": "2.0",
          "id": {{id}},
          "method": "tools/call",
          "params": {
            "name": "{{toolName}}",
            "arguments": {{arguments}}
          }
        }
        """;

        _messageRouter.RegisterHandler(id, (sseEvent) =>
        {
            try
            {
                using JsonDocument doc = JsonDocument.Parse(sseEvent.Data);
                var messageResult = doc.RootElement
                    .GetProperty("result");

                var resultJson = messageResult.GetRawText();
                completionSource.SetResult(BinaryData.FromString(resultJson));
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

    public async Task SendAsync(string json)
    {
        DebugPrint($"sending:\n {json}\n");
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
    }

    private void CleanupCurrentSession()
    {
        if (_activeHandshake != null)
        {
            _activeHandshake.Dispose();
            _activeHandshake = null;
        }
        _isInitialized = false;
    }

    public void Dispose()
    {
        _cancellationSource.Cancel();
        CleanupCurrentSession();
        _initializationLock.Dispose();
        _cancellationSource.Dispose();
    }

    public struct SseEvent
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
            if (string.IsNullOrEmpty(sseEvent.Data))
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
                    DebugPrint($"Error in message handler for ID {id}: {ex.Message}");
                }
            }
        }

        private static int ExtractId(string jsonPayload)
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
                DebugPrint($"Error parsing JSON: {ex.Message}");
                return -1;
            }
        }
    }

    private static void DebugPrint(string message)
    {
#if DEBUGPRINT
        var color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGray;// This is a placeholder for a debug print functi
        Console.WriteLine(message);
        Console.ForegroundColor = color;
#endif
    }
}
