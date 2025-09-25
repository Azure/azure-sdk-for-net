// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.VoiceLive.Samples;

/// <summary>
/// Customer service voice bot implementing function calling with the VoiceLive SDK.
/// </summary>
/// <remarks>
/// This sample demonstrates how to build a sophisticated customer service bot that can:
/// - Check order status and track shipments
/// - Retrieve customer account information and history
/// - Schedule technical support calls
/// - Process returns and exchanges
/// - Update shipping addresses for pending orders
///
/// The bot uses strongly-typed function definitions and provides real-time voice interaction
/// with proper interruption handling and error recovery.
/// </remarks>
public class CustomerServiceBot : IDisposable
{
    private readonly VoiceLiveClient _client;
    private readonly string _model;
    private readonly string _voice;
    private readonly string _instructions;
    private readonly ICustomerServiceFunctions _functions;
    private readonly ILogger<CustomerServiceBot> _logger;
    private readonly ILoggerFactory _loggerFactory;

    private readonly HashSet<string> _assistantMessageItems = new HashSet<string>();
    private readonly HashSet<string> _assistantMessageResponses = new HashSet<string>();

    private VoiceLiveSession? _session;
    private AudioProcessor? _audioProcessor;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the CustomerServiceBot class.
    /// </summary>
    /// <param name="client">The VoiceLive client.</param>
    /// <param name="model">The model to use.</param>
    /// <param name="voice">The voice to use.</param>
    /// <param name="instructions">The system instructions.</param>
    /// <param name="functions">The customer service functions implementation.</param>
    /// <param name="loggerFactory">Logger factory for creating loggers.</param>
    public CustomerServiceBot(
        VoiceLiveClient client,
        string model,
        string voice,
        string instructions,
        ICustomerServiceFunctions functions,
        ILoggerFactory loggerFactory)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _model = model ?? throw new ArgumentNullException(nameof(model));
        _voice = voice ?? throw new ArgumentNullException(nameof(voice));
        _instructions = instructions ?? throw new ArgumentNullException(nameof(instructions));
        _functions = functions ?? throw new ArgumentNullException(nameof(functions));
        _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        _logger = loggerFactory.CreateLogger<CustomerServiceBot>();
    }

    /// <summary>
    /// Start the customer service bot session.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token for stopping the session.</param>
    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Connecting to VoiceLive API with model {Model}", _model);

            // Start VoiceLive session
            _session = await _client.StartSessionAsync(_model, cancellationToken).ConfigureAwait(false);

            // Initialize audio processor
            _audioProcessor = new AudioProcessor(_session, _loggerFactory.CreateLogger<AudioProcessor>());

            // Configure session for voice conversation with function calling
            await SetupSessionAsync(cancellationToken).ConfigureAwait(false);

            // Start audio systems
            await _audioProcessor.StartPlaybackAsync().ConfigureAwait(false);
            await _audioProcessor.StartCaptureAsync().ConfigureAwait(false);

            _logger.LogInformation("Customer service bot ready! Start speaking...");
            Console.WriteLine();
            Console.WriteLine("=" + new string('=', 69));
            Console.WriteLine("🏢 CUSTOMER SERVICE BOT READY");
            Console.WriteLine("I can help you with orders, returns, account info, and scheduling support calls");
            Console.WriteLine("Start speaking to begin your customer service session");
            Console.WriteLine("Press Ctrl+C to exit");
            Console.WriteLine("=" + new string('=', 69));
            Console.WriteLine();

            // Process events
            await ProcessEventsAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Received cancellation signal, shutting down...");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Connection error");
            throw;
        }
        finally
        {
            // Cleanup
            if (_audioProcessor != null)
            {
                await _audioProcessor.CleanupAsync().ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// Configure the VoiceLive session for customer service with function calling.
    /// </summary>
    private async Task SetupSessionAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Setting up customer service session with function calling...");

        // Azure voice configuration
        var azureVoice = new AzureStandardVoice(_voice);

        // Create strongly typed turn detection configuration
        var turnDetectionConfig = new ServerVadTurnDetection
        {
            Threshold = 0.5f,
            PrefixPadding = TimeSpan.FromMilliseconds(300),
            SilenceDuration = TimeSpan.FromMilliseconds(500)
        };

        // Create conversation session options with function tools
        var sessionOptions = new VoiceLiveSessionOptions
        {
            Model = _model,
            Instructions = _instructions,
            Voice = azureVoice,
            InputAudioFormat = InputAudioFormat.Pcm16,
            OutputAudioFormat = OutputAudioFormat.Pcm16,
            TurnDetection = turnDetectionConfig
        };

        // Ensure modalities include audio
        sessionOptions.Modalities.Clear();
        sessionOptions.Modalities.Add(InteractionModality.Text);
        sessionOptions.Modalities.Add(InteractionModality.Audio);

        // Add function tools for customer service operations
        sessionOptions.Tools.Add(CreateCheckOrderStatusTool());
        sessionOptions.Tools.Add(CreateGetCustomerInfoTool());
        sessionOptions.Tools.Add(CreateScheduleSupportCallTool());
        sessionOptions.Tools.Add(CreateInitiateReturnProcessTool());
        sessionOptions.Tools.Add(CreateUpdateShippingAddressTool());


        await _session!.ConfigureSessionAsync(sessionOptions, cancellationToken).ConfigureAwait(false);

        _logger.LogInformation("Session configuration sent with {ToolCount} customer service tools", sessionOptions.Tools.Count);
    }

    /// <summary>
    /// Create the check order status function tool.
    /// </summary>
    private VoiceLiveFunctionDefinition CreateCheckOrderStatusTool()
    {
        var parameters = new
        {
            type = "object",
            properties = new
            {
                order_number = new
                {
                    type = "string",
                    description = "The customer's order number (required)"
                },
                email = new
                {
                    type = "string",
                    description = "Customer's email address if order number is not available"
                }
            },
            required = new[] { "order_number" }
        };

        return new VoiceLiveFunctionDefinition("check_order_status")
        {
            Description = "Check the status of a customer order by order number or email. Use this when customers ask about their order status, shipping, or delivery information.",
            Parameters = BinaryData.FromObjectAsJson(parameters)
        };
    }

    /// <summary>
    /// Create the get customer info function tool.
    /// </summary>
    private VoiceLiveFunctionDefinition CreateGetCustomerInfoTool()
    {
        var parameters = new
        {
            type = "object",
            properties = new
            {
                customer_id = new
                {
                    type = "string",
                    description = "Customer ID or email address to look up"
                },
                include_history = new
                {
                    type = "boolean",
                    description = "Whether to include recent purchase history in the response",
                    @default = false
                }
            },
            required = new[] { "customer_id" }
        };

        return new VoiceLiveFunctionDefinition("get_customer_info")
        {
            Description = "Retrieve customer account information and optionally their purchase history. Use this when customers ask about their account details or past orders.",
            Parameters = BinaryData.FromObjectAsJson(parameters)
        };
    }

    /// <summary>
    /// Create the schedule support call function tool.
    /// </summary>
    private VoiceLiveFunctionDefinition CreateScheduleSupportCallTool()
    {
        var parameters = new
        {
            type = "object",
            properties = new
            {
                customer_id = new
                {
                    type = "string",
                    description = "Customer identifier (ID or email)"
                },
                preferred_time = new
                {
                    type = "string",
                    description = "Preferred call time in ISO format (optional)"
                },
                issue_category = new
                {
                    type = "string",
                    @enum = new[] { "technical", "billing", "warranty", "returns" },
                    description = "Category of the support issue"
                },
                urgency = new
                {
                    type = "string",
                    @enum = new[] { "low", "medium", "high", "critical" },
                    description = "Urgency level of the issue",
                    @default = "medium"
                },
                description = new
                {
                    type = "string",
                    description = "Brief description of the issue the customer needs help with"
                }
            },
            required = new[] { "customer_id", "issue_category", "description" }
        };

        return new VoiceLiveFunctionDefinition("schedule_support_call")
        {
            Description = "Schedule a technical support call with a specialist. Use this when customers need to speak with a technical expert about complex issues.",
            Parameters = BinaryData.FromObjectAsJson(parameters)
        };
    }

    /// <summary>
    /// Create the initiate return process function tool.
    /// </summary>
    private VoiceLiveFunctionDefinition CreateInitiateReturnProcessTool()
    {
        var parameters = new
        {
            type = "object",
            properties = new
            {
                order_number = new
                {
                    type = "string",
                    description = "Original order number for the return"
                },
                product_id = new
                {
                    type = "string",
                    description = "Specific product ID to return from the order"
                },
                reason = new
                {
                    type = "string",
                    @enum = new[] { "defective", "wrong_item", "not_satisfied", "damaged_shipping" },
                    description = "Reason for the return"
                },
                return_type = new
                {
                    type = "string",
                    @enum = new[] { "refund", "exchange", "store_credit" },
                    description = "Type of return requested by the customer"
                }
            },
            required = new[] { "order_number", "product_id", "reason", "return_type" }
        };

        return new VoiceLiveFunctionDefinition("initiate_return_process")
        {
            Description = "Start the return/exchange process for a product. Use this when customers want to return or exchange items they've purchased.",
            Parameters = BinaryData.FromObjectAsJson(parameters)
        };
    }

    /// <summary>
    /// Create the update shipping address function tool.
    /// </summary>
    private VoiceLiveFunctionDefinition CreateUpdateShippingAddressTool()
    {
        var parameters = new
        {
            type = "object",
            properties = new
            {
                order_number = new
                {
                    type = "string",
                    description = "Order number to update the shipping address for"
                },
                new_address = new
                {
                    type = "object",
                    properties = new
                    {
                        street = new { type = "string", description = "Street address" },
                        city = new { type = "string", description = "City name" },
                        state = new { type = "string", description = "State or province" },
                        zip_code = new { type = "string", description = "ZIP or postal code" },
                        country = new { type = "string", description = "Country code", @default = "US" }
                    },
                    required = new[] { "street", "city", "state", "zip_code" },
                    description = "New shipping address information"
                }
            },
            required = new[] { "order_number", "new_address" }
        };

        return new VoiceLiveFunctionDefinition("update_shipping_address")
        {
            Description = "Update shipping address for pending orders. Use this when customers need to change where their order will be delivered.",
            Parameters = BinaryData.FromObjectAsJson(parameters)
        };
    }

    /// <summary>
    /// Process events from the VoiceLive session.
    /// </summary>
    private async Task ProcessEventsAsync(CancellationToken cancellationToken)
    {
        try
        {
            await foreach (SessionUpdate serverEvent in _session!.GetUpdatesAsync(cancellationToken).ConfigureAwait(false))
            {
                await HandleSessionUpdateAsync(serverEvent, cancellationToken).ConfigureAwait(false);
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Event processing cancelled");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing events");
            throw;
        }
    }

    /// <summary>
    /// Handle different types of server events from VoiceLive.
    /// </summary>
    private async Task HandleSessionUpdateAsync(SessionUpdate serverEvent, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Received event: {EventType}", serverEvent.GetType().Name);

        switch (serverEvent)
        {
            case SessionUpdateSessionCreated sessionCreated:
                await HandleSessionCreatedAsync(sessionCreated, cancellationToken).ConfigureAwait(false);
                break;

            case SessionUpdateSessionUpdated sessionUpdated:
                _logger.LogInformation("Session updated successfully with function tools");

                // Start audio capture once session is ready
                if (_audioProcessor != null)
                {
                    await _audioProcessor.StartCaptureAsync().ConfigureAwait(false);
                }
                break;

            case SessionUpdateInputAudioBufferSpeechStarted speechStarted:
                _logger.LogInformation("🎤 Customer started speaking - stopping playback");
                Console.WriteLine("🎤 Listening...");

                // Stop current assistant audio playback (interruption handling)
                if (_audioProcessor != null)
                {
                    await _audioProcessor.StopPlaybackAsync().ConfigureAwait(false);
                }

                // Cancel any ongoing response
                try
                {
                    await _session!.CancelResponseAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _logger.LogDebug(ex, "No response to cancel");
                }
                break;

            case SessionUpdateInputAudioBufferSpeechStopped speechStopped:
                _logger.LogInformation("🎤 Customer stopped speaking");
                Console.WriteLine("🤔 Processing...");

                // Restart playback system for response
                if (_audioProcessor != null)
                {
                    await _audioProcessor.StartPlaybackAsync().ConfigureAwait(false);
                }
                break;

            case SessionUpdateResponseCreated responseCreated:
                _logger.LogInformation("🤖 Assistant response created");
                break;

            case SessionUpdateResponseOutputItemAdded outputItemAdded:
                await HandleResponseOutputItemAddedAsync(outputItemAdded, cancellationToken).ConfigureAwait(false);
                break;

            case SessionUpdateResponseAudioDelta audioDelta:
                // Stream audio response to speakers
                _logger.LogDebug("Received audio delta");

                if (audioDelta.Delta != null && _audioProcessor != null)
                {
                    byte[] audioData = audioDelta.Delta.ToArray();
                    await _audioProcessor.QueueAudioAsync(audioData).ConfigureAwait(false);
                }
                break;

            case SessionUpdateResponseAudioDone audioDone:
                _logger.LogInformation("🤖 Assistant finished speaking");
                Console.WriteLine("🎤 Ready for next customer inquiry...");
                break;

            case SessionUpdateResponseContentPartAdded partAdded:
                if (_assistantMessageItems.Contains(partAdded.ItemId))
                {
                    _assistantMessageResponses.Add(partAdded.ResponseId);
                }

                break;
            case SessionUpdateResponseDone responseDone:
                _logger.LogInformation("✅ Response complete");
                break;
            case SessionUpdateResponseFunctionCallArgumentsDone functionCallArgumentsDone:
                _logger.LogInformation("🔧 Function call arguments done for call ID: {CallId}", functionCallArgumentsDone.CallId);
                await HandleFunctionCallAsync(functionCallArgumentsDone.Name, functionCallArgumentsDone.CallId, functionCallArgumentsDone.Arguments, cancellationToken).ConfigureAwait(false);
                break;
            case SessionUpdateResponseAudioTranscriptDelta transcriptDelta:
                // For now, only deal with the assistant responses.
                if (_assistantMessageResponses.Contains(transcriptDelta.ResponseId))
                {
                    Console.Write($"{transcriptDelta.Delta}");
                }
                break;

            case SessionUpdateResponseAudioTranscriptDone transcriptDone:
                // For now, only deal with the assistant responses.
                if (_assistantMessageResponses.Contains(transcriptDone.ResponseId))
                {
                    Console.WriteLine();
                }
                break;
            case SessionUpdateError errorEvent:
                _logger.LogError("❌ VoiceLive error: {ErrorMessage}", errorEvent.Error?.Message);
                Console.WriteLine($"Error: {errorEvent.Error?.Message}");
                break;

            default:
                _logger.LogDebug("Unhandled event type: {EventType}", serverEvent.GetType().Name);
                break;
        }
    }

    /// <summary>
    /// Handle response output item added events, including function calls.
    /// </summary>
    private async Task HandleResponseOutputItemAddedAsync(SessionUpdateResponseOutputItemAdded outputItemAdded, CancellationToken cancellationToken)
    {
        if (outputItemAdded.Item is ResponseFunctionCallItem item)
        {
            // This is a function call item, extract the details
            var functionName = item.Name;
            var callId = item.CallId;
            var arguments = item.Arguments;

            if (!string.IsNullOrEmpty(functionName) && !string.IsNullOrEmpty(callId) && !string.IsNullOrEmpty(arguments))
            {
                await HandleFunctionCallAsync(functionName, callId, arguments, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _logger.LogWarning("Function call item missing required properties: Name={Name}, CallId={CallId}, Arguments={Arguments}",
                    functionName, callId, arguments);
            }
        }
        else if (outputItemAdded.Item is ResponseMessageItem messageItem &&
            messageItem.Role == ResponseMessageRole.Assistant)
        {
            // Keep track of the items that are from the assistant, so we know how to display the conversation.
            _assistantMessageItems.Add(messageItem.Id);
        }
    }

    /// <summary>
    /// Handle function call execution and send results back to the session.
    /// </summary>
    private async Task HandleFunctionCallAsync(string functionName, string callId, string arguments, CancellationToken cancellationToken)
    {
        _logger.LogInformation("🔧 Executing function: {FunctionName}", functionName);
        Console.WriteLine($"🔧 Looking up {functionName.Replace("_", " ")}...");

        try
        {
            // Execute the function through our business logic layer
            var result = await _functions.ExecuteFunctionAsync(functionName, arguments, cancellationToken).ConfigureAwait(false);

            // Create function call output item using the model factory
            var outputItem = new FunctionCallOutputItem(callId, JsonSerializer.Serialize(result));

            // Add the result to the conversation
            await _session!.AddItemAsync(outputItem, cancellationToken).ConfigureAwait(false);
            await _session!.StartResponseAsync(cancellationToken).ConfigureAwait(false);

            _logger.LogInformation("✅ Function {FunctionName} completed successfully", functionName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "❌ Function {FunctionName} execution failed", functionName);

            // Send error response
            var errorResult = new { success = false, error = "I'm sorry, I'm having trouble accessing that information right now. Please try again in a moment." };
            var outputItem = new FunctionCallOutputItem(callId, JsonSerializer.Serialize(errorResult));

            await _session!.AddItemAsync(outputItem, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Handle session created event.
    /// </summary>
    private async Task HandleSessionCreatedAsync(SessionUpdateSessionCreated sessionCreated, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Session ready: {SessionId}", sessionCreated.Session?.Id);

        // Start audio capture once session is ready
        if (_audioProcessor != null)
        {
            await _audioProcessor.StartCaptureAsync().ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Dispose of resources.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
            return;

        _audioProcessor?.Dispose();
        _session?.Dispose();
        _disposed = true;
    }
}
