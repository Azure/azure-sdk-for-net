# Customer Service Bot Sample

This sample demonstrates how to build a sophisticated customer service voice bot using the Azure VoiceLive SDK with function calling capabilities. The bot provides real-time voice interaction for common customer service scenarios including order tracking, account management, returns processing, and technical support scheduling.

## Features Demonstrated

### Core Capabilities
- **Natural Voice Conversation**: Real-time speech-to-speech interaction with proper interruption handling
- **Function Calling**: Strongly-typed function definitions and execution using the VoiceLive SDK
- **Customer Service Operations**: Complete workflows for common support scenarios
- **Professional Voice Experience**: Optimized for customer-facing interactions

### Supported Functions

#### 1. Order Status Checking (`check_order_status`)
- Look up orders by order number
- Display order status, items, tracking, and delivery information
- Handle order not found scenarios gracefully

#### 2. Customer Information Retrieval (`get_customer_info`)
- Retrieve customer account details by ID or email
- Optional inclusion of purchase history
- Customer tier and membership information

#### 3. Support Call Scheduling (`schedule_support_call`)
- Schedule technical support calls with specialists
- Categorize issues (technical, billing, warranty, returns)
- Set urgency levels and preferred times
- Generate support tickets

#### 4. Return Processing (`initiate_return_process`)
- Start return/exchange workflows
- Support multiple return reasons and types
- Generate return labels and tracking
- Validate return eligibility

#### 5. Shipping Address Updates (`update_shipping_address`)
- Update shipping addresses for pending orders
- Validate order modification eligibility
- Adjust delivery estimates accordingly

## Architecture

### Clean Separation of Concerns
```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│ CustomerService │────│ VoiceLive SDK   │────│ Business Logic  │
│ Bot             │    │ Protocol        │    │ Layer          │
└─────────────────┘    └─────────────────┘    └─────────────────┘
         │                       │                       │
         │                       │                       │
    ┌─────────┐           ┌─────────────┐        ┌─────────────┐
    │ Audio   │           │ Function    │        │ External    │
    │ Handler │           │ Calling     │        │ Services    │
    └─────────┘           └─────────────┘        └─────────────┘
```

### Key Components

1. **CustomerServiceBot**: Main orchestrator handling VoiceLive session and event processing
2. **CustomerServiceFunctions**: Business logic implementation with mock data
3. **AudioProcessor**: Real-time audio capture and playback (shared with BasicVoiceAssistant)
4. **FunctionModels**: Strongly-typed request/response models

## Getting Started

### Prerequisites

- .NET 8.0 or later
- Azure VoiceLive API key
- Audio input/output devices (microphone and speakers)

### Setup

1. **Configure API Key**:
   ```bash
   # Set environment variable
   export AZURE_VOICELIVE_API_KEY="your_api_key_here"
   
   # Or update appsettings.json
   cp appsettings.template.json appsettings.json
   # Edit appsettings.json with your API key
   ```

2. **Install Dependencies**:
   ```bash
   dotnet restore
   ```

3. **Run the Sample**:
   ```bash
   dotnet run
   ```

### Command Line Options

```bash
dotnet run --help

Customer Service Bot using Azure VoiceLive SDK with Function Calling

Options:
  --api-key <api-key>              Azure VoiceLive API key
  --endpoint <endpoint>            Azure VoiceLive endpoint [default: wss://api.voicelive.com/v1]
  --model <model>                  VoiceLive model to use [default: gpt-4o]
  --voice <voice>                  Voice for the bot [default: en-US-JennyNeural]
  --instructions <instructions>    System instructions for the bot
  --use-token-credential          Use Azure token credential instead of API key
  --verbose                        Enable verbose logging
  --help                           Show help message
```

## Sample Data

The bot includes realistic sample data for demonstration:

### Orders
- **ORD-2024-001**: Processing laptop order ($299.99)
- **ORD-2024-002**: Shipped gaming accessories ($159.98)
- **ORD-2024-003**: Delivered monitor ($499.99)

### Customers
- **john.smith@email.com**: Gold tier customer with purchase history
- **sarah.johnson@email.com**: Silver tier customer
- **mike.davis@email.com**: Standard tier customer

### Products
- **LAPTOP-001**: TechCorp Laptop Pro
- **MOUSE-001**: Wireless Gaming Mouse
- **MONITOR-001**: 4K Gaming Monitor

## Usage Examples

### Voice Interactions

Try these sample phrases:

1. **Order Status**:
   - "What's the status of order ORD-2024-001?"
   - "Can you track my order ORD-2024-002?"

2. **Customer Info**:
   - "Look up my account for john.smith@email.com"
   - "Show me my account info and purchase history"

3. **Returns**:
   - "I need to return a defective laptop from order ORD-2024-001"
   - "How do I exchange this monitor for a different size?"

4. **Support Scheduling**:
   - "I need to schedule a technical support call"
   - "Can you book me a warranty call for tomorrow?"

5. **Address Updates**:
   - "I need to change the shipping address for order ORD-2024-001"
   - "Update my delivery address to a new location"

### Expected Responses

The bot provides detailed, conversational responses:

```
🎤 "What's the status of order ORD-2024-001?"

🔧 Looking up check order status...

🤖 "I found your order ORD-2024-001. It's currently being processed 
    and contains one TechCorp Laptop Pro for $299.99. Your estimated 
    delivery date is January 15th, and the tracking number is 
    1Z999AA1234567890. Is there anything else you'd like to know 
    about this order?"
```

## Implementation Details

### Function Tool Definitions

The bot uses strongly-typed function definitions with comprehensive parameter schemas:

```csharp
private FunctionTool CreateCheckOrderStatusTool()
{
    var parameters = new
    {
        type = "object",
        properties = new
        {
            order_number = new { 
                type = "string", 
                description = "The customer's order number (required)" 
            },
            email = new { 
                type = "string", 
                description = "Customer's email address if order number is not available" 
            }
        },
        required = new[] { "order_number" }
    };

    return new FunctionTool("check_order_status")
    {
        Description = "Check the status of a customer order by order number or email...",
        Parameters = BinaryData.FromObjectAsJson(parameters)
    };
}
```

### Event-Driven Architecture

The bot handles VoiceLive events with proper pattern matching:

```csharp
switch (serverEvent)
{
    case ServerEventResponseOutputItemAdded outputItemAdded:
        await HandleResponseOutputItemAddedAsync(outputItemAdded, cancellationToken);
        break;
        
    case ServerEventInputAudioBufferSpeechStarted:
        // Handle interruption...
        break;
        
    case ServerEventError errorEvent:
        // Handle errors gracefully...
        break;
}
```

### Function Execution Flow

1. **Function Call Detection**: Monitor `ServerEventResponseOutputItemAdded` events
2. **Function Extraction**: Parse function name, call ID, and arguments
3. **Business Logic Execution**: Delegate to `CustomerServiceFunctions`
4. **Result Formatting**: Serialize response data
5. **Response Transmission**: Send results via `RequestFunctionCallOutputItem`

### Error Handling

The implementation includes comprehensive error handling:

- **Network Issues**: Graceful degradation and retry logic
- **Invalid Parameters**: Clear user feedback and guidance
- **Function Failures**: Professional error messages
- **Audio Problems**: System checks and diagnostics

## Configuration

### Session Options

```json
{
  "VoiceLive": {
    "Model": "gpt-4o",
    "Voice": "en-US-JennyNeural",
    "Instructions": "You are a professional customer service representative...",
    "InputAudioFormat": "Pcm16",
    "OutputAudioFormat": "Pcm16",
    "TurnDetection": {
      "Type": "ServerVad",
      "Threshold": 0.5,
      "SilenceDurationMs": 500
    }
  }
}
```

### Logging Configuration

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Azure.AI.VoiceLive": "Debug"
    }
  }
}
```

## Extending the Sample

### Adding New Functions

1. **Define Function Model**:
   ```csharp
   public class NewFunctionArgs
   {
       public string parameter1 { get; set; } = string.Empty;
       public int parameter2 { get; set; }
   }
   ```

2. **Implement Business Logic**:
   ```csharp
   private async Task<object> ExecuteNewFunctionAsync(string argumentsJson, CancellationToken cancellationToken)
   {
       var args = JsonSerializer.Deserialize<NewFunctionArgs>(argumentsJson);
       // Implementation here
       return new { success = true, result = "..." };
   }
   ```

3. **Register Function Tool**:
   ```csharp
   sessionOptions.Tools.Add(CreateNewFunctionTool());
   ```

### Integrating External Services

Replace the mock implementations in `CustomerServiceFunctions` with actual service calls:

```csharp
private async Task<object> CheckOrderStatusAsync(string argumentsJson, CancellationToken cancellationToken)
{
    var args = JsonSerializer.Deserialize<CheckOrderStatusArgs>(argumentsJson);
    
    // Replace with actual service call
    var order = await _orderService.GetOrderAsync(args.order_number, cancellationToken);
    
    return new { success = true, order = order };
}
```

## Troubleshooting

### Common Issues

1. **No Audio Devices**:
   - Ensure microphone and speakers are connected
   - Check system audio settings
   - Verify device permissions

2. **API Key Issues**:
   - Verify API key is correct
   - Check environment variable or appsettings.json
   - Ensure proper Azure subscription

3. **Function Call Failures**:
   - Check function parameter schemas
   - Verify business logic implementation
   - Review error logs for details

4. **Session Configuration**:
   - Ensure all required tools are properly registered
   - Verify voice configuration is valid
   - Check model availability

### Debug Logging

Enable verbose logging to troubleshoot issues:

```bash
dotnet run --verbose
```

Or set logging level in appsettings.json:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Azure.AI.VoiceLive.Samples": "Trace"
    }
  }
}
```

## Performance Considerations

- **Function Execution Time**: Keep business logic fast (< 2 seconds)
- **Audio Buffer Management**: Proper cleanup to prevent memory leaks
- **Concurrent Function Calls**: Handle parallel function execution
- **Error Recovery**: Implement retry logic for transient failures

## Security Notes

- **Data Validation**: Always validate function parameters
- **Input Sanitization**: Clean user inputs before processing
- **Error Information**: Don't expose sensitive data in error messages
- **Audit Logging**: Log all customer service interactions

## Related Samples

- **BasicVoiceAssistant**: Foundation for voice interaction patterns
- **TranscriptionSample**: Speech-to-text focused scenarios
- **ConversationAnalysis**: Advanced conversation insights

## Learning Resources

---

This sample demonstrates production-ready patterns for building sophisticated voice-enabled customer service applications using the Azure VoiceLive SDK.
