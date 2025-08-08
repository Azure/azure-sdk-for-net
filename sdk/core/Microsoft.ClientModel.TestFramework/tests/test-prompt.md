# Unit Test Development Best Practices Prompt

## Core Testing Principles
- **No AAA Comments**: Never include Arrange/Act/Assert comments - the code structure should be self-evident
- **Comprehensive Coverage**: Test all modes/scenarios systematically (Live/Record/Playback for recording frameworks)
- **Edge Cases**: Include null values, empty collections, boundary conditions, and error scenarios
- **Consistent Patterns**: Once a pattern is established, follow it religiously across all similar tests
- **Focus on Behavior**: Test meaningful behavior and logic, not trivial implementation details or compiler guarantees

## Mocking Strategy Guidelines

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

**Avoid NUnit Internals (With Exceptions):**
- **Generally avoid**: Don't try to mock or use `TestResult`, `TestMethod`, `TestExecutionContext`, or other NUnit internal classes for typical business logic testing
- **Exception for Framework Integration**: When testing classes that directly integrate with NUnit's framework (like custom attributes that implement `IRepeatTest`, `IWrapSetUpTearDown`, etc.), using NUnit internals is appropriate and necessary
- **Key principle**: If your class under test is designed to work with NUnit internals, then your tests should use those same internals
- **Examples of appropriate use**: Testing custom test attributes, test commands, framework extensions
- **Examples of inappropriate use**: Testing business logic classes, data models, utility functions
- **Focus on behavior**: Whether using internals or not, always focus on testing meaningful behavior rather than implementation details

**Reflection Usage:**
- Use judiciously for accessing private fields when testing internal state
- Always check for null after reflection calls
- Use proper binding flags (`NonPublic | Instance`)

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
- **Regions**: Organize tests into logical regions by functionality
- **Descriptive Names**: Use `ScenarioExpectedBehavior` pattern (no underscores, no method name prefix)
- **Systematic Coverage**: Cover all modes/parameters systematically
- **TestCase Attributes**: Use `[TestCase]` for parameter variations instead of duplicate test methods

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

    #region Method Name - Core Behavior  
    // Primary functionality tests
    #endregion
    
    #region Method Name - Edge Cases
    // Null inputs, boundary conditions, error scenarios
    #endregion
    
    #region Integration and Usage Patterns
    // Real-world usage scenarios, fluent interfaces
    #endregion
}
```

**File Organization Principles:**
- One test class per production class (not per method)
- Group related tests in logical regions
- Order regions from basic to complex functionality
- Include integration tests in the same file when appropriate
- Keep test files focused - if they become too large, consider splitting by functionality

## Common Patterns

**Mode-Specific Testing:**
```csharp
// Test each recording mode (Live, Record, Playback) separately
// Live: No proxy interactions, direct behavior
// Record: Store data, apply sanitizers
// Playback: Retrieve recorded data, validate consistency
```

**Variable Management Testing:**
```csharp
// Record mode: stores values, applies sanitizers
// Live mode: returns defaults, doesn't store
// Playback mode: retrieves stored values, ignores sanitizers
```

**Disposal Testing:**
```csharp
// Use reflection to swap real clients with mocks for verification
// Test save vs. no-save scenarios
// Verify correct API calls with expected parameters
```

## Error Testing Patterns
- Use `Assert.Throws<ExceptionType>()` for expected exceptions
- Verify exception messages contain key information
- Test error conditions across all modes
- Use `Assert.DoesNotThrow()` for success scenarios

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
- **Asymmetric behavior** across modes (should Live/Record/Playback behave differently?)
- **Null handling inconsistencies** (should return null vs. default vs. throw?)
- **Silent failures** vs. **explicit errors** (which is more appropriate?)
- **Mutable state** vs. **read-only contracts** (should consumers be able to modify internal state?)
- **Sanitizer application** consistency across modes
- **Variable validation** timing and scope

## Anti-Patterns to Avoid
- Don't use hardcoded magic strings without context
- Don't test multiple unrelated behaviors in single test
- Don't ignore mode-specific behavior differences
- Don't use generic variable names like `result1`, `result2`
- Don't forget to test disposal and cleanup scenarios
- Don't assume default behavior - test it explicitly
- **Don't test trivial/obvious things**: Avoid testing that classes are abstract, interfaces are implemented, or other compile-time guarantees
- **Don't test framework behavior**: Don't test that NUnit works, that mocks work, or other third-party functionality
- **Don't test language features**: Don't test that properties return values they were set to, or that constructors assign parameters
- **Don't use NUnit internals**: Avoid using classes like `TestResult`, `TestMethod`, `TestExecutionContext` directly - these are internal implementation details that make tests brittle and overly complex
- **Never use Assert.Pass()**: If something isn't meaningfully testable at the unit level, delete the test rather than using `Assert.Pass()` - it creates false coverage and test noise

## Quality Indicators
- Tests should read like documentation
- Each test should have a single, clear purpose
- Setup should be minimal but complete
- Assertions should be comprehensive but focused
- Error messages should be helpful for debugging
- Tests should verify actual business logic and behavior, not implementation artifacts
- Every test should be able to fail in a meaningful way that indicates a real problem

## Identified Behavioral Inconsistencies to Consider

During test development, these behavioral patterns emerged that may warrant design review:

1. **GetVariable Playback Mode Returns Null**: When a variable doesn't exist in playback mode, returns `null` instead of `defaultValue`
2. **SetVariable No-Op Behavior**: SetVariable does nothing in Live and Playback modes (especially questionable for Live)
3. **Random Property Exception**: Throws exception when Variables empty in Playback, unlike other properties
4. **Transport Null Handling**: Asymmetric behavior across modes for null transport handling
5. **HasRequests Property Mutability**: Appears publicly settable but represents internal state
6. **Variable Collection Mutability**: Variables loaded in Playback but SetVariable silently ignored
7. **Sanitizer Ignored in Non-Record**: Sanitizer functions ignored in Live/Playback modes
8. **Disposal HasRequests Dependency**: Playback disposal behavior depends on runtime HasRequests state
9. **Variable Validation Inconsistency**: Only validates on Random access, not other operations

This prompt encapsulates the evolution from basic test structure to sophisticated, comprehensive test coverage that emerged through systematic implementation.
