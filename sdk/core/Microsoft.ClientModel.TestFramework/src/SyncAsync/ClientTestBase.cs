// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Base class for client tests that provides instrumentation and synchronization capabilities.
/// This class supports both synchronous and asynchronous test execution patterns and provides
/// common functionality for testing Azure SDK clients.
/// 
/// <para>
/// The ClientTestBase class serves as the foundation for writing tests against Azure SDK clients.
/// It provides automatic instrumentation of client instances, enabling interception of method calls
/// for validation, timing, and behavior modification. The class supports both sync and async test
/// patterns, automatically routing calls to the appropriate method variants based on the test configuration.
/// </para>
/// 
/// <para>
/// Key features include:
/// - Automatic client instrumentation with proxy generation
/// - Sync/async method routing based on test configuration
/// - Diagnostic scope validation for proper telemetry handling
/// - Global timeout enforcement to prevent runaway tests
/// - Support for custom interceptors for specialized testing scenarios
/// </para>
/// 
/// <para>
/// Tests deriving from this class should use the CreateClient or InstrumentClient methods
/// to obtain client instances rather than creating them directly, as this ensures proper
/// instrumentation and test behavior.
/// </para>
/// </summary>
//[ClientTestFixture]
public abstract class ClientTestBase
{
    /// <summary>
    /// A proxy generator used to create instrumented client instances for testing.
    /// This enables interception of method calls for validation and test behavior modification.
    /// </summary>
    protected static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

    /// <summary>
    /// Interceptor that forces the use of synchronous methods by intercepting async calls and redirecting them to sync equivalents.
    /// </summary>
    private static readonly IInterceptor s_useSyncInterceptor = new UseSyncMethodsInterceptor(forceSync: true);
    
    /// <summary>
    /// Interceptor that avoids synchronous methods by ensuring async methods are used when available.
    /// </summary>
    private static readonly IInterceptor s_avoidSyncInterceptor = new UseSyncMethodsInterceptor(forceSync: false);
    
    /// <summary>
    /// Interceptor that validates diagnostic scopes are properly created and disposed during method execution.
    /// </summary>
    private static readonly IInterceptor s_diagnosticScopeValidatingInterceptor = new DiagnosticScopeValidatingInterceptor();
    
    /// <summary>
    /// Cache of client type validation results to avoid repeating expensive reflection-based validation.
    /// </summary>
    private static Dictionary<Type, Exception> s_clientValidation = new Dictionary<Type, Exception>();

    /// <summary>
    /// Maximum test execution time in seconds when running in continuous integration environments.
    /// </summary>
    private const int GLOBAL_TEST_TIMEOUT_IN_SECONDS = 15;
    
    /// <summary>
    /// Maximum test execution time in seconds when running locally during development.
    /// </summary>
    private const int GLOBAL_LOCAL_TEST_TIMEOUT_IN_SECONDS = 10;

    /// <summary>
    /// Gets a value indicating whether this test instance should execute asynchronously.
    /// When true, async methods are preferred; when false, sync methods are used.
    /// </summary>
    public bool IsAsync { get; }

    /// <summary>
    /// Gets or sets a value indicating whether diagnostic scope validation should be performed.
    /// When enabled, the framework validates that diagnostic activities are properly created and disposed.
    /// </summary>
    public bool TestDiagnostics { get; set; } = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientTestBase"/> class.
    /// </summary>
    /// <param name="isAsync">A value indicating whether this test instance should execute asynchronously.</param>
    public ClientTestBase(bool isAsync)
    {
        IsAsync = isAsync;
    }

    /// <summary>
    /// Gets or sets additional interceptors that will be applied to instrumented clients.
    /// These interceptors are applied before the default framework interceptors.
    /// </summary>
    protected IReadOnlyCollection<IInterceptor> AdditionalInterceptors { get; set; }

    /// <summary>
    /// Gets the start time of the current test execution.
    /// This is used for timeout calculations and test duration tracking.
    /// </summary>
    protected virtual DateTime TestStartTime => TestExecutionContext.CurrentContext.StartTime;

    /// <summary>
    /// Validates that the test execution time does not exceed the global timeout limits.
    /// This method is automatically called after each test to ensure tests complete within reasonable time bounds.
    /// Different timeout values are used depending on whether the test is running in CI or locally.
    /// </summary>
    /// <exception cref="TestTimeoutException">Thrown when the test execution time exceeds the configured timeout.</exception>
    [TearDown]
    public virtual void GlobalTimeoutTearDown()
    {
        if (Debugger.IsAttached)
        {
            return;
        }

        var executionContext = TestExecutionContext.CurrentContext;
        var duration = DateTime.UtcNow - TestStartTime;
        var timeout = TestEnvironment.GlobalIsRunningInCI ? GLOBAL_TEST_TIMEOUT_IN_SECONDS : GLOBAL_LOCAL_TEST_TIMEOUT_IN_SECONDS;
        if (duration > TimeSpan.FromSeconds(timeout))
        {
            string message = $"Test exceeded global time limit of {timeout} seconds. Duration: {duration} ";
            if (this is RecordedTestBase &&
                !executionContext.CurrentTest.GetCustomAttributes<RecordedTestAttribute>(true).Any())
            {
                message += Environment.NewLine + "Replace the [Test] attribute with the [RecordedTest] attribute in your test to allow an automatic retry for timeouts.";
            }
            throw new TestTimeoutException(message);
        }
    }

    /// <summary>
    /// Creates and instruments a new client instance of the specified type.
    /// The client is created using the provided constructor arguments and then instrumented
    /// with the appropriate interceptors for testing.
    /// </summary>
    /// <typeparam name="TClient">The type of client to create.</typeparam>
    /// <param name="args">The constructor arguments for creating the client instance.</param>
    /// <returns>An instrumented client instance ready for testing.</returns>
    protected TClient CreateClient<TClient>(params object[] args) where TClient : class
    {
        return InstrumentClient((TClient)Activator.CreateInstance(typeof(TClient), args));
    }

    /// <summary>
    /// Instruments an existing client instance with the default set of interceptors.
    /// This method wraps the client with a proxy that intercepts method calls for testing purposes.
    /// </summary>
    /// <typeparam name="TClient">The type of client to instrument.</typeparam>
    /// <param name="client">The client instance to instrument.</param>
    /// <returns>An instrumented version of the client that can be used in tests.</returns>
    public TClient InstrumentClient<TClient>(TClient client) where TClient : class => (TClient)InstrumentClient(typeof(TClient), client, null);

    /// <summary>
    /// Instruments an existing client instance with custom interceptors in addition to the default ones.
    /// This overload allows you to specify additional interceptors that will be applied before the framework's default interceptors.
    /// </summary>
    /// <typeparam name="TClient">The type of client to instrument.</typeparam>
    /// <param name="client">The client instance to instrument.</param>
    /// <param name="preInterceptors">Additional interceptors to apply before the default framework interceptors.</param>
    /// <returns>An instrumented version of the client that can be used in tests.</returns>
    protected TClient InstrumentClient<TClient>(TClient client, IEnumerable<IInterceptor> preInterceptors) where TClient : class =>
        (TClient)InstrumentClient(typeof(TClient), client, preInterceptors);

    /// <summary>
    /// Core method for instrumenting client instances with the testing framework's interceptors.
    /// This method validates the client type, creates appropriate interceptors, and returns a proxy
    /// that can be used for testing. It performs validation to ensure async methods are properly virtualizable.
    /// </summary>
    /// <param name="clientType">The type of the client being instrumented.</param>
    /// <param name="client">The client instance to instrument.</param>
    /// <param name="preInterceptors">Optional additional interceptors to apply before the default framework interceptors.</param>
    /// <returns>An instrumented proxy of the client that intercepts method calls for testing purposes.</returns>
    protected internal virtual object InstrumentClient(Type clientType, object client, IEnumerable<IInterceptor> preInterceptors)
    {
        if (client is IProxyTargetAccessor)
        {
            // Already instrumented
            return client;
        }

        lock (s_clientValidation)
        {
            if (!s_clientValidation.TryGetValue(clientType, out var validationException))
            {
                var coreMethods = new Dictionary<string, MethodInfo>();

                foreach (MethodInfo methodInfo in clientType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    if (methodInfo.Name.EndsWith("CoreAsync") && (methodInfo.IsVirtual || methodInfo.IsAbstract))
                    {
                        coreMethods.Add(methodInfo.Name.Substring(0, methodInfo.Name.Length - 9) + "Async", methodInfo);
                    }
                }

                foreach (MethodInfo methodInfo in clientType.GetMethods(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (methodInfo.Name.EndsWith("Async") && !methodInfo.IsVirtual)
                    {
                        validationException = new InvalidOperationException($"Client type contains public non-virtual async method {methodInfo.Name}");

                        break;
                    }

                    if (methodInfo.Name.EndsWith("Client") &&
                        methodInfo.Name.StartsWith("Get") &&
                        !methodInfo.IsVirtual)
                    {
                        // if an async method is not virtual, we should find if we have a corresponding virtual or abstract Core method
                        // if no, we throw the validation failed exception
                        if (!coreMethods.ContainsKey(methodInfo.Name))
                        {
                            validationException = new InvalidOperationException($"Client type contains public non-virtual async method {methodInfo.Name}");

                            break;
                        }
                    }
                }

                s_clientValidation[clientType] = validationException;
            }

            if (validationException != null)
            {
                throw validationException;
            }
        }

        List<IInterceptor> interceptors = new List<IInterceptor>();
        if (preInterceptors != null)
        {
            interceptors.AddRange(preInterceptors);
        }

        interceptors.Add(new GetOriginalInterceptor(client));

        if (TestDiagnostics)
        {
            interceptors.Add(s_diagnosticScopeValidatingInterceptor);
        }

        interceptors.Add(new InstrumentResultInterceptor(this));

        // Ignore the async method interceptor entirely if we're running a
        // a SyncOnly test
        TestContext.TestAdapter test = TestContext.CurrentContext.Test;
        bool? isSyncOnly = (bool?)test.Properties.Get(ClientTestFixtureAttribute.SyncOnlyKey);
        if (isSyncOnly != true)
        {
            interceptors.Add(IsAsync ? s_avoidSyncInterceptor : s_useSyncInterceptor);
        }

        return ProxyGenerator.CreateClassProxyWithTarget(
            clientType,
            new[] { typeof(IInstrumented) },
            client,
            interceptors.ToArray());
    }

    /// <summary>
    /// Instruments a long-running operation instance for testing purposes.
    /// This method creates a proxy around the operation that allows the test framework
    /// to control and monitor the operation's behavior during testing.
    /// </summary>
    /// <param name="operationType">The type of the operation being instrumented.</param>
    /// <param name="operation">The operation instance to instrument.</param>
    /// <returns>An instrumented proxy of the operation that can be controlled during testing.</returns>
    protected internal virtual object InstrumentOperation(Type operationType, object operation)
    {
        var interceptors = AdditionalInterceptors ?? Array.Empty<IInterceptor>();

        // The assumption is that any recorded or live tests deriving from RecordedTestBase, and that any unit tests deriving directly from ClientTestBase are equivalent to playback.
        var interceptorArray = interceptors.Concat(new IInterceptor[] { new GetOriginalInterceptor(operation), new OperationInterceptor(RecordedTestMode.Playback) }).ToArray();
        return ProxyGenerator.CreateClassProxyWithTarget(
            operationType,
            new[] { typeof(IInstrumented) },
            operation,
            interceptorArray);
    }

    /// <summary>
    /// Instruments a long-running operation instance of a specific type for testing purposes.
    /// This is a generic convenience method that wraps the non-generic InstrumentOperation method.
    /// </summary>
    /// <typeparam name="T">The type of operation to instrument, which must inherit from Operation.</typeparam>
    /// <param name="operation">The operation instance to instrument.</param>
    /// <returns>An instrumented version of the operation that can be controlled during testing.</returns>
    protected internal T InstrumentOperation<T>(T operation) where T : Operation =>
        (T)InstrumentOperation(typeof(T), operation);

    /// <summary>
    /// Retrieves the original, uninstrumented instance from an instrumented object.
    /// This method can be used to access the underlying client or operation instance
    /// when you need to bypass the test instrumentation.
    /// </summary>
    /// <typeparam name="T">The type of the original object to retrieve.</typeparam>
    /// <param name="instrumented">The instrumented object from which to extract the original instance.</param>
    /// <returns>The original, uninstrumented instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the instrumented parameter is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the provided object is not an instrumented type.</exception>
    protected T GetOriginal<T>(T instrumented)
    {
        if (instrumented == null) throw new ArgumentNullException(nameof(instrumented));
        var i = instrumented as IInstrumented ?? throw new InvalidOperationException($"{instrumented.GetType()} is not an instrumented type");
        return (T)i.Original;
    }
}
