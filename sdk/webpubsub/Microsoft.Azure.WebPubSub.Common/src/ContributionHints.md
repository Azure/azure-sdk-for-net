# Contribution Hints

This file provides some hints for contributing to the Microsoft.Azure.WebPubSub.Common library.

## JSON serialization and deserialization

The main purpose of this project is to provide classes for JSON serialization and deserialization to the Azure Functions extensions and the `AspNetCore` project.

```mermaid
sequenceDiagram
    participant W as Web PubSub Service
    participant H as Functions Extensions (Host Process)
    participant WP as Functions Extensions (Worker Process)

    W->>H: Send HTTP Request
    H->>H: Deserialize HTTP Request using System.Text.Json

    H->>H: Serialize HTTP Request Body Object using Newtonsoft.Json
    H->>WP: Send JSON requests
    WP->>WP: Process Request in Worker Process

    WP->>H: Return JSON responses
    H->>H: Deserialize JSON Response using Newtonsoft.Json
    H->>H: Serialize into HTTP response using Newtonsoft.Json
    H->>W: Send HTTP Response
```

Currently all the classes for CloudEvents requests have customized JSON converters or customized deserialization classes. This is because in .NET framework, `System.Text.Json` cannot support deserialization of classes without a pameterless constructor. Therefore we need to customize the deserialization of these classes.