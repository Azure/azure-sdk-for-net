// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Projects.Tests.Utilities;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.Projects.Tests;

public class FunctionTracerTelemetryTests : RecordedTestBase<AIProjectsTestEnvironment>
{
    public const string EnableOpenTelemetryEnvironmentVariable = "AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE";
    private MemoryTraceExporter _exporter;
    private TracerProvider _tracerProvider;
    private GenAiTraceVerifier _traceVerifier;
    private bool _tracesEnabledInitialValue = false;

    // Test data classes
    public class CustomObject
    {
        public string Name { get; set; } = "Test";
        public int Value { get; set; } = 42;
    }

    public FunctionTracerTelemetryTests(bool isAsync) : base(isAsync)
    {
        TestDiagnostics = false;
    }

    [SetUp]
    public void Setup()
    {
        _exporter = new MemoryTraceExporter();
        _traceVerifier = new GenAiTraceVerifier();

        _tracesEnabledInitialValue = string.Equals(
            Environment.GetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable),
            "true",
            StringComparison.OrdinalIgnoreCase);

        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);

        _tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.Projects.FunctionTracer")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("FunctionTracerTest"))
            .AddProcessor(new SimpleActivityExportProcessor(_exporter))
            .Build();
    }

    [TearDown]
    public void Cleanup()
    {
        _tracerProvider.Dispose();
        _exporter.Clear();
        Environment.SetEnvironmentVariable(
            EnableOpenTelemetryEnvironmentVariable,
            _tracesEnabledInitialValue.ToString(),
            EnvironmentVariableTarget.Process);
    }

    #region Test Functions

    // Functions with supported types
    public static string ProcessOrderWithSupportedTypes(string orderId, int quantity, decimal price, bool isUrgent)
    {
        return $"Order {orderId}: {quantity} items at ${price:F2}, Urgent: {isUrgent}";
    }

    public static async Task<string> ProcessOrderWithSupportedTypesAsync(string orderId, int quantity, decimal price, bool isUrgent)
    {
        await Task.Delay(10);
        return $"Order {orderId}: {quantity} items at ${price:F2}, Urgent: {isUrgent}";
    }

    // Functions with mixed types (some supported, some not)
    public static string ProcessOrderWithMixedTypes(string orderId, CustomObject config, int quantity, DateTime orderDate)
    {
        return $"Order {orderId}: {quantity} items on {orderDate:yyyy-MM-dd}";
    }

    public static async Task<string> ProcessOrderWithMixedTypesAsync(string orderId, CustomObject config, int quantity, DateTime orderDate)
    {
        await Task.Delay(10);
        return $"Order {orderId}: {quantity} items on {orderDate:yyyy-MM-dd}";
    }

    // Functions with collections
    public static double CalculateAverage(List<int> numbers, string description)
    {
        return numbers.Count > 0 ? numbers.Average() : 0;
    }

    public static async Task<double> CalculateAverageAsync(List<int> numbers, string description)
    {
        await Task.Delay(10);
        return numbers.Count > 0 ? numbers.Average() : 0;
    }

    // Functions with only unsupported types
    public static CustomObject ProcessCustomObject(CustomObject input, CustomObject config)
    {
        return new CustomObject { Name = input.Name + "_processed", Value = input.Value * 2 };
    }

    public static async Task<CustomObject> ProcessCustomObjectAsync(CustomObject input, CustomObject config)
    {
        await Task.Delay(10);
        return new CustomObject { Name = input.Name + "_processed", Value = input.Value * 2 };
    }

    // Functions with framework types
    public static TimeSpan CalculateWorkingHours(DateTime start, DateTime end, Guid sessionId)
    {
        return end - start;
    }

    public static async Task<TimeSpan> CalculateWorkingHoursAsync(DateTime start, DateTime end, Guid sessionId)
    {
        await Task.Delay(10);
        return end - start;
    }

    // Void functions
    public static void LogEvent(string eventName, int severity)
    {
        // Simulate logging
    }

    public static async Task LogEventAsync(string eventName, int severity)
    {
        await Task.Delay(10);
        // Simulate logging
    }

    #endregion

    [Test]
    public void TestSyncFunctionWithSupportedTypesTracing()
    {
        // Execute traced function
        var result = FunctionTracer.Trace(() => ProcessOrderWithSupportedTypes("ORD-123", 5, 29.99m, true));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "ProcessOrderWithSupportedTypes");
        Assert.IsNotNull(span, "ProcessOrderWithSupportedTypes span should exist");

        // Verify basic attributes
        var expectedAttributes = new Dictionary<string, object>
        {
            { "code.function.parameter.orderId", "ORD-123" },
            { "code.function.parameter.quantity", "5" },
            { "code.function.parameter.price", "29.99" },
            { "code.function.parameter.isUrgent", "true" },
            { "code.function.return.value", "Order ORD-123: 5 items at $29.99, Urgent: True" },
            { "duration_ms", "+" } // Should be >= 0
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));
        Assert.AreEqual("Order ORD-123: 5 items at $29.99, Urgent: True", result);
    }

    [Test]
    public async Task TestAsyncFunctionWithSupportedTypesTracing()
    {
        // Execute traced async function
        var result = await FunctionTracer.TraceAsync(() => ProcessOrderWithSupportedTypesAsync("ORD-456", 3, 15.50m, false));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "ProcessOrderWithSupportedTypesAsync");
        Assert.IsNotNull(span, "ProcessOrderWithSupportedTypesAsync span should exist");

        // Verify basic attributes
        var expectedAttributes = new Dictionary<string, object>
        {
            { "code.function.parameter.orderId", "ORD-456" },
            { "code.function.parameter.quantity", "3" },
            { "code.function.parameter.price", "15.50" },
            { "code.function.parameter.isUrgent", "false" },
            { "code.function.return.value", "Order ORD-456: 3 items at $15.50, Urgent: False" },
            { "duration_ms", "+" } // Should be >= 0 and likely > 10 due to Task.Delay
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));
        Assert.AreEqual("Order ORD-456: 3 items at $15.50, Urgent: False", result);
    }

    [Test]
    public void TestSyncFunctionWithMixedTypesTracing()
    {
        var config = new CustomObject { Name = "TestConfig", Value = 100 };
        var orderDate = new DateTime(2025, 6, 30, 14, 30, 0);

        // Execute traced function
        var result = FunctionTracer.Trace(() => ProcessOrderWithMixedTypes("ORD-789", config, 7, orderDate));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "ProcessOrderWithMixedTypes");
        Assert.IsNotNull(span, "ProcessOrderWithMixedTypes span should exist");

        // Verify attributes - only supported types should be traced
        var expectedAttributes = new Dictionary<string, object>
        {
            { "code.function.parameter.orderId", "ORD-789" },
            { "code.function.parameter.quantity", "7" },
            { "code.function.parameter.orderDate", "2025-06-30T14:30:00.0000000" }, // ISO 8601 format
            { "code.function.return.value", "Order ORD-789: 7 items on 2025-06-30" },
            { "duration_ms", "+" }
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));

        // Verify that config parameter (CustomObject) is NOT traced
        var actualAttributes = new Dictionary<string, object>();
        foreach (var tag in span.EnumerateTagObjects())
        {
            actualAttributes[tag.Key] = tag.Value;
        }
        Assert.IsFalse(actualAttributes.ContainsKey("code.function.parameter.config"), "CustomObject parameter should not be traced");
    }

    [Test]
    public async Task TestAsyncFunctionWithMixedTypesTracing()
    {
        var config = new CustomObject { Name = "TestConfig", Value = 100 };
        var orderDate = new DateTime(2025, 6, 30, 14, 30, 0);

        // Execute traced async function
        var result = await FunctionTracer.TraceAsync(() => ProcessOrderWithMixedTypesAsync("ORD-999", config, 2, orderDate));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "ProcessOrderWithMixedTypesAsync");
        Assert.IsNotNull(span, "ProcessOrderWithMixedTypesAsync span should exist");

        // Verify attributes - only supported types should be traced
        var expectedAttributes = new Dictionary<string, object>
        {
            { "code.function.parameter.orderId", "ORD-999" },
            { "code.function.parameter.quantity", "2" },
            { "code.function.parameter.orderDate", "2025-06-30T14:30:00.0000000" },
            { "code.function.return.value", "Order ORD-999: 2 items on 2025-06-30" },
            { "duration_ms", "+" }
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));

        // Verify that config parameter (CustomObject) is NOT traced
        var actualAttributes = new Dictionary<string, object>();
        foreach (var tag in span.EnumerateTagObjects())
        {
            actualAttributes[tag.Key] = tag.Value;
        }
        Assert.IsFalse(actualAttributes.ContainsKey("code.function.parameter.config"), "CustomObject parameter should not be traced");
    }

    [Test]
    public void TestSyncFunctionWithCollectionsTracing()
    {
        var numbers = new List<int> { 10, 20, 30, 40, 50 };

        // Execute traced function
        var result = FunctionTracer.Trace(() => CalculateAverage(numbers, "Test calculation"));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "CalculateAverage");
        Assert.IsNotNull(span, "CalculateAverage span should exist");

        // Verify attributes
        var expectedAttributes = new Dictionary<string, object>
        {
            { "code.function.parameter.numbers", "10, 20, 30, 40, 50" },
            { "code.function.parameter.description", "Test calculation" },
            { "code.function.return.value", "30" },
            { "duration_ms", "+" }
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));
        Assert.AreEqual(30.0, result);
    }

    [Test]
    public async Task TestAsyncFunctionWithCollectionsTracing()
    {
        var numbers = new List<int> { 5, 15, 25 };

        // Execute traced async function
        var result = await FunctionTracer.TraceAsync(() => CalculateAverageAsync(numbers, "Async calculation"));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "CalculateAverageAsync");
        Assert.IsNotNull(span, "CalculateAverageAsync span should exist");

        // Verify attributes
        var expectedAttributes = new Dictionary<string, object>
        {
            { "code.function.parameter.numbers", "5, 15, 25" },
            { "code.function.parameter.description", "Async calculation" },
            { "code.function.return.value", "15" },
            { "duration_ms", "+" }
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));
        Assert.AreEqual(15.0, result);
    }

    [Test]
    public void TestSyncFunctionWithUnsupportedTypesOnly()
    {
        var input = new CustomObject { Name = "Input", Value = 10 };
        var config = new CustomObject { Name = "Config", Value = 20 };

        // Execute traced function
        var result = FunctionTracer.Trace(() => ProcessCustomObject(input, config));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "ProcessCustomObject");
        Assert.IsNotNull(span, "ProcessCustomObject span should exist");

        // Verify that NO parameters are traced (all are unsupported types)
        var expectedAttributes = new Dictionary<string, object>
        {
            { "duration_ms", "+" }
            // No param.* or result attributes should exist
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));

        // Verify that no parameters or result are traced
        var actualAttributes = new Dictionary<string, object>();
        foreach (var tag in span.EnumerateTagObjects())
        {
            actualAttributes[tag.Key] = tag.Value;
        }
        Assert.IsFalse(actualAttributes.ContainsKey("code.function.parameter.input"), "CustomObject input parameter should not be traced");
        Assert.IsFalse(actualAttributes.ContainsKey("code.function.parameter.config"), "CustomObject config parameter should not be traced");
        Assert.IsFalse(actualAttributes.ContainsKey("code.function.return.value"), "CustomObject result should not be traced");

        Assert.AreEqual("Input_processed", result.Name);
        Assert.AreEqual(20, result.Value);
    }

    [Test]
    public async Task TestAsyncFunctionWithUnsupportedTypesOnly()
    {
        var input = new CustomObject { Name = "AsyncInput", Value = 15 };
        var config = new CustomObject { Name = "AsyncConfig", Value = 25 };

        // Execute traced async function
        var result = await FunctionTracer.TraceAsync(() => ProcessCustomObjectAsync(input, config));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "ProcessCustomObjectAsync");
        Assert.IsNotNull(span, "ProcessCustomObjectAsync span should exist");

        // Verify that NO parameters are traced (all are unsupported types)
        var expectedAttributes = new Dictionary<string, object>
        {
            { "duration_ms", "+" }
            // No param.* or result attributes should exist
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));

        // Verify that no parameters or result are traced
        var actualAttributes = new Dictionary<string, object>();
        foreach (var tag in span.EnumerateTagObjects())
        {
            actualAttributes[tag.Key] = tag.Value;
        }
        Assert.IsFalse(actualAttributes.ContainsKey("code.function.parameter.input"), "CustomObject input parameter should not be traced");
        Assert.IsFalse(actualAttributes.ContainsKey("code.function.parameter.config"), "CustomObject config parameter should not be traced");
        Assert.IsFalse(actualAttributes.ContainsKey("code.function.return.value"), "CustomObject result should not be traced");

        Assert.AreEqual("AsyncInput_processed", result.Name);
        Assert.AreEqual(30, result.Value);
    }

    [Test]
    public void TestSyncFunctionWithFrameworkTypesTracing()
    {
        var start = new DateTime(2025, 6, 30, 9, 0, 0);
        var end = new DateTime(2025, 6, 30, 17, 30, 0);
        var sessionId = Guid.NewGuid();

        // Execute traced function
        var result = FunctionTracer.Trace(() => CalculateWorkingHours(start, end, sessionId));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "CalculateWorkingHours");
        Assert.IsNotNull(span, "CalculateWorkingHours span should exist");

        // Verify attributes
        var expectedAttributes = new Dictionary<string, object>
        {
            { "code.function.parameter.start", "2025-06-30T09:00:00.0000000" },
            { "code.function.parameter.end", "2025-06-30T17:30:00.0000000" },
            { "code.function.parameter.sessionId", sessionId.ToString() },
            { "code.function.return.value", "08:30:00" }, // TimeSpan format
            { "duration_ms", "+" }
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));
        Assert.AreEqual(TimeSpan.FromHours(8.5), result);
    }

    [Test]
    public async Task TestAsyncFunctionWithFrameworkTypesTracing()
    {
        var start = new DateTime(2025, 6, 30, 10, 0, 0);
        var end = new DateTime(2025, 6, 30, 16, 0, 0);
        var sessionId = Guid.NewGuid();

        // Execute traced async function
        var result = await FunctionTracer.TraceAsync(() => CalculateWorkingHoursAsync(start, end, sessionId));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "CalculateWorkingHoursAsync");
        Assert.IsNotNull(span, "CalculateWorkingHoursAsync span should exist");

        // Verify attributes
        var expectedAttributes = new Dictionary<string, object>
        {
            { "code.function.parameter.start", "2025-06-30T10:00:00.0000000" },
            { "code.function.parameter.end", "2025-06-30T16:00:00.0000000" },
            { "code.function.parameter.sessionId", sessionId.ToString() },
            { "code.function.return.value", "06:00:00" }, // TimeSpan format
            { "duration_ms", "+" }
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));
        Assert.AreEqual(TimeSpan.FromHours(6), result);
    }

    [Test]
    public void TestSyncVoidFunctionTracing()
    {
        // Execute traced void function
        FunctionTracer.Trace(() => LogEvent("UserLogin", 2));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "LogEvent");
        Assert.IsNotNull(span, "LogEvent span should exist");

        // Verify attributes
        var expectedAttributes = new Dictionary<string, object>
        {
            { "code.function.parameter.eventName", "UserLogin" },
            { "code.function.parameter.severity", "2" },
            { "duration_ms", "+" }
            // No result attribute for void functions
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));

        // Verify that no result is traced
        var actualAttributes = new Dictionary<string, object>();
        foreach (var tag in span.EnumerateTagObjects())
        {
            actualAttributes[tag.Key] = tag.Value;
        }
        Assert.IsFalse(actualAttributes.ContainsKey("code.function.return.value"), "Void function should not have result attribute");
    }

    [Test]
    public async Task TestAsyncVoidFunctionTracing()
    {
        // Execute traced async void function
        await FunctionTracer.TraceAsync(() => LogEventAsync("UserLogout", 1));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "LogEventAsync");
        Assert.IsNotNull(span, "LogEventAsync span should exist");

        // Verify attributes
        var expectedAttributes = new Dictionary<string, object>
        {
            { "code.function.parameter.eventName", "UserLogout" },
            { "code.function.parameter.severity", "1" },
            { "duration_ms", "+" }
            // No result attribute for void functions
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));

        // Verify that no result is traced
        var actualAttributes = new Dictionary<string, object>();
        foreach (var tag in span.EnumerateTagObjects())
        {
            actualAttributes[tag.Key] = tag.Value;
        }
        Assert.IsFalse(actualAttributes.ContainsKey("code.function.return.value"), "Async void function should not have result attribute");
    }

    [Test]
    public void TestFunctionTracingWithActivitySourceDisabled()
    {
        // Disable OpenTelemetry
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "false", EnvironmentVariableTarget.Process);

        // Recreate tracer provider without activity source
        _tracerProvider.Dispose();
        _tracerProvider = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("FunctionTracerTest"))
            .AddProcessor(new SimpleActivityExportProcessor(_exporter))
            .Build();

        // Execute traced function
        var result = FunctionTracer.Trace(() => ProcessOrderWithSupportedTypes("ORD-000", 1, 10.00m, false));

        // Force flush spans
        _exporter.ForceFlush();

        // Verify no spans are created
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "ProcessOrderWithSupportedTypes");
        Assert.IsNull(span, "No span should be created when activity source is disabled");

        // But function should still execute normally
        Assert.AreEqual("Order ORD-000: 1 items at $10.00, Urgent: False", result);

        // Restore environment
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
    }

    [Test]
    public void TestFunctionWithCustomFunctionName()
    {
        // Execute traced function with custom name
        var result = FunctionTracer.Trace(() => ProcessOrderWithSupportedTypes("ORD-CUSTOM", 2, 25.00m, true), "CustomOrderProcessor");

        // Force flush spans
        _exporter.ForceFlush();

        // Verify span exists with custom name
        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "CustomOrderProcessor");
        Assert.IsNotNull(span, "CustomOrderProcessor span should exist");

        // Verify attributes
        var expectedAttributes = new Dictionary<string, object>
        {
            { "code.function.parameter.orderId", "ORD-CUSTOM" },
            { "code.function.parameter.quantity", "2" },
            { "code.function.parameter.price", "25.00" },
            { "code.function.parameter.isUrgent", "true" },
            { "code.function.return.value", "Order ORD-CUSTOM: 2 items at $25.00, Urgent: True" },
            { "duration_ms", "+" }
        };

        Assert.IsTrue(_traceVerifier.CheckSpanAttributes(span, expectedAttributes));
    }

    [Test]
    public void TestFunctionWithNestedCollections()
    {
        var nestedList = new List<List<int>>
        {
            new() { 1, 2, 3 },
            new() { 4, 5 },
            new() { 6 }
        };

        // Create a function that actually takes the nested collection as a parameter
        var result = FunctionTracer.Trace(() => ProcessNestedCollection(nestedList), "ProcessNestedCollection");

        // Force flush spans
        _exporter.ForceFlush();

        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == "ProcessNestedCollection");
        Assert.IsNotNull(span, "ProcessNestedCollection span should exist");

        // The nested collection should be converted to string format
        var actualAttributes = new Dictionary<string, object>();
        foreach (var tag in span.EnumerateTagObjects())
        {
            actualAttributes[tag.Key] = tag.Value;
        }

        // Should contain nested collection parameter
        Assert.IsTrue(actualAttributes.ContainsKey("code.function.parameter.nestedList"),
                      "Should have parameter for nested collection");

        // Should contain nested collection as string representation with brackets
        var paramValue = actualAttributes["code.function.parameter.nestedList"].ToString();
        Assert.IsTrue(paramValue!.Contains("[") && paramValue.Contains("]"),
                      $"Nested collections should be represented with brackets, got: {paramValue}");

        // Should look something like: "[1, 2, 3], [4, 5], [6]"
        Assert.IsTrue(paramValue.Contains("1, 2, 3") && paramValue.Contains("4, 5") && paramValue.Contains("6"),
                      $"Should contain all nested values, got: {paramValue}");
    }

    // Add this helper method to the test class
    public static int ProcessNestedCollection(List<List<int>> nestedList)
    {
        return nestedList.SelectMany(x => x).Sum();
    }
}
