---
applyTo: '**'
---

If you are writing code follow [Writing code](#writing-code)
If you are writing samples follow [Writing samples](#writing-samples)
If you are writing tests follow [Integration test development](#integration-test-development) or [Unit test development](#unit-test-development)

---

# Writing code

Follow general C# best practices.

# Writing samples

Should be .md files and should cover champion scenarios with concise and straightforward text. Avoid excessive comments in code snippets.

# Integration test development

You are writing integration tests for a given feature. Assume that all fine-grained unit testing is already done elsewhere. These tests should specifically focus on end to end features and should use live resources or a test server instead of mocking. These tests will be much longer and more complex than unit testing.

# Unit test development

You are writing unit tests for a given class. The absolute most important thing to do is to get full coverage for meaningful behavior and logic. It is especially important NOT to test trivial implementation details or compiler guarantees, such as if a method exists or if a class is abstract.

## Core Testing Principles
- Do not include Arrange/Act/Assert comments, instead focus on making the code structure self-evident
- Test all modes/scenarios systematically, prefer [TestCase] attributes if possible to reduce lines of code
- For edge cases: Include null values, empty collections, boundary conditions, and error scenarios
- Once a pattern is established, follow it across similar tests
- Focus on the actual functionality of the code being tested and assume everything else works as expected. For example, don't test that NUnit works, that mocks work, or other third-party functionality
- Each test should test one specific behavior or scenario
- Don't test that properties return values they were set to, or that constructors assign parameters
- **Never use Assert.Pass()**: If something isn't meaningfully testable at the unit level, delete the test rather than using `Assert.Pass()` - it creates false coverage and test noise

## Mocking Guidelines

**Use Mock<T> when:**
- Testing interactions/method calls between components
- Need to verify specific method calls with parameters (`Times.Once`, `Times.Never`)
- Need to setup different return values for different scenarios
- Testing complex object behavior where you need fine-grained control

**Use Built-in Mocks (MockPipelineTransport, etc.) when:**
- Testing HTTP pipeline behavior
- Need realistic request/response simulation
- Framework provides pre-built mocks that match the domain
- Testing transport-layer functionality

Samples for using built-in mocks:

```csharp
// Basic mock credential with default token
var mockCredential = new MockCredential();

// Custom mock credential with specific token and expiration
var customCredential = new MockCredential(
    token: "custom-bearer-token", 
    expiresOn: DateTimeOffset.UtcNow.AddHours(2));

// Use in client creation
var options = new MyClientOptions();
options.AuthenticationProvider = customCredential;
var client = new MyClient(endpoint, options);
```

```csharp
// Simple transport that always returns 200 OK
var transport = new MockPipelineTransport();

// Custom transport with response factory
var transport = new MockPipelineTransport(message =>
{
    if (message.Request.Uri.Path.Contains("/users"))
    {
        return new MockPipelineResponse(200)
            .WithHeader("Content-Type", "application/json")
            .WithContent("""{"users": []}""");
    }
    
    return new MockPipelineResponse(404)
        .WithContent("Not found");
});

// Use in client pipeline
var options = new ClientPipelineOptions { Transport = transport };
var pipeline = ClientPipeline.Create(options);
```

```csharp
// Basic 200 response
var response = new MockPipelineResponse(200, "OK");

// Response with headers and JSON content
var response = new MockPipelineResponse(201)
    .WithHeader("Location", "/api/resource/123")
    .WithHeader("Content-Type", "application/json")
    .WithContent("""{"id": 123, "name": "Test Resource"}""");

// Response with binary content
var jsonBytes = Encoding.UTF8.GetBytes("""{"data": "value"}""");
var response = new MockPipelineResponse(200)
    .WithContent(jsonBytes);
```

**Reflection Usage:**
- Should almost never be used to access private or non virtual methods/properties/fields. Instead, prefer making public methods virtual or making private fields/methods internal. 

## Async Test Patterns
```csharp
[Test]
public async Task ScenarioExpectedBehavior()
{
    // Setup
    var mockProxy = new Mock<TestProxyProcess>();
    var testBase = new TestRecordedTestBase();
    
    var mockTransport = new MockPipelineTransport(_ => 
        new MockPipelineResponse(200).WithHeader("x-recording-id", "unique-test-id"))
    {
        ExpectSyncPipeline = false
    };
    var client = new TestProxyClient(ClientPipeline.Create(new ClientPipelineOptions { Transport = mockTransport }), new Uri($"http://127.0.0.1:5000"));
    mockProxy.Setup(p => p.ProxyClient).Returns(client);

    TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

    // Test action
    var result = recording.SomeMethod();

    // Assertions
    Assert.That(result, Is.EqualTo(expectedValue));
}
```

## Test Organization
- Organize tests into logical regions by functionality
- Use `ScenarioExpectedBehavior` pattern for test names (no underscores, no method name prefix)
- Cover all modes/parameters systematically
- Use `[TestCase]` for parameter variations instead of duplicating test methods

## Test File Structure and Naming

**File Naming Convention:**
- Each class should have a corresponding test file: `{ClassBeingTested}Tests.cs`
- Examples: `RecordedVariableOptions.cs` → `RecordedVariableOptionsTests.cs`
- Test files should be in the same relative namespace as the class being tested, but under a `.Tests` namespace

**When to Skip Test Files:**
- **Enums**: No meaningful unit tests (compile-time guarantees)
- **Simple DTOs/POCOs**: Properties that just get/set backing fields
- **Empty interfaces**: No behavior to test
- **Pure data classes**: Classes with only properties and no logic
- **Abstract classes with no implementation**: Test the concrete implementations instead

**Test Class Structure:**
```csharp
[TestFixture]
public class ClassNameTests
{
    #region Constructor and Basic Properties
    // Constructor tests, basic property validation
    #endregion

    #region Method Name
    // Primary functionality tests

    // Null inputs, boundary conditions, error scenarios
    #endregion
}
```

**File Organization Principles:**
- One test class per production class (not per method)
- Group related tests in logical regions
- Keep test files focused - if they become too large, consider splitting by functionality

## Common Patterns

## Error Testing Patterns
- Use `Assert.Throws<ExceptionType>()` for expected exceptions
- Verify exception messages contain key information
- Test error conditions across all modes

## Mock Verification Patterns
```csharp
// Verify method was called with specific parameters
mockClient.Verify(c => c.MethodName(
    It.Is<string>(id => id == "expected-id"),
    It.IsAny<OtherType>(),
    specificValue,
    It.IsAny<CancellationToken>()),
    Times.Once);

// Verify method was never called
mockClient.Verify(c => c.MethodName(It.IsAny<string>()), Times.Never);
```

## Data Setup Patterns
```csharp
// Use Dictionary<string, string> for variables
var variables = new Dictionary<string, string>
{
    { "Key1", "Value1" },
    { "Key2", "Value2" }
};

// Use BinaryData.FromObjectAsJson() for response content
.WithContent(BinaryData.FromObjectAsJson(variables).ToArray())
```

## Behavioral Consistency Checks
When implementing tests, watch for:
- Asymmetric behavior across modes, i.e. should Live/Record/Playback behave differently?
- Null handling inconsistencies, i.e. should return null vs. default vs. throw?
- Silent failures vs. explicit errors
- Mutable state vs. read-only contracts, i.e. should consumers be able to modify internal state?
- Variable validation timing and scope

## Quality Indicators
- Tests should read like documentation
- Each test should have a single, clear purpose
- Assertions should be comprehensive but focused
- Error messages should be helpful for debugging
- Tests should verify actual business logic and behavior, not implementation artifacts
- Every test should be able to fail in a meaningful way that indicates a real problem