// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Provides a base class for client library unit tests that need to test both synchronous and asynchronous code
/// paths, by automatically intercepting async calls and forwarding them to their sync counterpart. This allows test
/// suites to define one test for both the sync and async overload of a method.
/// </summary>
[ClientTestFixture]
public abstract class ClientTestBase
{
    private static readonly IInterceptor s_useSyncInterceptor = new UseSyncMethodsInterceptor(forceSync: true);
    private static readonly IInterceptor s_avoidSyncInterceptor = new UseSyncMethodsInterceptor(forceSync: false);
    private static Dictionary<Type, Exception?> s_clientValidation = new();

    /// <summary>
    /// Gets the shared proxy generator instance used for creating instrumented client proxies.
    /// </summary>
    protected static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

    /// <summary>
    /// Gets or sets the global timeout for individual tests in seconds.
    /// </summary>
    /// <value>The default timeout is 10 seconds.</value>
    /// <remarks>
    /// This timeout is enforced by <see cref="GlobalTimeoutTearDown"/> to prevent tests from hanging
    /// indefinitely. When a debugger is attached, timeout checking is disabled to allow debugging.
    /// </remarks>
    public int TestTimeoutInSeconds { get; set; } = 10;

    /// <summary>
    /// Gets a value indicating whether this test instance is running in asynchronous mode.
    /// </summary>
    /// <value>
    /// <c>true</c> if the test should prefer async methods; <c>false</c> if it should prefer sync methods.
    /// </value>
    public bool IsAsync { get; }

    /// <summary>
    /// Gets or sets additional interceptors to apply to instrumented clients and operations.
    /// </summary>
    /// <value>A collection of interceptors, or <c>null</c> if no additional interceptors are needed.</value>
    protected IReadOnlyCollection<IInterceptor>? AdditionalInterceptors { get; set; }

    /// <summary>
    /// Gets the start time of the current test execution.
    /// </summary>
    /// <value>The UTC time when the current test started executing.</value>
    protected virtual DateTime TestStartTime => TestExecutionContext.CurrentContext.StartTime;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientTestBase"/> class.
    /// </summary>
    /// <param name="isAsync">
    /// <c>true</c> if this test permutation is calling asynchronous methods;
    /// <c>false</c> if this test permutation should intercept async calls and forward to synchronous methods.
    /// </param>
    public ClientTestBase(bool isAsync)
    {
        IsAsync = isAsync;
    }

    /// <summary>
    /// Enforces global timeout limits for test execution to prevent hanging tests.
    /// </summary>
    /// <exception cref="TestTimeoutException">
    /// Thrown when the test execution time exceeds <see cref="TestTimeoutInSeconds"/>.
    /// </exception>
    [TearDown]
    public virtual void GlobalTimeoutTearDown()
    {
        if (Debugger.IsAttached)
        {
            return;
        }

        var executionContext = TestExecutionContext.CurrentContext;
        var duration = DateTime.UtcNow - TestStartTime;
        if (duration > TimeSpan.FromSeconds(TestTimeoutInSeconds))
        {
            string message = $"Test exceeded global time limit of {TestTimeoutInSeconds} seconds. Duration: {duration} ";
            if (this is RecordedTestBase &&
                !executionContext.CurrentTest.GetCustomAttributes<RecordedTestAttribute>(true).Any())
            {
                message += Environment.NewLine + "Replace the [Test] attribute with the [RecordedTest] attribute in your test to allow an automatic retry for timeouts.";
            }
            throw new TestTimeoutException(message);
        }
    }

    /// <summary>
    /// Creates and instruments a new client instance using the specified constructor arguments.
    /// </summary>
    /// <typeparam name="TClient">The type of client to create.</typeparam>
    /// <param name="args">The arguments to pass to the client's constructor.</param>
    /// <returns>An instrumented instance of the client.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the client instance cannot be created or when the client type fails validation.
    /// </exception>
    protected TClient CreateProxiedClient<TClient>(params object[] args) where TClient : class
    {
        var instance = Activator.CreateInstance(typeof(TClient), args);
        if (instance == null)
        {
            throw new InvalidOperationException($"Unable to create an instance of {typeof(TClient)}.");
        }
        return CreateProxyFromClient((TClient)instance);
    }

    /// <summary>
    /// Instruments a client instance with test framework interceptors for method call interception.
    /// </summary>
    /// <typeparam name="TClient">The type of client to instrument.</typeparam>
    /// <param name="client">The client instance to instrument.</param>
    /// <returns>An instrumented proxy of the client that intercepts method calls.</returns>
    public TClient CreateProxyFromClient<TClient>(TClient client) where TClient : class => (TClient)CreateProxyFromClient(typeof(TClient), client, null);

    /// <summary>
    /// Instruments a client instance with additional custom interceptors.
    /// </summary>
    /// <typeparam name="TClient">The type of client to instrument.</typeparam>
    /// <param name="client">The client instance to instrument.</param>
    /// <param name="preInterceptors">Additional interceptors to apply before the standard test framework interceptors.</param>
    /// <returns>An instrumented proxy of the client.</returns>
    protected TClient CreateProxyFromClient<TClient>(TClient client, IEnumerable<IInterceptor> preInterceptors) where TClient : class =>
        (TClient)CreateProxyFromClient(typeof(TClient), client, preInterceptors);

    /// <summary>
    /// Core implementation for instrumenting clients with test framework interceptors.
    /// </summary>
    /// <param name="clientType">The type of the client being instrumented.</param>
    /// <param name="client">The client instance to instrument.</param>
    /// <param name="preInterceptors">Optional additional interceptors to apply before the standard ones.</param>
    /// <returns>An instrumented proxy object that intercepts method calls.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the client type contains public non-virtual async methods that cannot be properly intercepted.
    /// </exception>
    protected internal virtual object CreateProxyFromClient(Type clientType, object client, IEnumerable<IInterceptor>? preInterceptors)
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
                        // if not, we throw the validation failed exception
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
        interceptors.Add(new ProxyResultInterceptor(this));

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
            new[] { typeof(IProxiedClient) },
            client,
            interceptors.ToArray());
    }

    /// <summary>
    /// Gets the original, non-instrumented instance from an instrumented proxy.
    /// </summary>
    /// <typeparam name="T">The type of the original instance.</typeparam>
    /// <param name="proxied">The instrumented proxy instance.</param>
    /// <returns>The original instance that was wrapped by the proxy.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="proxied"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when <paramref name="proxied"/> is not an instrumented proxy type.
    /// </exception>
    protected T GetOriginal<T>(T proxied)
    {
        if (proxied == null) throw new ArgumentNullException(nameof(proxied));
        var i = proxied as IProxiedClient ?? throw new InvalidOperationException($"{proxied.GetType()} is not an instrumented type");
        return (T)i.Original;
    }
}
