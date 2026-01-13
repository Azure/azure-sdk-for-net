# Test Utilities with Microsoft.ClientModel.TestFramework

This sample demonstrates the advanced utilities and helpers available in the test framework for specialized testing scenarios and common testing patterns.

## Environment Variable Management

### TestEnvVar Utility

The `TestEnvVar` utility provides a structured way to manage environment variables in tests:

```C# Snippet:TestEnvVarUsage
// Use TestEnvVar to temporarily set environment variables
using var testEnvVar = new TestEnvVar("TEST_SAMPLE_VALUE", "test-value");

// Retrieve the value that was set
var value = Environment.GetEnvironmentVariable("TEST_SAMPLE_VALUE");
Assert.That(value, Is.EqualTo("test-value"));

// Variable will be automatically restored to its original value when disposed
```

## Test Randomization

### TestRandom for Deterministic Values

Use `TestRandom` to generate deterministic random values in tests:

```C# Snippet:RandomId
string repeatableRandomId = Recording!.GenerateId();
```

```C# Snippet:RandomGuid
string repeatableGuid = Recording!.Random.NewGuid().ToString();
```

## Async Testing Extensions

### TaskExtensions for Testing

The framework provides extensions for working with async operations in tests:

```C# Snippet:AsyncEnumerableExtension
var items = GetAsyncItems();

// Use extension to collect async enumerable items
var collectedItems = await items.ToEnumerableAsync();
```