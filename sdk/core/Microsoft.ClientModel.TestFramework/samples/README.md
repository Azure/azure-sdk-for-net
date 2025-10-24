---
page_type: sample
languages:
- csharp
products:
- dotnet-api
name: Microsoft.ClientModel.TestFramework samples for .NET
description: Samples for the Microsoft.ClientModel.TestFramework library
---

# Microsoft.ClientModel.TestFramework Samples

The Microsoft.ClientModel.TestFramework provides comprehensive testing capabilities for client libraries built on System.ClientModel. These samples demonstrate the key features and best practices for testing your client libraries.

## Sample Categories

### [Recorded Tests](RecordedTests.md)
Learn how to use the Test Framework's recording capabilities to create deterministic, fast-running tests that can be executed against live services or recorded interactions.

- Setting up recorded test classes
- Creating and managing test environments
- Recording and playing back HTTP interactions
- Sanitizing sensitive data in recordings
- Working with the test proxy

### [Sync/Async Testing](SyncAsync.md)
Discover how to write tests that automatically validate both synchronous and asynchronous code paths with a single test implementation.

- Using `ClientTestBase` for dual-mode testing
- Instrumenting clients for sync/async compatibility
- Managing test fixtures and attributes
- Handling async-only and sync-only scenarios

### [Unit Testing](UnitTests.md)
Explore the mock utilities and testing helpers that enable comprehensive unit testing of your client libraries.

- Using `MockCredential` for authentication testing
- Leveraging `MockPipelineTransport` for HTTP simulation
- Creating custom mock responses
- Testing error scenarios and edge cases

### [Test Utilities](TestUtilities.md)
Learn about the advanced utilities and helpers available in the Test Framework for specialized testing scenarios.

- Environment variable management
- Test randomization and seeding
- Custom pipeline policies for testing
- Debugging and troubleshooting tools

## Getting Started

To use these samples in your own projects:

1. Add a reference to `Microsoft.ClientModel.TestFramework` in your test project
2. Follow the patterns shown in the sample code
3. Adapt the examples to your specific client library requirements
4. Run the sample tests to see the features in action

## Sample Test Code

All samples include executable test code that demonstrates the concepts in action. You can find the complete test implementations in the corresponding `*Samples.cs` files in the test project.

## Additional Resources

- [Microsoft.ClientModel.TestFramework README](../README.md)
- [System.ClientModel Documentation](../../System.ClientModel/README.md)
- [Azure SDK Testing Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#testing)