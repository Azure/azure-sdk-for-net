// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Example interceptor that demonstrates how to use AsyncMethodInterceptor
/// for telemetry validation in System.ClientModel-based tests.
/// </summary>
public class TelemetryValidatingInterceptor : AsyncMethodInterceptor
{
    private static readonly MethodInfo ValidateTelemetryMethodInfo = typeof(TelemetryValidatingInterceptor)
        .GetMethod(nameof(ValidateTelemetryInterceptor), BindingFlags.NonPublic | BindingFlags.Instance)
        ?? throw new InvalidOperationException("Unable to find TelemetryValidatingInterceptor.ValidateTelemetryInterceptor method");

    /// <summary>
    /// Initializes a new instance of TelemetryValidatingInterceptor.
    /// </summary>
    public TelemetryValidatingInterceptor()
        : base(ValidateTelemetryMethodInfo)
    {
        // Base constructor will use 'this' as the target automatically
    }

    /// <summary>
    /// The async call interceptor that validates telemetry.
    /// </summary>
    private ValueTask<T> ValidateTelemetryInterceptor<T>(IInvocation invocation, Func<ValueTask<T>> innerTask)
    {
        return ValidateTelemetry(innerTask, invocation.Method);
    }

    /// <summary>
    /// Validates telemetry for the given async operation.
    /// This is where you would add System.ClientModel-specific telemetry validation logic.
    /// </summary>
    private static async ValueTask<T> ValidateTelemetry<T>(Func<ValueTask<T>> action, MethodInfo methodInfo)
    {
        // TODO: Add System.ClientModel telemetry validation logic here
        // This is where you would:
        // 1. Set up telemetry listeners
        // 2. Execute the action
        // 3. Validate the telemetry was properly created
        // 4. Check for proper activity names, attributes, etc.

        // For now, just execute the action without validation
        await Task.Yield();
        throw new NotImplementedException();
    }
}
