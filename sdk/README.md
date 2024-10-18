# Azure SDK Libraries

This directory contains various libraries for interacting with Azure services. Below is a detailed documentation for each library, including usage examples and common use cases.

## Azure App Configuration

Azure App Configuration is a managed service that helps developers centralize their application and feature settings simply and securely.

- **Library**: `Azure.Data.AppConfiguration`
- **Documentation**: [Azure App Configuration client library for .NET](appconfiguration/README.md)
- **Usage Example**:
  ```csharp
  var client = new ConfigurationClient(connectionString);
  var setting = client.GetConfigurationSetting("myKey");
  Console.WriteLine(setting.Value);
  ```
- **Common Use Cases**:
  - Centralizing application settings
  - Managing feature flags

## Azure Communication Services

Azure Communication Services provides cloud-based communication capabilities for applications.

- **Library**: `Azure.Communication`
- **Documentation**: [Azure Communication Services client library for .NET](communication/README.md)
- **Usage Example**:
  ```csharp
  var client = new CommunicationIdentityClient(connectionString);
  var user = client.CreateUser();
  Console.WriteLine(user.Id);
  ```
- **Common Use Cases**:
  - Adding voice, video, chat, and SMS capabilities to applications

## Azure Core

Azure Core provides shared primitives, abstractions, and helpers for modern .NET Azure SDK client libraries.

- **Library**: `Azure.Core`
- **Documentation**: [Azure Core shared client library for .NET](core/README.md)
- **Usage Example**:
  ```csharp
  var client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());
  var secret = client.GetSecret("mySecret");
  Console.WriteLine(secret.Value);
  ```
- **Common Use Cases**:
  - Configuring service clients
  - Accessing HTTP response details
  - Calling long-running operations

## Azure DevCenter

Azure DevCenter provides tools and services for managing development environments.

- **Library**: `Azure.DevCenter`
- **Documentation**: [Azure DevCenter client library for .NET](devcenter/README.md)
- **Usage Example**:
  ```csharp
  var client = new DevCenterClient(connectionString);
  var environment = client.GetEnvironment("myEnvironment");
  Console.WriteLine(environment.Name);
  ```
- **Common Use Cases**:
  - Managing development environments
  - Automating development workflows

## Azure Key Vault

Azure Key Vault helps safeguard cryptographic keys and secrets used by cloud applications and services.

- **Library**: `Azure.Security.KeyVault`
- **Documentation**: [Azure Key Vault client library for .NET](keyvault/README.md)
- **Usage Example**:
  ```csharp
  var client = new KeyClient(new Uri("http://example.com"), new DefaultAzureCredential());
  var key = client.GetKey("myKey");
  Console.WriteLine(key.Value);
  ```
- **Common Use Cases**:
  - Managing cryptographic keys
  - Storing and accessing secrets

## Azure Service Bus

Azure Service Bus is a fully managed enterprise message broker with message queues and publish-subscribe topics.

- **Library**: `Azure.Messaging.ServiceBus`
- **Documentation**: [Azure Service Bus client library for .NET](servicebus/README.md)
- **Usage Example**:
  ```csharp
  var client = new ServiceBusClient(connectionString);
  var sender = client.CreateSender("myQueue");
  sender.SendMessage(new ServiceBusMessage("Hello, world!"));
  ```
- **Common Use Cases**:
  - Decoupling applications
  - Implementing messaging patterns
